namespace OtherSports_DataPushing
{
    partial class FrmValidation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmValidation));
            this.gvValidate = new System.Windows.Forms.DataGridView();
            this.Head = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MatchID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RaidNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbMatches = new System.Windows.Forms.ComboBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnDIPRecalculate = new System.Windows.Forms.Button();
            this.pnlError = new System.Windows.Forms.Panel();
            this.pbInplayerClose = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.llblErrorGrid = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gvValidate)).BeginInit();
            this.pnlError.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInplayerClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gvValidate
            // 
            this.gvValidate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvValidate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Head,
            this.MatchID,
            this.RaidNo,
            this.Description});
            this.gvValidate.Location = new System.Drawing.Point(37, 62);
            this.gvValidate.Name = "gvValidate";
            this.gvValidate.RowHeadersVisible = false;
            this.gvValidate.Size = new System.Drawing.Size(686, 505);
            this.gvValidate.TabIndex = 133;
            // 
            // Head
            // 
            this.Head.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Head.DataPropertyName = "Head";
            this.Head.HeaderText = "Head";
            this.Head.Name = "Head";
            this.Head.Width = 150;
            // 
            // MatchID
            // 
            this.MatchID.DataPropertyName = "MatchID";
            this.MatchID.HeaderText = "MatchID";
            this.MatchID.Name = "MatchID";
            this.MatchID.Width = 60;
            // 
            // RaidNo
            // 
            this.RaidNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RaidNo.DataPropertyName = "RaidNo";
            this.RaidNo.HeaderText = "RaidNo";
            this.RaidNo.Name = "RaidNo";
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.Width = 250;
            // 
            // cbMatches
            // 
            this.cbMatches.FormattingEnabled = true;
            this.cbMatches.Location = new System.Drawing.Point(261, 22);
            this.cbMatches.Name = "cbMatches";
            this.cbMatches.Size = new System.Drawing.Size(273, 21);
            this.cbMatches.TabIndex = 489;
            this.cbMatches.SelectedIndexChanged += new System.EventHandler(this.cbMatches_SelectedIndexChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(164, 24);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(76, 18);
            this.lblName.TabIndex = 488;
            this.lblName.Text = "Matches";
            // 
            // btnDIPRecalculate
            // 
            this.btnDIPRecalculate.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnDIPRecalculate.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDIPRecalculate.ForeColor = System.Drawing.Color.White;
            this.btnDIPRecalculate.Location = new System.Drawing.Point(561, 13);
            this.btnDIPRecalculate.Name = "btnDIPRecalculate";
            this.btnDIPRecalculate.Size = new System.Drawing.Size(103, 43);
            this.btnDIPRecalculate.TabIndex = 532;
            this.btnDIPRecalculate.Text = "DIP Recalculate";
            this.btnDIPRecalculate.UseVisualStyleBackColor = false;
            this.btnDIPRecalculate.Click += new System.EventHandler(this.btnDIPRecalculate_Click);
            // 
            // pnlError
            // 
            this.pnlError.Controls.Add(this.pbInplayerClose);
            this.pnlError.Controls.Add(this.dataGridView1);
            this.pnlError.Controls.Add(this.label1);
            this.pnlError.Location = new System.Drawing.Point(13, 62);
            this.pnlError.Name = "pnlError";
            this.pnlError.Size = new System.Drawing.Size(732, 531);
            this.pnlError.TabIndex = 533;
            this.pnlError.Visible = false;
            // 
            // pbInplayerClose
            // 
            this.pbInplayerClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbInplayerClose.BackgroundImage")));
            this.pbInplayerClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbInplayerClose.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbInplayerClose.Location = new System.Drawing.Point(712, 3);
            this.pbInplayerClose.Name = "pbInplayerClose";
            this.pbInplayerClose.Size = new System.Drawing.Size(17, 15);
            this.pbInplayerClose.TabIndex = 443;
            this.pbInplayerClose.TabStop = false;
            this.pbInplayerClose.Click += new System.EventHandler(this.pbInplayerClose_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 46);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(706, 472);
            this.dataGridView1.TabIndex = 134;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(286, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 18);
            this.label1.TabIndex = 488;
            this.label1.Text = "Error List";
            // 
            // llblErrorGrid
            // 
            this.llblErrorGrid.AutoSize = true;
            this.llblErrorGrid.Location = new System.Drawing.Point(678, 9);
            this.llblErrorGrid.Name = "llblErrorGrid";
            this.llblErrorGrid.Size = new System.Drawing.Size(67, 13);
            this.llblErrorGrid.TabIndex = 575;
            this.llblErrorGrid.TabStop = true;
            this.llblErrorGrid.Text = "DIP ERROR";
            this.llblErrorGrid.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblErrorGrid_LinkClicked);
            // 
            // FrmValidation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 596);
            this.Controls.Add(this.llblErrorGrid);
            this.Controls.Add(this.pnlError);
            this.Controls.Add(this.btnDIPRecalculate);
            this.Controls.Add(this.cbMatches);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.gvValidate);
            this.Name = "FrmValidation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Validation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmValidation_FormClosing);
            this.Load += new System.EventHandler(this.FrmValidation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvValidate)).EndInit();
            this.pnlError.ResumeLayout(false);
            this.pnlError.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInplayerClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvValidate;
        private System.Windows.Forms.ComboBox cbMatches;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Head;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatchID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RaidNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.Button btnDIPRecalculate;
        private System.Windows.Forms.Panel pnlError;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pbInplayerClose;
        private System.Windows.Forms.LinkLabel llblErrorGrid;
        private System.Windows.Forms.Label label1;
    }
}