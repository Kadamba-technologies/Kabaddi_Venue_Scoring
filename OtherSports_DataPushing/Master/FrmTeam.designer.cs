namespace OtherSports_DataPushing
{
    partial class FrmTeam
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
            this.TxtPrefix = new System.Windows.Forms.TextBox();
            this.lbPrefix = new System.Windows.Forms.Label();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.lbGroundName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbName = new System.Windows.Forms.ComboBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.cbgroups = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.chkRandomID = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_refID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(26, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 58;
            this.label6.Text = "Country";
            // 
            // TxtPrefix
            // 
            this.TxtPrefix.Location = new System.Drawing.Point(121, 124);
            this.TxtPrefix.MaxLength = 50;
            this.TxtPrefix.Name = "TxtPrefix";
            this.TxtPrefix.Size = new System.Drawing.Size(146, 20);
            this.TxtPrefix.TabIndex = 57;
            // 
            // lbPrefix
            // 
            this.lbPrefix.AutoSize = true;
            this.lbPrefix.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrefix.ForeColor = System.Drawing.Color.Black;
            this.lbPrefix.Location = new System.Drawing.Point(26, 127);
            this.lbPrefix.Name = "lbPrefix";
            this.lbPrefix.Size = new System.Drawing.Size(46, 13);
            this.lbPrefix.TabIndex = 56;
            this.lbPrefix.Text = "Prefix";
            // 
            // TxtName
            // 
            this.TxtName.Location = new System.Drawing.Point(121, 98);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(146, 20);
            this.TxtName.TabIndex = 54;
            // 
            // lbGroundName
            // 
            this.lbGroundName.AutoSize = true;
            this.lbGroundName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGroundName.ForeColor = System.Drawing.Color.Black;
            this.lbGroundName.Location = new System.Drawing.Point(26, 101);
            this.lbGroundName.Name = "lbGroundName";
            this.lbGroundName.Size = new System.Drawing.Size(84, 13);
            this.lbGroundName.TabIndex = 52;
            this.lbGroundName.Text = "Team Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(81, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 25);
            this.label1.TabIndex = 71;
            this.label1.Text = "Team Master";
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
            this.lblName.Size = new System.Drawing.Size(91, 13);
            this.lblName.TabIndex = 78;
            this.lblName.Text = "Team Names";
            this.lblName.Visible = false;
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(12, 266);
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
            this.btnClear.Location = new System.Drawing.Point(192, 266);
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
            this.btnSubmit.Location = new System.Drawing.Point(102, 266);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(84, 29);
            this.btnSubmit.TabIndex = 80;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(121, 152);
            this.txtCountry.MaxLength = 50;
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(146, 20);
            this.txtCountry.TabIndex = 83;
            // 
            // cbgroups
            // 
            this.cbgroups.FormattingEnabled = true;
            this.cbgroups.Items.AddRange(new object[] {
            "GROUP A",
            "GROUP B"});
            this.cbgroups.Location = new System.Drawing.Point(121, 183);
            this.cbgroups.Name = "cbgroups";
            this.cbgroups.Size = new System.Drawing.Size(146, 21);
            this.cbgroups.TabIndex = 99;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(18, 186);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 13);
            this.label14.TabIndex = 98;
            this.label14.Text = "Groups";
            // 
            // chkRandomID
            // 
            this.chkRandomID.AutoSize = true;
            this.chkRandomID.Location = new System.Drawing.Point(167, 243);
            this.chkRandomID.Name = "chkRandomID";
            this.chkRandomID.Size = new System.Drawing.Size(80, 17);
            this.chkRandomID.TabIndex = 102;
            this.chkRandomID.Text = "Random ID";
            this.chkRandomID.UseVisualStyleBackColor = true;
            this.chkRandomID.CheckedChanged += new System.EventHandler(this.chkRandomID_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(16, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 101;
            this.label4.Text = "Ref ID";
            // 
            // txt_refID
            // 
            this.txt_refID.Location = new System.Drawing.Point(120, 219);
            this.txt_refID.Name = "txt_refID";
            this.txt_refID.Size = new System.Drawing.Size(159, 20);
            this.txt_refID.TabIndex = 100;
            // 
            // FrmTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 330);
            this.Controls.Add(this.chkRandomID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_refID);
            this.Controls.Add(this.cbgroups);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtCountry);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.cbName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TxtPrefix);
            this.Controls.Add(this.lbPrefix);
            this.Controls.Add(this.TxtName);
            this.Controls.Add(this.lbGroundName);
            this.Name = "FrmTeam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmTeam";
            this.Load += new System.EventHandler(this.FrmTeam_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtPrefix;
        private System.Windows.Forms.Label lbPrefix;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.Label lbGroundName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.ComboBox cbgroups;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox chkRandomID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_refID;

    }
}