namespace OtherSports_DataPushing
{
    partial class frmCoachMaster
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
            this.label6 = new System.Windows.Forms.Label();
            this.TxtMiddleName = new System.Windows.Forms.TextBox();
            this.lbMiddleName = new System.Windows.Forms.Label();
            this.TxtFirstName = new System.Windows.Forms.TextBox();
            this.lbFirstname = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbName = new System.Windows.Forms.ComboBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lbLastname = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(30, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 58;
            this.label6.Text = "Country";
            // 
            // TxtMiddleName
            // 
            this.TxtMiddleName.Location = new System.Drawing.Point(121, 124);
            this.TxtMiddleName.MaxLength = 50;
            this.TxtMiddleName.Name = "TxtMiddleName";
            this.TxtMiddleName.Size = new System.Drawing.Size(146, 20);
            this.TxtMiddleName.TabIndex = 57;
            // 
            // lbMiddleName
            // 
            this.lbMiddleName.AutoSize = true;
            this.lbMiddleName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMiddleName.ForeColor = System.Drawing.Color.Black;
            this.lbMiddleName.Location = new System.Drawing.Point(26, 127);
            this.lbMiddleName.Name = "lbMiddleName";
            this.lbMiddleName.Size = new System.Drawing.Size(90, 13);
            this.lbMiddleName.TabIndex = 56;
            this.lbMiddleName.Text = "Middle Name";
            // 
            // TxtFirstName
            // 
            this.TxtFirstName.Location = new System.Drawing.Point(121, 98);
            this.TxtFirstName.Name = "TxtFirstName";
            this.TxtFirstName.Size = new System.Drawing.Size(146, 20);
            this.TxtFirstName.TabIndex = 54;
            // 
            // lbFirstname
            // 
            this.lbFirstname.AutoSize = true;
            this.lbFirstname.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFirstname.ForeColor = System.Drawing.Color.Black;
            this.lbFirstname.Location = new System.Drawing.Point(26, 101);
            this.lbFirstname.Name = "lbFirstname";
            this.lbFirstname.Size = new System.Drawing.Size(78, 13);
            this.lbFirstname.TabIndex = 52;
            this.lbFirstname.Text = "First Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(81, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 25);
            this.label1.TabIndex = 71;
            this.label1.Text = "Coach Master";
            // 
            // cbName
            // 
            this.cbName.FormattingEnabled = true;
            this.cbName.Location = new System.Drawing.Point(114, 67);
            this.cbName.Name = "cbName";
            this.cbName.Size = new System.Drawing.Size(159, 21);
            this.cbName.TabIndex = 79;
            this.cbName.Visible = false;
            this.cbName.SelectedIndexChanged += new System.EventHandler(this.cbName_SelectedIndexChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(18, 70);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(94, 13);
            this.lblName.TabIndex = 78;
            this.lblName.Text = "Coach Names";
            this.lblName.Visible = false;
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(17, 222);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(84, 29);
            this.btnEdit.TabIndex = 82;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(197, 222);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(84, 29);
            this.btnClear.TabIndex = 81;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(107, 222);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(84, 29);
            this.btnSubmit.TabIndex = 80;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(121, 176);
            this.txtCountry.MaxLength = 50;
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(146, 20);
            this.txtCountry.TabIndex = 83;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(121, 150);
            this.txtLastName.MaxLength = 50;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(146, 20);
            this.txtLastName.TabIndex = 85;
            // 
            // lbLastname
            // 
            this.lbLastname.AutoSize = true;
            this.lbLastname.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLastname.ForeColor = System.Drawing.Color.Black;
            this.lbLastname.Location = new System.Drawing.Point(26, 153);
            this.lbLastname.Name = "lbLastname";
            this.lbLastname.Size = new System.Drawing.Size(75, 13);
            this.lbLastname.TabIndex = 84;
            this.lbLastname.Text = "Last Name";
            // 
            // frmCoachMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 293);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lbLastname);
            this.Controls.Add(this.txtCountry);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.cbName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TxtMiddleName);
            this.Controls.Add(this.lbMiddleName);
            this.Controls.Add(this.TxtFirstName);
            this.Controls.Add(this.lbFirstname);
            this.Name = "frmCoachMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmTeam";
            this.Load += new System.EventHandler(this.FrmTeam_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtMiddleName;
        private System.Windows.Forms.Label lbMiddleName;
        private System.Windows.Forms.TextBox TxtFirstName;
        private System.Windows.Forms.Label lbFirstname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lbLastname;

    }
}