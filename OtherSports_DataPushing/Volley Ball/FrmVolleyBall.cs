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

namespace OtherSports_DataPushing.Volley_Ball
{
    public partial class FrmVolleyBall : Form
    {
        SendtoViz ObjFndCtrl = new SendtoViz();
        BusinessLy objMB = new BusinessLy();
        bool PageLoad = false;
        DataTable DT;
        int serverid = 0;
        int Pointid = 0;
        int SetCount = 0, PointCount = 0, TeamAPoints = 0, TeamBPoints = 0, Winnerid = 0;
        public FrmVolleyBall()
        {
            InitializeComponent();
        }

        private void FrmVolleyBall_Load(object sender, EventArgs e)
        {
            PageLoad = false;
            vizGridHeader();
            Bindform();
            bind();
            loadlastdata();

            if (objMB.ExeQueryStrIntBL("EXEC SP_VolleyBall_Select @Queryid=1,@MatchID=" + mycommon.MatchId, 1) == 0)
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
            //btnReset_Click(sender, e);
        }
        void Bindform()
        {
            lblteamAname.Text = mycommon.Team1Name;
            lblteamBname.Text = mycommon.Team2Name;
            lblTeam1name.Text = mycommon.Team1Name;
            lblTeam2name.Text = mycommon.Team2Name;
            lblmatchname.Text = mycommon.MatchId + " - " + mycommon.MatchName;
            DataTable d = new DataTable();
            d = objMB.ExeQueryStrRetDTBL("EXEC SP_VolleyBall_Select @Queryid=2,@MatchID=" + mycommon.MatchId, 1);
            if (d.Rows.Count > 0)
            {
                SetCount = Convert.ToInt32(d.Rows[0]["SetID"]);
                mycommon.Team1Score = Convert.ToInt32(d.Rows[0]["TeamAPoint"]);
                mycommon.Team2Score = Convert.ToInt32(d.Rows[0]["TeamBPoint"]);
            }
            else
            {
                SetCount = 1;
                mycommon.Team1Score = 0;
                mycommon.Team2Score = 0;
            }
        }
        void loadbtns()
        {
            pnlplayersingles.Enabled = false;
            tblscoreboard.Enabled = false;
        }
        void loadlastdata()
        {
            DataTable dtset = new DataTable();
            try
            {
                dtset = objMB.ExeQueryStrRetDTBL("EXEC SP_VolleyBall_Select @Queryid=3,@MatchID=" + mycommon.MatchId, 1);
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
            //     dt2 = objMB.ExeQueryStrRetDTBL("Select * From VB_Events where MatchID=" + mycommon.MatchId, 1);

            dt2 = objMB.ExeQueryStrRetDTBL("EXEC SP_VolleyBall_Select @Queryid=4,@MatchID=" + mycommon.MatchId, 1);
            if (dt2.Rows.Count > 0)
            {
                //  serverid = Convert.ToInt32(dt2.Rows[0]["ServerID"]);
                for (var i = 0; i < dt2.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dt2.Rows[i]["SetID"]) == 1)
                    {
                        txtset1t1.Text = Convert.ToString(dt2.Rows[i]["TeamAPoint"]);
                        mycommon.Team1Score = Convert.ToInt32(dt2.Rows[i]["TeamAPoint"]);
                        txtset1t2.Text = Convert.ToString(dt2.Rows[i]["TeamBPoint"]);
                        mycommon.Team2Score = Convert.ToInt32(dt2.Rows[i]["TeamBPoint"]);
                    }
                    else if (Convert.ToInt32(dt2.Rows[i]["SetID"]) == 2)
                    {
                        txtset2t1.Text = Convert.ToString(dt2.Rows[i]["TeamAPoint"]);
                        mycommon.Team1Score = Convert.ToInt32(dt2.Rows[i]["TeamAPoint"]);
                        txtset2t2.Text = Convert.ToString(dt2.Rows[i]["TeamBPoint"]);
                        mycommon.Team2Score = Convert.ToInt32(dt2.Rows[i]["TeamBPoint"]);
                    }
                    else if (Convert.ToInt32(dt2.Rows[i]["SetID"]) == 3)
                    {
                        txtset3t1.Text = Convert.ToString(dt2.Rows[i]["TeamAPoint"]);
                        mycommon.Team1Score = Convert.ToInt32(dt2.Rows[i]["TeamAPoint"]);
                        txtset3t2.Text = Convert.ToString(dt2.Rows[i]["TeamBPoint"]);
                        mycommon.Team2Score = Convert.ToInt32(dt2.Rows[i]["TeamBPoint"]);
                    }
                    else if (Convert.ToInt32(dt2.Rows[i]["SetID"]) == 4)
                    {
                        txtset4t1.Text = Convert.ToString(dt2.Rows[i]["TeamAPoint"]);
                        mycommon.Team1Score = Convert.ToInt32(dt2.Rows[i]["TeamAPoint"]);
                        txtset4t2.Text = Convert.ToString(dt2.Rows[i]["TeamBPoint"]);
                        mycommon.Team2Score = Convert.ToInt32(dt2.Rows[i]["TeamBPoint"]);
                    }
                    else if (Convert.ToInt32(dt2.Rows[i]["SetID"]) == 5)
                    {
                        txtset5t1.Text = Convert.ToString(dt2.Rows[i]["TeamAPoint"]);
                        mycommon.Team1Score = Convert.ToInt32(dt2.Rows[i]["TeamAPoint"]);
                        txtset5t2.Text = Convert.ToString(dt2.Rows[i]["TeamBPoint"]);
                        mycommon.Team2Score = Convert.ToInt32(dt2.Rows[i]["TeamBPoint"]);
                    }
                }
            }
        }

