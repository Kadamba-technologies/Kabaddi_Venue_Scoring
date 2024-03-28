using OtherSports_DataPushing.Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtherSports_DataPushing.Kabaddi
{
    public partial class frmArchiveSync : Form
    {
        BusinessLy objMB = new BusinessLy();
        DataTable dt;
        Boolean pageload = false;
        Timer timer = new Timer();
        public frmArchiveSync()
        {
            InitializeComponent();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (cbMatches.SelectedIndex >= 0)
            {
                if (Convert.ToInt32(objMB.ExeQueryStrIntBL("SELECT CoUNT(*) FROM MatchResult WHERE MatchID=" + cbMatches.SelectedValue, 1)) > 1)
                {
                     SyncArchive();
                     timer.Stop();
                     lblStatus.Text = lblStatus.Text + " " + " PUSHER STOPED";
                }
                else
                {
                    SyncArchive();
                }
               
            }
        }

        void SyncArchive()
        {
            try
            {
                dt = objMB.ExeQueryStrRetDTBL("SP_SYNC_K21_TO_ARCHIVE @Matchid=" + cbMatches.SelectedValue, 1);
                if (dt.Rows.Count > 0)
                {

                    lblTeamAScore.Text = dt.Rows[0]["K21TeamAPoints"].ToString();
                    lblTeamBScore.Text = dt.Rows[0]["K21TeamBPoints"].ToString();
                    lblTeamA.Text = dt.Rows[0]["TeamA"].ToString();
                    lblTeamB.Text = dt.Rows[0]["TeamB"].ToString();
                    lblTeamA2.Text = dt.Rows[0]["TeamA"].ToString();
                    lblTeamB2.Text = dt.Rows[0]["TeamB"].ToString();
                    lblTeamAScore2.Text = dt.Rows[0]["ArchiveTeamAPoints"].ToString();
                    lblTeamBScore2.Text = dt.Rows[0]["ArchiveTeamBPoints"].ToString();

                    lblStatus.Text = "Sync Success - Last Update on " + DateTime.Now.ToString();
                    lblStatus.ForeColor = Color.Green;
                }
            }
            catch
            {
                lblStatus.Text = "Sync Failed - Last Update on " + DateTime.Now.ToString();
                lblStatus.ForeColor = Color.Red;
            }
        }

        private void frmArchiveSync_Load(object sender, EventArgs e)
        {
            lblTeamAScore.Text = "";
            lblTeamBScore.Text = "";
            lblTeamAScore2.Text = "";
            lblTeamBScore2.Text = "";
            lblTeamA2.Text = "";
            lblTeamA.Text = "";
            lblTeamB2.Text = "";
            lblTeamB.Text = "";



            BindData();
            pageload = true;
        }
        void BindData()
        {
            cbCompetition.DataSource = objMB.ExeQueryStrRetDTBL("Select CompID ID,Name from Competition  Where SportID=" + mycommon.SportID + " ORDER BY CompID DESC", 1);
            cbCompetition.DisplayMember = "Name";
            cbCompetition.ValueMember = "ID";
            cbCompetition.SelectedIndex = -1;
        }

        private void cbCompetition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageload) { return; }
            bindMatches(" Where CompetitionID=" + cbCompetition.SelectedValue);
        }
        void bindMatches(string Filter)
        {
            pageload = false;
            cbMatches.DataSource = objMB.ExeQueryStrRetDTBL("Select MatchID,CAST(MatchID As Varchar)+' - '+dbo.fn_GetMatchNamePreDate_KB(MatchId)Name from KB_Matches " + Filter + " Order by MatchID desc", 1);
            cbMatches.DisplayMember = "Name";
            cbMatches.ValueMember = "MatchID";
            cbMatches.SelectedIndex = -1;
            pageload = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer.Interval = 30000;
            timer.Tick += Timer_Tick;
            timer.Start();
            btnStop.Enabled = true;
            btnStart.Enabled = false;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }
    }
}
