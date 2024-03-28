namespace OtherSports_DataPushing
{
    partial class FrmMatches
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbCompetition = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbVenue = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbMatchtype = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbTeamA = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbTeamB = new System.Windows.Forms.ComboBox();
            this.btnsubmit = new System.Windows.Forms.Button();
            this.btnclear = new System.Windows.Forms.Button();
            this.dtpMatchDate = new System.Windows.Forms.DateTimePicker();
            this.lbDOB = new System.Windows.Forms.Label();
            this.gbmatchtype = new System.Windows.Forms.GroupBox();
            this.rbDoubles = new System.Windows.Forms.RadioButton();
            this.rbSingles = new System.Windows.Forms.RadioButton();
            this.btnLineup = new System.Windows.Forms.Button();
            this.gbmatchtype.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(251, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Match Creation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Competition";
            // 
            // cbCompetition
            // 
            this.cbCompetition.FormattingEnabled = true;
            this.cbCompetition.Location = new System.Drawing.Point(135, 51);
            this.cbCompetition.Name = "cbCompetition";
            this.cbCompetition.Size = new System.Drawing.Size(181, 21);
            this.cbCompetition.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(49, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Venue";
            // 
            // cbVenue
            // 
            this.cbVenue.FormattingEnabled = true;
            this.cbVenue.Location = new System.Drawing.Point(135, 99);
            this.cbVenue.Name = "cbVenue";
            this.cbVenue.Size = new System.Drawing.Size(181, 21);
            this.cbVenue.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(46, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Match Type";
            // 
            // cbMatchtype
            // 
            this.cbMatchtype.FormattingEnabled = true;
            this.cbMatchtype.Location = new System.Drawing.Point(135, 148);
            this.cbMatchtype.Name = "cbMatchtype";
            this.cbMatchtype.Size = new System.Drawing.Size(181, 21);
            this.cbMatchtype.TabIndex = 6;
            this.cbMatchtype.SelectedIndexChanged += new System.EventHandler(this.cbMatchtype_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(368, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Team A";
            // 
            // cbTeamA
            // 
            this.cbTeamA.FormattingEnabled = true;
            this.cbTeamA.Location = new System.Drawing.Point(439, 51);
            this.cbTeamA.Name = "cbTeamA";
            this.cbTeamA.Size = new System.Drawing.Size(199, 21);
            this.cbTeamA.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(370, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Team B";
            // 
            // cbTeamB
            // 
            this.cbTeamB.FormattingEnabled = true;
            this.cbTeamB.Location = new System.Drawing.Point(439, 98);
            this.cbTeamB.Name = "cbTeamB";
            this.cbTeamB.Size = new System.Drawing.Size(199, 21);
            this.cbTeamB.TabIndex = 10;
            // 
            // btnsubmit
            // 
            this.btnsubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsubmit.Location = new System.Drawing.Point(230, 234);
            this.btnsubmit.Name = "btnsubmit";
            this.btnsubmit.Size = new System.Drawing.Size(75, 33);
            this.btnsubmit.TabIndex = 11;
            this.btnsubmit.Text = "Submit";
            this.btnsubmit.UseVisualStyleBackColor = true;
            this.btnsubmit.Click += new System.EventHandler(this.btnsubmit_Click);
            // 
            // btnclear
            // 
            this.btnclear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclear.Location = new System.Drawing.Point(425, 234);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(75, 33);
            this.btnclear.TabIndex = 11;
            this.btnclear.Text = "Clear";
            this.btnclear.UseVisualStyleBackColor = true;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // dtpMatchDate
            // 
            this.dtpMatchDate.CustomFormat = "dd/MMMM/yyyy H:mm:ss";
            this.dtpMatchDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpMatchDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMatchDate.Location = new System.Drawing.Point(439, 148);
            this.dtpMatchDate.Name = "dtpMatchDate";
            this.dtpMatchDate.Size = new System.Drawing.Size(199, 21);
            this.dtpMatchDate.TabIndex = 86;
            this.dtpMatchDate.Value = new System.DateTime(2015, 10, 19, 15, 26, 11, 0);
            // 
            // lbDOB
            // 
            this.lbDOB.AutoSize = true;
            this.lbDOB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDOB.ForeColor = System.Drawing.Color.Black;
            this.lbDOB.Location = new System.Drawing.Point(353, 151);
            this.lbDOB.Name = "lbDOB";
            this.lbDOB.Size = new System.Drawing.Size(76, 16);
            this.lbDOB.TabIndex = 85;
            this.lbDOB.Text = "Match Date";
            // 
            // gbmatchtype
            // 
            this.gbmatchtype.Controls.Add(this.rbDoubles);
            this.gbmatchtype.Controls.Add(this.rbSingles);
            this.gbmatchtype.Location = new System.Drawing.Point(49, 183);
            this.gbmatchtype.Name = "gbmatchtype";
            this.gbmatchtype.Size = new System.Drawing.Size(267, 39);
            this.gbmatchtype.TabIndex = 87;
            this.gbmatchtype.TabStop = false;
            // 
            // rbDoubles
            // 
            this.rbDoubles.AutoSize = true;
            this.rbDoubles.Location = new System.Drawing.Point(176, 14);
            this.rbDoubles.Name = "rbDoubles";
            this.rbDoubles.Size = new System.Drawing.Size(64, 17);
            this.rbDoubles.TabIndex = 0;
            this.rbDoubles.TabStop = true;
            this.rbDoubles.Text = "Doubles";
            this.rbDoubles.UseVisualStyleBackColor = true;
            // 
            // rbSingles
            // 
            this.rbSingles.AutoSize = true;
            this.rbSingles.Location = new System.Drawing.Point(24, 14);
            this.rbSingles.Name = "rbSingles";
            this.rbSingles.Size = new System.Drawing.Size(59, 17);
            this.rbSingles.TabIndex = 0;
            this.rbSingles.TabStop = true;
            this.rbSingles.Text = "Singles";
            this.rbSingles.UseVisualStyleBackColor = true;
            // 
            // btnLineup
            // 
            this.btnLineup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLineup.Location = new System.Drawing.Point(329, 234);
            this.btnLineup.Name = "btnLineup";
            this.btnLineup.Size = new System.Drawing.Size(75, 33);
            this.btnLineup.TabIndex = 88;
            this.btnLineup.Text = "Lineup";
            this.btnLineup.UseVisualStyleBackColor = true;
            this.btnLineup.Click += new System.EventHandler(this.btnLineup_Click);
            // 
            // FrmMatches
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 278);
            this.Controls.Add(this.btnLineup);
            this.Controls.Add(this.gbmatchtype);
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
            this.Name = "FrmMatches";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMatches";
            this.Load += new System.EventHandler(this.FrmMatches_Load);
            this.gbmatchtype.ResumeLayout(false);
            this.gbmatchtype.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbCompetition;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbVenue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbMatchtype;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbTeamA;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbTeamB;
        private System.Windows.Forms.Button btnsubmit;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.DateTimePicker dtpMatchDate;
        private System.Windows.Forms.Label lbDOB;
        private System.Windows.Forms.GroupBox gbmatchtype;
        private System.Windows.Forms.RadioButton rbDoubles;
        private System.Windows.Forms.RadioButton rbSingles;
        private System.Windows.Forms.Button btnLineup;
    }
}