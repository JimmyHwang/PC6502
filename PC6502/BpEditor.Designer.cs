namespace PC6502 {
  partial class BpEditor {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BpEditor));
      this.textBox_Address = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.textBox_Data = new System.Windows.Forms.TextBox();
      this.checkedListBox_Access = new System.Windows.Forms.CheckedListBox();
      this.checkedListBox_Register = new System.Windows.Forms.CheckedListBox();
      this.label2 = new System.Windows.Forms.Label();
      this.checkedListBox_Compare = new System.Windows.Forms.CheckedListBox();
      this.button_OK = new System.Windows.Forms.Button();
      this.button_Cancel = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // textBox_Address
      // 
      this.textBox_Address.Location = new System.Drawing.Point(12, 24);
      this.textBox_Address.Name = "textBox_Address";
      this.textBox_Address.Size = new System.Drawing.Size(100, 22);
      this.textBox_Address.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(10, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(42, 12);
      this.label1.TabIndex = 1;
      this.label1.Text = "Address";
      // 
      // textBox_Data
      // 
      this.textBox_Data.Location = new System.Drawing.Point(12, 64);
      this.textBox_Data.Name = "textBox_Data";
      this.textBox_Data.Size = new System.Drawing.Size(100, 22);
      this.textBox_Data.TabIndex = 2;
      // 
      // checkedListBox_Access
      // 
      this.checkedListBox_Access.FormattingEnabled = true;
      this.checkedListBox_Access.Items.AddRange(new object[] {
            "Execution",
            "Memory Read",
            "Memory Write"});
      this.checkedListBox_Access.Location = new System.Drawing.Point(118, 24);
      this.checkedListBox_Access.Name = "checkedListBox_Access";
      this.checkedListBox_Access.Size = new System.Drawing.Size(120, 55);
      this.checkedListBox_Access.TabIndex = 3;
      // 
      // checkedListBox_Register
      // 
      this.checkedListBox_Register.FormattingEnabled = true;
      this.checkedListBox_Register.Items.AddRange(new object[] {
            "A",
            "X",
            "Y"});
      this.checkedListBox_Register.Location = new System.Drawing.Point(244, 24);
      this.checkedListBox_Register.Name = "checkedListBox_Register";
      this.checkedListBox_Register.Size = new System.Drawing.Size(50, 55);
      this.checkedListBox_Register.TabIndex = 4;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(10, 49);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(26, 12);
      this.label2.TabIndex = 5;
      this.label2.Text = "Data";
      // 
      // checkedListBox_Compare
      // 
      this.checkedListBox_Compare.FormattingEnabled = true;
      this.checkedListBox_Compare.Items.AddRange(new object[] {
            "=",
            ">",
            "<"});
      this.checkedListBox_Compare.Location = new System.Drawing.Point(300, 24);
      this.checkedListBox_Compare.Name = "checkedListBox_Compare";
      this.checkedListBox_Compare.Size = new System.Drawing.Size(42, 55);
      this.checkedListBox_Compare.TabIndex = 6;
      // 
      // button_OK
      // 
      this.button_OK.Location = new System.Drawing.Point(267, 85);
      this.button_OK.Name = "button_OK";
      this.button_OK.Size = new System.Drawing.Size(75, 23);
      this.button_OK.TabIndex = 7;
      this.button_OK.Text = "OK";
      this.button_OK.UseVisualStyleBackColor = true;
      this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
      // 
      // button_Cancel
      // 
      this.button_Cancel.Location = new System.Drawing.Point(186, 85);
      this.button_Cancel.Name = "button_Cancel";
      this.button_Cancel.Size = new System.Drawing.Size(75, 23);
      this.button_Cancel.TabIndex = 8;
      this.button_Cancel.Text = "Cancel";
      this.button_Cancel.UseVisualStyleBackColor = true;
      this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
      // 
      // BpEditor
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(353, 117);
      this.Controls.Add(this.button_Cancel);
      this.Controls.Add(this.button_OK);
      this.Controls.Add(this.checkedListBox_Compare);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.checkedListBox_Register);
      this.Controls.Add(this.checkedListBox_Access);
      this.Controls.Add(this.textBox_Data);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.textBox_Address);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "BpEditor";
      this.Text = "BpEditor";
      this.Load += new System.EventHandler(this.BpEditor_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox textBox_Address;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox textBox_Data;
    private System.Windows.Forms.CheckedListBox checkedListBox_Access;
    private System.Windows.Forms.CheckedListBox checkedListBox_Register;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.CheckedListBox checkedListBox_Compare;
    private System.Windows.Forms.Button button_OK;
    private System.Windows.Forms.Button button_Cancel;
  }
}