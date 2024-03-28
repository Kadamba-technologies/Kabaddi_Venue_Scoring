namespace OtherSports_DataPushing
{
    partial class FrmCompetitionSquad
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbTeam = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbCompetition = new System.Windows.Forms.ComboBox();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gvTeamDetails = new System.Windows.Forms.DataGridView();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnassigntoclubplayerlist = new System.Windows.Forms.Button();
            this.btnInsertall = new System.Windows.Forms.Button();
            this.btnRemoveall = new System.Windows.Forms.Button();
            this.lstPlayersList = new System.Windows.Forms.ListBox();
            this.TxtPlayerFilter = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtTotal = new System.Windows.Forms.TextBox();
            this.PlayerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JercyNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsWithdraw = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isReserved = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DGV2NewPlayer = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvTeamDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // cbTeam
            // 
            this.cbTeam.FormattingEnabled = true;
            this.cbTeam.Location = new System.Drawing.Point(443, 65);
            this.cbTeam.Name = "cbTeam";
            this.cbTeam.Size = new System.Drawing.Size(183, 21);
            this.cbTeam.TabIndex = 114;
            this.cbTeam.SelectedIndexChanged += new System.EventHandler(this.cbTeam_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(357, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 113;
            this.label4.Text = "TeamName";
            // 
            // cbCompetition
            // 
            this.cbCompetition.FormattingEnabled = true;
            this.cbCompetition.Location = new System.Drawing.Point(147, 65);
            this.cbCompetition.Name = "cbCompetition";
            this.cbCompetition.Size = new System.Drawing.Size(182, 21);
            this.cbCompetition.TabIndex = 108;
            this.cbCompetition.SelectedIndexChanged += new System.EventHandler(this.cbCompetition_SelectedIndexChanged);
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.AutoSize = true;
            this.lblPlayerName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerName.ForeColor = System.Drawing.Color.Black;
            this.lblPlayerName.Location = new System.Drawing.Point(56, 68);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(85, 13);
            this.lblPlayerName.TabIndex = 107;
            this.lblPlayerName.Text = "Competition";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(251, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 25);
            this.label1.TabIndex = 104;
            this.label1.Text = "Competition Squad";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(288, 508);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(84, 29);
            this.btnSubmit.TabIndex = 103;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // panel5
            // 
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Location = new System.Drawing.Point(541, 12);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(272, 27);
            this.panel5.TabIndex = 481;
            this.panel5.UseWaitCursor = true;
            this.panel5.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(200, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "JercyNo";
            this.label3.UseWaitCursor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(61, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "PlayerName";
            this.label6.UseWaitCursor = true;
            // 
            // gvTeamDetails
            // 
            this.gvTeamDetails.AllowUserToAddRows = false;
            this.gvTeamDetails.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gvTeamDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvTeamDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvTeamDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTeamDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PlayerId,
            this.PlayerName,
            this.JercyNo,
            this.IsWithdraw,
            this.isReserved,
            this.DGV2NewPlayer});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvTeamDetails.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvTeamDetails.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.gvTeamDetails.Location = new System.Drawing.Point(378, 120);
            this.gvTeamDetails.Name = "gvTeamDetails";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvTeamDetails.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gvTeamDetails.RowHeadersVisible = false;
            this.gvTeamDetails.RowTemplate.Height = 26;
            this.gvTeamDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvTeamDetails.Size = new System.Drawing.Size(607, 377);
            this.gvTeamDetails.TabIndex = 480;
            this.gvTeamDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvTeamDetails_CellContentClick);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.Transparent;
            this.btnRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemove.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.Color.Black;
            this.btnRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemove.Location = new System.Drawing.Point(332, 263);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(40, 27);
            this.btnRemove.TabIndex = 477;
            this.btnRemove.Text = "<";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnassigntoclubplayerlist
            // 
            this.btnassigntoclubplayerlist.BackColor = System.Drawing.Color.Transparent;
            this.btnassigntoclubplayerlist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnassigntoclubplayerlist.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnassigntoclubplayerlist.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnassigntoclubplayerlist.ForeColor = System.Drawing.Color.Black;
            this.btnassigntoclubplayerlist.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnassigntoclubplayerlist.Location = new System.Drawing.Point(332, 228);
            this.btnassigntoclubplayerlist.Name = "btnassigntoclubplayerlist";
            this.btnassigntoclubplayerlist.Size = new System.Drawing.Size(40, 27);
            this.btnassigntoclubplayerlist.TabIndex = 476;
            this.btnassigntoclubplayerlist.Text = ">";
            this.btnassigntoclubplayerlist.UseVisualStyleBackColor = false;
            this.btnassigntoclubplayerlist.Click += new System.EventHandler(this.btnassigntoclubplayerlist_Click);
            // 
            // btnInsertall
            // 
            this.btnInsertall.BackColor = System.Drawing.Color.Transparent;
            this.btnInsertall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInsertall.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInsertall.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsertall.ForeColor = System.Drawing.Color.Black;
            this.btnInsertall.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInsertall.Location = new System.Drawing.Point(332, 329);
            this.btnInsertall.Name = "btnInsertall";
            this.btnInsertall.Size = new System.Drawing.Size(40, 27);
            this.btnInsertall.TabIndex = 479;
            this.btnInsertall.Text = ">>";
            this.btnInsertall.UseVisualStyleBackColor = false;
            this.btnInsertall.Click += new System.EventHandler(this.btnInsertall_Click);
            // 
            // btnRemoveall
            // 
            this.btnRemoveall.BackColor = System.Drawing.Color.Transparent;
            this.btnRemoveall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemoveall.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemoveall.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveall.ForeColor = System.Drawing.Color.Black;
            this.btnRemoveall.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoveall.Location = new System.Drawing.Point(332, 296);
            this.btnRemoveall.Name = "btnRemoveall";
            this.btnRemoveall.Size = new System.Drawing.Size(40, 27);
            this.btnRemoveall.TabIndex = 478;
            this.btnRemoveall.Text = "<<";
            this.btnRemoveall.UseVisualStyleBackColor = false;
            this.btnRemoveall.Click += new System.EventHandler(this.btnRemoveall_Click);
            // 
            // lstPlayersList
            // 
            this.lstPlayersList.FormattingEnabled = true;
            this.lstPlayersList.Location = new System.Drawing.Point(104, 119);
            this.lstPlayersList.Name = "lstPlayersList";
            this.lstPlayersList.Size = new System.Drawing.Size(222, 368);
            this.lstPlayersList.TabIndex = 475;
            this.lstPlayersList.DoubleClick += new System.EventHandler(this.lstPlayersList_DoubleClick);
            // 
            // TxtPlayerFilter
            // 
            this.TxtPlayerFilter.Location = new System.Drawing.Point(104, 93);
            this.TxtPlayerFilter.Name = "TxtPlayerFilter";
            this.TxtPlayerFilter.Size = new System.Drawing.Size(222, 20);
            this.TxtPlayerFilter.TabIndex = 482;
            this.TxtPlayerFilter.TextChanged += new System.EventHandler(this.TxtPlayerFilter_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(442, 500);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 14);
            this.label2.TabIndex = 484;
            this.label2.Text = "Total";
            // 
            // TxtTotal
            // 
            this.TxtTotal.BackColor = System.Drawing.Color.White;
            this.TxtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotal.ForeColor = System.Drawing.Color.Black;
            this.TxtTotal.Location = new System.Drawing.Point(486, 499);
            this.TxtTotal.Name = "TxtTotal";
            this.TxtTotal.Size = new System.Drawing.Size(114, 20);
            this.TxtTotal.TabIndex = 483;
            // 
            // PlayerId
            // 
            this.PlayerId.DataPropertyName = "PlayerId";
            this.PlayerId.HeaderText = "ID";
            this.PlayerId.Name = "PlayerId";
            this.PlayerId.Visible = false;
            // 
            // PlayerName
            // 
            this.PlayerName.DataPropertyName = "PlayerName";
            this.PlayerName.HeaderText = "Name";
            this.PlayerName.Name = "PlayerName";
            this.PlayerName.Width = 220;
            // 
            // JercyNo
            // 
            this.JercyNo.DataPropertyName = "JercyNo";
            this.JercyNo.HeaderText = "JercyNo";
            this.JercyNo.Name = "JercyNo";
            this.JercyNo.Width = 50;
            // 
            // IsWithdraw
            // 
            this.IsWithdraw.DataPropertyName = "IsWithdraw";
            this.IsWithdraw.HeaderText = "IsWithdraw";
            this.IsWithdraw.Name = "IsWithdraw";
            // 
            // isReserved
            // 
            this.isReserved.DataPropertyName = "isReserved";
            this.isReserved.HeaderText = "isReserved";
            this.isReserved.Name = "isReserved";
            // 
            // DGV2NewPlayer
            // 
            this.DGV2NewPlayer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DGV2NewPlayer.HeaderText = "ReplaceBy";
            this.DGV2NewPlayer.MinimumWidth = 7;
            this.DGV2NewPlayer.Name = "DGV2NewPlayer";
            this.DGV2NewPlayer.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV2NewPlayer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // FrmCompetitionSquad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 549);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtTotal);
            this.Controls.Add(this.TxtPlayerFilter);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.gvTeamDetails);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnassigntoclubplayerlist);
            this.Controls.Add(this.btnInsertall);
            this.Controls.Add(this.btnRemoveall);
            this.Controls.Add(this.lstPlayersList);
            this.Controls.Add(this.cbTeam);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbCompetition);
            this.Controls.Add(this.lblPlayerName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSubmit);
            this.Name = "FrmCompetitionSquad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCompetitionSquad";
            this.Load += new System.EventHandler(this.FrmCompetitionSquad_Load);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvTeamDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTeam;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbCompetition;
        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView gvTeamDetails;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnassigntoclubplayerlist;
        private System.Windows.Forms.Button btnInsertall;
        private System.Windows.Forms.Button btnRemoveall;
        private System.Windows.Forms.ListBox lstPlayersList;
        private System.Windows.Forms.TextBox TxtPlayerFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn JercyNo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsWithdraw;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isReserved;
        private System.Windows.Forms.DataGridViewComboBoxColumn DGV2NewPlayer;
    }
}