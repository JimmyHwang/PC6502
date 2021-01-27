using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DNA64.Library.Common;

namespace PC6502 {
  public partial class DeviceEditor : Form {
    public dynamic Data;

    public DeviceEditor() {
      InitializeComponent();
    }

    private void DeviceEditor_Load(object sender, EventArgs e) {
      if (!isset(Data, "UUID")) {
        Guid g = Guid.NewGuid();
        Data.UUID = g.ToString();
      }
      if (!isset(Data, "Type")) {
        Data.Type = "ROM";
      }
      if (!isset(Data, "Base")) {
        Data.Base = "0xE000";
      }
      if (!isset(Data, "Size")) {
        Data.Size = "0x2000";
      }
      comboBox_Type.Items.Clear();
      comboBox_Type.Items.Add("ROM");
      comboBox_Type.Items.Add("RAM");
      comboBox_Type.Items.Add("XIO");
      comboBox_Size.Items.Clear();
      comboBox_Size.Items.Add("0x1000");
      comboBox_Size.Items.Add("0x2000");
      comboBox_Size.Items.Add("0x4000");
      comboBox_Size.Items.Add("0x8000");
      comboBox_Base.Items.Clear();
      for(int addr = 0; addr<0x10000; addr += 0x1000) {
        string str = "0x"+ addr.ToString("X4");
        comboBox_Base.Items.Add(str);
      }
      Config2UI();
    }

    void Config2UI() {
      if (!isset(Data, "Type")) {
        comboBox_Type.SelectedIndex = 0;
      } else {
        comboBox_Type.SelectedText = Data.Type;
      }
      if (!isset(Data, "Size")) {
        comboBox_Size.SelectedIndex = 0;
      } else {
        comboBox_Size.SelectedText = Data.Size;
      }
      if (!isset(Data, "Base")) {
        comboBox_Base.SelectedIndex = 8;
      } else {
        comboBox_Base.SelectedText = Data.Base;
      }
      if (isset(Data, "File")) {
        textBox_File.Text = Data.File;
      }
    }

    void UI2Config() {
      Data.Type = comboBox_Type.Text;
      Data.Base = comboBox_Base.Text;
      Data.Size = comboBox_Size.Text;
      if (Data.Type == "ROM") {
        Data.File = textBox_File.Text;
      } else if (isset(Data, "File")) {
        Data.Remove("File");
      }
    }

    private void button_OK_Click(object sender, EventArgs e) {
      UI2Config();
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void button_Cancel_Click(object sender, EventArgs e) {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }

    private void button_Browser_Click(object sender, EventArgs e) {
      var open_dialog = new OpenFileDialog();
      if (textBox_File.Text != "") {
        open_dialog.FileName = Path.GetFileName(textBox_File.Text);
        open_dialog.InitialDirectory = Path.GetDirectoryName(textBox_File.Text);
      } else {
        open_dialog.InitialDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        open_dialog.FileName = "binary file";
      }
      open_dialog.Filter = "Binary files (*.bin)|*.bin";
      open_dialog.Title = "Open binary file";
      open_dialog.Multiselect = false;
      var result = open_dialog.ShowDialog();
      if (result == DialogResult.OK) {
        textBox_File.Text = open_dialog.FileName;
      }
    }
  }
}
