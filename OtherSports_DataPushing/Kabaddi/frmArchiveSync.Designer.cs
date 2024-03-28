using System.Drawing;
using System.Windows.Forms;
namespace OtherSports_DataPushing.Kabaddi
{
    partial class frmArchiveSync
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tblScore = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblTeamBScore2 = new System.Windows.Forms.Label();
            this.lblTeamAScore2 = new System.Windows.Forms.Label();
            this.lblTeamB2 = new System.Windows.Forms.Label();
            this.lblTeamA2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblTeamAScore = new System.Windows.Forms.Label();
            this.lblTeamBScore = new System.Windows.Forms.Label();
            this.lblTeamB = new System.Windows.Forms.Label();
            this.lblTeamA = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.cbCompetition = new System.Windows.Forms.ComboBox();
            this.cbMatches = new System.Windows.Forms.ComboBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tblScore.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1135, 588);
            this.panel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnStop);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.cbCompetition);
            this.panel1.Controls.Add(this.cbMatches);
            this.panel1.Location = new System.Drawing.Point(74, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(975, 484);
            this.panel1.TabIndex = 6;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(273, 205);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(57, 20);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "label5";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tblScore);
            this.panel3.Location = new System.Drawing.Point(51, 245);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(876, 139);
            this.panel3.TabIndex = 6;
            // 
            // tblScore
            // 
            this.tblScore.ColumnCount = 2;
            this.tblScore.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblScore.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblScore.Controls.Add(this.panel5, 1, 0);
            this.tblScore.Controls.Add(this.panel4, 0, 0);
            this.tblScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblScore.Location = new System.Drawing.Point(0, 0);
            this.tblScore.Name = "tblScore";
            this.tblScore.RowCount = 1;
            this.tblScore.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblScore.Size = new System.Drawing.Size(876, 139);
            this.tblScore.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblTeamBScore2);
            this.panel5.Controls.Add(this.lblTeamAScore2);
            this.panel5.Controls.Add(this.lblTeamB2);
            this.panel5.Controls.Add(this.lblTeamA2);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(441, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(432, 133);
            this.panel5.TabIndex = 1;
            // 
            // lblTeamBScore2
            // 
            this.lblTeamBScore2.AutoSize = true;
            this.lblTeamBScore2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeamBScore2.ForeColor = System.Drawing.Color.Green;
            this.lblTeamBScore2.Location = new System.Drawing.Point(284, 96);
            this.lblTeamBScore2.Name = "lblTeamBScore2";
            this.lblTeamBScore2.Size = new System.Drawing.Size(122, 20);
            this.lblTeamBScore2.TabIndex = 5;
            this.lblTeamBScore2.Text = "Team B Score";
            // 
            // lblTeamAScore2
            // 
            this.lblTeamAScore2.AutoSize = true;
            this.lblTeamAScore2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.lblTeamAScore2.ForeColor = System.Drawing.Color.Green;
            this.lblTeamAScore2.Location = new System.Drawing.Point(61, 95);
            this.lblTeamAScore2.Name = "lblTeamAScore2";
            this.lblTeamAScore2.Size = new System.Drawing.Size(122, 20);
            this.lblTeamAScore2.TabIndex = 4;
            this.lblTeamAScore2.Text = "Team A Score";
            // 
            // lblTeamB2
            // 
            this.lblTeamB2.AutoSize = true;
            this.lblTeamB2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeamB2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTeamB2.Location = new System.Drawing.Point(302, 60);
            this.lblTeamB2.Name = "lblTeamB2";
            this.lblTeamB2.Size = new System.Drawing.Size(70, 20);
            this.lblTeamB2.TabIndex = 3;
            this.lblTeamB2.Text = "Team B";
            // 
            // lblTeamA2
            // 
            this.lblTeamA2.AutoSize = true;
            this.lblTeamA2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeamA2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTeamA2.Location = new System.Drawing.Point(77, 60);
            this.lblTeamA2.Name = "lblTeamA2";
            this.lblTeamA2.Size = new System.Drawing.Size(70, 20);
            this.lblTeamA2.TabIndex = 2;
            this.lblTeamA2.Text = "Team A";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(118, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(189, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "ARCHIVE SCORE";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblTeamAScore);
            this.panel4.Controls.Add(this.lblTeamBScore);
            this.panel4.Controls.Add(this.lblTeamB);
            this.panel4.Controls.Add(this.lblTeamA);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(432, 133);
            this.panel4.TabIndex = 0;
            // 
            // lblTeamAScore
            // 
            this.lblTeamAScore.AutoSize = true;
            this.lblTeamAScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeamAScore.ForeColor = System.Drawing.Color.Red;
            this.lblTeamAScore.Location = new System.Drawing.Point(40, 96);
            this.lblTeamAScore.Name = "lblTeamAScore";
            this.lblTeamAScore.Size = new System.Drawing.Size(122, 20);
            this.lblTeamAScore.TabIndex = 4;
            this.lblTeamAScore.Text = "Team A Score";
            // 
            // lblTeamBScore
            // 
            this.lblTeamBScore.AutoSize = true;
            this.lblTeamBScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeamBScore.ForeColor = System.Drawing.Color.Red;
            this.lblTeamBScore.Location = new System.Drawing.Point(254, 96);
            this.lblTeamBScore.Name = "lblTeamBScore";
            this.lblTeamBScore.Size = new System.Drawing.Size(122, 20);
            this.lblTeamBScore.TabIndex = 3;
            this.lblTeamBScore.Text = "Team B Score";
            // 
            // lblTeamB
            // 
            this.lblTeamB.AutoSize = true;
            this.lblTeamB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeamB.ForeColor = System.Drawing.Color.White;
            this.lblTeamB.Location = new System.Drawing.Point(280, 60);
            this.lblTeamB.Name = "lblTeamB";
            this.lblTeamB.Size = new System.Drawing.Size(70, 20);
            this.lblTeamB.TabIndex = 2;
            this.lblTeamB.Text = "Team B";
            // 
            // lblTeamA
            // 
            this.lblTeamA.AutoSize = true;
            this.lblTeamA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeamA.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTeamA.Location = new System.Drawing.Point(63, 60);
            this.lblTeamA.Name = "lblTeamA";
            this.lblTeamA.Size = new System.Drawing.Size(70, 20);
            this.lblTeamA.TabIndex = 1;
            this.lblTeamA.Text = "Team A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(164, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "K21 SCORE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(158, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Match : ";
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.DarkRed;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Location = new System.Drawing.Point(511, 141);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(106, 51);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(158, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Competition :";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.SystemColors.Control;
            this.btnStart.Location = new System.Drawing.Point(323, 141);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(113, 51);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // cbCompetition
            // 
            this.cbCompetition.FormattingEnabled = true;
            this.cbCompetition.Location = new System.Drawing.Point(277, 37);
            this.cbCompetition.Name = "cbCompetition";
            this.cbCompetition.Size = new System.Drawing.Size(407, 21);
            this.cbCompetition.TabIndex = 1;
            this.cbCompetition.SelectedIndexChanged += new System.EventHandler(this.cbCompetition_SelectedIndexChanged);
            // 
            // cbMatches
            // 
            this.cbMatches.FormattingEnabled = true;
            this.cbMatches.Location = new System.Drawing.Point(277, 82);
            this.cbMatches.Name = "cbMatches";
            this.cbMatches.Size = new System.Drawing.Size(407, 21);
            this.cbMatches.TabIndex = 3;
            // 
            // frmArchiveSync
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 588);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmArchiveSync";
            this.Text = "frmArchiveSync";
            this.Load += new System.EventHandler(this.frmArchiveSync_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.tblScore.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ComboBox cbMatches;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbCompetition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private Panel panel3;
        private TableLayoutPanel tblScore;
        private Panel panel5;
        private Label lblTeamBScore2;
        private Label lblTeamAScore2;
        private Label lblTeamB2;
        private Label lblTeamA2;
        private Label label4;
        private Panel panel4;
        private Label lblTeamAScore;
        private Label lblTeamBScore;
        private Label lblTeamB;
        private Label lblTeamA;
        private Label label3;
        private Label lblStatus;
    }
}