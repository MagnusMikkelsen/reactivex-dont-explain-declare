namespace BlinkingLed
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
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.Led = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // Led
            // 
            this.Led.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Led.Location = new System.Drawing.Point(274, 150);
            this.Led.Name = "Led";
            this.Led.Size = new System.Drawing.Size(200, 82);
            this.Led.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Led);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Panel Led;
    }
}

