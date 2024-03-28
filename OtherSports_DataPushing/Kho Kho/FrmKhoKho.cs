using OtherSports_DataPushing.Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using System.Xml;

namespace OtherSports_DataPushing.Kho_Kho
{
    public partial class FrmKhoKho : Form
    {
        SendtoViz ObjFndCtrl = new SendtoViz();
        BusinessLy objMB = new BusinessLy();
        DataTable DT;
        Boolean pageload = false;
        int temp = 0, InnsCount = 0, teamAscore = 0, teamBscore = 0, Pointid = 0;
        int outplayerid = 0;
        int time = 0;
        // int elapsedtime = 540;
        DataTable dtTeamA = new DataTable();
        DataTable dtTeamB = new DataTable();
        DispatcherTimer timer = new DispatcherTimer();
        int swap = 0;
        string runner = "", chaser = "", t = "";



        Stopwatch mySW = new Stopwatch();
        int startoffset = 0;
        private bool _timerRunning = false;
        DateTime Starttime;
        int StartTime = 0;
        int EndTime = Convert.ToInt32(ConfigurationSettings.AppSettings["khokhoTimer"].ToString());

        public FrmKhoKho()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            time++;
            //elapsedtime--;
            if (time <= 540)
                lblMatchTime.Text = TimeSpan.FromSeconds(Convert.ToDouble(time)).ToString(@"mm\:ss");
            //if (elapsedtime >= 0)
            //    lblElapseTime.Text = TimeSpan.FromSeconds(Convert.ToDouble(elapsedtime)).ToString(@"mm\:ss");

            //retriveVizSend();
        }

        private void FrmKhoKho_Load(object sender, EventArgs e)
        {
            mycommon.Team1Score = 0;
            mycommon.Team2Score = 0;
            Bind();
            Bindgrid();
            Bindlist();
            BeginLoad();
            if (objMB.ExeQueryStrIntBL("EXEC SP_KhoKho_Select @Queryid=1,@MatchID=" + mycommon.MatchId, 1) == 0)
            {
                btnMatchStart.Enabled = true;
                btnInnStart.Enabled = false;
                btnInnStart.BackColor = Color.Silver;
                btnMatchEnd.Enabled = false;
                BtnTurnStart.Enabled = false;
            }
            else
            {
                btnMatchStart.Enabled = false;
                btnMatchEnd.Enabled = true;
                btnInnStart.Enabled = true;
                btnInnStart.BackColor = Color.LimeGreen;
            }
            vizGridHeader();
            MatchStart();
        }

