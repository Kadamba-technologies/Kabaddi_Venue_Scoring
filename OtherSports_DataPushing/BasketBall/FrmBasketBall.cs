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
using System.Windows.Threading;

namespace OtherSports_DataPushing
{
    public partial class FrmBasketBall : Form
    {
        SendtoViz ObjFndCtrl = new SendtoViz();
        BusinessLy objMB = new BusinessLy();
        DataTable DT;
        Boolean pageload = false;
        int temp = 0, QuarCount = 0, teamAPoint = 0, teamBPoint = 0, TeamAPlayer = 0, TeamBplayer = 0, Pointid = 0, totalAscore = 0, totalBscore = 0;
        int outplayerid = 0;
        int time = 0, shottime = 24;
        int elapsedtime = 900;
        DataTable dtTeamA = new DataTable();
        DataTable dtTeamB = new DataTable();
        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer Shottimer = new DispatcherTimer();
        public FrmBasketBall()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            Shottimer.Interval = TimeSpan.FromSeconds(1);
            Shottimer.Tick += Shottimer_Tick;
        }

        private void Shottimer_Tick(object sender, EventArgs e)
        {
            shottime--;
            if (shottime >= 0)
            {
                lblshotclock.Text = Convert.ToString(shottime);
            }
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            time++;
            elapsedtime--;
            if (time <= 900)
                lblMatchTime.Text = TimeSpan.FromSeconds(Convert.ToDouble(time)).ToString(@"mm\:ss");
            if (elapsedtime >= 0)
                lblElapseTime.Text = TimeSpan.FromSeconds(Convert.ToDouble(elapsedtime)).ToString(@"mm\:ss");
            retriveVizSend();
        }
        private void btnTimerReset_Click(object sender, EventArgs e)
        {
            timer.Stop();
            time = 0; elapsedtime = 900;
            lblMatchTime.Text = TimeSpan.FromSeconds(Convert.ToDouble(0.0)).ToString(@"mm\:ss");
            lblElapseTime.Text = TimeSpan.FromSeconds(Convert.ToDouble(0.0)).ToString(@"mm\:ss");
        }

        private void btnTimerOff_Click(object sender, EventArgs e)
        {
            timer.Stop();
            Shottimer.Stop();
        }

        private void btnTimerOn_Click(object sender, EventArgs e)
        {
            timer.Start();
            Shottimer.Start();
        }

