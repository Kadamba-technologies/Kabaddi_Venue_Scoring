namespace OtherSports_DataPushing.Kabaddi
{
    partial class frmBroadcast
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbName = new System.Windows.Forms.ComboBox();
            this.lblName = new System.Windows.Forms.Label();
            this.cbCompetition = new System.Windows.Forms.ComboBox();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.gvTeamADetails = new System.Windows.Forms.DataGridView();
            this.PlayerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BroadcastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JercyNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvTeamBDetails = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTeamA = new System.Windows.Forms.Label();
            this.lblTeamB = new System.Windows.Forms.Label();
            this.lblTeamAID = new System.Windows.Forms.Label();
            this.lblTeamBID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvTeamADetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTeamBDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // cbName
            // 
            this.cbName.FormattingEnabled = true;
            this.cbName.Location = new System.Drawing.Point(318, 48);
            this.cbName.Name = "cbName";
            this.cbName.Size = new System.Drawing.Size(245, 21);
            this.cbName.TabIndex = 97;
            this.cbName.Visible = false;
            this.cbName.SelectedIndexChanged += new System.EventHandler(this.cbName_SelectedIndexChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(252, 52);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(60, 13);
            this.lblName.TabIndex = 96;
            this.lblName.Text = "Matches";
            this.lblName.Visible = false;
            // 
            // cbCompetition
            // 
            this.cbCompetition.FormattingEnabled = true;
            this.cbCompetition.Location = new System.Drawing.Point(321, 15);
            this.cbCompetition.Name = "cbCompetition";
            this.cbCompetition.Size = new System.Drawing.Size(242, 21);
            this.cbCompetition.TabIndex = 95;
            this.cbCompetition.SelectedIndexChanged += new System.EventHandler(this.cbCompetition_SelectedIndexChanged);
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.AutoSize = true;
            this.lblPlayerName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerName.ForeColor = System.Drawing.Color.Black;
            this.lblPlayerName.Location = new System.Drawing.Point(232, 18);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(85, 13);
            this.lblPlayerName.TabIndex = 94;
            this.lblPlayerName.Text = "Competition";
            // 
            // gvTeamADetails
            // 
            this.gvTeamADetails.AllowUserToAddRows = false;
            this.gvTeamADetails.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gvTeamADetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvTeamADetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvTeamADetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTeamADetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PlayerId,
            this.PlayerName,
            this.BroadcastName,
            this.JercyNo});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvTeamADetails.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvTeamADetails.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.gvTeamADetails.Location = new System.Drawing.Point(15, 108);
            this.gvTeamADetails.Name = "gvTeamADetails";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvTeamADetails.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gvTeamADetails.RowHeadersVisible = false;
            this.gvTeamADetails.RowTemplate.Height = 26;
            this.gvTeamADetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvTeamADetails.Size = new System.Drawing.Size(440, 507);
            this.gvTeamADetails.TabIndex = 481;
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
            // BroadcastName
            // 
            this.BroadcastName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BroadcastName.DataPropertyName = "BroadcastName";
            this.BroadcastName.HeaderText = "BroadcastName";
            this.BroadcastName.Name = "BroadcastName";
            // 
            // JercyNo
            // 
            this.JercyNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.JercyNo.DataPropertyName = "JercyNo";
            this.JercyNo.HeaderText = "JercyNo";
            this.JercyNo.Name = "JercyNo";
            this.JercyNo.Width = 50;
            // 
            // gvTeamBDetails
            // 
            this.gvTeamBDetails.AllowUserToAddRows = false;
            this.gvTeamBDetails.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gvTeamBDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvTeamBDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gvTeamBDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTeamBDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvTeamBDetails.DefaultCellStyle = dataGridViewCellStyle5;
            this.gvTeamBDetails.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.gvTeamBDetails.Location = new System.Drawing.Point(461, 108);
            this.gvTeamBDetails.Name = "gvTeamBDetails";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvTeamBDetails.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gvTeamBDetails.RowHeadersVisible = false;
            this.gvTeamBDetails.RowTemplate.Height = 26;
            this.gvTeamBDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvTeamBDetails.Size = new System.Drawing.Size(440, 507);
            this.gvTeamBDetails.TabIndex = 481;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PlayerId";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "PlayerName";
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 220;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "BroadcastName";
            this.dataGridViewTextBoxColumn3.HeaderText = "BroadcastName";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "JercyNo";
            this.dataGridViewTextBoxColumn4.HeaderText = "JercyNo";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 50;
            // 
            // lblTeamA
            // 
            this.lblTeamA.AutoSize = true;
            this.lblTeamA.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeamA.ForeColor = System.Drawing.Color.Black;
            this.lblTeamA.Location = new System.Drawing.Point(163, 92);
            this.lblTeamA.Name = "lblTeamA";
            this.lblTeamA.Size = new System.Drawing.Size(56, 14);
            this.lblTeamA.TabIndex = 483;
            this.lblTeamA.Text = "Team A";
            // 
            // lblTeamB
            // 
            this.lblTeamB.AutoSize = true;
            this.lblTeamB.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeamB.ForeColor = System.Drawing.Color.Black;
            this.lblTeamB.Location = new System.Drawing.Point(628, 92);
            this.lblTeamB.Name = "lblTeamB";
            this.lblTeamB.Size = new System.Drawing.Size(56, 14);
            this.lblTeamB.TabIndex = 482;
            this.lblTeamB.Text = "Team B";
            // 
            // lblTeamAID
            // 
            this.lblTeamAID.AutoSize = true;
            this.lblTeamAID.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeamAID.ForeColor = System.Drawing.Color.Black;
            this.lblTeamAID.Location = new System.Drawing.Point(61, 78);
            this.lblTeamAID.Name = "lblTeamAID";
            this.lblTeamAID.Size = new System.Drawing.Size(31, 13);
            this.lblTeamAID.TabIndex = 483;
            this.lblTeamAID.Text = "AID";
            this.lblTeamAID.Visible = false;
            // 
            // lblTeamBID
            // 
            this.lblTeamBID.AutoSize = true;
            this.lblTeamBID.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeamBID.ForeColor = System.Drawing.Color.Black;
            this.lblTeamBID.Location = new System.Drawing.Point(813, 69);
            this.lblTeamBID.Name = "lblTeamBID";
            this.lblTeamBID.Size = new System.Drawing.Size(30, 13);
            this.lblTeamBID.TabIndex = 483;
            this.lblTeamBID.Text = "BID";
            this.lblTeamBID.Visible = false;
            // 
            // frmBroadcast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 620);
            this.Controls.Add(this.lblTeamBID);
            this.Controls.Add(this.lblTeamAID);
            this.Controls.Add(this.lblTeamA);
            this.Controls.Add(this.lblTeamB);
            this.Controls.Add(this.gvTeamBDetails);
            this.Controls.Add(this.gvTeamADetails);
            this.Controls.Add(this.cbName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.cbCompetition);
            this.Controls.Add(this.lblPlayerName);
            this.Name = "frmBroadcast";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Broadcast Master";
            this.Load += new System.EventHandler(this.frmBroadcast_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvTeamADetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTeamBDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ComboBox cbCompetition;
        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.DataGridView gvTeamADetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BroadcastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn JercyNo;
        private System.Windows.Forms.DataGridView gvTeamBDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Label lblTeamA;
        private System.Windows.Forms.Label lblTeamB;
        private System.Windows.Forms.Label lblTeamAID;
        private System.Windows.Forms.Label lblTeamBID;
    }
}