        void MatchStart()
        {
            DT = new DataTable();
            DT = objMB.ExeQueryStrRetDTBL("EXEC SP_KhoKho_Select @Queryid=2,@MatchID=" + mycommon.MatchId, 1);
            if (DT.Rows.Count > 0)
            {
                mycommon.MatchStart = DT.Rows[0]["EndStatus"].ToString() == "0" ? 1 : 0;
                mycommon.MatchEnd = DT.Rows[0]["EndStatus"].ToString() == "1" ? 1 : 0;
            }
            DataTable DT1 = new DataTable();
            DT1 = objMB.ExeQueryStrRetDTBL("EXEC SP_KhoKho_Select @Queryid=1,@MatchID=" + mycommon.MatchId, 1);
            if (DT1.Rows.Count > 0)
            {
                DT = new DataTable();
                DT = objMB.ExeQueryStrRetDTBL("EXEC SP_KhoKho_Select @Queryid=3,@MatchID=" + mycommon.MatchId + ",@InnEnd=1,@InningsID=" + DT1.Rows[0][0].ToString(), 1);
                if (DT.Rows.Count > 0)
                {
                    //btnMatchEnd.Enabled = false;
                    if (DT.Rows[0]["InningsID"].ToString() == "3")
                    {
                        mycommon.MatchEnd = 1;
                        btnMatchEnd.Enabled = true;
                        btnMatchEnd.Text = "Match Undo";
                        btn_11.Enabled = false;
                        btn_21.Enabled = false;
                    }
                    else if (Convert.ToInt32(DT.Rows[0]["InningsID"]) < 3)
                    {
                        btnInnStart.Enabled = true;
                    }
                }
                else
                {
                    mycommon.GameEnd = 0;
                    mycommon.MatchStart = 0;
                    if (DT1.Rows[0]["InningsID"].ToString() != "0")
                    { btnInnStart.Enabled = false; btnInnStart.BackColor = Color.Silver; btnInnEnd.Enabled = true; btnInnEnd.BackColor = Color.Firebrick; }
                }

                if (objMB.ExeQueryStrRetDTBL("select * from KK_MatchInnings where MatchID="+mycommon.MatchId+" AND InningsID="+InnsCount+" AND InnEnd=0", 1).Rows.Count > 0)
                {
                    if (objMB.ExeQueryStrRetDTBL("select * from KK_Turn where Matchid=" + mycommon.MatchId + " AND TurnId=1 AND TurnStart=1 AND InningsID=" + InnsCount, 1).Rows.Count > 0)
                    {
                        if (objMB.ExeQueryStrRetDTBL("select * from KK_Turn where Matchid=" + mycommon.MatchId + " AND TurnId=1 AND TurnEnd=1 AND InningsID=" + InnsCount, 1).Rows.Count > 0)
                        {
                            if (objMB.ExeQueryStrRetDTBL("select * from KK_Turn where Matchid=" + mycommon.MatchId + " AND TurnId=2 AND TurnStart=1 AND InningsID=" + InnsCount, 1).Rows.Count > 0)
                            {
                                if (objMB.ExeQueryStrRetDTBL("select * from KK_Turn where Matchid=" + mycommon.MatchId + " AND TurnId=2 AND TurnEnd=1 AND InningsID=" + InnsCount, 1).Rows.Count > 0)
                                {
                                    BtnTurnStart.Text = "Turn Start"; BtnTurnStart.Enabled = true; btnInnEnd.Enabled = true; btnInnEnd.BackColor = Color.Firebrick;
                                }
                                else
                                {
                                    BtnTurnStart.Text = "Turn End"; BtnTurnStart.Enabled = true; btnInnEnd.Enabled = false; btnInnEnd.BackColor = Color.Silver;
                                }
                            }
                            else
                            {
                                BtnTurnStart.Text = "Turn Start"; BtnTurnStart.Enabled = true; btnInnEnd.Enabled = false; btnInnEnd.BackColor = Color.Silver;
                            }
                        }
                        else
                        {
                            BtnTurnStart.Text = "Turn End"; BtnTurnStart.Enabled = true; btnInnEnd.Enabled = false; btnInnEnd.BackColor = Color.Silver;
                        }
                    }
                    else
                    {
                        BtnTurnStart.Text = "Turn Start"; BtnTurnStart.Enabled = true; btnInnEnd.Enabled = true; btnInnEnd.BackColor = Color.Firebrick;
                    }
                }
                DT = new DataTable();
                DT = objMB.ExeQueryStrRetDTBL("EXEC SP_KhoKho_Select @Queryid=4,@MatchID=" + mycommon.MatchId + ",@InnEnd=0", 1);
                if (DT.Rows.Count > 0)
                {
                    btnInnStart.Enabled = false; btnInnStart.BackColor = Color.Silver; btnInnEnd.Enabled = true; btnInnEnd.BackColor = Color.Firebrick;
                }
                else
                {
                    mycommon.GameStart = 1;
                    mycommon.MatchStart = 0;
                    if (DT1.Rows[0]["InningsID"].ToString() != "0")
                    { btnInnStart.Enabled = true; btnInnStart.BackColor = Color.LimeGreen; btnInnEnd.Enabled = false; btnInnEnd.BackColor = Color.Silver; BtnTurnStart.Enabled = false; }
                }
                if (objMB.ExeQueryStrRetDTBL("EXEC SP_KhoKho_Select @Queryid=5,@MatchID=" + mycommon.MatchId + ",@InnEnd=0", 1).Rows.Count > 0)
                { btnInnStart.Enabled = false; btnInnStart.BackColor = Color.Silver; btnInnEnd.Enabled = true; btnInnEnd.BackColor = Color.Firebrick; }

                if (objMB.ExeQueryStrRetDTBL("EXEC SP_KhoKho_Select @Queryid=6,@MatchID=" + mycommon.MatchId + ",@InningsID=" + InnsCount, 1).Rows.Count < 2)
                {
                    btnInnEnd.Enabled = false; btnInnEnd.BackColor = Color.Silver;
                }

                if (objMB.ExeQueryStrRetDTBL("EXEC SP_KhoKho_Select @Queryid=7,@MatchID=" + mycommon.MatchId + ",@TurnEnd=0", 1).Rows.Count > 0)
                {
                    BtnTurnStart.Text = "Turn End"; BtnTurnStart.Enabled = true; btnInnEnd.Enabled = false; btnInnEnd.BackColor = Color.Silver;
                }

                else
                {
                    if (objMB.ExeQueryStrRetDTBL("EXEC SP_KhoKho_Select @Queryid=8,@MatchID=" + mycommon.MatchId, 1).Rows.Count > 0)
                    {
                        if (objMB.ExeQueryStrIntBL("EXEC SP_KhoKho_Select @Queryid=9,@MatchID=" + mycommon.MatchId + ",@TurnEnd=1,@InningsID=" + InnsCount, 1) < 2)
                        { BtnTurnStart.Text = "Turn Start"; BtnTurnStart.Enabled = true; }
                    }
                }

                

                if (mycommon.MatchEnd == 1)
                {
                    btnInnStart.Enabled = false;
                    btnInnStart.BackColor = Color.Silver;
                    btnInnEnd.Enabled = false;
                    btnInnEnd.BackColor = Color.Silver;
                    btnMatchEnd.Enabled = false;
                    BtnTurnStart.Enabled = false;
                }
            }
            DT = new DataTable();
        }

