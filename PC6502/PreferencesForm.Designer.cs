namespace PC6502 {
  partial class PreferencesForm {
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
      this.button_OK = new System.Windows.Forms.Button();
      this.button_Cancel = new System.Windows.Forms.Button();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPage_System = new System.Windows.Forms.TabPage();
      this.comboBox_GuiRefreshTime = new System.Windows.Forms.ComboBox();
      this.label3 = new System.Windows.Forms.Label();
      this.tabPage_Emulator = new System.Windows.Forms.TabPage();
      this.label2 = new System.Windows.Forms.Label();
      this.comboBox_ExecutionMode = new System.Windows.Forms.ComboBox();
      this.tabPage_Single = new System.Windows.Forms.TabPage();
      this.comboBox_ExecutionCount = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.comboBox_ExecutionInterleaved = new System.Windows.Forms.ComboBox();
      this.label4 = new System.Windows.Forms.Label();
      this.tabPage_Multi = new System.Windows.Forms.TabPage();
      this.comboBox_MtExecutionCount = new System.Windows.Forms.ComboBox();
      this.label5 = new System.Windows.Forms.Label();
      this.tabControl1.SuspendLayout();
      this.tabPage_System.SuspendLayout();
      this.tabPage_Emulator.SuspendLayout();
      this.tabPage_Single.SuspendLayout();
      this.tabPage_Multi.SuspendLayout();
      this.SuspendLayout();
      // 
      // button_OK
      // 
      this.button_OK.Location = new System.Drawing.Point(388, 266);
      this.button_OK.Name = "button_OK";
      this.button_OK.Size = new System.Drawing.Size(75, 23);
      this.button_OK.TabIndex = 0;
      this.button_OK.Text = "OK";
      this.button_OK.UseVisualStyleBackColor = true;
      this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
      // 
      // button_Cancel
      // 
      this.button_Cancel.Location = new System.Drawing.Point(307, 266);
      this.button_Cancel.Name = "button_Cancel";
      this.button_Cancel.Size = new System.Drawing.Size(75, 23);
      this.button_Cancel.TabIndex = 1;
      this.button_Cancel.Text = "Cancel";
      this.button_Cancel.UseVisualStyleBackColor = true;
      this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabPage_System);
      this.tabControl1.Controls.Add(this.tabPage_Emulator);
      this.tabControl1.Controls.Add(this.tabPage_Single);
      this.tabControl1.Controls.Add(this.tabPage_Multi);
      this.tabControl1.Location = new System.Drawing.Point(12, 12);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(451, 248);
      this.tabControl1.TabIndex = 2;
      // 
      // tabPage_System
      // 
      this.tabPage_System.Controls.Add(this.comboBox_GuiRefreshTime);
      this.tabPage_System.Controls.Add(this.label3);
      this.tabPage_System.Location = new System.Drawing.Point(4, 22);
      this.tabPage_System.Name = "tabPage_System";
      this.tabPage_System.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage_System.Size = new System.Drawing.Size(443, 222);
      this.tabPage_System.TabIndex = 1;
      this.tabPage_System.Text = "System";
      this.tabPage_System.UseVisualStyleBackColor = true;
      // 
      // comboBox_GuiRefreshTime
      // 
      this.comboBox_GuiRefreshTime.FormattingEnabled = true;
      this.comboBox_GuiRefreshTime.Items.AddRange(new object[] {
            "1/15",
            "1/30",
            "1/60"});
      this.comboBox_GuiRefreshTime.Location = new System.Drawing.Point(177, 6);
      this.comboBox_GuiRefreshTime.Name = "comboBox_GuiRefreshTime";
      this.comboBox_GuiRefreshTime.Size = new System.Drawing.Size(121, 20);
      this.comboBox_GuiRefreshTime.TabIndex = 1;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(3, 9);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(91, 12);
      this.label3.TabIndex = 0;
      this.label3.Text = "GUI Refresh Time";
      // 
      // tabPage_Emulator
      // 
      this.tabPage_Emulator.Controls.Add(this.label2);
      this.tabPage_Emulator.Controls.Add(this.comboBox_ExecutionMode);
      this.tabPage_Emulator.Location = new System.Drawing.Point(4, 22);
      this.tabPage_Emulator.Name = "tabPage_Emulator";
      this.tabPage_Emulator.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage_Emulator.Size = new System.Drawing.Size(443, 222);
      this.tabPage_Emulator.TabIndex = 0;
      this.tabPage_Emulator.Text = "Emulator";
      this.tabPage_Emulator.UseVisualStyleBackColor = true;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(6, 9);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(87, 12);
      this.label2.TabIndex = 3;
      this.label2.Text = "Execuction Mode";
      // 
      // comboBox_ExecutionMode
      // 
      this.comboBox_ExecutionMode.FormattingEnabled = true;
      this.comboBox_ExecutionMode.Items.AddRange(new object[] {
            "Single-Thread",
            "Multi-Thread"});
      this.comboBox_ExecutionMode.Location = new System.Drawing.Point(177, 6);
      this.comboBox_ExecutionMode.Name = "comboBox_ExecutionMode";
      this.comboBox_ExecutionMode.Size = new System.Drawing.Size(121, 20);
      this.comboBox_ExecutionMode.TabIndex = 3;
      // 
      // tabPage_Single
      // 
      this.tabPage_Single.Controls.Add(this.comboBox_ExecutionCount);
      this.tabPage_Single.Controls.Add(this.label1);
      this.tabPage_Single.Controls.Add(this.comboBox_ExecutionInterleaved);
      this.tabPage_Single.Controls.Add(this.label4);
      this.tabPage_Single.Location = new System.Drawing.Point(4, 22);
      this.tabPage_Single.Name = "tabPage_Single";
      this.tabPage_Single.Size = new System.Drawing.Size(443, 222);
      this.tabPage_Single.TabIndex = 2;
      this.tabPage_Single.Text = "Single-Thread";
      this.tabPage_Single.UseVisualStyleBackColor = true;
      // 
      // comboBox_ExecutionCount
      // 
      this.comboBox_ExecutionCount.FormattingEnabled = true;
      this.comboBox_ExecutionCount.Items.AddRange(new object[] {
            "0x10",
            "0x100",
            "0x1000"});
      this.comboBox_ExecutionCount.Location = new System.Drawing.Point(179, 32);
      this.comboBox_ExecutionCount.Name = "comboBox_ExecutionCount";
      this.comboBox_ExecutionCount.Size = new System.Drawing.Size(121, 20);
      this.comboBox_ExecutionCount.TabIndex = 11;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(3, 35);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(89, 12);
      this.label1.TabIndex = 10;
      this.label1.Text = "Execuation Count";
      // 
      // comboBox_ExecutionInterleaved
      // 
      this.comboBox_ExecutionInterleaved.FormattingEnabled = true;
      this.comboBox_ExecutionInterleaved.Items.AddRange(new object[] {
            "1/30",
            "1/60",
            "1/120"});
      this.comboBox_ExecutionInterleaved.Location = new System.Drawing.Point(179, 6);
      this.comboBox_ExecutionInterleaved.Name = "comboBox_ExecutionInterleaved";
      this.comboBox_ExecutionInterleaved.Size = new System.Drawing.Size(121, 20);
      this.comboBox_ExecutionInterleaved.TabIndex = 9;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(3, 9);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(107, 12);
      this.label4.TabIndex = 8;
      this.label4.Text = "Execution Interleaved";
      // 
      // tabPage_Multi
      // 
      this.tabPage_Multi.Controls.Add(this.comboBox_MtExecutionCount);
      this.tabPage_Multi.Controls.Add(this.label5);
      this.tabPage_Multi.Location = new System.Drawing.Point(4, 22);
      this.tabPage_Multi.Name = "tabPage_Multi";
      this.tabPage_Multi.Size = new System.Drawing.Size(443, 222);
      this.tabPage_Multi.TabIndex = 3;
      this.tabPage_Multi.Text = "Multi-Thread";
      this.tabPage_Multi.UseVisualStyleBackColor = true;
      // 
      // comboBox_MtExecutionCount
      // 
      this.comboBox_MtExecutionCount.FormattingEnabled = true;
      this.comboBox_MtExecutionCount.Items.AddRange(new object[] {
            "0x1000",
            "0x2000",
            "0x4000",
            "0x8000"});
      this.comboBox_MtExecutionCount.Location = new System.Drawing.Point(178, 6);
      this.comboBox_MtExecutionCount.Name = "comboBox_MtExecutionCount";
      this.comboBox_MtExecutionCount.Size = new System.Drawing.Size(121, 20);
      this.comboBox_MtExecutionCount.TabIndex = 13;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(3, 9);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(89, 12);
      this.label5.TabIndex = 12;
      this.label5.Text = "Execuation Count";
      // 
      // PreferencesForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(470, 300);
      this.Controls.Add(this.tabControl1);
      this.Controls.Add(this.button_Cancel);
      this.Controls.Add(this.button_OK);
      this.Name = "PreferencesForm";
      this.Text = "Preferences";
      this.Load += new System.EventHandler(this.PreferencesForm_Load);
      this.tabControl1.ResumeLayout(false);
      this.tabPage_System.ResumeLayout(false);
      this.tabPage_System.PerformLayout();
      this.tabPage_Emulator.ResumeLayout(false);
      this.tabPage_Emulator.PerformLayout();
      this.tabPage_Single.ResumeLayout(false);
      this.tabPage_Single.PerformLayout();
      this.tabPage_Multi.ResumeLayout(false);
      this.tabPage_Multi.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button button_OK;
    private System.Windows.Forms.Button button_Cancel;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage_Emulator;
    private System.Windows.Forms.TabPage tabPage_System;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox comboBox_ExecutionMode;
    private System.Windows.Forms.ComboBox comboBox_GuiRefreshTime;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TabPage tabPage_Single;
    private System.Windows.Forms.ComboBox comboBox_ExecutionCount;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox comboBox_ExecutionInterleaved;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TabPage tabPage_Multi;
    private System.Windows.Forms.ComboBox comboBox_MtExecutionCount;
    private System.Windows.Forms.Label label5;
  }
}