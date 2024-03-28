namespace OtherSports_DataPushing
{
    partial class FrmOpenMatches
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gvMatches = new System.Windows.Forms.DataGridView();
            this.cbCompetition = new System.Windows.Forms.ComboBox();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.MatchID = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Matches = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Competition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvMatches)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(853, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 18);
            this.label2.TabIndex = 126;
            this.label2.Text = "Open Matches";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(992, 23);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(131, 24);
            this.txtSearch.TabIndex = 127;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(18, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1105, 38);
            this.panel2.TabIndex = 128;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(3, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 18);
            this.label3.TabIndex = 125;
            this.label3.Text = "MatchID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(130, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(483, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Match";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(947, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 18);
            this.label5.TabIndex = 123;
            this.label5.Text = "Competition";
            // 
            // gvMatches
            // 
            this.gvMatches.AllowUserToAddRows = false;
            this.gvMatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvMatches.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MatchID,
            this.Date,
            this.Matches,
            this.Competition});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvMatches.DefaultCellStyle = dataGridViewCellStyle1;
            this.gvMatches.Location = new System.Drawing.Point(18, 81);
            this.gvMatches.Name = "gvMatches";
            this.gvMatches.RowHeadersVisible = false;
            this.gvMatches.Size = new System.Drawing.Size(1105, 557);
            this.gvMatches.TabIndex = 129;
            this.gvMatches.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvMatches_CellClick);
            this.gvMatches.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvMatches_CellContentClick);
            // 
            // cbCompetition
            // 
            this.cbCompetition.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.cbCompetition.FormattingEnabled = true;
            this.cbCompetition.Location = new System.Drawing.Point(329, 30);
            this.cbCompetition.Name = "cbCompetition";
            this.cbCompetition.Size = new System.Drawing.Size(362, 26);
            this.cbCompetition.TabIndex = 131;
            this.cbCompetition.SelectedIndexChanged += new System.EventHandler(this.cbCompetition_SelectedIndexChanged);
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.AutoSize = true;
            this.lblPlayerName.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.lblPlayerName.ForeColor = System.Drawing.Color.Black;
            this.lblPlayerName.Location = new System.Drawing.Point(210, 33);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(113, 18);
            this.lblPlayerName.TabIndex = 130;
            this.lblPlayerName.Text = "Competition";
            // 
            // MatchID
            // 
            this.MatchID.DataPropertyName = "Matchid";
            this.MatchID.HeaderText = "MatchID";
            this.MatchID.Name = "MatchID";
            this.MatchID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MatchID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.MatchID.Width = 80;
            // 
            // Date
            // 
            this.Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.Width = 250;
            // 
            // Matches
            // 
            this.Matches.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Matches.DataPropertyName = "MatchName";
            this.Matches.HeaderText = "Matches";
            this.Matches.Name = "Matches";
            // 
            // Competition
            // 
            this.Competition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Competition.DataPropertyName = "CompetitionName";
            this.Competition.HeaderText = "Competition";
            this.Competition.Name = "Competition";
            this.Competition.Width = 200;
            // 
            // FrmOpenMatches
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 641);
            this.Controls.Add(this.cbCompetition);
            this.Controls.Add(this.lblPlayerName);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.gvMatches);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label2);
            this.Name = "FrmOpenMatches";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmOpenMatches";
            this.Load += new System.EventHandler(this.FrmOpenMatches_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvMatches)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView gvMatches;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbCompetition;
        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.DataGridViewLinkColumn MatchID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Matches;
        private System.Windows.Forms.DataGridViewTextBoxColumn Competition;
    }
}