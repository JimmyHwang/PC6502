namespace PC6502 {
  partial class CpuWindow {
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
      this.listView_Opcode = new System.Windows.Forms.ListView();
      this.columnHeader_IP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader_Opcode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader_Instruction = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.button1 = new System.Windows.Forms.Button();
      this.button_Run = new System.Windows.Forms.Button();
      this.button_Step = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // listView_Opcode
      // 
      this.listView_Opcode.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_IP,
            this.columnHeader_Opcode,
            this.columnHeader_Instruction});
      this.listView_Opcode.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.listView_Opcode.FullRowSelect = true;
      this.listView_Opcode.HideSelection = false;
      this.listView_Opcode.Location = new System.Drawing.Point(12, 12);
      this.listView_Opcode.MultiSelect = false;
      this.listView_Opcode.Name = "listView_Opcode";
      this.listView_Opcode.Size = new System.Drawing.Size(321, 363);
      this.listView_Opcode.TabIndex = 0;
      this.listView_Opcode.UseCompatibleStateImageBehavior = false;
      this.listView_Opcode.View = System.Windows.Forms.View.Details;
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
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(12, 381);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 1;
      this.button1.Text = "Reset";
      this.button1.UseVisualStyleBackColor = true;
      // 
      // button_Run
      // 
      this.button_Run.Location = new System.Drawing.Point(93, 381);
      this.button_Run.Name = "button_Run";
      this.button_Run.Size = new System.Drawing.Size(75, 23);
      this.button_Run.TabIndex = 2;
      this.button_Run.Text = "Run";
      this.button_Run.UseVisualStyleBackColor = true;
      // 
      // button_Step
      // 
      this.button_Step.Location = new System.Drawing.Point(174, 381);
      this.button_Step.Name = "button_Step";
      this.button_Step.Size = new System.Drawing.Size(75, 23);
      this.button_Step.TabIndex = 3;
      this.button_Step.Text = "Step";
      this.button_Step.UseVisualStyleBackColor = true;
      this.button_Step.Click += new System.EventHandler(this.button_Step_Click);
      // 
      // CpuWindow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.button_Step);
      this.Controls.Add(this.button_Run);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.listView_Opcode);
      this.Name = "CpuWindow";
      this.Text = "Emulator";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ListView listView_Opcode;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button_Run;
    private System.Windows.Forms.Button button_Step;
    private System.Windows.Forms.ColumnHeader columnHeader_IP;
    private System.Windows.Forms.ColumnHeader columnHeader_Opcode;
    private System.Windows.Forms.ColumnHeader columnHeader_Instruction;
  }
}