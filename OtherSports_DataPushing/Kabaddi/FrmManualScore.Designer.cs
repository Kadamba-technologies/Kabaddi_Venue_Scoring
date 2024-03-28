namespace OtherSports_DataPushing.Kabaddi
{
    partial class FrmManualScore
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
            this.label11 = new System.Windows.Forms.Label();
            this.cbhalf_man = new System.Windows.Forms.ComboBox();
            this.txtteamBname_man = new System.Windows.Forms.TextBox();
            this.txtteamAname_man = new System.Windows.Forms.TextBox();
            this.btnupdate_man = new System.Windows.Forms.Button();
            this.txtteamBscore = new System.Windows.Forms.TextBox();
            this.txtteamAscore = new System.Windows.Forms.TextBox();
            this.chkhideDIP = new System.Windows.Forms.CheckBox();
            this.btnswapteam_man = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(400, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "HalfID";
            // 
            // cbhalf_man
            // 
            this.cbhalf_man.FormattingEnabled = true;
            this.cbhalf_man.Items.AddRange(new object[] {
            "1st",
            "2nd",
            "ET"});
            this.cbhalf_man.Location = new System.Drawing.Point(449, 10);
            this.cbhalf_man.Name = "cbhalf_man";
            this.cbhalf_man.Size = new System.Drawing.Size(58, 21);
            this.cbhalf_man.TabIndex = 11;
            // 
            // txtteamBname_man
            // 
            this.txtteamBname_man.Location = new System.Drawing.Point(298, 75);
            this.txtteamBname_man.Name = "txtteamBname_man";
            this.txtteamBname_man.Size = new System.Drawing.Size(208, 20);
            this.txtteamBname_man.TabIndex = 9;
            // 
            // txtteamAname_man
            // 
            this.txtteamAname_man.Location = new System.Drawing.Point(24, 75);
            this.txtteamAname_man.Name = "txtteamAname_man";
            this.txtteamAname_man.Size = new System.Drawing.Size(200, 20);
            this.txtteamAname_man.TabIndex = 10;
            // 
            // btnupdate_man
            // 
            this.btnupdate_man.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnupdate_man.Location = new System.Drawing.Point(218, 203);
            this.btnupdate_man.Name = "btnupdate_man";
            this.btnupdate_man.Size = new System.Drawing.Size(99, 48);
            this.btnupdate_man.TabIndex = 8;
            this.btnupdate_man.Text = "UPDATE";
            this.btnupdate_man.UseVisualStyleBackColor = true;
            this.btnupdate_man.Click += new System.EventHandler(this.btnupdate_man_Click);
            // 
            // txtteamBscore
            // 
            this.txtteamBscore.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtteamBscore.Location = new System.Drawing.Point(340, 129);
            this.txtteamBscore.Name = "txtteamBscore";
            this.txtteamBscore.Size = new System.Drawing.Size(130, 53);
            this.txtteamBscore.TabIndex = 6;
            this.txtteamBscore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtteamAscore
            // 
            this.txtteamAscore.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtteamAscore.Location = new System.Drawing.Point(58, 129);
            this.txtteamAscore.Name = "txtteamAscore";
            this.txtteamAscore.Size = new System.Drawing.Size(129, 53);
            this.txtteamAscore.TabIndex = 7;
            this.txtteamAscore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkhideDIP
            // 
            this.chkhideDIP.AutoSize = true;
            this.chkhideDIP.Location = new System.Drawing.Point(316, 14);
            this.chkhideDIP.Name = "chkhideDIP";
            this.chkhideDIP.Size = new System.Drawing.Size(69, 17);
            this.chkhideDIP.TabIndex = 13;
            this.chkhideDIP.Text = "Hide DIP";
            this.chkhideDIP.UseVisualStyleBackColor = true;
            this.chkhideDIP.CheckedChanged += new System.EventHandler(this.chkhideDIP_CheckedChanged);
            // 
            // btnswapteam_man
            // 
            this.btnswapteam_man.Location = new System.Drawing.Point(24, 14);
            this.btnswapteam_man.Name = "btnswapteam_man";
            this.btnswapteam_man.Size = new System.Drawing.Size(75, 23);
            this.btnswapteam_man.TabIndex = 14;
            this.btnswapteam_man.Text = "Swap team";
            this.btnswapteam_man.UseVisualStyleBackColor = true;
            this.btnswapteam_man.Click += new System.EventHandler(this.btnswapteam_man_Click);
            // 
            // FrmManualScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 265);
            this.Controls.Add(this.btnswapteam_man);
            this.Controls.Add(this.chkhideDIP);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cbhalf_man);
            this.Controls.Add(this.txtteamBname_man);
            this.Controls.Add(this.txtteamAname_man);
            this.Controls.Add(this.btnupdate_man);
            this.Controls.Add(this.txtteamBscore);
            this.Controls.Add(this.txtteamAscore);
            this.Name = "FrmManualScore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmManualScore";
            this.Load += new System.EventHandler(this.FrmManualScore_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbhalf_man;
        private System.Windows.Forms.TextBox txtteamBname_man;
        private System.Windows.Forms.TextBox txtteamAname_man;
        private System.Windows.Forms.Button btnupdate_man;
        private System.Windows.Forms.TextBox txtteamBscore;
        private System.Windows.Forms.TextBox txtteamAscore;
        private System.Windows.Forms.CheckBox chkhideDIP;
        private System.Windows.Forms.Button btnswapteam_man;
    }
}