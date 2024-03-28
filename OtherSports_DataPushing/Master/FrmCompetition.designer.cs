namespace OtherSports_DataPushing
{
    partial class FrmCompetition
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
            this.cbName = new System.Windows.Forms.ComboBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.DTPTo = new System.Windows.Forms.DateTimePicker();
            this.DTPFrom = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.lbGroundName = new System.Windows.Forms.Label();
            this.cbcompmatchtype = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rdmen = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdwomen = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbName
            // 
            this.cbName.FormattingEnabled = true;
            this.cbName.Location = new System.Drawing.Point(157, 78);
            this.cbName.Name = "cbName";
            this.cbName.Size = new System.Drawing.Size(159, 21);
            this.cbName.TabIndex = 77;
            this.cbName.Visible = false;
            this.cbName.SelectedIndexChanged += new System.EventHandler(this.cbName_SelectedIndexChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(25, 81);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(126, 13);
            this.lblName.TabIndex = 73;
            this.lblName.Text = "Competition Name";
            this.lblName.Visible = false;
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(37, 271);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(84, 29);
            this.btnEdit.TabIndex = 72;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(217, 271);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(84, 29);
            this.btnClear.TabIndex = 71;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(49, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 25);
            this.label1.TabIndex = 70;
            this.label1.Text = "Competition Master";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(127, 271);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(84, 29);
            this.btnSubmit.TabIndex = 69;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // DTPTo
            // 
            this.DTPTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPTo.Location = new System.Drawing.Point(164, 173);
            this.DTPTo.Name = "DTPTo";
            this.DTPTo.Size = new System.Drawing.Size(137, 20);
            this.DTPTo.TabIndex = 82;
            // 
            // DTPFrom
            // 
            this.DTPFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPFrom.Location = new System.Drawing.Point(164, 141);
            this.DTPFrom.Name = "DTPFrom";
            this.DTPFrom.Size = new System.Drawing.Size(137, 20);
            this.DTPFrom.TabIndex = 81;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(51, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 85;
            this.label3.Text = "ToDate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(51, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 84;
            this.label2.Text = "FromDate";
            // 
            // TxtName
            // 
            this.TxtName.Location = new System.Drawing.Point(164, 111);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(137, 20);
            this.TxtName.TabIndex = 79;
            // 
            // lbGroundName
            // 
            this.lbGroundName.AutoSize = true;
            this.lbGroundName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGroundName.ForeColor = System.Drawing.Color.Black;
            this.lbGroundName.Location = new System.Drawing.Point(51, 118);
            this.lbGroundName.Name = "lbGroundName";
            this.lbGroundName.Size = new System.Drawing.Size(44, 13);
            this.lbGroundName.TabIndex = 78;
            this.lbGroundName.Text = "Name";
            // 
            // cbcompmatchtype
            // 
            this.cbcompmatchtype.FormattingEnabled = true;
            this.cbcompmatchtype.Location = new System.Drawing.Point(164, 203);
            this.cbcompmatchtype.Name = "cbcompmatchtype";
            this.cbcompmatchtype.Size = new System.Drawing.Size(136, 21);
            this.cbcompmatchtype.TabIndex = 87;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(51, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 85;
            this.label4.Text = "Match Type";
            // 
            // rdmen
            // 
            this.rdmen.AutoSize = true;
            this.rdmen.Checked = true;
            this.rdmen.Location = new System.Drawing.Point(3, 10);
            this.rdmen.Name = "rdmen";
            this.rdmen.Size = new System.Drawing.Size(46, 17);
            this.rdmen.TabIndex = 88;
            this.rdmen.TabStop = true;
            this.rdmen.Text = "Men";
            this.rdmen.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdwomen);
            this.panel1.Controls.Add(this.rdmen);
            this.panel1.Location = new System.Drawing.Point(164, 230);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(136, 35);
            this.panel1.TabIndex = 89;
            // 
            // rdwomen
            // 
            this.rdwomen.AutoSize = true;
            this.rdwomen.Location = new System.Drawing.Point(62, 10);
            this.rdwomen.Name = "rdwomen";
            this.rdwomen.Size = new System.Drawing.Size(62, 17);
            this.rdwomen.TabIndex = 88;
            this.rdwomen.TabStop = true;
            this.rdwomen.Text = "Women";
            this.rdwomen.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(51, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 85;
            this.label5.Text = "Gender";
            // 
            // FrmCompetition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 334);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbcompmatchtype);
            this.Controls.Add(this.DTPTo);
            this.Controls.Add(this.DTPFrom);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtName);
            this.Controls.Add(this.lbGroundName);
            this.Controls.Add(this.cbName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSubmit);
            this.Name = "FrmCompetition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Competition";
            this.Load += new System.EventHandler(this.FrmCompetition_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.DateTimePicker DTPTo;
        private System.Windows.Forms.DateTimePicker DTPFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.Label lbGroundName;
        private System.Windows.Forms.ComboBox cbcompmatchtype;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdmen;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdwomen;
        private System.Windows.Forms.Label label5;
    }
}