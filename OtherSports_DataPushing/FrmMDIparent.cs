using System;
using OtherSports_DataPushing.Layer;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Configuration;
using OtherSports_DataPushing.Volley_Ball;
using OtherSports_DataPushing.Kho_Kho;
using OtherSports_DataPushing.BadMinton;
using OtherSports_DataPushing.BasketBall;
using OtherSports_DataPushing.Wrestling;
using System.Xml;
using OtherSports_DataPushing.Kabaddi;

namespace OtherSports_DataPushing
{
    public partial class FrmMDIparent : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectControlS"]);
        SqlConnectionStringBuilder strBuild = new SqlConnectionStringBuilder();
        BusinessLy objMB = new BusinessLy();
        DataTable DT;
        Boolean pageload = false;
        string Appname = "";
        int TeamID = 0;
        int playerID = 0;
        int VenueID = 0;

        public FrmMDIparent()
        {
            InitializeComponent();
            if (mycommon.SportID == 8)
            {
                reportToolStripMenuItem.Visible = true;
                validataionToolStripMenuItem.Visible = true;
                importExportToolStripMenuItem.Visible = true;
                scorecardToolStripMenuItem.Visible = true;
                clearTransactionToolStripMenuItem.Visible = true;
            }

            DBConnection dd = new DBConnection();
            string datasource = dd.SqlConnectionDB(1).DataSource;
            strBuild.ConnectionString = ConfigurationManager.AppSettings["ConnectString"];
            lblLocalConn.Text = "Server Connection :-" + strBuild.DataSource + " DB:-" + strBuild.InitialCatalog;
            MessageBox.Show("DataBase Server Name is :" + datasource + " DB:-" + strBuild.InitialCatalog);

            this.Text = this.Text + " - " + mycommon.ApplicationName.ToUpper() + " - Server Connection :-" + strBuild.DataSource + " DB:-" + strBuild.InitialCatalog;

            cmbLocal.Text = strBuild.DataSource;
        }

        private void FrmMDIparent_Load(object sender, EventArgs e)
        {
            pageload = true;
        }
        
        #region App_Option&function

        private void pbMain_Click(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            Appname = Convert.ToString(((PictureBox)sender).Name);
            mycommon.ApplicationName = Appname.Replace("pb", "");
            this.Text = mycommon.ApplicationName + " - " + fvi.FileVersion;
            msMain.Visible = true;
            this.Size = new Size(1320, 870);
            this.StartPosition = FormStartPosition.CenterScreen;
            try
            {
                DataTable dt = objMB.ExeQueryStrRetDTBL("select ID from Sports_Master where Name like '" + mycommon.ApplicationName + "'", 1);
                mycommon.SportID = Convert.ToInt32(dt.Rows[0]["ID"]);
            }
            catch { }
        }
        private void tsCompetition_Click(object sender, EventArgs e)
        {
            FrmCompetition frm = new FrmCompetition();
            frm.Show();
        }


        private void tsteams_Click(object sender, EventArgs e)
        {
            FrmTeam frm = new FrmTeam();
            frm.Show();
        }

        private void tsplayermaster_Click(object sender, EventArgs e)
        {
            FrmMasterPlayer frm = new FrmMasterPlayer();
            frm.Show();
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmHome frm = new FrmHome();
            frm.Show();
        }

        private void tscompteams_Click(object sender, EventArgs e)
        {
            //foreach (Form FrmCompetitionTeam in MdiChildren)
            //{
            //    FrmCompetitionTeam.Show();
            //    return;
            //}
            //pnlbg.Visible = false;
            FrmCompetitionTeam objfrm = new FrmCompetitionTeam();
            //objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void tsCompsquad_Click(object sender, EventArgs e)
        {
            //foreach (Form FrmCompetitionSquad in MdiChildren)
            //{
            //    FrmCompetitionSquad.Show();
            //    return;
            //}
            //pnlbg.Visible = false;
            FrmCompetitionSquad objfrm = new FrmCompetitionSquad();
          //  objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void tsMatchCreation_Click(object sender, EventArgs e)
        {
            if (mycommon.SportID == 15)
            {
                //foreach (Form FrmMatches_BM in MdiChildren)
                //{
                //    FrmMatches_BM.Show();
                //    return;
                //}
                //pnlbg.Visible = false;
                FrmMatches_BM objfrm = new FrmMatches_BM();
              //  objfrm.MdiParent = this;
                objfrm.Show();
            }
            else if (mycommon.SportID == 8)
            {
                //foreach (Form FrmMatches_Kabaddi in MdiChildren)
                //{
                //    FrmMatches_Kabaddi.Show();
                //    return;
                //}
                //pnlbg.Visible = false;
                FrmMatches_Kabaddi objfrm = new FrmMatches_Kabaddi();
               // objfrm.MdiParent = this;
                objfrm.Show();
            }
            else if (mycommon.SportID == 14)
            {
                //foreach (Form FrmMatches_BB in MdiChildren)
                //{
                //    FrmMatches_BB.Show();
                //    return;
                //}
                //pnlbg.Visible = false;
                FrmMatches_BB objfrm = new FrmMatches_BB();
               // objfrm.MdiParent = this;
                objfrm.Show();
            }
            else if (mycommon.SportID == 4)
            {
                //foreach (Form FrmMatches_Volleyball in MdiChildren)
                //{
                //    FrmMatches_Volleyball.Show();
                //    return;
                //}
                //pnlbg.Visible = false;
                FrmMatches_Volleyball objfrm = new FrmMatches_Volleyball();
               // objfrm.MdiParent = this;
                objfrm.Show();
            }
            else if (mycommon.SportID == 7)
            {
                //foreach (Form FrmMatches_KK in MdiChildren)
                //{
                //    FrmMatches_KK.Show();
                //    return;
                //}
                //pnlbg.Visible = false;
                FrmMatches_KK objfrm = new FrmMatches_KK();
               // objfrm.MdiParent = this;
                objfrm.Show();
            }
            else if (mycommon.SportID == 16)
            {
                //foreach (Form FrmMatch_Athletic in MdiChildren)
                //{
                //    FrmMatch_Athletic.Show();
                //    return;
                //}
                //pnlbg.Visible = false;
                FrmMatch_Athletic objfrm = new FrmMatch_Athletic();
               // objfrm.MdiParent = this;
                objfrm.Show();
            }
            else if (mycommon.SportID == 2)
            {
                //foreach (Form FrmMatches_Ww in MdiChildren)
                //{
                //    FrmMatches_Ww.Show();
                //    return;
                //}
                //pnlbg.Visible = false;
                FrmMatches_Ww objfrm = new FrmMatches_Ww();
               // objfrm.MdiParent = this;
                objfrm.Show();
            }
        }

        private void tsVenuemaster_Click(object sender, EventArgs e)
        {
            FrmVenue frm = new FrmVenue();
            frm.Show();
        }

        #endregion

        private void tsOpen_Click(object sender, EventArgs e)
        {
            //foreach (Form FrmOpenMatches in MdiChildren)
            //{
            //    FrmOpenMatches.Show();
            //    return;
            //}
           // pnlbg.Visible = false;
            FrmOpenMatches objfrm = new FrmOpenMatches();
          //  objfrm.MdiParent = this;
            objfrm.Show();

        }

        private void FrmMDIparent_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAllReport frm = new FrmAllReport();
            frm.Show();
        }

        private void validataionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmValidation frm = new FrmValidation();
            frm.Show();
        }

