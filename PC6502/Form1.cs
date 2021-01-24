using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;     // *MUST* Need for [DllImport ...]

namespace PC6502 {
  public partial class Form1 : Form {
    [DllImport(@"D:\MyGIT\PC6502\x64\Debug\CPU_6502.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern int InitializeVM();
    [DllImport(@"D:\MyGIT\PC6502\x64\Debug\CPU_6502.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern unsafe int LoadBIOS(string filename);

    public Form1() {
      InitializeComponent();
    }

    private void button_Test_Click(object sender, EventArgs e) {
      InitializeVM();
      string fn = "BIOS.bin";
      LoadBIOS(fn);
    }
  }
}