        private void btnGamestart_Click(object sender, EventArgs e)
        {
            SetCount = objMB.ExeQueryStrIntBL("EXEC SP_VolleyBall_Select @Queryid=5,@MatchID=" + mycommon.MatchId, 1);
            if (SetCount <= 5)
            {
                if (objMB.ExeQueryRetBooDL("EXEC SP_VolleyBall_Manipulation @Queryid=1,@MatchID=" + mycommon.MatchId + ",@SetID=" + SetCount + ",@StartTime='" + DateTime.Now + "',@TeamId=" + mycommon.TeamID1 + ",@SetScore=0,@SetWinner=0,@SetComplete=0", 1))
                {
                    if (objMB.ExeQueryRetBooDL("EXEC SP_VolleyBall_Manipulation @Queryid=1,@MatchID=" + mycommon.MatchId + ",@SetID=" + SetCount + ",@StartTime='" + DateTime.Now + "',@TeamId=" + mycommon.TeamID2 + ",@SetScore=0,@SetWinner=0,@SetComplete=0", 1))
                    {
                        mycommon.GameStart = 1;
                    }
                }
                tblscoreboard.Enabled = true;
                pnlplayersingles.Enabled = true;
                btnGamestart.Enabled = false;
                btngameend.Enabled = true;
            }
            else
            {
                MessageBox.Show("Match Completed.!!");
            }
            mycommon.Team1Score = 0;
            mycommon.Team2Score = 0;
            retriveVizSend();
        }

