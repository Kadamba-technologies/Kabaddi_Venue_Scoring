namespace OtherSports_DataPushing
{
    partial class Frmtiebreaker
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.TxtSet1A = new System.Windows.Forms.TextBox();
            this.btnSet1ADes = new System.Windows.Forms.Button();
            this.btnSet1AInc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtSet1B = new System.Windows.Forms.TextBox();
            this.btnSet1BDes = new System.Windows.Forms.Button();
            this.btnSet1BInc = new System.Windows.Forms.Button();
            this.LblteamAName = new System.Windows.Forms.Label();
            this.LblteamBName = new System.Windows.Forms.Label();
            this.cbName = new System.Windows.Forms.ComboBox();
            this.lblName = new System.Windows.Forms.Label();
            this.cbCompetition = new System.Windows.Forms.ComboBox();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TxtRaidNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTeam = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbraider = new System.Windows.Forms.ComboBox();
            this.TxtRaidpoint = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Txtdefendpoint = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtBonuspoint = new System.Windows.Forms.TextBox();
            this.BtnSave_event = new System.Windows.Forms.Button();
            this.BtnRaidNo_asc = new System.Windows.Forms.Button();
            this.BtnRaidNo_dasc = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.MatchID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RaidNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Raiderid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Raider = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RaidPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Defendingpoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BonusPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.cbWintype = new System.Windows.Forms.ComboBox();
            this.chkFiveR = new System.Windows.Forms.CheckBox();
            this.chkGR = new System.Windows.Forms.CheckBox();
            this.BtnSave_btn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel1.Controls.Add(this.TxtSet1A);
            this.panel1.Controls.Add(this.btnSet1ADes);
            this.panel1.Controls.Add(this.btnSet1AInc);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(137, 144);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(366, 33);
            this.panel1.TabIndex = 74;
            // 
            // TxtSet1A
            // 
            this.TxtSet1A.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtSet1A.BackColor = System.Drawing.Color.Azure;
            this.TxtSet1A.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSet1A.Location = new System.Drawing.Point(247, 7);
            this.TxtSet1A.Name = "TxtSet1A";
            this.TxtSet1A.ReadOnly = true;
            this.TxtSet1A.Size = new System.Drawing.Size(61, 23);
            this.TxtSet1A.TabIndex = 68;
            this.TxtSet1A.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSet1ADes
            // 
            this.btnSet1ADes.BackColor = System.Drawing.Color.Red;
            this.btnSet1ADes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSet1ADes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSet1ADes.Location = new System.Drawing.Point(211, 7);
            this.btnSet1ADes.Name = "btnSet1ADes";
            this.btnSet1ADes.Size = new System.Drawing.Size(21, 23);
            this.btnSet1ADes.TabIndex = 67;
            this.btnSet1ADes.Text = "-";
            this.btnSet1ADes.UseVisualStyleBackColor = false;
            this.btnSet1ADes.Click += new System.EventHandler(this.btnSet1ADes_Click);
            // 
            // btnSet1AInc
            // 
            this.btnSet1AInc.BackColor = System.Drawing.Color.Red;
            this.btnSet1AInc.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSet1AInc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSet1AInc.Location = new System.Drawing.Point(316, 6);
            this.btnSet1AInc.Name = "btnSet1AInc";
            this.btnSet1AInc.Size = new System.Drawing.Size(21, 23);
            this.btnSet1AInc.TabIndex = 45;
            this.btnSet1AInc.Text = "+";
            this.btnSet1AInc.UseVisualStyleBackColor = false;
            this.btnSet1AInc.Click += new System.EventHandler(this.btnSet1AInc_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Blue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Aqua;
            this.label1.Location = new System.Drawing.Point(62, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 20);
            this.label1.TabIndex = 75;
            this.label1.Text = "T-A";
            // 
            // TxtSet1B
            // 
            this.TxtSet1B.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtSet1B.BackColor = System.Drawing.Color.Azure;
            this.TxtSet1B.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSet1B.Location = new System.Drawing.Point(249, 7);
            this.TxtSet1B.Name = "TxtSet1B";
            this.TxtSet1B.ReadOnly = true;
            this.TxtSet1B.Size = new System.Drawing.Size(61, 23);
            this.TxtSet1B.TabIndex = 24;
            this.TxtSet1B.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSet1BDes
            // 
            this.btnSet1BDes.BackColor = System.Drawing.Color.Red;
            this.btnSet1BDes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSet1BDes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSet1BDes.Location = new System.Drawing.Point(211, 7);
            this.btnSet1BDes.Name = "btnSet1BDes";
            this.btnSet1BDes.Size = new System.Drawing.Size(21, 23);
            this.btnSet1BDes.TabIndex = 58;
            this.btnSet1BDes.Text = "-";
            this.btnSet1BDes.UseVisualStyleBackColor = false;
            this.btnSet1BDes.Click += new System.EventHandler(this.btnSet1BDes_Click);
            // 
            // btnSet1BInc
            // 
            this.btnSet1BInc.BackColor = System.Drawing.Color.Red;
            this.btnSet1BInc.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSet1BInc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSet1BInc.Location = new System.Drawing.Point(316, 5);
            this.btnSet1BInc.Name = "btnSet1BInc";
            this.btnSet1BInc.Size = new System.Drawing.Size(21, 24);
            this.btnSet1BInc.TabIndex = 52;
            this.btnSet1BInc.Text = "+";
            this.btnSet1BInc.UseVisualStyleBackColor = false;
            this.btnSet1BInc.Click += new System.EventHandler(this.btnSet1BInc_Click);
            // 
            // LblteamAName
            // 
            this.LblteamAName.AutoSize = true;
            this.LblteamAName.BackColor = System.Drawing.Color.Blue;
            this.LblteamAName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblteamAName.ForeColor = System.Drawing.Color.Aqua;
            this.LblteamAName.Location = new System.Drawing.Point(-66, 95);
            this.LblteamAName.Name = "LblteamAName";
            this.LblteamAName.Size = new System.Drawing.Size(49, 25);
            this.LblteamAName.TabIndex = 73;
            this.LblteamAName.Text = "T-A";
            // 
            // LblteamBName
            // 
            this.LblteamBName.AutoSize = true;
            this.LblteamBName.BackColor = System.Drawing.Color.Blue;
            this.LblteamBName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblteamBName.ForeColor = System.Drawing.Color.Aqua;
            this.LblteamBName.Location = new System.Drawing.Point(62, 9);
            this.LblteamBName.Name = "LblteamBName";
            this.LblteamBName.Size = new System.Drawing.Size(37, 20);
            this.LblteamBName.TabIndex = 72;
            this.LblteamBName.Text = "T-B";
            // 
            // cbName
            // 
            this.cbName.FormattingEnabled = true;
            this.cbName.Location = new System.Drawing.Point(255, 90);
            this.cbName.Name = "cbName";
            this.cbName.Size = new System.Drawing.Size(245, 21);
            this.cbName.TabIndex = 97;
            this.cbName.SelectedIndexChanged += new System.EventHandler(this.cbName_SelectedIndexChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblName.Location = new System.Drawing.Point(162, 90);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(71, 17);
            this.lblName.TabIndex = 96;
            this.lblName.Text = "Matches";
            // 
            // cbCompetition
            // 
            this.cbCompetition.FormattingEnabled = true;
            this.cbCompetition.Location = new System.Drawing.Point(255, 53);
            this.cbCompetition.Name = "cbCompetition";
            this.cbCompetition.Size = new System.Drawing.Size(242, 21);
            this.cbCompetition.TabIndex = 95;
            this.cbCompetition.SelectedIndexChanged += new System.EventHandler(this.cbCompetition_SelectedIndexChanged);
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.AutoSize = true;
            this.lblPlayerName.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblPlayerName.Location = new System.Drawing.Point(131, 53);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(102, 17);
            this.lblPlayerName.TabIndex = 94;
            this.lblPlayerName.Text = "Competition";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel2.Controls.Add(this.btnSet1BDes);
            this.panel2.Controls.Add(this.TxtSet1B);
            this.panel2.Controls.Add(this.btnSet1BInc);
            this.panel2.Controls.Add(this.LblteamBName);
            this.panel2.Location = new System.Drawing.Point(137, 195);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(366, 33);
            this.panel2.TabIndex = 98;
            // 
            // TxtRaidNo
            // 
            this.TxtRaidNo.Location = new System.Drawing.Point(88, 12);
            this.TxtRaidNo.Name = "TxtRaidNo";
            this.TxtRaidNo.Size = new System.Drawing.Size(46, 20);
            this.TxtRaidNo.TabIndex = 99;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(3, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 17);
            this.label2.TabIndex = 100;
            this.label2.Text = "RaidNo";
            // 
            // cbTeam
            // 
            this.cbTeam.FormattingEnabled = true;
            this.cbTeam.Location = new System.Drawing.Point(219, 13);
            this.cbTeam.Name = "cbTeam";
            this.cbTeam.Size = new System.Drawing.Size(158, 21);
            this.cbTeam.TabIndex = 101;
            this.cbTeam.SelectedIndexChanged += new System.EventHandler(this.cbTeam_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(163, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 17);
            this.label3.TabIndex = 103;
            this.label3.Text = "Team";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label4.Location = new System.Drawing.Point(384, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 17);
            this.label4.TabIndex = 105;
            this.label4.Text = "Raider";
            // 
            // cbraider
            // 
            this.cbraider.FormattingEnabled = true;
            this.cbraider.Location = new System.Drawing.Point(448, 11);
            this.cbraider.Name = "cbraider";
            this.cbraider.Size = new System.Drawing.Size(157, 21);
            this.cbraider.TabIndex = 104;
            // 
            // TxtRaidpoint
            // 
            this.TxtRaidpoint.Location = new System.Drawing.Point(121, 47);
            this.TxtRaidpoint.Name = "TxtRaidpoint";
            this.TxtRaidpoint.Size = new System.Drawing.Size(62, 20);
            this.TxtRaidpoint.TabIndex = 106;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label5.Location = new System.Drawing.Point(4, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 17);
            this.label5.TabIndex = 107;
            this.label5.Text = "Raiding Point";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label6.Location = new System.Drawing.Point(189, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 17);
            this.label6.TabIndex = 109;
            this.label6.Text = "Defending Point";
            // 
            // Txtdefendpoint
            // 
            this.Txtdefendpoint.Location = new System.Drawing.Point(327, 49);
            this.Txtdefendpoint.Name = "Txtdefendpoint";
            this.Txtdefendpoint.Size = new System.Drawing.Size(67, 20);
            this.Txtdefendpoint.TabIndex = 108;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label7.Location = new System.Drawing.Point(426, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 17);
            this.label7.TabIndex = 111;
            this.label7.Text = "Bonus Point";
            // 
            // TxtBonuspoint
            // 
            this.TxtBonuspoint.Location = new System.Drawing.Point(534, 46);
            this.TxtBonuspoint.Name = "TxtBonuspoint";
            this.TxtBonuspoint.Size = new System.Drawing.Size(63, 20);
            this.TxtBonuspoint.TabIndex = 110;
            // 
            // BtnSave_event
            // 
            this.BtnSave_event.BackColor = System.Drawing.Color.OrangeRed;
            this.BtnSave_event.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave_event.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnSave_event.Location = new System.Drawing.Point(246, 74);
            this.BtnSave_event.Name = "BtnSave_event";
            this.BtnSave_event.Size = new System.Drawing.Size(75, 23);
            this.BtnSave_event.TabIndex = 112;
            this.BtnSave_event.Text = "SAVE";
            this.BtnSave_event.UseVisualStyleBackColor = false;
            this.BtnSave_event.Click += new System.EventHandler(this.BtnSave_event_Click);
            // 
            // BtnRaidNo_asc
            // 
            this.BtnRaidNo_asc.BackColor = System.Drawing.Color.Red;
            this.BtnRaidNo_asc.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnRaidNo_asc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRaidNo_asc.Location = new System.Drawing.Point(137, 13);
            this.BtnRaidNo_asc.Name = "BtnRaidNo_asc";
            this.BtnRaidNo_asc.Size = new System.Drawing.Size(21, 21);
            this.BtnRaidNo_asc.TabIndex = 76;
            this.BtnRaidNo_asc.Text = "+";
            this.BtnRaidNo_asc.UseVisualStyleBackColor = false;
            this.BtnRaidNo_asc.Click += new System.EventHandler(this.BtnRaidNo_asc_Click);
            // 
            // BtnRaidNo_dasc
            // 
            this.BtnRaidNo_dasc.BackColor = System.Drawing.Color.Red;
            this.BtnRaidNo_dasc.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnRaidNo_dasc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRaidNo_dasc.Location = new System.Drawing.Point(65, 12);
            this.BtnRaidNo_dasc.Name = "BtnRaidNo_dasc";
            this.BtnRaidNo_dasc.Size = new System.Drawing.Size(21, 22);
            this.BtnRaidNo_dasc.TabIndex = 113;
            this.BtnRaidNo_dasc.Text = "-";
            this.BtnRaidNo_dasc.UseVisualStyleBackColor = false;
            this.BtnRaidNo_dasc.Click += new System.EventHandler(this.BtnRaidNo_dasc_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel3.Controls.Add(this.cbTeam);
            this.panel3.Controls.Add(this.BtnSave_event);
            this.panel3.Controls.Add(this.BtnRaidNo_dasc);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.TxtRaidNo);
            this.panel3.Controls.Add(this.TxtBonuspoint);
            this.panel3.Controls.Add(this.BtnRaidNo_asc);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.Txtdefendpoint);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.TxtRaidpoint);
            this.panel3.Controls.Add(this.cbraider);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(24, 234);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(615, 100);
            this.panel3.TabIndex = 114;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MatchID,
            this.TeamId,
            this.RaidNo,
            this.Raiderid,
            this.Raider,
            this.RaidPoint,
            this.Defendingpoint,
            this.BonusPoint});
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dataGridView1.Location = new System.Drawing.Point(7, 337);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(643, 160);
            this.dataGridView1.TabIndex = 115;
            this.dataGridView1.Visible = false;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // MatchID
            // 
            this.MatchID.DataPropertyName = "Matchid";
            this.MatchID.HeaderText = "MatchID";
            this.MatchID.Name = "MatchID";
            // 
            // TeamId
            // 
            this.TeamId.DataPropertyName = "Teamid";
            this.TeamId.HeaderText = "TeamId";
            this.TeamId.Name = "TeamId";
            this.TeamId.Visible = false;
            // 
            // RaidNo
            // 
            this.RaidNo.DataPropertyName = "RaidNo";
            this.RaidNo.HeaderText = "RaidNo";
            this.RaidNo.Name = "RaidNo";
            // 
            // Raiderid
            // 
            this.Raiderid.DataPropertyName = "Raiderid";
            this.Raiderid.HeaderText = "Raiderid";
            this.Raiderid.Name = "Raiderid";
            this.Raiderid.Visible = false;
            // 
            // Raider
            // 
            this.Raider.DataPropertyName = "Raider";
            this.Raider.HeaderText = "Raider";
            this.Raider.Name = "Raider";
            // 
            // RaidPoint
            // 
            this.RaidPoint.DataPropertyName = "RaidingPoint";
            this.RaidPoint.HeaderText = "RaidPoint";
            this.RaidPoint.Name = "RaidPoint";
            // 
            // Defendingpoint
            // 
            this.Defendingpoint.DataPropertyName = "Defendingpoint";
            this.Defendingpoint.HeaderText = "Defendingpoint";
            this.Defendingpoint.Name = "Defendingpoint";
            // 
            // BonusPoint
            // 
            this.BonusPoint.DataPropertyName = "BonusPoint";
            this.BonusPoint.HeaderText = "BonusPoint";
            this.BonusPoint.Name = "BonusPoint";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label8.Location = new System.Drawing.Point(162, 124);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 17);
            this.label8.TabIndex = 116;
            this.label8.Text = "Win Type";
            // 
            // cbWintype
            // 
            this.cbWintype.FormattingEnabled = true;
            this.cbWintype.Items.AddRange(new object[] {
            "select",
            "Point",
            "Toss"});
            this.cbWintype.Location = new System.Drawing.Point(255, 120);
            this.cbWintype.Name = "cbWintype";
            this.cbWintype.Size = new System.Drawing.Size(132, 21);
            this.cbWintype.TabIndex = 117;
            // 
            // chkFiveR
            // 
            this.chkFiveR.AutoSize = true;
            this.chkFiveR.Checked = true;
            this.chkFiveR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFiveR.Location = new System.Drawing.Point(255, 13);
            this.chkFiveR.Name = "chkFiveR";
            this.chkFiveR.Size = new System.Drawing.Size(40, 17);
            this.chkFiveR.TabIndex = 118;
            this.chkFiveR.Text = "5R";
            this.chkFiveR.UseVisualStyleBackColor = true;
            this.chkFiveR.CheckedChanged += new System.EventHandler(this.chkFiveR_CheckedChanged);
            // 
            // chkGR
            // 
            this.chkGR.AutoSize = true;
            this.chkGR.Location = new System.Drawing.Point(345, 13);
            this.chkGR.Name = "chkGR";
            this.chkGR.Size = new System.Drawing.Size(42, 17);
            this.chkGR.TabIndex = 119;
            this.chkGR.Text = "GR";
            this.chkGR.UseVisualStyleBackColor = true;
            this.chkGR.CheckedChanged += new System.EventHandler(this.chkGR_CheckedChanged);
            // 
            // BtnSave_btn
            // 
            this.BtnSave_btn.BackColor = System.Drawing.Color.OrangeRed;
            this.BtnSave_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnSave_btn.Location = new System.Drawing.Point(393, 118);
            this.BtnSave_btn.Name = "BtnSave_btn";
            this.BtnSave_btn.Size = new System.Drawing.Size(75, 23);
            this.BtnSave_btn.TabIndex = 120;
            this.BtnSave_btn.Text = "SAVE";
            this.BtnSave_btn.UseVisualStyleBackColor = false;
            this.BtnSave_btn.Click += new System.EventHandler(this.BtnSave_btn_Click);
            // 
            // Frmtiebreaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(654, 500);
            this.Controls.Add(this.BtnSave_btn);
            this.Controls.Add(this.chkGR);
            this.Controls.Add(this.chkFiveR);
            this.Controls.Add(this.cbWintype);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cbName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.cbCompetition);
            this.Controls.Add(this.lblPlayerName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblteamAName);
            this.Name = "Frmtiebreaker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frmtiebreaker";
            this.Load += new System.EventHandler(this.Frmtiebreaker_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSet1ADes;
        private System.Windows.Forms.Button btnSet1AInc;
        private System.Windows.Forms.TextBox TxtSet1B;
        private System.Windows.Forms.Button btnSet1BDes;
        private System.Windows.Forms.Button btnSet1BInc;
        private System.Windows.Forms.Label LblteamAName;
        private System.Windows.Forms.Label LblteamBName;
        private System.Windows.Forms.TextBox TxtSet1A;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ComboBox cbCompetition;
        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox TxtRaidNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTeam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbraider;
        private System.Windows.Forms.TextBox TxtRaidpoint;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Txtdefendpoint;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtBonuspoint;
        private System.Windows.Forms.Button BtnSave_event;
        private System.Windows.Forms.Button BtnRaidNo_asc;
        private System.Windows.Forms.Button BtnRaidNo_dasc;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbWintype;
        private System.Windows.Forms.CheckBox chkFiveR;
        private System.Windows.Forms.CheckBox chkGR;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatchID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeamId;
        private System.Windows.Forms.DataGridViewTextBoxColumn RaidNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Raiderid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Raider;
        private System.Windows.Forms.DataGridViewTextBoxColumn RaidPoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn Defendingpoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn BonusPoint;
        private System.Windows.Forms.Button BtnSave_btn;
    }
}