namespace ColorSelector
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelColor = new System.Windows.Forms.Panel();
            this.trackBarR = new System.Windows.Forms.TrackBar();
            this.trackBarGreen = new System.Windows.Forms.TrackBar();
            this.trackBarBlue = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.labelG = new System.Windows.Forms.Label();
            this.labelB = new System.Windows.Forms.Label();
            this.labelBrightness = new System.Windows.Forms.Label();
            this.trackBarBrightness = new System.Windows.Forms.TrackBar();
            this.trackBarSaturation = new System.Windows.Forms.TrackBar();
            this.labelSaturation = new System.Windows.Forms.Label();
            this.labelHue = new System.Windows.Forms.Label();
            this.trackBarHue = new System.Windows.Forms.TrackBar();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSaturation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHue)).BeginInit();
            this.SuspendLayout();
            // 
            // panelColor
            // 
            this.panelColor.Location = new System.Drawing.Point(572, 12);
            this.panelColor.Name = "panelColor";
            this.panelColor.Size = new System.Drawing.Size(200, 426);
            this.panelColor.TabIndex = 0;
            // 
            // trackBarR
            // 
            this.trackBarR.Location = new System.Drawing.Point(92, 12);
            this.trackBarR.Maximum = 255;
            this.trackBarR.Name = "trackBarR";
            this.trackBarR.Size = new System.Drawing.Size(445, 45);
            this.trackBarR.TabIndex = 0;
            // 
            // trackBarGreen
            // 
            this.trackBarGreen.BackColor = System.Drawing.SystemColors.Menu;
            this.trackBarGreen.Location = new System.Drawing.Point(92, 63);
            this.trackBarGreen.Maximum = 255;
            this.trackBarGreen.Name = "trackBarGreen";
            this.trackBarGreen.Size = new System.Drawing.Size(445, 45);
            this.trackBarGreen.TabIndex = 0;
            // 
            // trackBarBlue
            // 
            this.trackBarBlue.Location = new System.Drawing.Point(92, 114);
            this.trackBarBlue.Maximum = 255;
            this.trackBarBlue.Name = "trackBarBlue";
            this.trackBarBlue.Size = new System.Drawing.Size(445, 45);
            this.trackBarBlue.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "R";
            // 
            // labelG
            // 
            this.labelG.AutoSize = true;
            this.labelG.Location = new System.Drawing.Point(12, 63);
            this.labelG.Name = "labelG";
            this.labelG.Size = new System.Drawing.Size(15, 15);
            this.labelG.TabIndex = 1;
            this.labelG.Text = "G";
            // 
            // labelB
            // 
            this.labelB.AutoSize = true;
            this.labelB.Location = new System.Drawing.Point(12, 114);
            this.labelB.Name = "labelB";
            this.labelB.Size = new System.Drawing.Size(14, 15);
            this.labelB.TabIndex = 1;
            this.labelB.Text = "B";
            // 
            // labelBrightness
            // 
            this.labelBrightness.AutoSize = true;
            this.labelBrightness.Location = new System.Drawing.Point(12, 358);
            this.labelBrightness.Name = "labelBrightness";
            this.labelBrightness.Size = new System.Drawing.Size(62, 15);
            this.labelBrightness.TabIndex = 1;
            this.labelBrightness.Text = "Brightness";
            // 
            // trackBarBrightness
            // 
            this.trackBarBrightness.Location = new System.Drawing.Point(92, 358);
            this.trackBarBrightness.Maximum = 510;
            this.trackBarBrightness.Name = "trackBarBrightness";
            this.trackBarBrightness.Size = new System.Drawing.Size(445, 45);
            this.trackBarBrightness.TabIndex = 0;
            // 
            // trackBarSaturation
            // 
            this.trackBarSaturation.Location = new System.Drawing.Point(92, 307);
            this.trackBarSaturation.Maximum = 255;
            this.trackBarSaturation.Name = "trackBarSaturation";
            this.trackBarSaturation.Size = new System.Drawing.Size(445, 45);
            this.trackBarSaturation.TabIndex = 0;
            // 
            // labelSaturation
            // 
            this.labelSaturation.AutoSize = true;
            this.labelSaturation.Location = new System.Drawing.Point(12, 307);
            this.labelSaturation.Name = "labelSaturation";
            this.labelSaturation.Size = new System.Drawing.Size(61, 15);
            this.labelSaturation.TabIndex = 1;
            this.labelSaturation.Text = "Saturation";
            // 
            // labelHue
            // 
            this.labelHue.AutoSize = true;
            this.labelHue.Location = new System.Drawing.Point(12, 256);
            this.labelHue.Name = "labelHue";
            this.labelHue.Size = new System.Drawing.Size(29, 15);
            this.labelHue.TabIndex = 1;
            this.labelHue.Text = "Hue";
            // 
            // trackBarHue
            // 
            this.trackBarHue.Location = new System.Drawing.Point(92, 256);
            this.trackBarHue.Maximum = 360;
            this.trackBarHue.Name = "trackBarHue";
            this.trackBarHue.Size = new System.Drawing.Size(445, 45);
            this.trackBarHue.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(210, 188);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(198, 24);
            this.comboBox1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.trackBarHue);
            this.Controls.Add(this.labelHue);
            this.Controls.Add(this.labelSaturation);
            this.Controls.Add(this.trackBarSaturation);
            this.Controls.Add(this.trackBarBrightness);
            this.Controls.Add(this.labelBrightness);
            this.Controls.Add(this.labelB);
            this.Controls.Add(this.labelG);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBarBlue);
            this.Controls.Add(this.trackBarGreen);
            this.Controls.Add(this.trackBarR);
            this.Controls.Add(this.panelColor);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSaturation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelColor;
        private System.Windows.Forms.TrackBar trackBarR;
        private System.Windows.Forms.TrackBar trackBarGreen;
        private System.Windows.Forms.TrackBar trackBarBlue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelG;
        private System.Windows.Forms.Label labelB;
        private System.Windows.Forms.Label labelBrightness;
        private System.Windows.Forms.TrackBar trackBarBrightness;
        private System.Windows.Forms.TrackBar trackBarSaturation;
        private System.Windows.Forms.Label labelSaturation;
        private System.Windows.Forms.Label labelHue;
        private System.Windows.Forms.TrackBar trackBarHue;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}

