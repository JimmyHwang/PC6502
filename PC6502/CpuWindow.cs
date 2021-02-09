using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DNA64.Library.Common;

namespace PC6502 {
  public partial class CpuWindow : Form {
    [DllImport(@"CPU_6502.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern unsafe int VM_Reset(IntPtr VM);
    [DllImport(@"CPU_6502.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern unsafe int VM_Run(IntPtr VM, int Count);
    [DllImport(@"CPU_6502.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern unsafe IntPtr VM_GetRegisters(IntPtr VM);
    [DllImport(@"CPU_6502.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern unsafe IntPtr VM_Disassembly(IntPtr VM, UInt16 Base, int lines);
    [DllImport(@"CPU_6502.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern unsafe IntPtr VM_GetMemoryHistory(IntPtr VM);
    [DllImport(@"CPU_6502.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern unsafe IntPtr VM_Talk(IntPtr VM, string msg);

    public const int DNA_SUCCESS = 0x00;
    public const int DNA_BREAK_POINT = 0x10;
    public const int VM_STEP_OVER_FLAG = 0x1000000;

    public IntPtr VM;
    List<UInt16> InstructionAddress = new List<UInt16>();
    bool Running = false;
    BREAK_POINT_CLASS BpObj = new BREAK_POINT_CLASS();
    int VM_OperationFlags = 0;

    public CpuWindow() {
      InitializeComponent();
    }

    private void CpuWindow_Load(object sender, EventArgs e) {
      RefreshCpuStatus();
    }

    public void Callback(dynamic cmd) {
      if (cmd == "Running") {
        listView_Opcode.Items.Clear();
        foreach (dynamic line in cmd.Lines) {
          ListViewItem lvitem = new ListViewItem();
          lvitem.Text = line.Address;
          lvitem.SubItems.Add(line.Opcode);
          lvitem.SubItems.Add(line.Disassembly);
          listView_Opcode.Items.Add(lvitem);
        }
      }
      //Console.WriteLine("CPU Form:"+jstr);      
    }

    void ClearBreakPointBitmap() {
      BpObj.Clear();
    }

    UInt16 FindBestDisassemblyAddress(UInt16 pc, int count) {
      UInt16 result = 0;
      int index;

      index = InstructionAddress.IndexOf(pc);
      if (index < 0) {
        InstructionAddress.Add(pc);
        InstructionAddress.Sort();
        result = pc;
      }
      index = InstructionAddress.IndexOf(pc);
      do {
        if (index == 0 || count == 0) {
          result = pc;
          break;
        }
        index--;
        if (InstructionAddress[index] >= pc - 3) {
          pc = InstructionAddress[index];
          count--;
        } else {
          result = pc;
          break;
        }
      } while (true);

      return result;
    }

    void RefreshMemoryHistory(dynamic history) {
      string mode;
      int skip_count = 0;
      int rows;
      int index;
      int cursor;

      //rows = listView_MemoryHistory.ClientSize.Height / listView_MemoryHistory.Font.Height;
      rows = 20;
      int total = history.Count;
      if (total > rows) {
        skip_count = total - rows;
      }

      listView_MemoryHistory.Items.Clear();
      index = 0;
      cursor = 0;
      foreach (var record in history) {
        if (skip_count > 0) {
          skip_count--;
          continue;
        }
        ListViewItem lvitem = new ListViewItem();
        if (record.Mode == 0) {
          mode = "R";
        } else {
          mode = "W";
        }
        lvitem.Text = mode;
        lvitem.SubItems.Add(record.Address.ToString("X2"));
        lvitem.SubItems.Add(record.Data.ToString("X2"));
        listView_MemoryHistory.Items.Add(lvitem);
        cursor = index;
        index++;
      }
      listView_MemoryHistory.Items[cursor].Selected = true;
    }

    void RefreshRegisterStatus(dynamic regs) {
      byte flags = 0;
      string flags_str1 = "NVssDIZC";
      string flags_str2 = "";      
      listView_Registers.Items.Clear();
      foreach(var reg in regs) {
        var key = reg.Key;
        var data = reg.Value;
        ListViewItem lvitem = new ListViewItem();
        lvitem.Text = (string)key;
        lvitem.SubItems.Add(data.ToString("X2"));        
        listView_Registers.Items.Add(lvitem);
        if (lvitem.Text == "Flags") {
          flags = data;
        }
      }
      for (int b = 7; b >= 0; b--) {
        byte bitmask = (byte)(1 << b);
        if ((flags & bitmask) != 0) {
          flags_str2 += "1";
        } else {
          flags_str2 += "0";
        }
      }
      textBox_Status.Text = flags_str1 +"\r\n" + flags_str2;
    }

    void RefreshCpuStatus() {
      String jstr;
      UInt16 disasm_base = 0;
      UInt16 addr;
      dynamic regs = new ExpandoObject();
      dynamic jdata;
      int cursor;
      string tag;

      jstr = Marshal.PtrToStringAnsi(VM_GetRegisters(VM));
      jdata = json_decode(jstr);
      regs.A = Convert.ToByte((string)jdata.Registers.A, 16);
      regs.X = Convert.ToByte((string)jdata.Registers.X, 16);
      regs.Y = Convert.ToByte((string)jdata.Registers.Y, 16);
      regs.PC = Convert.ToUInt16((string)jdata.Registers.PC, 16);
      regs.SP = Convert.ToByte((string)jdata.Registers.SP, 16);
      regs.Flags = Convert.ToByte((string)jdata.Registers.Flags, 16);

      string pc_str = jdata.Registers.PC;
      UInt16 pc = Convert.ToUInt16(pc_str, 16);
      disasm_base = FindBestDisassemblyAddress(pc, 10);
      jstr = Marshal.PtrToStringAnsi(VM_Disassembly(VM, disasm_base, 20));
      dynamic lines_data = json_decode(jstr);
      listView_Opcode.Items.Clear();
      int index = 0;
      cursor = 0;
      foreach (dynamic line in lines_data.Lines) {
        ListViewItem lvitem = new ListViewItem();
        addr = Convert.ToUInt16((string)line.Address, 16);
        if (addr == pc) {
          cursor = index;
        }
        if (BpObj.IsExists(addr)) {
          tag = "B";
        } else {
          tag = " ";
        }
        lvitem.Text = tag;
        lvitem.SubItems.Add((string)line.Address);
        lvitem.SubItems.Add((string)line.Opcode);
        lvitem.SubItems.Add((string)line.Disassembly);
        listView_Opcode.Items.Add(lvitem);
        index++;
      }
      listView_Opcode.Items[cursor].Selected = true;
      listView_Opcode.Select();
      //
      // Update Register Pane
      //
      RefreshRegisterStatus(regs);
      //
      // Update Memory History Pane
      //
      jstr = Marshal.PtrToStringAnsi(VM_GetMemoryHistory(VM));
      jdata = json_decode(jstr);
      RefreshMemoryHistory(jdata.History);
    }

    private void button_Step_Click(object sender, EventArgs e) {
      VM_SetIgnoreBPs(1);
      VM_Run(VM, VM_OperationFlags + 1);
      RefreshCpuStatus();
    }

    private void button_StepOver_Click(object sender, EventArgs e) {
      VM_SetIgnoreBPs(1);
      VM_Run(VM, VM_OperationFlags + VM_STEP_OVER_FLAG + 1);
      RefreshCpuStatus();
    }

    private void button_Reset_Click(object sender, EventArgs e) {
      VM_Reset(VM);
      SwitchRunStop("Stop");
    }

    private void button_Reload_Click(object sender, EventArgs e) {
      VM_Reload();
      VM_Reset(VM);
      SwitchRunStop("Stop");
    }

    // 
    // Mode 0 = Stop
    // Mode 1 = Run
    //
    void SwitchRunStop(string mode) {
      if (mode == "Stop") {             // Stop
        Running = false;
        button_Run.Text = "Run";
        RefreshCpuStatus();
        button_StepOver.Enabled = true;
        button_Step.Enabled = true;
      } else if (mode == "Run") {       // Run
        Running = true;
        button_Run.Text = "Stop";
        button_StepOver.Enabled = false;
        button_Step.Enabled = false;
      }
    }

    dynamic VM_SetIgnoreBPs(int count) {
      dynamic args;
      string jstr;
      dynamic result;

      args = new ExpandoObject();
      args.Target = "CPU";
      args.Command = "SetIgnoreBPs";
      args.Count = count;
      jstr = json_encode(args);
      jstr = Marshal.PtrToStringAnsi(VM_Talk(VM, jstr));
      result = json_decode(jstr);
      return result;
    }


    private void button_Run_Click(object sender, EventArgs e) {
      VM_SetIgnoreBPs(1);
      if (Running) {                    // Switch to STOP
        SwitchRunStop("Stop");
      } else {                          // Switch to RUN
        SwitchRunStop("Run");
      }
    }

    public void Timer() {
      int Status;
      if (Running) {
        Status = VM_Run(VM, VM_OperationFlags + 16);
        if (Status == DNA_BREAK_POINT) {
          SwitchRunStop("Stop");
        }
      }      
    }

    private void listView_Opcode_MouseClick(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Right) {
        if (listView_Opcode.FocusedItem.Bounds.Contains(e.Location)) {
          contextMenuStrip_Opcode.Show(Cursor.Position);
        }
      }
    }

    void BpObj2UI() {
      int i;
      listView_BPs.Items.Clear();
      for (i=0; i<BpObj.Items.Count; i++) {
        BREAK_POINT bp = BpObj.Items[i];
        ListViewItem lvitem = new ListViewItem();
        lvitem.Text = bp.Address.ToString("X");
        lvitem.SubItems.Add(bp.Type.ToString());
        lvitem.SubItems.Add(bp.Enabled.ToString());
        listView_BPs.Items.Add(lvitem);
      }
    }

    dynamic VM_UpdateBPs() {
      dynamic args;
      string jstr;
      dynamic result;

      var items = new JArray();
      for (int i = 0; i < BpObj.Items.Count; i++) {
        var bp_item = BpObj.Items[i];
        JObject item = new JObject();
        item["Address"] = bp_item.Address;
        item["Type"] = bp_item.Type;
        item["Enabled"] = bp_item.Enabled;
        items.Add(item);
      }

      args = new ExpandoObject();
      args.Target = "CPU";
      args.Command = "UpdateBPs";
      args.Items = items;
      jstr = json_encode(args);
      jstr = Marshal.PtrToStringAnsi(VM_Talk(VM, jstr));
      result = json_decode(jstr);
      return result;
    }

    private void toggleBreakPointToolStripMenuItem_Click(object sender, EventArgs e) {
      if (listView_Opcode.SelectedItems.Count > 0) {
        ListViewItem lvitem = listView_Opcode.SelectedItems[0];
        var opcode_addrr = lvitem.SubItems[1].Text;
        UInt16 bp_addrr = Convert.ToUInt16(opcode_addrr, 16);
        BpObj.Toggle(bp_addrr);
        BpObj2UI();
        VM_UpdateBPs();
        RefreshCpuStatus();
      }
    }

    dynamic VM_Reload() {
      dynamic args;
      string jstr;
      dynamic result;

      args = new ExpandoObject();
      args.Target = "VM";
      args.Command = "Reload";      
      jstr = json_encode(args);
      jstr = Marshal.PtrToStringAnsi(VM_Talk(VM, jstr));
      result = json_decode(jstr);
      return result;
    }

  }
}
