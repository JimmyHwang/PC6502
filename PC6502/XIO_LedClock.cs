﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PC6502 {
  public partial class XIO_LedClock : Form {
    public XIO_LedClock() {
      InitializeComponent();
    }

    private void button_Minute_Click(object sender, EventArgs e) {
      //sevenSegment1.Value = "1";
      sevenSegment1.CustomPattern = 0x11;
      //sevenSegment1.
      SystemSounds.Beep.Play();
    }

    private void button_Second_Click(object sender, EventArgs e) {
      SystemSounds.Beep.Play();
    }

    private void button_Reset_Click(object sender, EventArgs e) {
      SystemSounds.Beep.Play();
    }

    private void button_StartStop_Click(object sender, EventArgs e) {
      SystemSounds.Beep.Play();
    }

    public void Callback(dynamic cmd) {
      /*
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
      */
      //Console.WriteLine("XIO Form:"+jstr);      
    }

  }
}
