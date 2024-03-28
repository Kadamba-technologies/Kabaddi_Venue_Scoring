namespace OtherSports_DataPushing.Kho_Kho
{
    partial class Frmtoss
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
            this.cbtoss = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnsubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbtoss
            // 
            this.cbtoss.FormattingEnabled = true;
            this.cbtoss.Location = new System.Drawing.Point(128, 38);
            this.cbtoss.Name = "cbtoss";
            this.cbtoss.Size = new System.Drawing.Size(207, 21);
            this.cbtoss.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Defenders Team";
            // 
            // btnsubmit
            // 
            this.btnsubmit.Location = new System.Drawing.Point(137, 82);
            this.btnsubmit.Name = "btnsubmit";
            this.btnsubmit.Size = new System.Drawing.Size(75, 29);
            this.btnsubmit.TabIndex = 2;
            this.btnsubmit.Text = "Submit";
            this.btnsubmit.UseVisualStyleBackColor = true;
            this.btnsubmit.Click += new System.EventHandler(this.btnsubmit_Click);
            // 
            // Frmtoss
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 131);
            this.Controls.Add(this.btnsubmit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbtoss);
            this.Name = "Frmtoss";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frmtoss";
            this.Load += new System.EventHandler(this.Frmtoss_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbtoss;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnsubmit;
    }
}