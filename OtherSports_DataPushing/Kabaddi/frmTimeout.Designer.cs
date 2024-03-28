namespace OtherSports_DataPushing.Kabaddi
{
    partial class frmTimeout
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
            this.rbBoth = new System.Windows.Forms.RadioButton();
            this.rbTeamB = new System.Windows.Forms.RadioButton();
            this.rbTeamA = new System.Windows.Forms.RadioButton();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.gvTimeout = new System.Windows.Forms.DataGridView();
            this.AutoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HalfID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RaidNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Team = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label29 = new System.Windows.Forms.Label();
            this.Clock2 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.btnpause = new System.Windows.Forms.Button();
            this.btnstop = new System.Windows.Forms.Button();
            this.Timer_Clock = new System.Windows.Forms.Timer(this.components);
            this.rdallout = new System.Windows.Forms.RadioButton();
            this.rdothers = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.gvTimeout)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbBoth
            // 
            this.rbBoth.AutoSize = true;
            this.rbBoth.Location = new System.Drawing.Point(16, 101);
            this.rbBoth.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbBoth.Name = "rbBoth";
            this.rbBoth.Size = new System.Drawing.Size(72, 21);
            this.rbBoth.TabIndex = 590;
            this.rbBoth.TabStop = true;
            this.rbBoth.Text = "Official";
            this.rbBoth.UseVisualStyleBackColor = true;
            this.rbBoth.CheckedChanged += new System.EventHandler(this.rbTeamA_CheckedChanged);
            // 
            // rbTeamB
            // 
            this.rbTeamB.AutoSize = true;
            this.rbTeamB.Location = new System.Drawing.Point(16, 70);
            this.rbTeamB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbTeamB.Name = "rbTeamB";
            this.rbTeamB.Size = new System.Drawing.Size(74, 21);
            this.rbTeamB.TabIndex = 588;
            this.rbTeamB.TabStop = true;
            this.rbTeamB.Text = "TeamB";
            this.rbTeamB.UseVisualStyleBackColor = true;
            this.rbTeamB.CheckedChanged += new System.EventHandler(this.rbTeamA_CheckedChanged);
            // 
            // rbTeamA
            // 
            this.rbTeamA.AutoSize = true;
            this.rbTeamA.Location = new System.Drawing.Point(16, 38);
            this.rbTeamA.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbTeamA.Name = "rbTeamA";
            this.rbTeamA.Size = new System.Drawing.Size(74, 21);
            this.rbTeamA.TabIndex = 589;
            this.rbTeamA.TabStop = true;
            this.rbTeamA.Text = "TeamA";
            this.rbTeamA.UseVisualStyleBackColor = true;
            this.rbTeamA.CheckedChanged += new System.EventHandler(this.rbTeamA_CheckedChanged);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(629, 293);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(141, 78);
            this.btnSubmit.TabIndex = 591;
            this.btnSubmit.Text = "TIMEOUT START";
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
            this.Duration,
            this.Type});
            this.gvTimeout.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvTimeout.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvTimeout.Location = new System.Drawing.Point(16, 199);
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
            this.gvTimeout.Size = new System.Drawing.Size(588, 212);
            this.gvTimeout.TabIndex = 592;
            this.gvTimeout.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvTimeout_CellContentClick);
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
            // Duration
            // 
            this.Duration.DataPropertyName = "Duration";
            this.Duration.HeaderText = "Duration";
            this.Duration.Name = "Duration";
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Type";
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
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
            this.label29.Location = new System.Drawing.Point(184, -1);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(264, 60);
            this.label29.TabIndex = 593;
            this.label29.Text = "TimeOut";
            // 
            // Clock2
            // 
            this.Clock2.CustomFormat = "mm:ss";
            this.Clock2.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.Clock2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Clock2.Location = new System.Drawing.Point(195, 101);
            this.Clock2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Clock2.Name = "Clock2";
            this.Clock2.ShowUpDown = true;
            this.Clock2.Size = new System.Drawing.Size(117, 36);
            this.Clock2.TabIndex = 596;
            this.Clock2.Value = new System.DateTime(2018, 1, 31, 0, 0, 0, 0);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(193, 153);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 28);
            this.button1.TabIndex = 597;
            this.button1.Text = "start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnpause
            // 
            this.btnpause.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnpause.Location = new System.Drawing.Point(287, 154);
            this.btnpause.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnpause.Name = "btnpause";
            this.btnpause.Size = new System.Drawing.Size(85, 28);
            this.btnpause.TabIndex = 597;
            this.btnpause.Text = "Pause";
            this.btnpause.UseVisualStyleBackColor = true;
            this.btnpause.Click += new System.EventHandler(this.btnpause_Click);
            // 
            // btnstop
            // 
            this.btnstop.BackColor = System.Drawing.Color.Red;
            this.btnstop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnstop.Location = new System.Drawing.Point(656, 15);
            this.btnstop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnstop.Name = "btnstop";
            this.btnstop.Size = new System.Drawing.Size(96, 52);
            this.btnstop.TabIndex = 597;
            this.btnstop.Text = "Reset";
            this.btnstop.UseVisualStyleBackColor = false;
            this.btnstop.Click += new System.EventHandler(this.btnstop_Click);
            // 
            // Timer_Clock
            // 
            this.Timer_Clock.Tick += new System.EventHandler(this.Timer_Clock_Tick_1);
            // 
            // rdallout
            // 
            this.rdallout.AutoSize = true;
            this.rdallout.Location = new System.Drawing.Point(16, 129);
            this.rdallout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdallout.Name = "rdallout";
            this.rdallout.Size = new System.Drawing.Size(71, 21);
            this.rdallout.TabIndex = 598;
            this.rdallout.TabStop = true;
            this.rdallout.Text = "All Out";
            this.rdallout.UseVisualStyleBackColor = true;
            this.rdallout.CheckedChanged += new System.EventHandler(this.rbTeamA_CheckedChanged);
            // 
            // rdothers
            // 
            this.rdothers.AutoSize = true;
            this.rdothers.Location = new System.Drawing.Point(16, 158);
            this.rdothers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdothers.Name = "rdothers";
            this.rdothers.Size = new System.Drawing.Size(72, 21);
            this.rdothers.TabIndex = 598;
            this.rdothers.TabStop = true;
            this.rdothers.Text = "Others";
            this.rdothers.UseVisualStyleBackColor = true;
            this.rdothers.CheckedChanged += new System.EventHandler(this.rbTeamA_CheckedChanged);
            // 
            // frmTimeout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 426);
            this.Controls.Add(this.rdothers);
            this.Controls.Add(this.rdallout);
            this.Controls.Add(this.btnstop);
            this.Controls.Add(this.btnpause);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Clock2);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.gvTimeout);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.rbBoth);
            this.Controls.Add(this.rbTeamB);
            this.Controls.Add(this.rbTeamA);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmTimeout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTimeout";
            this.Load += new System.EventHandler(this.frmTimeout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvTimeout)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbBoth;
        private System.Windows.Forms.RadioButton rbTeamB;
        private System.Windows.Forms.RadioButton rbTeamA;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.DataGridView gvTimeout;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker Clock2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnpause;
        private System.Windows.Forms.Button btnstop;
        private System.Windows.Forms.Timer Timer_Clock;
        private System.Windows.Forms.RadioButton rdallout;
        private System.Windows.Forms.RadioButton rdothers;
        private System.Windows.Forms.DataGridViewTextBoxColumn AutoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn HalfID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RaidNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Team;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
    }
}