namespace OtherSports_DataPushing
{
    partial class FrmLineup_Athletic
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
            this.TxtPlayerFilter = new System.Windows.Forms.TextBox();
            this.lstPlayersList = new System.Windows.Forms.ListBox();
            this.lblAvailableClub = new System.Windows.Forms.Label();
            this.lblCurrentclub = new System.Windows.Forms.Label();
            this.cbTeams = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtTotal = new System.Windows.Forms.TextBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnassigntoclubplayerlist = new System.Windows.Forms.Button();
            this.btnInsertall = new System.Windows.Forms.Button();
            this.btnRemoveall = new System.Windows.Forms.Button();
            this.gvTeamDetails = new System.Windows.Forms.DataGridView();
            this.PlayerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JercyNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PickNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LaneNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblAlert = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnResult = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvTeamDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtPlayerFilter
            // 
            this.TxtPlayerFilter.Location = new System.Drawing.Point(19, 88);
            this.TxtPlayerFilter.Name = "TxtPlayerFilter";
            this.TxtPlayerFilter.Size = new System.Drawing.Size(222, 20);
            this.TxtPlayerFilter.TabIndex = 26;
            this.TxtPlayerFilter.TextChanged += new System.EventHandler(this.TxtPlayerFilter_TextChanged);
            // 
            // lstPlayersList
            // 
            this.lstPlayersList.FormattingEnabled = true;
            this.lstPlayersList.Location = new System.Drawing.Point(19, 114);
            this.lstPlayersList.Name = "lstPlayersList";
            this.lstPlayersList.Size = new System.Drawing.Size(222, 368);
            this.lstPlayersList.TabIndex = 24;
            this.lstPlayersList.SelectedIndexChanged += new System.EventHandler(this.lstPlayersList_DoubleClick);
            this.lstPlayersList.DoubleClick += new System.EventHandler(this.lstPlayersList_DoubleClick);
            // 
            // lblAvailableClub
            // 
            this.lblAvailableClub.AutoSize = true;
            this.lblAvailableClub.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableClub.ForeColor = System.Drawing.Color.Black;
            this.lblAvailableClub.Location = new System.Drawing.Point(79, 54);
            this.lblAvailableClub.Name = "lblAvailableClub";
            this.lblAvailableClub.Size = new System.Drawing.Size(102, 14);
            this.lblAvailableClub.TabIndex = 25;
            this.lblAvailableClub.Text = "Available Player";
            // 
            // lblCurrentclub
            // 
            this.lblCurrentclub.AutoSize = true;
            this.lblCurrentclub.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentclub.ForeColor = System.Drawing.Color.Black;
            this.lblCurrentclub.Location = new System.Drawing.Point(345, 67);
            this.lblCurrentclub.Name = "lblCurrentclub";
            this.lblCurrentclub.Size = new System.Drawing.Size(39, 14);
            this.lblCurrentclub.TabIndex = 28;
            this.lblCurrentclub.Text = "Team";
            // 
            // cbTeams
            // 
            this.cbTeams.FormattingEnabled = true;
            this.cbTeams.Location = new System.Drawing.Point(295, 88);
            this.cbTeams.Name = "cbTeams";
            this.cbTeams.Size = new System.Drawing.Size(195, 21);
            this.cbTeams.TabIndex = 27;
            this.cbTeams.SelectedIndexChanged += new System.EventHandler(this.cbTeams_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(472, 491);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 14);
            this.label1.TabIndex = 30;
            this.label1.Text = "Total";
            // 
            // TxtTotal
            // 
            this.TxtTotal.BackColor = System.Drawing.Color.White;
            this.TxtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotal.ForeColor = System.Drawing.Color.Black;
            this.TxtTotal.Location = new System.Drawing.Point(516, 488);
            this.TxtTotal.Name = "TxtTotal";
            this.TxtTotal.Size = new System.Drawing.Size(114, 20);
            this.TxtTotal.TabIndex = 29;
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.Transparent;
            this.btnRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemove.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.Color.Black;
            this.btnRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemove.Location = new System.Drawing.Point(247, 240);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(40, 27);
            this.btnRemove.TabIndex = 470;
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
            this.btnassigntoclubplayerlist.Location = new System.Drawing.Point(247, 199);
            this.btnassigntoclubplayerlist.Name = "btnassigntoclubplayerlist";
            this.btnassigntoclubplayerlist.Size = new System.Drawing.Size(40, 27);
            this.btnassigntoclubplayerlist.TabIndex = 469;
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
            this.btnInsertall.Location = new System.Drawing.Point(247, 314);
            this.btnInsertall.Name = "btnInsertall";
            this.btnInsertall.Size = new System.Drawing.Size(40, 27);
            this.btnInsertall.TabIndex = 472;
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
            this.btnRemoveall.Location = new System.Drawing.Point(247, 281);
            this.btnRemoveall.Name = "btnRemoveall";
            this.btnRemoveall.Size = new System.Drawing.Size(40, 27);
            this.btnRemoveall.TabIndex = 471;
            this.btnRemoveall.Text = "<<";
            this.btnRemoveall.UseVisualStyleBackColor = false;
            this.btnRemoveall.Click += new System.EventHandler(this.btnRemoveall_Click);
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
            this.PickNo,
            this.TeamID,
            this.TeamName,
            this.LaneNo});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvTeamDetails.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvTeamDetails.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.gvTeamDetails.Location = new System.Drawing.Point(295, 130);
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
            this.gvTeamDetails.Size = new System.Drawing.Size(496, 352);
            this.gvTeamDetails.TabIndex = 473;
            this.gvTeamDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvTeamDetails_CellClick);
            this.gvTeamDetails.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gvTeamDetails_DataError);
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
            this.PlayerName.Width = 200;
            // 
            // JercyNo
            // 
            this.JercyNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.JercyNo.DataPropertyName = "JercyNo";
            this.JercyNo.HeaderText = "JercyNo";
            this.JercyNo.Name = "JercyNo";
            this.JercyNo.Width = 55;
            // 
            // PickNo
            // 
            this.PickNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PickNo.DataPropertyName = "PickNo";
            this.PickNo.HeaderText = "PickNo";
            this.PickNo.Name = "PickNo";
            this.PickNo.Width = 80;
            // 
            // TeamID
            // 
            this.TeamID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TeamID.DataPropertyName = "TeamID";
            this.TeamID.HeaderText = "TeamID";
            this.TeamID.Name = "TeamID";
            this.TeamID.Visible = false;
            // 
            // TeamName
            // 
            this.TeamName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TeamName.DataPropertyName = "TeamName";
            this.TeamName.HeaderText = "TeamName";
            this.TeamName.Name = "TeamName";
            // 
            // LaneNo
            // 
            this.LaneNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.LaneNo.DataPropertyName = "LaneNo";
            this.LaneNo.HeaderText = "LaneNo";
            this.LaneNo.Name = "LaneNo";
            this.LaneNo.Width = 60;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(277, 503);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(84, 29);
            this.btnSubmit.TabIndex = 475;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblAlert
            // 
            this.lblAlert.AutoSize = true;
            this.lblAlert.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblAlert.ForeColor = System.Drawing.Color.Red;
            this.lblAlert.Location = new System.Drawing.Point(302, 486);
            this.lblAlert.Name = "lblAlert";
            this.lblAlert.Size = new System.Drawing.Size(37, 14);
            this.lblAlert.TabIndex = 476;
            this.lblAlert.Text = "Alert";
            this.lblAlert.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(250, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 25);
            this.label6.TabIndex = 477;
            this.label6.Text = "LineUp";
            // 
            // btnResult
            // 
            this.btnResult.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResult.Location = new System.Drawing.Point(367, 503);
            this.btnResult.Name = "btnResult";
            this.btnResult.Size = new System.Drawing.Size(107, 29);
            this.btnResult.TabIndex = 518;
            this.btnResult.Text = "ATTEMPTS";
            this.btnResult.UseVisualStyleBackColor = true;
            this.btnResult.Click += new System.EventHandler(this.btnResult_Click);
            // 
            // FrmLineup_Athletic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 544);
            this.Controls.Add(this.btnResult);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblAlert);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.gvTeamDetails);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnassigntoclubplayerlist);
            this.Controls.Add(this.btnInsertall);
            this.Controls.Add(this.btnRemoveall);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtTotal);
            this.Controls.Add(this.lblCurrentclub);
            this.Controls.Add(this.cbTeams);
            this.Controls.Add(this.TxtPlayerFilter);
            this.Controls.Add(this.lstPlayersList);
            this.Controls.Add(this.lblAvailableClub);
            this.Name = "FrmLineup_Athletic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLineup";
            this.Load += new System.EventHandler(this.FrmLineup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvTeamDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtPlayerFilter;
        private System.Windows.Forms.ListBox lstPlayersList;
        private System.Windows.Forms.Label lblAvailableClub;
        private System.Windows.Forms.Label lblCurrentclub;
        private System.Windows.Forms.ComboBox cbTeams;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtTotal;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnassigntoclubplayerlist;
        private System.Windows.Forms.Button btnInsertall;
        private System.Windows.Forms.Button btnRemoveall;
        private System.Windows.Forms.DataGridView gvTeamDetails;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblAlert;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn JercyNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PickNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeamID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LaneNo;
        private System.Windows.Forms.Button btnResult;
    }
}