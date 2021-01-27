namespace PC6502 {
  partial class DeviceEditor {
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
      this.comboBox_Type = new System.Windows.Forms.ComboBox();
      this.comboBox_Base = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.comboBox_Size = new System.Windows.Forms.ComboBox();
      this.button_OK = new System.Windows.Forms.Button();
      this.button_Cancel = new System.Windows.Forms.Button();
      this.label4 = new System.Windows.Forms.Label();
      this.textBox_File = new System.Windows.Forms.TextBox();
      this.button_Browser = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // comboBox_Type
      // 
      this.comboBox_Type.FormattingEnabled = true;
      this.comboBox_Type.Items.AddRange(new object[] {
            "CPU",
            "ROM",
            "RAM",
            "XIO_LedClock"});
      this.comboBox_Type.Location = new System.Drawing.Point(12, 24);
      this.comboBox_Type.Name = "comboBox_Type";
      this.comboBox_Type.Size = new System.Drawing.Size(121, 20);
      this.comboBox_Type.TabIndex = 0;
      // 
      // comboBox_Base
      // 
      this.comboBox_Base.FormattingEnabled = true;
      this.comboBox_Base.Location = new System.Drawing.Point(12, 62);
      this.comboBox_Base.Name = "comboBox_Base";
      this.comboBox_Base.Size = new System.Drawing.Size(121, 20);
      this.comboBox_Base.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(64, 12);
      this.label1.TabIndex = 2;
      this.label1.Text = "Device Type";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 47);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(67, 12);
      this.label2.TabIndex = 3;
      this.label2.Text = "Base Address";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(137, 9);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(24, 12);
      this.label3.TabIndex = 4;
      this.label3.Text = "Size";
      // 
      // comboBox_Size
      // 
      this.comboBox_Size.FormattingEnabled = true;
      this.comboBox_Size.Location = new System.Drawing.Point(139, 24);
      this.comboBox_Size.Name = "comboBox_Size";
      this.comboBox_Size.Size = new System.Drawing.Size(121, 20);
      this.comboBox_Size.TabIndex = 5;
      // 
      // button_OK
      // 
      this.button_OK.Location = new System.Drawing.Point(281, 129);
      this.button_OK.Name = "button_OK";
      this.button_OK.Size = new System.Drawing.Size(75, 23);
      this.button_OK.TabIndex = 6;
      this.button_OK.Text = "OK";
      this.button_OK.UseVisualStyleBackColor = true;
      this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
      // 
      // button_Cancel
      // 
      this.button_Cancel.Location = new System.Drawing.Point(200, 129);
      this.button_Cancel.Name = "button_Cancel";
      this.button_Cancel.Size = new System.Drawing.Size(75, 23);
      this.button_Cancel.TabIndex = 7;
      this.button_Cancel.Text = "Cancel";
      this.button_Cancel.UseVisualStyleBackColor = true;
      this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(12, 85);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(57, 12);
      this.label4.TabIndex = 8;
      this.label4.Text = "Binary File";
      // 
      // textBox_File
      // 
      this.textBox_File.Location = new System.Drawing.Point(12, 100);
      this.textBox_File.Name = "textBox_File";
      this.textBox_File.Size = new System.Drawing.Size(315, 22);
      this.textBox_File.TabIndex = 9;
      // 
      // button_Browser
      // 
      this.button_Browser.Location = new System.Drawing.Point(333, 100);
      this.button_Browser.Name = "button_Browser";
      this.button_Browser.Size = new System.Drawing.Size(22, 23);
      this.button_Browser.TabIndex = 10;
      this.button_Browser.Text = "...";
      this.button_Browser.UseVisualStyleBackColor = true;
      this.button_Browser.Click += new System.EventHandler(this.button_Browser_Click);
      // 
      // DeviceEditor
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(368, 160);
      this.Controls.Add(this.button_Browser);
      this.Controls.Add(this.textBox_File);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.button_Cancel);
      this.Controls.Add(this.button_OK);
      this.Controls.Add(this.comboBox_Size);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.comboBox_Base);
      this.Controls.Add(this.comboBox_Type);
      this.Name = "DeviceEditor";
      this.Text = "Device Editor";
      this.Load += new System.EventHandler(this.DeviceEditor_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ComboBox comboBox_Type;
    private System.Windows.Forms.ComboBox comboBox_Base;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ComboBox comboBox_Size;
    private System.Windows.Forms.Button button_OK;
    private System.Windows.Forms.Button button_Cancel;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox textBox_File;
    private System.Windows.Forms.Button button_Browser;
  }
}