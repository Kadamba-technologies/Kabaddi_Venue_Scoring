namespace OtherSports_DataPushing.Kabaddi
{
    partial class frmPitchmapRegion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPitchmapRegion));
            this.pnlPitchMap = new System.Windows.Forms.Panel();
            this.txtRegion = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlPitchMap
            // 
            this.pnlPitchMap.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlPitchMap.BackgroundImage")));
            this.pnlPitchMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlPitchMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPitchMap.Location = new System.Drawing.Point(73, 33);
            this.pnlPitchMap.Name = "pnlPitchMap";
            this.pnlPitchMap.Size = new System.Drawing.Size(509, 292);
            this.pnlPitchMap.TabIndex = 590;
            this.pnlPitchMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlPitchMap_MouseClick);
            // 
            // txtRegion
            // 
            this.txtRegion.Location = new System.Drawing.Point(140, 357);
            this.txtRegion.Name = "txtRegion";
            this.txtRegion.Size = new System.Drawing.Size(116, 20);
            this.txtRegion.TabIndex = 591;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(309, 357);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(346, 23);
            this.textBox1.TabIndex = 591;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(145, 341);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(109, 13);
            this.lblName.TabIndex = 592;
            this.lblName.Text = "X,Y Coordinates";
            this.lblName.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(426, 341);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 593;
            this.label1.Text = "Region";
            this.label1.Visible = false;
            // 
            // frmPitchmapRegion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 395);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtRegion);
            this.Controls.Add(this.pnlPitchMap);
            this.Name = "frmPitchmapRegion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPitchmapRegion";
            this.Load += new System.EventHandler(this.frmPitchmapRegion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlPitchMap;
        private System.Windows.Forms.TextBox txtRegion;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label1;
    }
}