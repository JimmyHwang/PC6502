namespace PC6502 {
  partial class Emulator {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.listView_CPU = new System.Windows.Forms.ListView();
      this.button1 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.button3 = new System.Windows.Forms.Button();
      this.columnHeader_IP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader_Opcode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader_Instruction = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.SuspendLayout();
      // 
      // listView_CPU
      // 
      this.listView_CPU.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_IP,
            this.columnHeader_Opcode,
            this.columnHeader_Instruction});
      this.listView_CPU.HideSelection = false;
      this.listView_CPU.Location = new System.Drawing.Point(12, 12);
      this.listView_CPU.Name = "listView_CPU";
      this.listView_CPU.Size = new System.Drawing.Size(321, 363);
      this.listView_CPU.TabIndex = 0;
      this.listView_CPU.UseCompatibleStateImageBehavior = false;
      this.listView_CPU.View = System.Windows.Forms.View.Details;
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(12, 381);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 1;
      this.button1.Text = "Reset";
      this.button1.UseVisualStyleBackColor = true;
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(93, 381);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(75, 23);
      this.button2.TabIndex = 2;
      this.button2.Text = "Run";
      this.button2.UseVisualStyleBackColor = true;
      // 
      // button3
      // 
      this.button3.Location = new System.Drawing.Point(174, 381);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(75, 23);
      this.button3.TabIndex = 3;
      this.button3.Text = "Step";
      this.button3.UseVisualStyleBackColor = true;
      // 
      // columnHeader_IP
      // 
      this.columnHeader_IP.Text = "IP";
      // 
      // columnHeader_Opcode
      // 
      this.columnHeader_Opcode.Text = "Opcode";
      this.columnHeader_Opcode.Width = 96;
      // 
      // columnHeader_Instruction
      // 
      this.columnHeader_Instruction.Text = "Instruction";
      this.columnHeader_Instruction.Width = 150;
      // 
      // Emulator
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.button3);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.listView_CPU);
      this.Name = "Emulator";
      this.Text = "Emulator";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ListView listView_CPU;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.ColumnHeader columnHeader_IP;
    private System.Windows.Forms.ColumnHeader columnHeader_Opcode;
    private System.Windows.Forms.ColumnHeader columnHeader_Instruction;
  }
}