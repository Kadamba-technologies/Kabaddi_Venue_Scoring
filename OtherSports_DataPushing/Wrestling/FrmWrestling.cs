using OtherSports_DataPushing.Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace OtherSports_DataPushing.Wrestling
{
    public partial class FrmWrestling : Form
    {
        SendtoViz ObjFndCtrl = new SendtoViz();
        BusinessLy objMB = new BusinessLy();
        int Round = 0;
        DispatcherTimer timer = new DispatcherTimer();
        int Time = 0;


        Stopwatch mySW = new Stopwatch();
        int startoffset = 0;
        private bool _timerRunning = false;
        DateTime Starttime;


        public FrmWrestling()
        {
            InitializeComponent();
        }

        private void BeginLoad()
        {
            lblTeamA.Text = Convert.ToString(mycommon.Team1Name);
            lblTeamB.Text = Convert.ToString(mycommon.Team2Name);


            pnlTeamAPlayer.BackColor = Color.FromName(mycommon.TeamAColor);
            pnlTeamBPlayer.BackColor = Color.FromName(mycommon.TeamBColor);

            if (mycommon.TeamAColor.Length > 0)
                pnlTeamA.BackColor = Color.FromName(mycommon.TeamAColor);
            else
                pnlTeamA.BackColor = Color.Red;
            if (mycommon.TeamBColor.Length > 0)
                pnlTeamB.BackColor = Color.FromName(mycommon.TeamBColor);
            else
                pnlTeamB.BackColor = Color.Blue;


            if (Convert.ToString(mycommon.WWCategory).Equals("1"))
                lblCategory.Text = "Under 17 Boys";
            else if (Convert.ToString(mycommon.WWCategory).Equals("2"))
                lblCategory.Text = "Under 17 Girls";

            //rblPlayerA.Text = Convert.ToString(objMB.ExeQueryStrRetStrBL("SELECT P.FirstName + ' ' + P.LastName AS PlayerName FROM Player_Master P INNER JOIN CompetitionSquad C ON C.PlayerId = P.ID AND C.TeamID = P.TeamID WHERE C.TeamID = " + Convert.ToString(mycommon.TeamID1), 1));
            //rblPlayerB.Text = Convert.ToString(objMB.ExeQueryStrRetStrBL("SELECT P.FirstName + ' ' + P.LastName AS PlayerName FROM Player_Master P INNER JOIN CompetitionSquad C ON C.PlayerId = P.ID AND C.TeamID = P.TeamID WHERE C.TeamID = " + Convert.ToString(mycommon.TeamID2), 1));

            rblPlayerA.Text = Convert.ToString(objMB.ExeQueryStrRetStrBL("SELECT dbo.fn_GetPlayerFullName(P.ID) AS PlayerName FROM Player_Master P WHERE P.ID = (SELECT PlayerID FROM WW_Matches M INNER JOIN WW_Lineup L ON L.MatchID = M.MatchID WHERE M.MatchID = " + mycommon.MatchId + " AND L.ClubID = " + Convert.ToString(mycommon.TeamID1) + ")", 1));
            rblPlayerB.Text = Convert.ToString(objMB.ExeQueryStrRetStrBL("SELECT dbo.fn_GetPlayerFullName(P.ID) AS PlayerName FROM Player_Master P WHERE P.ID = (SELECT PlayerID FROM WW_Matches M INNER JOIN WW_Lineup L ON L.MatchID = M.MatchID WHERE M.MatchID = " + mycommon.MatchId + " AND L.ClubID = " + Convert.ToString(mycommon.TeamID2) + ")", 1));

            lblRound.Text = Convert.ToString(Round);

            BindGridData();

            gbPlayers.Enabled = btn1P.Enabled = btn2P.Enabled = btn3P.Enabled = btn5P.Enabled = btnEnd.Enabled = btnTimerStart.Enabled = btnTimerUpdate.Enabled = btnTimerReset.Enabled = btn1P2.Enabled = btn2P2.Enabled = btn3P2.Enabled = btn5P2.Enabled = btnTimern1.Enabled = btnTimern3.Enabled = btnTimern5.Enabled = btnTimerp1.Enabled = btnTimerp3.Enabled = btnTimerp5.Enabled = btnWonfall.Enabled = false;
            btnStart.Enabled = true;
            BindEnableDisable();
        }

        private void BindGridData()
        {
            //grdData.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            DataTable dt = objMB.ExeQueryStrRetDTBL("SELECT E.ROUNDID [Round],E.POINTID [Point], E.PLAYER_A_POINT [Player 1], E.PLAYER_B_POINT [Player 2], P.FirstName + ' ' + P.LastName [Player Name], E.TEAM_A_SCORE [Team A], E.TEAM_B_SCORE [Team B] FROM WW_Events E INNER JOIN Player_Master P ON P.ID = E.PLAYERID WHERE E.MATCHID = " + mycommon.MatchId + " ORDER BY [Round] DESC, POINTID DESC", 1);
            grdData.DataSource = dt;
        }

        private void BindEnableDisable()
        {
            DataTable dt = new DataTable();
            DataTable dtEve = new DataTable();
            dt = objMB.ExeQueryStrRetDTBL("SELECT * FROM WW_MatchInnings WHERE MatchID = " + mycommon.MatchId + " ORDER BY INSERTID DESC", 1);
            dtEve = objMB.ExeQueryStrRetDTBL("SELECT * FROM WW_Events ORDER BY ROUNDID DESC, POINTID DESC", 1);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.AsEnumerable().FirstOrDefault();
                if (dr != null)
                {
                    if (Convert.ToString(dr["StartTime"]).Length > 0 && Convert.ToString(dr["EndTime"]).Length == 0)
                    {
                        Round = Convert.ToInt32(dr["Rounds"]);
                        lblRound.Text = Convert.ToString(Round);
                        gbPlayers.Enabled = btn1P.Enabled = btn2P.Enabled = btn3P.Enabled = btn5P.Enabled = btnEnd.Enabled = btnTimerStart.Enabled = btnTimerUpdate.Enabled = btnTimerReset.Enabled = btn1P2.Enabled = btn2P2.Enabled = btn3P2.Enabled = btn5P2.Enabled = btnTimern1.Enabled = btnTimern3.Enabled = btnTimern5.Enabled = btnTimerp1.Enabled = btnTimerp3.Enabled = btnTimerp5.Enabled = btnWonfall.Enabled = true;
                        btnStart.Enabled = false;
                        if (dtEve != null && dtEve.Rows.Count > 0)
                        {
                            DataRow drEve = dtEve.AsEnumerable().FirstOrDefault();
                            if (drEve != null)
                            {
                                lblTimer.Text = Convert.ToString(drEve["CurrentTime"]);
                                Time = Convert.ToInt32(TimeSpan.Parse("00:" + lblTimer.Text).TotalSeconds);
                                startoffset = Time;

                                TimeSpan span3 = TimeSpan.FromSeconds(startoffset).Add(mySW.Elapsed);
                                dtp_Clock.Value = DateTime.ParseExact(span3.ToString(@"mm\:ss"), "mm:ss", CultureInfo.InvariantCulture);
                            }
                        }
                        //DataTable dtBind = objMB.ExeQueryStrRetDTBL("SELECT TOP 1 * FROM WW_Events WHERE MATCHID = " + mycommon.MatchId + " AND ROUNDID = " + Round + " ORDER BY POINTID DESC", 1);
                        DataTable dtBind = objMB.ExeQueryStrRetDTBL("SELECT TOP 1 * FROM WW_Events WHERE MATCHID = " + mycommon.MatchId + " ORDER BY POINTID DESC", 1);
                        DataRow drBind = dtBind.AsEnumerable().FirstOrDefault();
                        if (drBind != null)
                        {
                            lblTeamAScore.Text = Convert.ToString(drBind["TEAM_A_SCORE"]);
                            lblTeamBScore.Text = Convert.ToString(drBind["TEAM_B_SCORE"]);
                        }
                        else
                        {
                            lblTeamAScore.Text = "0";
                            lblTeamBScore.Text = "0";
                        }
                    }
                    else
                    {
                        Round = Convert.ToInt32(dr["Rounds"]);
                        lblRound.Text = Convert.ToString(Round);
                        gbPlayers.Enabled = btn1P.Enabled = btn2P.Enabled = btn3P.Enabled = btn5P.Enabled = btnEnd.Enabled = btnTimerStart.Enabled = btnTimerUpdate.Enabled = btnTimerReset.Enabled = btn1P2.Enabled = btn2P2.Enabled = btn3P2.Enabled = btn5P2.Enabled = btnTimern1.Enabled = btnTimern3.Enabled = btnTimern5.Enabled = btnTimerp1.Enabled = btnTimerp3.Enabled = btnTimerp5.Enabled = btnWonfall.Enabled = false;
                        btnStart.Enabled = true;
                    }
                }
            }
        }

        private void UpdateScore(int Point, int Player)
        {
            int scoreDiff = 0;
            if (Convert.ToInt32(lblTeamAScore.Text) > Convert.ToInt32(lblTeamBScore.Text)) { scoreDiff = Convert.ToInt32(lblTeamAScore.Text) - Convert.ToInt32(lblTeamBScore.Text); }
            else if (Convert.ToInt32(lblTeamBScore.Text) > Convert.ToInt32(lblTeamAScore.Text)) { scoreDiff = Convert.ToInt32(lblTeamBScore.Text) - Convert.ToInt32(lblTeamAScore.Text); }
            if (scoreDiff >= 10)
            {
                string message = "Are you sure you want to end this Round?";
                string caption = "End round";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                if (result == DialogResult.Yes)
                {
                    RoundEnds();
                    int InsertID = objMB.ExeQueryStrIntBL("SELECT ISNULL(MAX(INSERTID),0)+1 FROM WW_MatchInnings", 1);
                    bool status = objMB.ExeQueryRetBooDL("INSERT INTO WW_MatchInnings(MatchID,Rounds,TeamA,TeamB,RoundStart,RoundEnd,StartTime,EndTime,Timer,RoundWinner,INSERTID,WonType) VALUES (" + mycommon.MatchId + "," + Round + "," + mycommon.TeamID1 + "," + mycommon.TeamID2 + ",0,1,'','" + DateTime.Now.ToString("h:mm:ss tt") + "','" + dtp_Clock.Value + "',''," + InsertID + ",2)", 1);
                }
                else if (result == DialogResult.No)
                {
                    return;
                }
            }
            else
            {
                int PlayerID = 0;
                if (Player == 1)
                {
                    PlayerID = objMB.ExeQueryStrIntBL("select PlayerID from WW_Lineup where MatchID=" + mycommon.MatchId + " AND CLubID=" + Convert.ToString(mycommon.TeamID1), 1);
                }
                else if (Player == 2)
                {
                    PlayerID = objMB.ExeQueryStrIntBL("select PlayerID from WW_Lineup where MatchID=" + mycommon.MatchId + " AND CLubID=" + Convert.ToString(mycommon.TeamID2), 1);
                }

                int PointID = objMB.ExeQueryStrIntBL("SELECT ISNULL(MAX(POINTID),0)+1 FROM WW_Events", 1);
                int TeamAScore = objMB.ExeQueryStrIntBL("SELECT ISNULL(SUM(PLAYER_A_POINT),0) FROM WW_Events WHERE MATCHID = " + mycommon.MatchId + " --AND ROUNDID = " + Round, 1);
                int TeamBScore = objMB.ExeQueryStrIntBL("SELECT ISNULL(SUM(PLAYER_B_POINT),0) FROM WW_Events WHERE MATCHID = " + mycommon.MatchId + " --AND  ROUNDID = " + Round, 1);

                if (Player == 1)
                {
                    TeamAScore += Point;
                    lblTeamAScore.Text = Convert.ToString(TeamAScore);
                    lblTeamBScore.Text = Convert.ToString(TeamBScore);
                }
                else if (Player == 2)
                {
                    TeamBScore += Point;
                    lblTeamAScore.Text = Convert.ToString(TeamAScore);
                    lblTeamBScore.Text = Convert.ToString(TeamBScore);
                }

                bool status = false;

                if (Player == 1)
                    status = objMB.ExeQueryRetBooDL("INSERT INTO WW_Events (MATCHID,ROUNDID,POINTID,PLAYER_A_POINT,PLAYER_B_POINT,PLAYERID,TEAM_A_SCORE,TEAM_B_SCORE,CurrentTime) VALUES (" + mycommon.MatchId + "," + Round + "," + PointID + "," + Point + ",0," + PlayerID + "," + TeamAScore + "," + TeamBScore + ",'" + lblTimer.Text + "')", 1);
                else if (Player == 2)
                    status = objMB.ExeQueryRetBooDL("INSERT INTO WW_Events (MATCHID,ROUNDID,POINTID,PLAYER_A_POINT,PLAYER_B_POINT,PLAYERID,TEAM_A_SCORE,TEAM_B_SCORE,CurrentTime) VALUES (" + mycommon.MatchId + "," + Round + "," + PointID + ",0," + Point + "," + PlayerID + "," + TeamAScore + "," + TeamBScore + ",'" + lblTimer.Text + "')", 1);
                BindGridData();
                try
                {
                    retriveVizSend();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            btnpointswap.Enabled = true;
            if (undoflag == 1)
            {
                btn1P.Enabled = false;
                btn1P2.Enabled = false;
                btn2P.Enabled = false;
                btn2P2.Enabled = false;
                btn3P.Enabled = false;
                btn3P2.Enabled = false;
                btn5P.Enabled = false;
                btn5P2.Enabled = false;
                undoflag = 0;
            }
        }

        private void btn1P_Click(object sender, EventArgs e)
        {
            UpdateScore(1, 1);
        }

        private void bnt2P_Click(object sender, EventArgs e)
        {
            UpdateScore(2, 1);
        }

        private void btn3P_Click(object sender, EventArgs e)
        {
            UpdateScore(4, 1);
        }

        private void btn5P_Click(object sender, EventArgs e)
        {
            UpdateScore(5, 1);
        }

        private void btn1P2_Click(object sender, EventArgs e)
        {
            UpdateScore(1, 2);
        }

        private void btn3P2_Click(object sender, EventArgs e)
        {
            UpdateScore(4, 2);
        }

        private void btn2P2_Click(object sender, EventArgs e)
        {
            UpdateScore(2, 2);
        }

        private void btn5P2_Click(object sender, EventArgs e)
        {
            UpdateScore(5, 2);
        }

        private void FrmWrestling_Load(object sender, EventArgs e)
        {
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            if (objMB.ExeQueryStrIntBL("Select Isnull(Max(Rounds),0) From WW_MatchInnings Where MatchID=" + mycommon.MatchId + "", 1) == 0)
            {
                btnMatchStart.Enabled = true;
                btnStart.Enabled = false;
                btnEnd.Enabled = false;
            }
            else
            {
                btnMatchStart.Enabled = false;
                btnMatchEnd.Enabled = true;
                btnStart.Enabled = true;
            }
            try
            {
                lblEventName.Text = mycommon.EventName.ToString();
            }
            catch { }
            BeginLoad();
            vizGridHeader();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Round++;
            lblRound.Text = Convert.ToString(Round);
            //lblTeamAScore.Text = lblTeamBScore.Text = "0";
            gbPlayers.Enabled = btn1P.Enabled = btn2P.Enabled = btn3P.Enabled = btn5P.Enabled = btnEnd.Enabled = btnTimerStart.Enabled = btnTimerUpdate.Enabled = btnTimerReset.Enabled = btn1P2.Enabled = btn2P2.Enabled = btn3P2.Enabled = btn5P2.Enabled = btnTimern1.Enabled = btnTimern3.Enabled = btnTimern5.Enabled = btnTimerp1.Enabled = btnTimerp3.Enabled = btnTimerp5.Enabled = btnWonfall.Enabled = true;
            btnStart.Enabled = false;
            int InsertID = objMB.ExeQueryStrIntBL("SELECT ISNULL(MAX(INSERTID),0)+1 FROM WW_MatchInnings", 1);
            bool status = objMB.ExeQueryRetBooDL("INSERT INTO WW_MatchInnings(MatchID,Rounds,TeamA,TeamB,RoundStart,RoundEnd,StartTime,EndTime,Timer,RoundWinner,INSERTID) VALUES (" + mycommon.MatchId + "," + Round + "," + mycommon.TeamID1 + "," + mycommon.TeamID2 + ",1,0,'" + DateTime.Now.ToString("h:mm:ss tt") + "','','" + lblTimer.Text + "',''," + InsertID + ")", 1);
            try
            {
                retriveVizSend();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            MessageBox.Show("Round " + Round + " Starts");
            btnTimerStart_Click(sender, e);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (Time < 360)
            {
                Time++;
                //lblTimer.Text = TimeSpan.FromSeconds(Time).ToString(@"mm\:ss");
                //if (Time == 120)
                //{
                //    timer.Stop();
                //    RoundEnds();
                //    int InsertID = objMB.ExeQueryStrIntBL("SELECT ISNULL(MAX(INSERTID),0)+1 FROM WW_MatchInnings", 1);
                //    bool status = objMB.ExeQueryRetBooDL("INSERT INTO WW_MatchInnings(MatchID,Rounds,TeamA,TeamB,RoundStart,RoundEnd,StartTime,EndTime,Timer,RoundWinner,INSERTID,WonType) VALUES (" + mycommon.MatchId + "," + Round + "," + mycommon.TeamID1 + "," + mycommon.TeamID2 + ",0,1,'','" + DateTime.Now.ToString("h:mm:ss tt") + "','" + lblTimer.Text + "',''," + InsertID + ",1)", 1);
                //}
                //else if (Time == 240)
                //{
                //    timer.Stop();
                //    RoundEnds();
                //    int InsertID = objMB.ExeQueryStrIntBL("SELECT ISNULL(MAX(INSERTID),0)+1 FROM WW_MatchInnings", 1);
                //    bool status = objMB.ExeQueryRetBooDL("INSERT INTO WW_MatchInnings(MatchID,Rounds,TeamA,TeamB,RoundStart,RoundEnd,StartTime,EndTime,Timer,RoundWinner,INSERTID,WonType) VALUES (" + mycommon.MatchId + "," + Round + "," + mycommon.TeamID1 + "," + mycommon.TeamID2 + ",0,1,'','" + DateTime.Now.ToString("h:mm:ss tt") + "','" + lblTimer.Text + "',''," + InsertID + ",1)", 1);
                //}
                //else if (Time == 360)
                //{
                //    timer.Stop();
                //    RoundEnds();
                //    int InsertID = objMB.ExeQueryStrIntBL("SELECT ISNULL(MAX(INSERTID),0)+1 FROM WW_MatchInnings", 1);
                //    bool status = objMB.ExeQueryRetBooDL("INSERT INTO WW_MatchInnings(MatchID,Rounds,TeamA,TeamB,RoundStart,RoundEnd,StartTime,EndTime,Timer,RoundWinner,INSERTID,WonType) VALUES (" + mycommon.MatchId + "," + Round + "," + mycommon.TeamID1 + "," + mycommon.TeamID2 + ",0,1,'','" + DateTime.Now.ToString("h:mm:ss tt") + "','" + lblTimer.Text + "',''," + InsertID + ",1)", 1);
                //}
                //   retriveVizSend();
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            RoundEnds();
            int InsertID = objMB.ExeQueryStrIntBL("SELECT ISNULL(MAX(INSERTID),0)+1 FROM WW_MatchInnings", 1);
            bool status = objMB.ExeQueryRetBooDL("INSERT INTO WW_MatchInnings(MatchID,Rounds,TeamA,TeamB,RoundStart,RoundEnd,StartTime,EndTime,Timer,RoundWinner,INSERTID,WonType) VALUES (" + mycommon.MatchId + "," + Round + "," + mycommon.TeamID1 + "," + mycommon.TeamID2 + ",0,1,'','" + DateTime.Now.ToString("h:mm:ss tt") + "','" + lblTimer.Text + "',''," + InsertID + ",1)", 1);
        }

        private void RoundEnds()
        {
            //timer.Stop();
            //Time = 300;
            lblTimer.Text = TimeSpan.FromSeconds(Time).ToString(@"mm\:ss");
            //string winner = Convert.ToInt32(lblTeamAScore.Text) > Convert.ToInt32(lblTeamBScore.Text) ? objMB.ExeQueryStrRetStrBL("SELECT P.ID AS PlayerID FROM Player_Master P INNER JOIN CompetitionSquad C ON C.PlayerId = P.ID WHERE C.TeamID = " + Convert.ToString(mycommon.TeamID1), 1) : objMB.ExeQueryStrRetStrBL("SELECT P.ID AS PlayerID FROM Player_Master P INNER JOIN CompetitionSquad C ON C.PlayerId = P.ID WHERE C.TeamID = " + Convert.ToString(mycommon.TeamID2), 1);            
            gbPlayers.Enabled = btn1P.Enabled = btn2P.Enabled = btn3P.Enabled = btn5P.Enabled = btnEnd.Enabled = btnTimerStart.Enabled = btnTimerUpdate.Enabled = btnTimerReset.Enabled = btn1P2.Enabled = btn2P2.Enabled = btn3P2.Enabled = btn5P2.Enabled = btnTimern1.Enabled = btnTimern3.Enabled = btnTimern5.Enabled = btnTimerp1.Enabled = btnTimerp3.Enabled = btnTimerp5.Enabled = btnWonfall.Enabled = false;
            btnStart.Enabled = true;
            btnpointswap.Enabled = false;
            MessageBox.Show("Round " + Round + " Ends");
        }
        int StartTime = 0;
        int EndTime = 0;
        private void btnTimerStart_Click(object sender, EventArgs e)
        {
            if (Round == 1)
            { StartTime = 0; EndTime = 120; }
            else if (Round == 2)
            { StartTime = 120; EndTime = 240; }
            else if (Round == 3)
            { StartTime = 240; EndTime = 260; }
            timer.Start();
            if (btnTimerStart.Text == "Timer Start")
            {

                TimeSpan span3 = TimeSpan.FromSeconds(startoffset).Add(mySW.Elapsed);
                dtp_Clock.Value = DateTime.ParseExact(span3.ToString(@"mm\:ss"), "mm:ss", CultureInfo.InvariantCulture);
                mySW.Start();
                ObjFndCtrl.sendWrestlingTimer("CLOCK0*DIRECTION SET UP");
                ObjFndCtrl.sendWrestlingTimer("CLOCK0*TIME SET " + StartTime);
                ObjFndCtrl.sendWrestlingTimer("CLOCK0*LIMIT SET " + EndTime + "");
                ObjFndCtrl.sendWrestlingTimer("CLOCK0 START");

                Timer_MatchClock.Start();
                _timerRunning = true;

                Starttime = DateTime.Now;

                btnTimerStart.Text = "Timer Pause";
            }
            else if (btnTimerStart.Text == "Timer Resume")
            {
                ObjFndCtrl.sendWrestlingTimer("CLOCK0 CONT");
                timer.Start();

                mySW.Start();
                Timer_MatchClock.Start();
                _timerRunning = true;
                btnTimerStart.Text = "Timer Pause";

            }
            else if (btnTimerStart.Text == "Timer Pause")
            {
                ObjFndCtrl.sendWrestlingTimer("CLOCK0 STOP");

                timer.Stop();
                if (_timerRunning)// If the timer is already running
                {
                    Timer_MatchClock.Stop();
                    _timerRunning = false;
                }
                mySW.Stop();
                btnTimerStart.Text = "Timer Resume";
            }
        }

        private void btnTimerReset_Click(object sender, EventArgs e)
        {
            if (Round == 1)
            { StartTime = 0; EndTime = 120; }
            else if (Round == 2)
            { StartTime = 120; EndTime = 240; }
            else if (Round == 3)
            { StartTime = 240; EndTime = 260; }
            timer.Stop();
            Time = 0;
            lblTimer.Text = TimeSpan.FromSeconds(Time).ToString(@"mm\:ss");

            startoffset = EndTime;
            mySW = new Stopwatch();

            TimeSpan span3 = TimeSpan.FromSeconds(startoffset).Add(mySW.Elapsed);
            dtp_Clock.Value = DateTime.ParseExact(span3.ToString(@"mm\:ss"), "mm:ss", CultureInfo.InvariantCulture);

            ObjFndCtrl.sendWrestlingTimer("CLOCK0*DIRECTION SET UP");
            ObjFndCtrl.sendWrestlingTimer("CLOCK0*TIME SET " + StartTime);
            ObjFndCtrl.sendWrestlingTimer("CLOCK0*LIMIT SET " + EndTime + "");
            ObjFndCtrl.sendWrestlingTimer("CLOCK0 STOP");
            //ObjFndCtrl.sendWrestlingTimer("CLOCK0*TIME SET " + startoffset);
        }


        private void btnTimerUpdate_Click(object sender, EventArgs e)
        {

            if (Round == 1)
            { StartTime = 0; EndTime = 120; }
            else if (Round == 2)
            { StartTime = 120; EndTime = 240; }
            else if (Round == 3)
            { StartTime = 240; EndTime = 260; }

            int sec = (dtp_Clock.Value.Minute * 60) + (dtp_Clock.Value.Second);
            startoffset = sec;
            mySW = new Stopwatch();
            //mySW = new Stopwatch(TimeSpan.FromSeconds(1200 - sec));
            //myStopWatch.e

            ObjFndCtrl.sendWrestlingTimer("CLOCK0*DIRECTION SET UP");
            ObjFndCtrl.sendWrestlingTimer("CLOCK0*LIMIT SET " + EndTime);
            ObjFndCtrl.sendWrestlingTimer("CLOCK0 STOP");
            ObjFndCtrl.sendWrestlingTimer("CLOCK0*TIME SET " + sec);
        }

        private void Timer_MatchClock_Tick(object sender, EventArgs e)
        {
            TimeSpan span3 = TimeSpan.FromSeconds(startoffset).Add(mySW.Elapsed);
            if (span3.TotalSeconds <= 1)
            {
                mySW.Stop();
                ObjFndCtrl.sendWrestlingTimer("CLOCK0*TIME SET 0");
                ObjFndCtrl.sendWrestlingTimer("CLOCK0 STOP");
                Timer_MatchClock.Stop();

            }

            lblTimer.Text = TimeSpan.FromSeconds(Time).ToString(@"mm\:ss");
            if (span3.TotalSeconds >= 120 && span3.TotalSeconds < 121)
            {
                ObjFndCtrl.sendWrestlingTimer("CLOCK0 STOP");
                Timer_MatchClock.Stop();
                timer.Stop();
                mySW.Stop();
                //RoundEnds();
                //int InsertID = objMB.ExeQueryStrIntBL("SELECT ISNULL(MAX(INSERTID),0)+1 FROM WW_MatchInnings", 1);
                //bool status = objMB.ExeQueryRetBooDL("INSERT INTO WW_MatchInnings(MatchID,Rounds,TeamA,TeamB,RoundStart,RoundEnd,StartTime,EndTime,Timer,RoundWinner,INSERTID,WonType) VALUES (" + mycommon.MatchId + "," + Round + "," + mycommon.TeamID1 + "," + mycommon.TeamID2 + ",0,1,'','" + DateTime.Now.ToString("h:mm:ss tt") + "','" + lblTimer.Text + "',''," + InsertID + ",1)", 1);
                btnTimerStart.Text = "Timer Start";
            }
            else if (span3.TotalSeconds >= 240 && span3.TotalSeconds < 241)
            {
                ObjFndCtrl.sendWrestlingTimer("CLOCK0 STOP");
                Timer_MatchClock.Stop();
                timer.Stop();
                mySW.Stop();
                //RoundEnds();
                //int InsertID = objMB.ExeQueryStrIntBL("SELECT ISNULL(MAX(INSERTID),0)+1 FROM WW_MatchInnings", 1);
                //bool status = objMB.ExeQueryRetBooDL("INSERT INTO WW_MatchInnings(MatchID,Rounds,TeamA,TeamB,RoundStart,RoundEnd,StartTime,EndTime,Timer,RoundWinner,INSERTID,WonType) VALUES (" + mycommon.MatchId + "," + Round + "," + mycommon.TeamID1 + "," + mycommon.TeamID2 + ",0,1,'','" + DateTime.Now.ToString("h:mm:ss tt") + "','" + lblTimer.Text + "',''," + InsertID + ",1)", 1);
                btnTimerStart.Text = "Timer Start";
            }
            else if (span3.TotalSeconds >= 360 && span3.TotalSeconds < 361)
            {
                ObjFndCtrl.sendWrestlingTimer("CLOCK0 STOP");
                Timer_MatchClock.Stop();
                timer.Stop();
                mySW.Stop();
                //RoundEnds();
                //int InsertID = objMB.ExeQueryStrIntBL("SELECT ISNULL(MAX(INSERTID),0)+1 FROM WW_MatchInnings", 1);
                //bool status = objMB.ExeQueryRetBooDL("INSERT INTO WW_MatchInnings(MatchID,Rounds,TeamA,TeamB,RoundStart,RoundEnd,StartTime,EndTime,Timer,RoundWinner,INSERTID,WonType) VALUES (" + mycommon.MatchId + "," + Round + "," + mycommon.TeamID1 + "," + mycommon.TeamID2 + ",0,1,'','" + DateTime.Now.ToString("h:mm:ss tt") + "','" + lblTimer.Text + "',''," + InsertID + ",1)", 1);
                btnTimerStart.Text = "Timer Start";
            }

            dtp_Clock.Value = DateTime.ParseExact(span3.ToString(@"mm\:ss"), "mm:ss", CultureInfo.InvariantCulture);
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PointID = Convert.ToInt32(grdData.Rows[0].Cells["Point"].Value);
            int RoundID = Convert.ToInt32(grdData.Rows[0].Cells["Round"].Value);
            bool status = objMB.ExeQueryRetBooDL("DELETE FROM WW_Events WHERE MATCHID = " + mycommon.MatchId + " AND ROUNDID = " + RoundID + " AND POINTID = " + PointID, 1);
            //DataTable dt = objMB.ExeQueryStrRetDTBL("SELECT TOP 1 * FROM WW_Events WHERE MATCHID = " + mycommon.MatchId + " AND ROUNDID = " + Round + " ORDER BY POINTID DESC", 1);
            DataTable dt = objMB.ExeQueryStrRetDTBL("SELECT TOP 1 * FROM WW_Events WHERE MATCHID = " + mycommon.MatchId + " ORDER BY POINTID DESC", 1);
            DataRow dr = dt.AsEnumerable().FirstOrDefault();
            if (dr != null)
            {
                lblTeamAScore.Text = Convert.ToString(dr["TEAM_A_SCORE"]);
                lblTeamBScore.Text = Convert.ToString(dr["TEAM_B_SCORE"]);
            }
            else
            {
                lblTeamAScore.Text = "0";
                lblTeamBScore.Text = "0";
            }
            if (status) { MessageBox.Show("Record deleted successfully."); BindGridData(); } else { MessageBox.Show("Record deletion failed"); }
            try
            {
                retriveVizSend();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnTimern1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            timer.Stop();
            switch (Convert.ToString(btn.Name))
            {
                case "btnTimern1":
                    Time -= 2;
                    break;
                case "btnTimern3":
                    Time -= 4;
                    break;
                case "btnTimern5":
                    Time -= 6;
                    break;
            };
            timer.Start();
        }

        private void btnTimerp1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            timer.Stop();
            switch (Convert.ToString(btn.Name))
            {
                case "btnTimerp1":
                    Time += 0;
                    break;
                case "btnTimerp3":
                    Time += 2;
                    break;
                case "btnTimerp5":
                    Time += 4;
                    break;
            };
            timer.Start();
        }

        private void btnWonfall_Click(object sender, EventArgs e)
        {
            RoundEnds();
            int InsertID = objMB.ExeQueryStrIntBL("SELECT ISNULL(MAX(INSERTID),0)+1 FROM WW_MatchInnings", 1);
            bool status = objMB.ExeQueryRetBooDL("INSERT INTO WW_MatchInnings(MatchID,Rounds,TeamA,TeamB,RoundStart,RoundEnd,StartTime,EndTime,Timer,RoundWinner,INSERTID,WonType) VALUES (" + mycommon.MatchId + "," + Round + "," + mycommon.TeamID1 + "," + mycommon.TeamID2 + ",0,1,'','" + DateTime.Now.ToString("h:mm:ss tt") + "','" + lblTimer.Text + "',''," + InsertID + ",3)", 1);
        }

        void retriveVizSend()
        {
            //if (CommonCls.EnableSendvizData == 0 || !pageload) { return; }
            try
            {
                VizBasketballSendData viz = new VizBasketballSendData();
                if (viz.TeamAName == "" || viz.TeamAName == null)
                    viz.TeamAName = rblPlayerA.Text;
                if (viz.TeamBName == "" || viz.TeamBName == null)
                    viz.TeamBName = rblPlayerB.Text;
                viz.TeamAPrefix = mycommon.Team1Prefix == null ? "" : mycommon.Team1Prefix;
                viz.TeamBPrefix = mycommon.Team2Prefix == null ? "" : mycommon.Team2Prefix;
                viz.Timer = lblTimer.Text;
                viz.TeamAScore = Convert.ToString(lblTeamAScore.Text);
                viz.TeamBScore = Convert.ToString(lblTeamBScore.Text);
                viz.QuarterID = Convert.ToString((Round == 0 ? 1 : Round));
                //viz.MatchStart=

                Dtgv1.Rows[0]["QuarterID"] = viz.QuarterID.ToString();
                Dtgv1.Rows[0]["TeamAName1"] = viz.TeamAName.ToString() + (mycommon.TeamAColor != "" ? " (" + mycommon.TeamAColor + ")" : "");
                Dtgv1.Rows[0]["TeamBName1"] = viz.TeamBName.ToString() + (mycommon.TeamBColor != "" ? " (" + mycommon.TeamBColor + ")" : "");
                Dtgv1.Rows[0]["TeamAscore1"] = viz.TeamAScore.ToString();
                Dtgv1.Rows[0]["TeamBscore1"] = viz.TeamBScore.ToString();
                Dtgv1.Rows[0]["Timer2"] = viz.Timer.ToString();
                Dtgv1.Rows[0]["TeamAPrefix"] = viz.TeamAPrefix.ToString();
                Dtgv1.Rows[0]["TeamBPrefix"] = viz.TeamBPrefix.ToString();

                ObjFndCtrl.dgvBasketball.DataSource = Dtgv1;
                ObjFndCtrl.Width = 1149;
                ObjFndCtrl.Height = 120;
                pnlgrid.Controls.Add(ObjFndCtrl);
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
            Dtgv1.Columns.Add("TeamAPrefix");
            Dtgv1.Columns.Add("TeamBPrefix");
            Dtgv1.Columns.Add("MatchStart");
            Dtgv1.Rows.Add();
        }

        private void btnMatchStart_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Result = MessageBox.Show("Continue to Match Start", "Wrestling Info", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (Result == DialogResult.Yes)
                {
                    mycommon.MatchStart = 1;
                    btnMatchStart.Enabled = false;
                    btnMatchEnd.Enabled = true;
                    btnStart.Enabled = true;

                }
                ObjFndCtrl.sendWrestlingTimer("CLOCK0*DIRECTION SET UP");
                ObjFndCtrl.sendWrestlingTimer("CLOCK0*TIME SET " + StartTime);
                ObjFndCtrl.sendWrestlingTimer("CLOCK0*LIMIT SET " + EndTime + "");
                ObjFndCtrl.sendWrestlingTimer("CLOCK0 START");
                try
                {
                    retriveVizSend();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void btnMatchEnd_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Continue to Match End", "Wrestling Info", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (Result == DialogResult.Yes)
            {
                mycommon.MatchEnd = 1;
                btnMatchStart.Enabled = false;
                btnMatchEnd.Enabled = false;

                btnStart.Enabled = false;
                btnEnd.Enabled = false;
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                rblPlayerA.Text = Convert.ToString(objMB.ExeQueryStrRetStrBL("SELECT dbo.fn_GetPlayerFullName(P.ID) AS PlayerName FROM Player_Master P WHERE P.ID = (SELECT PlayerID FROM WW_Matches M INNER JOIN WW_Lineup L ON L.MatchID = M.MatchID WHERE M.MatchID = " + mycommon.MatchId + " AND L.ClubID = " + Convert.ToString(mycommon.TeamID1) + ")", 1));
                rblPlayerB.Text = Convert.ToString(objMB.ExeQueryStrRetStrBL("SELECT dbo.fn_GetPlayerFullName(P.ID) AS PlayerName FROM Player_Master P WHERE P.ID = (SELECT PlayerID FROM WW_Matches M INNER JOIN WW_Lineup L ON L.MatchID = M.MatchID WHERE M.MatchID = " + mycommon.MatchId + " AND L.ClubID = " + Convert.ToString(mycommon.TeamID2) + ")", 1));

                retriveVizSend();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        int undoflag = 0;
        private void btnWonbyfallundo_Click(object sender, EventArgs e)
        {
            btn1P.Enabled = true;
            btn1P2.Enabled = true;
            btn2P.Enabled = true;
            btn2P2.Enabled = true;
            btn3P.Enabled = true;
            btn3P2.Enabled = true;
            btn5P.Enabled = true;
            btn5P2.Enabled = true;
            undoflag = 1;
        }

        private void btnmatchendundo_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to undo match end?", mycommon.ApplicationName + " Info", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                mycommon.MatchEnd = 0;
                btnMatchEnd.Enabled = true;
                btnEnd.Enabled = true;
                btnStart.Enabled = false;

                retriveVizSend();
            }
        }

        private void btnpointswap_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to change point?", mycommon.ApplicationName + " Info", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                DataTable dt = new DataTable();
                try
                {
                    int playerid=0;
                    dt = objMB.ExeQueryStrRetDTBL("select PLAYER_A_POINT Apoint,PLAYER_B_POINT Bpoint,TEAM_A_SCORE AScore,TEAM_B_SCORE BScore,POINTID from WW_Events where MATCHID=" + mycommon.MatchId + " AND ROUNDID=" + Round + " order by POINTID DESC", 1);
                    if (dt.Rows.Count > 0)
                    {
                        int team1point = 0, team2point = 0;
                        int team1 = Convert.ToInt32(dt.Rows[0]["AScore"]);
                        int team2 = Convert.ToInt32(dt.Rows[0]["BScore"]);
                        if (Convert.ToInt32(dt.Rows[0]["Apoint"]) != 0 && Convert.ToInt32(dt.Rows[0]["Bpoint"]) == 0)
                        {
                            team1point = Convert.ToInt32(dt.Rows[0]["Bpoint"]);
                            team2point = Convert.ToInt32(dt.Rows[0]["Apoint"]);
                            team1 = Convert.ToInt32(dt.Rows[0]["AScore"]) - Convert.ToInt32(dt.Rows[0]["Apoint"]);
                            team2 = Convert.ToInt32(dt.Rows[0]["BScore"]) + Convert.ToInt32(dt.Rows[0]["Apoint"]);
                            playerid = objMB.ExeQueryStrIntBL("select PlayerID from WW_Lineup where MatchID=" + mycommon.MatchId + " AND CLubID=" + Convert.ToString(mycommon.TeamID2), 1);
                        }
                        else if (Convert.ToInt32(dt.Rows[0]["Apoint"]) == 0 && Convert.ToInt32(dt.Rows[0]["Bpoint"]) != 0)
                        {
                            team1point = Convert.ToInt32(dt.Rows[0]["Bpoint"]);
                            team2point = Convert.ToInt32(dt.Rows[0]["Apoint"]);
                            team1 = Convert.ToInt32(dt.Rows[0]["AScore"]) + Convert.ToInt32(dt.Rows[0]["Bpoint"]);
                            team2 = Convert.ToInt32(dt.Rows[0]["BScore"]) - Convert.ToInt32(dt.Rows[0]["Bpoint"]);
                            playerid=objMB.ExeQueryStrIntBL("select PlayerID from WW_Lineup where MatchID=" + mycommon.MatchId + " AND CLubID=" + Convert.ToString(mycommon.TeamID1), 1);
                        }

                        if (objMB.ExeQueryRetBooDL("update WW_Events set TEAM_A_SCORE=" + team1 + ",TEAM_B_SCORE=" + team2 + ",PLAYER_A_POINT=" + team1point + " ,PLAYER_B_POINT=" + team2point + ",PLAYERID=" + playerid + " where MATCHID=" + mycommon.MatchId + " AND ROUNDID=" + Round + " AND POINTID=" + Convert.ToInt32(dt.Rows[0]["POINTID"]), 1))
                        {
                            BindGridData();
                            BindEnableDisable();
                        }
                    }
                    retriveVizSend();
                    btnpointswap.Enabled = false;
                }
                catch { }
            }
        }
    }
}