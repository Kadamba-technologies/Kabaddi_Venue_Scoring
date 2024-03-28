namespace OtherSports_DataPushing.Kabaddi
{
    partial class frmReview
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
            this.AutoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HalfID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RaidNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Team = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label29 = new System.Windows.Forms.Label();
            this.cmbOutcome = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_MatchClock = new System.Windows.Forms.DateTimePicker();
            this.btnClear = new System.Windows.Forms.Button();
            this.Timer_Clock = new System.Windows.Forms.Timer(this.components);
            this.Clock2 = new System.Windows.Forms.DateTimePicker();
            this.btnplay = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvTimeout)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbTeamB
            // 
            this.rbTeamB.AutoSize = true;
            this.rbTeamB.Location = new System.Drawing.Point(231, 105);
            this.rbTeamB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbTeamB.Name = "rbTeamB";
            this.rbTeamB.Size = new System.Drawing.Size(74, 21);
            this.rbTeamB.TabIndex = 588;
            this.rbTeamB.TabStop = true;
            this.rbTeamB.Text = "TeamB";
            this.rbTeamB.UseVisualStyleBackColor = true;
            // 
            // rbTeamA
            // 
            this.rbTeamA.AutoSize = true;
            this.rbTeamA.Location = new System.Drawing.Point(329, 105);
            this.rbTeamA.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbTeamA.Name = "rbTeamA";
            this.rbTeamA.Size = new System.Drawing.Size(74, 21);
            this.rbTeamA.TabIndex = 589;
            this.rbTeamA.TabStop = true;
            this.rbTeamA.Text = "TeamA";
            this.rbTeamA.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(396, 156);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(105, 37);
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
            this.Result,
            this.Duration});
            this.gvTimeout.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvTimeout.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvTimeout.Location = new System.Drawing.Point(16, 201);
            this.gvTimeout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.gvTimeout.Size = new System.Drawing.Size(587, 198);
            this.gvTimeout.TabIndex = 592;
            this.gvTimeout.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvTimeout_CellContentClick);
            this.gvTimeout.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvTimeout_CellDoubleClick);
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
            // Result
            // 
            this.Result.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Result.DataPropertyName = "Outcome";
            this.Result.HeaderText = "Result";
            this.Result.Name = "Result";
            this.Result.Width = 80;
            // 
            // Duration
            // 
            this.Duration.DataPropertyName = "Duration";
            this.Duration.HeaderText = "Duration";
            this.Duration.Name = "Duration";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(123, 28);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.Font = new System.Drawing.Font("Verdana", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(156, 14);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(229, 60);
            this.label29.TabIndex = 593;
            this.label29.Text = "Review";
            // 
            // cmbOutcome
            // 
            this.cmbOutcome.FormattingEnabled = true;
            this.cmbOutcome.Items.AddRange(new object[] {
            "Success",
            "Fail"});
            this.cmbOutcome.Location = new System.Drawing.Point(212, 166);
            this.cmbOutcome.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbOutcome.Name = "cmbOutcome";
            this.cmbOutcome.Size = new System.Drawing.Size(160, 24);
            this.cmbOutcome.TabIndex = 594;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(77, 106);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(134, 18);
            this.label17.TabIndex = 595;
            this.label17.Text = "Review Taken :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(77, 169);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 18);
            this.label1.TabIndex = 596;
            this.label1.Text = "Final Result :";
            // 
            // dtp_MatchClock
            // 
            this.dtp_MatchClock.CustomFormat = "mm:ss";
            this.dtp_MatchClock.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.dtp_MatchClock.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_MatchClock.Location = new System.Drawing.Point(29, 33);
            this.dtp_MatchClock.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtp_MatchClock.Name = "dtp_MatchClock";
            this.dtp_MatchClock.ShowUpDown = true;
            this.dtp_MatchClock.Size = new System.Drawing.Size(105, 36);
            this.dtp_MatchClock.TabIndex = 597;
            this.dtp_MatchClock.Value = new System.DateTime(2018, 1, 31, 0, 0, 0, 0);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(3, 420);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(71, 25);
            this.btnClear.TabIndex = 598;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // Timer_Clock
            // 
            this.Timer_Clock.Tick += new System.EventHandler(this.Timer_Clock_Tick);
            // 
            // Clock2
            // 
            this.Clock2.CustomFormat = "mm:ss";
            this.Clock2.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.Clock2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Clock2.Location = new System.Drawing.Point(529, 66);
            this.Clock2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Clock2.Name = "Clock2";
            this.Clock2.ShowUpDown = true;
            this.Clock2.Size = new System.Drawing.Size(105, 36);
            this.Clock2.TabIndex = 597;
            this.Clock2.Value = new System.DateTime(2018, 1, 31, 0, 0, 0, 0);
            // 
            // btnplay
            // 
            this.btnplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnplay.Location = new System.Drawing.Point(520, 121);
            this.btnplay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnplay.Name = "btnplay";
            this.btnplay.Size = new System.Drawing.Size(72, 28);
            this.btnplay.TabIndex = 599;
            this.btnplay.Text = "Start";
            this.btnplay.UseVisualStyleBackColor = true;
            this.btnplay.Click += new System.EventHandler(this.btnplay_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(624, 118);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(68, 28);
            this.button2.TabIndex = 599;
            this.button2.Text = "Pause";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(608, 9);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(76, 28);
            this.button3.TabIndex = 599;
            this.button3.Text = "Reset";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // frmReview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnplay);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.Clock2);
            this.Controls.Add(this.dtp_MatchClock);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cmbOutcome);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.gvTimeout);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.rbTeamB);
            this.Controls.Add(this.rbTeamA);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmReview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTimeout";
            this.Load += new System.EventHandler(this.frmReview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvTimeout)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
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
        private System.Windows.Forms.ComboBox cmbOutcome;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_MatchClock;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Timer Timer_Clock;
        private System.Windows.Forms.DateTimePicker Clock2;
        private System.Windows.Forms.Button btnplay;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn AutoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn HalfID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RaidNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Team;
        private System.Windows.Forms.DataGridViewTextBoxColumn Result;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
    }
}