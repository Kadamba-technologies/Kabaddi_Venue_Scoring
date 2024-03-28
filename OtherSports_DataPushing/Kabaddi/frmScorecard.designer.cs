namespace OtherSports_DataPushing
{
    partial class frmScorecard
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
            this.dgvTeamA = new System.Windows.Forms.DataGridView();
            this.dgvTeamB = new System.Windows.Forms.DataGridView();
            this.lblTeamA = new System.Windows.Forms.Label();
            this.lblTeamB = new System.Windows.Forms.Label();
            this.dgvTeamscore = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTeamAScore = new System.Windows.Forms.Label();
            this.lblTeamANameGoal = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblTeamBScore = new System.Windows.Forms.Label();
            this.lblTeamBNameGoal = new System.Windows.Forms.Label();
            this.cbMatches = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeamA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeamB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeamscore)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTeamA
            // 
            this.dgvTeamA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeamA.Location = new System.Drawing.Point(12, 200);
            this.dgvTeamA.Name = "dgvTeamA";
            this.dgvTeamA.Size = new System.Drawing.Size(538, 365);
            this.dgvTeamA.TabIndex = 1;
            // 
            // dgvTeamB
            // 
            this.dgvTeamB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeamB.Location = new System.Drawing.Point(590, 200);
            this.dgvTeamB.Name = "dgvTeamB";
            this.dgvTeamB.Size = new System.Drawing.Size(542, 365);
            this.dgvTeamB.TabIndex = 1;
            // 
            // lblTeamA
            // 
            this.lblTeamA.AutoSize = true;
            this.lblTeamA.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeamA.ForeColor = System.Drawing.Color.Black;
            this.lblTeamA.Location = new System.Drawing.Point(172, 171);
            this.lblTeamA.Name = "lblTeamA";
            this.lblTeamA.Size = new System.Drawing.Size(98, 25);
            this.lblTeamA.TabIndex = 478;
            this.lblTeamA.Text = "TEAM A";
            this.lblTeamA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTeamB
            // 
            this.lblTeamB.AutoSize = true;
            this.lblTeamB.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeamB.ForeColor = System.Drawing.Color.Black;
            this.lblTeamB.Location = new System.Drawing.Point(714, 171);
            this.lblTeamB.Name = "lblTeamB";
            this.lblTeamB.Size = new System.Drawing.Size(97, 25);
            this.lblTeamB.TabIndex = 478;
            this.lblTeamB.Text = "TEAM B";
            this.lblTeamB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvTeamscore
            // 
            this.dgvTeamscore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeamscore.Location = new System.Drawing.Point(438, 51);
            this.dgvTeamscore.Name = "dgvTeamscore";
            this.dgvTeamscore.Size = new System.Drawing.Size(643, 105);
            this.dgvTeamscore.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DimGray;
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.panel1);
            this.panel5.Controls.Add(this.lblResult);
            this.panel5.Controls.Add(this.label27);
            this.panel5.Controls.Add(this.label26);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Location = new System.Drawing.Point(67, 43);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(341, 121);
            this.panel5.TabIndex = 498;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblTeamAScore);
            this.panel1.Controls.Add(this.lblTeamANameGoal);
            this.panel1.Location = new System.Drawing.Point(1, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(166, 59);
            this.panel1.TabIndex = 445;
            // 
            // lblTeamAScore
            // 
            this.lblTeamAScore.AutoSize = true;
            this.lblTeamAScore.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeamAScore.ForeColor = System.Drawing.SystemColors.Window;
            this.lblTeamAScore.Location = new System.Drawing.Point(48, 30);
            this.lblTeamAScore.Name = "lblTeamAScore";
            this.lblTeamAScore.Size = new System.Drawing.Size(66, 18);
            this.lblTeamAScore.TabIndex = 437;
            this.lblTeamAScore.Text = "AScore";
            this.lblTeamAScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTeamANameGoal
            // 
            this.lblTeamANameGoal.AutoSize = true;
            this.lblTeamANameGoal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeamANameGoal.ForeColor = System.Drawing.SystemColors.Window;
            this.lblTeamANameGoal.Location = new System.Drawing.Point(47, 8);
            this.lblTeamANameGoal.Name = "lblTeamANameGoal";
            this.lblTeamANameGoal.Size = new System.Drawing.Size(62, 16);
            this.lblTeamANameGoal.TabIndex = 434;
            this.lblTeamANameGoal.Text = "Team A";
            this.lblTeamANameGoal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.BackColor = System.Drawing.Color.Transparent;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.ForeColor = System.Drawing.Color.White;
            this.lblResult.Location = new System.Drawing.Point(61, 97);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(19, 13);
            this.lblResult.TabIndex = 448;
            this.lblResult.Text = "---";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.White;
            this.label27.Location = new System.Drawing.Point(3, 82);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(51, 13);
            this.label27.TabIndex = 447;
            this.label27.Text = "Result :";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.SystemColors.Info;
            this.label26.Location = new System.Drawing.Point(139, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(69, 18);
            this.label26.TabIndex = 446;
            this.label26.Text = "POINTS";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Transparent;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.lblTeamBScore);
            this.panel7.Controls.Add(this.lblTeamBNameGoal);
            this.panel7.Location = new System.Drawing.Point(167, 20);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(171, 59);
            this.panel7.TabIndex = 444;
            // 
            // lblTeamBScore
            // 
            this.lblTeamBScore.AutoSize = true;
            this.lblTeamBScore.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeamBScore.ForeColor = System.Drawing.SystemColors.Window;
            this.lblTeamBScore.Location = new System.Drawing.Point(46, 29);
            this.lblTeamBScore.Name = "lblTeamBScore";
            this.lblTeamBScore.Size = new System.Drawing.Size(65, 18);
            this.lblTeamBScore.TabIndex = 436;
            this.lblTeamBScore.Text = "BScore";
            this.lblTeamBScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTeamBNameGoal
            // 
            this.lblTeamBNameGoal.AutoSize = true;
            this.lblTeamBNameGoal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeamBNameGoal.ForeColor = System.Drawing.SystemColors.Window;
            this.lblTeamBNameGoal.Location = new System.Drawing.Point(43, 8);
            this.lblTeamBNameGoal.Name = "lblTeamBNameGoal";
            this.lblTeamBNameGoal.Size = new System.Drawing.Size(62, 16);
            this.lblTeamBNameGoal.TabIndex = 435;
            this.lblTeamBNameGoal.Text = "Team B";
            this.lblTeamBNameGoal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbMatches
            // 
            this.cbMatches.FormattingEnabled = true;
            this.cbMatches.Location = new System.Drawing.Point(457, 12);
            this.cbMatches.Name = "cbMatches";
            this.cbMatches.Size = new System.Drawing.Size(255, 21);
            this.cbMatches.TabIndex = 525;
            this.cbMatches.SelectedIndexChanged += new System.EventHandler(this.cbMatches_SelectedIndexChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(375, 15);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(60, 13);
            this.label25.TabIndex = 524;
            this.label25.Text = "Matches";
            // 
            // frmScorecard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 572);
            this.Controls.Add(this.cbMatches);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.lblTeamB);
            this.Controls.Add(this.lblTeamA);
            this.Controls.Add(this.dgvTeamB);
            this.Controls.Add(this.dgvTeamA);
            this.Controls.Add(this.dgvTeamscore);
            this.Name = "frmScorecard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scorecard";
            this.Load += new System.EventHandler(this.frmScorecard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeamA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeamB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeamscore)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTeamA;
        private System.Windows.Forms.DataGridView dgvTeamB;
        private System.Windows.Forms.Label lblTeamA;
        private System.Windows.Forms.Label lblTeamB;
        private System.Windows.Forms.DataGridView dgvTeamscore;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTeamAScore;
        private System.Windows.Forms.Label lblTeamANameGoal;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lblTeamBScore;
        private System.Windows.Forms.Label lblTeamBNameGoal;
        private System.Windows.Forms.ComboBox cbMatches;
        private System.Windows.Forms.Label label25;
    }
}