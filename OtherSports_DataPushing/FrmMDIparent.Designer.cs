namespace OtherSports_DataPushing
{
    partial class FrmMDIparent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMDIparent));
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCompetition = new System.Windows.Forms.ToolStripMenuItem();
            this.tsteams = new System.Windows.Forms.ToolStripMenuItem();
            this.tsplayermaster = new System.Windows.Forms.ToolStripMenuItem();
            this.tsVenuemaster = new System.Windows.Forms.ToolStripMenuItem();
            this.coachMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tscompteams = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCompsquad = new System.Windows.Forms.ToolStripMenuItem();
            this.clearTransactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.broadcastMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ratingMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matchesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMatchCreation = new System.Windows.Forms.ToolStripMenuItem();
            this.tsOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.scorecardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.validataionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dBBackupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.syncToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finalSyncToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tieBreakerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualCaptureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlbg = new System.Windows.Forms.Panel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.PnServers = new System.Windows.Forms.Panel();
            this.btnOkServers = new System.Windows.Forms.Button();
            this.cmbLocal = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lblLocalConn = new System.Windows.Forms.Label();
            this.archiveSYNCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msMain.SuspendLayout();
            this.pnlbg.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.PnServers.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.matchesToolStripMenuItem,
            this.tsOpen,
            this.scorecardToolStripMenuItem,
            this.importExportToolStripMenuItem,
            this.validataionToolStripMenuItem,
            this.reportToolStripMenuItem,
            this.backToolStripMenuItem,
            this.dBBackupToolStripMenuItem,
            this.databaseToolStripMenuItem,
            this.syncToolStripMenuItem,
            this.finalSyncToolStripMenuItem,
            this.tieBreakerToolStripMenuItem,
            this.manualCaptureToolStripMenuItem,
            this.archiveSYNCToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(1264, 24);
            this.msMain.TabIndex = 4;
            this.msMain.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsCompetition,
            this.tsteams,
            this.tsplayermaster,
            this.tsVenuemaster,
            this.coachMasterToolStripMenuItem,
            this.tscompteams,
            this.tsCompsquad,
            this.clearTransactionToolStripMenuItem,
            this.broadcastMasterToolStripMenuItem,
            this.ratingMasterToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(60, 20);
            this.toolStripMenuItem1.Text = "Masters";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // tsCompetition
            // 
            this.tsCompetition.Name = "tsCompetition";
            this.tsCompetition.Size = new System.Drawing.Size(165, 22);
            this.tsCompetition.Text = "Competition";
            this.tsCompetition.Click += new System.EventHandler(this.tsCompetition_Click);
            // 
            // tsteams
            // 
            this.tsteams.Name = "tsteams";
            this.tsteams.Size = new System.Drawing.Size(165, 22);
            this.tsteams.Text = "Teams Master";
            this.tsteams.Click += new System.EventHandler(this.tsteams_Click);
            // 
            // tsplayermaster
            // 
            this.tsplayermaster.Name = "tsplayermaster";
            this.tsplayermaster.Size = new System.Drawing.Size(165, 22);
            this.tsplayermaster.Text = "Player Master";
            this.tsplayermaster.Click += new System.EventHandler(this.tsplayermaster_Click);
            // 
            // tsVenuemaster
            // 
            this.tsVenuemaster.Name = "tsVenuemaster";
            this.tsVenuemaster.Size = new System.Drawing.Size(165, 22);
            this.tsVenuemaster.Text = "Venue Master";
            this.tsVenuemaster.Click += new System.EventHandler(this.tsVenuemaster_Click);
            // 
            // coachMasterToolStripMenuItem
            // 
            this.coachMasterToolStripMenuItem.Name = "coachMasterToolStripMenuItem";
            this.coachMasterToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.coachMasterToolStripMenuItem.Text = "Coach Master";
            this.coachMasterToolStripMenuItem.Click += new System.EventHandler(this.coachMasterToolStripMenuItem_Click);
            // 
            // tscompteams
            // 
            this.tscompteams.Name = "tscompteams";
            this.tscompteams.Size = new System.Drawing.Size(165, 22);
            this.tscompteams.Text = "Comp Teams";
            this.tscompteams.Click += new System.EventHandler(this.tscompteams_Click);
            // 
            // tsCompsquad
            // 
            this.tsCompsquad.Name = "tsCompsquad";
            this.tsCompsquad.Size = new System.Drawing.Size(165, 22);
            this.tsCompsquad.Text = "Comp Lineup";
            this.tsCompsquad.Click += new System.EventHandler(this.tsCompsquad_Click);
            // 
            // clearTransactionToolStripMenuItem
            // 
            this.clearTransactionToolStripMenuItem.Name = "clearTransactionToolStripMenuItem";
            this.clearTransactionToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.clearTransactionToolStripMenuItem.Text = "Clear Transaction";
            this.clearTransactionToolStripMenuItem.Visible = false;
            this.clearTransactionToolStripMenuItem.Click += new System.EventHandler(this.clearTransactionToolStripMenuItem_Click);
            // 
            // broadcastMasterToolStripMenuItem
            // 
            this.broadcastMasterToolStripMenuItem.Name = "broadcastMasterToolStripMenuItem";
            this.broadcastMasterToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.broadcastMasterToolStripMenuItem.Text = "Broadcast Master";
            this.broadcastMasterToolStripMenuItem.Click += new System.EventHandler(this.broadcastMasterToolStripMenuItem_Click);
            // 
            // ratingMasterToolStripMenuItem
            // 
            this.ratingMasterToolStripMenuItem.Name = "ratingMasterToolStripMenuItem";
            this.ratingMasterToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.ratingMasterToolStripMenuItem.Text = "Rating Master";
            this.ratingMasterToolStripMenuItem.Click += new System.EventHandler(this.ratingMasterToolStripMenuItem_Click);
            // 
            // matchesToolStripMenuItem
            // 
            this.matchesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMatchCreation});
            this.matchesToolStripMenuItem.Name = "matchesToolStripMenuItem";
            this.matchesToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.matchesToolStripMenuItem.Text = "Matches";
            // 
            // tsMatchCreation
            // 
            this.tsMatchCreation.Name = "tsMatchCreation";
            this.tsMatchCreation.Size = new System.Drawing.Size(156, 22);
            this.tsMatchCreation.Text = "Match Creation";
            this.tsMatchCreation.Click += new System.EventHandler(this.tsMatchCreation_Click);
            // 
            // tsOpen
            // 
            this.tsOpen.Name = "tsOpen";
            this.tsOpen.Size = new System.Drawing.Size(48, 20);
            this.tsOpen.Text = "Open";
            this.tsOpen.Click += new System.EventHandler(this.tsOpen_Click);
            // 
            // scorecardToolStripMenuItem
            // 
            this.scorecardToolStripMenuItem.Name = "scorecardToolStripMenuItem";
            this.scorecardToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.scorecardToolStripMenuItem.Text = "Scorecard";
            this.scorecardToolStripMenuItem.Visible = false;
            this.scorecardToolStripMenuItem.Click += new System.EventHandler(this.scorecardToolStripMenuItem_Click);
            // 
            // importExportToolStripMenuItem
            // 
            this.importExportToolStripMenuItem.Name = "importExportToolStripMenuItem";
            this.importExportToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.importExportToolStripMenuItem.Text = "Import Export";
            this.importExportToolStripMenuItem.Visible = false;
            this.importExportToolStripMenuItem.Click += new System.EventHandler(this.importExportToolStripMenuItem_Click);
            // 
            // validataionToolStripMenuItem
            // 
            this.validataionToolStripMenuItem.Name = "validataionToolStripMenuItem";
            this.validataionToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.validataionToolStripMenuItem.Text = "Validataion";
            this.validataionToolStripMenuItem.Visible = false;
            this.validataionToolStripMenuItem.Click += new System.EventHandler(this.validataionToolStripMenuItem_Click);
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.reportToolStripMenuItem.Text = "Report";
            this.reportToolStripMenuItem.Visible = false;
            this.reportToolStripMenuItem.Click += new System.EventHandler(this.reportToolStripMenuItem_Click);
            // 
            // backToolStripMenuItem
            // 
            this.backToolStripMenuItem.Name = "backToolStripMenuItem";
            this.backToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.backToolStripMenuItem.Text = "Back";
            this.backToolStripMenuItem.Click += new System.EventHandler(this.backToolStripMenuItem_Click);
            // 
            // dBBackupToolStripMenuItem
            // 
            this.dBBackupToolStripMenuItem.Name = "dBBackupToolStripMenuItem";
            this.dBBackupToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.dBBackupToolStripMenuItem.Text = "DB Backup";
            this.dBBackupToolStripMenuItem.Click += new System.EventHandler(this.dBBackupToolStripMenuItem_Click);
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.databaseToolStripMenuItem.Text = "Database";
            this.databaseToolStripMenuItem.Click += new System.EventHandler(this.databaseToolStripMenuItem_Click);
            // 
            // syncToolStripMenuItem
            // 
            this.syncToolStripMenuItem.Name = "syncToolStripMenuItem";
            this.syncToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.syncToolStripMenuItem.Text = "Sync";
            this.syncToolStripMenuItem.Click += new System.EventHandler(this.syncToolStripMenuItem_Click);
            // 
            // finalSyncToolStripMenuItem
            // 
            this.finalSyncToolStripMenuItem.Name = "finalSyncToolStripMenuItem";
            this.finalSyncToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.finalSyncToolStripMenuItem.Text = "Final Sync";
            this.finalSyncToolStripMenuItem.Click += new System.EventHandler(this.finalSyncToolStripMenuItem_Click);
            // 
            // tieBreakerToolStripMenuItem
            // 
            this.tieBreakerToolStripMenuItem.Name = "tieBreakerToolStripMenuItem";
            this.tieBreakerToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.tieBreakerToolStripMenuItem.Text = "Tie Breaker";
            this.tieBreakerToolStripMenuItem.Click += new System.EventHandler(this.tieBreakerToolStripMenuItem_Click);
            // 
            // manualCaptureToolStripMenuItem
            // 
            this.manualCaptureToolStripMenuItem.Name = "manualCaptureToolStripMenuItem";
            this.manualCaptureToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.manualCaptureToolStripMenuItem.Text = "Manual Capture";
            this.manualCaptureToolStripMenuItem.Click += new System.EventHandler(this.manualCaptureToolStripMenuItem_Click);
            // 
            // pnlbg
            // 
            this.pnlbg.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnlbg.Controls.Add(this.statusStrip);
            this.pnlbg.Controls.Add(this.PnServers);
            this.pnlbg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlbg.Location = new System.Drawing.Point(0, 24);
            this.pnlbg.Name = "pnlbg";
            this.pnlbg.Size = new System.Drawing.Size(1264, 693);
            this.pnlbg.TabIndex = 11;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 671);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1264, 22);
            this.statusStrip.TabIndex = 189;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // PnServers
            // 
            this.PnServers.BackColor = System.Drawing.Color.Transparent;
            this.PnServers.Controls.Add(this.btnOkServers);
            this.PnServers.Controls.Add(this.cmbLocal);
            this.PnServers.Controls.Add(this.label12);
            this.PnServers.Location = new System.Drawing.Point(558, 19);
            this.PnServers.Name = "PnServers";
            this.PnServers.Size = new System.Drawing.Size(269, 70);
            this.PnServers.TabIndex = 188;
            this.PnServers.Visible = false;
            // 
            // btnOkServers
            // 
            this.btnOkServers.Location = new System.Drawing.Point(118, 36);
            this.btnOkServers.Name = "btnOkServers";
            this.btnOkServers.Size = new System.Drawing.Size(52, 23);
            this.btnOkServers.TabIndex = 189;
            this.btnOkServers.Text = "Ok";
            this.btnOkServers.UseVisualStyleBackColor = true;
            this.btnOkServers.Click += new System.EventHandler(this.btnOkServers_Click);
            // 
            // cmbLocal
            // 
            this.cmbLocal.FormattingEnabled = true;
            this.cmbLocal.Items.AddRange(new object[] {
            "192.168.1.17"});
            this.cmbLocal.Location = new System.Drawing.Point(79, 9);
            this.cmbLocal.Name = "cmbLocal";
            this.cmbLocal.Size = new System.Drawing.Size(162, 21);
            this.cmbLocal.TabIndex = 186;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(14, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 14);
            this.label12.TabIndex = 185;
            this.label12.Text = "Local";
            // 
            // lblLocalConn
            // 
            this.lblLocalConn.AutoSize = true;
            this.lblLocalConn.BackColor = System.Drawing.Color.Black;
            this.lblLocalConn.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalConn.ForeColor = System.Drawing.Color.White;
            this.lblLocalConn.Location = new System.Drawing.Point(750, 699);
            this.lblLocalConn.Name = "lblLocalConn";
            this.lblLocalConn.Size = new System.Drawing.Size(38, 14);
            this.lblLocalConn.TabIndex = 193;
            this.lblLocalConn.Text = "local";
            // 
            // archiveSYNCToolStripMenuItem
            // 
            this.archiveSYNCToolStripMenuItem.Name = "archiveSYNCToolStripMenuItem";
            this.archiveSYNCToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.archiveSYNCToolStripMenuItem.Text = "Archive SYNC";
            this.archiveSYNCToolStripMenuItem.Click += new System.EventHandler(this.archiveSYNCToolStripMenuItem_Click);
            // 
            // FrmMDIparent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 717);
            this.Controls.Add(this.lblLocalConn);
            this.Controls.Add(this.pnlbg);
            this.Controls.Add(this.msMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "FrmMDIparent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KHELO INDIA";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMDIparent_FormClosing);
            this.Load += new System.EventHandler(this.FrmMDIparent_Load);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.pnlbg.ResumeLayout(false);
            this.pnlbg.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.PnServers.ResumeLayout(false);
            this.PnServers.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsCompetition;
        private System.Windows.Forms.ToolStripMenuItem tsteams;
        private System.Windows.Forms.ToolStripMenuItem tsplayermaster;
        private System.Windows.Forms.ToolStripMenuItem matchesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsMatchCreation;
        private System.Windows.Forms.ToolStripMenuItem tsOpen;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.Panel pnlbg;
        private System.Windows.Forms.ToolStripMenuItem tsVenuemaster;
        private System.Windows.Forms.ToolStripMenuItem tsCompsquad;
        private System.Windows.Forms.ToolStripMenuItem tscompteams;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem validataionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coachMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importExportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dBBackupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scorecardToolStripMenuItem;
        private System.Windows.Forms.Label lblLocalConn;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.Panel PnServers;
        private System.Windows.Forms.Button btnOkServers;
        private System.Windows.Forms.ComboBox cmbLocal;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem clearTransactionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem syncToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem broadcastMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ratingMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem finalSyncToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tieBreakerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualCaptureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem archiveSYNCToolStripMenuItem;
    }
}



