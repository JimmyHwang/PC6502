using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PC6502 {
  public partial class BpEditor : Form {
    public dynamic Data = null;

    public BpEditor() {
      InitializeComponent();
      Data = new ExpandoObject();
      Data.Address = 0000;
      Data.Data = 00;
      Data.Access = 1;
      Data.Register = 0;
      Data.Compare = 0;
    }

    int GetCheckedListStatus(CheckedListBox listbox) {
      int bits = 0;
      for (int i = 0; i < listbox.Items.Count; i++) {
        if (listbox.GetItemChecked(i)) {
          bits |= 1 << i;
        }
      }
      return bits;
    }

    void SetCheckedListStatus(CheckedListBox listbox, int value) {
      bool sw;

      for (int i = 0; i < listbox.Items.Count; i++) {
        if ((value & (1 << i)) != 0) {
          sw = true;
        } else {
          sw = false;
        }
        listbox.SetItemChecked(i, sw);
      }
    }

    public void Config2UI() {
      UInt16 addr;
      byte data;

      addr = (UInt16)Data.Address;
      data = (byte)Data.Data;
      textBox_Address.Text = addr.ToString("X");
      textBox_Data.Text = data.ToString("X");
      SetCheckedListStatus(checkedListBox_Access, Data.Access);
      SetCheckedListStatus(checkedListBox_Register, Data.Register);
      SetCheckedListStatus(checkedListBox_Compare, Data.Compare);
    }

    public void UI2Config() {
      Data.Access = GetCheckedListStatus(checkedListBox_Access);
      Data.Register = GetCheckedListStatus(checkedListBox_Register);
      Data.Compare = GetCheckedListStatus(checkedListBox_Compare);
      Data.Address = Convert.ToUInt16(textBox_Address.Text, 16);
      Data.Data = Convert.ToByte(textBox_Data.Text, 16);
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

    private void BpEditor_Load(object sender, EventArgs e) {
      Config2UI();
    }
  }
}
