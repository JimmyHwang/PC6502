namespace PC6502 {
  partial class XIO_LedClock {
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
      this.sevenSegment1 = new DmitryBrant.CustomControls.SevenSegment();
      this.sevenSegment2 = new DmitryBrant.CustomControls.SevenSegment();
      this.sevenSegment3 = new DmitryBrant.CustomControls.SevenSegment();
      this.sevenSegment4 = new DmitryBrant.CustomControls.SevenSegment();
      this.button_Reset = new System.Windows.Forms.Button();
      this.button_Minute = new System.Windows.Forms.Button();
      this.button_Second = new System.Windows.Forms.Button();
      this.button_StartStop = new System.Windows.Forms.Button();
      this.button_Mode = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // sevenSegment1
      // 
      this.sevenSegment1.ColonOn = false;
      this.sevenSegment1.ColonShow = false;
      this.sevenSegment1.ColorBackground = System.Drawing.Color.DarkGray;
      this.sevenSegment1.ColorDark = System.Drawing.Color.DimGray;
      this.sevenSegment1.ColorLight = System.Drawing.Color.Red;
      this.sevenSegment1.CustomPattern = 0;
      this.sevenSegment1.DecimalOn = false;
      this.sevenSegment1.DecimalShow = true;
      this.sevenSegment1.ElementWidth = 10;
      this.sevenSegment1.ItalicFactor = -0.07F;
      this.sevenSegment1.Location = new System.Drawing.Point(12, 12);
      this.sevenSegment1.Name = "sevenSegment1";
      this.sevenSegment1.Padding = new System.Windows.Forms.Padding(12, 4, 8, 4);
      this.sevenSegment1.Size = new System.Drawing.Size(134, 164);
      this.sevenSegment1.TabIndex = 0;
      this.sevenSegment1.TabStop = false;
      this.sevenSegment1.Value = null;
      // 
      // sevenSegment2
      // 
      this.sevenSegment2.ColonOn = false;
      this.sevenSegment2.ColonShow = false;
      this.sevenSegment2.ColorBackground = System.Drawing.Color.DarkGray;
      this.sevenSegment2.ColorDark = System.Drawing.Color.DimGray;
      this.sevenSegment2.ColorLight = System.Drawing.Color.Red;
      this.sevenSegment2.CustomPattern = 0;
      this.sevenSegment2.DecimalOn = false;
      this.sevenSegment2.DecimalShow = true;
      this.sevenSegment2.ElementWidth = 10;
      this.sevenSegment2.ItalicFactor = -0.07F;
      this.sevenSegment2.Location = new System.Drawing.Point(152, 12);
      this.sevenSegment2.Name = "sevenSegment2";
      this.sevenSegment2.Padding = new System.Windows.Forms.Padding(12, 4, 8, 4);
      this.sevenSegment2.Size = new System.Drawing.Size(134, 164);
      this.sevenSegment2.TabIndex = 1;
      this.sevenSegment2.TabStop = false;
      this.sevenSegment2.Value = null;
      // 
      // sevenSegment3
      // 
      this.sevenSegment3.ColonOn = false;
      this.sevenSegment3.ColonShow = false;
      this.sevenSegment3.ColorBackground = System.Drawing.Color.DarkGray;
      this.sevenSegment3.ColorDark = System.Drawing.Color.DimGray;
      this.sevenSegment3.ColorLight = System.Drawing.Color.Red;
      this.sevenSegment3.CustomPattern = 0;
      this.sevenSegment3.DecimalOn = false;
      this.sevenSegment3.DecimalShow = true;
      this.sevenSegment3.ElementWidth = 10;
      this.sevenSegment3.ItalicFactor = -0.07F;
      this.sevenSegment3.Location = new System.Drawing.Point(319, 12);
      this.sevenSegment3.Name = "sevenSegment3";
      this.sevenSegment3.Padding = new System.Windows.Forms.Padding(12, 4, 8, 4);
      this.sevenSegment3.Size = new System.Drawing.Size(134, 164);
      this.sevenSegment3.TabIndex = 2;
      this.sevenSegment3.TabStop = false;
      this.sevenSegment3.Value = null;
      // 
      // sevenSegment4
      // 
      this.sevenSegment4.ColonOn = false;
      this.sevenSegment4.ColonShow = false;
      this.sevenSegment4.ColorBackground = System.Drawing.Color.DarkGray;
      this.sevenSegment4.ColorDark = System.Drawing.Color.DimGray;
      this.sevenSegment4.ColorLight = System.Drawing.Color.Red;
      this.sevenSegment4.CustomPattern = 0;
      this.sevenSegment4.DecimalOn = false;
      this.sevenSegment4.DecimalShow = true;
      this.sevenSegment4.ElementWidth = 10;
      this.sevenSegment4.ItalicFactor = -0.07F;
      this.sevenSegment4.Location = new System.Drawing.Point(459, 12);
      this.sevenSegment4.Name = "sevenSegment4";
      this.sevenSegment4.Padding = new System.Windows.Forms.Padding(12, 4, 8, 4);
      this.sevenSegment4.Size = new System.Drawing.Size(134, 164);
      this.sevenSegment4.TabIndex = 3;
      this.sevenSegment4.TabStop = false;
      this.sevenSegment4.Value = null;
      // 
      // button_Reset
      // 
      this.button_Reset.Location = new System.Drawing.Point(211, 211);
      this.button_Reset.Name = "button_Reset";
      this.button_Reset.Size = new System.Drawing.Size(75, 23);
      this.button_Reset.TabIndex = 4;
      this.button_Reset.Text = "Reset";
      this.button_Reset.UseVisualStyleBackColor = true;
      this.button_Reset.Click += new System.EventHandler(this.button_Reset_Click);
      // 
      // button_Minute
      // 
      this.button_Minute.Location = new System.Drawing.Point(211, 182);
      this.button_Minute.Name = "button_Minute";
      this.button_Minute.Size = new System.Drawing.Size(75, 23);
      this.button_Minute.TabIndex = 5;
      this.button_Minute.Text = "Minute";
      this.button_Minute.UseVisualStyleBackColor = true;
      this.button_Minute.Click += new System.EventHandler(this.button_Minute_Click);
      // 
      // button_Second
      // 
      this.button_Second.Location = new System.Drawing.Point(518, 182);
      this.button_Second.Name = "button_Second";
      this.button_Second.Size = new System.Drawing.Size(75, 23);
      this.button_Second.TabIndex = 6;
      this.button_Second.Text = "Second";
      this.button_Second.UseVisualStyleBackColor = true;
      this.button_Second.Click += new System.EventHandler(this.button_Second_Click);
      // 
      // button_StartStop
      // 
      this.button_StartStop.Location = new System.Drawing.Point(518, 211);
      this.button_StartStop.Name = "button_StartStop";
      this.button_StartStop.Size = new System.Drawing.Size(75, 23);
      this.button_StartStop.TabIndex = 7;
      this.button_StartStop.Text = "Start/Stop";
      this.button_StartStop.UseVisualStyleBackColor = true;
      this.button_StartStop.Click += new System.EventHandler(this.button_StartStop_Click);
      // 
      // button_Mode
      // 
      this.button_Mode.Location = new System.Drawing.Point(12, 211);
      this.button_Mode.Name = "button_Mode";
      this.button_Mode.Size = new System.Drawing.Size(75, 23);
      this.button_Mode.TabIndex = 8;
      this.button_Mode.Text = "Mode";
      this.button_Mode.UseVisualStyleBackColor = true;
      this.button_Mode.Click += new System.EventHandler(this.button_Mode_Click);
      // 
      // XIO_LedClock
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(600, 244);
      this.Controls.Add(this.button_Mode);
      this.Controls.Add(this.button_StartStop);
      this.Controls.Add(this.button_Second);
      this.Controls.Add(this.button_Minute);
      this.Controls.Add(this.button_Reset);
      this.Controls.Add(this.sevenSegment4);
      this.Controls.Add(this.sevenSegment3);
      this.Controls.Add(this.sevenSegment2);
      this.Controls.Add(this.sevenSegment1);
      this.Name = "XIO_LedClock";
      this.Text = "XIO_LedClock";
      this.ResumeLayout(false);

    }

    #endregion

    private DmitryBrant.CustomControls.SevenSegment sevenSegment1;
    private DmitryBrant.CustomControls.SevenSegment sevenSegment2;
    private DmitryBrant.CustomControls.SevenSegment sevenSegment3;
    private DmitryBrant.CustomControls.SevenSegment sevenSegment4;
    private System.Windows.Forms.Button button_Reset;
    private System.Windows.Forms.Button button_Minute;
    private System.Windows.Forms.Button button_Second;
    private System.Windows.Forms.Button button_StartStop;
    private System.Windows.Forms.Button button_Mode;
  }
}