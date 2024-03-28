namespace OtherSports_DataPushing
{
    partial class frmDeleteMatchcs
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
            this.txtMatchid = new System.Windows.Forms.TextBox();
            this.lblMatcid = new System.Windows.Forms.Label();
            this.CmdSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbMatches = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMatchid
            // 
            this.txtMatchid.Location = new System.Drawing.Point(105, 38);
            this.txtMatchid.Name = "txtMatchid";
            this.txtMatchid.Size = new System.Drawing.Size(163, 24);
            this.txtMatchid.TabIndex = 69;
            // 
            // lblMatcid
            // 
            this.lblMatcid.AutoSize = true;
            this.lblMatcid.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatcid.ForeColor = System.Drawing.Color.Silver;
            this.lblMatcid.Location = new System.Drawing.Point(17, 43);
            this.lblMatcid.Name = "lblMatcid";
            this.lblMatcid.Size = new System.Drawing.Size(60, 13);
            this.lblMatcid.TabIndex = 70;
            this.lblMatcid.Text = "MatchID";
            // 
            // CmdSave
            // 
            this.CmdSave.BackColor = System.Drawing.Color.YellowGreen;
            this.CmdSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CmdSave.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdSave.ForeColor = System.Drawing.Color.White;
            this.CmdSave.Location = new System.Drawing.Point(121, 84);
            this.CmdSave.Name = "CmdSave";
            this.CmdSave.Size = new System.Drawing.Size(77, 27);
            this.CmdSave.TabIndex = 71;
            this.CmdSave.Text = "Clear";
            this.CmdSave.UseVisualStyleBackColor = false;
            this.CmdSave.Click += new System.EventHandler(this.CmdSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMatchid);
            this.groupBox1.Controls.Add(this.CmdSave);
            this.groupBox1.Controls.Add(this.lblMatcid);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Silver;
            this.groupBox1.Location = new System.Drawing.Point(66, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 137);
            this.groupBox1.TabIndex = 72;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Clear Transaction Table";
            // 
            // cbMatches
            // 
            this.cbMatches.FormattingEnabled = true;
            this.cbMatches.Location = new System.Drawing.Point(84, 51);
            this.cbMatches.Name = "cbMatches";
            this.cbMatches.Size = new System.Drawing.Size(272, 21);
            this.cbMatches.TabIndex = 525;
            this.cbMatches.SelectedIndexChanged += new System.EventHandler(this.cbMatches_SelectedIndexChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.label25.ForeColor = System.Drawing.Color.White;
            this.label25.Location = new System.Drawing.Point(27, 55);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(51, 13);
            this.label25.TabIndex = 524;
            this.label25.Text = "MATCH";
            // 
            // frmDeleteMatchcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(402, 262);
            this.Controls.Add(this.cbMatches);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "frmDeleteMatchcs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clear Transaction";
            this.Load += new System.EventHandler(this.frmDeleteMatchcs_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMatchid;
        private System.Windows.Forms.Label lblMatcid;
        private System.Windows.Forms.Button CmdSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbMatches;
        private System.Windows.Forms.Label label25;
    }
}