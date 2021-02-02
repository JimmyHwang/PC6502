using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

    public CpuWindow() {
      InitializeComponent();
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

    private void button_Step_Click(object sender, EventArgs e) {
      VM_Run(VM, 1);
      String jstr;

      jstr = Marshal.PtrToStringAnsi(VM_GetRegisters(VM));
      //Marshal.FreeHGlobal(t);
      Console.WriteLine(jstr);
      dynamic regs_data = json_decode(jstr);
      string pc_str = regs_data.Registers.PC;
      UInt16 pc = Convert.ToUInt16(pc_str, 16);
      Console.WriteLine(pc);

      jstr = Marshal.PtrToStringAnsi(VM_Disassembly(VM, pc, 10));
      dynamic lines_data = json_decode(jstr);
      listView_Opcode.Items.Clear();
      foreach (dynamic line in lines_data.Lines) {
        ListViewItem lvitem = new ListViewItem();
        lvitem.Text = line.Address;
        lvitem.SubItems.Add((string)line.Opcode);
        lvitem.SubItems.Add((string)line.Disassembly);
        listView_Opcode.Items.Add(lvitem);
      }
      //Marshal.FreeHGlobal(t);
      //Console.WriteLine(jstr);

    }
  }
}