        void Bind()
        {
            try
            {
                lblmatchid.Text = mycommon.MatchId.ToString();
                DataTable dt = new DataTable();
                dt = objMB.ExeQueryStrRetDTBL("EXEC SP_KhoKho_Select @Queryid=10,@MatchID=" + mycommon.MatchId, 1);
                lblTeamANameGoal.Text = mycommon.Team1Name;
                lblTeamBNameGoal.Text = mycommon.Team2Name;
                lblTeamAScore.Text = "0";
                lblTeamBScore.Text = "0";
                temp = objMB.ExeQueryStrIntBL("EXEC SP_KhoKho_Select @Queryid=11,@MatchID=" + mycommon.MatchId, 1);
                if (dt.Rows.Count > 0)
                {
                    if (temp == 0)
                    {
                        btnInnEnd.Enabled = true;
                        btnInnEnd.BackColor = Color.Firebrick;
                        btnInnStart.Enabled = false;
                        btnInnStart.BackColor = Color.Silver;
                    }
                    else if (temp == 1)
                    {
                        timer.Start();
                        btnInnEnd.Enabled = false;
                        btnInnEnd.BackColor = Color.Silver;
                        btnInnStart.Enabled = true;
                        btnInnStart.BackColor = Color.LimeGreen;
                    }
                }
            }
            catch { }
        }

        void Bindgrid()
        {
            try
            {
                DT = new DataTable();
                DT = objMB.ExeQueryStrRetDTBL("EXEC SP_KhoKho_Select @Queryid=12,@MatchID=" + mycommon.MatchId, 1);
                gvdatagrid.DataSource = DT;
                gvdatagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                if (DT.Rows.Count > 0)
                {
                    lblhalfid.Text = DT.Rows[0]["InningsID"].ToString();
                    InnsCount = Convert.ToInt32(DT.Rows[0]["InningsID"]);
                    lblTeamAScore.Text = DT.Rows[0]["TeamAPoint"].ToString();
                    mycommon.Team1Score = Convert.ToInt32(DT.Rows[0]["TeamAPoint"]);
                    lblTeamBScore.Text = DT.Rows[0]["TeamBPoint"].ToString();
                    mycommon.Team2Score = Convert.ToInt32(DT.Rows[0]["TeamBPoint"]);
                }
                else
                {
                    InnsCount = objMB.ExeQueryStrIntBL("EXEC SP_KhoKho_Select @Queryid=1,@MatchID=" + mycommon.MatchId + "", 1);
                    lblhalfid.Text = InnsCount.ToString();
                    mycommon.Team1Score = 0;
                    mycommon.Team2Score = 0;

                    lblTeamAScore.Text = mycommon.Team1Score.ToString();
                    lblTeamBScore.Text = mycommon.Team2Score.ToString();
                }
                lblTurnNo.Text = objMB.ExeQueryStrRetStrBL("EXEC SP_KhoKho_Select @Queryid=13,@MatchID=" + mycommon.MatchId + ",@InningsID=" + InnsCount + "", 1);
                CurrentTurnID = Convert.ToInt32(lblTurnNo.Text);
            }
            catch { }
        }

        void BeginLoad()
        {
            try
            {
                DT = new DataTable();
                DT = objMB.ExeQueryStrRetDTBL("EXEC SP_KhoKho_Select @Queryid=12,@MatchID=" + mycommon.MatchId, 1);
                gvdatagrid.DataSource = DT;
                gvdatagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                if (DT.Rows.Count > 0)
                {
                    lblhalfid.Text = DT.Rows[0]["InningsID"].ToString();
                    InnsCount = Convert.ToInt32(DT.Rows[0]["InningsID"]);
                    lblTeamAScore.Text = DT.Rows[0]["TeamAPoint"].ToString();
                    mycommon.Team1Score = Convert.ToInt32(DT.Rows[0]["TeamAPoint"]);
                    lblTeamBScore.Text = DT.Rows[0]["TeamBPoint"].ToString();
                    mycommon.Team2Score = Convert.ToInt32(DT.Rows[0]["TeamBPoint"]);

                    lblMatchTime.Text = Convert.ToString(DT.Rows[0]["Timer"]);
                    time = Convert.ToInt32(TimeSpan.Parse("00:" + lblMatchTime.Text).TotalSeconds);
                    startoffset = time;

                    TimeSpan span3 = TimeSpan.FromSeconds(startoffset).Add(mySW.Elapsed);
                    dtp_Clock.Value = DateTime.ParseExact(span3.ToString(@"mm\:ss"), "mm:ss", CultureInfo.InvariantCulture);
                }
                else
                {
                    InnsCount = objMB.ExeQueryStrIntBL("EXEC SP_KhoKho_Select @Queryid=1,@MatchID=" + mycommon.MatchId + "", 1);
                    lblhalfid.Text = InnsCount.ToString();
                }
                lblTurnNo.Text = objMB.ExeQueryStrRetStrBL("EXEC SP_KhoKho_Select @Queryid=13,@MatchID=" + mycommon.MatchId + ",@InningsID=" + InnsCount + "", 1);
                CurrentTurnID = Convert.ToInt32(lblTurnNo.Text);
            }
            catch { }
        }

