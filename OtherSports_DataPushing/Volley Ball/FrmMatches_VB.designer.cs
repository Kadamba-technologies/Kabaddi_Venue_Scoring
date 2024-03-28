namespace OtherSports_DataPushing.Volley_Ball
{
    partial class FrmMatches_VB
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
            this.btnLineup = new System.Windows.Forms.Button();
            this.dtpMatchDate = new System.Windows.Forms.DateTimePicker();
            this.lbDOB = new System.Windows.Forms.Label();
            this.btnclear = new System.Windows.Forms.Button();
            this.btnsubmit = new System.Windows.Forms.Button();
            this.cbTeamB = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbTeamA = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbMatchtype = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbVenue = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbCompetition = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLineup
            // 
            this.btnLineup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLineup.Location = new System.Drawing.Point(269, 213);
            this.btnLineup.Name = "btnLineup";
            this.btnLineup.Size = new System.Drawing.Size(75, 33);
            this.btnLineup.TabIndex = 104;
            this.btnLineup.Text = "Lineup";
            this.btnLineup.UseVisualStyleBackColor = true;
            this.btnLineup.Click += new System.EventHandler(this.btnLineup_Click);
            // 
            // dtpMatchDate
            // 
            this.dtpMatchDate.CustomFormat = "dd/MMMM/yyyy H:mm:ss";
            this.dtpMatchDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpMatchDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMatchDate.Location = new System.Drawing.Point(407, 161);
            this.dtpMatchDate.Name = "dtpMatchDate";
            this.dtpMatchDate.Size = new System.Drawing.Size(199, 21);
            this.dtpMatchDate.TabIndex = 103;
            this.dtpMatchDate.Value = new System.DateTime(2015, 10, 19, 15, 26, 11, 0);
            // 
            // lbDOB
            // 
            this.lbDOB.AutoSize = true;
            this.lbDOB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDOB.ForeColor = System.Drawing.Color.Black;
            this.lbDOB.Location = new System.Drawing.Point(321, 164);
            this.lbDOB.Name = "lbDOB";
            this.lbDOB.Size = new System.Drawing.Size(76, 16);
            this.lbDOB.TabIndex = 102;
            this.lbDOB.Text = "Match Date";
            // 
            // btnclear
            // 
            this.btnclear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclear.Location = new System.Drawing.Point(365, 213);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(75, 33);
            this.btnclear.TabIndex = 100;
            this.btnclear.Text = "Clear";
            this.btnclear.UseVisualStyleBackColor = true;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // btnsubmit
            // 
            this.btnsubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsubmit.Location = new System.Drawing.Point(170, 213);
            this.btnsubmit.Name = "btnsubmit";
            this.btnsubmit.Size = new System.Drawing.Size(75, 33);
            this.btnsubmit.TabIndex = 101;
            this.btnsubmit.Text = "Submit";
            this.btnsubmit.UseVisualStyleBackColor = true;
            this.btnsubmit.Click += new System.EventHandler(this.btnsubmit_Click);
            // 
            // cbTeamB
            // 
            this.cbTeamB.FormattingEnabled = true;
            this.cbTeamB.Location = new System.Drawing.Point(407, 111);
            this.cbTeamB.Name = "cbTeamB";
            this.cbTeamB.Size = new System.Drawing.Size(199, 21);
            this.cbTeamB.TabIndex = 99;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(338, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 17);
            this.label6.TabIndex = 98;
            this.label6.Text = "Team B";
            // 
            // cbTeamA
            // 
            this.cbTeamA.FormattingEnabled = true;
            this.cbTeamA.Location = new System.Drawing.Point(407, 64);
            this.cbTeamA.Name = "cbTeamA";
            this.cbTeamA.Size = new System.Drawing.Size(199, 21);
            this.cbTeamA.TabIndex = 97;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(336, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 17);
            this.label5.TabIndex = 96;
            this.label5.Text = "Team A";
            // 
            // cbMatchtype
            // 
            this.cbMatchtype.FormattingEnabled = true;
            this.cbMatchtype.Location = new System.Drawing.Point(103, 161);
            this.cbMatchtype.Name = "cbMatchtype";
            this.cbMatchtype.Size = new System.Drawing.Size(181, 21);
            this.cbMatchtype.TabIndex = 95;
            this.cbMatchtype.SelectedIndexChanged += new System.EventHandler(this.cbMatchtype_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 17);
            this.label4.TabIndex = 94;
            this.label4.Text = "Match Type";
            // 
            // cbVenue
            // 
            this.cbVenue.FormattingEnabled = true;
            this.cbVenue.Location = new System.Drawing.Point(103, 112);
            this.cbVenue.Name = "cbVenue";
            this.cbVenue.Size = new System.Drawing.Size(181, 21);
            this.cbVenue.TabIndex = 93;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 92;
            this.label3.Text = "Venue";
            // 
            // cbCompetition
            // 
            this.cbCompetition.FormattingEnabled = true;
            this.cbCompetition.Location = new System.Drawing.Point(103, 64);
            this.cbCompetition.Name = "cbCompetition";
            this.cbCompetition.Size = new System.Drawing.Size(181, 21);
            this.cbCompetition.TabIndex = 91;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 90;
            this.label2.Text = "Competition";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(231, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 22);
            this.label1.TabIndex = 89;
            this.label1.Text = "Match Creation";
            // 
            // FrmMatches_VB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 327);
            this.Controls.Add(this.btnLineup);
            this.Controls.Add(this.dtpMatchDate);
            this.Controls.Add(this.lbDOB);
            this.Controls.Add(this.btnclear);
            this.Controls.Add(this.btnsubmit);
            this.Controls.Add(this.cbTeamB);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbTeamA);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbMatchtype);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbVenue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbCompetition);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmMatches_VB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMatches_VB";
            this.Load += new System.EventHandler(this.FrmMatches_VB_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLineup;
        private System.Windows.Forms.DateTimePicker dtpMatchDate;
        private System.Windows.Forms.Label lbDOB;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Button btnsubmit;
        private System.Windows.Forms.ComboBox cbTeamB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbTeamA;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbMatchtype;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbVenue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbCompetition;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}