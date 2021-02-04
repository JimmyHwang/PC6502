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
    [DllImport(@"D:\MyGIT\PC6502\x64\Debug\CPU_6502.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern unsafe int VM_Reset(IntPtr VM);
    [DllImport(@"D:\MyGIT\PC6502\x64\Debug\CPU_6502.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern unsafe int VM_Run(IntPtr VM, int Count);
    [DllImport(@"D:\MyGIT\PC6502\x64\Debug\CPU_6502.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern unsafe IntPtr VM_GetRegisters(IntPtr VM);
    [DllImport(@"D:\MyGIT\PC6502\x64\Debug\CPU_6502.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern unsafe IntPtr VM_Disassembly(IntPtr VM, UInt16 Base, int lines);

    public IntPtr VM;
    UInt16 DisassemblyBase;
    int DisassemblyCursor;
    List<UInt16> InstructionAddress = new List<UInt16>();

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

    void RefreshRegisterStatus(dynamic regs) {
      listView_Registers.Items.Clear();
      foreach(var reg in regs) {
        var key = reg.Key;
        var data = reg.Value;
        ListViewItem lvitem = new ListViewItem();
        lvitem.Text = (string)key;
        lvitem.SubItems.Add(data.ToString("X2"));        
        listView_Registers.Items.Add(lvitem);
      }
    }

    void RefreshCpuStatus() {
      String jstr;
      UInt16 disasm_base = 0;
      UInt16 addr;
      string regs_str;
      dynamic regs = new ExpandoObject();

      jstr = Marshal.PtrToStringAnsi(VM_GetRegisters(VM));
      dynamic jdata = json_decode(jstr);
      regs.A = Convert.ToByte((string)jdata.Registers.A, 16);
      regs.X = Convert.ToByte((string)jdata.Registers.X, 16);
      regs.Y = Convert.ToByte((string)jdata.Registers.Y, 16);
      regs.PC = Convert.ToUInt16((string)jdata.Registers.PC, 16);
      regs.SP = Convert.ToByte((string)jdata.Registers.SP, 16);
      regs_str = string.Format("A={0:X2}, X={1:X2}, Y={2:X2}, PC={3:X4}, SP={4:X2}", regs.A, regs.X, regs.Y, regs.PC, regs.SP);
      textBox_Registers.Text = regs_str;
      RefreshRegisterStatus(regs);

      string pc_str = jdata.Registers.PC;
      UInt16 pc = Convert.ToUInt16(pc_str, 16);
      disasm_base = FindBestDisassemblyAddress(pc, 10);
      jstr = Marshal.PtrToStringAnsi(VM_Disassembly(VM, disasm_base, 20));
      dynamic lines_data = json_decode(jstr);
      listView_Opcode.Items.Clear();
      int index = 0;
      foreach (dynamic line in lines_data.Lines) {
        ListViewItem lvitem = new ListViewItem();
        addr = Convert.ToUInt16((string)line.Address, 16);
        if (addr == pc) {
          DisassemblyCursor = index;
        }
        lvitem.Text = line.Address;
        lvitem.SubItems.Add((string)line.Opcode);
        lvitem.SubItems.Add((string)line.Disassembly);
        listView_Opcode.Items.Add(lvitem);
        index++;
      }
      listView_Opcode.Items[DisassemblyCursor].Selected = true;
      listView_Opcode.Select();
    }

    private void button_Step_Click(object sender, EventArgs e) {
      VM_Run(VM, 1);
      RefreshCpuStatus();
    }

    private void button_Reset_Click(object sender, EventArgs e) {
      VM_Reset(VM);
    }

    private void button_Run_Click(object sender, EventArgs e) {

    }

  }
}
