namespace OtherSports_DataPushing.Kabaddi
{
    partial class frmSync
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
            this.cbMatches = new System.Windows.Forms.ComboBox();
            this.lblName = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.btnSync = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbMatches
            // 
            this.cbMatches.FormattingEnabled = true;
            this.cbMatches.Location = new System.Drawing.Point(118, 111);
            this.cbMatches.Name = "cbMatches";
            this.cbMatches.Size = new System.Drawing.Size(273, 21);
            this.cbMatches.TabIndex = 491;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(21, 113);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(76, 18);
            this.lblName.TabIndex = 490;
            this.lblName.Text = "Matches";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.Font = new System.Drawing.Font("Verdana", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(140, 41);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(140, 48);
            this.label29.TabIndex = 594;
            this.label29.Text = "SYNC";
            // 
            // btnSync
            // 
            this.btnSync.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnSync.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSync.ForeColor = System.Drawing.Color.Transparent;
            this.btnSync.Location = new System.Drawing.Point(164, 157);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(99, 51);
            this.btnSync.TabIndex = 601;
            this.btnSync.Text = "Sync";
            this.btnSync.UseVisualStyleBackColor = false;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // frmSync
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 263);
            this.Controls.Add(this.btnSync);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.cbMatches);
            this.Controls.Add(this.lblName);
            this.Name = "frmSync";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSync";
            this.Load += new System.EventHandler(this.frmSync_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbMatches;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Button btnSync;
    }
}