using OtherSports_DataPushing.Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtherSports_DataPushing
{
    public partial class FrmBadminton : Form
    {

        SendtoViz ObjFndCtrl = new SendtoViz();
        BusinessLy objMB = new BusinessLy();
        DataTable DT;
        int Playerno = 0;
        int serverid = 0;
        bool PageLoad = false;
        int Pointid = 0;
        int SetCount = 0, PointCount = 0, TeamAPoints = 0, TeamBPoints = 0, Winnerid = 0;
        int rallycount = 0;
        public FrmBadminton()
        {
            InitializeComponent();
            this.Size = new Size(838, 690);
        }

        private void FrmBadminton_Load(object sender, EventArgs e)
        {
            mycommon.Team1Score = 0;
            mycommon.Team2Score = 0;
            PageLoad = false;
            vizGridHeader();
            binddata();

            loadtype();
            loadlastdata();
            txtRally.ReadOnly = true;

            if (objMB.ExeQueryStrIntBL("Select Isnull(Max(SetID),0) From Setcard Where MatchID=" + mycommon.MatchId + "", 1) == 0)
            {
                btnMatchStart.Enabled = true;
                btnGamestart.Enabled = false;
                btnMatchEnd.Enabled = false;
            }
            else
            {
                btnMatchStart.Enabled = false;
                btnMatchEnd.Enabled = true;
                btnGamestart.Enabled = true;
            }
            PageLoad = true;
            clear();
            MatchStart();
            mycommon.pagerefresh = true;
        }

        void MatchStart()
        {

            DT = new DataTable();
            DT = objMB.ExeQueryStrRetDTBL(" Select * from BM_Matches where Matchid=" + mycommon.MatchId, 1);
            if (DT.Rows.Count > 0)
            {
                mycommon.MatchStart = DT.Rows[0]["EndStatus"].ToString() == "0" ? 1 : 0;
                mycommon.MatchEnd = DT.Rows[0]["EndStatus"].ToString() == "1" ? 1 : 0;
            }
            DataTable DT1 = new DataTable();
            DT1 = objMB.ExeQueryStrRetDTBL(" Select ISNULL(MAX(SetID),0)SetID from SetCard where Matchid=" + mycommon.MatchId + "", 1);
            if (DT1.Rows.Count > 0)
            {
                DT = new DataTable();
                DT = objMB.ExeQueryStrRetDTBL("Select * from SetCard where Matchid=" + mycommon.MatchId + " And SetComplete=1 and SetID=" + DT1.Rows[0][0].ToString(), 1);
                if (DT.Rows.Count > 0)
                {
                    mycommon.GameEnd = 1;
                    btngameend.Enabled = false;
                    mycommon.MatchStart = 0;
                    if (DT.Rows[0]["SetID"].ToString() == "3")
                        mycommon.MatchEnd = 1;
                }
                else
                {
                    mycommon.GameEnd = 0;
                    mycommon.MatchStart = 0;
                    if (DT1.Rows[0]["SetID"].ToString() != "0")
                    { btnGamestart.Enabled = false; btngameend.Enabled = true; }
                }

                DT = new DataTable();
                DT = objMB.ExeQueryStrRetDTBL(" select * From BM_Events where MAtchID=" + mycommon.MatchId + " And GameID IN(Select MAX(SetID) from SetCard where Matchid=" + mycommon.MatchId + " and SetComplete=0)", 1);
                if (DT.Rows.Count > 0)
                {
                    mycommon.GameStart = 0;
                    mycommon.MatchStart = 0;
                    btnGamestart.Enabled = false; btngameend.Enabled = true;
                }
                else
                {
                    mycommon.GameStart = 1;
                    mycommon.MatchStart = 0;
                    if (DT1.Rows[0]["SetID"].ToString() != "0")
                    { btnGamestart.Enabled = true; btngameend.Enabled = false; }
                }
                if (objMB.ExeQueryStrRetDTBL("Select * from SetCard where Matchid=" + mycommon.MatchId + " and SetComplete=0", 1).Rows.Count > 0)
                { btnGamestart.Enabled = false; btngameend.Enabled = true; }

                if (mycommon.MatchEnd == 1)
                {
                    mycommon.GameStart = 0;
                    mycommon.MatchStart = 0;
                    mycommon.GameEnd = 0;
                    btnGamestart.Enabled = false;
                    btngameend.Enabled = false;
                    tableLayoutPanel2.Enabled = false;
                    btnMatchEnd.Enabled = false;
                }
            }
            DT = new DataTable();
            mycommon.Team1Setwin = 0;
            mycommon.Team2Setwin = 0;
        }
        void loadtype()
        {
            if (mycommon.Type == "Singles")
            {
                pnlplayersingles.Visible = true;
            }
            else if (mycommon.Type == "Doubles")
            {
                pnlplayerdoubles.Location = new Point(329, 12);
                pnlplayerdoubles.Visible = true;
                pnlplayersingles.Visible = false;
            }
        }
        void loadbtns()
        {
            pnlplayersingles.Enabled = false;
            pnlplayerdoubles.Enabled = false;
            btnshot.Enabled = false;
            tblscoreboard.Enabled = false;
            btninc.Enabled = false;
            btndec.Enabled = false;
            txtRally.Enabled = false;
        }

        void binddata()
        {
            try
            {
                DT = new DataTable();
                DT = objMB.ExeQueryStrRetDTBL("select b.MatchId,MatchType,b.TeamA,b.TeamB,[dbo].[fn_GetPlayerName](LA.PlayerID) PlayerA,[dbo].[fn_GetPlayerName](LB.PlayerID) PlayerB from BM_Matches b join BM_Lineup LA on b.MatchId=LA.MatchId AND b.TeamA=LA.TeamID join BM_Lineup LB on b.MatchId=LB.MatchId AND b.TeamB=LB.TeamID where b.MatchId=" + mycommon.MatchId, 1);
                lblmatchno.Text = mycommon.MatchId.ToString();
                DataTable d1 = new DataTable();
                DataTable d2 = new DataTable();
                d1 = objMB.ExeQueryStrRetDTBL("select PlayerID,[dbo].[fn_GetPlayerName](PlayerID) PlayerName from [dbo].[BM_Lineup] where MatchId=" + mycommon.MatchId + " AND TeamID=" + mycommon.TeamID1, 1);
                d2 = objMB.ExeQueryStrRetDTBL("select PlayerID,[dbo].[fn_GetPlayerName](PlayerID) PlayerName from [dbo].[BM_Lineup] where MatchId=" + mycommon.MatchId + " AND TeamID=" + mycommon.TeamID2, 1);

                if (mycommon.Type == "Singles")
                {
                    lblSt1N.Text = mycommon.Team1Name.ToUpper();
                    lblSt2N.Text = mycommon.Team2Name.ToUpper();
                    lblSt1P.Text = Convert.ToString(d1.Rows[0]["PlayerName"]).ToUpper();
                    lblSt2P.Text = Convert.ToString(d2.Rows[0]["PlayerName"]).ToUpper();
                    lblTeam1name.Text = mycommon.Team1Name.ToUpper();
                    lblTeam2name.Text = mycommon.Team2Name.ToUpper();
                    mycommon.PlayerT1AId = Convert.ToInt32(d1.Rows[0]["PlayerID"]);
                    mycommon.PlayerT2AId = Convert.ToInt32(d2.Rows[0]["PlayerID"]);
                }
                else if (mycommon.Type == "Doubles")
                {
                    lblDt1N.Text = mycommon.Team1Name.ToUpper();
                    lblDt2N.Text = mycommon.Team2Name.ToUpper();
                    lblDt1P1.Text = Convert.ToString(d1.Rows[0]["PlayerName"]).ToUpper();
                    lblDt1P2.Text = Convert.ToString(d1.Rows[1]["PlayerName"]).ToUpper();
                    lblDt2P1.Text = Convert.ToString(d2.Rows[0]["PlayerName"]).ToUpper();
                    lblDt2P2.Text = Convert.ToString(d2.Rows[1]["PlayerName"]).ToUpper();
                    lblTeam1name.Text = mycommon.Team1Name.ToUpper();
                    lblTeam2name.Text = mycommon.Team2Name.ToUpper();
                    mycommon.PlayerT1AId = Convert.ToInt32(d1.Rows[0]["PlayerID"]);
                    mycommon.PlayerT1BId = Convert.ToInt32(d1.Rows[1]["PlayerID"]);
                    mycommon.PlayerT2AId = Convert.ToInt32(d2.Rows[0]["PlayerID"]);
                    mycommon.PlayerT2BId = Convert.ToInt32(d2.Rows[1]["PlayerID"]);
                }

                DataTable Dt = new DataTable();
                gvdatabind.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                Dt = objMB.ExeQueryStrRetDTBL("select GameID,PointID,WinnerID WonID,ServerID Serid,dbo.[fn_GetTeamName](WinnerID) WinnerID,dbo.[fn_GetTeamName](ServerID) ServerID,TeamAPoint,TeamBPoint from BM_Events where MatchID=" + mycommon.MatchId + " order by GameID DESC,PointID DESC", 1);
                gvdatabind.AutoGenerateColumns = false;
                gvdatabind.DataSource = Dt;
                SetCount = objMB.ExeQueryStrIntBL("Select Max(SetID) From Setcard Where MatchID=" + mycommon.MatchId, 1);
                //SetCount = objMB.ExeQueryStrIntBL("Select Max(GameID) From BM_Events Where MatchID=" + mycommon.MatchId, 1);
                if (Dt.Rows.Count > 0)
                {
                    if (Convert.ToInt32(Dt.Rows[0]["WonID"]) == mycommon.TeamID1)
                    {
                        rbSt1.Checked = true;
                        rbDt1.Checked = true;
                    }
                    else if (Convert.ToInt32(Dt.Rows[0]["WonID"]) == mycommon.TeamID2)
                    {
                        rbSt2.Checked = true;
                        rbDt2.Checked = true;
                    }
                }
            }
            catch
            {

            }
        }

        void loadlastdata()
        {
            DataTable dtset = new DataTable();
            try
            {
                dtset = objMB.ExeQueryStrRetDTBL("select distinct SetId,StartTime,EndTime from Setcard where MatchId=" + mycommon.MatchId + " order by SetId DESC", 1);
                if (dtset.Rows.Count > 0)
                {
                    SetCount = Convert.ToInt32(dtset.Rows[0]["SetId"]);
                    if (dtset.Rows[0]["StartTime"].ToString() != "" && dtset.Rows[0]["EndTime"].ToString() == "")
                    {
                        btnGamestart.Enabled = false;
                        btngameend.Enabled = true;
                    }
                    else if ((dtset.Rows[0]["StartTime"].ToString() == "" && dtset.Rows[0]["EndTime"].ToString() == ""))
                    {
                        btnGamestart.Enabled = true;
                        btngameend.Enabled = false;
                        loadbtns();
                    }
                }
                else
                {
                    btnGamestart.Enabled = true;
                    btngameend.Enabled = false;
                    loadbtns();
                }
            }
            catch { }
            DataTable dt2 = new DataTable();
            //            dt2 = objMB.ExeQueryStrRetDTBL("Select * From BM_Events where MatchID=" + mycommon.MatchId, 1);
            dt2 = objMB.ExeQueryStrRetDTBL("Select GameID,MAX(TeamAPoint)TeamAPoint ,MAX(TeamBPoint)TeamBPoint From BM_Events where MatchID=" + mycommon.MatchId + " Group by GameID", 1);
            if (dt2.Rows.Count > 0)
            {
                // serverid = Convert.ToInt32(dt2.Rows[0]["ServerID"]);
                for (var i = 0; i < dt2.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dt2.Rows[i]["GameID"]) == 1)
                    {
                        txtset1t1.Text = Convert.ToString(dt2.Rows[i]["TeamAPoint"]);
                        mycommon.Team1Score = Convert.ToInt32(dt2.Rows[i]["TeamAPoint"]);
                        txtset1t2.Text = Convert.ToString(dt2.Rows[i]["TeamBPoint"]);
                        mycommon.Team2Score = Convert.ToInt32(dt2.Rows[i]["TeamBPoint"]);
                    }
                    else if (Convert.ToInt32(dt2.Rows[i]["GameID"]) == 2)
                    {
                        txtset2t1.Text = Convert.ToString(dt2.Rows[i]["TeamAPoint"]);
                        mycommon.Team1Score = Convert.ToInt32(dt2.Rows[i]["TeamAPoint"]);
                        txtset2t2.Text = Convert.ToString(dt2.Rows[i]["TeamBPoint"]);
                        mycommon.Team2Score = Convert.ToInt32(dt2.Rows[i]["TeamBPoint"]);
                    }
                    else if (Convert.ToInt32(dt2.Rows[i]["GameID"]) == 3)
                    {
                        txtset3t1.Text = Convert.ToString(dt2.Rows[i]["TeamAPoint"]);
                        mycommon.Team1Score = Convert.ToInt32(dt2.Rows[i]["TeamAPoint"]);
                        txtset3t2.Text = Convert.ToString(dt2.Rows[i]["TeamBPoint"]);
                        mycommon.Team2Score = Convert.ToInt32(dt2.Rows[i]["TeamBPoint"]);
                    }
                }
                if (SetCount == 2 && dt2.Rows.Count == 1)
                {
                    txtset2t1.Text = "0";
                    mycommon.Team1Score = 0;
                    txtset2t2.Text = "0";
                    mycommon.Team2Score = 0;
                }
                else if (SetCount == 3 && dt2.Rows.Count == 2)
                {
                    txtset3t1.Text = "0";
                    mycommon.Team1Score = 0;
                    txtset3t2.Text = "0";
                    mycommon.Team2Score = 0;
                }
            }
            else
            {
                txtset1t1.Text = "0";
                mycommon.Team1Score = 0;
                txtset1t2.Text = "0";
                mycommon.Team2Score = 0;
            }

        }

        void clear()
        {
            //rbSt1.Checked = false;
            //rbSt2.Checked = false;
            txtRally.Text = "0";
            rallycount = 0;

            mycommon.pagerefresh = false;
            mycommon.GameStart = 0;
            mycommon.GameEnd = 0;
            mycommon.MatchStart = 0;
            mycommon.MatchEnd = 0;
        }
        private void btnWinner_Click(object sender, EventArgs e)
        {
            lblerror.Text = "";
            if (!rbSt1.Checked && !rbSt2.Checked)
            {
                lblerror.Visible = true;
                lblerror.Text = "Error!! please select the Server";
                return;
            }
            if (rbSt1.Checked)
            {
                serverid = mycommon.PlayerT1AId;
            }
            else if (rbSt2.Checked)
            {
                serverid = mycommon.PlayerT2AId;
            }
            if (Convert.ToString(((Button)sender).Name) == "btnSt1winner")
            {
                Winnerid = mycommon.TeamID1;
                previouspoint = 1;
                mycommon.Team1Score += 1;
            }
            else if (Convert.ToString(((Button)sender).Name) == "btnSt2winner")
            {
                Winnerid = mycommon.TeamID2;
                mycommon.Team2Score += 1;
                previouspoint = 2;
            }
            try
            {
                Pointid = objMB.ExeQueryStrIntBL("Select Isnull(Max(PointID),0)+1 From BM_Events Where MatchID=" + mycommon.MatchId + " AND GameID=" + SetCount, 1);
                if (objMB.ExeQueryRetBooDL("Insert into BM_Events(MatchID,GameID,PointID,ServerID,WinnerID,RallyCount,TeamAPoint,TeamBPoint) values(" + mycommon.MatchId + "," + SetCount + "," + Pointid + "," + serverid + "," + Winnerid + "," + (txtRally.Text) + "," + mycommon.Team1Score + "," + mycommon.Team2Score + ")", 1))
                {

                }
            }
            catch { }
            datarefresh();
            clear();
            btnpointswap.Enabled = true;
        }
        void datarefresh()
        {
            DataTable dt1 = new DataTable();
            try
            {
                dt1 = objMB.ExeQueryStrRetDTBL("select GameID,PointID,WinnerID WonID,ServerID Serid,dbo.[fn_GetTeamName](WinnerID) WinnerID,dbo.[fn_GetTeamName](ServerID) ServerID,TeamAPoint,TeamBPoint from BM_Events where MatchID=" + mycommon.MatchId + " order by GameID Desc,PointID Desc", 1);
                gvdatabind.DataSource = dt1;
                gvdatabind.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch { }
            if (Convert.ToInt32(dt1.Rows[0]["WonID"]) != Convert.ToInt32(dt1.Rows[0]["Serid"]))
            {
                if (rbSt1.Checked)
                {
                    rbSt2.Checked = true;
                }
                else if (rbSt2.Checked)
                {
                    rbSt1.Checked = true;
                }
            }

            if (Convert.ToInt32(dt1.Rows[0]["GameID"]) == 1)
            {
                txtset1t1.Text = mycommon.Team1Score.ToString();
                txtset1t2.Text = mycommon.Team2Score.ToString();
            }
            else if (Convert.ToInt32(dt1.Rows[0]["GameID"]) == 2)
            {
                txtset2t1.Text = mycommon.Team1Score.ToString();
                txtset2t2.Text = mycommon.Team2Score.ToString();
            }
            else if (Convert.ToInt32(dt1.Rows[0]["GameID"]) == 3)
            {
                txtset3t1.Text = mycommon.Team1Score.ToString();
                txtset3t2.Text = mycommon.Team2Score.ToString();
            }
            retriveVizSend();
        }

        private void btnWinnerdoubles_Click(object sender, EventArgs e)
        {
            lblerror.Text = "";
            if (!rbDt1.Checked && !rbDt2.Checked)
            {
                lblerror.Visible = true;
                lblerror.Text = "Error!! please select the Server";
                return;
            }
            if (rbDt1.Checked)
            {
                serverid = mycommon.TeamID1;
            }
            else if (rbDt2.Checked)
            {
                serverid = mycommon.TeamID2;
            }

            if (Convert.ToString(((Button)sender).Name) == "btnDt1P1winner" || Convert.ToString(((Button)sender).Name) == "btnDt1P2winner")
            {
                Winnerid = mycommon.TeamID1;
                previouspoint = 1;
                mycommon.Team1Score += 1;
            }
            else if (Convert.ToString(((Button)sender).Name) == "btnDt2P1winner" || Convert.ToString(((Button)sender).Name) == "btnDt2P2winner")
            {
                Winnerid = mycommon.TeamID2;
                previouspoint = 2;
                mycommon.Team2Score += 1;
            }

            try
            {
                Pointid = objMB.ExeQueryStrIntBL("Select Isnull(Max(PointID),0)+1 From BM_Events Where MatchID=" + mycommon.MatchId + " AND GameID=" + SetCount, 1);
                if (objMB.ExeQueryRetBooDL("Insert into BM_Events(MatchID,GameID,PointID,ServerID,WinnerID,RallyCount,TeamAPoint,TeamBPoint) values(" + mycommon.MatchId + "," + SetCount + "," + Pointid + "," + serverid + "," + Winnerid + "," + (txtRally.Text) + "," + mycommon.Team1Score + "," + mycommon.Team2Score + ")", 1))
                {

                }
            }
            catch { }
            datarefreshdoubles();
            clear();
            btnpointswap.Enabled = true;
        }

        void datarefreshdoubles()
        {
            DataTable dt1 = new DataTable();
            dt1 = objMB.ExeQueryStrRetDTBL("select GameID,PointID,WinnerID WonID,ServerID Serid,dbo.[fn_GetTeamName](WinnerID) WinnerID,dbo.[fn_GetTeamName](ServerID) ServerID,TeamAPoint,TeamBPoint from BM_Events where MatchID=" + mycommon.MatchId + " order by GameID Desc,PointID DEsc", 1);
            gvdatabind.DataSource = dt1;
            gvdatabind.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (Convert.ToInt32(dt1.Rows[0]["WonID"]) != serverid)
            {
                if (rbDt1.Checked)
                {
                    rbDt2.Checked = true;
                }
                else if (rbDt2.Checked)
                {
                    rbDt1.Checked = true;
                }
            }

            if (Convert.ToInt32(dt1.Rows[0]["GameID"]) == 1)
            {
                txtset1t1.Text = mycommon.Team1Score.ToString();
                txtset1t2.Text = mycommon.Team2Score.ToString();
            }
            else if (Convert.ToInt32(dt1.Rows[0]["GameID"]) == 2)
            {
                txtset2t1.Text = mycommon.Team1Score.ToString();
                txtset2t2.Text = mycommon.Team2Score.ToString();
            }
            else if (Convert.ToInt32(dt1.Rows[0]["GameID"]) == 3)
            {
                txtset3t1.Text = mycommon.Team1Score.ToString();
                txtset3t2.Text = mycommon.Team2Score.ToString();
            }
            retriveVizSend();
        }

        private void btnshot_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Name == "btndec")
            {
                if (rallycount > 0)
                {
                    rallycount -= 1;
                    txtRally.Text = rallycount.ToString();
                }
            }
            else if (((Button)sender).Name == "btninc")
            {
                rallycount += 1;
                txtRally.Text = rallycount.ToString();
            }
            else if (((Button)sender).Name == "btnshot")
            {
                rallycount += 1;
                txtRally.Text = rallycount.ToString();
            }

        }

        private void btnGamestart_Click(object sender, EventArgs e)
        {
            mycommon.Team1Score = 0;
            mycommon.Team2Score = 0;
            mycommon.GameEnd = 0;
            if (mycommon.Type == "Singles")
            {
                pnlplayersingles.Visible = true;
                pnlplayersingles.BringToFront();
                pnlplayersingles.Enabled = true;
            }
            else if (mycommon.Type == "Doubles")
            {
                pnlplayerdoubles.Visible = true;
                pnlplayerdoubles.BringToFront();
                pnlplayerdoubles.Enabled = true;
            }
            btnshot.Enabled = true;
            tblscoreboard.Enabled = true;
            btninc.Enabled = true;
            btndec.Enabled = true;
            txtRally.Enabled = true;

            SetCount = objMB.ExeQueryStrIntBL("Select Isnull(Max(SetID),0)+1 From Setcard Where MatchID=" + mycommon.MatchId + "", 1);
            if (SetCount <= 3)
            {
                if (objMB.ExeQueryRetBooDL("Insert Into SetCard(MatchId,SetId,StartTime,TeamId,SetScore,SetWinner,SetComplete) Values (" + mycommon.MatchId + "," + SetCount + ",'" + DateTime.Now + "'," + mycommon.TeamID1 + ",0,0,0)", 1))
                {
                    if (objMB.ExeQueryRetBooDL("Insert Into SetCard(MatchId,SetId,StartTime,TeamId,SetScore,SetWinner,SetComplete) Values (" + mycommon.MatchId + "," + SetCount + ",'" + DateTime.Now + "'," + mycommon.TeamID2 + ",0,0,0)", 1))
                    {
                        mycommon.GameStart = 1;
                    }
                }
            }
            else
            {
                MessageBox.Show("Match Completed.!!"); return;
            }
            btnGamestart.Enabled = false;
            btngameend.Enabled = true;
            retriveVizSend();
        }

        void refresh()
        {

        }

        private void txtRally_TextChanged(object sender, EventArgs e)
        {
            if (txtRally.Text.Length > 0)
            {
                try
                {
                    rallycount = Convert.ToInt32(txtRally.Text);
                }
                catch
                {
                    MessageBox.Show("Please enter a Valid number!");
                }
            }
        }

        private void btngameend_Click(object sender, EventArgs e)
        {
            int Iscompelete = 0, TeamAIsWinner = 0, TeamBIsWinner = 0;
            DialogResult Result = MessageBox.Show("Set Compeleted", "BadMinton Info", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (Result == DialogResult.Yes)
            {
                Iscompelete = 1;
            }
            else if (Result == DialogResult.No)
            {
                Iscompelete = 0;
                return;
            }
            else if (Result == DialogResult.Cancel)
            {
                return;
            }
            mycommon.GameEnd = 1;
            loadbtns();
            txtRally.Text = "0";
            rbSt1.Checked = false;
            rbSt2.Checked = false;
            DT = new DataTable();
            // DT = objMB.ExeQueryStrRetDTBL("Select TeamAScore AScore,TeamBScore BScore from PointCard Where MatchID=" + CommonCls.MatchId + " And SetId=" + SetCount + "Order by PointId desc", 1);
            DT = objMB.ExeQueryStrRetDTBL("Select TeamAPoint as AScore,TeamBPoint as BScore from BM_Events Where MatchID=" + mycommon.MatchId + " And GameID=" + SetCount + " order by PointID DESC", 1);
            if (DT.Rows.Count > 0)
            {
                mycommon.Team1Score = Convert.ToInt32(DT.Rows[0]["AScore"].ToString());
                mycommon.Team2Score = Convert.ToInt32(DT.Rows[0]["BScore"].ToString());
            }

            if (mycommon.Team1Score > mycommon.Team2Score)
            {
                TeamAIsWinner = 1;
                TeamBIsWinner = 0;
            }
            else if (mycommon.Team1Score < mycommon.Team2Score)
            {
                TeamAIsWinner = 0;
                TeamBIsWinner = 1;
            }

            if (objMB.ExeQueryStrRetDTBL("Select * from Setcard Where MatchId=" + mycommon.MatchId + " And SetId=" + SetCount + "", 1).Rows.Count > 0)
            {
                if (objMB.ExeQueryRetBooDL("Update Setcard Set EndTime='" + DateTime.Now + "',SetScore=" + mycommon.Team1Score + " ,SetWinner=" + TeamAIsWinner + ",SetComplete=" + Iscompelete + " Where MatchId=" + mycommon.MatchId + " And SetId=" + SetCount + " And TeamId=" + mycommon.TeamID1 + "", 1))
                {
                    if (objMB.ExeQueryRetBooDL("Update Setcard Set EndTime='" + DateTime.Now + "',SetScore=" + mycommon.Team2Score + " ,SetWinner=" + TeamBIsWinner + ",SetComplete=" + Iscompelete + " Where MatchId=" + mycommon.MatchId + " And SetId=" + SetCount + " And TeamId=" + mycommon.TeamID2 + "", 1))
                    {

                    }
                }
            }
            else
            {
                if (objMB.ExeQueryRetBooDL("Insert Into Setcard(MatchId,SetId,StartTime,EndTime,TeamId,SetScore,SetWinner,SetComplete,Startframe,EndBrame) Values (" + mycommon.MatchId + "," + SetCount + ",'" + DateTime.Now + "','" + DateTime.Now + "'," + mycommon.TeamID1 + "," + mycommon.Team1Score + "," + TeamAIsWinner + "," + Iscompelete + ")", 1))
                {
                }
                if (objMB.ExeQueryRetBooDL("Insert Into Setcard(MatchId,SetId,StartTime,EndTime,TeamId,SetScore,SetWinner,SetComplete,Startframe,EndBrame) Values (" + mycommon.MatchId + "," + SetCount + ",'" + DateTime.Now + "','" + DateTime.Now + "'," + mycommon.TeamID2 + "," + mycommon.Team2Score + "," + TeamBIsWinner + "," + Iscompelete + ")", 1))
                {
                }
            }
            btnGamestart.Enabled = true;
            btngameend.Enabled = false;
            mycommon.Team1Score = 0;
            mycommon.Team2Score = 0;
            rbDt1.Checked = false;
            rbDt2.Checked = false;
            rbSt1.Checked = false;
            rbSt2.Checked = false;
            btnpointswap.Enabled = false;
        }

        private void rbSt1_CheckedChanged(object sender, EventArgs e)
        {
            rbSt2.Checked = !rbSt1.Checked;
            retriveVizSend();
        }
        private void rbSt2_CheckedChanged(object sender, EventArgs e)
        {
            rbSt1.Checked = !rbSt2.Checked;
            retriveVizSend();
        }

        private void rbDt1_CheckedChanged(object sender, EventArgs e)
        {
            rbDt2.Checked = !rbDt1.Checked;
            retriveVizSend();
        }

        private void rbDt2_CheckedChanged(object sender, EventArgs e)
        {
            rbDt1.Checked = !rbDt2.Checked;
            retriveVizSend();
        }

        private void FrmBadminton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                if (rallycount > 0)
                {
                    rallycount -= 1;
                    txtRally.Text = rallycount.ToString();
                }
            }
            else if (e.KeyCode == Keys.Right)
            {
                rallycount += 1;
                txtRally.Text = rallycount.ToString();
            }
        }

        void retriveVizSend()
        {
            if (CommonCls.EnableSendvizData == 0) { return; }
            try
            {
                VizBadmintonSendData viz = new VizBadmintonSendData();
                if (viz.TeamAPrefix == "" || viz.TeamAPrefix == null)
                    viz.TeamAPrefix = mycommon.Team1Prefix;//"BENGALURU";
                if (viz.TeamBPrefix == "" || viz.TeamBPrefix == null)
                    viz.TeamBPrefix = mycommon.Team2Prefix; //"SHIMOGA";
                if (viz.TeamAName == "" || viz.TeamAName == null)
                    viz.TeamAName = mycommon.Team1Name;
                if (viz.TeamBName == "" || viz.TeamBName == null)
                    viz.TeamBName = mycommon.Team2Name;
                viz.TeamASet1Score = txtset1t1.Text;
                viz.TeamBSet1Score = txtset1t2.Text;

                viz.TeamASet2Score = txtset2t1.Text;
                viz.TeamBSet2Score = txtset2t2.Text;

                viz.TeamASet3Score = txtset3t1.Text;
                viz.TeamBSet3Score = txtset3t2.Text;

                viz.TeamASet4Score = "";
                viz.TeamBSet4Score = "";

                viz.TeamASet5Score = "";
                viz.TeamBSet5Score = "";

                viz.GameStart = mycommon.GameStart.ToString();
                viz.GameEnd = mycommon.GameEnd.ToString();
                viz.MatchStart = mycommon.MatchStart.ToString();
                viz.MatchEnd = mycommon.MatchEnd.ToString();

                viz.SetID = SetCount.ToString();

                if (viz.SetID == "1")
                {
                    viz.TeamACurSetScore = txtset1t1.Text;
                    viz.TeamBCurSetScore = txtset1t2.Text;
                }
                else if (viz.SetID == "2")
                {
                    viz.TeamACurSetScore = txtset2t1.Text;
                    viz.TeamBCurSetScore = txtset2t2.Text;
                }
                else if (viz.SetID == "3")
                {
                    viz.TeamACurSetScore = txtset3t1.Text;
                    viz.TeamBCurSetScore = txtset3t2.Text;
                }
                else
                {
                    viz.SetID = "1";
                    viz.TeamACurSetScore = "0";
                    viz.TeamBCurSetScore = "0";
                }

                if (mycommon.Type == "Singles")
                {
                    //viz.TeamAPlayer1 = lblSt1P.Text.ToUpper();
                    //viz.TeamBPlayer1 = lblSt2P.Text.ToUpper();
                    viz.TeamAPlayerfname1 = objMB.ExeQueryStrRetStrBL("select dbo.fn_GetPlayerFirstName(" + mycommon.PlayerT1AId + ")", 1);
                    viz.TeamAPlayerlname1 = objMB.ExeQueryStrRetStrBL("select dbo.fn_GetPlayerLastName(" + mycommon.PlayerT1AId + ")", 1);

                    viz.TeamBPlayerfname1 = objMB.ExeQueryStrRetStrBL("select dbo.fn_GetPlayerFirstName(" + mycommon.PlayerT2AId + ")", 1);
                    viz.TeamBPlayerlname1 = objMB.ExeQueryStrRetStrBL("select dbo.fn_GetPlayerLastName(" + mycommon.PlayerT2AId + ")", 1);
                    viz.TeamAPlayer2 = "";
                    viz.TeamBPlayer2 = "";
                    if (rbSt1.Checked)
                    {
                        viz.TeamAServe = "1";
                        viz.TeamBServe = "0";
                    }
                    else if (rbSt2.Checked)
                    {
                        viz.TeamAServe = "0";
                        viz.TeamBServe = "1";
                    }
                    else
                    {
                        viz.TeamAServe = "0";
                        viz.TeamBServe = "0";
                    }

                    viz.SingleorDouble = "1";
                }
                else if (mycommon.Type == "Doubles")
                {
                    //viz.TeamAPlayer1 = lblDt1P1.Text.ToUpper();
                    //viz.TeamBPlayer1 = lblDt2P1.Text.ToUpper();

                    //viz.TeamAPlayer2 = lblDt1P2.Text.ToUpper();
                    //viz.TeamBPlayer2 = lblDt2P1.Text.ToUpper();

                    viz.TeamAPlayerfname1 = "";
                    viz.TeamAPlayerlname1 = objMB.ExeQueryStrRetStrBL("select dbo.fn_GetPlayerFirstName(" + mycommon.PlayerT1AId + ")", 1);

                    viz.TeamBPlayerfname1 = "";
                    viz.TeamBPlayerlname1 = objMB.ExeQueryStrRetStrBL("select dbo.fn_GetPlayerFirstName(" + mycommon.PlayerT2AId + ")", 1);

                    viz.TeamAPlayer2 = objMB.ExeQueryStrRetStrBL("select dbo.fn_GetPlayerFirstName(" + mycommon.PlayerT1BId + ")", 1);
                    viz.TeamBPlayer2 = objMB.ExeQueryStrRetStrBL("select dbo.fn_GetPlayerFirstName(" + mycommon.PlayerT2BId + ")", 1);

                    if (rbDt1.Checked)
                    {
                        viz.TeamAServe = "1";
                        viz.TeamBServe = "0";
                    }
                    else if (rbDt2.Checked)
                    {
                        viz.TeamAServe = "0";
                        viz.TeamBServe = "1";
                    }
                    else
                    {
                        viz.TeamAServe = "0";
                        viz.TeamBServe = "0";
                    }
                    viz.SingleorDouble = "2";
                }
                if (btnGamestart.Enabled || mycommon.MatchEnd == 1)
                {
                    viz.TeamAServe = "0";
                    viz.TeamBServe = "0";
                }

                Dtgv1.Rows[0]["SetID"] = viz.SetID.ToString();
                Dtgv1.Rows[0]["BadTeamAPrefix"] = viz.TeamAPrefix.ToString();
                Dtgv1.Rows[0]["BadTeamBPrefix"] = viz.TeamBPrefix.ToString();
                Dtgv1.Rows[0]["BadTeamAName"] = viz.TeamAName.ToString();
                Dtgv1.Rows[0]["BadTeamBName"] = viz.TeamBName.ToString();
                Dtgv1.Rows[0]["BadTeamASet1Score"] = viz.TeamASet1Score.ToString();
                Dtgv1.Rows[0]["BadTeamBSet1Score"] = viz.TeamBSet1Score.ToString();
                Dtgv1.Rows[0]["BadTeamASet2Score"] = viz.TeamASet2Score.ToString();
                Dtgv1.Rows[0]["BadTeamBSet2Score"] = viz.TeamBSet2Score.ToString();
                Dtgv1.Rows[0]["BadTeamASet3Score"] = viz.TeamASet3Score.ToString();
                Dtgv1.Rows[0]["BadTeamBSet3Score"] = viz.TeamBSet3Score.ToString();
                Dtgv1.Rows[0]["BadTeamASet4Score"] = viz.TeamASet4Score.ToString();
                Dtgv1.Rows[0]["BadTeamBSet4Score"] = viz.TeamBSet4Score.ToString();
                Dtgv1.Rows[0]["BadTeamASet5Score"] = viz.TeamASet5Score.ToString();
                Dtgv1.Rows[0]["BadTeamBSet5Score"] = viz.TeamBSet5Score.ToString();
                Dtgv1.Rows[0]["BadTeamACurSetScore"] = viz.TeamACurSetScore.ToString();
                Dtgv1.Rows[0]["BadTeamBCurSetScore"] = viz.TeamACurSetScore.ToString();

                Dtgv1.Rows[0]["BadTeamAPlayerfname1"] = viz.TeamAPlayerfname1.ToString();
                Dtgv1.Rows[0]["BadTeamBPlayerfname1"] = viz.TeamBPlayerfname1.ToString();
                Dtgv1.Rows[0]["BadTeamAPlayerlname1"] = viz.TeamAPlayerlname1.ToString();
                Dtgv1.Rows[0]["BadTeamBPlayerlname1"] = viz.TeamBPlayerlname1.ToString();

                Dtgv1.Rows[0]["BadTeamAPlayer2"] = viz.TeamAPlayer2.ToString();
                Dtgv1.Rows[0]["BadTeamBPlayer2"] = viz.TeamBPlayer2.ToString();
                Dtgv1.Rows[0]["BadTeamAServe"] = viz.TeamAServe.ToString();
                Dtgv1.Rows[0]["BadTeamBServe"] = viz.TeamBServe.ToString();
                Dtgv1.Rows[0]["SingleorDouble"] = viz.SingleorDouble.ToString();
                Dtgv1.Rows[0]["GameStart"] = viz.GameStart.ToString();
                Dtgv1.Rows[0]["GameEnd"] = viz.GameEnd.ToString(); ;
                Dtgv1.Rows[0]["MatchStart"] = viz.MatchStart.ToString();
                Dtgv1.Rows[0]["MatchEnd"] = viz.MatchEnd.ToString();
                Dtgv1.Rows[0]["AsetWin"] = viz.TeamACurSetScore.ToString();
                Dtgv1.Rows[0]["BsetWin"] = viz.TeamBCurSetScore.ToString();


                ObjFndCtrl.dgvBadminton.DataSource = Dtgv1;
                ObjFndCtrl.Width = 1149;
                ObjFndCtrl.Height = 120;
                PnlGrid.Controls.Add(ObjFndCtrl);
                ObjFndCtrl.BringToFront();
                try
                {
                    if ((CommonCls.EnableSendvizData == 1) && PageLoad)
                    {
                        ObjFndCtrl.sendScorecard();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            catch { }
        }
        DataTable Dtgv1;
        void vizGridHeader()
        {
            ObjFndCtrl.dgv1.AutoGenerateColumns = false;
            Dtgv1 = new DataTable();
            Dtgv1.Columns.Add("SetID");
            Dtgv1.Columns.Add("BadTeamAName");
            Dtgv1.Columns.Add("BadTeamBName");
            Dtgv1.Columns.Add("BadTeamAPrefix");
            Dtgv1.Columns.Add("BadTeamBPrefix");
            Dtgv1.Columns.Add("BadTeamASet1Score");
            Dtgv1.Columns.Add("BadTeamBSet1Score");
            Dtgv1.Columns.Add("BadTeamASet2Score");
            Dtgv1.Columns.Add("BadTeamBSet2Score");
            Dtgv1.Columns.Add("BadTeamASet3Score");
            Dtgv1.Columns.Add("BadTeamBSet3Score");
            Dtgv1.Columns.Add("BadTeamASet4Score");
            Dtgv1.Columns.Add("BadTeamBSet4Score");
            Dtgv1.Columns.Add("BadTeamASet5Score");
            Dtgv1.Columns.Add("BadTeamBSet5Score");
            Dtgv1.Columns.Add("BadTeamACurSetScore");
            Dtgv1.Columns.Add("BadTeamBCurSetScore");
            Dtgv1.Columns.Add("BadTeamAServe");
            Dtgv1.Columns.Add("BadTeamBServe");
            Dtgv1.Columns.Add("BadTeamAPlayerfname1");
            Dtgv1.Columns.Add("BadTeamBPlayerfname1");
            Dtgv1.Columns.Add("BadTeamAPlayerlname1");
            Dtgv1.Columns.Add("BadTeamBPlayerlname1");
            Dtgv1.Columns.Add("BadTeamAPlayer2");
            Dtgv1.Columns.Add("BadTeamBPlayer2");
            Dtgv1.Columns.Add("SingleorDouble");
            Dtgv1.Columns.Add("GameStart");
            Dtgv1.Columns.Add("GameEnd");
            Dtgv1.Columns.Add("MatchStart");
            Dtgv1.Columns.Add("MatchEnd");
            Dtgv1.Columns.Add("AsetWin");
            Dtgv1.Columns.Add("BsetWin");
            Dtgv1.Rows.Add();
        }

        private void btnMatchStart_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Continue to Match Start", "BadMinton Info", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (Result == DialogResult.Yes)
            {
                mycommon.MatchStart = 1;
                btnMatchStart.Enabled = false;
                btnMatchEnd.Enabled = true;
                btnGamestart.Enabled = true;

                try
                {
                    objMB.ExeQueryRetBooDL("Update BM_Matches set EndStatus=0 where Matchid=" + mycommon.MatchId, 1);
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }
            retriveVizSend();
        }

        private void btnMatchEnd_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Continue to Match End", "BadMinton Info", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (Result == DialogResult.Yes)
            {
                mycommon.MatchEnd = 1;
                btnMatchStart.Enabled = false;
                btnMatchEnd.Enabled = false;

                btnGamestart.Enabled = false;
                btngameend.Enabled = false;

                try
                {
                    objMB.ExeQueryRetBooDL("Update BM_Matches set EndStatus=1 where Matchid=" + mycommon.MatchId, 1);
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }
            retriveVizSend();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(gvdatabind.Rows[0].Cells["GameID"].Value) == Convert.ToInt32(gvdatabind.Rows[1].Cells["GameID"].Value))
            {
                if (SetCount == Convert.ToInt32(gvdatabind.Rows[0].Cells["GameID"].Value))
                {
                    try
                    {
                        int matid = mycommon.MatchId;
                        int gameid = Convert.ToInt32(gvdatabind.Rows[0].Cells["GameID"].Value);
                        int point = Convert.ToInt32(gvdatabind.Rows[0].Cells["PointID1"].Value);
                        if (objMB.ExeQueryRetBooDL("Delete from BM_Events where MatchID=" + matid + " AND GameID=" + gameid + " AND PointID=" + point, 1))
                        {
                            binddata();
                            loadlastdata();
                        }
                    }
                    catch { }
                }
                else
                {
                    MessageBox.Show("That Set completed can't delete..!");
                }
            }
            else
            {
                try
                {
                    int matid = mycommon.MatchId;
                    int gameid = Convert.ToInt32(gvdatabind.Rows[0].Cells["GameID"].Value);
                    int point = Convert.ToInt32(gvdatabind.Rows[0].Cells["PointID1"].Value);
                    if (objMB.ExeQueryRetBooDL("Delete from BM_Events where MatchID=" + matid + " AND GameID=" + gameid + " AND PointID=" + point, 1))
                    {
                        binddata();
                        loadlastdata();
                    }
                    mycommon.Team1Score = 0;
                    mycommon.Team2Score = 0;
                }
                catch { }
            }
            retriveVizSend();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clear();
            MatchStart();
            mycommon.pagerefresh = true;
            retriveVizSend();
            mycommon.pagerefresh = false;
        }
        int previouspoint = 0;
        private void btnpointswap_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to change points?", mycommon.ApplicationName + " Info", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                int wonid = 0;
                DataTable dt = new DataTable();
                dt = objMB.ExeQueryStrRetDTBL("select TeamAPoint,TeamBPoint,PointID from BM_Events where MatchID=" + mycommon.MatchId + " AND GameID=" + SetCount + " order by PointID Desc", 1);
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        int team1 = Convert.ToInt32(dt.Rows[0]["TeamAPoint"]);
                        int team2 = Convert.ToInt32(dt.Rows[0]["TeamBPoint"]);
                        if (previouspoint == 1)
                        {
                            team1 = Convert.ToInt32(dt.Rows[0]["TeamAPoint"]) - 1;
                            team2 = Convert.ToInt32(dt.Rows[0]["TeamBPoint"]) + 1;
                            wonid = mycommon.TeamID2;
                        }
                        else if (previouspoint == 2)
                        {
                            team1 = Convert.ToInt32(dt.Rows[0]["TeamAPoint"]) + 1;
                            team2 = Convert.ToInt32(dt.Rows[0]["TeamBpoint"]) - 1;
                            wonid = mycommon.TeamID1;
                        }

                        if (objMB.ExeQueryRetBooDL("update BM_Events set TeamAPoint=" + team1 + ",TeamBPoint=" + team2 + ",WinnerID=" + wonid + " where MatchID=" + mycommon.MatchId + " AND GameID=" + SetCount + " AND PointID=" + Convert.ToInt32(dt.Rows[0]["PointID"]), 1))
                        {
                            binddata();
                            loadlastdata();
                        }
                    }
                    btnpointswap.Enabled = false;
                }
                catch { }
                retriveVizSend();
            }
        }

        private void btnmatchendundo_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Are you sure wants to undo the changes?", "BadMinton Info", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Result == DialogResult.Yes)
            {
                mycommon.MatchEnd = 0;
                btnMatchStart.Enabled = false;
                btnMatchEnd.Enabled = true;

                btnGamestart.Enabled = false;
                btngameend.Enabled = true;
                pnlplayersingles.Enabled = true;
                pnlplayerdoubles.Enabled = true;

                try
                {
                    objMB.ExeQueryRetBooDL("Update BM_Matches set EndStatus=0 where Matchid=" + mycommon.MatchId, 1);
                }
                catch { }
                binddata();
                loadlastdata();
            }
        }

    }
}
