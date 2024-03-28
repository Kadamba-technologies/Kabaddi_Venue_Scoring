namespace OtherSports_DataPushing
{
    partial class frmMedalReadfrmJson
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnRead = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(241, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(247, 32);
            this.label2.TabIndex = 521;
            this.label2.Text = "MEDALS ENTRY";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRead
            // 
            this.btnRead.BackColor = System.Drawing.Color.SeaShell;
            this.btnRead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRead.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRead.ForeColor = System.Drawing.Color.Black;
            this.btnRead.Location = new System.Drawing.Point(247, 107);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(237, 53);
            this.btnRead.TabIndex = 522;
            this.btnRead.Text = "READ JSON";
            this.btnRead.UseVisualStyleBackColor = false;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // frmMedalReadfrmJson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 515);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.label2);
            this.Name = "frmMedalReadfrmJson";
            this.Text = "frmMedalReadfrmJson";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRead;
    }
}