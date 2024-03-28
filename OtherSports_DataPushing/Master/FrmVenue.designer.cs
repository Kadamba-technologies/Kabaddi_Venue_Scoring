namespace OtherSports_DataPushing
{
    partial class FrmVenue
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
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.cbName = new System.Windows.Forms.ComboBox();
            this.lblName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.lbGroundName = new System.Windows.Forms.Label();
            this.TxtCity = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(124, 191);
            this.txtCountry.MaxLength = 5;
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(146, 20);
            this.txtCountry.TabIndex = 95;
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(12, 260);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(84, 29);
            this.btnEdit.TabIndex = 94;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(192, 260);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(84, 29);
            this.btnClear.TabIndex = 93;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(102, 260);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(84, 29);
            this.btnSubmit.TabIndex = 92;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // cbName
            // 
            this.cbName.FormattingEnabled = true;
            this.cbName.Location = new System.Drawing.Point(111, 73);
            this.cbName.Name = "cbName";
            this.cbName.Size = new System.Drawing.Size(159, 21);
            this.cbName.TabIndex = 91;
            this.cbName.Visible = false;
            this.cbName.SelectedIndexChanged += new System.EventHandler(this.cbName_SelectedIndexChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(15, 76);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(95, 13);
            this.lblName.TabIndex = 90;
            this.lblName.Text = "Venue Names";
            this.lblName.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(78, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 25);
            this.label1.TabIndex = 89;
            this.label1.Text = "Venue Master";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(29, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 88;
            this.label6.Text = "Country";
            // 
            // TxtName
            // 
            this.TxtName.Location = new System.Drawing.Point(124, 113);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(146, 20);
            this.TxtName.TabIndex = 85;
            // 
            // lbGroundName
            // 
            this.lbGroundName.AutoSize = true;
            this.lbGroundName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGroundName.ForeColor = System.Drawing.Color.Black;
            this.lbGroundName.Location = new System.Drawing.Point(29, 116);
            this.lbGroundName.Name = "lbGroundName";
            this.lbGroundName.Size = new System.Drawing.Size(88, 13);
            this.lbGroundName.TabIndex = 84;
            this.lbGroundName.Text = "Venue Name";
            // 
            // TxtCity
            // 
            this.TxtCity.Location = new System.Drawing.Point(124, 153);
            this.TxtCity.MaxLength = 10;
            this.TxtCity.Name = "TxtCity";
            this.TxtCity.Size = new System.Drawing.Size(146, 20);
            this.TxtCity.TabIndex = 97;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(29, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 96;
            this.label2.Text = "City";
            // 
            // FrmVenue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 301);
            this.Controls.Add(this.TxtCity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCountry);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.cbName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TxtName);
            this.Controls.Add(this.lbGroundName);
            this.Name = "FrmVenue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Venue";
            this.Load += new System.EventHandler(this.Venue_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.ComboBox cbName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.Label lbGroundName;
        private System.Windows.Forms.TextBox TxtCity;
        private System.Windows.Forms.Label label2;
    }
}