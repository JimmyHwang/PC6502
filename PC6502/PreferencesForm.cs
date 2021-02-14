using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DNA64.Library.Common;

namespace PC6502 {
  public partial class PreferencesForm : Form {
    public dynamic Data;

    public PreferencesForm() {
      InitializeComponent();
    }

    public void DefaultConfig() {
      Config2UI();
      UI2Config();
    }

    void UI2Config() {
      //
      // System
      //
      Data.GuiRefreshTime = comboBox_GuiRefreshTime.Text;
      //
      // Emulator
      //
      Data.ExecutionMode = comboBox_ExecutionMode.Text;
      //
      // Single-Thread
      //
      Data.ExecutionInterleaved = comboBox_ExecutionInterleaved.Text;
      Data.ExecutionCount = comboBox_ExecutionCount.Text;
      //
      // Multi-Thread
      //
      Data.MtExecutionCount = comboBox_MtExecutionCount.Text;
    }

    void Config2UI() {
      //
      // System
      //
      if (!isset(Data, "GuiRefreshTime")) {
        comboBox_GuiRefreshTime.SelectedIndex = 0;
      } else {
        comboBox_GuiRefreshTime.Text = Data.GuiRefreshTime;
      }

      //
      // Emulator
      //
      if (!isset(Data, "ExecutionMode")) {
        comboBox_ExecutionMode.SelectedIndex = 0;
      } else {
        comboBox_ExecutionMode.Text = Data.ExecutionMode;
      }
      //
      // Single-Thread
      //
      if (!isset(Data, "ExecutionInterleaved")) {
        comboBox_ExecutionInterleaved.SelectedIndex = 0;
      } else {
        comboBox_ExecutionInterleaved.Text = Data.ExecutionInterleaved;
      }
      if (!isset(Data, "ExecutionCount")) {
        comboBox_ExecutionCount.SelectedIndex = 0;
      } else {
        comboBox_ExecutionCount.Text = Data.ExecutionCount;
      }
      //
      // Multi-Thread
      //
      if (!isset(Data, "MtExecutionCount")) {
        comboBox_MtExecutionCount.SelectedIndex = 0;
      } else {
        comboBox_MtExecutionCount.Text = Data.MtExecutionCount;
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

    private void PreferencesForm_Load(object sender, EventArgs e) {
      Config2UI();
    }
  }
}
