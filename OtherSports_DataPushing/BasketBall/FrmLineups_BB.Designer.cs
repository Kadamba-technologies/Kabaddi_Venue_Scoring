namespace OtherSports_DataPushing.BasketBall
{
    partial class FrmLineups_BB
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
            this.gvTeamDetails = new System.Windows.Forms.DataGridView();
            this.PlayerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsLive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PlayerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JercyNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnassigntoclubplayerlist = new System.Windows.Forms.Button();
            this.btnInsertall = new System.Windows.Forms.Button();
            this.btnRemoveall = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtTotal = new System.Windows.Forms.TextBox();
            this.lblCurrentclub = new System.Windows.Forms.Label();
            this.cbTeams = new System.Windows.Forms.ComboBox();
            this.TxtPlayerFilter = new System.Windows.Forms.TextBox();
            this.lstPlayersList = new System.Windows.Forms.ListBox();
            this.lblAvailableClub = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvTeamDetails)).BeginInit();
            this.SuspendLayout();
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
            this.IsLive,
            this.PlayerName,
            this.JercyNo});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvTeamDetails.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvTeamDetails.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.gvTeamDetails.Location = new System.Drawing.Point(320, 112);
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
            this.gvTeamDetails.Size = new System.Drawing.Size(316, 352);
            this.gvTeamDetails.TabIndex = 520;
            this.gvTeamDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvTeamDetails_CellClick);
            this.gvTeamDetails.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvTeamDetails_CellEndEdit);
            this.gvTeamDetails.CellErrorTextChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvTeamDetails_CellErrorTextChanged);
            this.gvTeamDetails.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gvTeamDetails_DataError);
            // 
            // PlayerId
            // 
            this.PlayerId.DataPropertyName = "PlayerId";
            this.PlayerId.HeaderText = "ID";
            this.PlayerId.Name = "PlayerId";
            this.PlayerId.Visible = false;
            // 
            // IsLive
            // 
            this.IsLive.DataPropertyName = "IsLive";
            this.IsLive.HeaderText = "IsLive";
            this.IsLive.Name = "IsLive";
            this.IsLive.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsLive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsLive.Width = 60;
            // 
            // PlayerName
            // 
            this.PlayerName.DataPropertyName = "PlayerName";
            this.PlayerName.HeaderText = "Player Name";
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(257, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 25);
            this.label6.TabIndex = 519;
            this.label6.Text = "LineUp";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(283, 501);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(84, 29);
            this.btnSubmit.TabIndex = 518;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.Transparent;
            this.btnRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemove.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.Color.Black;
            this.btnRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemove.Location = new System.Drawing.Point(263, 238);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(40, 27);
            this.btnRemove.TabIndex = 515;
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
            this.btnassigntoclubplayerlist.Location = new System.Drawing.Point(263, 197);
            this.btnassigntoclubplayerlist.Name = "btnassigntoclubplayerlist";
            this.btnassigntoclubplayerlist.Size = new System.Drawing.Size(40, 27);
            this.btnassigntoclubplayerlist.TabIndex = 514;
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
            this.btnInsertall.Location = new System.Drawing.Point(263, 312);
            this.btnInsertall.Name = "btnInsertall";
            this.btnInsertall.Size = new System.Drawing.Size(40, 27);
            this.btnInsertall.TabIndex = 517;
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
            this.btnRemoveall.Location = new System.Drawing.Point(263, 279);
            this.btnRemoveall.Name = "btnRemoveall";
            this.btnRemoveall.Size = new System.Drawing.Size(40, 27);
            this.btnRemoveall.TabIndex = 516;
            this.btnRemoveall.Text = "<<";
            this.btnRemoveall.UseVisualStyleBackColor = false;
            this.btnRemoveall.Click += new System.EventHandler(this.btnRemoveall_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(411, 487);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 14);
            this.label1.TabIndex = 513;
            this.label1.Text = "Total";
            // 
            // TxtTotal
            // 
            this.TxtTotal.BackColor = System.Drawing.Color.White;
            this.TxtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotal.ForeColor = System.Drawing.Color.Black;
            this.TxtTotal.Location = new System.Drawing.Point(455, 484);
            this.TxtTotal.Name = "TxtTotal";
            this.TxtTotal.Size = new System.Drawing.Size(114, 20);
            this.TxtTotal.TabIndex = 512;
            // 
            // lblCurrentclub
            // 
            this.lblCurrentclub.AutoSize = true;
            this.lblCurrentclub.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentclub.ForeColor = System.Drawing.Color.Black;
            this.lblCurrentclub.Location = new System.Drawing.Point(443, 53);
            this.lblCurrentclub.Name = "lblCurrentclub";
            this.lblCurrentclub.Size = new System.Drawing.Size(39, 14);
            this.lblCurrentclub.TabIndex = 511;
            this.lblCurrentclub.Text = "Team";
            // 
            // cbTeams
            // 
            this.cbTeams.FormattingEnabled = true;
            this.cbTeams.Location = new System.Drawing.Point(393, 74);
            this.cbTeams.Name = "cbTeams";
            this.cbTeams.Size = new System.Drawing.Size(195, 21);
            this.cbTeams.TabIndex = 510;
            this.cbTeams.SelectedIndexChanged += new System.EventHandler(this.cbTeams_SelectedIndexChanged);
            // 
            // TxtPlayerFilter
            // 
            this.TxtPlayerFilter.Location = new System.Drawing.Point(25, 86);
            this.TxtPlayerFilter.Name = "TxtPlayerFilter";
            this.TxtPlayerFilter.Size = new System.Drawing.Size(222, 20);
            this.TxtPlayerFilter.TabIndex = 509;
            this.TxtPlayerFilter.Visible = false;
            this.TxtPlayerFilter.TextChanged += new System.EventHandler(this.TxtPlayerFilter_TextChanged);
            // 
            // lstPlayersList
            // 
            this.lstPlayersList.FormattingEnabled = true;
            this.lstPlayersList.Location = new System.Drawing.Point(25, 112);
            this.lstPlayersList.Name = "lstPlayersList";
            this.lstPlayersList.Size = new System.Drawing.Size(222, 368);
            this.lstPlayersList.TabIndex = 507;
            this.lstPlayersList.DoubleClick += new System.EventHandler(this.lstPlayersList_DoubleClick);
            // 
            // lblAvailableClub
            // 
            this.lblAvailableClub.AutoSize = true;
            this.lblAvailableClub.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableClub.ForeColor = System.Drawing.Color.Black;
            this.lblAvailableClub.Location = new System.Drawing.Point(85, 52);
            this.lblAvailableClub.Name = "lblAvailableClub";
            this.lblAvailableClub.Size = new System.Drawing.Size(102, 14);
            this.lblAvailableClub.TabIndex = 508;
            this.lblAvailableClub.Text = "Available Player";
            // 
            // FrmLineups_BB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 546);
            this.Controls.Add(this.gvTeamDetails);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSubmit);
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
            this.Name = "FrmLineups_BB";
            this.Text = "FrmLineups_BB";
            this.Load += new System.EventHandler(this.FrmLineups_BB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvTeamDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvTeamDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerId;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsLive;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn JercyNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnassigntoclubplayerlist;
        private System.Windows.Forms.Button btnInsertall;
        private System.Windows.Forms.Button btnRemoveall;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtTotal;
        private System.Windows.Forms.Label lblCurrentclub;
        private System.Windows.Forms.ComboBox cbTeams;
        private System.Windows.Forms.TextBox TxtPlayerFilter;
        private System.Windows.Forms.ListBox lstPlayersList;
        private System.Windows.Forms.Label lblAvailableClub;
    }
}