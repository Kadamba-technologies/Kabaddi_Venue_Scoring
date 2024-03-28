namespace OtherSports_DataPushing.Athletics
{
    partial class frmResult_Athletic
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblEventName = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.RANK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PickNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stats = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnResult = new System.Windows.Forms.Button();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SeaShell;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(319, 417);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(229, 50);
            this.btnSave.TabIndex = 515;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DimGray;
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.lblEventName);
            this.panel5.Controls.Add(this.label27);
            this.panel5.Location = new System.Drawing.Point(35, 12);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(854, 77);
            this.panel5.TabIndex = 516;
            // 
            // lblEventName
            // 
            this.lblEventName.AutoSize = true;
            this.lblEventName.BackColor = System.Drawing.Color.Transparent;
            this.lblEventName.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventName.ForeColor = System.Drawing.Color.White;
            this.lblEventName.Location = new System.Drawing.Point(161, 23);
            this.lblEventName.Name = "lblEventName";
            this.lblEventName.Size = new System.Drawing.Size(159, 25);
            this.lblEventName.TabIndex = 447;
            this.lblEventName.Text = "EVENT NAME";
            this.lblEventName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.White;
            this.label27.Location = new System.Drawing.Point(22, 28);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(121, 17);
            this.label27.TabIndex = 447;
            this.label27.Text = "EVENT NAME :";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(385, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 25);
            this.label2.TabIndex = 447;
            this.label2.Text = "EVENT RESULT";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvResult);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Location = new System.Drawing.Point(35, 133);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(854, 509);
            this.panel1.TabIndex = 516;
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.BackgroundColor = System.Drawing.Color.SeaShell;
            this.dgvResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.RANK,
            this.PlayerID,
            this.PlayerName,
            this.TeamID,
            this.TeamName,
            this.PickNo,
            this.Stats});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.SeaShell;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvResult.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvResult.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.dgvResult.Location = new System.Drawing.Point(62, 34);
            this.dgvResult.Name = "dgvResult";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResult.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvResult.RowHeadersVisible = false;
            this.dgvResult.RowTemplate.Height = 26;
            this.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResult.Size = new System.Drawing.Size(698, 355);
            this.dgvResult.TabIndex = 516;
            this.dgvResult.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResult_CellEndEdit);
            this.dgvResult.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvResult_CellMouseUp);
            this.dgvResult.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvResult_DataError);
            // 
            // Select
            // 
            this.Select.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Select.HeaderText = "";
            this.Select.Name = "Select";
            this.Select.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Select.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Select.Width = 40;
            // 
            // RANK
            // 
            this.RANK.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.RANK.DataPropertyName = "RANK";
            this.RANK.HeaderText = "RANK";
            this.RANK.Name = "RANK";
            this.RANK.Width = 85;
            // 
            // PlayerID
            // 
            this.PlayerID.DataPropertyName = "PlayerID";
            this.PlayerID.HeaderText = "PlayerID";
            this.PlayerID.Name = "PlayerID";
            this.PlayerID.Visible = false;
            // 
            // PlayerName
            // 
            this.PlayerName.DataPropertyName = "PlayerName";
            this.PlayerName.HeaderText = "PlayerName";
            this.PlayerName.Name = "PlayerName";
            this.PlayerName.Width = 255;
            // 
            // TeamID
            // 
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
            // PickNo
            // 
            this.PickNo.DataPropertyName = "PickNo";
            this.PickNo.HeaderText = "BIB No";
            this.PickNo.Name = "PickNo";
            // 
            // Stats
            // 
            this.Stats.DataPropertyName = "Stats";
            this.Stats.HeaderText = "Stats";
            this.Stats.Name = "Stats";
            // 
            // btnResult
            // 
            this.btnResult.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResult.Location = new System.Drawing.Point(782, 98);
            this.btnResult.Name = "btnResult";
            this.btnResult.Size = new System.Drawing.Size(107, 29);
            this.btnResult.TabIndex = 517;
            this.btnResult.Text = "ATTEMPTS";
            this.btnResult.UseVisualStyleBackColor = true;
            this.btnResult.Click += new System.EventHandler(this.btnResult_Click);
            // 
            // frmResult_Athletic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(919, 654);
            this.Controls.Add(this.btnResult);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Name = "frmResult_Athletic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ATHLETICS RESULT";
            this.Load += new System.EventHandler(this.frmResult_Athletic_Load);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblEventName;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn RANK;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeamID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PickNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stats;
        private System.Windows.Forms.Button btnResult;
    }
}