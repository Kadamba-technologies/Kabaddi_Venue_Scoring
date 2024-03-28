namespace OtherSports_DataPushing
{
    partial class FrmMasterPlayer
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
            this.DTPDOB = new System.Windows.Forms.DateTimePicker();
            this.TxtLastName = new System.Windows.Forms.TextBox();
            this.TxtFirstName = new System.Windows.Forms.TextBox();
            this.lbDOB = new System.Windows.Forms.Label();
            this.lbLastName = new System.Windows.Forms.Label();
            this.lbFirstName = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.lblPlayerID = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbtnMen = new System.Windows.Forms.RadioButton();
            this.rbtnWomen = new System.Windows.Forms.RadioButton();
            this.lblGender = new System.Windows.Forms.Label();
            this.cbPlayerName = new System.Windows.Forms.ComboBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.cbTeamName = new System.Windows.Forms.ComboBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtPickNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_refID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbCompetition = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkRandomID = new System.Windows.Forms.CheckBox();
            this.txtmarshal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbRole = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chkDOBNull = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNickName = new System.Windows.Forms.TextBox();
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.TxtID = new System.Windows.Forms.TextBox();
            this.txtBroadcastName = new System.Windows.Forms.TextBox();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DTPDOB
            // 
            this.DTPDOB.CustomFormat = "MM/dd/yyyy";
            this.DTPDOB.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPDOB.Location = new System.Drawing.Point(177, 231);
            this.DTPDOB.Name = "DTPDOB";
            this.DTPDOB.Size = new System.Drawing.Size(144, 20);
            this.DTPDOB.TabIndex = 42;
            this.DTPDOB.ValueChanged += new System.EventHandler(this.DTPDOB_ValueChanged);
            // 
            // TxtLastName
            // 
            this.TxtLastName.Location = new System.Drawing.Point(176, 167);
            this.TxtLastName.Name = "TxtLastName";
            this.TxtLastName.Size = new System.Drawing.Size(159, 20);
            this.TxtLastName.TabIndex = 38;
            this.TxtLastName.TextChanged += new System.EventHandler(this.TxtLastName_TextChanged);
            // 
            // TxtFirstName
            // 
            this.TxtFirstName.Location = new System.Drawing.Point(176, 100);
            this.TxtFirstName.Name = "TxtFirstName";
            this.TxtFirstName.Size = new System.Drawing.Size(159, 20);
            this.TxtFirstName.TabIndex = 35;
            this.TxtFirstName.TextChanged += new System.EventHandler(this.TxtFirstName_TextChanged);
            // 
            // lbDOB
            // 
            this.lbDOB.AutoSize = true;
            this.lbDOB.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDOB.ForeColor = System.Drawing.Color.Black;
            this.lbDOB.Location = new System.Drawing.Point(73, 236);
            this.lbDOB.Name = "lbDOB";
            this.lbDOB.Size = new System.Drawing.Size(33, 13);
            this.lbDOB.TabIndex = 44;
            this.lbDOB.Text = "DOB";
            // 
            // lbLastName
            // 
            this.lbLastName.AutoSize = true;
            this.lbLastName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLastName.ForeColor = System.Drawing.Color.Black;
            this.lbLastName.Location = new System.Drawing.Point(72, 170);
            this.lbLastName.Name = "lbLastName";
            this.lbLastName.Size = new System.Drawing.Size(75, 13);
            this.lbLastName.TabIndex = 41;
            this.lbLastName.Text = "Last Name";
            // 
            // lbFirstName
            // 
            this.lbFirstName.AutoSize = true;
            this.lbFirstName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFirstName.ForeColor = System.Drawing.Color.Black;
            this.lbFirstName.Location = new System.Drawing.Point(73, 103);
            this.lbFirstName.Name = "lbFirstName";
            this.lbFirstName.Size = new System.Drawing.Size(78, 13);
            this.lbFirstName.TabIndex = 37;
            this.lbFirstName.Text = "First Name";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(286, 393);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(84, 29);
            this.btnSubmit.TabIndex = 47;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(256, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 25);
            this.label1.TabIndex = 48;
            this.label1.Text = "Player Master";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(376, 393);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(84, 29);
            this.btnClear.TabIndex = 49;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.AutoSize = true;
            this.lblPlayerName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerName.ForeColor = System.Drawing.Color.Black;
            this.lblPlayerName.Location = new System.Drawing.Point(73, 64);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(90, 13);
            this.lblPlayerName.TabIndex = 52;
            this.lblPlayerName.Text = "Player Name";
            this.lblPlayerName.Visible = false;
            // 
            // lblPlayerID
            // 
            this.lblPlayerID.AutoSize = true;
            this.lblPlayerID.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerID.ForeColor = System.Drawing.Color.Black;
            this.lblPlayerID.Location = new System.Drawing.Point(654, 9);
            this.lblPlayerID.Name = "lblPlayerID";
            this.lblPlayerID.Size = new System.Drawing.Size(22, 13);
            this.lblPlayerID.TabIndex = 53;
            this.lblPlayerID.Text = "ID";
            this.lblPlayerID.Visible = false;
            this.lblPlayerID.Click += new System.EventHandler(this.lblPlayerID_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbtnMen);
            this.groupBox4.Controls.Add(this.rbtnWomen);
            this.groupBox4.ForeColor = System.Drawing.Color.Black;
            this.groupBox4.Location = new System.Drawing.Point(176, 268);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(147, 31);
            this.groupBox4.TabIndex = 54;
            this.groupBox4.TabStop = false;
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // rbtnMen
            // 
            this.rbtnMen.AutoSize = true;
            this.rbtnMen.Checked = true;
            this.rbtnMen.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnMen.ForeColor = System.Drawing.Color.Black;
            this.rbtnMen.Location = new System.Drawing.Point(10, 10);
            this.rbtnMen.Name = "rbtnMen";
            this.rbtnMen.Size = new System.Drawing.Size(51, 17);
            this.rbtnMen.TabIndex = 37;
            this.rbtnMen.TabStop = true;
            this.rbtnMen.Text = "Men";
            this.rbtnMen.UseVisualStyleBackColor = true;
            // 
            // rbtnWomen
            // 
            this.rbtnWomen.AutoSize = true;
            this.rbtnWomen.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnWomen.ForeColor = System.Drawing.Color.Black;
            this.rbtnWomen.Location = new System.Drawing.Point(63, 10);
            this.rbtnWomen.Name = "rbtnWomen";
            this.rbtnWomen.Size = new System.Drawing.Size(73, 17);
            this.rbtnWomen.TabIndex = 38;
            this.rbtnWomen.TabStop = true;
            this.rbtnWomen.Text = "Women";
            this.rbtnWomen.UseVisualStyleBackColor = true;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.ForeColor = System.Drawing.Color.Black;
            this.lblGender.Location = new System.Drawing.Point(73, 281);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(54, 13);
            this.lblGender.TabIndex = 55;
            this.lblGender.Text = "Gender";
            // 
            // cbPlayerName
            // 
            this.cbPlayerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbPlayerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbPlayerName.FormattingEnabled = true;
            this.cbPlayerName.Location = new System.Drawing.Point(489, 5);
            this.cbPlayerName.Name = "cbPlayerName";
            this.cbPlayerName.Size = new System.Drawing.Size(159, 21);
            this.cbPlayerName.TabIndex = 56;
            this.cbPlayerName.Visible = false;
            this.cbPlayerName.TextChanged += new System.EventHandler(this.cbPlayerName_TextChanged);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(196, 393);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(84, 29);
            this.btnEdit.TabIndex = 50;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // cbTeamName
            // 
            this.cbTeamName.FormattingEnabled = true;
            this.cbTeamName.Location = new System.Drawing.Point(176, 198);
            this.cbTeamName.Name = "cbTeamName";
            this.cbTeamName.Size = new System.Drawing.Size(159, 21);
            this.cbTeamName.TabIndex = 81;
            this.cbTeamName.SelectedIndexChanged += new System.EventHandler(this.cbTeamName_SelectedIndexChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(72, 204);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(91, 13);
            this.lblName.TabIndex = 80;
            this.lblName.Text = "Team Names";
            // 
            // txtPickNo
            // 
            this.txtPickNo.Location = new System.Drawing.Point(176, 310);
            this.txtPickNo.Name = "txtPickNo";
            this.txtPickNo.Size = new System.Drawing.Size(159, 20);
            this.txtPickNo.TabIndex = 82;
            this.txtPickNo.Text = "0";
            this.txtPickNo.TextChanged += new System.EventHandler(this.txtPickNo_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(72, 313);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 83;
            this.label2.Text = "BIB No";
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.Location = new System.Drawing.Point(176, 133);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(159, 20);
            this.txtMiddleName.TabIndex = 84;
            this.txtMiddleName.TextChanged += new System.EventHandler(this.txtMiddleName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(73, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 85;
            this.label3.Text = "Middle Name";
            // 
            // txt_refID
            // 
            this.txt_refID.Location = new System.Drawing.Point(121, 71);
            this.txt_refID.Name = "txt_refID";
            this.txt_refID.Size = new System.Drawing.Size(159, 21);
            this.txt_refID.TabIndex = 86;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(17, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 87;
            this.label4.Text = "Ref ID";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBroadcastName);
            this.groupBox1.Controls.Add(this.cbCompetition);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.chkRandomID);
            this.groupBox1.Controls.Add(this.txtmarshal);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbRole);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_refID);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(342, 126);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 239);
            this.groupBox1.TabIndex = 88;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Broadcast Details";
            // 
            // cbCompetition
            // 
            this.cbCompetition.FormattingEnabled = true;
            this.cbCompetition.Location = new System.Drawing.Point(113, 36);
            this.cbCompetition.Name = "cbCompetition";
            this.cbCompetition.Size = new System.Drawing.Size(196, 21);
            this.cbCompetition.TabIndex = 91;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(17, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 90;
            this.label8.Text = "Competition";
            // 
            // chkRandomID
            // 
            this.chkRandomID.AutoSize = true;
            this.chkRandomID.Location = new System.Drawing.Point(168, 95);
            this.chkRandomID.Name = "chkRandomID";
            this.chkRandomID.Size = new System.Drawing.Size(97, 17);
            this.chkRandomID.TabIndex = 89;
            this.chkRandomID.Text = "Random ID";
            this.chkRandomID.UseVisualStyleBackColor = true;
            this.chkRandomID.CheckedChanged += new System.EventHandler(this.chkRandomID_CheckedChanged);
            // 
            // txtmarshal
            // 
            this.txtmarshal.Location = new System.Drawing.Point(121, 201);
            this.txtmarshal.Name = "txtmarshal";
            this.txtmarshal.Size = new System.Drawing.Size(159, 21);
            this.txtmarshal.TabIndex = 84;
            this.txtmarshal.TextChanged += new System.EventHandler(this.txtMiddleName_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(11, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 85;
            this.label6.Text = "BroadcastName";
            // 
            // cbRole
            // 
            this.cbRole.FormattingEnabled = true;
            this.cbRole.Location = new System.Drawing.Point(121, 163);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(159, 21);
            this.cbRole.TabIndex = 81;
            this.cbRole.SelectedIndexChanged += new System.EventHandler(this.cbTeamName_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(17, 209);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 13);
            this.label9.TabIndex = 80;
            this.label9.Text = "Marshal Id";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(17, 169);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 80;
            this.label7.Text = "Role";
            // 
            // chkDOBNull
            // 
            this.chkDOBNull.AutoSize = true;
            this.chkDOBNull.Checked = true;
            this.chkDOBNull.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDOBNull.Location = new System.Drawing.Point(229, 255);
            this.chkDOBNull.Name = "chkDOBNull";
            this.chkDOBNull.Size = new System.Drawing.Size(72, 17);
            this.chkDOBNull.TabIndex = 89;
            this.chkDOBNull.Text = "Allow Null";
            this.chkDOBNull.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(352, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Nick Name";
            // 
            // txtNickName
            // 
            this.txtNickName.Location = new System.Drawing.Point(455, 93);
            this.txtNickName.Name = "txtNickName";
            this.txtNickName.Size = new System.Drawing.Size(159, 20);
            this.txtNickName.TabIndex = 35;
            this.txtNickName.TextChanged += new System.EventHandler(this.TxtFirstName_TextChanged);
            // 
            // TxtSearch
            // 
            this.TxtSearch.Location = new System.Drawing.Point(169, 61);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(183, 20);
            this.TxtSearch.TabIndex = 104;
            this.TxtSearch.Visible = false;
            this.TxtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            this.TxtSearch.Leave += new System.EventHandler(this.TxtSearch_Leave);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(169, 82);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(183, 186);
            this.listBox1.TabIndex = 105;
            this.listBox1.Visible = false;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // TxtID
            // 
            this.TxtID.Enabled = false;
            this.TxtID.Location = new System.Drawing.Point(357, 61);
            this.TxtID.Name = "TxtID";
            this.TxtID.Size = new System.Drawing.Size(106, 20);
            this.TxtID.TabIndex = 106;
            this.TxtID.Visible = false;
            // 
            // txtBroadcastName
            // 
            this.txtBroadcastName.Location = new System.Drawing.Point(126, 122);
            this.txtBroadcastName.Name = "txtBroadcastName";
            this.txtBroadcastName.Size = new System.Drawing.Size(159, 21);
            this.txtBroadcastName.TabIndex = 92;
            // 
            // FrmMasterPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 434);
            this.Controls.Add(this.TxtID);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.TxtSearch);
            this.Controls.Add(this.chkDOBNull);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtMiddleName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPickNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbTeamName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.cbPlayerName);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.lblPlayerID);
            this.Controls.Add(this.lblPlayerName);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.DTPDOB);
            this.Controls.Add(this.TxtLastName);
            this.Controls.Add(this.txtNickName);
            this.Controls.Add(this.TxtFirstName);
            this.Controls.Add(this.lbDOB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbLastName);
            this.Controls.Add(this.lbFirstName);
            this.Name = "FrmMasterPlayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMasterPlayer";
            this.Load += new System.EventHandler(this.FrmMasterPlayer_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmMasterPlayer_MouseDown);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DTPDOB;
        private System.Windows.Forms.TextBox TxtLastName;
        private System.Windows.Forms.TextBox TxtFirstName;
        private System.Windows.Forms.Label lbDOB;
        private System.Windows.Forms.Label lbLastName;
        private System.Windows.Forms.Label lbFirstName;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.Label lblPlayerID;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbtnMen;
        private System.Windows.Forms.RadioButton rbtnWomen;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.ComboBox cbPlayerName;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ComboBox cbTeamName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtPickNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_refID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkRandomID;
        private System.Windows.Forms.ComboBox cbRole;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkDOBNull;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNickName;
        private System.Windows.Forms.ComboBox cbCompetition;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtmarshal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtSearch;
        private System.Windows.Forms.ListBox listBox1;
        public System.Windows.Forms.TextBox TxtID;
        private System.Windows.Forms.TextBox txtBroadcastName;
    }
}