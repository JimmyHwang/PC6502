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
    public static extern int InitializeVM();
    [DllImport(@"D:\MyGIT\PC6502\x64\Debug\CPU_6502.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern unsafe int LoadBIOS(string filename);

    string ConfigFile;
    dynamic ConfigData;
    string ProjectFile;
    dynamic ProjectData;

    public Form1() {
      ConfigData = new ExpandoObject();
      ProjectData = new ExpandoObject();
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
      InitializeVM();
      string fn = "BIOS.bin";
      LoadBIOS(fn);
    }

    private void button1_Click(object sender, EventArgs e) {
      //recentFilesToolStripMenuItem
      recentFilesToolStripMenuItem.DropDownItems.Clear();
      recentFilesToolStripMenuItem.DropDownItems.Add("ABC");

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
        LoadProject(open_dialog.FileName);
        ProjectFile = open_dialog.FileName;
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
      save_dialog.FileName = "project";
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

    void LoadProject(string filename) {
      string json_data = File.ReadAllText(filename);
      ProjectData = json_decode(json_data);
      AddFileToRecentFiles(filename);
    }

    void SaveProject(string filename) {
      string json_data = json_encode(ProjectData);
      File.WriteAllText(filename, json_data);
      AddFileToRecentFiles(filename);
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
      recentFilesToolStripMenuItem.DropDownItems.Clear();
      if (ConfigData.ContainsKey("RecentFiles")) {
        dynamic files = ConfigData["RecentFiles"];
        foreach (string file in files) {
          recentFilesToolStripMenuItem.DropDownItems.Add(file);
        }        
      } else {
        ConfigData["RecentFiles"] = new JArray();
      }
    }

    void UI2Config() {

    }


  }
}
