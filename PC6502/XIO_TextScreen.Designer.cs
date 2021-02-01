namespace PC6502 {
  partial class XIO_Screen {
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
      this.pictureBox_Screen = new System.Windows.Forms.PictureBox();
      this.button1 = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Screen)).BeginInit();
      this.SuspendLayout();
      // 
      // pictureBox_Screen
      // 
      this.pictureBox_Screen.Location = new System.Drawing.Point(12, 12);
      this.pictureBox_Screen.Name = "pictureBox_Screen";
      this.pictureBox_Screen.Size = new System.Drawing.Size(640, 480);
      this.pictureBox_Screen.TabIndex = 0;
      this.pictureBox_Screen.TabStop = false;
      // 
      // button1
      // 
      this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button1.Location = new System.Drawing.Point(658, 469);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 1;
      this.button1.Text = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // XIO_Screen
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(772, 504);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.pictureBox_Screen);
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.Name = "XIO_Screen";
      this.Text = "XIO_TextScreen";
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Screen)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox pictureBox_Screen;
    private System.Windows.Forms.Button button1;
  }
}