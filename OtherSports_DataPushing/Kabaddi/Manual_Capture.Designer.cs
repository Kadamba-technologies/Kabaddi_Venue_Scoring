namespace OtherSports_DataPushing.Kabaddi
{
    partial class Manual_Capture
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cbMatches = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblComp = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblMatch = new System.Windows.Forms.Label();
            this.cbCompetition = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgRaids = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRaids)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(689, 79);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.05263F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.94737F));
            this.tableLayoutPanel2.Controls.Add(this.cbMatches, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.cbCompetition, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(689, 79);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // cbMatches
            // 
            this.cbMatches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbMatches.FormattingEnabled = true;
            this.cbMatches.Location = new System.Drawing.Point(148, 42);
            this.cbMatches.Name = "cbMatches";
            this.cbMatches.Size = new System.Drawing.Size(538, 21);
            this.cbMatches.TabIndex = 3;
            this.cbMatches.SelectedIndexChanged += new System.EventHandler(this.cbMatches_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblComp);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(139, 30);
            this.panel2.TabIndex = 0;
            // 
            // lblComp
            // 
            this.lblComp.AutoSize = true;
            this.lblComp.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblComp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComp.Location = new System.Drawing.Point(54, 0);
            this.lblComp.Name = "lblComp";
            this.lblComp.Size = new System.Drawing.Size(85, 13);
            this.lblComp.TabIndex = 0;
            this.lblComp.Text = "Competition : ";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblMatch);
            this.panel3.Location = new System.Drawing.Point(3, 42);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(139, 30);
            this.panel3.TabIndex = 1;
            // 
            // lblMatch
            // 
            this.lblMatch.AutoSize = true;
            this.lblMatch.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatch.Location = new System.Drawing.Point(89, 0);
            this.lblMatch.Name = "lblMatch";
            this.lblMatch.Size = new System.Drawing.Size(50, 13);
            this.lblMatch.TabIndex = 0;
            this.lblMatch.Text = "Match :";
            // 
            // cbCompetition
            // 
            this.cbCompetition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbCompetition.FormattingEnabled = true;
            this.cbCompetition.Location = new System.Drawing.Point(148, 3);
            this.cbCompetition.Name = "cbCompetition";
            this.cbCompetition.Size = new System.Drawing.Size(538, 21);
            this.cbCompetition.TabIndex = 2;
            this.cbCompetition.SelectedIndexChanged += new System.EventHandler(this.cbCompetition_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.05493F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.94508F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1132, 619);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dgRaids);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 90);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1126, 526);
            this.panel5.TabIndex = 1;
            // 
            // dgRaids
            // 
            this.dgRaids.BackgroundColor = System.Drawing.Color.MistyRose;
            this.dgRaids.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRaids.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgRaids.Location = new System.Drawing.Point(9, 61);
            this.dgRaids.Name = "dgRaids";
            this.dgRaids.Size = new System.Drawing.Size(1108, 457);
            this.dgRaids.TabIndex = 0;
            this.dgRaids.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgRaids_RowValidated);
            // 
            // Manual_Capture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 619);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Manual_Capture";
            this.Text = "Manual_Capture";
            this.Load += new System.EventHandler(this.Manual_Capture_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgRaids)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ComboBox cbMatches;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblComp;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblMatch;
        private System.Windows.Forms.ComboBox cbCompetition;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgRaids;

    }
}