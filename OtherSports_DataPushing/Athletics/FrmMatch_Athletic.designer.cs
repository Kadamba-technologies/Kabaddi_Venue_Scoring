namespace OtherSports_DataPushing
{
    partial class FrmMatch_Athletic
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
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lbDOB = new System.Windows.Forms.Label();
            this.cbVenue = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpMatchDate = new System.Windows.Forms.DateTimePicker();
            this.cbName = new System.Windows.Forms.ComboBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblMatchID = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbMatchType = new System.Windows.Forms.ComboBox();
            this.btnLineup = new System.Windows.Forms.Button();
            this.cbRoundType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbEventMaster = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(162, 291);
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
            this.btnClear.Location = new System.Drawing.Point(425, 291);
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
            this.label1.Location = new System.Drawing.Point(266, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 25);
            this.label1.TabIndex = 70;
            this.label1.Text = "Match Creation";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(250, 291);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(84, 29);
            this.btnSubmit.TabIndex = 69;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lbDOB
            // 
            this.lbDOB.AutoSize = true;
            this.lbDOB.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDOB.ForeColor = System.Drawing.Color.Black;
            this.lbDOB.Location = new System.Drawing.Point(343, 178);
            this.lbDOB.Name = "lbDOB";
            this.lbDOB.Size = new System.Drawing.Size(79, 13);
            this.lbDOB.TabIndex = 66;
            this.lbDOB.Text = "Match Date";
            // 
            // cbVenue
            // 
            this.cbVenue.FormattingEnabled = true;
            this.cbVenue.Location = new System.Drawing.Point(424, 210);
            this.cbVenue.Name = "cbVenue";
            this.cbVenue.Size = new System.Drawing.Size(182, 21);
            this.cbVenue.TabIndex = 79;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(343, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 78;
            this.label2.Text = "Venue";
            // 
            // dtpMatchDate
            // 
            this.dtpMatchDate.CustomFormat = "dd/MMMM/yyyy H:mm:ss";
            this.dtpMatchDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpMatchDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMatchDate.Location = new System.Drawing.Point(424, 176);
            this.dtpMatchDate.Name = "dtpMatchDate";
            this.dtpMatchDate.Size = new System.Drawing.Size(182, 21);
            this.dtpMatchDate.TabIndex = 84;
            this.dtpMatchDate.Value = new System.DateTime(2015, 10, 19, 15, 26, 11, 0);
            // 
            // cbName
            // 
            this.cbName.FormattingEnabled = true;
            this.cbName.Location = new System.Drawing.Point(245, 79);
            this.cbName.Name = "cbName";
            this.cbName.Size = new System.Drawing.Size(245, 21);
            this.cbName.TabIndex = 93;
            this.cbName.Visible = false;
            this.cbName.SelectedIndexChanged += new System.EventHandler(this.cbName_SelectedIndexChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(179, 83);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(60, 13);
            this.lblName.TabIndex = 92;
            this.lblName.Text = "Matches";
            this.lblName.Visible = false;
            // 
            // lblMatchID
            // 
            this.lblMatchID.AutoSize = true;
            this.lblMatchID.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatchID.ForeColor = System.Drawing.Color.Black;
            this.lblMatchID.Location = new System.Drawing.Point(636, 65);
            this.lblMatchID.Name = "lblMatchID";
            this.lblMatchID.Size = new System.Drawing.Size(22, 13);
            this.lblMatchID.TabIndex = 98;
            this.lblMatchID.Text = "ID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(563, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 101;
            this.label6.Text = "MatchID :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(49, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 96;
            this.label5.Text = "Match Type";
            // 
            // cbMatchType
            // 
            this.cbMatchType.FormattingEnabled = true;
            this.cbMatchType.Location = new System.Drawing.Point(133, 179);
            this.cbMatchType.Name = "cbMatchType";
            this.cbMatchType.Size = new System.Drawing.Size(182, 21);
            this.cbMatchType.TabIndex = 97;
            this.cbMatchType.SelectedIndexChanged += new System.EventHandler(this.cbMatchType_SelectedIndexChanged);
            // 
            // btnLineup
            // 
            this.btnLineup.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLineup.Location = new System.Drawing.Point(339, 291);
            this.btnLineup.Name = "btnLineup";
            this.btnLineup.Size = new System.Drawing.Size(84, 29);
            this.btnLineup.TabIndex = 69;
            this.btnLineup.Text = "Lineup";
            this.btnLineup.UseVisualStyleBackColor = true;
            this.btnLineup.Click += new System.EventHandler(this.btnLineup_Click);
            // 
            // cbRoundType
            // 
            this.cbRoundType.FormattingEnabled = true;
            this.cbRoundType.Location = new System.Drawing.Point(133, 215);
            this.cbRoundType.Name = "cbRoundType";
            this.cbRoundType.Size = new System.Drawing.Size(182, 21);
            this.cbRoundType.TabIndex = 103;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(49, 218);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 102;
            this.label7.Text = "Round Type";
            // 
            // cbEventMaster
            // 
            this.cbEventMaster.FormattingEnabled = true;
            this.cbEventMaster.Location = new System.Drawing.Point(245, 135);
            this.cbEventMaster.Name = "cbEventMaster";
            this.cbEventMaster.Size = new System.Drawing.Size(242, 21);
            this.cbEventMaster.TabIndex = 105;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(151, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 104;
            this.label8.Text = "Event Name";
            // 
            // FrmMatch_Athletic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 355);
            this.Controls.Add(this.cbEventMaster);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbRoundType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblMatchID);
            this.Controls.Add(this.cbMatchType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.dtpMatchDate);
            this.Controls.Add(this.cbVenue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLineup);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lbDOB);
            this.Name = "FrmMatch_Athletic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Matches";
            this.Load += new System.EventHandler(this.FrmMatches_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lbDOB;
        private System.Windows.Forms.ComboBox cbVenue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpMatchDate;
        private System.Windows.Forms.ComboBox cbName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblMatchID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbMatchType;
        private System.Windows.Forms.Button btnLineup;
        private System.Windows.Forms.ComboBox cbRoundType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbEventMaster;
        private System.Windows.Forms.Label label8;
    }
}