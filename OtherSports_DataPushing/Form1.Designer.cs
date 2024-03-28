namespace OtherSports_DataPushing
{
    partial class frmBadmintonScore
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
            this.pnlmain = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pnlmain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlmain
            // 
            this.pnlmain.Controls.Add(this.panel1);
            this.pnlmain.Controls.Add(this.menuStrip1);
            this.pnlmain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlmain.Location = new System.Drawing.Point(0, 0);
            this.pnlmain.Name = "pnlmain";
            this.pnlmain.Size = new System.Drawing.Size(1276, 638);
            this.pnlmain.TabIndex = 0;
            this.pnlmain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlmain_Paint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Location = new System.Drawing.Point(447, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(403, 93);
            this.panel1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1276, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // frmBadmintonScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(1276, 638);
            this.Controls.Add(this.pnlmain);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmBadmintonScore";
            this.Text = "Form1";
            this.pnlmain.ResumeLayout(false);
            this.pnlmain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlmain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;

    }
}

