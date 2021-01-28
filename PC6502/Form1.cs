using System;
using System.IO;
using System.Dynamic;
using Microsoft.Win32;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;     // *MUST* Need for [DllImport ...]
using Newtonsoft.Json.Linq;
using static DNA64.Library.Common;

namespace PC6502 {
  public partial class Form1 : Form {
    [DllImport(@"D:\MyGIT\PC6502\x64\Debug\CPU_6502.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern unsafe IntPtr CreateVM();
    [DllImport(@"D:\MyGIT\PC6502\x64\Debug\CPU_6502.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern unsafe int FreeVM(IntPtr VM);
    [DllImport(@"D:\MyGIT\PC6502\x64\Debug\CPU_6502.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern unsafe int LoadBIOS(string filename);

    string ConfigFile;
    dynamic ConfigData;
    string ProjectFile;
    dynamic ProjectData;
    IntPtr VM;
    
    public Form1() {
      VM = IntPtr.Zero;
      ConfigData = new ExpandoObject();
      NewProject();
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e) {
      ConfigFile = System.Reflection.Assembly.GetEntryAssembly().Location;
      ConfigFile = ConfigFile.Replace(".exe", ".cfg");
      //
      // Read Config File
      //
      LoadConfig();
      Config2UI();
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
      UI2Config();
      SaveConfig();
    }

    private void button_Test_Click(object sender, EventArgs e) {
      //InitializeVM();
      //string fn = "BIOS.bin";
      //LoadBIOS(fn);
    }

    private void button1_Click(object sender, EventArgs e) {
      //recentFilesToolStripMenuItem
      //recentFilesToolStripMenuItem.DropDownItems.Clear();
      //recentFilesToolStripMenuItem.DropDownItems.Add("ABC");
      dynamic a = new ExpandoObject();
      a.Base = "0xE000";
      int a_base = Convert.ToInt32((string)a.Base,16);
      Console.WriteLine(a_base);
      //int b_base = Convert.ToInt32((string)b.Base);

      //var form = new XIO_LedClock();
      //form.Show();
    }

    private void loadToolStripMenuItem_Click(object sender, EventArgs e) {
      var open_dialog = new OpenFileDialog();
      open_dialog.InitialDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
      open_dialog.FileName = "New project file";
      open_dialog.Filter = "Project files (*.prj)|*.prj";
      open_dialog.Title = "Open project file";
      open_dialog.Multiselect = false;
      if (ProjectFile != null) {
        open_dialog.FileName = Path.GetFileName(ProjectFile);
        open_dialog.InitialDirectory = Path.GetDirectoryName(ProjectFile);
      }
      var result = open_dialog.ShowDialog();
      if (result == DialogResult.OK) {
        ProjectFile = open_dialog.FileName;
        LoadProject(open_dialog.FileName);
      }
    }

    private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
      if (ProjectFile == null) {
        saveAsToolStripMenuItem_Click(sender, e);
      } else {
        SaveProject(ProjectFile);
      }
    }

    private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) {
      var save_dialog = new SaveFileDialog();
      save_dialog.InitialDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
      save_dialog.FileName = "Untitled";
      save_dialog.Filter = "Project files (*.prj)|*.prj";
      save_dialog.Title = "Save As";
      if (ProjectFile != null) {
        save_dialog.InitialDirectory = Path.GetDirectoryName(ProjectFile);
        save_dialog.FileName = Path.GetFileName(ProjectFile);
      }
      var result = save_dialog.ShowDialog();
      if (result == DialogResult.OK) {
        SaveProject(save_dialog.FileName);
        ProjectFile = save_dialog.FileName;
      }
    }

    void NewProject() {
      ProjectData = new ExpandoObject();
      ProjectData.Device = new JArray();
    }
    
    void LoadProject(string filename) {
      string json_data = File.ReadAllText(filename);
      ProjectData = json_decode(json_data);
      AddFileToRecentFiles(filename);
      if (!isset(ConfigData, "Device")) {
        ConfigData.Device = new JArray();
      }
      Config2UI();
      ProjectFile = filename;
    }

    void SaveProject(string filename) {
      UI2Config();
      string json_data = json_encode(ProjectData);
      File.WriteAllText(filename, json_data);
      AddFileToRecentFiles(filename);
      ProjectFile = filename;
    }

    void AddFileToRecentFiles(string filename) {
      bool found = false;
      foreach(string fn in ConfigData["RecentFiles"]) {
        if (fn == filename) {
          found = true;
          break;
        }
      }
      if (found == false) {
        ConfigData["RecentFiles"].Add(filename);
      }
    }

    void LoadConfig() {
      if (File.Exists(ConfigFile)) {
        string json_data = File.ReadAllText(@ConfigFile);
        ConfigData = json_decode(json_data);
      } else {
        ConfigData = new JObject();
      }
    }

    void SaveConfig() {
      //
      // Write setting to Config file
      //
      string json_data = json_encode(ConfigData);
      File.WriteAllText(@ConfigFile, json_data);
    }

    void Config2UI() {
      //
      // Sort device
      //
      int update_count;
      if (ProjectData.Device.Count >= 2) {
        do {
          update_count = 0;
          for (int i = 0; i < ProjectData.Device.Count - 1; i++) {
            dynamic a = ProjectData.Device[i];
            dynamic b = ProjectData.Device[i + 1];
            int a_base = Convert.ToInt32((string)a.Base, 16);
            int b_base = Convert.ToInt32((string)b.Base, 16);
            if (a_base > b_base) {
              ProjectData.Device[i] = b;
              ProjectData.Device[i + 1] = a;
              update_count++;
            }
          }
        } while (update_count > 0);
      }
      //
      // Update to Recent files 
      //
      recentFilesToolStripMenuItem.DropDownItems.Clear();
      if (ConfigData.ContainsKey("RecentFiles")) {
        dynamic files = ConfigData["RecentFiles"];
        foreach (string file in files) {
          ToolStripMenuItem item = new ToolStripMenuItem(file, null, RecentFile_click);
          recentFilesToolStripMenuItem.DropDownItems.Add(item);
        }        
      } else {
        ConfigData["RecentFiles"] = new JArray();
      }
      //
      // Update listView_Device
      //
      listView_Device.Items.Clear();
      foreach(dynamic item in ProjectData.Device) {
        ListViewItem lvitem = new ListViewItem();
        lvitem.Tag = (string)item.UUID;
        lvitem.Text = (string)item.Type;
        lvitem.SubItems.Add((string)item.Base);
        lvitem.SubItems.Add((string)item.Size);
        listView_Device.Items.Add(lvitem);
      }
    }

    void RecentFile_click(object sender, EventArgs e) {
      var menuItem = sender as ToolStripMenuItem;
      var filename = menuItem.Text;
      LoadProject(filename);
    }

    void UI2Config() {

    }

    private void loadROMToolStripMenuItem_Click(object sender, EventArgs e) {
      var open_dialog = new OpenFileDialog();
      open_dialog.InitialDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
      open_dialog.FileName = "Default";
      open_dialog.Filter = "ROM files (*.bin)|*.bin";
      open_dialog.Title = "Load ROM file";
      open_dialog.Multiselect = false;
      if (ProjectFile != null) {
        open_dialog.FileName = Path.GetFileName(ProjectFile);
        open_dialog.InitialDirectory = Path.GetDirectoryName(ProjectFile);
      }
      var result = open_dialog.ShowDialog();
      if (result == DialogResult.OK) {
        LoadProject(open_dialog.FileName);
        ProjectFile = open_dialog.FileName;
      }
    }

    private void button_Add_Click(object sender, EventArgs e) {
      var device_dialog = new DeviceEditor();
      device_dialog.Data = new JObject();
      var result = device_dialog.ShowDialog();
      if (result == DialogResult.OK) {
        ProjectData.Device.Add(device_dialog.Data);
        Config2UI();
      }
    }

    dynamic FindDeviceByUUID (string UUID) {
      dynamic result = null;
      foreach (dynamic device in ProjectData.Device) {
        if (device.UUID == UUID) {
          result = device;
          break;
        }
      }
      return result;
    }

    void UpdateDeviceByUUID(string UUID, dynamic Device) {
      foreach (dynamic device in ProjectData.Device) {
        if (device.UUID == UUID) {
          device.Type = Device.Type;
          device.Base = Device.Base;
          device.Size = Device.Size;
          break;
        }
      }
    }

    private void listView_Device_DoubleClick(object sender, EventArgs e) {
      if (listView_Device.SelectedItems.Count > 0) {
         var lvitem = listView_Device.SelectedItems[0];
        string UUID = (string)lvitem.Tag;
        dynamic device_data = FindDeviceByUUID(UUID);
        //
        //
        //
        var device_dialog = new DeviceEditor();
        device_dialog.Data = device_data;
        var result = device_dialog.ShowDialog();
        if (result == DialogResult.OK) {
          //JObject data = json_decode(json_encode(device_dialog.Data));
          UpdateDeviceByUUID((string)device_dialog.Data.UUID, device_dialog.Data);
          Config2UI();
        }
      }
    }

    private void button_Reset_Click(object sender, EventArgs e) {
      if (VM == IntPtr.Zero) {
        VM = CreateVM();
        FreeVM(VM);
      }
      //InitializeVM();

    }
  }
}
