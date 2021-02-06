using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Dynamic;
using static DNA64.Library.Common;

public enum PlaySoundFlags : int {
  SND_SYNC = 0x0000,
  SND_ASYNC = 0x0001,
  SND_NODEFAULT = 0x0002,
  SND_LOOP = 0x0008,
  SND_NOSTOP = 0x0010,
  SND_NOWAIT = 0x00002000,
  SND_FILENAME = 0x00020000,
  SND_RESOURCE = 0x00040004
}

namespace PC6502 {
  public partial class XIO_LedClock : Form {
    [DllImport("winmm.DLL", EntryPoint = "PlaySound", SetLastError = true, CharSet = CharSet.Unicode, ThrowOnUnmappableChar = true)]
    private static extern bool PlaySound(string szSound, System.IntPtr hMod, PlaySoundFlags flags);
    [DllImport(@"D:\MyGIT\PC6502\x64\Debug\CPU_6502.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern unsafe IntPtr VM_Talk(IntPtr VM, string msg);

    public IntPtr VM;

    public XIO_LedClock() {
      InitializeComponent();
    }

    void ButtonClickSound() {
      string App = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
      string AppFolder = Path.GetDirectoryName(App);
      string wave_fn = Path.Combine(AppFolder, "button-20.wav");
      PlaySound(wave_fn, new System.IntPtr(), PlaySoundFlags.SND_FILENAME | PlaySoundFlags.SND_SYNC | PlaySoundFlags.SND_NOSTOP);
    }

    dynamic XIO_SendClickMessage(string Name) {
      dynamic args;
      string jstr;
      dynamic result;

      args = new ExpandoObject();
      args.Target = "XIO";
      args.Command = "Click";
      args.Name = Name;
      jstr = json_encode(args);
      jstr = Marshal.PtrToStringAnsi(VM_Talk(VM, jstr));
      result = json_decode(jstr);
      return result;
    }

    private void button_Minute_Click(object sender, EventArgs e) {
      XIO_SendClickMessage("Minute");
      ButtonClickSound();
    }

    private void button_Second_Click(object sender, EventArgs e) {
      XIO_SendClickMessage("Second");
      ButtonClickSound();
    }

    private void button_Reset_Click(object sender, EventArgs e) {
      XIO_SendClickMessage("Reset");
      ButtonClickSound();
    }

    private void button_StartStop_Click(object sender, EventArgs e) {
      XIO_SendClickMessage("Start");
      ButtonClickSound();
    }

    public void Callback(dynamic args) {
      int reg;
      reg = (int)args.Address & 0xF;

      if (reg == 0) {
        sevenSegment4.CustomPattern = (int)args.Data;
      } else if (reg == 1) {
        sevenSegment3.CustomPattern = (int)args.Data;
      } else if (reg == 2) {
        sevenSegment2.CustomPattern = (int)args.Data;
      } else if (reg == 3) {
        sevenSegment1.CustomPattern = (int)args.Data;
      }
      //Console.WriteLine("XIO Window:"+jstr);
    }
  }
}
