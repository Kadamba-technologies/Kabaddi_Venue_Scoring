namespace OtherSports_DataPushing.Kabaddi
{
    partial class frmOtherCards
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rbTeamB = new System.Windows.Forms.RadioButton();
            this.rbTeamA = new System.Windows.Forms.RadioButton();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.gvTimeout = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label29 = new System.Windows.Forms.Label();
            this.cbCardType = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_MatchClock = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbTeamorCoach = new System.Windows.Forms.ComboBox();
            this.AutoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HalfID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RaidNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Team = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamorCoach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvTimeout)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbTeamB
            // 
            this.rbTeamB.AutoSize = true;
            this.rbTeamB.Location = new System.Drawing.Point(8, 9);
            this.rbTeamB.Name = "rbTeamB";
            this.rbTeamB.Size = new System.Drawing.Size(59, 17);
            this.rbTeamB.TabIndex = 588;
            this.rbTeamB.TabStop = true;
            this.rbTeamB.Text = "TeamB";
            this.rbTeamB.UseVisualStyleBackColor = true;
            // 
            // rbTeamA
            // 
            this.rbTeamA.AutoSize = true;
            this.rbTeamA.Location = new System.Drawing.Point(82, 9);
            this.rbTeamA.Name = "rbTeamA";
            this.rbTeamA.Size = new System.Drawing.Size(59, 17);
            this.rbTeamA.TabIndex = 589;
            this.rbTeamA.TabStop = true;
            this.rbTeamA.Text = "TeamA";
            this.rbTeamA.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(340, 135);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(79, 30);
            this.btnSubmit.TabIndex = 591;
            this.btnSubmit.Text = "ADD";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // gvTimeout
            // 
            this.gvTimeout.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvTimeout.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvTimeout.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTimeout.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AutoID,
            this.HalfID,
            this.RaidNo,
            this.Time,
            this.Team,
            this.TeamorCoach,
            this.CardType});
            this.gvTimeout.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvTimeout.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvTimeout.Location = new System.Drawing.Point(12, 217);
            this.gvTimeout.Name = "gvTimeout";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvTimeout.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gvTimeout.RowHeadersVisible = false;
            this.gvTimeout.Size = new System.Drawing.Size(410, 172);
            this.gvTimeout.TabIndex = 592;
            this.gvTimeout.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvTimeout_CellDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.Font = new System.Drawing.Font("Verdana", 30F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(152, 9);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(144, 48);
            this.label29.TabIndex = 593;
            this.label29.Text = "CARD";
            // 
            // cbCardType
            // 
            this.cbCardType.FormattingEnabled = true;
            this.cbCardType.Items.AddRange(new object[] {
            "Success",
            "Fail"});
            this.cbCardType.Location = new System.Drawing.Point(176, 177);
            this.cbCardType.Name = "cbCardType";
            this.cbCardType.Size = new System.Drawing.Size(121, 21);
            this.cbCardType.TabIndex = 594;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(58, 85);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(52, 14);
            this.label17.TabIndex = 595;
            this.label17.Text = "Team :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 14);
            this.label1.TabIndex = 596;
            this.label1.Text = "Card Type :";
            // 
            // dtp_MatchClock
            // 
            this.dtp_MatchClock.CustomFormat = "mm:ss";
            this.dtp_MatchClock.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.dtp_MatchClock.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_MatchClock.Location = new System.Drawing.Point(176, 141);
            this.dtp_MatchClock.Name = "dtp_MatchClock";
            this.dtp_MatchClock.ShowUpDown = true;
            this.dtp_MatchClock.Size = new System.Drawing.Size(80, 30);
            this.dtp_MatchClock.TabIndex = 597;
            this.dtp_MatchClock.Value = new System.DateTime(2018, 1, 31, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(58, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 14);
            this.label2.TabIndex = 598;
            this.label2.Text = "Clock :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(58, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 14);
            this.label3.TabIndex = 599;
            this.label3.Text = "CARD Given to :";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbTeamA);
            this.panel1.Controls.Add(this.rbTeamB);
            this.panel1.Location = new System.Drawing.Point(176, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(160, 33);
            this.panel1.TabIndex = 600;
            // 
            // cbTeamorCoach
            // 
            this.cbTeamorCoach.FormattingEnabled = true;
            this.cbTeamorCoach.Items.AddRange(new object[] {
            "Team",
            "Coach"});
            this.cbTeamorCoach.Location = new System.Drawing.Point(176, 117);
            this.cbTeamorCoach.Name = "cbTeamorCoach";
            this.cbTeamorCoach.Size = new System.Drawing.Size(121, 21);
            this.cbTeamorCoach.TabIndex = 601;
            // 
            // AutoID
            // 
            this.AutoID.DataPropertyName = "AutoID";
            this.AutoID.HeaderText = "AutoID";
            this.AutoID.Name = "AutoID";
            this.AutoID.Visible = false;
            // 
            // HalfID
            // 
            this.HalfID.DataPropertyName = "HalfID";
            this.HalfID.HeaderText = "Half No";
            this.HalfID.Name = "HalfID";
            this.HalfID.Width = 50;
            // 
            // RaidNo
            // 
            this.RaidNo.DataPropertyName = "RaidNo";
            this.RaidNo.HeaderText = "RaidNo";
            this.RaidNo.Name = "RaidNo";
            this.RaidNo.Width = 50;
            // 
            // Time
            // 
            this.Time.DataPropertyName = "Time";
            this.Time.HeaderText = "Time";
            this.Time.Name = "Time";
            this.Time.Width = 70;
            // 
            // Team
            // 
            this.Team.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Team.DataPropertyName = "TeamName";
            this.Team.HeaderText = "Team";
            this.Team.Name = "Team";
            // 
            // TeamorCoach
            // 
            this.TeamorCoach.DataPropertyName = "TeamorCoach";
            this.TeamorCoach.HeaderText = "TeamorCoach";
            this.TeamorCoach.Name = "TeamorCoach";
            // 
            // CardType
            // 
            this.CardType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CardType.DataPropertyName = "CardType";
            this.CardType.HeaderText = "CardType";
            this.CardType.Name = "CardType";
            this.CardType.Width = 80;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(366, 174);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(53, 20);
            this.btnClear.TabIndex = 602;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmOtherCards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 414);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.cbTeamorCoach);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtp_MatchClock);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cbCardType);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.gvTimeout);
            this.Controls.Add(this.btnSubmit);
            this.Name = "frmOtherCards";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTimeout";
            this.Load += new System.EventHandler(this.frmReview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvTimeout)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbTeamB;
        private System.Windows.Forms.RadioButton rbTeamA;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.DataGridView gvTimeout;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbCardType;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_MatchClock;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbTeamorCoach;
        private System.Windows.Forms.DataGridViewTextBoxColumn AutoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn HalfID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RaidNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Team;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeamorCoach;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardType;
        private System.Windows.Forms.Button btnClear;
    }
}