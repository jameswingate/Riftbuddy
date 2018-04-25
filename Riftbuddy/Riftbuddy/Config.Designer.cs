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
            this.textBoxSummonerName = new System.Windows.Forms.TextBox();
            this.labelSummonerName = new System.Windows.Forms.Label();
            this.comboBoxServer = new System.Windows.Forms.ComboBox();
            this.labelServer = new System.Windows.Forms.Label();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxSummonerName
            // 
            this.textBoxSummonerName.Location = new System.Drawing.Point(99, 6);
            this.textBoxSummonerName.Name = "textBoxSummonerName";
            this.textBoxSummonerName.Size = new System.Drawing.Size(100, 20);
            this.textBoxSummonerName.TabIndex = 0;
            // 
            // labelSummonerName
            // 
            this.labelSummonerName.AutoSize = true;
            this.labelSummonerName.Location = new System.Drawing.Point(7, 9);
            this.labelSummonerName.Name = "labelSummonerName";
            this.labelSummonerName.Size = new System.Drawing.Size(91, 13);
            this.labelSummonerName.TabIndex = 1;
            this.labelSummonerName.Text = "Summoner Name:";
            // 
            // comboBoxServer
            // 
            this.comboBoxServer.FormattingEnabled = true;
            this.comboBoxServer.Location = new System.Drawing.Point(99, 29);
            this.comboBoxServer.Name = "comboBoxServer";
            this.comboBoxServer.Size = new System.Drawing.Size(53, 21);
            this.comboBoxServer.TabIndex = 2;
            // 
            // labelServer
            // 
            this.labelServer.AutoSize = true;
            this.labelServer.Location = new System.Drawing.Point(57, 33);
            this.labelServer.Name = "labelServer";
            this.labelServer.Size = new System.Drawing.Size(41, 13);
            this.labelServer.TabIndex = 3;
            this.labelServer.Text = "Server:";
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(63, 53);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 4;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(208, 80);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.labelServer);
            this.Controls.Add(this.comboBoxServer);
            this.Controls.Add(this.labelSummonerName);
            this.Controls.Add(this.textBoxSummonerName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Config";
            this.Text = "111";
            this.Load += new System.EventHandler(this.Config_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSummonerName;
        private System.Windows.Forms.Label labelSummonerName;
        private System.Windows.Forms.ComboBox comboBoxServer;
        private System.Windows.Forms.Label labelServer;
        private System.Windows.Forms.Button buttonUpdate;
    }
}