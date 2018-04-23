namespace Riftbuddy
{
    partial class Config
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.microphoneComboBox = new System.Windows.Forms.ComboBox();
            this.microphoneLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // microphoneComboBox
            // 
            this.microphoneComboBox.FormattingEnabled = true;
            this.microphoneComboBox.Location = new System.Drawing.Point(77, 5);
            this.microphoneComboBox.Name = "microphoneComboBox";
            this.microphoneComboBox.Size = new System.Drawing.Size(185, 21);
            this.microphoneComboBox.TabIndex = 0;
            // 
            // microphoneLabel
            // 
            this.microphoneLabel.AutoSize = true;
            this.microphoneLabel.Location = new System.Drawing.Point(9, 8);
            this.microphoneLabel.Name = "microphoneLabel";
            this.microphoneLabel.Size = new System.Drawing.Size(66, 13);
            this.microphoneLabel.TabIndex = 1;
            this.microphoneLabel.Text = "Microphone:";
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 66);
            this.Controls.Add(this.microphoneLabel);
            this.Controls.Add(this.microphoneComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Config";
            this.Text = "Config";
            this.Load += new System.EventHandler(this.Config_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox microphoneComboBox;
        private System.Windows.Forms.Label microphoneLabel;
    }
}