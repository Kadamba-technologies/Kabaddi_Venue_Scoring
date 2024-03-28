namespace OtherSports_DataPushing.Kho_Kho
{
    partial class FrmKhoKho
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
            this.components = new System.ComponentModel.Container();
            this.lblmatchid = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label26 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTeamAScore = new System.Windows.Forms.Label();
            this.lblTeamANameGoal = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblTeamBScore = new System.Windows.Forms.Label();
            this.lblTeamBNameGoal = new System.Windows.Forms.Label();
            this.btnTimerReset = new System.Windows.Forms.Button();
            this.btnTimerStart = new System.Windows.Forms.Button();
            this.btnTimerUpdate = new System.Windows.Forms.Button();
            this.pnlTimer = new System.Windows.Forms.Panel();
            this.lblTurnNo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp_Clock = new System.Windows.Forms.DateTimePicker();
            this.lblhalfid = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblElapseTime = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblMatchTime = new System.Windows.Forms.Label();
            this.btnInnEnd = new System.Windows.Forms.Button();
            this.btnInnStart = new System.Windows.Forms.Button();
            this.gvdatagrid = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lstteamB = new System.Windows.Forms.ListBox();
            this.lstTeamA = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblteamAname = new System.Windows.Forms.Label();
            this.lblteamBname = new System.Windows.Forms.Label();
            this.btn_11 = new System.Windows.Forms.Button();
            this.btn_21 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chkallout = new System.Windows.Forms.CheckBox();
            this.btnswap = new System.Windows.Forms.Button();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.Timer_MatchClock = new System.Windows.Forms.Timer(this.components);
            this.btnMatchStart = new System.Windows.Forms.Button();
            this.btnMatchEnd = new System.Windows.Forms.Button();
            this.BtnTurnStart = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btninnsendundo = new System.Windows.Forms.Button();
            this.btnturnendundo = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel7.SuspendLayout();
            this.pnlTimer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvdatagrid)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblmatchid
            // 
            this.lblmatchid.AutoSize = true;
            this.lblmatchid.BackColor = System.Drawing.Color.Transparent;
            this.lblmatchid.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmatchid.Location = new System.Drawing.Point(135, 10);
            this.lblmatchid.Name = "lblmatchid";
            this.lblmatchid.Size = new System.Drawing.Size(25, 14);
            this.lblmatchid.TabIndex = 506;
            this.lblmatchid.Text = "No";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(76, 10);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(55, 14);
            this.label29.TabIndex = 505;
            this.label29.Text = "Match :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.Controls.Add(this.label26);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Location = new System.Drawing.Point(458, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(311, 123);
            this.panel1.TabIndex = 507;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.SystemColors.Info;
            this.label26.Location = new System.Drawing.Point(123, 11);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(69, 18);
            this.label26.TabIndex = 449;
            this.label26.Text = "POINTS";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblTeamAScore);
            this.panel2.Controls.Add(this.lblTeamANameGoal);
            this.panel2.Location = new System.Drawing.Point(-18, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(168, 59);
            this.panel2.TabIndex = 448;
            // 
            // lblTeamAScore
            // 
            this.lblTeamAScore.AutoSize = true;
            this.lblTeamAScore.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeamAScore.ForeColor = System.Drawing.SystemColors.Window;
            this.lblTeamAScore.Location = new System.Drawing.Point(86, 24);
            this.lblTeamAScore.Name = "lblTeamAScore";
            this.lblTeamAScore.Size = new System.Drawing.Size(66, 18);
            this.lblTeamAScore.TabIndex = 437;
            this.lblTeamAScore.Text = "AScore";
            this.lblTeamAScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTeamANameGoal
            // 
            this.lblTeamANameGoal.AutoSize = true;
            this.lblTeamANameGoal.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTeamANameGoal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeamANameGoal.ForeColor = System.Drawing.SystemColors.Window;
            this.lblTeamANameGoal.Location = new System.Drawing.Point(104, 0);
            this.lblTeamANameGoal.Name = "lblTeamANameGoal";
            this.lblTeamANameGoal.Size = new System.Drawing.Size(62, 16);
            this.lblTeamANameGoal.TabIndex = 434;
            this.lblTeamANameGoal.Text = "Team A";
            this.lblTeamANameGoal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Transparent;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.lblTeamBScore);
            this.panel7.Controls.Add(this.lblTeamBNameGoal);
            this.panel7.Location = new System.Drawing.Point(150, 40);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(171, 59);
            this.panel7.TabIndex = 447;
            // 
            // lblTeamBScore
            // 
            this.lblTeamBScore.AutoSize = true;
            this.lblTeamBScore.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeamBScore.ForeColor = System.Drawing.SystemColors.Window;
            this.lblTeamBScore.Location = new System.Drawing.Point(46, 24);
            this.lblTeamBScore.Name = "lblTeamBScore";
            this.lblTeamBScore.Size = new System.Drawing.Size(65, 18);
            this.lblTeamBScore.TabIndex = 436;
            this.lblTeamBScore.Text = "BScore";
            this.lblTeamBScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTeamBNameGoal
            // 
            this.lblTeamBNameGoal.AutoSize = true;
            this.lblTeamBNameGoal.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTeamBNameGoal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeamBNameGoal.ForeColor = System.Drawing.SystemColors.Window;
            this.lblTeamBNameGoal.Location = new System.Drawing.Point(0, 0);
            this.lblTeamBNameGoal.Name = "lblTeamBNameGoal";
            this.lblTeamBNameGoal.Size = new System.Drawing.Size(62, 16);
            this.lblTeamBNameGoal.TabIndex = 435;
            this.lblTeamBNameGoal.Text = "Team B";
            this.lblTeamBNameGoal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnTimerReset
            // 
            this.btnTimerReset.BackColor = System.Drawing.Color.DimGray;
            this.btnTimerReset.Font = new System.Drawing.Font("Verdana", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimerReset.ForeColor = System.Drawing.Color.White;
            this.btnTimerReset.Location = new System.Drawing.Point(273, 188);
            this.btnTimerReset.Name = "btnTimerReset";
            this.btnTimerReset.Size = new System.Drawing.Size(86, 51);
            this.btnTimerReset.TabIndex = 538;
            this.btnTimerReset.Text = "Timer Reset";
            this.btnTimerReset.UseVisualStyleBackColor = false;
            this.btnTimerReset.Click += new System.EventHandler(this.btnTimerReset_Click);
            // 
            // btnTimerStart
            // 
            this.btnTimerStart.BackColor = System.Drawing.Color.DimGray;
            this.btnTimerStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTimerStart.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimerStart.ForeColor = System.Drawing.Color.White;
            this.btnTimerStart.Location = new System.Drawing.Point(25, 188);
            this.btnTimerStart.Name = "btnTimerStart";
            this.btnTimerStart.Size = new System.Drawing.Size(122, 51);
            this.btnTimerStart.TabIndex = 537;
            this.btnTimerStart.Text = "Timer Start";
            this.btnTimerStart.UseVisualStyleBackColor = false;
            this.btnTimerStart.Click += new System.EventHandler(this.btnTimerOn_Click);
            // 
            // btnTimerUpdate
            // 
            this.btnTimerUpdate.BackColor = System.Drawing.Color.DimGray;
            this.btnTimerUpdate.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimerUpdate.ForeColor = System.Drawing.Color.White;
            this.btnTimerUpdate.Location = new System.Drawing.Point(149, 188);
            this.btnTimerUpdate.Name = "btnTimerUpdate";
            this.btnTimerUpdate.Size = new System.Drawing.Size(121, 51);
            this.btnTimerUpdate.TabIndex = 536;
            this.btnTimerUpdate.Text = "Timer Update";
            this.btnTimerUpdate.UseVisualStyleBackColor = false;
            this.btnTimerUpdate.Click += new System.EventHandler(this.btnTimerOff_Click);
            // 
            // pnlTimer
            // 
            this.pnlTimer.BackColor = System.Drawing.Color.LightSlateGray;
            this.pnlTimer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTimer.Controls.Add(this.lblTurnNo);
            this.pnlTimer.Controls.Add(this.label2);
            this.pnlTimer.Controls.Add(this.dtp_Clock);
            this.pnlTimer.Controls.Add(this.lblhalfid);
            this.pnlTimer.Controls.Add(this.label18);
            this.pnlTimer.Controls.Add(this.lblElapseTime);
            this.pnlTimer.Controls.Add(this.label17);
            this.pnlTimer.Controls.Add(this.label10);
            this.pnlTimer.Controls.Add(this.lblMatchTime);
            this.pnlTimer.Controls.Add(this.label29);
            this.pnlTimer.Controls.Add(this.lblmatchid);
            this.pnlTimer.Location = new System.Drawing.Point(25, 56);
            this.pnlTimer.Name = "pnlTimer";
            this.pnlTimer.Size = new System.Drawing.Size(237, 126);
            this.pnlTimer.TabIndex = 539;
            // 
            // lblTurnNo
            // 
            this.lblTurnNo.AutoSize = true;
            this.lblTurnNo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurnNo.ForeColor = System.Drawing.Color.Lavender;
            this.lblTurnNo.Location = new System.Drawing.Point(198, 32);
            this.lblTurnNo.Name = "lblTurnNo";
            this.lblTurnNo.Size = new System.Drawing.Size(23, 14);
            this.lblTurnNo.TabIndex = 560;
            this.lblTurnNo.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(136, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 14);
            this.label2.TabIndex = 559;
            this.label2.Text = "TURN  :";
            // 
            // dtp_Clock
            // 
            this.dtp_Clock.CustomFormat = "mm:ss";
            this.dtp_Clock.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Bold);
            this.dtp_Clock.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_Clock.Location = new System.Drawing.Point(50, 59);
            this.dtp_Clock.Name = "dtp_Clock";
            this.dtp_Clock.ShowUpDown = true;
            this.dtp_Clock.Size = new System.Drawing.Size(127, 53);
            this.dtp_Clock.TabIndex = 558;
            this.dtp_Clock.Value = new System.DateTime(2018, 1, 31, 12, 0, 0, 0);
            // 
            // lblhalfid
            // 
            this.lblhalfid.AutoSize = true;
            this.lblhalfid.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblhalfid.ForeColor = System.Drawing.Color.Lavender;
            this.lblhalfid.Location = new System.Drawing.Point(86, 32);
            this.lblhalfid.Name = "lblhalfid";
            this.lblhalfid.Size = new System.Drawing.Size(23, 14);
            this.lblhalfid.TabIndex = 9;
            this.lblhalfid.Text = "ID";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(2, 32);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(81, 14);
            this.label18.TabIndex = 8;
            this.label18.Text = "INNINGS  :";
            // 
            // lblElapseTime
            // 
            this.lblElapseTime.AutoSize = true;
            this.lblElapseTime.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblElapseTime.ForeColor = System.Drawing.Color.Lavender;
            this.lblElapseTime.Location = new System.Drawing.Point(145, 86);
            this.lblElapseTime.Name = "lblElapseTime";
            this.lblElapseTime.Size = new System.Drawing.Size(48, 14);
            this.lblElapseTime.TabIndex = 7;
            this.lblElapseTime.Text = "09:00";
            this.lblElapseTime.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(124, 67);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(94, 14);
            this.label17.TabIndex = 6;
            this.label17.Text = "Elapsed Time";
            this.label17.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(20, 67);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 14);
            this.label10.TabIndex = 5;
            this.label10.Text = "MatchTime";
            this.label10.Visible = false;
            // 
            // lblMatchTime
            // 
            this.lblMatchTime.AutoSize = true;
            this.lblMatchTime.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatchTime.ForeColor = System.Drawing.Color.Lavender;
            this.lblMatchTime.Location = new System.Drawing.Point(33, 86);
            this.lblMatchTime.Name = "lblMatchTime";
            this.lblMatchTime.Size = new System.Drawing.Size(48, 14);
            this.lblMatchTime.TabIndex = 4;
            this.lblMatchTime.Text = "00:00";
            this.lblMatchTime.Visible = false;
            // 
            // btnInnEnd
            // 
            this.btnInnEnd.BackColor = System.Drawing.Color.Firebrick;
            this.btnInnEnd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInnEnd.Enabled = false;
            this.btnInnEnd.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInnEnd.ForeColor = System.Drawing.Color.White;
            this.btnInnEnd.Location = new System.Drawing.Point(548, 345);
            this.btnInnEnd.Name = "btnInnEnd";
            this.btnInnEnd.Size = new System.Drawing.Size(125, 44);
            this.btnInnEnd.TabIndex = 541;
            this.btnInnEnd.Text = "Inns End";
            this.btnInnEnd.UseVisualStyleBackColor = false;
            this.btnInnEnd.Click += new System.EventHandler(this.btnInnEnd_Click);
            // 
            // btnInnStart
            // 
            this.btnInnStart.BackColor = System.Drawing.Color.LimeGreen;
            this.btnInnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInnStart.Enabled = false;
            this.btnInnStart.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInnStart.ForeColor = System.Drawing.Color.White;
            this.btnInnStart.Location = new System.Drawing.Point(547, 187);
            this.btnInnStart.Name = "btnInnStart";
            this.btnInnStart.Size = new System.Drawing.Size(125, 44);
            this.btnInnStart.TabIndex = 540;
            this.btnInnStart.Text = "Inns Start";
            this.btnInnStart.UseVisualStyleBackColor = false;
            this.btnInnStart.Click += new System.EventHandler(this.btnInnStart_Click);
            // 
            // gvdatagrid
            // 
            this.gvdatagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvdatagrid.ContextMenuStrip = this.contextMenuStrip1;
            this.gvdatagrid.Location = new System.Drawing.Point(5, 246);
            this.gvdatagrid.Name = "gvdatagrid";
            this.gvdatagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvdatagrid.Size = new System.Drawing.Size(537, 337);
            this.gvdatagrid.TabIndex = 542;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // lstteamB
            // 
            this.lstteamB.FormattingEnabled = true;
            this.lstteamB.Location = new System.Drawing.Point(957, 244);
            this.lstteamB.Name = "lstteamB";
            this.lstteamB.Size = new System.Drawing.Size(192, 342);
            this.lstteamB.TabIndex = 543;
            this.lstteamB.SelectedValueChanged += new System.EventHandler(this.lstteamB_SelectedValueChanged);
            // 
            // lstTeamA
            // 
            this.lstTeamA.FormattingEnabled = true;
            this.lstTeamA.Location = new System.Drawing.Point(765, 244);
            this.lstTeamA.Name = "lstTeamA";
            this.lstTeamA.Size = new System.Drawing.Size(186, 342);
            this.lstTeamA.TabIndex = 544;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(879, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 17);
            this.label6.TabIndex = 545;
            this.label6.Text = "Current Players List";
            // 
            // lblteamAname
            // 
            this.lblteamAname.AutoSize = true;
            this.lblteamAname.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblteamAname.Location = new System.Drawing.Point(871, 181);
            this.lblteamAname.Name = "lblteamAname";
            this.lblteamAname.Size = new System.Drawing.Size(46, 13);
            this.lblteamAname.TabIndex = 546;
            this.lblteamAname.Text = "TeamA";
            this.lblteamAname.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblteamBname
            // 
            this.lblteamBname.AutoSize = true;
            this.lblteamBname.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblteamBname.Location = new System.Drawing.Point(981, 179);
            this.lblteamBname.Name = "lblteamBname";
            this.lblteamBname.Size = new System.Drawing.Size(46, 13);
            this.lblteamBname.TabIndex = 547;
            this.lblteamBname.Text = "TeamB";
            this.lblteamBname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_11
            // 
            this.btn_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_11.Location = new System.Drawing.Point(390, 78);
            this.btn_11.Name = "btn_11";
            this.btn_11.Size = new System.Drawing.Size(50, 50);
            this.btn_11.TabIndex = 548;
            this.btn_11.Text = "+";
            this.btn_11.UseVisualStyleBackColor = true;
            this.btn_11.Click += new System.EventHandler(this.btn_Score_Click);
            // 
            // btn_21
            // 
            this.btn_21.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_21.Location = new System.Drawing.Point(786, 78);
            this.btn_21.Name = "btn_21";
            this.btn_21.Size = new System.Drawing.Size(50, 50);
            this.btn_21.TabIndex = 548;
            this.btn_21.Text = "+";
            this.btn_21.UseVisualStyleBackColor = true;
            this.btn_21.Click += new System.EventHandler(this.btn_Score_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1025, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 550;
            this.label3.Text = "Runner";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(835, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 551;
            this.label4.Text = "Chaser";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // chkallout
            // 
            this.chkallout.AutoSize = true;
            this.chkallout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkallout.Location = new System.Drawing.Point(855, 88);
            this.chkallout.Name = "chkallout";
            this.chkallout.Size = new System.Drawing.Size(76, 21);
            this.chkallout.TabIndex = 555;
            this.chkallout.Text = "All Out";
            this.chkallout.UseVisualStyleBackColor = true;
            // 
            // btnswap
            // 
            this.btnswap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnswap.Location = new System.Drawing.Point(935, 206);
            this.btnswap.Name = "btnswap";
            this.btnswap.Size = new System.Drawing.Size(36, 30);
            this.btnswap.TabIndex = 556;
            this.btnswap.Text = "< >";
            this.btnswap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnswap.UseVisualStyleBackColor = true;
            this.btnswap.Click += new System.EventHandler(this.btnswap_Click);
            // 
            // pnlGrid
            // 
            this.pnlGrid.Location = new System.Drawing.Point(1137, 53);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(200, 100);
            this.pnlGrid.TabIndex = 557;
            this.pnlGrid.Visible = false;
            // 
            // Timer_MatchClock
            // 
            this.Timer_MatchClock.Interval = 1000;
            this.Timer_MatchClock.Tick += new System.EventHandler(this.Timer_MatchClock_Tick);
            // 
            // btnMatchStart
            // 
            this.btnMatchStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMatchStart.Location = new System.Drawing.Point(20, 12);
            this.btnMatchStart.Name = "btnMatchStart";
            this.btnMatchStart.Size = new System.Drawing.Size(115, 38);
            this.btnMatchStart.TabIndex = 559;
            this.btnMatchStart.Text = "Match Start";
            this.btnMatchStart.UseVisualStyleBackColor = true;
            this.btnMatchStart.Click += new System.EventHandler(this.btnMatchStart_Click);
            // 
            // btnMatchEnd
            // 
            this.btnMatchEnd.Enabled = false;
            this.btnMatchEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMatchEnd.Location = new System.Drawing.Point(155, 11);
            this.btnMatchEnd.Name = "btnMatchEnd";
            this.btnMatchEnd.Size = new System.Drawing.Size(115, 38);
            this.btnMatchEnd.TabIndex = 558;
            this.btnMatchEnd.Text = "Match End";
            this.btnMatchEnd.UseVisualStyleBackColor = true;
            this.btnMatchEnd.Click += new System.EventHandler(this.btnMatchEnd_Click);
            // 
            // BtnTurnStart
            // 
            this.BtnTurnStart.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BtnTurnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnTurnStart.Enabled = false;
            this.BtnTurnStart.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnTurnStart.ForeColor = System.Drawing.Color.White;
            this.BtnTurnStart.Location = new System.Drawing.Point(549, 265);
            this.BtnTurnStart.Name = "BtnTurnStart";
            this.BtnTurnStart.Size = new System.Drawing.Size(125, 44);
            this.BtnTurnStart.TabIndex = 560;
            this.BtnTurnStart.Text = "Turn Start";
            this.BtnTurnStart.UseVisualStyleBackColor = false;
            this.BtnTurnStart.Click += new System.EventHandler(this.BtnTurnStart_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnReset.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.Transparent;
            this.btnReset.Location = new System.Drawing.Point(1050, 21);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(61, 49);
            this.btnReset.TabIndex = 561;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btninnsendundo
            // 
            this.btninnsendundo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btninnsendundo.Location = new System.Drawing.Point(686, 349);
            this.btninnsendundo.Name = "btninnsendundo";
            this.btninnsendundo.Size = new System.Drawing.Size(65, 34);
            this.btninnsendundo.TabIndex = 563;
            this.btninnsendundo.Text = "Undo";
            this.btninnsendundo.UseVisualStyleBackColor = true;
            this.btninnsendundo.Visible = false;
            this.btninnsendundo.Click += new System.EventHandler(this.btninnsendundo_Click);
            // 
            // btnturnendundo
            // 
            this.btnturnendundo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnturnendundo.Location = new System.Drawing.Point(686, 270);
            this.btnturnendundo.Name = "btnturnendundo";
            this.btnturnendundo.Size = new System.Drawing.Size(65, 34);
            this.btnturnendundo.TabIndex = 563;
            this.btnturnendundo.Text = "Undo";
            this.btnturnendundo.UseVisualStyleBackColor = true;
            this.btnturnendundo.Visible = false;
            this.btnturnendundo.Click += new System.EventHandler(this.btnturnendundo_Click);
            // 
            // FrmKhoKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 592);
            this.Controls.Add(this.btnturnendundo);
            this.Controls.Add(this.btninnsendundo);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.BtnTurnStart);
            this.Controls.Add(this.btnMatchStart);
            this.Controls.Add(this.btnMatchEnd);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.btnswap);
            this.Controls.Add(this.chkallout);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_21);
            this.Controls.Add(this.btn_11);
            this.Controls.Add(this.lblteamBname);
            this.Controls.Add(this.lblteamAname);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lstTeamA);
            this.Controls.Add(this.gvdatagrid);
            this.Controls.Add(this.btnInnEnd);
            this.Controls.Add(this.btnInnStart);
            this.Controls.Add(this.pnlTimer);
            this.Controls.Add(this.btnTimerReset);
            this.Controls.Add(this.btnTimerStart);
            this.Controls.Add(this.btnTimerUpdate);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lstteamB);
            this.Name = "FrmKhoKho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmKhoKho";
            this.Load += new System.EventHandler(this.FrmKhoKho_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.pnlTimer.ResumeLayout(false);
            this.pnlTimer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvdatagrid)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblmatchid;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTeamAScore;
        private System.Windows.Forms.Label lblTeamANameGoal;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lblTeamBScore;
        private System.Windows.Forms.Label lblTeamBNameGoal;
        private System.Windows.Forms.Button btnTimerReset;
        private System.Windows.Forms.Button btnTimerStart;
        private System.Windows.Forms.Button btnTimerUpdate;
        private System.Windows.Forms.Panel pnlTimer;
        private System.Windows.Forms.Label lblhalfid;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblElapseTime;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblMatchTime;
        private System.Windows.Forms.Button btnInnEnd;
        private System.Windows.Forms.Button btnInnStart;
        private System.Windows.Forms.DataGridView gvdatagrid;
        private System.Windows.Forms.ListBox lstteamB;
        private System.Windows.Forms.ListBox lstTeamA;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblteamAname;
        private System.Windows.Forms.Label lblteamBname;
        private System.Windows.Forms.Button btn_11;
        private System.Windows.Forms.Button btn_21;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox chkallout;
        private System.Windows.Forms.Button btnswap;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DateTimePicker dtp_Clock;
        private System.Windows.Forms.Timer Timer_MatchClock;
        private System.Windows.Forms.Button btnMatchStart;
        private System.Windows.Forms.Button btnMatchEnd;
        private System.Windows.Forms.Button BtnTurnStart;
        private System.Windows.Forms.Label lblTurnNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btninnsendundo;
        private System.Windows.Forms.Button btnturnendundo;
    }
}