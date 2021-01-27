namespace PC6502 {
  partial class Form1 {
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
      this.button_Test = new System.Windows.Forms.Button();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.recentFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.button1 = new System.Windows.Forms.Button();
      this.listView_Device = new System.Windows.Forms.ListView();
      this.columnHeader_Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader_Base = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader_Size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.button_Reset = new System.Windows.Forms.Button();
      this.button_RunStop = new System.Windows.Forms.Button();
      this.button_Step = new System.Windows.Forms.Button();
      this.button_Add = new System.Windows.Forms.Button();
      this.button_Remove = new System.Windows.Forms.Button();
      this.button_Edit = new System.Windows.Forms.Button();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // button_Test
      // 
      this.button_Test.Location = new System.Drawing.Point(713, 415);
      this.button_Test.Name = "button_Test";
      this.button_Test.Size = new System.Drawing.Size(75, 23);
      this.button_Test.TabIndex = 0;
      this.button_Test.Text = "Test";
      this.button_Test.UseVisualStyleBackColor = true;
      this.button_Test.Click += new System.EventHandler(this.button_Test_Click);
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(800, 24);
      this.menuStrip1.TabIndex = 1;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.recentFilesToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem.Text = "File";
      // 
      // loadToolStripMenuItem
      // 
      this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
      this.loadToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
      this.loadToolStripMenuItem.Text = "Load";
      this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
      // 
      // saveToolStripMenuItem
      // 
      this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
      this.saveToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
      this.saveToolStripMenuItem.Text = "Save";
      this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
      // 
      // saveAsToolStripMenuItem
      // 
      this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
      this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
      this.saveAsToolStripMenuItem.Text = "Save As";
      this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(133, 6);
      // 
      // recentFilesToolStripMenuItem
      // 
      this.recentFilesToolStripMenuItem.Name = "recentFilesToolStripMenuItem";
      this.recentFilesToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
      this.recentFilesToolStripMenuItem.Text = "Recent Files";
      // 
      // toolStripMenuItem2
      // 
      this.toolStripMenuItem2.Name = "toolStripMenuItem2";
      this.toolStripMenuItem2.Size = new System.Drawing.Size(133, 6);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
      this.exitToolStripMenuItem.Text = "Exit";
      // 
      // editToolStripMenuItem
      // 
      this.editToolStripMenuItem.Name = "editToolStripMenuItem";
      this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
      this.editToolStripMenuItem.Text = "Edit";
      // 
      // helpToolStripMenuItem
      // 
      this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
      this.helpToolStripMenuItem.Text = "Help";
      // 
      // aboutToolStripMenuItem
      // 
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
      this.aboutToolStripMenuItem.Text = "About";
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(477, 415);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 2;
      this.button1.Text = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // listView_Device
      // 
      this.listView_Device.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_Type,
            this.columnHeader_Base,
            this.columnHeader_Size});
      this.listView_Device.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.listView_Device.FullRowSelect = true;
      this.listView_Device.HideSelection = false;
      this.listView_Device.Location = new System.Drawing.Point(12, 27);
      this.listView_Device.Name = "listView_Device";
      this.listView_Device.Size = new System.Drawing.Size(313, 279);
      this.listView_Device.TabIndex = 3;
      this.listView_Device.UseCompatibleStateImageBehavior = false;
      this.listView_Device.View = System.Windows.Forms.View.Details;
      this.listView_Device.DoubleClick += new System.EventHandler(this.listView_Device_DoubleClick);
      // 
      // columnHeader_Type
      // 
      this.columnHeader_Type.Text = "Device";
      this.columnHeader_Type.Width = 84;
      // 
      // columnHeader_Base
      // 
      this.columnHeader_Base.Text = "Base";
      this.columnHeader_Base.Width = 103;
      // 
      // columnHeader_Size
      // 
      this.columnHeader_Size.Text = "Size";
      this.columnHeader_Size.Width = 100;
      // 
      // button_Reset
      // 
      this.button_Reset.Location = new System.Drawing.Point(207, 424);
      this.button_Reset.Name = "button_Reset";
      this.button_Reset.Size = new System.Drawing.Size(75, 23);
      this.button_Reset.TabIndex = 4;
      this.button_Reset.Text = "Reset";
      this.button_Reset.UseVisualStyleBackColor = true;
      // 
      // button_RunStop
      // 
      this.button_RunStop.Location = new System.Drawing.Point(126, 424);
      this.button_RunStop.Name = "button_RunStop";
      this.button_RunStop.Size = new System.Drawing.Size(75, 23);
      this.button_RunStop.TabIndex = 5;
      this.button_RunStop.Text = "Run";
      this.button_RunStop.UseVisualStyleBackColor = true;
      // 
      // button_Step
      // 
      this.button_Step.Location = new System.Drawing.Point(288, 424);
      this.button_Step.Name = "button_Step";
      this.button_Step.Size = new System.Drawing.Size(75, 23);
      this.button_Step.TabIndex = 7;
      this.button_Step.Text = "Step";
      this.button_Step.UseVisualStyleBackColor = true;
      // 
      // button_Add
      // 
      this.button_Add.Location = new System.Drawing.Point(331, 27);
      this.button_Add.Name = "button_Add";
      this.button_Add.Size = new System.Drawing.Size(75, 23);
      this.button_Add.TabIndex = 9;
      this.button_Add.Text = "Add";
      this.button_Add.UseVisualStyleBackColor = true;
      this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
      // 
      // button_Remove
      // 
      this.button_Remove.Location = new System.Drawing.Point(331, 56);
      this.button_Remove.Name = "button_Remove";
      this.button_Remove.Size = new System.Drawing.Size(75, 23);
      this.button_Remove.TabIndex = 10;
      this.button_Remove.Text = "Remove";
      this.button_Remove.UseVisualStyleBackColor = true;
      // 
      // button_Edit
      // 
      this.button_Edit.Location = new System.Drawing.Point(331, 85);
      this.button_Edit.Name = "button_Edit";
      this.button_Edit.Size = new System.Drawing.Size(75, 23);
      this.button_Edit.TabIndex = 11;
      this.button_Edit.Text = "Edit";
      this.button_Edit.UseVisualStyleBackColor = true;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.button_Edit);
      this.Controls.Add(this.button_Remove);
      this.Controls.Add(this.button_Add);
      this.Controls.Add(this.button_Step);
      this.Controls.Add(this.button_RunStop);
      this.Controls.Add(this.button_Reset);
      this.Controls.Add(this.listView_Device);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.button_Test);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "Form1";
      this.Text = "Form1";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
      this.Load += new System.EventHandler(this.Form1_Load);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button button_Test;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem recentFilesToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    private System.Windows.Forms.ListView listView_Device;
    private System.Windows.Forms.Button button_Reset;
    private System.Windows.Forms.Button button_RunStop;
    private System.Windows.Forms.Button button_Step;
    private System.Windows.Forms.ColumnHeader columnHeader_Type;
    private System.Windows.Forms.ColumnHeader columnHeader_Base;
    private System.Windows.Forms.ColumnHeader columnHeader_Size;
    private System.Windows.Forms.Button button_Add;
    private System.Windows.Forms.Button button_Remove;
    private System.Windows.Forms.Button button_Edit;
  }
}

