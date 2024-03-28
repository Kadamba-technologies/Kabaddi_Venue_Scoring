namespace OtherSports_DataPushing
{
    partial class frmSubstitute
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
            this.lbCurPlayerList = new System.Windows.Forms.ListBox();
            this.rbTeamB = new System.Windows.Forms.RadioButton();
            this.rbTeamA = new System.Windows.Forms.RadioButton();
            this.lbSubPlayerList = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label29 = new System.Windows.Forms.Label();
            this.gvSubstitute = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbRaidNo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_MatchClock = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblHalfID = new System.Windows.Forms.Label();
            this.AutoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HalfID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RaidNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Team = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubInID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubOutID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvSubstitute)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbCurPlayerList
            // 
            this.lbCurPlayerList.FormattingEnabled = true;
            this.lbCurPlayerList.Location = new System.Drawing.Point(21, 111);
            this.lbCurPlayerList.Name = "lbCurPlayerList";
            this.lbCurPlayerList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbCurPlayerList.Size = new System.Drawing.Size(193, 238);
            this.lbCurPlayerList.TabIndex = 532;
            // 
            // rbTeamB
            // 
            this.rbTeamB.AutoSize = true;
            this.rbTeamB.Location = new System.Drawing.Point(258, 61);
            this.rbTeamB.Name = "rbTeamB";
            this.rbTeamB.Size = new System.Drawing.Size(59, 17);
            this.rbTeamB.TabIndex = 585;
            this.rbTeamB.TabStop = true;
            this.rbTeamB.Text = "TeamB";
            this.rbTeamB.UseVisualStyleBackColor = true;
            this.rbTeamB.CheckedChanged += new System.EventHandler(this.rbTeam_CheckedChanged);
            // 
            // rbTeamA
            // 
            this.rbTeamA.AutoSize = true;
            this.rbTeamA.Location = new System.Drawing.Point(178, 61);
            this.rbTeamA.Name = "rbTeamA";
            this.rbTeamA.Size = new System.Drawing.Size(59, 17);
            this.rbTeamA.TabIndex = 586;
            this.rbTeamA.TabStop = true;
            this.rbTeamA.Text = "TeamA";
            this.rbTeamA.UseVisualStyleBackColor = true;
            this.rbTeamA.CheckedChanged += new System.EventHandler(this.rbTeam_CheckedChanged);
            // 
            // lbSubPlayerList
            // 
            this.lbSubPlayerList.FormattingEnabled = true;
            this.lbSubPlayerList.Location = new System.Drawing.Point(258, 111);
            this.lbSubPlayerList.Name = "lbSubPlayerList";
            this.lbSubPlayerList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbSubPlayerList.Size = new System.Drawing.Size(193, 238);
            this.lbSubPlayerList.TabIndex = 532;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnAdd.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(457, 232);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(77, 26);
            this.btnAdd.TabIndex = 587;
            this.btnAdd.Text = "ADD";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.Font = new System.Drawing.Font("Verdana", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(336, 9);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(363, 48);
            this.label29.TabIndex = 594;
            this.label29.Text = "SUBSTITUTION";
            // 
            // gvSubstitute
            // 
            this.gvSubstitute.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvSubstitute.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvSubstitute.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSubstitute.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AutoID,
            this.HalfID,
            this.RaidNo,
            this.Time,
            this.Team,
            this.TeamID,
            this.SubIn,
            this.SubInID,
            this.SubOut,
            this.SubOutID});
            this.gvSubstitute.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvSubstitute.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvSubstitute.Location = new System.Drawing.Point(540, 71);
            this.gvSubstitute.Name = "gvSubstitute";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvSubstitute.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gvSubstitute.RowHeadersVisible = false;
            this.gvSubstitute.Size = new System.Drawing.Size(435, 267);
            this.gvSubstitute.TabIndex = 595;
            this.gvSubstitute.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvSubstitute_CellDoubleClick);
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
            // cbRaidNo
            // 
            this.cbRaidNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbRaidNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbRaidNo.FormattingEnabled = true;
            this.cbRaidNo.Location = new System.Drawing.Point(468, 146);
            this.cbRaidNo.Name = "cbRaidNo";
            this.cbRaidNo.Size = new System.Drawing.Size(53, 21);
            this.cbRaidNo.TabIndex = 598;
            this.cbRaidNo.SelectedIndexChanged += new System.EventHandler(this.cbRaider_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(465, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 597;
            this.label1.Text = "RaidNo :";
            // 
            // dtp_MatchClock
            // 
            this.dtp_MatchClock.CustomFormat = "mm:ss";
            this.dtp_MatchClock.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.dtp_MatchClock.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_MatchClock.Location = new System.Drawing.Point(457, 183);
            this.dtp_MatchClock.Name = "dtp_MatchClock";
            this.dtp_MatchClock.ShowUpDown = true;
            this.dtp_MatchClock.Size = new System.Drawing.Size(80, 30);
            this.dtp_MatchClock.TabIndex = 599;
            this.dtp_MatchClock.Value = new System.DateTime(2018, 1, 31, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(311, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 17);
            this.label2.TabIndex = 600;
            this.label2.Text = "SUBPLAYER";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(45, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 17);
            this.label3.TabIndex = 601;
            this.label3.Text = "CURRENT PLAYER";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(466, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 602;
            this.label4.Text = "HalfID :";
            // 
            // lblHalfID
            // 
            this.lblHalfID.AutoSize = true;
            this.lblHalfID.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHalfID.ForeColor = System.Drawing.Color.Black;
            this.lblHalfID.Location = new System.Drawing.Point(482, 108);
            this.lblHalfID.Name = "lblHalfID";
            this.lblHalfID.Size = new System.Drawing.Size(15, 13);
            this.lblHalfID.TabIndex = 602;
            this.lblHalfID.Text = "1";
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
            // TeamID
            // 
            this.TeamID.DataPropertyName = "TeamID";
            this.TeamID.HeaderText = "TeamID";
            this.TeamID.Name = "TeamID";
            this.TeamID.Visible = false;
            // 
            // SubIn
            // 
            this.SubIn.DataPropertyName = "SubIn";
            this.SubIn.HeaderText = "SubIn";
            this.SubIn.Name = "SubIn";
            // 
            // SubInID
            // 
            this.SubInID.DataPropertyName = "SubInID";
            this.SubInID.HeaderText = "SubInID";
            this.SubInID.Name = "SubInID";
            this.SubInID.Visible = false;
            // 
            // SubOut
            // 
            this.SubOut.DataPropertyName = "SubOut";
            this.SubOut.HeaderText = "SubOut";
            this.SubOut.Name = "SubOut";
            // 
            // SubOutID
            // 
            this.SubOutID.DataPropertyName = "SubOutID";
            this.SubOutID.HeaderText = "SubOutID";
            this.SubOutID.Name = "SubOutID";
            this.SubOutID.Visible = false;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnClear.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(457, 274);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(77, 26);
            this.btnClear.TabIndex = 603;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmSubstitute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 379);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblHalfID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtp_MatchClock);
            this.Controls.Add(this.cbRaidNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gvSubstitute);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.rbTeamB);
            this.Controls.Add(this.rbTeamA);
            this.Controls.Add(this.lbSubPlayerList);
            this.Controls.Add(this.lbCurPlayerList);
            this.Name = "frmSubstitute";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.frmSubstitute_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvSubstitute)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbCurPlayerList;
        private System.Windows.Forms.RadioButton rbTeamB;
        private System.Windows.Forms.RadioButton rbTeamA;
        private System.Windows.Forms.ListBox lbSubPlayerList;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.DataGridView gvSubstitute;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbRaidNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_MatchClock;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblHalfID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AutoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn HalfID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RaidNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Team;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeamID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubInID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubOutID;
        private System.Windows.Forms.Button btnClear;
    }
}