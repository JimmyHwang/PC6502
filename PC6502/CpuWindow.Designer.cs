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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CpuWindow));
      this.listView_Opcode = new System.Windows.Forms.ListView();
      this.columnHeader_BP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
      this.button_StepOver = new System.Windows.Forms.Button();
      this.listView_BPs = new System.Windows.Forms.ListView();
      this.columnHeader_BPA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader_BPC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.contextMenuStrip_Opcode = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.toggleBreakPointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.textBox_Status = new System.Windows.Forms.TextBox();
      this.button_Reload = new System.Windows.Forms.Button();
      this.contextMenuStrip_BP = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.button_AddBP = new System.Windows.Forms.Button();
      this.contextMenuStrip_Opcode.SuspendLayout();
      this.contextMenuStrip_BP.SuspendLayout();
      this.SuspendLayout();
      // 
      // listView_Opcode
      // 
      this.listView_Opcode.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_BP,
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
      this.listView_Opcode.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_Opcode_MouseClick);
      // 
      // columnHeader_BP
      // 
      this.columnHeader_BP.Text = "BP";
      this.columnHeader_BP.Width = 27;
      // 
      // columnHeader_IP
      // 
      this.columnHeader_IP.Text = "IP";
      // 
      // columnHeader_Opcode
      // 
      this.columnHeader_Opcode.Text = "Opcode";
      this.columnHeader_Opcode.Width = 103;
      // 
      // columnHeader_Instruction
      // 
      this.columnHeader_Instruction.Text = "Instruction";
      this.columnHeader_Instruction.Width = 119;
      // 
      // button_Run
      // 
      this.button_Run.Location = new System.Drawing.Point(339, 320);
      this.button_Run.Name = "button_Run";
      this.button_Run.Size = new System.Drawing.Size(75, 23);
      this.button_Run.TabIndex = 2;
      this.button_Run.Text = "Run";
      this.button_Run.UseVisualStyleBackColor = true;
      this.button_Run.Click += new System.EventHandler(this.button_Run_Click);
      // 
      // button_Step
      // 
      this.button_Step.Location = new System.Drawing.Point(339, 378);
      this.button_Step.Name = "button_Step";
      this.button_Step.Size = new System.Drawing.Size(75, 23);
      this.button_Step.TabIndex = 3;
      this.button_Step.Text = "Step Into";
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
      this.listView_Registers.Size = new System.Drawing.Size(156, 139);
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
      // button_StepOver
      // 
      this.button_StepOver.Location = new System.Drawing.Point(339, 349);
      this.button_StepOver.Name = "button_StepOver";
      this.button_StepOver.Size = new System.Drawing.Size(75, 23);
      this.button_StepOver.TabIndex = 11;
      this.button_StepOver.Text = "Step Over";
      this.button_StepOver.UseVisualStyleBackColor = true;
      this.button_StepOver.Click += new System.EventHandler(this.button_StepOver_Click);
      // 
      // listView_BPs
      // 
      this.listView_BPs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_BPA,
            this.columnHeader_BPC});
      this.listView_BPs.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.listView_BPs.FullRowSelect = true;
      this.listView_BPs.HideSelection = false;
      this.listView_BPs.Location = new System.Drawing.Point(420, 157);
      this.listView_BPs.Name = "listView_BPs";
      this.listView_BPs.Size = new System.Drawing.Size(156, 244);
      this.listView_BPs.TabIndex = 12;
      this.listView_BPs.UseCompatibleStateImageBehavior = false;
      this.listView_BPs.View = System.Windows.Forms.View.Details;
      this.listView_BPs.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_BPs_MouseClick);
      this.listView_BPs.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView_BPs_MouseDoubleClick);
      // 
      // columnHeader_BPA
      // 
      this.columnHeader_BPA.Text = "Addr";
      this.columnHeader_BPA.Width = 44;
      // 
      // columnHeader_BPC
      // 
      this.columnHeader_BPC.Text = "Condition";
      this.columnHeader_BPC.Width = 102;
      // 
      // contextMenuStrip_Opcode
      // 
      this.contextMenuStrip_Opcode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toggleBreakPointToolStripMenuItem});
      this.contextMenuStrip_Opcode.Name = "contextMenuStrip_Opcode";
      this.contextMenuStrip_Opcode.Size = new System.Drawing.Size(170, 26);
      // 
      // toggleBreakPointToolStripMenuItem
      // 
      this.toggleBreakPointToolStripMenuItem.Name = "toggleBreakPointToolStripMenuItem";
      this.toggleBreakPointToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
      this.toggleBreakPointToolStripMenuItem.Text = "Toggle BreakPoint";
      this.toggleBreakPointToolStripMenuItem.Click += new System.EventHandler(this.toggleBreakPointToolStripMenuItem_Click);
      // 
      // textBox_Status
      // 
      this.textBox_Status.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.textBox_Status.Location = new System.Drawing.Point(339, 114);
      this.textBox_Status.Multiline = true;
      this.textBox_Status.Name = "textBox_Status";
      this.textBox_Status.ReadOnly = true;
      this.textBox_Status.Size = new System.Drawing.Size(75, 37);
      this.textBox_Status.TabIndex = 13;
      // 
      // button_Reload
      // 
      this.button_Reload.Location = new System.Drawing.Point(339, 41);
      this.button_Reload.Name = "button_Reload";
      this.button_Reload.Size = new System.Drawing.Size(75, 23);
      this.button_Reload.TabIndex = 14;
      this.button_Reload.Text = "Reload";
      this.button_Reload.UseVisualStyleBackColor = true;
      this.button_Reload.Click += new System.EventHandler(this.button_Reload_Click);
      // 
      // contextMenuStrip_BP
      // 
      this.contextMenuStrip_BP.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.editToolStripMenuItem});
      this.contextMenuStrip_BP.Name = "contextMenuStrip_BP";
      this.contextMenuStrip_BP.Size = new System.Drawing.Size(181, 92);
      // 
      // addToolStripMenuItem
      // 
      this.addToolStripMenuItem.Name = "addToolStripMenuItem";
      this.addToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
      this.addToolStripMenuItem.Text = "Add";
      // 
      // removeToolStripMenuItem
      // 
      this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
      this.removeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
      this.removeToolStripMenuItem.Text = "Remove";
      // 
      // editToolStripMenuItem
      // 
      this.editToolStripMenuItem.Name = "editToolStripMenuItem";
      this.editToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.editToolStripMenuItem.Text = "Edit";
      this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
      // 
      // button_AddBP
      // 
      this.button_AddBP.Location = new System.Drawing.Point(339, 157);
      this.button_AddBP.Name = "button_AddBP";
      this.button_AddBP.Size = new System.Drawing.Size(75, 23);
      this.button_AddBP.TabIndex = 15;
      this.button_AddBP.Text = "Add BP";
      this.button_AddBP.UseVisualStyleBackColor = true;
      this.button_AddBP.Click += new System.EventHandler(this.button_AddBP_Click);
      // 
      // CpuWindow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 540);
      this.Controls.Add(this.button_AddBP);
      this.Controls.Add(this.button_Reload);
      this.Controls.Add(this.textBox_Status);
      this.Controls.Add(this.listView_BPs);
      this.Controls.Add(this.button_StepOver);
      this.Controls.Add(this.listView_Registers);
      this.Controls.Add(this.listView_MemoryHistory);
      this.Controls.Add(this.button_Reset);
      this.Controls.Add(this.button_Step);
      this.Controls.Add(this.button_Run);
      this.Controls.Add(this.listView_Opcode);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "CpuWindow";
      this.Text = "CPU";
      this.Load += new System.EventHandler(this.CpuWindow_Load);
      this.contextMenuStrip_Opcode.ResumeLayout(false);
      this.contextMenuStrip_BP.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

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
    private System.Windows.Forms.Button button_StepOver;
    private System.Windows.Forms.ListView listView_BPs;
    private System.Windows.Forms.ColumnHeader columnHeader_BPA;
    private System.Windows.Forms.ColumnHeader columnHeader_BPC;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Opcode;
    private System.Windows.Forms.ToolStripMenuItem toggleBreakPointToolStripMenuItem;
    private System.Windows.Forms.ColumnHeader columnHeader_BP;
    private System.Windows.Forms.TextBox textBox_Status;
    private System.Windows.Forms.Button button_Reload;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip_BP;
    private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
    private System.Windows.Forms.Button button_AddBP;
  }
}