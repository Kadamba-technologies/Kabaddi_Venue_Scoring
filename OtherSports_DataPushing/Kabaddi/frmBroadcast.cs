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
    public partial class frmBroadcast : Form
    {
        BusinessLy objMB = new BusinessLy();
        int ID = 0;
        DataTable DT, Dt;
        Boolean pageload = false, LoadPlayer = false, LoadTeam = false;

        public frmBroadcast()
        {
            InitializeComponent();
        }

        private void frmBroadcast_Load(object sender, EventArgs e)
        {
            bindData();
        }

        void bindData()
        {
            cbCompetition.DataSource = objMB.ExeQueryStrRetDTBL("Select CompID ID,Name from Competition  Where SportID=" + mycommon.SportID + "", 1);
            cbCompetition.DisplayMember = "Name";
            cbCompetition.ValueMember = "ID";
            pageload = true;
            cbCompetition.SelectedValue = CommonCls.CompId;
        }

        private void cbCompetition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageload) { return; }
            bindMatches(" Where CompetitionID=" + cbCompetition.SelectedValue);
        }

        void bindMatches(string Filter)
        {
            pageload = false;
            cbName.DataSource = objMB.ExeQueryStrRetDTBL("Select MatchID,CAST(MatchID As Varchar)+' - '+dbo.fn_GetMatchNamePreDate_KB(MatchId)Name from KB_Matches " + Filter + " Order by MatchID desc", 1);
            cbName.DisplayMember = "Name";
            cbName.ValueMember = "MatchID";
            cbName.SelectedIndex = -1;
            lblName.Visible = true;
            cbName.Visible = true;
            pageload = true;
        }

        private void cbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageload) { return; }
            Dt = new DataTable();
            Dt = objMB.ExeQueryStrRetDTBL("select TeamA TeamAID, dbo.fn_GetTeamName(TeamA)TeamA,TeamB TeamBID,dbo.fn_GetTeamName(TeamB)TeamB From KB_Matches WHERE MatchId=" + cbName.SelectedValue + "", 1);
            lblTeamA.Text = Dt.Rows[0]["TeamA"].ToString();
            lblTeamB.Text = Dt.Rows[0]["TeamB"].ToString();
            lblTeamAID.Text = Dt.Rows[0]["TeamAID"].ToString();
            lblTeamBID.Text = Dt.Rows[0]["TeamBID"].ToString();

            Dt = new DataTable();
            Dt = objMB.ExeQueryStrRetDTBL("Select L.PlayerID,dbo.fn_GetPlayerFullName(L.PlayerID)PlayerName,MAX(P.Player_BroadcastName) BroadcastName,MAX(L.JercyNo)JercyNo from Lineups L LEFT JOIN Player_Broadcast_Master P ON P.playerid=L.PlayerID where MatchID=" + cbName.SelectedValue + " And ClubID=" + lblTeamAID.Text + " Group by L.PlayerID", 1);
            //Select L.PlayerID,dbo.fn_GetPlayerFullName(L.PlayerID)PlayerName,P.Player_BroadcastName BroadcastName,L.JercyNo from Player_Broadcast_Master P RIGHT JOIN Lineups L ON P.playerid=L.PlayerID where Compid=" + cbCompetition.SelectedValue + " and MatchID=" + cbName.SelectedValue + " And ClubID=" + lblTeamAID.Text + "", 1);

            if (Dt.Rows.Count > 0)
            {
                gvTeamADetails.AutoGenerateColumns = false;
                gvTeamADetails.DataSource = Dt;
            }
            else
            {
                Dt = new DataTable();
                Dt = objMB.ExeQueryStrRetDTBL("Select C.PlayerID,dbo.fn_GetPlayerFullName(C.PlayerID)PlayerName,MAX(P.Player_BroadcastName) BroadcastName,MAX(C.JercyNo)JercyNo from CompetitionSquad C LEFT JOIN Player_Broadcast_Master P ON P.playerid=C.PlayerID where C.Compid=" + cbCompetition.SelectedValue + " And TeamID=" + lblTeamAID.Text + " Group by C.PlayerID", 1);
                //Select C.PlayerID,dbo.fn_GetPlayerFullName(C.PlayerID)PlayerName,P.Player_BroadcastName BroadcastName,C.JercyNo from Player_Broadcast_Master P RIGHT JOIN CompetitionSquad C ON P.playerid=C.PlayerID And P.Compid=C.Compid where C.Compid=" + cbCompetition.SelectedValue + " And TeamID=" + lblTeamAID.Text + "", 1);
                gvTeamADetails.AutoGenerateColumns = false;
                gvTeamADetails.DataSource = Dt;
            }

            Dt = new DataTable();
            Dt = objMB.ExeQueryStrRetDTBL("Select L.PlayerID,dbo.fn_GetPlayerFullName(L.PlayerID)PlayerName,MAX(P.Player_BroadcastName) BroadcastName,MAX(L.JercyNo)JercyNo from Lineups L LEFT JOIN Player_Broadcast_Master P ON P.playerid=L.PlayerID where MatchID=" + cbName.SelectedValue + " And ClubID=" + lblTeamBID.Text + " Group by L.PlayerID", 1);
            //Select L.PlayerID,dbo.fn_GetPlayerFullName(L.PlayerID)PlayerName,P.Player_BroadcastName BroadcastName,L.JercyNo from Player_Broadcast_Master P RIGHT JOIN Lineups L ON P.playerid=L.PlayerID where Compid=" + cbCompetition.SelectedValue + " and MatchID=" + cbName.SelectedValue + " And ClubID=" + lblTeamBID.Text + "", 1);

            if (Dt.Rows.Count > 0)
            {
                gvTeamBDetails.AutoGenerateColumns = false;
                gvTeamBDetails.DataSource = Dt;
            }
            else
            {
                Dt = new DataTable();
                Dt = objMB.ExeQueryStrRetDTBL("Select C.PlayerID,dbo.fn_GetPlayerFullName(C.PlayerID)PlayerName,MAX(P.Player_BroadcastName) BroadcastName,MAX(C.JercyNo)JercyNo from CompetitionSquad C LEFT JOIN Player_Broadcast_Master P ON P.playerid=C.PlayerID where C.Compid=" + cbCompetition.SelectedValue + " And TeamID=" + lblTeamBID.Text + " Group by C.PlayerID", 1);
                //Select C.PlayerID,dbo.fn_GetPlayerFullName(C.PlayerID)PlayerName,P.Player_BroadcastName BroadcastName,C.JercyNo from Player_Broadcast_Master P RIGHT JOIN CompetitionSquad C ON P.playerid=C.PlayerID And P.Compid=C.Compid where C.Compid=" + cbCompetition.SelectedValue + " And TeamID=" + lblTeamBID.Text + "", 1);
                gvTeamBDetails.AutoGenerateColumns = false;
                gvTeamBDetails.DataSource = Dt;
            }

        }
    }
}
