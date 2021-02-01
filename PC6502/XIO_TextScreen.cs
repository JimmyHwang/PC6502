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

namespace PC6502 {
  public partial class XIO_Screen : Form {
    byte[] VideoBuffer;
    int VideoMode;
    public int MODE_MONO_320x240 = 1;

    public XIO_Screen() {
      InitializeComponent();
      SetVideoMode(MODE_MONO_320x240);
    }

    void SetVideoMode(int mode) {
      if (mode == MODE_MONO_320x240) {
        VideoBuffer = new byte[320 * 240 / 8];
        VideoMode = mode;
      } else {
        VideoMode = -1;
      }
    }

    void PaintToScreen() {
      Bitmap b = new Bitmap(640, 480);
      if (VideoMode == MODE_MONO_320x240) {

      }
      //Byte Buffer[];
      //byte[] buffer = new byte[length];
      //IntPtr beginPtr = GetCurrentImage();
      //Marshal.Copy(beginPtr, buffer, 0, length);
    }

    private void button1_Click(object sender, EventArgs e) {
      Font font = new Font("Tahoma", 20);

      Bitmap b = new Bitmap(640, 480);
      using (Graphics g = Graphics.FromImage(b)) {
        g.FillRectangle(Brushes.White, new Rectangle(0, 0,
            b.Width, b.Height));

        g.DrawString("text", font, Brushes.Black, 50, 60);
      }
      pictureBox_Screen.BackgroundImage = b;
      //pictureBox_Screen.Size = b.Size;
    }
  }
}
