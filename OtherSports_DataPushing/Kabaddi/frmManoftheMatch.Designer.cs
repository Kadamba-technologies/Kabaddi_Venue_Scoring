namespace OtherSports_DataPushing.Kabaddi
{
    partial class frmManoftheMatch
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
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lsPlayer = new System.Windows.Forms.ListBox();
            this.rbTeamB = new System.Windows.Forms.RadioButton();
            this.rbTeamA = new System.Windows.Forms.RadioButton();
            this.rbBoth = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(61, 228);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(61, 23);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "Ok";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lsPlayer
            // 
            this.lsPlayer.FormattingEnabled = true;
            this.lsPlayer.Location = new System.Drawing.Point(5, 24);
            this.lsPlayer.Name = "lsPlayer";
            this.lsPlayer.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lsPlayer.Size = new System.Drawing.Size(169, 199);
            this.lsPlayer.TabIndex = 2;
            this.lsPlayer.SelectedIndexChanged += new System.EventHandler(this.lsPlayer_SelectedIndexChanged);
            // 
            // rbTeamB
            // 
            this.rbTeamB.AutoSize = true;
            this.rbTeamB.Location = new System.Drawing.Point(66, 1);
            this.rbTeamB.Name = "rbTeamB";
            this.rbTeamB.Size = new System.Drawing.Size(59, 17);
            this.rbTeamB.TabIndex = 585;
            this.rbTeamB.TabStop = true;
            this.rbTeamB.Text = "TeamB";
            this.rbTeamB.UseVisualStyleBackColor = true;
            this.rbTeamB.CheckedChanged += new System.EventHandler(this.rbTeamPlayerFilter_CheckedChanged);
            // 
            // rbTeamA
            // 
            this.rbTeamA.AutoSize = true;
            this.rbTeamA.Location = new System.Drawing.Point(8, 1);
            this.rbTeamA.Name = "rbTeamA";
            this.rbTeamA.Size = new System.Drawing.Size(59, 17);
            this.rbTeamA.TabIndex = 586;
            this.rbTeamA.TabStop = true;
            this.rbTeamA.Text = "TeamA";
            this.rbTeamA.UseVisualStyleBackColor = true;
            this.rbTeamA.CheckedChanged += new System.EventHandler(this.rbTeamPlayerFilter_CheckedChanged);
            // 
            // rbBoth
            // 
            this.rbBoth.AutoSize = true;
            this.rbBoth.Location = new System.Drawing.Point(127, 1);
            this.rbBoth.Name = "rbBoth";
            this.rbBoth.Size = new System.Drawing.Size(47, 17);
            this.rbBoth.TabIndex = 587;
            this.rbBoth.TabStop = true;
            this.rbBoth.Text = "Both";
            this.rbBoth.UseVisualStyleBackColor = true;
            this.rbBoth.CheckedChanged += new System.EventHandler(this.rbTeamPlayerFilter_CheckedChanged);
            // 
            // frmManoftheMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(178, 257);
            this.Controls.Add(this.rbBoth);
            this.Controls.Add(this.rbTeamB);
            this.Controls.Add(this.rbTeamA);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lsPlayer);
            this.Name = "frmManoftheMatch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManoftheMatch";
            this.Load += new System.EventHandler(this.frmManoftheMatch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.ListBox lsPlayer;
        private System.Windows.Forms.RadioButton rbTeamB;
        private System.Windows.Forms.RadioButton rbTeamA;
        private System.Windows.Forms.RadioButton rbBoth;
    }
}