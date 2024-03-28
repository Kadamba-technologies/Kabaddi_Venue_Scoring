namespace OtherSports_DataPushing
{
    partial class frmMedalEntry
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
            this.cbEventMaster = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCurrentclub = new System.Windows.Forms.Label();
            this.cbTeams = new System.Windows.Forms.ComboBox();
            this.cbPlayerName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rdbGold = new System.Windows.Forms.RadioButton();
            this.rdbSilver = new System.Windows.Forms.RadioButton();
            this.rdbBronze = new System.Windows.Forms.RadioButton();
            this.dgvMedals = new System.Windows.Forms.DataGridView();
            this.AutoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Playername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EventName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MedalType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbSportName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedals)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbEventMaster
            // 
            this.cbEventMaster.FormattingEnabled = true;
            this.cbEventMaster.Location = new System.Drawing.Point(156, 132);
            this.cbEventMaster.Name = "cbEventMaster";
            this.cbEventMaster.Size = new System.Drawing.Size(294, 21);
            this.cbEventMaster.TabIndex = 107;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(62, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 106;
            this.label8.Text = "Event Name";
            // 
            // lblCurrentclub
            // 
            this.lblCurrentclub.AutoSize = true;
            this.lblCurrentclub.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentclub.ForeColor = System.Drawing.Color.Black;
            this.lblCurrentclub.Location = new System.Drawing.Point(62, 178);
            this.lblCurrentclub.Name = "lblCurrentclub";
            this.lblCurrentclub.Size = new System.Drawing.Size(78, 14);
            this.lblCurrentclub.TabIndex = 109;
            this.lblCurrentclub.Text = "State Name";
            // 
            // cbTeams
            // 
            this.cbTeams.FormattingEnabled = true;
            this.cbTeams.Location = new System.Drawing.Point(156, 176);
            this.cbTeams.Name = "cbTeams";
            this.cbTeams.Size = new System.Drawing.Size(195, 21);
            this.cbTeams.TabIndex = 108;
            this.cbTeams.SelectedIndexChanged += new System.EventHandler(this.cbTeams_SelectedIndexChanged);
            // 
            // cbPlayerName
            // 
            this.cbPlayerName.FormattingEnabled = true;
            this.cbPlayerName.Location = new System.Drawing.Point(156, 214);
            this.cbPlayerName.Name = "cbPlayerName";
            this.cbPlayerName.Size = new System.Drawing.Size(195, 21);
            this.cbPlayerName.TabIndex = 108;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(62, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 14);
            this.label1.TabIndex = 109;
            this.label1.Text = "Player Name";
            // 
            // rdbGold
            // 
            this.rdbGold.AutoSize = true;
            this.rdbGold.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold);
            this.rdbGold.Location = new System.Drawing.Point(21, 27);
            this.rdbGold.Name = "rdbGold";
            this.rdbGold.Size = new System.Drawing.Size(93, 29);
            this.rdbGold.TabIndex = 110;
            this.rdbGold.TabStop = true;
            this.rdbGold.Text = "GOLD";
            this.rdbGold.UseVisualStyleBackColor = true;
            // 
            // rdbSilver
            // 
            this.rdbSilver.AutoSize = true;
            this.rdbSilver.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold);
            this.rdbSilver.Location = new System.Drawing.Point(21, 62);
            this.rdbSilver.Name = "rdbSilver";
            this.rdbSilver.Size = new System.Drawing.Size(113, 29);
            this.rdbSilver.TabIndex = 110;
            this.rdbSilver.TabStop = true;
            this.rdbSilver.Text = "SILVER";
            this.rdbSilver.UseVisualStyleBackColor = true;
            // 
            // rdbBronze
            // 
            this.rdbBronze.AutoSize = true;
            this.rdbBronze.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold);
            this.rdbBronze.Location = new System.Drawing.Point(21, 97);
            this.rdbBronze.Name = "rdbBronze";
            this.rdbBronze.Size = new System.Drawing.Size(123, 29);
            this.rdbBronze.TabIndex = 110;
            this.rdbBronze.TabStop = true;
            this.rdbBronze.Text = "BRONZE";
            this.rdbBronze.UseVisualStyleBackColor = true;
            // 
            // dgvMedals
            // 
            this.dgvMedals.AllowUserToAddRows = false;
            this.dgvMedals.BackgroundColor = System.Drawing.Color.SeaShell;
            this.dgvMedals.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMedals.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMedals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedals.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AutoID,
            this.TeamName,
            this.Playername,
            this.EventName,
            this.MedalType});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SeaShell;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMedals.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMedals.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.dgvMedals.Location = new System.Drawing.Point(79, 321);
            this.dgvMedals.Name = "dgvMedals";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMedals.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMedals.RowHeadersVisible = false;
            this.dgvMedals.RowTemplate.Height = 26;
            this.dgvMedals.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMedals.Size = new System.Drawing.Size(698, 355);
            this.dgvMedals.TabIndex = 517;
            this.dgvMedals.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMedals_CellDoubleClick);
            // 
            // AutoID
            // 
            this.AutoID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.AutoID.DataPropertyName = "AutoID";
            this.AutoID.HeaderText = "AutoID";
            this.AutoID.Name = "AutoID";
            this.AutoID.Width = 50;
            // 
            // TeamName
            // 
            this.TeamName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TeamName.DataPropertyName = "TeamName";
            this.TeamName.HeaderText = "TeamName";
            this.TeamName.Name = "TeamName";
            // 
            // Playername
            // 
            this.Playername.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Playername.DataPropertyName = "Playername";
            this.Playername.HeaderText = "PlayerName";
            this.Playername.Name = "Playername";
            // 
            // EventName
            // 
            this.EventName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EventName.DataPropertyName = "EventName";
            this.EventName.HeaderText = "EventName";
            this.EventName.Name = "EventName";
            // 
            // MedalType
            // 
            this.MedalType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MedalType.DataPropertyName = "MedalType";
            this.MedalType.HeaderText = "MedalType";
            this.MedalType.Name = "MedalType";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbSilver);
            this.groupBox1.Controls.Add(this.rdbGold);
            this.groupBox1.Controls.Add(this.rdbBronze);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(528, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(174, 143);
            this.groupBox1.TabIndex = 518;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MEDALS";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SeaShell;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(721, 117);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(123, 90);
            this.btnSave.TabIndex = 519;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(316, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(247, 32);
            this.label2.TabIndex = 520;
            this.label2.Text = "MEDALS ENTRY";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbSportName
            // 
            this.cbSportName.FormattingEnabled = true;
            this.cbSportName.Location = new System.Drawing.Point(156, 88);
            this.cbSportName.Name = "cbSportName";
            this.cbSportName.Size = new System.Drawing.Size(195, 21);
            this.cbSportName.TabIndex = 108;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(62, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 14);
            this.label3.TabIndex = 109;
            this.label3.Text = "Sport Name";
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(801, 690);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 32);
            this.btnBack.TabIndex = 521;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SeaShell;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(665, -326);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 90);
            this.button1.TabIndex = 519;
            this.button1.Text = "SAVE";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(745, 247);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 32);
            this.btnClear.TabIndex = 521;
            this.btnClear.Text = "Back";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmMedalEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 734);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvMedals);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCurrentclub);
            this.Controls.Add(this.cbPlayerName);
            this.Controls.Add(this.cbSportName);
            this.Controls.Add(this.cbTeams);
            this.Controls.Add(this.cbEventMaster);
            this.Controls.Add(this.label8);
            this.Name = "frmMedalEntry";
            this.Text = "frmMedalEntry";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMedalEntry_FormClosing);
            this.Load += new System.EventHandler(this.frmMedalEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedals)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbEventMaster;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCurrentclub;
        private System.Windows.Forms.ComboBox cbTeams;
        private System.Windows.Forms.ComboBox cbPlayerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbGold;
        private System.Windows.Forms.RadioButton rdbSilver;
        private System.Windows.Forms.RadioButton rdbBronze;
        private System.Windows.Forms.DataGridView dgvMedals;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbSportName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridViewTextBoxColumn AutoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Playername;
        private System.Windows.Forms.DataGridViewTextBoxColumn EventName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MedalType;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnClear;
    }
}