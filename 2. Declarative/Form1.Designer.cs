namespace _2._Declarative
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
            buttonTest = new Button();
            buttonControl = new Button();
            labelStatus = new Label();
            SuspendLayout();
            // 
            // buttonTest
            // 
            buttonTest.Location = new Point(12, 12);
            buttonTest.Name = "buttonTest";
            buttonTest.Size = new Size(212, 29);
            buttonTest.TabIndex = 0;
            buttonTest.Text = "Test";
            buttonTest.UseVisualStyleBackColor = true;
            // 
            // buttonControl
            // 
            buttonControl.Location = new Point(12, 47);
            buttonControl.Name = "buttonControl";
            buttonControl.Size = new Size(212, 29);
            buttonControl.TabIndex = 1;
            buttonControl.Text = "Control";
            buttonControl.UseVisualStyleBackColor = true;
            // 
            // labelStatus
            // 
            labelStatus.Location = new Point(12, 82);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(212, 29);
            labelStatus.TabIndex = 2;
            labelStatus.Text = "Status";
            labelStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(236, 137);
            Controls.Add(labelStatus);
            Controls.Add(buttonControl);
            Controls.Add(buttonTest);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonTest;
        private Button buttonControl;
        private Label labelStatus;
    }
}
