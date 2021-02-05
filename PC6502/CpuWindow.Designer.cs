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
      this.button_Run = new System.Windows.Forms.Button();
      this.button_Step = new System.Windows.Forms.Button();
      this.button_Reset = new System.Windows.Forms.Button();
      this.listView_MemoryHistory = new System.Windows.Forms.ListView();
      this.columnHeader_RW = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader_Address = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader_Data = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.listView_Registers = new System.Windows.Forms.ListView();
      this.columnHeader_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader_Value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
      this.listView_Opcode.Size = new System.Drawing.Size(321, 389);
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
      // button_Run
      // 
      this.button_Run.Location = new System.Drawing.Point(339, 41);
      this.button_Run.Name = "button_Run";
      this.button_Run.Size = new System.Drawing.Size(75, 23);
      this.button_Run.TabIndex = 2;
      this.button_Run.Text = "Run";
      this.button_Run.UseVisualStyleBackColor = true;
      this.button_Run.Click += new System.EventHandler(this.button_Run_Click);
      // 
      // button_Step
      // 
      this.button_Step.Location = new System.Drawing.Point(339, 70);
      this.button_Step.Name = "button_Step";
      this.button_Step.Size = new System.Drawing.Size(75, 23);
      this.button_Step.TabIndex = 3;
      this.button_Step.Text = "Step";
      this.button_Step.UseVisualStyleBackColor = true;
      this.button_Step.Click += new System.EventHandler(this.button_Step_Click);
      // 
      // button_Reset
      // 
      this.button_Reset.Location = new System.Drawing.Point(339, 12);
      this.button_Reset.Name = "button_Reset";
      this.button_Reset.Size = new System.Drawing.Size(75, 23);
      this.button_Reset.TabIndex = 4;
      this.button_Reset.Text = "Reset";
      this.button_Reset.UseVisualStyleBackColor = true;
      this.button_Reset.Click += new System.EventHandler(this.button_Reset_Click);
      // 
      // listView_MemoryHistory
      // 
      this.listView_MemoryHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_RW,
            this.columnHeader_Address,
            this.columnHeader_Data});
      this.listView_MemoryHistory.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.listView_MemoryHistory.FullRowSelect = true;
      this.listView_MemoryHistory.HideSelection = false;
      this.listView_MemoryHistory.Location = new System.Drawing.Point(582, 12);
      this.listView_MemoryHistory.Name = "listView_MemoryHistory";
      this.listView_MemoryHistory.Scrollable = false;
      this.listView_MemoryHistory.Size = new System.Drawing.Size(156, 389);
      this.listView_MemoryHistory.TabIndex = 9;
      this.listView_MemoryHistory.UseCompatibleStateImageBehavior = false;
      this.listView_MemoryHistory.View = System.Windows.Forms.View.Details;
      // 
      // columnHeader_RW
      // 
      this.columnHeader_RW.Text = "R/W";
      this.columnHeader_RW.Width = 36;
      // 
      // columnHeader_Address
      // 
      this.columnHeader_Address.Text = "Address";
      this.columnHeader_Address.Width = 61;
      // 
      // columnHeader_Data
      // 
      this.columnHeader_Data.Text = "Data";
      this.columnHeader_Data.Width = 48;
      // 
      // listView_Registers
      // 
      this.listView_Registers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_Name,
            this.columnHeader_Value});
      this.listView_Registers.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.listView_Registers.FullRowSelect = true;
      this.listView_Registers.HideSelection = false;
      this.listView_Registers.Location = new System.Drawing.Point(420, 12);
      this.listView_Registers.Name = "listView_Registers";
      this.listView_Registers.Size = new System.Drawing.Size(156, 156);
      this.listView_Registers.TabIndex = 10;
      this.listView_Registers.UseCompatibleStateImageBehavior = false;
      this.listView_Registers.View = System.Windows.Forms.View.Details;
      // 
      // columnHeader_Name
      // 
      this.columnHeader_Name.Text = "Name";
      this.columnHeader_Name.Width = 51;
      // 
      // columnHeader_Value
      // 
      this.columnHeader_Value.Text = "Value";
      this.columnHeader_Value.Width = 95;
      // 
      // CpuWindow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 540);
      this.Controls.Add(this.listView_Registers);
      this.Controls.Add(this.listView_MemoryHistory);
      this.Controls.Add(this.button_Reset);
      this.Controls.Add(this.button_Step);
      this.Controls.Add(this.button_Run);
      this.Controls.Add(this.listView_Opcode);
      this.Name = "CpuWindow";
      this.Text = "CPU";
      this.Load += new System.EventHandler(this.CpuWindow_Load);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ListView listView_Opcode;
    private System.Windows.Forms.Button button_Run;
    private System.Windows.Forms.Button button_Step;
    private System.Windows.Forms.ColumnHeader columnHeader_IP;
    private System.Windows.Forms.ColumnHeader columnHeader_Opcode;
    private System.Windows.Forms.ColumnHeader columnHeader_Instruction;
    private System.Windows.Forms.Button button_Reset;
    private System.Windows.Forms.ListView listView_MemoryHistory;
    private System.Windows.Forms.ColumnHeader columnHeader_RW;
    private System.Windows.Forms.ColumnHeader columnHeader_Address;
    private System.Windows.Forms.ColumnHeader columnHeader_Data;
    private System.Windows.Forms.ListView listView_Registers;
    private System.Windows.Forms.ColumnHeader columnHeader_Name;
    private System.Windows.Forms.ColumnHeader columnHeader_Value;
  }
}