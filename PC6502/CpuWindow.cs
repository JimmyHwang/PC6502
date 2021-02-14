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
    public static extern unsafe int VM_Run(IntPtr VM, UInt32 Count);
    [DllImport(@"CPU_6502.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern unsafe int VM_Halt(IntPtr VM);
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
    public const UInt32 VM_THREAD_FLAG = 0x80000000;
    public const UInt32 VM_STEP_OVER_FLAG = 0x01000000;
    public const int RUNNING_FLAGS_STOP = 0;
    public const int RUNNING_FLAGS_START = 1;
    public const int RUNNING_FLAGS_THREAD = 2;

    public Form1 Master;
    public IntPtr VM;
    List<UInt16> InstructionAddress = new List<UInt16>();
    int Running = 0;                    // 0: Stop, 1: Run, 3: Run with Thread
    BREAK_POINT_CLASS BpObj = new BREAK_POINT_CLASS();
    UInt16 ExecutionCount = 0x10;

    public CpuWindow() {
      InitializeComponent();
    }

    private void CpuWindow_Load(object sender, EventArgs e) {
      RefreshCpuStatus();
      Form1 master = this.Master;
      dynamic pref = master.ConfigData.Preferences;
      double exec_inteleaved = Evaluate((string)pref.ExecutionInterleaved);
      timer_CPU.Interval = (int)(exec_inteleaved * 1000);
      ExecutionCount = (UInt16)Convert.ToUInt16((string)pref.ExecutionCount, 16);
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
      VM_Run(VM, 1);
      RefreshCpuStatus();
    }

    private void button_StepOver_Click(object sender, EventArgs e) {
      VM_SetIgnoreBPs(1);
      VM_Run(VM, VM_STEP_OVER_FLAG + 1);
      RefreshCpuStatus();
    }

    private void button_Reset_Click(object sender, EventArgs e) {
      VM_Reset(VM);
      SwitchRunStop(RUNNING_FLAGS_STOP);
    }

    private void button_Reload_Click(object sender, EventArgs e) {
      VM_Reload();
      VM_Reset(VM);
      SwitchRunStop(RUNNING_FLAGS_STOP);
    }

    // 
    // Bit 0 = Run Flag
    // Bit 1 = Thread Flag
    //
    void SwitchRunStop(int run_mode) {
      if (run_mode == RUNNING_FLAGS_STOP) {               // Stop
        if ((Running & RUNNING_FLAGS_THREAD) != 0) {
          VM_Halt(VM);
        } else {
          timer_CPU.Enabled = false;
        }
        Running = run_mode;
        button_Run.Text = "Run";
        RefreshCpuStatus();
        button_StepOver.Enabled = true;
        button_Step.Enabled = true;
      } else if ((run_mode & RUNNING_FLAGS_START) != 0) { // Run
        if ((run_mode & RUNNING_FLAGS_THREAD) != 0) {
          VM_Run(VM, VM_THREAD_FLAG + 0);
        } else {
          timer_CPU.Enabled = true;
        }
        Running = run_mode;
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
      if (Running == 0) {               // Stop to Run
        Form1 master = this.Master;
        if (master.ConfigData.Preferences.ExecutionMode == "Multi-Thread") {
          SwitchRunStop(RUNNING_FLAGS_START | RUNNING_FLAGS_THREAD);
        } else {
          SwitchRunStop(RUNNING_FLAGS_START);
        }
      } else {                          // Run to Stop
        SwitchRunStop(RUNNING_FLAGS_STOP);
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
        lvitem.Text = bp.Data.Address.ToString("X");
        string cond_str = "";
        bool show_data = false;
        if ((bp.Data.Access & 1) != 0) {
          cond_str += "E";
        }
        if ((bp.Data.Access & 2) != 0) {
          cond_str += "R";
        }
        if ((bp.Data.Access & 4) != 0) {
          cond_str += "W";
        }
        if ((bp.Data.Access & 1) != 0) {
          if ((bp.Data.Register & 1) != 0) {
            cond_str += "A";
          }
          if ((bp.Data.Register & 2) != 0) {
            cond_str += "X";
          }
          if ((bp.Data.Register & 4) != 0) {
            cond_str += "Y";
          }
        }
        if ((bp.Data.Compare & 1) != 0) {
          cond_str += "=";
        }
        if ((bp.Data.Compare & 2) != 0) {
          cond_str += ">";
        }
        if ((bp.Data.Compare & 4) != 0) {
          cond_str += "<";
        }
        if ((bp.Data.Access & 1) != 0 &&    // Need reg & compare for Execution break
            bp.Data.Register != 0 &&
            bp.Data.Compare != 0) {
          show_data = true;
        }
        if ((bp.Data.Access & 6) != 0 &&    // Need compare for mR/mW break
            bp.Data.Compare != 0) {
          show_data = true;
        }
        if (show_data) {
          cond_str += bp.Data.Data.ToString("X");
        }        
        lvitem.SubItems.Add(cond_str);
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
        JObject item = json_decode(json_encode(bp_item.Data));
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
        var opcode_addr = lvitem.SubItems[1].Text;
        UInt16 bp_addr = Convert.ToUInt16(opcode_addr, 16);
        BpObj.Toggle(bp_addr);
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

    private void listView_BPs_MouseClick(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Right) {
        if (listView_BPs.FocusedItem.Bounds.Contains(e.Location)) {
          contextMenuStrip_BP.Show(Cursor.Position);
        }
      }
    }

    private void listView_BPs_MouseDoubleClick(object sender, MouseEventArgs e) {
      editToolStripMenuItem_Click(sender, e);
    }

    private void button_AddBP_Click(object sender, EventArgs e) {
      var f = new BpEditor();
      var result = f.ShowDialog();
      if (result == DialogResult.OK) {
        dynamic Data = f.Data;
        BREAK_POINT bp = BpObj.Toggle(Data.Address);
        if (bp != null) {
          bp.Data = f.Data;
          BpObj2UI();
          VM_UpdateBPs();
          RefreshCpuStatus();
        }
      }
    }

    private void editToolStripMenuItem_Click(object sender, EventArgs e) {
      var f = new BpEditor();
      if (listView_BPs.SelectedItems.Count > 0) {
        ListViewItem lvitem = listView_BPs.SelectedItems[0];
        UInt16 addr = Convert.ToUInt16(lvitem.Text, 16);
        BREAK_POINT bp = BpObj.Find(addr);
        f.Data = bp.Data;
        var result = f.ShowDialog();
        if (result == DialogResult.OK) {
          bp.Data = f.Data;
          BpObj2UI();
          VM_UpdateBPs();
          RefreshCpuStatus();
        }
      }
    }

    private void CpuWindow_FormClosing(object sender, FormClosingEventArgs e) {
      if (Running != RUNNING_FLAGS_STOP) {
        SwitchRunStop(RUNNING_FLAGS_STOP);
      }
    }

    public void Timer() {
      int Status;
      //
      // Running with Timer only work with START=1 and THREAD=0
      //
      if ((Running & RUNNING_FLAGS_THREAD) == 0 && (Running & RUNNING_FLAGS_START) != 0) {
        Status = VM_Run(VM, ExecutionCount);
        if (Status == DNA_BREAK_POINT) {
          SwitchRunStop(RUNNING_FLAGS_STOP);
        }
      }
    }

    private void timer_CPU_Tick(object sender, EventArgs e) {
      Timer();
    }
  }
}
