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

    public XIO_LedClock() {
      InitializeComponent();
    }

    void ButtonClickSound() {
      string App = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
      string AppFolder = Path.GetDirectoryName(App);
      string wave_fn = Path.Combine(AppFolder, "button-20.wav");
      PlaySound(wave_fn, new System.IntPtr(), PlaySoundFlags.SND_FILENAME | PlaySoundFlags.SND_SYNC | PlaySoundFlags.SND_NOSTOP);
    }

    private void button_Minute_Click(object sender, EventArgs e) {
      //sevenSegment1.Value = "1";
      sevenSegment1.CustomPattern = 0x11;
      ButtonClickSound();
    }

    private void button_Second_Click(object sender, EventArgs e) {
      ButtonClickSound();
    }

    private void button_Reset_Click(object sender, EventArgs e) {
      ButtonClickSound();
    }

    private void button_StartStop_Click(object sender, EventArgs e) {
      ButtonClickSound();
    }

    public void Callback(dynamic args) {
      int reg;
      reg = (int)args.Address & 0xF;

      if (reg == 0) {
        sevenSegment1.CustomPattern = (int)args.Data;
      } else if (reg == 1) {
        sevenSegment2.CustomPattern = (int)args.Data;
      } else if (reg == 2) {
        sevenSegment3.CustomPattern = (int)args.Data;
      } else if (reg == 3) {
        sevenSegment4.CustomPattern = (int)args.Data;
      }
      //Console.WriteLine("XIO Window:"+jstr);
    }

  }
}