        private void coachMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCoachMaster frm = new frmCoachMaster();
            frm.Show();
        }

        private void importExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImportExport frm = new frmImportExport();
            frm.Show();
        }

        private void dBBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDBBackup frm = new FrmDBBackup();
            frm.Show();
        }

        private void scorecardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScorecard frm = new frmScorecard();
            frm.Show();
        }

        private void databaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PnServers.Location = new Point(statusStrip.Location.X + 500, 25);
            PnServers.BringToFront();
            PnServers.Visible = true;
        }

        private void btnOkServers_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder decoder = new SqlConnectionStringBuilder(ConfigurationManager.AppSettings["ConnectString"].ToString());

            string Key = "User Id=" + decoder.UserID + ";Password=" + decoder.Password + ";Data Source=" + cmbLocal.Text + ";Initial Catalog=" + decoder.InitialCatalog;
            SetValue("ConnectString", Key);
            ConfigurationManager.RefreshSection("appSettings");
            Properties.Settings.Default.Reload();
            PnServers.Visible = false;
            strBuild.ConnectionString = ConfigurationManager.AppSettings["ConnectString"].ToString();
            lblLocalConn.Text = "Server Connection :-" + strBuild.DataSource + " DB:-" + strBuild.InitialCatalog;
            lblLocalConn.Location = new Point(statusStrip.Location.X + 750, statusStrip.Location.Y+25);
         
        }
        private XmlNode node = null; public string docName = string.Empty;
        public bool SetValue(string key, string value)
        {
            XmlDocument cfgDoc = new XmlDocument();
            LoadConfigDoc(cfgDoc);

            node = cfgDoc.SelectSingleNode("//appSettings");

            if (node == null)
            {
                MessageBox.Show("connectionStrings section not found");
            }

            try
            {
                XmlElement addElem = (XmlElement)node.SelectSingleNode("//add[@key='" + key + "']");

                if (addElem != null)
                {
                    addElem.SetAttribute("value", value);
                }
                else
                {
                    XmlElement entry = cfgDoc.CreateElement("add");
                    entry.SetAttribute("name", key);
                    entry.SetAttribute("connectionString", value);
                    node.AppendChild(entry);
                }

                SaveConfigDoc(cfgDoc, docName);
                return true;
            }
            catch
            {

                return false;
            }
        }

        private XmlDocument LoadConfigDoc(XmlDocument cfgDoc)
        {

            docName = ((Assembly.GetEntryAssembly()).GetName()).Name;
            docName += ".exe.config";

            cfgDoc.Load(docName);
            return cfgDoc;
        }


        private void SaveConfigDoc(XmlDocument cfgDoc, string cfgDocPath)
        {
            try
            {
                XmlTextWriter writer = new XmlTextWriter(cfgDocPath, null);
                writer.Formatting = Formatting.Indented;
                cfgDoc.WriteTo(writer);
                writer.Flush();
                writer.Close();
                return;

            }
            catch
            {
                throw;
            }
        }

        private void clearTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDeleteMatchcs frm = new frmDeleteMatchcs();
            frm.Show();
        }

        private void syncToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSync frm = new frmSync();
            frm.Show();
        }

        private void broadcastMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBroadcast frm = new frmBroadcast();
            frm.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void ratingMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // FrmRating fr = new FrmRating();
           // fr.Show();
        }

        private void finalSyncToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmfinalSync fr = new FrmfinalSync();
            fr.Show();
        }

        private void tieBreakerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmtiebreaker fg = new Frmtiebreaker();
            fg.Show();
        }

        private void manualCaptureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manual_Capture mc = new Manual_Capture();
            mc.Show();
        }

        private void archiveSYNCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArchiveSync ac = new frmArchiveSync();
            ac.Show();
        }

        

    }
}