        private void btnInnStart_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Quarter Started");
                QuarCount = objMB.ExeQueryStrIntBL("Select Isnull(Max(QuarterID),0)+1 From BB_MatchQuarters Where MatchID=" + mycommon.MatchId + "", 1);
                if (QuarCount <= 4)
                {
                    if (objMB.ExeQueryRetBooDL("Insert Into BB_MatchQuarters(MatchId,QuarterID,TeamA,QuarStart,QuarEnd,StartTime,EndTime) Values (" + mycommon.MatchId + "," + QuarCount + "," + mycommon.TeamID1 + ",1,0,'" + DateTime.Now + "',0)", 1))
                    {
                        if (objMB.ExeQueryRetBooDL("Insert Into BB_MatchQuarters(MatchId,QuarterID,TeamB,QuarStart,QuarEnd,StartTime,EndTime) Values (" + mycommon.MatchId + "," + QuarCount + "," + mycommon.TeamID2 + ",1,0,'" + DateTime.Now + "',0)", 1))
                        {
                        }
                    }
                }
            }
            catch { }
            btnInnStart.Enabled = false;
            btnInnEnd.Enabled = true;
            pnlbtns.Enabled = true;
            timer.Start();
            Shottimer.Start();
            btnenable();
            mycommon.Team1Score = 0;
            mycommon.Team2Score = 0; 
            retriveVizSend();
        }

        private void btnInnEnd_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Set Compeleted", mycommon.ApplicationName + " Info", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (Result == DialogResult.Yes)
            {
            }
            else if (Result == DialogResult.No)
            {
                return;
            }
            else
            {
                return;
            }
            btndisable();
            try
            {
                DT = new DataTable();
                // DT = objMB.ExeQueryStrRetDTBL("Select TeamAScore AScore,TeamBScore BScore from PointCard Where MatchID=" + CommonCls.MatchId + " And SetId=" + SetCount + "Order by PointId desc", 1);
                DT = objMB.ExeQueryStrRetDTBL("Select TeamAPoint as AScore,TeamBPoint as BScore from BB_Events Where MatchID=" + mycommon.MatchId + " And QuarterID=" + QuarCount + "order by PointID DESC", 1);
                if (DT.Rows.Count > 0)
                {
                    mycommon.Team1Score = Convert.ToInt32(DT.Rows[0]["AScore"].ToString());
                    mycommon.Team2Score = Convert.ToInt32(DT.Rows[0]["BScore"].ToString());
                }

                if (objMB.ExeQueryStrRetDTBL("Select * from BB_MatchQuarters Where MatchId=" + mycommon.MatchId + " And QuarterID=" + QuarCount + "", 1).Rows.Count > 0)
                {
                    if (objMB.ExeQueryRetBooDL("Update BB_MatchQuarters Set EndTime='" + DateTime.Now + "',QuarEnd=1,Timer='" + time + "' Where MatchId=" + mycommon.MatchId + " And QuarterID=" + QuarCount + " And TeamA=" + mycommon.TeamID1 + "", 1))
                    {
                        if (objMB.ExeQueryRetBooDL("Update BB_MatchQuarters Set EndTime='" + DateTime.Now + "',QuarEnd=1,Timer='" + time + "' Where MatchId=" + mycommon.MatchId + " And QuarterID=" + QuarCount + " And TeamB=" + mycommon.TeamID2 + "", 1))
                        {

                        }
                    }
                }
                else
                {
                    if (objMB.ExeQueryRetBooDL("Insert Into BB_MatchQuarters(MatchId,QuarterID,TeamA,QuarStart,QuarEnd,StartTime,EndTime) Values (" + mycommon.MatchId + "," + QuarCount + "," + mycommon.TeamID1 + ",1,0,'" + DateTime.Now + "',0)", 1))
                    {
                    }
                    if (objMB.ExeQueryRetBooDL("Insert Into BB_MatchQuarters(MatchId,QuarterID,TeamB,QuarStart,QuarEnd,StartTime,EndTime) Values (" + mycommon.MatchId + "," + QuarCount + "," + mycommon.TeamID2 + ",1,0,'" + DateTime.Now + "',0)", 1))
                    {
                    }
                }
            }
            catch { }
            mycommon.Team1Score = 0;
            mycommon.Team2Score = 0;
            btnInnStart.Enabled = true;
            btnInnEnd.Enabled = false;
            pnlbtns.Enabled = false;
            btnTimerReset.PerformClick();
        }
        void btnenable()
        {
            pnlbtns.Enabled = true;
            btnTimerOn.Enabled = true;
            btnTimerOff.Enabled = true;
            btnTimerReset.Enabled = true;
        }

        void btndisable()
        {
            pnlbtns.Enabled = false;
        }

        private void FrmBasketBall_Load(object sender, EventArgs e)
        {
            mycommon.Team1Score = 0;
            mycommon.Team2Score = 0;
            bindgrid();
            binddata();
            loadlastdata();
            loadscorecard();
            vizGridHeader();
            Loadscore();

            matchstart();
        }
        void matchstart()
        {
            DT = new DataTable();
            DT = objMB.ExeQueryStrRetDTBL("Select * from BB_Matches where Matchid=" + mycommon.MatchId, 1);
            if (DT.Rows.Count > 0)
            {
                mycommon.MatchStart = DT.Rows[0]["EndStatus"].ToString() == "0" ? 1 : 0;
                mycommon.MatchEnd = DT.Rows[0]["EndStatus"].ToString() == "1" ? 1 : 0;
            }
            DataTable DT1 = new DataTable();
            DT1 = objMB.ExeQueryStrRetDTBL("Select ISNULL(MAX(QuarterID),0)QuarterID from BB_MatchQuarters where Matchid=" + mycommon.MatchId + "", 1);
            if (DT1.Rows.Count > 0)
            {
                DT = new DataTable();
                DT = objMB.ExeQueryStrRetDTBL("Select * from BB_MatchQuarters where Matchid=" + mycommon.MatchId + " AND EndTime Not Like '0' and QuarterID=" + DT1.Rows[0][0].ToString(), 1);
                if (DT.Rows.Count > 0)
                {
                    mycommon.GameEnd = 1;
                    btnInnEnd.Enabled = false;
                    mycommon.MatchStart = 0;
                }
                else
                {
                    mycommon.GameEnd = 0;
                    mycommon.MatchStart = 0;
                    btnInnEnd.Enabled = true;
                }

                DT = new DataTable();
                DT = objMB.ExeQueryStrRetDTBL("select * From BB_Events where MatchID=" + mycommon.MatchId + " And QuarterID IN(Select MAX(QuarterID) from BB_MatchQuarters where Matchid=" + mycommon.MatchId + " and EndTime Like '0')", 1);
                if (DT.Rows.Count > 0)
                {
                    mycommon.GameStart = 0;
                    mycommon.MatchStart = 0;
                    btnInnStart.Enabled = false;
                }
                else
                {
                    mycommon.GameStart = 1;
                    mycommon.MatchStart = 0;
                    btnInnStart.Enabled = true;
                }
                if (mycommon.MatchEnd == 1)
                {
                    mycommon.GameStart = 0;
                    mycommon.MatchStart = 0;
                    btnInnStart.Enabled = false;
                    btnInnEnd.Enabled = false;
                    pnlbtns.Enabled = false;
                    btnmatchend.Enabled = false;
                }
            }
        }

        void binddata()
        {
            lblTeam1name.Text = mycommon.Team1Name;
            lblTeam2name.Text = mycommon.Team2Name;
            lblTeamA.Text = mycommon.Team1Name;
            lblTeamB.Text = mycommon.Team2Name;
            try
            {
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                dt1 = objMB.ExeQueryStrRetDTBL("select PlayerID ID,dbo.fn_GetPlayerName(PlayerID) PlayerName from BB_Lineup where MatchID=" + mycommon.MatchId + " AND ClubID=" + mycommon.TeamID1, 1);
                lstA.DataSource = dt1;
                lstA.DisplayMember = "PlayerName";
                lstA.ValueMember = "ID";
                lstA.ClearSelected();
                dt2 = objMB.ExeQueryStrRetDTBL("select PlayerID ID,dbo.fn_GetPlayerName(PlayerID) PlayerName from BB_Lineup where MatchID=" + mycommon.MatchId + " AND ClubID=" + mycommon.TeamID2, 1);
                lstB.DataSource = dt2;
                lstB.DisplayMember = "PlayerName";
                lstB.ValueMember = "ID";
                lstB.ClearSelected();
                DataTable d = new DataTable();
                d = objMB.ExeQueryStrRetDTBL("Select Max(QuarterID) SetID,Max(TeamAPoint) TeamAPoint,Max(TeamBPoint) TeamBPoint,timer From BB_Events Where MatchID=" + mycommon.MatchId + " group by QuarterID order by QuarterID desc", 1);
                if (d.Rows.Count > 0)
                {
                    QuarCount = Convert.ToInt32(d.Rows[0]["SetID"]);
                    mycommon.Team1Score = Convert.ToInt32(d.Rows[0]["TeamAPoint"]);
                    mycommon.Team2Score = Convert.ToInt32(d.Rows[0]["TeamBPoint"]);
                    time = Convert.ToInt32(d.Rows[0]["timer"]);

                }
            }
            catch
            {

            }
        }
        void bindgrid()
        {
            try
            {
                DataTable DT = new DataTable();
                DT = objMB.ExeQueryStrRetDTBL("select MatchID,QuarterID,PointID,TeamAScore,TeamBScore,TeamAPoint,TeamBPoint from BB_Events where MatchID=" + mycommon.MatchId + " order by QuarterID DESC,PointID DESC", 1);
                gvdatagrid.DataSource = DT;
                gvdatagrid.Rows[0].Selected = true;

                mycommon.Team1Score = Convert.ToInt32(DT.Rows[0]["TeamAScore"]);
                mycommon.Team2Score = Convert.ToInt32(DT.Rows[0]["TeamBScore"]);
            }
            catch { }
        }

        void Loadscore()
        {
            try
            {
                DataTable dt4 = new DataTable();
                dt4 = objMB.ExeQueryStrRetDTBL("select Sum(TeamAPoint) Apoint,SUM(TeamBPoint) Bpoint from BB_Events where MatchID=" + mycommon.MatchId, 1);
                if (dt4.Rows.Count > 0)
                {
                    totalAscore = Convert.ToInt32(dt4.Rows[0]["Apoint"]);
                    totalBscore = Convert.ToInt32(dt4.Rows[0]["Bpoint"]);
                }
            }
            catch { }
        }

        void loadlastdata()
        {
            DataTable dtset = new DataTable();
            try
            {
                dtset = objMB.ExeQueryStrRetDTBL("select distinct QuarterID,StartTime,EndTime from BB_MatchQuarters where MatchId=" + mycommon.MatchId + " order by QuarterID DESC", 1);
                if (dtset.Rows.Count > 0)
                {
                    QuarCount = Convert.ToInt32(dtset.Rows[0]["QuarterID"]);
                    if (dtset.Rows[0]["StartTime"].ToString() != "" && dtset.Rows[0]["EndTime"].ToString() == "0")
                    {
                        btnInnStart.Enabled = false;
                        btnInnEnd.Enabled = true;
                        timer.Start();
                    }
                    else if ((dtset.Rows[0]["StartTime"].ToString() == "" && dtset.Rows[0]["EndTime"].ToString() == ""))
                    {
                        btnInnStart.Enabled = true;
                        btnInnEnd.Enabled = false;
                        btndisable();
                    }
                }
                else
                {
                    btnInnStart.Enabled = true;
                    btnInnEnd.Enabled = false;
                    btndisable();
                }
            }
            catch { }
        }
        void loadscorecard()
        {
            txtset1t1.Text = "";
            txtset1t2.Text = "";
            txtset2t1.Text = "";
            txtset2t2.Text = "";
            txtset3t1.Text = "";
            txtset3t2.Text = "";
            txtset4t1.Text = "";
            txtset4t2.Text = "";
            DataTable dt2 = new DataTable();
            dt2 = objMB.ExeQueryStrRetDTBL("Select * From BB_Events where MatchID=" + mycommon.MatchId, 1);
            if (dt2.Rows.Count > 0)
            {
                for (var i = 0; i < dt2.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dt2.Rows[i]["QuarterID"]) == 1)
                    {
                        txtset1t1.Text = Convert.ToString(dt2.Rows[i]["TeamAScore"]);
                        txtset1t2.Text = Convert.ToString(dt2.Rows[i]["TeamBScore"]);
                    }
                    else if (Convert.ToInt32(dt2.Rows[i]["QuarterID"]) == 2)
                    {
                        txtset2t1.Text = Convert.ToString(dt2.Rows[i]["TeamAScore"]);
                        txtset2t2.Text = Convert.ToString(dt2.Rows[i]["TeamBScore"]);
                    }
                    else if (Convert.ToInt32(dt2.Rows[i]["QuarterID"]) == 3)
                    {
                        txtset3t1.Text = Convert.ToString(dt2.Rows[i]["TeamAScore"]);
                        txtset3t2.Text = Convert.ToString(dt2.Rows[i]["TeamBScore"]);
                    }
                    else if (Convert.ToInt32(dt2.Rows[i]["QuarterID"]) == 4)
                    {
                        txtset4t1.Text = Convert.ToString(dt2.Rows[i]["TeamAScore"]);
                        txtset4t2.Text = Convert.ToString(dt2.Rows[i]["TeamBScore"]);
                    }

                }
            }
        }

        private void btnShot_Click(object sender, EventArgs e)
        {
            shottime = 24;
            Shottimer.Start();
            lblshotclock.Text = "24";
            retriveVizSend();
        }
        private void btnPoints_Click(object sender, EventArgs e)
        {
            if (lstB.SelectedItems.Count == 0 && lstA.SelectedItems.Count == 0) { MessageBox.Show("please Select Player.!!"); return; }
            var btnval = ((Button)sender).Name.Split('_')[1];

            if (lstA.SelectedItems.Count > 0)
            {
                TeamAPlayer = Convert.ToInt32(lstA.SelectedValue);
                mycommon.Team1Score += Convert.ToInt32(btnval);
                totalAscore += Convert.ToInt32(btnval);
                teamAPoint = Convert.ToInt32(btnval);
                previousteam = 1;
            }
            else if (lstB.SelectedItems.Count > 0)
            {
                TeamBplayer = Convert.ToInt32(lstB.SelectedValue);
                mycommon.Team2Score += Convert.ToInt32(btnval);
                totalBscore += Convert.ToInt32(btnval);
                teamBPoint = Convert.ToInt32(btnval);
                previousteam = 2;
            }

            try
            {
                Pointid = objMB.ExeQueryStrIntBL("Select Isnull(Max(PointID),0)+1 From BB_Events Where MatchID=" + mycommon.MatchId + " AND QuarterID=" + QuarCount, 1);
                if (objMB.ExeQueryRetBooDL("Insert into BB_Events(MatchID,QuarterID,PointID,TeamAScore,TeamBScore,TeamAPoint,TeamBPoint,TeamAPlayer,TeamBPlayer,timer) values(" + mycommon.MatchId + "," + QuarCount + "," + Pointid + "," + mycommon.Team1Score + "," + mycommon.Team2Score + "," + teamAPoint + "," + teamBPoint + "," + TeamAPlayer + "," + TeamBplayer + "," + time + ")", 1))
                {

                }
            }
            catch { }
            Scorecard();
            bindgrid();
            teamAPoint = 0;
            teamBPoint = 0;
            lstA.ClearSelected();
            lstB.ClearSelected();
            shottime = 24;
            Shottimer.Start();
            btnpointswap.Enabled = true;
        }
        void Scorecard()
        {
            DataTable dt = new DataTable();
            dt = objMB.ExeQueryStrRetDTBL("Select QuarterID,TeamAScore,TeamBScore from BB_Events where MatchID=" + mycommon.MatchId + " order by QuarterID DESC,PointID DESC", 1);

            if (Convert.ToInt32(dt.Rows[0]["QuarterID"]) == 1)
            {
                txtset1t1.Text = mycommon.Team1Score.ToString();
                txtset1t2.Text = mycommon.Team2Score.ToString();
            }
            else if (Convert.ToInt32(dt.Rows[0]["QuarterID"]) == 2)
            {
                txtset2t1.Text = mycommon.Team1Score.ToString();
                txtset2t2.Text = mycommon.Team2Score.ToString();
            }
            else if (Convert.ToInt32(dt.Rows[0]["QuarterID"]) == 3)
            {
                txtset3t1.Text = mycommon.Team1Score.ToString();
                txtset3t2.Text = mycommon.Team2Score.ToString();
            }
            else if (Convert.ToInt32(dt.Rows[0]["QuarterID"]) == 4)
            {
                txtset4t1.Text = mycommon.Team1Score.ToString();
                txtset4t2.Text = mycommon.Team2Score.ToString();
            }
            retriveVizSend();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(gvdatagrid.Rows[0].Cells["QuarterID"].Value) == Convert.ToInt32(gvdatagrid.Rows[1].Cells["QuarterID"].Value))
            {
                if (QuarCount == Convert.ToInt32(gvdatagrid.Rows[0].Cells["QuarterID"].Value))
                {
                    try
                    {
                        int matid = Convert.ToInt32(gvdatagrid.Rows[0].Cells["MatchID"].Value);
                        int Quarid = Convert.ToInt32(gvdatagrid.Rows[0].Cells["QuarterID"].Value);
                        int point = Convert.ToInt32(gvdatagrid.Rows[0].Cells["PointID"].Value);
                        if (objMB.ExeQueryRetBooDL("Delete from BB_Events where MatchID=" + matid + " AND QuarterID=" + Quarid + " AND PointID=" + point, 1))
                        {
                            bindgrid();
                            loadscorecard();
                            Loadscore();
                        }
                    }
                    catch { }
                }
                else
                {
                    MessageBox.Show("That Quarter completed can't delete..!");
                }
            }
            else
            {
                try
                {
                    int matid = Convert.ToInt32(gvdatagrid.Rows[0].Cells["MatchID"].Value);
                    int Quarid = Convert.ToInt32(gvdatagrid.Rows[0].Cells["QuarterID"].Value);
                    int point = Convert.ToInt32(gvdatagrid.Rows[0].Cells["PointID"].Value);
                    if (objMB.ExeQueryRetBooDL("Delete from BB_Events where MatchID=" + matid + " AND QuarterID=" + Quarid + " AND PointID=" + point, 1))
                    {
                        bindgrid();
                        loadscorecard();
                        Loadscore();
                    }
                }
                catch { }
                mycommon.Team1Score = 0;
                mycommon.Team2Score=0;
            }
                retriveVizSend();
        }

        private void btninc_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Name == "btninc")
            {
                shottime += Convert.ToInt32(txtadd.Text);
            }
            else if (((Button)sender).Name == "btndec")
            {
                shottime -= Convert.ToInt32(txtadd.Text);
            }
            retriveVizSend();
        }
        void retriveVizSend()
        {
            //if (CommonCls.EnableSendvizData == 0 || !pageload) { return; }
            try
            {
                VizBasketballSendData viz = new VizBasketballSendData();
                if (viz.TeamAName == "" || viz.TeamAName == null)
                    viz.TeamAName = mycommon.Team1Name;
                if (viz.TeamBName == "" || viz.TeamBName == null)
                    viz.TeamBName = mycommon.Team2Name;
                viz.Timer = lblElapseTime.Text;
                viz.Shottime = Convert.ToString(shottime);
                viz.TeamAScore = Convert.ToString(totalAscore);
                viz.TeamBScore = Convert.ToString(totalBscore);
                viz.QuarterID = Convert.ToString(QuarCount);
                //viz.MatchStart=
                viz.MatchStart = mycommon.MatchStart.ToString();
                viz.MatchEnd = mycommon.MatchEnd.ToString();

                Dtgv1.Rows[0]["QuarterID"] = viz.QuarterID.ToString();
                Dtgv1.Rows[0]["TeamAName1"] = viz.TeamAName.ToString();
                Dtgv1.Rows[0]["TeamBName1"] = viz.TeamBName.ToString();
                Dtgv1.Rows[0]["TeamAscore1"] = viz.TeamAScore.ToString();
                Dtgv1.Rows[0]["TeamBscore1"] = viz.TeamBScore.ToString();
                Dtgv1.Rows[0]["Timer2"] = viz.Timer.ToString();
                Dtgv1.Rows[0]["ShotTimer"] = viz.Shottime.ToString();
                Dtgv1.Rows[0]["MatchStart"] = viz.Shottime.ToString();

                ObjFndCtrl.dgvBasketball.DataSource = Dtgv1;
                ObjFndCtrl.Width = 1149;
                ObjFndCtrl.Height = 120;
                PnlGrid.Controls.Add(ObjFndCtrl);
                ObjFndCtrl.BringToFront();

                try
                {
                    //if ((CommonCls.EnableSendvizData == 1) && PageLoad)
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
            ObjFndCtrl.dgvBasketball.AutoGenerateColumns = false;
            Dtgv1 = new DataTable();
            Dtgv1.Columns.Add("QuarterID");
            Dtgv1.Columns.Add("TeamAName1");
            Dtgv1.Columns.Add("TeamBName1");
            Dtgv1.Columns.Add("TeamAscore1");
            Dtgv1.Columns.Add("TeamBscore1");
            Dtgv1.Columns.Add("Timer2");
            Dtgv1.Columns.Add("ShotTimer");
            Dtgv1.Columns.Add("MatchStart");
            Dtgv1.Rows.Add();
        }

        private void lstA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstA.SelectedIndex > 0)
            {
                lstB.SelectedIndex = -1;
            }
        }

        private void lstB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstB.SelectedIndex > 0)
            {
                lstA.SelectedIndex = -1;
            }
        }

        private void FrmBasketBall_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer.Stop();
        }

        private void btnmatchstart_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Result = MessageBox.Show("Continue to Match Start", mycommon.ApplicationName + " Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (Result == DialogResult.Yes)
                {
                    mycommon.MatchStart = 1;
                    btnmatchstart.Enabled = false;
                    btnmatchend.Enabled = true;
                    btnInnStart.Enabled = true;

                    try
                    {
                        objMB.ExeQueryRetBooDL("Update VB_Matches set EndStatus=0 where Matchid=" + mycommon.MatchId, 1);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                }
                    try
                    {
                        retriveVizSend();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
            }
            catch { }
        }

        private void btnmatchend_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Result = MessageBox.Show("Continue to Match End", mycommon.ApplicationName + " Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (Result == DialogResult.Yes)
                {
                    mycommon.MatchEnd = 1;
                    btnmatchstart.Enabled = false;
                    btnmatchend.Enabled = false;

                    btnInnStart.Enabled = false;
                    btnInnEnd.Enabled = false;

                    try
                    {
                        objMB.ExeQueryRetBooDL("Update VB_Matches set EndStatus=1 where Matchid=" + mycommon.MatchId , 1);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                }
                    try
                    {
                        retriveVizSend();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
            }
            catch { }
        }

        int previousteam = 0;
        private void btnpointswap_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to change points?", mycommon.ApplicationName + " Info", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            { 
                DataTable dt = new DataTable();
                try
                {
                    dt = objMB.ExeQueryStrRetDTBL("select TeamAScore,TeamBScore,TeamAPoint,TeamBPoint,PointID from BB_Events where MatchID="+mycommon.MatchId+" AND QuarterID="+QuarCount+" order by PointID DESC", 1);
                    if (dt.Rows.Count > 0)
                    {
                        int team1point = 0, team2point = 0;
                        int team1 = Convert.ToInt32(dt.Rows[0]["TeamAScore"]);
                        int team2 = Convert.ToInt32(dt.Rows[0]["TeamBScore"]);

                        if (previousteam == 1)
                        {
                            team1point = Convert.ToInt32(dt.Rows[0]["TeamBPoint"]);
                            team2point = Convert.ToInt32(dt.Rows[0]["TeamAPoint"]);
                            team1 = Convert.ToInt32(dt.Rows[0]["TeamAScore"]) - Convert.ToInt32(dt.Rows[0]["TeamAPoint"]);
                            team2 = Convert.ToInt32(dt.Rows[0]["TeamBScore"]) + Convert.ToInt32(dt.Rows[0]["TeamAPoint"]);
                        }
                        else if (previousteam == 2)
                        {
                            team1point = Convert.ToInt32(dt.Rows[0]["TeamBPoint"]);
                            team2point = Convert.ToInt32(dt.Rows[0]["TeamAPoint"]);
                            team2 = Convert.ToInt32(dt.Rows[0]["TeamBScore"]) - Convert.ToInt32(dt.Rows[0]["TeamBPoint"]);
                            team1 = Convert.ToInt32(dt.Rows[0]["TeamAScore"]) + Convert.ToInt32(dt.Rows[0]["TeamBPoint"]);
                        }

                        if (objMB.ExeQueryRetBooDL("update BB_Events set TeamAPoint=" + team1point + " ,TeamBPoint=" + team2point + " ,TeamAScore=" + team1 + " ,TeamBScore=" + team2 + "  where MatchID=" + mycommon.MatchId + " AND QuarterID=" + QuarCount + " AND PointID=" + Convert.ToInt32(dt.Rows[0]["PointID"]), 1))
                        {
                            bindgrid();
                            loadscorecard();
                            Loadscore();
                        }
                    }
                }
                catch { }

                btnpointswap.Enabled = false;
                retriveVizSend();
            }
        }

        private void btnmatchendundo_Click(object sender, EventArgs e)
        {
            btnmatchend.Enabled = true;
            btnInnEnd.Enabled = true;
            pnlbtns.Enabled = true;
        }

    }
}
