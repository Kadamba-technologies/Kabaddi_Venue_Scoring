namespace OtherSports_DataPushing.BadMinton
{
    partial class FrmQC
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
            this.gvpointtable = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gvpointtable)).BeginInit();
            this.SuspendLayout();
            // 
            // gvpointtable
            // 
            this.gvpointtable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvpointtable.Location = new System.Drawing.Point(11, 45);
            this.gvpointtable.Name = "gvpointtable";
            this.gvpointtable.Size = new System.Drawing.Size(741, 371);
            this.gvpointtable.TabIndex = 0;
            // 
            // FrmQC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 422);
            this.Controls.Add(this.gvpointtable);
            this.Name = "FrmQC";
            this.Text = "FrmQC";
            this.Load += new System.EventHandler(this.FrmQC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvpointtable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvpointtable;
    }
}