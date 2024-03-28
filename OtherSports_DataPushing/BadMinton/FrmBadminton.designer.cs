namespace OtherSports_DataPushing
{
    partial class FrmBadminton
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnmatchendundo = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.PnlGrid = new System.Windows.Forms.Panel();
            this.btnpointswap = new System.Windows.Forms.Button();
            this.gvdatabind = new System.Windows.Forms.DataGridView();
            this.GameID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PointID1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WonID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Serid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WinnerID1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServerID1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamAPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamBPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMatchStart = new System.Windows.Forms.Button();
            this.btnGamestart = new System.Windows.Forms.Button();
            this.lblerror = new System.Windows.Forms.Label();
            this.btnMatchEnd = new System.Windows.Forms.Button();
            this.btngameend = new System.Windows.Forms.Button();
            this.btndec = new System.Windows.Forms.Button();
            this.btninc = new System.Windows.Forms.Button();
            this.lblmatchno = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnshot = new System.Windows.Forms.Button();
            this.txtRally = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tblscoreboard = new System.Windows.Forms.TableLayoutPanel();
            this.lblTname = new System.Windows.Forms.Label();
            this.lblTeam1name = new System.Windows.Forms.Label();
            this.lblTeam2name = new System.Windows.Forms.Label();
            this.lblset1 = new System.Windows.Forms.Label();
            this.lblset2 = new System.Windows.Forms.Label();
            this.lblset3 = new System.Windows.Forms.Label();
            this.txtset1t1 = new System.Windows.Forms.TextBox();
            this.txtset2t1 = new System.Windows.Forms.TextBox();
            this.txtset3t1 = new System.Windows.Forms.TextBox();
            this.txtset3t2 = new System.Windows.Forms.TextBox();
            this.txtset2t2 = new System.Windows.Forms.TextBox();
            this.txtset1t2 = new System.Windows.Forms.TextBox();
            this.pnlplayerdoubles = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDt2N = new System.Windows.Forms.Label();
            this.lblDt2P1 = new System.Windows.Forms.Label();
            this.btnDt2P1winner = new System.Windows.Forms.Button();
            this.lblDt2P2 = new System.Windows.Forms.Label();
            this.rbDt2 = new System.Windows.Forms.RadioButton();
            this.btnDt2P2winner = new System.Windows.Forms.Button();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDt1N = new System.Windows.Forms.Label();
            this.lblDt1P1 = new System.Windows.Forms.Label();
            this.btnDt1P1winner = new System.Windows.Forms.Button();
            this.lblDt1P2 = new System.Windows.Forms.Label();
            this.rbDt1 = new System.Windows.Forms.RadioButton();
            this.btnDt1P2winner = new System.Windows.Forms.Button();
            this.pnlplayersingles = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lblSt2N = new System.Windows.Forms.Label();
            this.lblSt2P = new System.Windows.Forms.Label();
            this.rbSt2 = new System.Windows.Forms.RadioButton();
            this.btnSt2winner = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblSt1N = new System.Windows.Forms.Label();
            this.lblSt1P = new System.Windows.Forms.Label();
            this.rbSt1 = new System.Windows.Forms.RadioButton();
            this.btnSt1winner = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvdatabind)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tblscoreboard.SuspendLayout();
            this.pnlplayerdoubles.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.pnlplayersingles.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.btnmatchendundo);
            this.pnlMain.Controls.Add(this.btnReset);
            this.pnlMain.Controls.Add(this.PnlGrid);
            this.pnlMain.Controls.Add(this.btnpointswap);
            this.pnlMain.Controls.Add(this.gvdatabind);
            this.pnlMain.Controls.Add(this.btnMatchStart);
            this.pnlMain.Controls.Add(this.btnGamestart);
            this.pnlMain.Controls.Add(this.lblerror);
            this.pnlMain.Controls.Add(this.btnMatchEnd);
            this.pnlMain.Controls.Add(this.btngameend);
            this.pnlMain.Controls.Add(this.btndec);
            this.pnlMain.Controls.Add(this.btninc);
            this.pnlMain.Controls.Add(this.lblmatchno);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.btnshot);
            this.pnlMain.Controls.Add(this.txtRally);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.tblscoreboard);
            this.pnlMain.Controls.Add(this.pnlplayerdoubles);
            this.pnlMain.Controls.Add(this.pnlplayersingles);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1276, 679);
            this.pnlMain.TabIndex = 0;
            // 
            // btnmatchendundo
            // 
            this.btnmatchendundo.Location = new System.Drawing.Point(266, 67);
            this.btnmatchendundo.Name = "btnmatchendundo";
            this.btnmatchendundo.Size = new System.Drawing.Size(46, 29);
            this.btnmatchendundo.TabIndex = 520;
            this.btnmatchendundo.Text = "Undo";
            this.btnmatchendundo.UseVisualStyleBackColor = true;
            this.btnmatchendundo.Click += new System.EventHandler(this.btnmatchendundo_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnReset.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.Transparent;
            this.btnReset.Location = new System.Drawing.Point(266, 352);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(61, 49);
            this.btnReset.TabIndex = 519;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // PnlGrid
            // 
            this.PnlGrid.Location = new System.Drawing.Point(930, 699);
            this.PnlGrid.Name = "PnlGrid";
            this.PnlGrid.Size = new System.Drawing.Size(200, 100);
            this.PnlGrid.TabIndex = 13;
            // 
            // btnpointswap
            // 
            this.btnpointswap.Enabled = false;
            this.btnpointswap.Location = new System.Drawing.Point(730, 376);
            this.btnpointswap.Name = "btnpointswap";
            this.btnpointswap.Size = new System.Drawing.Size(81, 23);
            this.btnpointswap.TabIndex = 12;
            this.btnpointswap.Text = "Point Change";
            this.btnpointswap.UseVisualStyleBackColor = true;
            this.btnpointswap.Click += new System.EventHandler(this.btnpointswap_Click);
            // 
            // gvdatabind
            // 
            this.gvdatabind.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvdatabind.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GameID,
            this.PointID1,
            this.WonID,
            this.Serid,
            this.WinnerID1,
            this.ServerID1,
            this.TeamAPoint,
            this.TeamBPoint});
            this.gvdatabind.ContextMenuStrip = this.contextMenuStrip1;
            this.gvdatabind.Location = new System.Drawing.Point(3, 402);
            this.gvdatabind.Name = "gvdatabind";
            this.gvdatabind.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvdatabind.Size = new System.Drawing.Size(807, 272);
            this.gvdatabind.TabIndex = 11;
            // 
            // GameID
            // 
            this.GameID.DataPropertyName = "GameID";
            this.GameID.HeaderText = "GameID";
            this.GameID.Name = "GameID";
            // 
            // PointID1
            // 
            this.PointID1.DataPropertyName = "PointID";
            this.PointID1.HeaderText = "PointID1";
            this.PointID1.Name = "PointID1";
            // 
            // WonID
            // 
            this.WonID.DataPropertyName = "WonID";
            this.WonID.HeaderText = "WonID";
            this.WonID.Name = "WonID";
            this.WonID.Visible = false;
            // 
            // Serid
            // 
            this.Serid.DataPropertyName = "Serid";
            this.Serid.HeaderText = "Serid";
            this.Serid.Name = "Serid";
            this.Serid.Visible = false;
            // 
            // WinnerID1
            // 
            this.WinnerID1.DataPropertyName = "WinnerID";
            this.WinnerID1.HeaderText = "Winner";
            this.WinnerID1.Name = "WinnerID1";
            // 
            // ServerID1
            // 
            this.ServerID1.DataPropertyName = "ServerID";
            this.ServerID1.HeaderText = "Server";
            this.ServerID1.Name = "ServerID1";
            // 
            // TeamAPoint
            // 
            this.TeamAPoint.DataPropertyName = "TeamAPoint";
            this.TeamAPoint.HeaderText = "TeamAPoint";
            this.TeamAPoint.Name = "TeamAPoint";
            // 
            // TeamBPoint
            // 
            this.TeamBPoint.DataPropertyName = "TeamBPoint";
            this.TeamBPoint.HeaderText = "TeamBPoint";
            this.TeamBPoint.Name = "TeamBPoint";
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
            // btnMatchStart
            // 
            this.btnMatchStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMatchStart.Location = new System.Drawing.Point(15, 6);
            this.btnMatchStart.Name = "btnMatchStart";
            this.btnMatchStart.Size = new System.Drawing.Size(115, 38);
            this.btnMatchStart.TabIndex = 10;
            this.btnMatchStart.Text = "Match Start";
            this.btnMatchStart.UseVisualStyleBackColor = true;
            this.btnMatchStart.Click += new System.EventHandler(this.btnMatchStart_Click);
            // 
            // btnGamestart
            // 
            this.btnGamestart.Enabled = false;
            this.btnGamestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGamestart.Location = new System.Drawing.Point(28, 224);
            this.btnGamestart.Name = "btnGamestart";
            this.btnGamestart.Size = new System.Drawing.Size(115, 38);
            this.btnGamestart.TabIndex = 10;
            this.btnGamestart.Text = "Game Start";
            this.btnGamestart.UseVisualStyleBackColor = true;
            this.btnGamestart.Click += new System.EventHandler(this.btnGamestart_Click);
            // 
            // lblerror
            // 
            this.lblerror.AutoSize = true;
            this.lblerror.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblerror.ForeColor = System.Drawing.Color.Red;
            this.lblerror.Location = new System.Drawing.Point(418, 375);
            this.lblerror.Name = "lblerror";
            this.lblerror.Size = new System.Drawing.Size(45, 17);
            this.lblerror.TabIndex = 9;
            this.lblerror.Text = "Error";
            this.lblerror.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblerror.Visible = false;
            // 
            // btnMatchEnd
            // 
            this.btnMatchEnd.Enabled = false;
            this.btnMatchEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMatchEnd.Location = new System.Drawing.Point(197, 6);
            this.btnMatchEnd.Name = "btnMatchEnd";
            this.btnMatchEnd.Size = new System.Drawing.Size(115, 38);
            this.btnMatchEnd.TabIndex = 8;
            this.btnMatchEnd.Text = "Match End";
            this.btnMatchEnd.UseVisualStyleBackColor = true;
            this.btnMatchEnd.Click += new System.EventHandler(this.btnMatchEnd_Click);
            // 
            // btngameend
            // 
            this.btngameend.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btngameend.Location = new System.Drawing.Point(178, 224);
            this.btngameend.Name = "btngameend";
            this.btngameend.Size = new System.Drawing.Size(115, 38);
            this.btngameend.TabIndex = 8;
            this.btngameend.Text = "Game End";
            this.btngameend.UseVisualStyleBackColor = true;
            this.btngameend.Click += new System.EventHandler(this.btngameend_Click);
            // 
            // btndec
            // 
            this.btndec.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndec.Location = new System.Drawing.Point(61, 304);
            this.btndec.Name = "btndec";
            this.btndec.Size = new System.Drawing.Size(35, 33);
            this.btndec.TabIndex = 7;
            this.btndec.Text = "-";
            this.btndec.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btndec.UseVisualStyleBackColor = true;
            this.btndec.Click += new System.EventHandler(this.btnshot_Click);
            // 
            // btninc
            // 
            this.btninc.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btninc.Location = new System.Drawing.Point(215, 303);
            this.btninc.Name = "btninc";
            this.btninc.Size = new System.Drawing.Size(35, 33);
            this.btninc.TabIndex = 7;
            this.btninc.Text = "+";
            this.btninc.UseVisualStyleBackColor = true;
            this.btninc.Click += new System.EventHandler(this.btnshot_Click);
            // 
            // lblmatchno
            // 
            this.lblmatchno.AutoSize = true;
            this.lblmatchno.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmatchno.Location = new System.Drawing.Point(144, 67);
            this.lblmatchno.Name = "lblmatchno";
            this.lblmatchno.Size = new System.Drawing.Size(18, 20);
            this.lblmatchno.TabIndex = 6;
            this.lblmatchno.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(45, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Match No:";
            // 
            // btnshot
            // 
            this.btnshot.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnshot.Location = new System.Drawing.Point(100, 353);
            this.btnshot.Name = "btnshot";
            this.btnshot.Size = new System.Drawing.Size(110, 45);
            this.btnshot.TabIndex = 4;
            this.btnshot.Text = "Shot";
            this.btnshot.UseVisualStyleBackColor = true;
            this.btnshot.Click += new System.EventHandler(this.btnshot_Click);
            // 
            // txtRally
            // 
            this.txtRally.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRally.Location = new System.Drawing.Point(114, 298);
            this.txtRally.Multiline = true;
            this.txtRally.Name = "txtRally";
            this.txtRally.Size = new System.Drawing.Size(83, 45);
            this.txtRally.TabIndex = 3;
            this.txtRally.Text = "0";
            this.txtRally.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRally.TextChanged += new System.EventHandler(this.txtRally_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(100, 266);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Rally Count";
            // 
            // tblscoreboard
            // 
            this.tblscoreboard.BackColor = System.Drawing.Color.Gray;
            this.tblscoreboard.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tblscoreboard.ColumnCount = 4;
            this.tblscoreboard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblscoreboard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tblscoreboard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tblscoreboard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tblscoreboard.Controls.Add(this.lblTname, 0, 0);
            this.tblscoreboard.Controls.Add(this.lblTeam1name, 0, 1);
            this.tblscoreboard.Controls.Add(this.lblTeam2name, 0, 2);
            this.tblscoreboard.Controls.Add(this.lblset1, 1, 0);
            this.tblscoreboard.Controls.Add(this.lblset2, 2, 0);
            this.tblscoreboard.Controls.Add(this.lblset3, 3, 0);
            this.tblscoreboard.Controls.Add(this.txtset1t1, 1, 1);
            this.tblscoreboard.Controls.Add(this.txtset2t1, 2, 1);
            this.tblscoreboard.Controls.Add(this.txtset3t1, 3, 1);
            this.tblscoreboard.Controls.Add(this.txtset3t2, 3, 2);
            this.tblscoreboard.Controls.Add(this.txtset2t2, 2, 2);
            this.tblscoreboard.Controls.Add(this.txtset1t2, 1, 2);
            this.tblscoreboard.Location = new System.Drawing.Point(15, 101);
            this.tblscoreboard.Name = "tblscoreboard";
            this.tblscoreboard.RowCount = 3;
            this.tblscoreboard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblscoreboard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblscoreboard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tblscoreboard.Size = new System.Drawing.Size(297, 115);
            this.tblscoreboard.TabIndex = 0;
            // 
            // lblTname
            // 
            this.lblTname.AutoSize = true;
            this.lblTname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTname.Font = new System.Drawing.Font("Franklin Gothic Demi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTname.ForeColor = System.Drawing.Color.White;
            this.lblTname.Location = new System.Drawing.Point(6, 3);
            this.lblTname.Name = "lblTname";
            this.lblTname.Size = new System.Drawing.Size(73, 34);
            this.lblTname.TabIndex = 0;
            this.lblTname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTeam1name
            // 
            this.lblTeam1name.AutoSize = true;
            this.lblTeam1name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTeam1name.Font = new System.Drawing.Font("Franklin Gothic Demi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeam1name.ForeColor = System.Drawing.Color.White;
            this.lblTeam1name.Location = new System.Drawing.Point(6, 40);
            this.lblTeam1name.Name = "lblTeam1name";
            this.lblTeam1name.Size = new System.Drawing.Size(73, 34);
            this.lblTeam1name.TabIndex = 1;
            this.lblTeam1name.Text = "Player1";
            this.lblTeam1name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTeam2name
            // 
            this.lblTeam2name.AutoSize = true;
            this.lblTeam2name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTeam2name.Font = new System.Drawing.Font("Franklin Gothic Demi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeam2name.ForeColor = System.Drawing.Color.White;
            this.lblTeam2name.Location = new System.Drawing.Point(6, 77);
            this.lblTeam2name.Name = "lblTeam2name";
            this.lblTeam2name.Size = new System.Drawing.Size(73, 35);
            this.lblTeam2name.TabIndex = 2;
            this.lblTeam2name.Text = "Player2";
            this.lblTeam2name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblset1
            // 
            this.lblset1.AutoSize = true;
            this.lblset1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblset1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblset1.ForeColor = System.Drawing.Color.White;
            this.lblset1.Location = new System.Drawing.Point(88, 3);
            this.lblset1.Name = "lblset1";
            this.lblset1.Size = new System.Drawing.Size(61, 34);
            this.lblset1.TabIndex = 3;
            this.lblset1.Text = "Game1";
            this.lblset1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblset2
            // 
            this.lblset2.AutoSize = true;
            this.lblset2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblset2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblset2.ForeColor = System.Drawing.Color.White;
            this.lblset2.Location = new System.Drawing.Point(158, 3);
            this.lblset2.Name = "lblset2";
            this.lblset2.Size = new System.Drawing.Size(59, 34);
            this.lblset2.TabIndex = 3;
            this.lblset2.Text = "Game2";
            this.lblset2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblset3
            // 
            this.lblset3.AutoSize = true;
            this.lblset3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblset3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblset3.ForeColor = System.Drawing.Color.White;
            this.lblset3.Location = new System.Drawing.Point(226, 3);
            this.lblset3.Name = "lblset3";
            this.lblset3.Size = new System.Drawing.Size(65, 34);
            this.lblset3.TabIndex = 3;
            this.lblset3.Text = "Game3";
            this.lblset3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtset1t1
            // 
            this.txtset1t1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtset1t1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtset1t1.Location = new System.Drawing.Point(88, 43);
            this.txtset1t1.Multiline = true;
            this.txtset1t1.Name = "txtset1t1";
            this.txtset1t1.Size = new System.Drawing.Size(61, 28);
            this.txtset1t1.TabIndex = 4;
            this.txtset1t1.Text = "0";
            this.txtset1t1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtset2t1
            // 
            this.txtset2t1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtset2t1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtset2t1.Location = new System.Drawing.Point(158, 43);
            this.txtset2t1.Multiline = true;
            this.txtset2t1.Name = "txtset2t1";
            this.txtset2t1.Size = new System.Drawing.Size(59, 28);
            this.txtset2t1.TabIndex = 4;
            this.txtset2t1.Text = "0";
            this.txtset2t1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtset3t1
            // 
            this.txtset3t1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtset3t1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtset3t1.Location = new System.Drawing.Point(226, 43);
            this.txtset3t1.Multiline = true;
            this.txtset3t1.Name = "txtset3t1";
            this.txtset3t1.Size = new System.Drawing.Size(65, 28);
            this.txtset3t1.TabIndex = 4;
            this.txtset3t1.Text = "0";
            this.txtset3t1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtset3t2
            // 
            this.txtset3t2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtset3t2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtset3t2.Location = new System.Drawing.Point(226, 80);
            this.txtset3t2.Multiline = true;
            this.txtset3t2.Name = "txtset3t2";
            this.txtset3t2.Size = new System.Drawing.Size(65, 29);
            this.txtset3t2.TabIndex = 4;
            this.txtset3t2.Text = "0";
            this.txtset3t2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtset2t2
            // 
            this.txtset2t2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtset2t2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtset2t2.Location = new System.Drawing.Point(158, 80);
            this.txtset2t2.Multiline = true;
            this.txtset2t2.Name = "txtset2t2";
            this.txtset2t2.Size = new System.Drawing.Size(59, 29);
            this.txtset2t2.TabIndex = 4;
            this.txtset2t2.Text = "0";
            this.txtset2t2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtset1t2
            // 
            this.txtset1t2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtset1t2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtset1t2.Location = new System.Drawing.Point(88, 80);
            this.txtset1t2.Multiline = true;
            this.txtset1t2.Name = "txtset1t2";
            this.txtset1t2.Size = new System.Drawing.Size(61, 29);
            this.txtset1t2.TabIndex = 4;
            this.txtset1t2.Text = "0";
            this.txtset1t2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pnlplayerdoubles
            // 
            this.pnlplayerdoubles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlplayerdoubles.Controls.Add(this.tableLayoutPanel1);
            this.pnlplayerdoubles.Location = new System.Drawing.Point(816, 6);
            this.pnlplayerdoubles.Name = "pnlplayerdoubles";
            this.pnlplayerdoubles.Size = new System.Drawing.Size(481, 363);
            this.pnlplayerdoubles.TabIndex = 1;
            this.pnlplayerdoubles.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel6, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(477, 359);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.lblDt2N, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.lblDt2P1, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.btnDt2P1winner, 0, 4);
            this.tableLayoutPanel5.Controls.Add(this.lblDt2P2, 0, 7);
            this.tableLayoutPanel5.Controls.Add(this.rbDt2, 0, 8);
            this.tableLayoutPanel5.Controls.Add(this.btnDt2P2winner, 0, 9);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(242, 5);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 11;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(230, 349);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // lblDt2N
            // 
            this.lblDt2N.AutoSize = true;
            this.lblDt2N.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDt2N.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDt2N.Location = new System.Drawing.Point(3, 8);
            this.lblDt2N.Name = "lblDt2N";
            this.lblDt2N.Size = new System.Drawing.Size(224, 57);
            this.lblDt2N.TabIndex = 0;
            this.lblDt2N.Text = "Team Name";
            this.lblDt2N.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDt2P1
            // 
            this.lblDt2P1.AutoSize = true;
            this.lblDt2P1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDt2P1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDt2P1.Location = new System.Drawing.Point(3, 65);
            this.lblDt2P1.Name = "lblDt2P1";
            this.lblDt2P1.Size = new System.Drawing.Size(224, 48);
            this.lblDt2P1.TabIndex = 1;
            this.lblDt2P1.Text = "Player Name";
            this.lblDt2P1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDt2P1winner
            // 
            this.btnDt2P1winner.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDt2P1winner.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDt2P1winner.Location = new System.Drawing.Point(3, 138);
            this.btnDt2P1winner.Name = "btnDt2P1winner";
            this.btnDt2P1winner.Size = new System.Drawing.Size(224, 40);
            this.btnDt2P1winner.TabIndex = 3;
            this.btnDt2P1winner.Text = "Winner";
            this.btnDt2P1winner.UseVisualStyleBackColor = true;
            this.btnDt2P1winner.Click += new System.EventHandler(this.btnWinnerdoubles_Click);
            // 
            // lblDt2P2
            // 
            this.lblDt2P2.AutoSize = true;
            this.lblDt2P2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDt2P2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDt2P2.Location = new System.Drawing.Point(3, 199);
            this.lblDt2P2.Name = "lblDt2P2";
            this.lblDt2P2.Size = new System.Drawing.Size(224, 47);
            this.lblDt2P2.TabIndex = 5;
            this.lblDt2P2.Text = "Player Name";
            this.lblDt2P2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbDt2
            // 
            this.rbDt2.AutoSize = true;
            this.rbDt2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbDt2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDt2.Location = new System.Drawing.Point(3, 249);
            this.rbDt2.Name = "rbDt2";
            this.rbDt2.Padding = new System.Windows.Forms.Padding(80, 0, 0, 0);
            this.rbDt2.Size = new System.Drawing.Size(224, 32);
            this.rbDt2.TabIndex = 6;
            this.rbDt2.TabStop = true;
            this.rbDt2.Text = "Server";
            this.rbDt2.UseVisualStyleBackColor = true;
            this.rbDt2.CheckedChanged += new System.EventHandler(this.rbDt2_CheckedChanged);
            // 
            // btnDt2P2winner
            // 
            this.btnDt2P2winner.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDt2P2winner.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDt2P2winner.Location = new System.Drawing.Point(3, 296);
            this.btnDt2P2winner.Name = "btnDt2P2winner";
            this.btnDt2P2winner.Size = new System.Drawing.Size(224, 40);
            this.btnDt2P2winner.TabIndex = 7;
            this.btnDt2P2winner.Text = "Winner";
            this.btnDt2P2winner.UseVisualStyleBackColor = true;
            this.btnDt2P2winner.Click += new System.EventHandler(this.btnWinnerdoubles_Click);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.lblDt1N, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.lblDt1P1, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.btnDt1P1winner, 0, 4);
            this.tableLayoutPanel6.Controls.Add(this.lblDt1P2, 0, 7);
            this.tableLayoutPanel6.Controls.Add(this.rbDt1, 0, 8);
            this.tableLayoutPanel6.Controls.Add(this.btnDt1P2winner, 0, 9);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 11;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(229, 349);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // lblDt1N
            // 
            this.lblDt1N.AutoSize = true;
            this.lblDt1N.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDt1N.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDt1N.Location = new System.Drawing.Point(3, 8);
            this.lblDt1N.Name = "lblDt1N";
            this.lblDt1N.Size = new System.Drawing.Size(223, 58);
            this.lblDt1N.TabIndex = 0;
            this.lblDt1N.Text = "Team Name";
            this.lblDt1N.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDt1P1
            // 
            this.lblDt1P1.AutoSize = true;
            this.lblDt1P1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDt1P1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDt1P1.Location = new System.Drawing.Point(3, 66);
            this.lblDt1P1.Name = "lblDt1P1";
            this.lblDt1P1.Size = new System.Drawing.Size(223, 46);
            this.lblDt1P1.TabIndex = 1;
            this.lblDt1P1.Text = "Player Name";
            this.lblDt1P1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDt1P1winner
            // 
            this.btnDt1P1winner.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDt1P1winner.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDt1P1winner.Location = new System.Drawing.Point(3, 141);
            this.btnDt1P1winner.Name = "btnDt1P1winner";
            this.btnDt1P1winner.Size = new System.Drawing.Size(223, 40);
            this.btnDt1P1winner.TabIndex = 3;
            this.btnDt1P1winner.Text = "Winner";
            this.btnDt1P1winner.UseVisualStyleBackColor = true;
            this.btnDt1P1winner.Click += new System.EventHandler(this.btnWinnerdoubles_Click);
            // 
            // lblDt1P2
            // 
            this.lblDt1P2.AutoSize = true;
            this.lblDt1P2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDt1P2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDt1P2.Location = new System.Drawing.Point(3, 200);
            this.lblDt1P2.Name = "lblDt1P2";
            this.lblDt1P2.Size = new System.Drawing.Size(223, 46);
            this.lblDt1P2.TabIndex = 5;
            this.lblDt1P2.Text = "Player Name";
            this.lblDt1P2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbDt1
            // 
            this.rbDt1.AutoSize = true;
            this.rbDt1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbDt1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDt1.Location = new System.Drawing.Point(3, 249);
            this.rbDt1.Name = "rbDt1";
            this.rbDt1.Padding = new System.Windows.Forms.Padding(80, 0, 0, 0);
            this.rbDt1.Size = new System.Drawing.Size(223, 33);
            this.rbDt1.TabIndex = 6;
            this.rbDt1.TabStop = true;
            this.rbDt1.Text = "Server";
            this.rbDt1.UseVisualStyleBackColor = true;
            this.rbDt1.CheckedChanged += new System.EventHandler(this.rbDt1_CheckedChanged);
            // 
            // btnDt1P2winner
            // 
            this.btnDt1P2winner.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDt1P2winner.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDt1P2winner.Location = new System.Drawing.Point(3, 298);
            this.btnDt1P2winner.Name = "btnDt1P2winner";
            this.btnDt1P2winner.Size = new System.Drawing.Size(223, 40);
            this.btnDt1P2winner.TabIndex = 7;
            this.btnDt1P2winner.Text = "Winner";
            this.btnDt1P2winner.UseVisualStyleBackColor = true;
            this.btnDt1P2winner.Click += new System.EventHandler(this.btnWinnerdoubles_Click);
            // 
            // pnlplayersingles
            // 
            this.pnlplayersingles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlplayersingles.Controls.Add(this.tableLayoutPanel2);
            this.pnlplayersingles.Location = new System.Drawing.Point(329, 6);
            this.pnlplayersingles.Name = "pnlplayersingles";
            this.pnlplayersingles.Size = new System.Drawing.Size(481, 363);
            this.pnlplayersingles.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(477, 359);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.lblSt2N, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.lblSt2P, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.rbSt2, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.btnSt2winner, 0, 4);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(242, 5);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 6;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.90698F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 72.09303F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(230, 349);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // lblSt2N
            // 
            this.lblSt2N.AutoSize = true;
            this.lblSt2N.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSt2N.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSt2N.Location = new System.Drawing.Point(3, 29);
            this.lblSt2N.Name = "lblSt2N";
            this.lblSt2N.Size = new System.Drawing.Size(224, 76);
            this.lblSt2N.TabIndex = 0;
            this.lblSt2N.Text = "Team Name";
            this.lblSt2N.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSt2P
            // 
            this.lblSt2P.AutoSize = true;
            this.lblSt2P.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSt2P.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSt2P.Location = new System.Drawing.Point(3, 105);
            this.lblSt2P.Name = "lblSt2P";
            this.lblSt2P.Size = new System.Drawing.Size(224, 56);
            this.lblSt2P.TabIndex = 1;
            this.lblSt2P.Text = "Player Name";
            this.lblSt2P.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbSt2
            // 
            this.rbSt2.AutoSize = true;
            this.rbSt2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbSt2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSt2.Location = new System.Drawing.Point(3, 164);
            this.rbSt2.Name = "rbSt2";
            this.rbSt2.Padding = new System.Windows.Forms.Padding(80, 0, 0, 0);
            this.rbSt2.Size = new System.Drawing.Size(224, 45);
            this.rbSt2.TabIndex = 2;
            this.rbSt2.TabStop = true;
            this.rbSt2.Text = "Server";
            this.rbSt2.UseVisualStyleBackColor = true;
            this.rbSt2.CheckedChanged += new System.EventHandler(this.rbSt2_CheckedChanged);
            // 
            // btnSt2winner
            // 
            this.btnSt2winner.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSt2winner.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSt2winner.Location = new System.Drawing.Point(3, 243);
            this.btnSt2winner.Name = "btnSt2winner";
            this.btnSt2winner.Size = new System.Drawing.Size(224, 40);
            this.btnSt2winner.TabIndex = 3;
            this.btnSt2winner.Text = "Winner";
            this.btnSt2winner.UseVisualStyleBackColor = true;
            this.btnSt2winner.Click += new System.EventHandler(this.btnWinner_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.lblSt1N, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblSt1P, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.rbSt1, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.btnSt1winner, 0, 4);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 6;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.58621F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 72.4138F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(229, 349);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // lblSt1N
            // 
            this.lblSt1N.AutoSize = true;
            this.lblSt1N.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSt1N.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSt1N.Location = new System.Drawing.Point(3, 28);
            this.lblSt1N.Name = "lblSt1N";
            this.lblSt1N.Size = new System.Drawing.Size(223, 76);
            this.lblSt1N.TabIndex = 0;
            this.lblSt1N.Text = "Team Name";
            this.lblSt1N.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSt1P
            // 
            this.lblSt1P.AutoSize = true;
            this.lblSt1P.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSt1P.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSt1P.Location = new System.Drawing.Point(3, 104);
            this.lblSt1P.Name = "lblSt1P";
            this.lblSt1P.Size = new System.Drawing.Size(223, 57);
            this.lblSt1P.TabIndex = 1;
            this.lblSt1P.Text = "Player Name";
            this.lblSt1P.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbSt1
            // 
            this.rbSt1.AutoSize = true;
            this.rbSt1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbSt1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSt1.Location = new System.Drawing.Point(3, 164);
            this.rbSt1.Name = "rbSt1";
            this.rbSt1.Padding = new System.Windows.Forms.Padding(80, 0, 0, 0);
            this.rbSt1.Size = new System.Drawing.Size(223, 46);
            this.rbSt1.TabIndex = 2;
            this.rbSt1.TabStop = true;
            this.rbSt1.Text = "Server";
            this.rbSt1.UseVisualStyleBackColor = true;
            this.rbSt1.CheckedChanged += new System.EventHandler(this.rbSt1_CheckedChanged);
            // 
            // btnSt1winner
            // 
            this.btnSt1winner.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSt1winner.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSt1winner.Location = new System.Drawing.Point(3, 243);
            this.btnSt1winner.Name = "btnSt1winner";
            this.btnSt1winner.Size = new System.Drawing.Size(223, 40);
            this.btnSt1winner.TabIndex = 3;
            this.btnSt1winner.Text = "Winner";
            this.btnSt1winner.UseVisualStyleBackColor = true;
            this.btnSt1winner.Click += new System.EventHandler(this.btnWinner_Click);
            // 
            // FrmBadminton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 679);
            this.Controls.Add(this.pnlMain);
            this.KeyPreview = true;
            this.Name = "FrmBadminton";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmBadminton";
            this.Load += new System.EventHandler(this.FrmBadminton_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmBadminton_KeyDown);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvdatabind)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tblscoreboard.ResumeLayout(false);
            this.tblscoreboard.PerformLayout();
            this.pnlplayerdoubles.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.pnlplayersingles.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlplayersingles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tblscoreboard;
        private System.Windows.Forms.TextBox txtRally;
        private System.Windows.Forms.Label lblTname;
        private System.Windows.Forms.Label lblTeam1name;
        private System.Windows.Forms.Label lblTeam2name;
        private System.Windows.Forms.Label lblset1;
        private System.Windows.Forms.Label lblset2;
        private System.Windows.Forms.Label lblset3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnshot;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lblSt1N;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblmatchno;
        private System.Windows.Forms.Label lblSt2N;
        private System.Windows.Forms.Label lblSt2P;
        private System.Windows.Forms.Label lblSt1P;
        private System.Windows.Forms.RadioButton rbSt1;
        private System.Windows.Forms.RadioButton rbSt2;
        private System.Windows.Forms.Button btnSt1winner;
        private System.Windows.Forms.Button btnSt2winner;
        private System.Windows.Forms.Button btndec;
        private System.Windows.Forms.Button btninc;
        private System.Windows.Forms.TextBox txtset1t1;
        private System.Windows.Forms.TextBox txtset2t1;
        private System.Windows.Forms.TextBox txtset3t1;
        private System.Windows.Forms.TextBox txtset3t2;
        private System.Windows.Forms.TextBox txtset2t2;
        private System.Windows.Forms.TextBox txtset1t2;
        private System.Windows.Forms.Button btngameend;
        private System.Windows.Forms.Label lblerror;
        private System.Windows.Forms.Button btnGamestart;
        private System.Windows.Forms.Panel pnlplayerdoubles;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label lblDt1N;
        private System.Windows.Forms.Label lblDt1P1;
        private System.Windows.Forms.Button btnDt1P1winner;
        private System.Windows.Forms.Label lblDt1P2;
        private System.Windows.Forms.RadioButton rbDt1;
        private System.Windows.Forms.Button btnDt1P2winner;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label lblDt2N;
        private System.Windows.Forms.Label lblDt2P1;
        private System.Windows.Forms.Button btnDt2P1winner;
        private System.Windows.Forms.Label lblDt2P2;
        private System.Windows.Forms.RadioButton rbDt2;
        private System.Windows.Forms.Button btnDt2P2winner;
        private System.Windows.Forms.DataGridView gvdatabind;
        private System.Windows.Forms.Button btnpointswap;
        private System.Windows.Forms.DataGridViewTextBoxColumn GameID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PointID1;
        private System.Windows.Forms.DataGridViewTextBoxColumn WonID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serid;
        private System.Windows.Forms.DataGridViewTextBoxColumn WinnerID1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServerID1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeamAPoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeamBPoint;
        private System.Windows.Forms.Panel PnlGrid;
        private System.Windows.Forms.Button btnMatchStart;
        private System.Windows.Forms.Button btnMatchEnd;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnmatchendundo;
    }
}