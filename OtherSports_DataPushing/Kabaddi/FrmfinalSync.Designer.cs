namespace OtherSports_DataPushing.Kabaddi
{
    partial class FrmfinalSync
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
            this.btnSync = new System.Windows.Forms.Button();
            this.label29 = new System.Windows.Forms.Label();
            this.cbMatches = new System.Windows.Forms.ComboBox();
            this.lblName = new System.Windows.Forms.Label();
            this.Stop_sync = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSync
            // 
            this.btnSync.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnSync.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSync.ForeColor = System.Drawing.Color.Transparent;
            this.btnSync.Location = new System.Drawing.Point(148, 163);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(99, 51);
            this.btnSync.TabIndex = 605;
            this.btnSync.Text = "Sync";
            this.btnSync.UseVisualStyleBackColor = false;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.Font = new System.Drawing.Font("Verdana", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(162, 52);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(200, 32);
            this.label29.TabIndex = 604;
            this.label29.Text = "FINAL SYNC";
            // 
            // cbMatches
            // 
            this.cbMatches.FormattingEnabled = true;
            this.cbMatches.Location = new System.Drawing.Point(141, 117);
            this.cbMatches.Name = "cbMatches";
            this.cbMatches.Size = new System.Drawing.Size(273, 21);
            this.cbMatches.TabIndex = 603;
            this.cbMatches.SelectedIndexChanged += new System.EventHandler(this.cbMatches_SelectedIndexChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(59, 119);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(76, 18);
            this.lblName.TabIndex = 602;
            this.lblName.Text = "Matches";
            // 
            // Stop_sync
            // 
            this.Stop_sync.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.Stop_sync.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Stop_sync.ForeColor = System.Drawing.Color.Transparent;
            this.Stop_sync.Location = new System.Drawing.Point(263, 163);
            this.Stop_sync.Name = "Stop_sync";
            this.Stop_sync.Size = new System.Drawing.Size(99, 51);
            this.Stop_sync.TabIndex = 606;
            this.Stop_sync.Text = "Stop";
            this.Stop_sync.UseVisualStyleBackColor = false;
            this.Stop_sync.Click += new System.EventHandler(this.Stop_sync_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(163, 237);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 25);
            this.label1.TabIndex = 607;
            this.label1.Text = "            ";
            // 
            // FrmfinalSync
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 290);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Stop_sync);
            this.Controls.Add(this.btnSync);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.cbMatches);
            this.Controls.Add(this.lblName);
            this.Name = "FrmfinalSync";
            this.Text = "FrmfinalSync";
            this.Load += new System.EventHandler(this.FrmfinalSync_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ComboBox cbMatches;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button Stop_sync;
        private System.Windows.Forms.Label label1;
    }
}