        void Bindlist()
        {
            try
            {
                dtTeamA = objMB.ExeQueryStrRetDTBL("EXEC SP_KhoKho_Select @Queryid=14,@MatchID=" + mycommon.MatchId + ",@ClubID=" + mycommon.TeamID1, 1);
                lstTeamA.DataSource = dtTeamA;
                lstTeamA.DisplayMember = "PlayerName";
                lstTeamA.ValueMember = "ClubID";
                lblteamAname.Text = dtTeamA.Rows[0]["TeamName"].ToString();

                dtTeamB = objMB.ExeQueryStrRetDTBL("EXEC SP_KhoKho_Select @Queryid=14,@MatchID=" + mycommon.MatchId + ",@ClubID=" + mycommon.TeamID2, 1);
                lstteamB.DataSource = dtTeamB;
                lstteamB.DisplayMember = "PlayerName";
                lstteamB.ValueMember = "ClubID";
                lblteamBname.Text = dtTeamB.Rows[0]["TeamName"].ToString();
                runner = "CHASER";
                chaser = "RUNNER";
            }
            catch { }
        }

        private void btnInnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (InnsCount <= 4)
                {
                    MessageBox.Show("Inns Started");
                }
                else { MessageBox.Show("Inns Completed"); return; }
                InnsCount = objMB.ExeQueryStrIntBL("EXEC SP_KhoKho_Select @Queryid=15,@MatchID=" + mycommon.MatchId, 1);
                if (objMB.ExeQueryRetBooDL("Insert Into KK_MatchInnings(MatchId,InningsID,TeamA,InnStart,InnEnd,StartTime,EndTime) Values (" + mycommon.MatchId + "," + InnsCount + "," + mycommon.TeamID1 + ",1,0,'" + DateTime.Now + "',0)", 1))
                {
                    if (objMB.ExeQueryRetBooDL("Insert Into KK_MatchInnings(MatchId,InningsID,TeamB,InnStart,InnEnd,StartTime,EndTime) Values (" + mycommon.MatchId + "," + InnsCount + "," + mycommon.TeamID2 + ",1,0,'" + DateTime.Now + "',0)", 1))
                    {
                    }
                }
                lblhalfid.Text = InnsCount.ToString();
            }
            catch { }
            CurrentTurnID = 1;
            btnInnStart.Enabled = false;
            btnInnStart.BackColor = Color.Silver;
            btnInnEnd.Enabled = true;
            btnInnEnd.BackColor = Color.Firebrick;
            BtnTurnStart.Enabled = true;
            BtnTurnStart.Text = "Turn Start";
            btnenable();
            retriveVizSend();
            ObjFndCtrl.sendChaserorRunner((lblteamAname.Text == mycommon.Team1Name ? "1" : "0"), (lblteamBname.Text == mycommon.Team2Name ? "0" : "1"));
        }

        private void btnInnEnd_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Continue to Innings End", mycommon.ApplicationName + " Info", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (Result == DialogResult.Yes)
            {
            }
            else if (Result == DialogResult.No)
            {
                return;
            }
            else if (Result == DialogResult.Cancel)
            {
                return;
            }
            btndisable();
            try
            {
                DT = new DataTable();
                // DT = objMB.ExeQueryStrRetDTBL("Select TeamAScore AScore,TeamBScore BScore from PointCard Where MatchID=" + CommonCls.MatchId + " And SetId=" + SetCount + "Order by PointId desc", 1);
                DT = objMB.ExeQueryStrRetDTBL("EXEC SP_KhoKho_Select @Queryid=16,@MatchID=" + mycommon.MatchId + ",@InningsID=" + InnsCount, 1);
                if (DT.Rows.Count > 0)
                {
                    mycommon.Team1Score = Convert.ToInt32(DT.Rows[0]["AScore"].ToString());
                    mycommon.Team2Score = Convert.ToInt32(DT.Rows[0]["BScore"].ToString());

                }

                if (objMB.ExeQueryStrRetDTBL("EXEC SP_KhoKho_Select @Queryid=17,@MatchID=" + mycommon.MatchId + ",@InningsID=" + InnsCount + "", 1).Rows.Count > 0)
                {
                    if (objMB.ExeQueryRetBooDL("Update KK_MatchInnings Set EndTime='" + DateTime.Now + "',InnEnd=1 Where MatchId=" + mycommon.MatchId + " And InningsId=" + InnsCount + " And TeamA=" + mycommon.TeamID1 + "", 1))
                    {
                        if (objMB.ExeQueryRetBooDL("Update KK_MatchInnings Set EndTime='" + DateTime.Now + "',InnEnd=1 Where MatchId=" + mycommon.MatchId + " And InningsId=" + InnsCount + " And TeamB=" + mycommon.TeamID2 + "", 1))
                        {

                        }
                    }
                }
                else
                {
                    if (objMB.ExeQueryRetBooDL("Insert Into KK_MatchInnings(MatchId,InningsID,TeamA,InnStart,InnEnd,StartTime,EndTime) Values (" + mycommon.MatchId + "," + InnsCount + "," + mycommon.TeamID1 + ",1,0,'" + DateTime.Now + "',0)", 1))
                    {
                    }
                    if (objMB.ExeQueryRetBooDL("Insert Into KK_MatchInnings(MatchId,InningsID,TeamB,InnStart,InnEnd,StartTime,EndTime) Values (" + mycommon.MatchId + "," + InnsCount + "," + mycommon.TeamID2 + ",1,0,'" + DateTime.Now + "',0)", 1))
                    {
                    }
                }
            }
            catch { }
            //mycommon.Team1Score = 0;
            //mycommon.Team2Score = 0;
            BtnTurnStart.Enabled = false;
            btnInnStart.Enabled = true;
            btnInnStart.BackColor = Color.LimeGreen;
            btnInnEnd.Enabled = false;
            btnInnEnd.BackColor = Color.Silver;
        }

        void btnenable()
        {
            btn_11.Enabled = true;
            btn_21.Enabled = true;
            chkallout.Enabled = true;
        }

        void btndisable()
        {
            btn_11.Enabled = false;
            btn_21.Enabled = false;
            chkallout.Enabled = false;
        }

        int previouspoint = 0, previousteam = 0;

        private void btn_Score_Click(object sender, EventArgs e)
        {
            int btn = Convert.ToInt32(((Button)sender).Name.Split('_')[1]);
            if (btn != 11 && btn != 21) { return; }

            try
            {
                previousteam = btn;
                if (btn == 11)
                {
                    if (chkallout.Checked == true)
                    {
                        mycommon.Team1Score += 2;
                        previouspoint = 2;
                    }
                    else
                    {
                        mycommon.Team1Score += 1;
                        previouspoint = 1;
                    }

                }
                else if (btn == 21)
                {
                    if (chkallout.Checked == true)
                    {
                        mycommon.Team2Score += 2;
                        previouspoint = 2;
                    }
                    else
                    {
                        mycommon.Team2Score += 1;
                        previouspoint = 1;
                    }
                }
            }
            catch { }
            try
            {
                if (btn != 12 && btn != 22)
                {
                    Pointid = objMB.ExeQueryStrIntBL("EXEC SP_KhoKho_Select @Queryid=18,@MatchID=" + mycommon.MatchId + ",@InningsID=" + InnsCount, 1);
                    if (objMB.ExeQueryRetBooDL("Insert into KK_Events(MatchID,InningsID,PointID,DefenderTeam,CatcherTeam,Timer,TeamAPoint,TeamBPoint,TurnID) values(" + mycommon.MatchId + "," + InnsCount + "," + Pointid + "," + lstteamB.SelectedValue + "," + lstTeamA.SelectedValue + ",'" + dtp_Clock.Value.ToString(@"mm\:ss") + "'," + mycommon.Team1Score + "," + mycommon.Team2Score + "," + CurrentTurnID + ")", 1))
                    {

                    }
                }
            }
            catch { }
            chkallout.Checked = false;
            Bindgrid();
            retriveVizSend();
        }

        private void lstteamB_SelectedValueChanged(object sender, EventArgs e)
        {
            //    if (lstteamB.SelectedItems.Count <= 3)
            //    {
            //    }
            //    else
            //    {
            //        MessageBox.Show("Only 3 selections are allowed.");
            //    }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //lblMatchTime.Text=
        }

        private void btnTimerReset_Click(object sender, EventArgs e)
        {
            //timer.Stop();
            //time = 0; elapsedtime = 540;
            //lblMatchTime.Text = TimeSpan.FromSeconds(Convert.ToDouble(0.0)).ToString(@"mm\:ss");
            //lblElapseTime.Text = TimeSpan.FromSeconds(Convert.ToDouble(0.0)).ToString(@"mm\:ss");

            //time = 0;
            //lblTimer.Text = TimeSpan.FromSeconds(time).ToString(@"mm\:ss");

            startoffset = StartTime;
            mySW = new Stopwatch();

            TimeSpan span3 = TimeSpan.FromSeconds(startoffset).Add(mySW.Elapsed);
            dtp_Clock.Value = DateTime.ParseExact(span3.ToString(@"mm\:ss"), "mm:ss", CultureInfo.InvariantCulture);

            ObjFndCtrl.sendWrestlingTimer("CLOCK0*DIRECTION SET UP");
            ObjFndCtrl.sendWrestlingTimer("CLOCK0*TIME SET " + StartTime);
            ObjFndCtrl.sendWrestlingTimer("CLOCK0*LIMIT SET " + EndTime + "");
            ObjFndCtrl.sendWrestlingTimer("CLOCK0 STOP");
            btnTimerStart.Text = "Timer Start";
        }
        private void btnTimerOff_Click(object sender, EventArgs e)
        {
            ////timer1.Enabled = false;
            //timer.Stop();

            int sec = (dtp_Clock.Value.Minute * 60) + (dtp_Clock.Value.Second);
            startoffset = sec;
            mySW = new Stopwatch();
            //mySW = new Stopwatch(TimeSpan.FromSeconds(1200 - sec));
            //myStopWatch.e

            //  ObjFndCtrl.sendWrestlingTimer("CLOCK0*DIRECTION SET UP");
            //  ObjFndCtrl.sendWrestlingTimer("CLOCK0*LIMIT SET " + EndTime);
            // ObjFndCtrl.sendWrestlingTimer("CLOCK0 STOP");
            ObjFndCtrl.sendWrestlingTimer("CLOCK0*TIME SET " + sec);
            ObjFndCtrl.sendWrestlingTimer("CLOCK0 START");

            Timer_MatchClock.Start();
            mySW.Start();
            _timerRunning = true;
            btnTimerStart.Text = "Timer Pause";
        }

        private void btnTimerOn_Click(object sender, EventArgs e)
        {
            ////timer1.Enabled = true;                        
            //timer.Start();
            timer.Start();
            if (btnTimerStart.Text == "Timer Start")
            {
                TimeSpan span3 = TimeSpan.FromSeconds(0).Add(mySW.Elapsed);
                dtp_Clock.Value = DateTime.ParseExact(span3.ToString(@"mm\:ss"), "mm:ss", CultureInfo.InvariantCulture);
                mySW.Start();
                //  ObjFndCtrl.sendWrestlingTimer("CLOCK0*DIRECTION SET UP");
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
                //  ObjFndCtrl.sendWrestlingTimer("CLOCK0 STOP");

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

        private void btnswap_Click(object sender, EventArgs e)
        {
            swap++;
            try
            {
                if (swap % 2 != 0)
                {
                    lstTeamA.DataSource = dtTeamB;
                    lstTeamA.DisplayMember = "PlayerName";
                    lstTeamA.ValueMember = "ClubID";
                    lblteamAname.Text = dtTeamB.Rows[0]["TeamName"].ToString();

                    lstteamB.DataSource = dtTeamA;
                    lstteamB.DisplayMember = "PlayerName";
                    lstteamB.ValueMember = "ClubID";
                    lblteamBname.Text = dtTeamA.Rows[0]["TeamName"].ToString();
                    runner = "RUNNER";
                    chaser = "CHASER";
                    ObjFndCtrl.sendChaserorRunner("0", "1");
                    btn_11.Enabled = false;
                    btn_21.Enabled = true;
                }
                else
                {
                    lstTeamA.DataSource = dtTeamA;
                    lstTeamA.DisplayMember = "PlayerName";
                    lstTeamA.ValueMember = "ClubID";
                    lblteamAname.Text = dtTeamA.Rows[0]["TeamName"].ToString();

                    lstteamB.DataSource = dtTeamB;
                    lstteamB.DisplayMember = "PlayerName";
                    lstteamB.ValueMember = "ClubID";
                    lblteamBname.Text = dtTeamB.Rows[0]["TeamName"].ToString();
                    runner = "CHASER";
                    chaser = "RUNNER";
                    ObjFndCtrl.sendChaserorRunner("1", "0");
                    btn_11.Enabled = true;
                    btn_21.Enabled = false;
                }
            }
            catch { MessageBox.Show("Player Not Imported"); }
            //retriveVizSend();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(gvdatagrid.Rows[0].Cells["InningsID"].Value) == Convert.ToInt32(gvdatagrid.Rows[1].Cells["InningsID"].Value))
            {
                if (InnsCount == Convert.ToInt32(gvdatagrid.Rows[0].Cells["InningsID"].Value))
                {
                    try
                    {
                        int matid = Convert.ToInt32(gvdatagrid.Rows[0].Cells["MatchID"].Value);
                        int Quarid = Convert.ToInt32(gvdatagrid.Rows[0].Cells["InningsID"].Value);
                        int point = Convert.ToInt32(gvdatagrid.Rows[0].Cells["PointID"].Value);
                        if (objMB.ExeQueryRetBooDL("Delete from KK_Events where MatchID=" + matid + " AND InningsID=" + Quarid + " AND PointID=" + point, 1))
                        {
                            Bindgrid();
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
                    int matid = Convert.ToInt32(gvdatagrid.Rows[0].Cells["MatchID"].Value);
                    int Quarid = Convert.ToInt32(gvdatagrid.Rows[0].Cells["InningsID"].Value);
                    int point = Convert.ToInt32(gvdatagrid.Rows[0].Cells["PointID"].Value);
                    if (objMB.ExeQueryRetBooDL("Delete from KK_Events where MatchID=" + matid + " AND InningsID=" + Quarid + " AND PointID=" + point, 1))
                    {
                        Bindgrid();
                        mycommon.Team1Score = 0;
                        mycommon.Team2Score = 0;
                    }
                }
                catch { }
            }
            retriveVizSend();
        }

        void retriveVizSend()
        {
            if (objMB.ExeQueryStrRetDTBL("select * from Live where SportID=" + mycommon.SportID + " AND IsLive=1 --AND MatchID=" + mycommon.MatchId + "", 1).Rows.Count > 0)
            {
                try
                {
                    VizBasketballSendData viz = new VizBasketballSendData();
                    if (viz.TeamAName == "" || viz.TeamAName == null)
                        viz.TeamAName = mycommon.Team1Name;
                    if (viz.TeamBName == "" || viz.TeamBName == null)
                        viz.TeamBName = mycommon.Team2Name;
                    viz.Timer = lblElapseTime.Text;
                    viz.TeamAScore = Convert.ToString(mycommon.Team1Score);
                    viz.TeamBScore = Convert.ToString(mycommon.Team2Score);

                    viz.QuarterID = objMB.ExeQueryStrRetStrBL("Select dbo.fn_GetKhokhoInnings(" + (InnsCount == 0 ? 1 : InnsCount) + "," + CurrentTurnID + ")", 1);

                    viz.Runner = runner;
                    viz.Chaser = chaser;

                    Dtgv1.Rows[0]["QuarterID"] = viz.QuarterID.ToString();
                    Dtgv1.Rows[0]["TeamAName1"] = viz.TeamAName.ToString();
                    Dtgv1.Rows[0]["TeamBName1"] = viz.TeamBName.ToString();
                    Dtgv1.Rows[0]["TeamAscore1"] = viz.TeamAScore.ToString();
                    Dtgv1.Rows[0]["TeamBscore1"] = viz.TeamBScore.ToString();
                    Dtgv1.Rows[0]["Timer2"] = viz.Timer.ToString();
                    Dtgv1.Rows[0]["Runner"] = viz.Runner.ToString();
                    Dtgv1.Rows[0]["Chaser"] = viz.Chaser.ToString();

                    ObjFndCtrl.dgvBasketball.DataSource = Dtgv1;
                    ObjFndCtrl.Width = 1149;
                    ObjFndCtrl.Height = 120;
                    pnlGrid.Controls.Add(ObjFndCtrl);
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
            else
            {
                MessageBox.Show("Not connected to Live");
            }
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
            Dtgv1.Columns.Add("Runner");
            Dtgv1.Columns.Add("Chaser");

            Dtgv1.Rows.Add();
        }

        private void Timer_MatchClock_Tick(object sender, EventArgs e)
        {
            TimeSpan span3 = TimeSpan.FromSeconds(startoffset).Add(mySW.Elapsed);

            lblMatchTime.Text = TimeSpan.FromSeconds(time).ToString(@"mm\:ss");
            //if (span3.TotalSeconds <= 1)
            //{
            //    mySW.Stop();
            //    //ObjFndCtrl.sendWrestlingTimer("CLOCK0*TIME SET 0");
            //    //ObjFndCtrl.sendWrestlingTimer("CLOCK0 STOP");
            //    Timer_MatchClock.Stop();

            //}
            if (span3.TotalSeconds > (EndTime - 1))// && span3.TotalSeconds < 61)
            {
                mySW.Stop();
                //ObjFndCtrl.sendWrestlingTimer("CLOCK0*TIME SET 0");
                //ObjFndCtrl.sendWrestlingTimer("CLOCK0 STOP");
                Timer_MatchClock.Stop();
                span3 = TimeSpan.FromSeconds(EndTime);
                dtp_Clock.Value = DateTime.ParseExact(span3.ToString(@"mm\:ss"), "mm:ss", CultureInfo.InvariantCulture);
            }
            else
                dtp_Clock.Value = DateTime.ParseExact(span3.ToString(@"mm\:ss"), "mm:ss", CultureInfo.InvariantCulture);
        }

        private void btnMatchStart_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Continue to Match Start", "Kho-Kho Info", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (Result == DialogResult.Yes)
            {
                mycommon.MatchStart = 1;
                btnMatchStart.Enabled = false;
                btnMatchEnd.Enabled = true;
                btnInnStart.Enabled = true;
                btnInnStart.BackColor = Color.LimeGreen;
                BtnTurnStart.Enabled = false;

                try
                {
                    objMB.ExeQueryRetBooDL("Update KK_Matches set EndStatus=0 where Matchid=" + mycommon.MatchId, 1);
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }

                ObjFndCtrl.sendWrestlingTimer("CLOCK0*DIRECTION SET UP");
                ObjFndCtrl.sendWrestlingTimer("CLOCK0*TIME SET " + StartTime);
                ObjFndCtrl.sendWrestlingTimer("CLOCK0*LIMIT SET " + EndTime + "");
                ObjFndCtrl.sendWrestlingTimer("CLOCK0 STOP");
                btnMatchEnd.Text = "Match End";
            }
            retriveVizSend();
        }

        private void btnMatchEnd_Click(object sender, EventArgs e)
        {
            if (btnMatchEnd.Text == "Match End")
            {
                DialogResult Result = MessageBox.Show("Continue to Match End", "Kho-Kho Info", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (Result == DialogResult.Yes)
                {
                    mycommon.MatchEnd = 1;
                    btnMatchStart.Enabled = false;

                    btnInnStart.Enabled = false;
                    btnInnStart.BackColor = Color.Silver;
                    btnInnEnd.Enabled = false;
                    btnInnEnd.BackColor = Color.Silver;

                    try
                    {
                        objMB.ExeQueryRetBooDL("Update KK_Matches set EndStatus=1 where Matchid=" + mycommon.MatchId, 1);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                    btnMatchEnd.Text = "Match Undo";
                }
                else { return; }
            }
            else if (btnMatchEnd.Text == "Match Undo")
            {
                mycommon.MatchEnd = 0;
                btnMatchEnd.Enabled = true;
                btn_11.Enabled = true;
                btn_21.Enabled = true;
                btnInnEnd.Enabled = true;
                btnInnEnd.BackColor = Color.Firebrick;
                try
                {
                    objMB.ExeQueryRetBooDL("Update KK_Matches set EndStatus=0 where Matchid=" + mycommon.MatchId, 1);
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                btnMatchEnd.Text = "Match End";
            }
            retriveVizSend();
        }
        int CurrentTurnID = 0;
        private void BtnTurnStart_Click(object sender, EventArgs e)
        {
            if (BtnTurnStart.Text == "Turn Start")
            {
                int TurnID = objMB.ExeQueryStrIntBL("EXEC SP_KhoKho_Select @Queryid=19,@MatchID=" + mycommon.MatchId + ",@inningsID=" + InnsCount + "", 1);
                if (TurnID <= 2)
                {
                    CurrentTurnID = TurnID;
                    lblTurnNo.Text = CurrentTurnID.ToString();
                    objMB.ExeQueryRetBooDL("Insert into KK_Turn values(" + mycommon.MatchId + "," + InnsCount + "," + TurnID + ",1,0)", 1);
                    BtnTurnStart.Text = "Turn End";
                    btnInnEnd.Enabled = false;
                    btnInnEnd.BackColor = Color.Silver;
                    startoffset = StartTime;
                    //startoffset = EndTime;
                    mySW = new Stopwatch();
                    startoffset = 0;
                    _timerRunning = false;
                    //StartTime = 0;
                    btnTimerStart.Text = "Timer Start";

                    //TimeSpan span3 = TimeSpan.FromSeconds(StartTime).Add(mySW.Elapsed);
                    //dtp_Clock.Value = DateTime.ParseExact(span3.ToString(@"mm\:ss"), "mm:ss", CultureInfo.InvariantCulture);


                    //TimeSpan span3 = TimeSpan.FromSeconds(0);
                    //dtp_Clock.Value = DateTime.ParseExact(span3.ToString(@"mm\:ss"), "mm:ss", CultureInfo.InvariantCulture);


                    //S mySW.Start();
                    btnTimerStart.Text = "Timer Start";
                    //ObjFndCtrl.sendWrestlingTimer("CLOCK0*DIRECTION SET UP");
                    //ObjFndCtrl.sendWrestlingTimer("CLOCK0*TIME SET " + StartTime);
                    //ObjFndCtrl.sendWrestlingTimer("CLOCK0*LIMIT SET " + EndTime + "");
                    //ObjFndCtrl.sendWrestlingTimer("CLOCK0 START");

                    //timer.Start();

                    //Timer_MatchClock.Start();
                    //_timerRunning = true;

                    // Starttime = DateTime.Now;
                    btnswap_Click(sender, e);
                    if (InnsCount == 1 && TurnID == 1)
                    {
                        MessageBox.Show("Fix the runner & chaser");
                    }
                }
                else
                {
                    MessageBox.Show("Turn Completed."); btnInnEnd.Enabled = true;
                    btnInnEnd.BackColor = Color.Firebrick;
                }
            }
            else
            {
                DialogResult Result = MessageBox.Show("Continue to Turn End", "Kho-Kho Info", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (Result == DialogResult.No)
                {
                    return;
                }
                else if (Result == DialogResult.Cancel)
                {
                    return;
                }
                objMB.ExeQueryRetBooDL("Update KK_Turn set TurnEnd=1 where Matchid=" + mycommon.MatchId + " And InningsID=" + InnsCount + " And TurnId=" + CurrentTurnID + "", 1);
                BtnTurnStart.Text = "Turn Start";
                btnturnendundo.Enabled = true;

                if (objMB.ExeQueryStrIntBL("EXEC SP_KhoKho_Select @Queryid=20,@Matchid=" + mycommon.MatchId + ",@InningsID=" + InnsCount, 1) < 2)
                { BtnTurnStart.Text = "Turn Start"; BtnTurnStart.Enabled = true; }
                else
                {
                    BtnTurnStart.Text = "Turn Start"; BtnTurnStart.Enabled = false;
                    btnInnStart.Enabled = false;
                    btnInnStart.BackColor = Color.Silver;
                    btnInnEnd.Enabled = true;
                    btnInnEnd.BackColor = Color.Firebrick;
                }

                ObjFndCtrl.sendWrestlingTimer("CLOCK0 STOP");
                timer.Stop();
                mySW.Stop();

            }
            retriveVizSend();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            retriveVizSend();
        }

        private void btnmatchundo_Click(object sender, EventArgs e)
        {
            btnMatchEnd.Enabled = true;
            btn_11.Enabled = true;
            btn_21.Enabled = true;
            btnInnEnd.Enabled = true;
            btnInnEnd.BackColor = Color.Firebrick;
        }

        private void btnturnendundo_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Continue to Undo Turn End", mycommon.ApplicationName + " Info", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (Result == DialogResult.Yes)
            {
                objMB.ExeQueryRetBooDL("Update KK_Turn set TurnEnd=0 where Matchid=" + mycommon.MatchId + " And InningsID=" + InnsCount + " And TurnId=" + CurrentTurnID + "", 1);
                BtnTurnStart.Text = "Turn End";
                btnturnendundo.Enabled = false;
            }
        }

        private void btninnsendundo_Click(object sender, EventArgs e)
        {

        }

    }
}
