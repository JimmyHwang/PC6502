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
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.button_Test);
      this.Name = "Form1";
      this.Text = "Form1";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button button_Test;
  }
}