        private void btngameend_Click(object sender, EventArgs e)
        {
            int Iscompelete = 0, TeamAIsWinner = 0, TeamBIsWinner = 0;
            if (btngameend.Text == "Game End")
            {
                DialogResult Result = MessageBox.Show("Set Compeleted", mycommon.ApplicationName + " Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (Result == DialogResult.Yes)
                {
                    Iscompelete = 1;
                }
                else if (Result == DialogResult.No)
                {
                    Iscompelete = 0;
                    return;
                }
                pnlplayersingles.Enabled = false;
                tblscoreboard.Enabled = false;
                DT = new DataTable();
                
                DT = objMB.ExeQueryStrRetDTBL("EXEC SP_VolleyBall_Select @Queryid=6,@MatchID=" + mycommon.MatchId + ",@SetID=" + SetCount, 1);
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

                if (objMB.ExeQueryStrRetDTBL("EXEC SP_VolleyBall_Select @Queryid=7,@MatchID=" + mycommon.MatchId + ",@SetID=" + SetCount, 1).Rows.Count > 0)
                {
                    if (objMB.ExeQueryRetBooDL("EXEC SP_VolleyBall_Manipulation @Queryid=2,@EndTime='" + DateTime.Now + "',@SetScore=" + mycommon.Team1Score + ",@SetWinner=" + TeamAIsWinner + ",@SetComplete=" + Iscompelete + ",@MatchID=" + mycommon.MatchId + ",@SetID=" + SetCount + ",@TeamId=" + mycommon.TeamID1, 1))
                    {
                        if (objMB.ExeQueryRetBooDL("EXEC SP_VolleyBall_Manipulation @Queryid=2,@EndTime='" + DateTime.Now + "',@SetScore=" + mycommon.Team2Score + ",@SetWinner=" + TeamBIsWinner + ",@SetComplete=" + Iscompelete + ",@MatchID=" + mycommon.MatchId + ",@SetID=" + SetCount + ",@TeamId=" + mycommon.TeamID2, 1))
                        {

                        }
                    }
                }
                else
                {
                    if (objMB.ExeQueryRetBooDL("EXEC SP_VolleyBall_Manipulation @Queryid=3,@MatchID=" + mycommon.MatchId + ",@SetID=" + SetCount + ",@StartTime='" + DateTime.Now + "',@EndTime='" + DateTime.Now + "',@TeamId=" + mycommon.TeamID1 + ",@SetScore=" + mycommon.Team1Score + ",@SetWinner=" + TeamAIsWinner + ",@SetComplete=" + Iscompelete, 1))
                    {
                    }
                    if (objMB.ExeQueryRetBooDL("EXEC SP_VolleyBall_Manipulation @Queryid=3,@MatchID=" + mycommon.MatchId + ",@SetID=" + SetCount + ",@StartTime='" + DateTime.Now + "',@EndTime='" + DateTime.Now + "',@TeamId=" + mycommon.TeamID2 + ",@SetScore=" + mycommon.Team2Score + ",@SetWinner=" + TeamBIsWinner + ",@SetComplete=" + Iscompelete, 1))
                    {
                    }
                }
                DT = new DataTable();

                DT = objMB.ExeQueryStrRetDTBL("EXEC SP_VolleyBall_Select @Queryid=8,@MatchID=" + mycommon.MatchId, 1);
                if (DT.Rows.Count > 0)
                {
                    mycommon.Team1Setwin = Convert.ToInt32(DT.Rows[0]["TeamASSet"].ToString());
                    mycommon.Team2Setwin = Convert.ToInt32(DT.Rows[0]["TeamBSSet"].ToString());
                }
                else
                {
                    mycommon.Team1Setwin = 0;
                    mycommon.Team2Setwin = 0;
                }
                mycommon.GameEnd = 1;
                btnGamestart.Enabled = true;
                mycommon.Team1Score = 0;
                mycommon.Team2Score = 0;
                tblscoreboard.Enabled = false;
                btngameend.Enabled = false;
                swapteamside();
                btnpointswap.Enabled = false;
                btngameend.Text = "Game Undo";
            }
            else if (btngameend.Text == "Game Undo")
            {
                btngameend.Text = "Game End";
                mycommon.GameEnd = 0;
                pnlplayersingles.Enabled = true;
                btngameend.Enabled = true;
                tblscoreboard.Enabled = true;
                DT = new DataTable();

                DT = objMB.ExeQueryStrRetDTBL("EXEC SP_VolleyBall_Select @Queryid=6,@MatchID=" + mycommon.MatchId + ",@SetID=" + SetCount, 1);
                if (DT.Rows.Count > 0)
                {
                    mycommon.Team1Score = Convert.ToInt32(DT.Rows[0]["AScore"].ToString());
                    mycommon.Team2Score = Convert.ToInt32(DT.Rows[0]["BScore"].ToString());
                }

                if (objMB.ExeQueryStrRetDTBL("EXEC SP_VolleyBall_Select @Queryid=7,@MatchID=" + mycommon.MatchId + ",@SetID=" + SetCount, 1).Rows.Count > 0)
                {
                    if (objMB.ExeQueryRetBooDL("EXEC SP_VolleyBall_Manipulation @Queryid=2,@EndTime='" + DateTime.Now + "',@SetScore=" + mycommon.Team1Score + ",@SetWinner=" + TeamAIsWinner + ",@SetComplete=" + Iscompelete + ",@MatchID=" + mycommon.MatchId + ",@SetID=" + SetCount + ",@TeamId=" + mycommon.TeamID1, 1))
                    {
                        if (objMB.ExeQueryRetBooDL("EXEC SP_VolleyBall_Manipulation @Queryid=2,@EndTime='" + DateTime.Now + "',@SetScore=" + mycommon.Team2Score + ",@SetWinner=" + TeamBIsWinner + ",@SetComplete=" + Iscompelete + ",@MatchID=" + mycommon.MatchId + ",@SetID=" + SetCount + ",@TeamId=" + mycommon.TeamID2, 1))
                        {

                        }
                    }
                }
                else
                {
                    if (objMB.ExeQueryRetBooDL("EXEC SP_VolleyBall_Manipulation @Queryid=3,@MatchID=" + mycommon.MatchId + ",@SetID=" + SetCount + ",@StartTime='" + DateTime.Now + "',@EndTime='" + DateTime.Now + "',@TeamId=" + mycommon.TeamID1 + ",@SetScore=" + mycommon.Team1Score + ",@SetWinner=" + TeamAIsWinner + ",@SetComplete=" + Iscompelete, 1))
                    {
                    }
                    if (objMB.ExeQueryRetBooDL("EXEC SP_VolleyBall_Manipulation @Queryid=3,@MatchID=" + mycommon.MatchId + ",@SetID=" + SetCount + ",@StartTime='" + DateTime.Now + "',@EndTime='" + DateTime.Now + "',@TeamId=" + mycommon.TeamID2 + ",@SetScore=" + mycommon.Team2Score + ",@SetWinner=" + TeamBIsWinner + ",@SetComplete=" + Iscompelete, 1))
                    {
                    }
                }

            }
            retriveVizSend();
        }
        int previouspoint = 0, previousteam = 0;

        private void btnW_Click(object sender, EventArgs e)
        {
            lblerror.Text = "";
            if (!rbS_1.Checked && !rbS_2.Checked)
            {
                lblerror.Visible = true;
                lblerror.Text = "Error!! please select the Server";
                return;
            }
            if (rbS_1.Checked)
            {
                rbS_2.Checked = false;
                serverid = mycommon.TeamID1;
            }
            else if (rbS_2.Checked)
            {
                rbS_1.Checked = false;
                serverid = mycommon.TeamID2;
            }
            if (Convert.ToString(((Button)sender).Name) == "btnW_1")
            {
                Winnerid = mycommon.TeamID1;
                previousteam = 1;
                mycommon.Team1Score += 1;
                previouspoint = 1;

            }
            else if (Convert.ToString(((Button)sender).Name) == "btnW_2")
            {
                Winnerid = mycommon.TeamID2;
                previousteam = 2;
                mycommon.Team2Score += 1;
                previouspoint = 1;
            }
            try
            {
                Pointid = objMB.ExeQueryStrIntBL("EXEC SP_VolleyBall_Select @Queryid=9,@MatchID=" + mycommon.MatchId + ",@SetID=" + SetCount, 1);
                if (objMB.ExeQueryRetBooDL("EXEC SP_VolleyBall_Manipulation @Queryid=4,@MatchID=" + mycommon.MatchId + ",@SetID=" + SetCount + ",@PointID=" + Pointid + ",@ServerID=" + serverid + ",@TeamAPoint=" + mycommon.Team1Score + ",@TeamBPoint=" + mycommon.Team2Score + ",@WinnerID=" + Winnerid, 1))
                {

                }
            }
            catch { }
            bind();
            clear();
            btnpointswap.Enabled = true;
        }

        void bind()
        {
            DataTable dt1 = new DataTable();
            try
            {
                dt1 = objMB.ExeQueryStrRetDTBL("EXEC SP_VolleyBall_Select @Queryid=10,@MatchID=" + mycommon.MatchId, 1);
                gvdatabind.DataSource = dt1;
                gvdatabind.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (dt1.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dt1.Rows[0]["WonID"]) != Convert.ToInt32(dt1.Rows[0]["Serid"]))
                    {
                        if (rbS_1.Checked)
                        {
                            rbS_2.Checked = true;
                        }
                        else if (rbS_2.Checked)
                        {
                            rbS_1.Checked = true;
                        }
                    }

                    if (Convert.ToInt32(dt1.Rows[0]["SetID"]) == 1)
                    {
                        txtset1t1.Text = mycommon.Team1Score.ToString();
                        txtset1t2.Text = mycommon.Team2Score.ToString();
                    }
                    else if (Convert.ToInt32(dt1.Rows[0]["SetID"]) == 2)
                    {
                        txtset2t1.Text = mycommon.Team1Score.ToString();
                        txtset2t2.Text = mycommon.Team2Score.ToString();
                    }
                    else if (Convert.ToInt32(dt1.Rows[0]["SetID"]) == 3)
                    {
                        txtset3t1.Text = mycommon.Team1Score.ToString();
                        txtset3t2.Text = mycommon.Team2Score.ToString();
                    }
                    else if (Convert.ToInt32(dt1.Rows[0]["SetID"]) == 4)
                    {
                        txtset4t1.Text = mycommon.Team1Score.ToString();
                        txtset4t2.Text = mycommon.Team2Score.ToString();
                    }
                    else if (Convert.ToInt32(dt1.Rows[0]["SetID"]) == 5)
                    {
                        txtset5t1.Text = mycommon.Team1Score.ToString();
                        txtset5t2.Text = mycommon.Team2Score.ToString();
                    }
                }
            }
            catch { }
            retriveVizSend();
        }


        DataTable DT1 = new DataTable();
        void clear()
        {

            mycommon.pagerefresh = false;
            mycommon.GameStart = 0;
            mycommon.GameEnd = 0;
            mycommon.MatchStart = 0;
            mycommon.MatchEnd = 0;

        }

        void MatchStart()
        {
            DT = new DataTable();
            DT = objMB.ExeQueryStrRetDTBL(" EXEC SP_VolleyBall_Select @Queryid=11,@MatchID=" + mycommon.MatchId, 1);
            if (DT.Rows.Count > 0)
            {
                mycommon.MatchStart = DT.Rows[0]["EndStatus"].ToString() == "0" ? 1 : 0;
                mycommon.MatchEnd = DT.Rows[0]["EndStatus"].ToString() == "1" ? 1 : 0;
            }
            DataTable DT1 = new DataTable();
            DT1 = objMB.ExeQueryStrRetDTBL(" EXEC SP_VolleyBall_Select @Queryid=12,@MatchID=" + mycommon.MatchId + "", 1);
            if (DT1.Rows.Count > 0)
            {
                DT = new DataTable();
                DT = objMB.ExeQueryStrRetDTBL("EXEC SP_VolleyBall_Select @Queryid=13,@MatchID=" + mycommon.MatchId + ",@SetID=" + DT1.Rows[0][0].ToString(), 1);
                if (DT.Rows.Count > 0)
                {
                    mycommon.GameEnd = 1;
                    btngameend.Enabled = false;
                    mycommon.MatchStart = 0;
                }
                else
                {
                    mycommon.GameEnd = 0;
                    mycommon.MatchStart = 0;
                    btngameend.Enabled = true;
                }

                DT = new DataTable();
                DT = objMB.ExeQueryStrRetDTBL("EXEC SP_VolleyBall_Select @Queryid=14,@MatchID=" + mycommon.MatchId, 1);
                if (DT.Rows.Count > 0)
                {
                    mycommon.GameStart = 0;
                    mycommon.MatchStart = 0;
                    btnGamestart.Enabled = false;
                }
                else
                {
                    mycommon.GameStart = 1;
                    mycommon.MatchStart = 0;
                    btnGamestart.Enabled = true;
                }
                if (mycommon.MatchEnd == 1)
                {
                    mycommon.GameStart = 0;
                    mycommon.MatchStart = 0;
                    btnGamestart.Enabled = false;
                    btngameend.Enabled = false;
                    tableLayoutPanel2.Enabled = false;
                    btnMatchEnd.Enabled = false;
                }
            }
            DT = new DataTable();

            DT = objMB.ExeQueryStrRetDTBL("EXEC SP_VolleyBall_Select @Queryid=8,@MatchID=" + mycommon.MatchId, 1);
            if (DT.Rows.Count > 0)
            {
                mycommon.Team1Setwin = Convert.ToInt32(DT.Rows[0]["TeamASSet"].ToString());
                mycommon.Team2Setwin = Convert.ToInt32(DT.Rows[0]["TeamBSSet"].ToString());
            }
            else
            {
                mycommon.Team1Setwin = 0;
                mycommon.Team2Setwin = 0;
            }
        }

        private void rbS_1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbS_1.Checked)
            {
                rbS_2.Checked = !rbS_1.Checked; retriveVizSend();
                //mycommon.GameStart = 0;
            }
        }

        private void rbS_2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbS_2.Checked)
            {
                rbS_1.Checked = !rbS_2.Checked; retriveVizSend();
                // mycommon.GameStart = 0;
            }
        }

        void retriveVizSend()
        {
            if (objMB.ExeQueryStrRetDTBL("select * from Live where SportID=" + mycommon.SportID + " AND IsLive=1 --AND MatchID=" + mycommon.MatchId + "", 1).Rows.Count > 0)
            {
                if (CommonCls.EnableSendvizData == 0 || !PageLoad) { return; }
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



                    viz.GameStart = mycommon.GameStart.ToString();
                    viz.GameEnd = mycommon.GameEnd.ToString();
                    viz.MatchStart = mycommon.MatchStart.ToString();
                    viz.MatchEnd = mycommon.MatchEnd.ToString();

                    viz.SetID = SetCount.ToString();
                    if (viz.MatchEnd == "1")
                    {
                        viz.TeamASet1Score = txtset1t1.Text;
                        viz.TeamBSet1Score = txtset1t2.Text;

                        viz.TeamASet2Score = txtset2t1.Text;
                        viz.TeamBSet2Score = txtset2t2.Text;

                        viz.TeamASet3Score = txtset3t1.Text;
                        viz.TeamBSet3Score = txtset3t2.Text;


                        viz.TeamASet4Score = txtset4t1.Text; 
                        viz.TeamBSet4Score = txtset4t2.Text;

                        viz.TeamASet5Score = txtset5t1.Text;
                        viz.TeamBSet5Score = txtset5t2.Text;
                    }
                    else
                    {

                        viz.TeamASet1Score = "";
                        viz.TeamBSet1Score = "";

                        viz.TeamASet2Score = "";
                        viz.TeamBSet2Score = "";

                        viz.TeamASet3Score = "";
                        viz.TeamBSet3Score = "";

                        viz.TeamASet4Score = "";
                        viz.TeamBSet4Score = "";

                        viz.TeamASet5Score = "";
                        viz.TeamBSet5Score = "";

                        viz.TeamASet1Score = mycommon.Team1Setwin.ToString();
                        viz.TeamBSet1Score = mycommon.Team2Setwin.ToString();

                    }
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
                    else if (viz.SetID == "4")
                    {
                        viz.TeamACurSetScore = txtset4t1.Text;
                        viz.TeamBCurSetScore = txtset4t2.Text;
                    }
                    else if (viz.SetID == "5")
                    {
                        viz.TeamACurSetScore = txtset5t1.Text;
                        viz.TeamBCurSetScore = txtset5t2.Text;
                    }
                    else
                    {
                        viz.TeamACurSetScore = "0";
                        viz.TeamBCurSetScore = "0";
                    }
                    if (viz.GameEnd == "1")
                    {
                        viz.TeamACurSetScore = "0";
                        viz.TeamBCurSetScore = "0";
                    }

                    // if (mycommon.Type == "Singles")
                    {
                        //viz.TeamAPlayer1 = lblSt1P.Text.ToUpper();
                        //viz.TeamBPlayer1 = lblSt2P.Text.ToUpper();
                        viz.TeamAPlayerfname1 = "";
                        viz.TeamAPlayerlname1 = "";

                        viz.TeamBPlayerfname1 = "";
                        viz.TeamBPlayerlname1 = "";
                        viz.TeamAPlayer2 = "";
                        viz.TeamBPlayer2 = "";
                        if (rbS_1.Checked)
                        {
                            viz.TeamAServe = "1";
                            viz.TeamBServe = "0";
                        }
                        else if (rbS_2.Checked)
                        {
                            viz.TeamAServe = "0";
                            viz.TeamBServe = "1";
                        }
                        else
                        {
                            viz.TeamAServe = "0";
                            viz.TeamBServe = "0";
                        }
                        if (viz.GameStart == "1" || viz.GameEnd == "1" || viz.MatchStart == "1")
                        {
                            viz.TeamAServe = "0";
                            viz.TeamBServe = "0";
                        }
                        viz.SingleorDouble = "1";
                    }


                    Dtgv1.Rows[0]["SetID"] = viz.SetID.ToString();
                    Dtgv1.Rows[0]["BadTeamAPrefix"] = viz.TeamAPrefix.ToString();
                    Dtgv1.Rows[0]["BadTeamBPrefix"] = viz.TeamBPrefix.ToString();
                    Dtgv1.Rows[0]["BadTeamAName"] = viz.TeamAName.ToString().ToUpper();
                    Dtgv1.Rows[0]["BadTeamBName"] = viz.TeamBName.ToString().ToUpper();
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
                    Dtgv1.Rows[0]["BadTeamBCurSetScore"] = viz.TeamBCurSetScore.ToString();

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

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (Convert.ToInt32(gvdatabind.Rows[0].Cells["GameID"].Value) == Convert.ToInt32(gvdatabind.Rows[1].Cells["GameID"].Value))
            {
                if (SetCount == Convert.ToInt32(gvdatabind.Rows[0].Cells["GameID"].Value))
                {
                    try
                    {
                        int matid = mycommon.MatchId;
                        int Setid = Convert.ToInt32(gvdatabind.Rows[0].Cells["GameID"].Value);
                        int point = Convert.ToInt32(gvdatabind.Rows[0].Cells["PointID1"].Value);
                        if (objMB.ExeQueryRetBooDL("EXEC SP_VolleyBall_Manipulation @Queryid=5,@MatchID=" + matid + ",@SetID=" + Setid + ",@PointID=" + point, 1))
                        {
                            bind();
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
                    int Setid = Convert.ToInt32(gvdatabind.Rows[0].Cells["GameID"].Value);
                    int point = Convert.ToInt32(gvdatabind.Rows[0].Cells["PointID1"].Value);
                    if (objMB.ExeQueryRetBooDL("EXEC SP_VolleyBall_Manipulation @Queryid=5,@MatchID=" + matid + ",@SetID=" + Setid + ",@PointID=" + point, 1))
                    {
                        mycommon.Team1Score = 0;
                        mycommon.Team2Score = 0;
                        bindscorescard();
                        bind();
                        loadlastdata();
                    }
                    mycommon.Team1Score = 0;
                    mycommon.Team2Score = 0;
                }
                catch { }
            }

            retriveVizSend();
        }

        void bindscorescard()
        {
            if (SetCount == 1)
            {
                txtset1t1.Text = mycommon.Team1Score.ToString();
                txtset1t2.Text = mycommon.Team2Score.ToString();
            }
            else if (SetCount == 2)
            {
                txtset2t1.Text = mycommon.Team1Score.ToString();
                txtset2t2.Text = mycommon.Team2Score.ToString();
            }
            else if (SetCount == 3)
            {
                txtset3t1.Text = mycommon.Team1Score.ToString();
                txtset3t2.Text = mycommon.Team2Score.ToString();
            }
            else if (SetCount == 4)
            {
                txtset4t1.Text = mycommon.Team1Score.ToString();
                txtset4t2.Text = mycommon.Team2Score.ToString();
            }
            else if (SetCount == 5)
            {
                txtset5t1.Text = mycommon.Team1Score.ToString();
                txtset5t2.Text = mycommon.Team2Score.ToString();
            }
        }

        private void btnMatchStart_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Result = MessageBox.Show("Continue to Match Start", mycommon.ApplicationName+" Info", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (Result == DialogResult.Yes)
                {
                    mycommon.MatchStart = 1;
                    btnMatchStart.Enabled = false;
                    btnMatchEnd.Enabled = true;
                    btnGamestart.Enabled = true;

                    try
                    {
                        objMB.ExeQueryRetBooDL("EXEC SP_VolleyBall_Manipulation @Queryid=6,@MatchID=" + mycommon.MatchId + ",@EndStatus=0", 1);
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
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void btnMatchEnd_Click(object sender, EventArgs e)
        {
            if (btnMatchEnd.Text == "Match End")
            {
                DialogResult Result = MessageBox.Show("Continue to Match End", mycommon.ApplicationName + " Info", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (Result == DialogResult.Yes)
                {
                    mycommon.MatchEnd = 1;
                    btnMatchStart.Enabled = false;
                    btnMatchEnd.Enabled = false;

                    btnGamestart.Enabled = false;
                    btngameend.Enabled = false;
                    try
                    {
                        objMB.ExeQueryRetBooDL("EXEC SP_VolleyBall_Manipulation @Queryid=6,@MatchID=" + mycommon.MatchId + ",@EndStatus=1", 1);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                    btnMatchEnd.Text = "Match Undo";
                }
            }
            else if (btnMatchEnd.Text == "Match Undo")
            {
                mycommon.MatchEnd = 0;
                btnMatchEnd.Enabled = true;
                btngameend.Enabled = true;
                tableLayoutPanel2.Enabled = true;
                try
                {
                    objMB.ExeQueryRetBooDL("EXEC SP_VolleyBall_Manipulation @Queryid=6,@MatchID=" + mycommon.MatchId + ",@EndStatus=0", 1);
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                btnMatchEnd.Text = "Match End";
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
            clear();
            MatchStart();
            mycommon.pagerefresh = true;
            retriveVizSend();
            mycommon.pagerefresh = false;
        }

        private void swapteamside()
        {
            Control ctr1 = tableLayoutPanel2.GetControlFromPosition(0, 0);
            Control ctr2 = tableLayoutPanel2.GetControlFromPosition(1, 0);

            tableLayoutPanel2.SetCellPosition(ctr2, new TableLayoutPanelCellPosition(0, 0));
            tableLayoutPanel2.SetCellPosition(ctr1, new TableLayoutPanelCellPosition(1, 0));
        }

        private void btnswapteam_Click(object sender, EventArgs e)
        {
            swapteamside();
        }

        private void btnmatchundo_Click(object sender, EventArgs e)
        {
            btnMatchEnd.Enabled = true;
            btngameend.Enabled = true;
            tableLayoutPanel2.Enabled = true;
        }

        private void btnpointswap_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to change points?", mycommon.ApplicationName + " Info", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                DataTable dt = new DataTable();
                try
                {
                    dt = objMB.ExeQueryStrRetDTBL("EXEC SP_VolleyBall_Select @Queryid=15,@MatchID=" + mycommon.MatchId + ",@SetID=" + SetCount, 1);
                    if (dt.Rows.Count > 0)
                    {
                        int team1 = Convert.ToInt32(dt.Rows[0]["AScore"]);
                        int team2 = Convert.ToInt32(dt.Rows[0]["BScore"]);
                        if (previousteam == 1)
                        {
                            team1 = Convert.ToInt32(dt.Rows[0]["AScore"]) - previouspoint;
                            team2 = Convert.ToInt32(dt.Rows[0]["BScore"]) + previouspoint;
                        }
                        else if (previousteam == 2)
                        {
                            team2 = Convert.ToInt32(dt.Rows[0]["BScore"]) - previouspoint;
                            team1 = Convert.ToInt32(dt.Rows[0]["AScore"]) + previouspoint;
                        }

                        if (objMB.ExeQueryRetBooDL("update VB_Events set TeamAPoint=" + team1 + ",TeamBPoint=" + team2 + " where MatchID=" + mycommon.MatchId + " AND SetID=" + SetCount + " AND PointID=" + Convert.ToInt32(dt.Rows[0]["PointID"]), 1))
                        {
                            bind();
                            loadlastdata();
                        }
                    }
                    retriveVizSend();
                    btnpointswap.Enabled = false;
                }
                catch { }
            }
        }

        private void lblTname_Click(object sender, EventArgs e)
        {

        }
    }
}
