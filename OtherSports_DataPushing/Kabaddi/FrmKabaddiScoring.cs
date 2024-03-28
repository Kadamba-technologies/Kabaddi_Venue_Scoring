using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OtherSports_DataPushing.Layer;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices;
using System.IO;
//using PCTVVideoControl;
using System.IO;
using System.Configuration;
using System.Diagnostics;
using System.Xml;
using System.Collections;
using System.Threading;
using System.Reflection;
using OtherSports_DataPushing.Kabaddi;
using System.Xml.Serialization;
using clsXmlRead;
using System.Globalization;
using System.Data.SqlClient;

namespace OtherSports_DataPushing
{
    public partial class FrmKabaddiScoring : Form
    {
        KabaddiXmlGenerate Xml = new KabaddiXmlGenerate();
        SendtoViz ObjFndCtrl = new SendtoViz();
        DataTable dt;
        bool isVideocontrol = false;
        string VideoPath = string.Empty;
        double VideoSpeed = 100;
        string Extn = ".AVI";
        string fileName = string.Empty, InningsID = "1";
        MasterDL objDL = new MasterDL();
        Boolean PageLoad = false;
        string defFileName = "000";
        int i = 0;
        decimal setStarttime, setEndtime;
        string setStarttimevideo, setEndtimevideo;
        string Command = string.Empty;
        string singleVideoName = string.Empty;
        bool TouchClick = false, TackleClick = false;
        Boolean RaiderClick = false, DefenderClick = false;
        bool raiderchose = false;
        bool techPoint = false;
        bool isDeclare = false;
        DataTable DTTouch, DTTackle;

        int TeamADipXML;
        int TeamBDipXML;
        int TeamAManualDipXML;
        int TeamBManualDipXML;

        int Temp_matchid;
        int Temp_HalfID;
        public Int32 Score_Matchid
        {
            get
            {
                return Temp_matchid;
            }
            set
            {
                Temp_matchid = value;
            }
        }
        public Int32 Score_HalfID
        {
            get
            {
                return Temp_HalfID;
            }
            set
            {
                Temp_HalfID = value;
            }
        }

        //---------------------------
        string raiderplayerid = string.Empty;

        List<string> getoutplayerA = new List<string>();
        List<string> getoutplayerB = new List<string>();
        List<string> getoutplayerAtemp = new List<string>();
        List<string> getoutplayerBtemp = new List<string>();

        List<string> getclubAinnerplayer = new List<string>();
        List<string> getclubBinnerplayer = new List<string>();
        List<string> getclubAinnerplayertemp = new List<string>();
        List<string> getclubBinnerplayertemp = new List<string>();

        string raideroutcome = string.Empty;
        string raideroutcometype = string.Empty;
        string linebounspoint = string.Empty;
        string Lonapoint = string.Empty;
        string raiderExtrapoint = string.Empty;

        string raideroldplace = string.Empty;
        string videorunningflag = string.Empty;




        public FrmKabaddiScoring()
        {
            InitializeComponent();
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            this.Text = "KABADDI - " + fvi.FileVersion + "    Matchid=" + Score_Matchid.ToString() + ",Halfid=" + Score_HalfID.ToString();
            this.Update();
        }


        private void FrmScoreingPage_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = "KABADDI - 1.0.4.0" + "    Matchid=" + Score_Matchid.ToString() + ",Halfid=" + Score_HalfID.ToString();
                CommonCls.MatchId = Score_Matchid;
                CommonCls.HalfID = Score_HalfID;
                lblmatchid.Text = CommonCls.MatchId.ToString();
                try
                {
                    dt = new DataTable();
                    dt.Columns.Add("ClubID", typeof(int));
                    dt.Columns.Add("Name", typeof(string));
                    dt.Rows.Add(CommonCls.ClubId1, CommonCls.Club1Prefix);
                    dt.Rows.Add(CommonCls.ClubId2, CommonCls.Club2Prefix);
                    cbTeam.DataSource = dt;
                    cbTeam.DisplayMember = "Name";
                    cbTeam.ValueMember = "ClubID";
                    lblTeamA.Text = CommonCls.Club1Prefix;
                    lblTeamA2.Text = CommonCls.Club1Prefix;
                    lblTeamB.Text = CommonCls.Club2Prefix;
                    lblTeamB2.Text = CommonCls.Club2Prefix;
                    lblTeamANameGoal.Text = CommonCls.Club1Prefix;
                    lblTeamBNameGoal.Text = CommonCls.Club2Prefix;

                    rbTeamAIN.Text = CommonCls.Club1Prefix;
                    rbTeamBIN.Text = CommonCls.Club2Prefix;

                    MasterDL obj = new MasterDL();
                    CommonCls.RaidNo = Convert.ToInt32(obj.ExeQueryStrRetStrDL("select ISNULL(MAX(RaidNo),0) from Raid where Matchid=" + CommonCls.MatchId + "", 1));
                    int PreviousRaiderID = obj.ExeQueryStrDL("Select RaiderID from Raid Where MatchID=" + CommonCls.MatchId + " And RaidNo=" + CommonCls.RaidNo + "", 1);
                    if (CommonCls.RaidNo != 0)
                    {
                        CommonCls.RaidClubId = obj.ExeQueryStrDL("Select L.ClubID from Raid R Join Lineups L ON R.MatchID=L.MatchID And R.RaiderID=L.PlayerID Where R.MatchID=" + CommonCls.MatchId + " And R.RaiderID=" + PreviousRaiderID + "", 1); // Previous Raid TeamID
                        CommonCls.DefenceClubId = obj.ExeQueryStrDL("Select LeftClubID from MatchHalf Where Matchid=" + CommonCls.MatchId + " And LeftClubID Not in(" + CommonCls.RaidClubId + ")", 1); // Previous Defender TeamID
                    }
                    else
                    {
                        CommonCls.RaidClubId = obj.ExeQueryStrDL("Select Case When Description='Ride' And LeftClubID=TossWin Then LeftClubID When Description='Ride' And RightClubID=TossWin Then RightClubID When Description='Defence' And LeftClubID=TossWin Then RightClubID When Description='Defence' And RightClubID=TossWin Then LeftClubID End from MatchHalf Where Matchid=" + CommonCls.MatchId + " And HalfID=1", 1);
                        CommonCls.DefenceClubId = obj.ExeQueryStrDL("Select LeftClubID from MatchHalf Where Matchid=" + CommonCls.MatchId + " And LeftClubID Not in(" + CommonCls.RaidClubId + ")", 1);
                    }
                    if (CommonCls.ClubId1 == CommonCls.RaidClubId)
                        lblRaidTeam.Text = CommonCls.Club1Prefix;
                    else if (CommonCls.ClubId2 == CommonCls.RaidClubId)
                        lblRaidTeam.Text = CommonCls.Club2Prefix;
                    if (CommonCls.ClubId1 == CommonCls.DefenceClubId)
                        lblDefenderTeam.Text = CommonCls.Club1Prefix;
                    else if (CommonCls.ClubId2 == CommonCls.DefenceClubId)
                        lblDefenderTeam.Text = CommonCls.Club2Prefix;
                    DTTouch = new DataTable();
                    DTTouch = obj.ExeQueryStrRetDTDL("Select ID,dbo.fn_GetEventName(ID)EventType From EventMaster where EventGroup='Touch'", 1);

                    DTTackle = new DataTable();
                    DTTackle = obj.ExeQueryStrRetDTDL("Select ID,dbo.fn_GetEventName(ID)EventType From EventMaster where EventGroup='Tackle'", 1);
                }
                catch
                {
                    DTTouch = new DataTable();
                    DTTouch = objDL.ExeQueryStrRetDTDL("Select ID,dbo.fn_GetEventName(ID)EventType From EventMaster where EventGroup='Touch'", 1);

                    DTTackle = new DataTable();
                    DTTackle = objDL.ExeQueryStrRetDTDL("Select ID,dbo.fn_GetEventName(ID)EventType From EventMaster where EventGroup='Tackle'", 1);
                }
                try
                {
                    string str = objDL.ExeQueryStrRetStrDL("select top 1 Isnull(R.TimerEnd,M.MatchClock) from KB_Matches M LEFT JOIN raid R ON M.MatchId=R.MatchID where M.MatchId=" + CommonCls.MatchId + " order by R.RaidNo desc", 1);
                    CommonCls.LastTime = default(DateTime).Add(Convert.ToDateTime(str).TimeOfDay);

                    startoffset = Convert.ToInt32(TimeSpan.FromTicks(CommonCls.LastTime.Ticks).TotalSeconds);
                    mySW = new Stopwatch();

                    TimeSpan span3 = TimeSpan.FromSeconds(startoffset).Add(mySW.Elapsed);
                    dtp_MatchClock.Value = DateTime.ParseExact(span3.ToString(@"mm\:ss"), "mm:ss", CultureInfo.InvariantCulture);
                    span3 = TimeSpan.FromSeconds(CurrntTime - startoffset + 1).Subtract(mySW.Elapsed);
                    dtp_ElapseClock.Value = DateTime.ParseExact(span3.ToString(@"mm\:ss"), "mm:ss", CultureInfo.InvariantCulture);
                }
                catch
                {
                }


                CommonCls.DTListEvents = new DataTable();
                CommonCls.DTListEvents.Columns.Add("MatchID", typeof(int));
                CommonCls.DTListEvents.Columns.Add("HalfID", typeof(int));
                CommonCls.DTListEvents.Columns.Add("RaidNo", typeof(int));
                CommonCls.DTListEvents.Columns.Add("EventId", typeof(int));
                CommonCls.DTListEvents.Columns.Add("EventType", typeof(int));
                CommonCls.DTListEvents.Columns.Add("PX", typeof(int));
                CommonCls.DTListEvents.Columns.Add("PY", typeof(int));
                CommonCls.DTListEvents.Columns.Add("setEndtime", typeof(string));
                CommonCls.DTListEvents.Columns.Add("Initiator", typeof(string));
                CommonCls.DTListEvents.Columns.Add("Time", typeof(string));

                CommonCls.DTListOutPlayer = new DataTable();
                CommonCls.DTListOutPlayer.Columns.Add("MatchID", typeof(int));
                CommonCls.DTListOutPlayer.Columns.Add("HalfID", typeof(int));
                CommonCls.DTListOutPlayer.Columns.Add("RaidNo", typeof(int));
                CommonCls.DTListOutPlayer.Columns.Add("EventId", typeof(int));
                CommonCls.DTListOutPlayer.Columns.Add("PlayerID", typeof(int));
                CommonCls.DTListOutPlayer.Columns.Add("KeyDefender", typeof(int));
                CommonCls.DTListOutPlayer.Columns.Add("SupportedKeyDefender", typeof(int));
                CommonCls.DTListOutPlayer.Columns.Add("IsOut", typeof(int));
                CommonCls.DTListOutPlayer.Columns.Add("OutType", typeof(int));
                CommonCls.DTListOutPlayer.Columns.Add("ISInitiator", typeof(int));
                vizGridHeader();
                loadInplayerList("");
                Reset();
                pnlEvents.Enabled = false;
                pnlSpecialCase.Enabled = false;
                dt = new DataTable();
                dt = objDL.ExeQueryStrRetDTDL("SELECT * FROM MatchHalf where  matchID= " + CommonCls.MatchId + " and HalfStart=1 and HalfEnd=0", 1);
                //   GVscorecard.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    CommonCls.HalfID = Convert.ToInt32(dt.Rows[0]["HalfID"]);
                    lblhalfid.Text = dt.Rows[0]["HalfID"].ToString();

                    BtnStartEnd.Enabled = false;
                    btnHalfStart.Enabled = true;
                    BtnStartEnd.Enabled = false;
                }
                else
                {
                    dt = new DataTable();
                    dt = objDL.ExeQueryStrRetDTDL("SELECT Min(HalfID)HalfID FROM MatchHalf where  matchID= " + CommonCls.MatchId + " and HalfStart=0 and HalfEnd=0", 1);

                    if (dt.Rows.Count > 0)
                    {
                        TimerReset();
                        if (dt.Rows[0]["HalfID"].ToString() != string.Empty)
                        {
                            CommonCls.HalfID = Convert.ToInt32(dt.Rows[0]["HalfID"]);
                            lblhalfid.Text = dt.Rows[0]["HalfID"].ToString();

                            BtnStartEnd.Enabled = false;
                            btnHalfStart.Enabled = true;
                            BtnStartEnd.Enabled = false;
                        }
                        else
                        {

                            extraTimeToolStripMenuItem.Visible = true;
                            menuStrip1.Refresh();
                            MessageBox.Show("2 Half are Completed", "Kabaddi Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CommonCls.HalfID = 2;
                            BtnStartEnd.Enabled = false;
                            btnHalfStart.Enabled = false;
                            BtnStartEnd.Enabled = true;
                        }

                    }
                }
                if (objDL.ExeQueryStrRetDTDL("Select * from Raid Where Matchid=" + CommonCls.MatchId + " And HalfID=" + CommonCls.HalfID + "", 1).Rows.Count > 0)
                {
                    btnHalfStart.Text = "Half Continue";
                }
                else
                    btnHalfStart.Text = "Half Start";
                PageLoad = true;
                btnCard.Enabled = false;
                btnTechnicalPoint.Enabled = false;
                try
                {
                    CommonCls.LastTime = default(DateTime).Add(Convert.ToDateTime("00:00:00").TimeOfDay);
                }
                catch { }
                Reset();
            }
            catch { }
        }

        void loadInplayerList(string Filter)
        {
            try
            {
                MasterDL obj = new MasterDL();
                dt = new DataTable();
                dt = obj.ExeQueryStrRetDTDL("Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20))+'('+dbo.fn_getTeamnameprefix(L.clubid)+')' AS firstname,L.JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + Temp_matchid + " " + Filter + "", 1);
                lbPlayerList.DataSource = dt;
                lbPlayerList.DisplayMember = "firstname";
                lbPlayerList.ValueMember = "playerid";
                lbPlayerList.SelectedIndex = -1;
            }
            catch { }
        }

        DataSet sevensPlayerDS;
        void LoadPlayer()
        {
            try
            {
                MasterDL obj = new MasterDL();
                if (obj.ExeQueryStrRetStrDL("select COUNT(RaidNo) from Raid where Matchid=" + CommonCls.MatchId + "", 1) == "0")
                {
                    // DataSet sevensPlayerDS = obj.ExeQueryStrRetDsDL("select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,L.JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.ClubId1 + " and L.issub=0 order by CAST(JercyNo AS INT);select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,L.JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.ClubId2 + "   and L.issub=0 order by CAST(JercyNo AS INT)", 1);
                    sevensPlayerDS = new DataSet();
                    sevensPlayerDS = obj.ExeQueryStrRetDsDL("SP_GetCurrentIN_Outplayer " + CommonCls.MatchId + "", 1);
                    lbTeamAINList.DataSource = sevensPlayerDS.Tables[0];
                    lbTeamAINList.DisplayMember = "firstname";
                    lbTeamAINList.ValueMember = "playerid";

                    lbTeamBINList.DataSource = sevensPlayerDS.Tables[1];
                    lbTeamBINList.DisplayMember = "firstname";
                    lbTeamBINList.ValueMember = "playerid";

                    //  sevensPlayerDS = obj.ExeQueryStrRetDsDL("select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,L.JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.ClubId1 + " and L.issub=0 order by CAST(JercyNo AS INT);select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,L.JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.ClubId2 + "   and L.issub=0 order by CAST(JercyNo AS INT)", 1);
                    sevensPlayerDS = new DataSet();
                    sevensPlayerDS = obj.ExeQueryStrRetDsDL("SP_GetCurrentIN_Outplayer " + CommonCls.MatchId + "", 1);
                    lbTeamAINList1.DataSource = sevensPlayerDS.Tables[0];
                    lbTeamAINList1.DisplayMember = "firstname";
                    lbTeamAINList1.ValueMember = "playerid";

                    lbTeamBINList1.DataSource = sevensPlayerDS.Tables[1];
                    lbTeamBINList1.DisplayMember = "firstname";
                    lbTeamBINList1.ValueMember = "playerid";
                    //INOUTPlayer();

                    lbTeamAOutList.DataSource = null;
                    lbTeamBOutList.DataSource = null;
                }
                else
                {
                    sevensPlayerDS = new DataSet();
                    sevensPlayerDS = obj.ExeQueryStrRetDsDL("SP_GetCurrentIN_Outplayer " + CommonCls.MatchId + "", 1);
                    //   dt = new DataTable();
                    //dt = obj.ExeQueryStrRetDTDL("Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.ClubId1 + " and L.issub=0 AND PlayerID NOT IN(Select PlayerID from OutPlayerRef Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.ClubId1 + " AND RaidNo=" + CommonCls.RaidNo + ") Union All Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.ClubId1 + " and L.issub=0 AND PlayerID IN(Select PlayerID from Innerplayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.ClubId1 + " AND RaidNo=" + CommonCls.RaidNo + ") order by JercyNo", 1);
                    // lbTeamAINList.DataSource = obj.ExeQueryStrRetDTDL("Select * FROM(Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.ClubId1 + " and L.issub=0 AND PlayerID NOT IN(Select PlayerID from OutPlayerRef Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.ClubId1 + " AND RaidNo=" + CommonCls.RaidNo + ") AND PlayerID Not IN(Select PlayerID from SuspendedPlayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.ClubId1 + " And Issuspend=1) Union All Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.ClubId1 + " and L.issub=0 AND PlayerID IN(Select PlayerID from Innerplayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.ClubId1 + " AND RaidNo=" + CommonCls.RaidNo + ") AND PlayerID Not IN(Select PlayerID from SuspendedPlayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.ClubId1 + " And Issuspend=1))A GROUP BY playerid,JercyNo, firstname order by JercyNo", 1);
                    lbTeamAINList.DataSource = sevensPlayerDS.Tables[0];
                    lbTeamAINList.DisplayMember = "firstname";
                    lbTeamAINList.ValueMember = "playerid";

                    // dt = new DataTable();
                    //dt = obj.ExeQueryStrRetDTDL("Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.ClubId2 + " and L.issub=0 AND PlayerID NOT IN(Select PlayerID from OutPlayerRef Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.ClubId2 + " AND RaidNo=" + CommonCls.RaidNo + ") Union All Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.ClubId2 + " and L.issub=0 AND PlayerID IN(Select PlayerID from Innerplayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.ClubId2 + " AND RaidNo=" + CommonCls.RaidNo + ") order by JercyNo", 1);
                    // lbTeamBINList.DataSource = obj.ExeQueryStrRetDTDL("Select * FROM(Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.ClubId2 + " and L.issub=0 AND PlayerID NOT IN(Select PlayerID from OutPlayerRef Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.ClubId2 + " AND RaidNo=" + CommonCls.RaidNo + ") AND PlayerID Not IN(Select PlayerID from SuspendedPlayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.ClubId2 + " And Issuspend=1) Union All Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.ClubId2 + " and L.issub=0 AND PlayerID IN(Select PlayerID from Innerplayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.ClubId2 + " AND RaidNo=" + CommonCls.RaidNo + ") AND PlayerID Not IN(Select PlayerID from SuspendedPlayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.ClubId2 + " And Issuspend=1))A GROUP BY playerid,JercyNo,firstname order by JercyNo", 1); ;
                    lbTeamBINList.DataSource = sevensPlayerDS.Tables[1];
                    lbTeamBINList.DisplayMember = "firstname";
                    lbTeamBINList.ValueMember = "playerid";


                    sevensPlayerDS = new DataSet();
                    sevensPlayerDS = obj.ExeQueryStrRetDsDL("SP_GetCurrentIN_Outplayer " + CommonCls.MatchId + "", 1);
                    //dt = new DataTable();
                    //dt = obj.ExeQueryStrRetDTDL("Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.ClubId1 + " and L.issub=0 AND PlayerID NOT IN(Select PlayerID from OutPlayerRef Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.ClubId1 + " AND RaidNo=" + CommonCls.RaidNo + ") Union All Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.ClubId1 + " and L.issub=0 AND PlayerID IN(Select PlayerID from Innerplayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.ClubId1 + " AND RaidNo=" + CommonCls.RaidNo + ") order by JercyNo", 1);
                    //lbTeamAINList1.DataSource = obj.ExeQueryStrRetDTDL("Select * FROM(Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.ClubId1 + " and L.issub=0 AND PlayerID NOT IN(Select PlayerID from OutPlayerRef Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.ClubId1 + " AND RaidNo=" + CommonCls.RaidNo + ") AND PlayerID Not IN(Select PlayerID from SuspendedPlayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.ClubId1 + " And Issuspend=1) Union All Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.ClubId1 + " and L.issub=0 AND PlayerID IN(Select PlayerID from Innerplayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.ClubId1 + " AND RaidNo=" + CommonCls.RaidNo + ") AND PlayerID Not IN(Select PlayerID from SuspendedPlayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.ClubId1 + " And Issuspend=1))A GROUP BY playerid,JercyNo,firstname order by JercyNo", 1); ;
                    lbTeamAINList1.DataSource = sevensPlayerDS.Tables[0];
                    lbTeamAINList1.DisplayMember = "firstname";
                    lbTeamAINList1.ValueMember = "playerid";

                    //dt = new DataTable();
                    //dt = obj.ExeQueryStrRetDTDL("Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.ClubId2 + " and L.issub=0 AND PlayerID NOT IN(Select PlayerID from OutPlayerRef Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.ClubId2 + " AND RaidNo=" + CommonCls.RaidNo + ") Union All Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.ClubId2 + " and L.issub=0 AND PlayerID IN(Select PlayerID from Innerplayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.ClubId2 + " AND RaidNo=" + CommonCls.RaidNo + ") order by JercyNo", 1);
                    //lbTeamBINList1.DataSource = obj.ExeQueryStrRetDTDL("Select * FROM(Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.ClubId2 + " and L.issub=0 AND PlayerID NOT IN(Select PlayerID from OutPlayerRef Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.ClubId2 + " AND RaidNo=" + CommonCls.RaidNo + ") AND PlayerID Not IN(Select PlayerID from SuspendedPlayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.ClubId2 + " And Issuspend=1) Union All Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.ClubId2 + " and L.issub=0 AND PlayerID IN(Select PlayerID from Innerplayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.ClubId2 + " AND RaidNo=" + CommonCls.RaidNo + ") AND PlayerID Not IN(Select PlayerID from SuspendedPlayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.ClubId2 + " And Issuspend=1))A GROUP BY playerid,JercyNo,firstname order by JercyNo", 1);
                    lbTeamBINList1.DataSource = sevensPlayerDS.Tables[1];
                    lbTeamBINList1.DisplayMember = "firstname";
                    lbTeamBINList1.ValueMember = "playerid";

                    //DataTable dt1 = new DataTable();
                    //dt1 = obj.ExeQueryStrRetDTDL("Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.ClubId1 + " and L.issub=0 AND PlayerID IN(Select PlayerID from OutPlayerRef Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.ClubId1 + " AND RaidNo=" + CommonCls.RaidNo + ") And PlayerID Not IN(Select PlayerID from Innerplayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.ClubId1 + " AND RaidNo=" + CommonCls.RaidNo + ") order by CAST(JercyNo AS INT)", 1);
                    //lbTeamAOutList.DataSource = dt1;
                    //lbTeamAOutList.DataSource = obj.ExeQueryStrRetDTDL("Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id INNER JOIN OutPlayerRef OPR ON OPR.Matchid=L.MatchID AND OPR.Clubid=L.ClubID And OPR.PlayerId=L.PlayerID WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.ClubId1 + " and L.issub=0 AND RaidNo=" + CommonCls.RaidNo + " And OPR.PlayerID Not IN(Select PlayerID from Innerplayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.ClubId1 + " AND RaidNo=" + CommonCls.RaidNo + ") AND OPR.PlayerID Not IN(Select PlayerID from SuspendedPlayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.ClubId1 + " And Issuspend=1) GROUP BY L.playerid,L.JercyNo,CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END order by MAX(OPR.Orderno)", 1);
                    lbTeamAOutList.DataSource = sevensPlayerDS.Tables[2];
                    lbTeamAOutList.DisplayMember = "firstname";
                    lbTeamAOutList.ValueMember = "playerid";
                    try
                    {
                        lbTeamAOutList.SelectedIndex = 0;
                    }
                    catch { }
                    //dt = new DataTable();
                    //dt = obj.ExeQueryStrRetDTDL("Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.ClubId2 + " and L.issub=0 AND PlayerID IN(Select PlayerID from OutPlayerRef Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.ClubId2 + " AND RaidNo=" + CommonCls.RaidNo + ") And PlayerID Not IN(Select PlayerID from Innerplayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.ClubId2 + " AND RaidNo=" + CommonCls.RaidNo + ") order by CAST(JercyNo AS INT)", 1);
                    //lbTeamBOutList.DataSource = obj.ExeQueryStrRetDTDL("Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.ClubId2 + " and L.issub=0 AND PlayerID IN(Select PlayerID from OutPlayerRef Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.ClubId2 + " AND RaidNo=" + CommonCls.RaidNo + ") And PlayerID Not IN(Select PlayerID from Innerplayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.ClubId2 + " AND RaidNo=" + CommonCls.RaidNo + ") order by CAST(JercyNo AS INT)", 1);
                    //lbTeamBOutList.DataSource = obj.ExeQueryStrRetDTDL("Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id INNER JOIN OutPlayerRef OPR ON OPR.Matchid=L.MatchID AND OPR.Clubid=L.ClubID And OPR.PlayerId=L.PlayerID WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.ClubId2 + " and L.issub=0 AND RaidNo=" + CommonCls.RaidNo + " And OPR.PlayerID Not IN(Select PlayerID from Innerplayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.ClubId2 + " AND RaidNo=" + CommonCls.RaidNo + ") AND OPR.PlayerID Not IN(Select PlayerID from SuspendedPlayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.ClubId2 + " And Issuspend=1) GROUP BY L.playerid,L.JercyNo,CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END order by MAX(OPR.Orderno) ", 1);
                    lbTeamBOutList.DataSource = sevensPlayerDS.Tables[3];
                    lbTeamBOutList.DisplayMember = "firstname";
                    lbTeamBOutList.ValueMember = "playerid";
                    try
                    {
                        lbTeamBOutList.SelectedIndex = 0;
                    }
                    catch { }
                }

                //    DataSet subPlayerDS = obj.ExeQueryStrRetDsDL("select Distinct L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.ClubId1 + "   and L.issub=1 order by CAST(JercyNo AS INT);select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,L.JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.ClubId2 + "   and L.issub=1 order by CAST(JercyNo AS INT)", 1);
                DataSet subPlayerDS = obj.ExeQueryStrRetDsDL("SP_GetCurrentIN_Outplayer " + CommonCls.MatchId + "", 1);
                lbTeamASubList.DataSource = subPlayerDS.Tables[4];
                lbTeamASubList.DisplayMember = "firstname";
                lbTeamASubList.ValueMember = "playerid";

                lbTeamBSubList.DataSource = subPlayerDS.Tables[5];
                lbTeamBSubList.DisplayMember = "firstname";
                lbTeamBSubList.ValueMember = "playerid";

                try
                {
                    lbTeamAINList.BackColor = Color.FromName(CommonCls.TeamAColor);
                    lbTeamAINList1.BackColor = Color.FromName(CommonCls.TeamAColor);
                    lbTeamASubList.BackColor = Color.FromName(CommonCls.TeamAColor);
                    lbTeamAOutList.BackColor = Color.FromName(CommonCls.TeamAColor);
                }
                catch
                {
                    lbTeamAINList.BackColor = Color.FromName("Silver");
                    lbTeamAINList1.BackColor = Color.FromName("Silver");
                    lbTeamASubList.BackColor = Color.FromName("Silver");
                    lbTeamAOutList.BackColor = Color.FromName("Silver");
                }

                try
                {
                    lbTeamBINList.BackColor = Color.FromName(CommonCls.TeamBColor);
                    lbTeamBINList1.BackColor = Color.FromName(CommonCls.TeamBColor);
                    lbTeamBSubList.BackColor = Color.FromName(CommonCls.TeamBColor);
                    lbTeamBOutList.BackColor = Color.FromName(CommonCls.TeamBColor);
                }
                catch
                {
                    lbTeamBINList.BackColor = Color.FromName("Silver");
                    lbTeamBINList1.BackColor = Color.FromName("Silver");
                    lbTeamBSubList.BackColor = Color.FromName("Silver");
                    lbTeamBOutList.BackColor = Color.FromName("Silver");
                }
                //DataSet sevensPlayerDS = obj.ExeQueryStrRetDsDL("select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+'-'+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,L.JercyNo   from lineups L INNER JOIN Player P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.ClubId1 + " and L.issub=0;select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+'-'+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,L.JercyNo   from lineups L INNER JOIN Player P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.ClubId2 + "   and L.issub=0 order by CAST(JercyNo AS INT)", 1);

                try
                {
                    dt = new DataTable();
                    // dt = obj.ExeQueryStrRetDTDL("SP_GetRaidWise " + CommonCls.MatchId + "," + CommonCls.HalfID + "", 1);                    

                    WriteToLog("Before Grid Update");
                    dt = obj.ExeQueryStrRetDTDL("SP_GetRaidMatchWise " + CommonCls.MatchId + "," + (chkScore.Checked ? "1" : "2"), 1);
                    gvRaidEvent.AutoGenerateColumns = false;
                    gvRaidEvent.DataSource = dt;

                    WriteToLog("After Grid Update");
                    dt = new DataTable();
                    dt = obj.ExeQueryStrRetDTDL("SP_GetRaidwiseScore " + CommonCls.MatchId + "," + CommonCls.HalfID + "", 1);
                    gvRaidPoint.AutoGenerateColumns = false;
                    gvRaidPoint.DataSource = dt;
                }
                catch { }
            }

            catch
            { }
            BindDIP();
        }

        public void WriteToLog(string text)
        {
            //if (EnLog.Checked == true)
            //{
            string sTemp = System.Windows.Forms.Application.StartupPath + "\\Loadtime_Log_" + DateTime.Now.ToString("dd_MM") + ".txt";
            FileStream Fs = new FileStream(sTemp, FileMode.OpenOrCreate | FileMode.Append);
            StreamWriter st = new StreamWriter(Fs);
            string dttemp = DateTime.Now.ToString("[dd:MM:yyyy] [HH:mm:ss:ffff]"); //"[" + DateTime.Now.Day + ":" + DateTime.Now.Month + ":" + DateTime.Now.Year + "] [" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + ":" + DateTime.Now.Millisecond + "]";
            st.WriteLine(dttemp + "\t" + text);
            st.Close();
            // }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            //try
            //{
            //    timer2.Enabled = true;
            //    timer2.Interval = 1000;
            //    Stopwatch stopWatch = new Stopwatch();
            //    stopWatch.Start();
            //    TimeSpan ts = stopWatch.Elapsed;


            //    // lblMatchTime.Text = elapsedTime;
            //    // if (lblMatchTime.Text != "00:00:00")
            //    {
            //        Stopwatch sw = Stopwatch.StartNew();
            //    }


            //    for (int index = 0; index < 10; index++)
            //    {
            //        //string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            //        //             ts.Hours, ts.Minutes, ts.Seconds,
            //        //             ts.Milliseconds / 10);
            //        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}",
            //                     ts.Hours, ts.Minutes, ts.Seconds);
            //        lblMatchTime.Text = elapsedTime;
            //    }

            //}
            //catch { }

        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        { }

        private void btnTouch_Click(object sender, EventArgs e)
        {
            //TouchClick = true;
            //TackleClick = false;
            //CommonCls.EventTypeId = 1;
            //CommonCls.EventID = CommonCls.EventID + 1;
            //lblEventID.Text = CommonCls.EventID.ToString();

            //lbKeyDefender.SelectedIndex = -1;
            //lbSupportedDefender.SelectedIndex = -1;
            //pnlDefender.Show(); pnlDefender.BringToFront();
            //pnlPitchMapMsg.Show(); pnlPitchMapMsg.BringToFront();

            TouchClick = true;
            TackleClick = false;
            bonuscheck = false;
            if (CommonCls.PX == 0 && CommonCls.PY == 0)
            {
                //  pnlPitchMapMsg.Show(); pnlPitchMapMsg.BringToFront();
                //  return; 
            }
            contextMenuStrip1.Items.Clear();
            //contextMenuStrip1.Items.Add("Hand touch");
            //contextMenuStrip1.Items.Add("Toe Touch");
            //contextMenuStrip1.Items.Add("Dubki");
            //contextMenuStrip1.Items.Add("Front Kick");
            //contextMenuStrip1.Items.Add("Escape");
            //contextMenuStrip1.Items.Add("Back Kick");
            //contextMenuStrip1.Items.Add("Jump");


            // Command at 06Oct18
            //contextMenuStrip1.Items.Add("Hand touch");
            //contextMenuStrip1.Items.Add("Toe Touch");
            //contextMenuStrip1.Items.Add("Dubki");
            //contextMenuStrip1.Items.Add("Front Kick");
            //contextMenuStrip1.Items.Add("Charge");
            //contextMenuStrip1.Items.Add("Back Kick");
            //contextMenuStrip1.Items.Add("Dive");
            //contextMenuStrip1.Items.Add("Jump");
            //contextMenuStrip1.Items.Add("Other Touch");
            foreach (DataRow dr in DTTouch.Rows)
                contextMenuStrip1.Items.Add(dr["EventType"].ToString());

            //contextMenuStrip1.Show(btnTouch, new Point(btnTouch.Width, 0));
            contextMenuStrip1_ItemClicked(btnTouch, null);
            // contextMenuStrip1.i
            pnlDefender.Show(); pnlDefender.BringToFront();
        }

        private void btnTackle_Click(object sender, EventArgs e)
        {
            //TouchClick = false;
            //TackleClick = true;

            //CommonCls.EventTypeId = 9;
            //CommonCls.EventID = CommonCls.EventID + 1;
            //lblEventID.Text = CommonCls.EventID.ToString();

            //lbKeyDefender.SelectedIndex = -1;
            //lbSupportedDefender.SelectedIndex = -1;
            //pnlKeyDefender.Show(); pnlKeyDefender.BringToFront();
            //pnlPitchMapMsg.Show(); pnlPitchMapMsg.BringToFront();

            TouchClick = false;
            TackleClick = true;
            bonuscheck = false;
            if (CommonCls.PX == 0 && CommonCls.PY == 0)
            {
                // pnlPitchMapMsg.Show(); pnlPitchMapMsg.BringToFront();
                // return; 
            }
            contextMenuStrip1.Items.Clear();
            //contextMenuStrip1.Items.Add("Ankle Hold");
            //contextMenuStrip1.Items.Add("Dash");
            //contextMenuStrip1.Items.Add("Hand Hold");
            //contextMenuStrip1.Items.Add("Thigh Hold");
            //contextMenuStrip1.Items.Add("Block");
            //contextMenuStrip1.Items.Add("Back Hold");
            //contextMenuStrip1.Items.Add("Chain");


            // Command at 06Oct18
            //contextMenuStrip1.Items.Add("Ankle Hold");
            //contextMenuStrip1.Items.Add("Pushed out (dash)");
            //contextMenuStrip1.Items.Add("Hand Hold");
            //contextMenuStrip1.Items.Add("Knee Hold");
            //contextMenuStrip1.Items.Add("Waist Hold");
            //contextMenuStrip1.Items.Add("Thigh Hold");
            //contextMenuStrip1.Items.Add("Block");
            //contextMenuStrip1.Items.Add("Body Hold ");
            //contextMenuStrip1.Items.Add("Back Hold");
            //contextMenuStrip1.Items.Add("Chain");
            //contextMenuStrip1.Items.Add("Other Tackle");

            foreach (DataRow dr in DTTackle.Rows)
                contextMenuStrip1.Items.Add(dr["EventType"].ToString());

            //contextMenuStrip1.Show(btnTackle, new Point(btnTackle.Width, 0));
            contextMenuStrip1_ItemClicked(btnTackle, null);
            //contextMenuStrip1. 
            //  pnlDefender.Show(); pnlDefender.BringToFront();
        }


        private void btnDefenderOutType_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Items.Clear();
            contextMenuStrip1.Items.Add("Lineout");
            contextMenuStrip1.Items.Add("Foul");
            contextMenuStrip1.Show(btnDefenderOutType, new Point(btnDefenderOutType.Width, 0));
            RaiderClick = false;
            DefenderClick = true;
        }

        private void btnRaiderOutType_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Items.Clear();
            contextMenuStrip1.Items.Add("Lineout");
            contextMenuStrip1.Items.Add("Foul");
            contextMenuStrip1.Items.Add("Baulk Line Fault");
            contextMenuStrip1.Items.Add("Tackle");
            contextMenuStrip1.Items.Add("Timeout");
            contextMenuStrip1.Items.Add("Noword");
            contextMenuStrip1.Show(btnRaiderOutType, new Point(btnRaiderOutType.Width, 0));

            RaiderClick = true;
            DefenderClick = false;
        }

        private void btnOutCome_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Items.Clear();
            contextMenuStrip1.Items.Add("Success");
            contextMenuStrip1.Items.Add("Un Success");
            contextMenuStrip1.Items.Add("Empty Raid");
            contextMenuStrip1.Show(btnOutCome, new Point(btnOutCome.Width, 0));
        }

        private void btnCard_Click(object sender, EventArgs e)
        {
            if (BtnStartEnd.Text == "Raid Start")
            {
                showLineoutPlayers();
            }
            contextMenuStrip1.Items.Clear();
            contextMenuStrip1.Items.Add("Green Card");
            contextMenuStrip1.Items.Add("Yellow Card");
            contextMenuStrip1.Items.Add("Red Card");
            contextMenuStrip1.Items.Add("Foul");
            contextMenuStrip1.Show(btnCard, new Point(btnCard.Width, 0));
        }
        Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
        string sendtxt = "";
        //latest
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            lbDefender.SelectionMode = SelectionMode.MultiSimple;
            sendtxt = "";
            //stopwatch.Stop();
            // dt = new DataTable();
            //  dt = objDL.ExeQueryStrRetDTDL("Select * from EventMaster Where EventName ='" + e.ClickedItem.Text.Trim() + "'", 1);
            try
            {
                Button s = sender as Button;
                sendtxt = s.Text;
            }
            catch
            {

            }
            dt = new DataTable();
            if (sendtxt == "Tackle")
            {
                dt = objDL.ExeQueryStrRetDTDL("Select * from EventMaster Where EventName ='Other Tackle' ", 1);
            }
            if (sendtxt == "Touch")
            {
                dt = objDL.ExeQueryStrRetDTDL("Select * from EventMaster Where EventName ='Other Touch' ", 1);
            }
            if (sendtxt != "Tackle" && sendtxt != "Touch")
            {

                dt = objDL.ExeQueryStrRetDTDL("Select * from EventMaster Where EventName ='" + e.ClickedItem.Text.Trim() + "'", 1);
            }
            #region old
            //if (dt.Rows.Count > 0)
            //{
            //    CommonCls.EventTypeId = Convert.ToInt32(dt.Rows[0]["ID"]);
            //    if (CommonCls.EventTypeId != 31 && CommonCls.EventTypeId != 32 && CommonCls.EventTypeId != 37 && CommonCls.EventTypeId != 41 && CommonCls.EventTypeId != 44 && CommonCls.EventTypeId != 36 && CommonCls.EventTypeId != 38 && CommonCls.EventTypeId != 39 && CommonCls.EventTypeId != 40 && CommonCls.EventTypeId != 42 && CommonCls.EventTypeId != 43 && CommonCls.EventTypeId != 45)
            //    {
            //        CommonCls.EventID = CommonCls.EventID + 1;
            //        lblEventID.Text = CommonCls.EventID.ToString();
            //    }
            //    lbKeyDefender.SelectedIndex = -1;
            //    lbSupportedDefender.SelectedIndex = -1;
            //    if (CommonCls.EventTypeId == 18 || CommonCls.EventTypeId == 23 || CommonCls.EventTypeId == 24 || CommonCls.EventTypeId == 25)
            //    {
            //        //lbLineOutRaider.SelectionMode = SelectionMode.MultiSimple;
            //        //lbLineOutDefender.SelectionMode = SelectionMode.MultiSimple;
            //        pnlLineOut.Show(); pnlLineOut.BringToFront();
            //    }
            //    else if (CommonCls.EventTypeId == 1 || CommonCls.EventTypeId == 33 || CommonCls.EventTypeId == 34 || CommonCls.EventTypeId == 35 || CommonCls.EventTypeId == 2 || CommonCls.EventTypeId == 3 || CommonCls.EventTypeId == 4 || CommonCls.EventTypeId == 5 || CommonCls.EventTypeId == 6 || CommonCls.EventTypeId == 7 || CommonCls.EventTypeId == 8 || CommonCls.EventTypeId == 55 || CommonCls.EventTypeId == 56 || CommonCls.EventTypeId == 57 || CommonCls.EventTypeId == 58 || CommonCls.EventTypeId == 66 || CommonCls.EventTypeId == 67 || CommonCls.EventTypeId == 68 || CommonCls.EventTypeId == 69)
            //    {
            //        pnlDefender.Show(); pnlDefender.BringToFront();
            //    }
            //    else if (CommonCls.EventTypeId == 9 || CommonCls.EventTypeId == 10 || CommonCls.EventTypeId == 11 || CommonCls.EventTypeId == 26 || CommonCls.EventTypeId == 27 || CommonCls.EventTypeId == 28 || CommonCls.EventTypeId == 29 || CommonCls.EventTypeId == 59 || CommonCls.EventTypeId == 60 || CommonCls.EventTypeId == 61 || CommonCls.EventTypeId == 70 || CommonCls.EventTypeId == 71 || CommonCls.EventTypeId == 72 || CommonCls.EventTypeId == 73 || CommonCls.EventTypeId == 74 || CommonCls.EventTypeId == 75 || CommonCls.EventTypeId == 76 || CommonCls.EventTypeId == 79)
            //    {
            //        pnlKeyDefender.Show(); pnlKeyDefender.BringToFront();
            //    }
            //    if (CommonCls.EventTypeId == 12 || CommonCls.EventTypeId == 13 || CommonCls.EventTypeId == 14 || CommonCls.EventTypeId == 15 || CommonCls.EventTypeId == 16)
            //    {
            //        CommonCls.RaiderOutCome = CommonCls.EventTypeId;
            //        if (CommonCls.EventTypeId == 12 || CommonCls.EventTypeId == 13 || CommonCls.EventTypeId == 14)
            //        {
            //            CommonCls.RaiderEscape = CommonCls.EventTypeId;
            //        }
            //    }
            //    if (CommonCls.EventTypeId == 17 || CommonCls.EventTypeId == 18 || CommonCls.EventTypeId == 19 || CommonCls.EventTypeId == 20 || CommonCls.EventTypeId == 21 || CommonCls.EventTypeId == 22)
            //    {
            //        if (RaiderClick)
            //        {
            //            CommonCls.RaiderOutType = CommonCls.EventTypeId;
            //            #region Command
            //            //CommonCls.DTListEvents.Rows.Add(CommonCls.MatchId, CommonCls.HalfID, CommonCls.RaidNo, CommonCls.EventID, CommonCls.EventTypeId, CommonCls.PX, CommonCls.PY);
            //            //int PlayerIsExists = 0;
            //            //for (int j = 0; j < CommonCls.DTListOutPlayer.Rows.Count; j++)
            //            //{
            //            //    if (CommonCls.RaiderID.ToString() == CommonCls.DTListOutPlayer.Rows[j][4].ToString())
            //            //    {
            //            //        PlayerIsExists = 1;
            //            //    }
            //            //}
            //            //if (PlayerIsExists == 0)
            //            //    CommonCls.DTListOutPlayer.Rows.Add(CommonCls.MatchId, CommonCls.HalfID, CommonCls.RaidNo, CommonCls.EventID, CommonCls.RaiderID, "0", "0", "0", CommonCls.EventTypeId);

            //            #endregion
            //        }
            //        if (DefenderClick && CommonCls.EventTypeId != 18)
            //            pnlDefender.Show(); pnlDefender.BringToFront();
            //    }

            //    else if (CommonCls.EventTypeId == 37 || CommonCls.EventTypeId == 41 || CommonCls.EventTypeId == 42)
            //    {
            //        lbDefender.SelectionMode = SelectionMode.One; pnlDefender.Show(); pnlDefender.BringToFront();
            //    }
            //    else if (CommonCls.EventTypeId == 36 || CommonCls.EventTypeId == 38 || CommonCls.EventTypeId == 39 || CommonCls.EventTypeId == 40 || CommonCls.EventTypeId == 44 || CommonCls.EventTypeId == 43 || CommonCls.EventTypeId == 45 || CommonCls.EventTypeId == 46 || CommonCls.EventTypeId == 47 || CommonCls.EventTypeId == 48 || CommonCls.EventTypeId == 49 || CommonCls.EventTypeId == 50 || CommonCls.EventTypeId == 51 || CommonCls.EventTypeId == 52 || CommonCls.EventTypeId == 53 || CommonCls.EventTypeId == 54 || CommonCls.EventTypeId == 62 || CommonCls.EventTypeId == 63 || CommonCls.EventTypeId == 64 || CommonCls.EventTypeId == 65 || CommonCls.EventTypeId == 77 || CommonCls.EventTypeId == 78)
            //    {
            //        setEndtime = 0;
            //        int Subid = objDL.ExeQueryStrDL("Select MAX(ISNULL(SubId,0))+1 from RaidSubjects Where MatchID=" + CommonCls.MatchId + " And RaidNo=" + CommonCls.RaidNo + "", 1);
            //        objDL.ExeQueryRetBooDL("Insert Into RaidSubjects(Matchid,HalfID,RaidNo,SubId,EventtypeId,PlayerId,StanceTime,StartFrame,PX1,PY1) Values (" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + CommonCls.RaidNo + "," + Subid + "," + CommonCls.EventTypeId + "," + CommonCls.RaiderID + "," + 0 + "," + setEndtime + "," + CommonCls.PX + "," + CommonCls.PY + ")", 1);
            //    }
            //}
            //else
            //{
            //    return;
            //}
            #endregion
            if (dt.Rows.Count > 0)
            {
                CommonCls.EventTypeId = Convert.ToInt32(dt.Rows[0]["ID"]);
                if (CommonCls.EventTypeId != 31 && CommonCls.EventTypeId != 32 && CommonCls.EventTypeId != 37 && CommonCls.EventTypeId != 41 && CommonCls.EventTypeId != 44 && CommonCls.EventTypeId != 36 && CommonCls.EventTypeId != 38 && CommonCls.EventTypeId != 39 && CommonCls.EventTypeId != 40 && CommonCls.EventTypeId != 42 && CommonCls.EventTypeId != 43 && CommonCls.EventTypeId != 45)
                {
                    CommonCls.EventID = CommonCls.EventID + 1;
                    lblEventID.Text = CommonCls.EventID.ToString();
                }
                lbKeyDefender.SelectedIndex = -1;
                lbSupportedDefender.SelectedIndex = -1;
                if (CommonCls.EventTypeId == 18 || CommonCls.EventTypeId == 23 || CommonCls.EventTypeId == 24 || CommonCls.EventTypeId == 25)
                {
                    //lbLineOutRaider.SelectionMode = SelectionMode.MultiSimple;
                    //lbLineOutDefender.SelectionMode = SelectionMode.MultiSimple;
                    pnlLineOut.Show(); pnlLineOut.BringToFront();
                }
                else if (CommonCls.EventTypeId == 1 || CommonCls.EventTypeId == 33 || CommonCls.EventTypeId == 34 || CommonCls.EventTypeId == 35 || CommonCls.EventTypeId == 2 || CommonCls.EventTypeId == 3 || CommonCls.EventTypeId == 4 || CommonCls.EventTypeId == 5 || CommonCls.EventTypeId == 6 || CommonCls.EventTypeId == 7 || CommonCls.EventTypeId == 8 || CommonCls.EventTypeId == 55 || CommonCls.EventTypeId == 56 || CommonCls.EventTypeId == 57 || CommonCls.EventTypeId == 58 || CommonCls.EventTypeId == 66 || CommonCls.EventTypeId == 67 || CommonCls.EventTypeId == 68 || CommonCls.EventTypeId == 69)
                {
                    pnlDefender.Show(); pnlDefender.BringToFront();
                }
                else if (CommonCls.EventTypeId == 9 || CommonCls.EventTypeId == 10 || CommonCls.EventTypeId == 11 || CommonCls.EventTypeId == 26 || CommonCls.EventTypeId == 27 || CommonCls.EventTypeId == 28 || CommonCls.EventTypeId == 29 || CommonCls.EventTypeId == 59 || CommonCls.EventTypeId == 60 || CommonCls.EventTypeId == 61 || CommonCls.EventTypeId == 70 || CommonCls.EventTypeId == 71 || CommonCls.EventTypeId == 72 || CommonCls.EventTypeId == 73 || CommonCls.EventTypeId == 74 || CommonCls.EventTypeId == 75 || CommonCls.EventTypeId == 76 || CommonCls.EventTypeId == 79)
                {
                    pnlKeyDefender.Show(); pnlKeyDefender.BringToFront();
                }
                if (CommonCls.EventTypeId == 12 || CommonCls.EventTypeId == 13 || CommonCls.EventTypeId == 14 || CommonCls.EventTypeId == 15 || CommonCls.EventTypeId == 16)
                {
                    CommonCls.RaiderOutCome = CommonCls.EventTypeId;
                    if (CommonCls.EventTypeId == 12 || CommonCls.EventTypeId == 13 || CommonCls.EventTypeId == 14)
                    {
                        CommonCls.RaiderEscape = CommonCls.EventTypeId;
                    }
                }
                if (CommonCls.EventTypeId == 17 || CommonCls.EventTypeId == 18 || CommonCls.EventTypeId == 19 || CommonCls.EventTypeId == 20 || CommonCls.EventTypeId == 21 || CommonCls.EventTypeId == 22)
                {
                    if (RaiderClick)
                    {
                        CommonCls.RaiderOutType = CommonCls.EventTypeId;
                        #region Command
                        //CommonCls.DTListEvents.Rows.Add(CommonCls.MatchId, CommonCls.HalfID, CommonCls.RaidNo, CommonCls.EventID, CommonCls.EventTypeId, CommonCls.PX, CommonCls.PY);
                        //int PlayerIsExists = 0;
                        //for (int j = 0; j < CommonCls.DTListOutPlayer.Rows.Count; j++)
                        //{
                        //    if (CommonCls.RaiderID.ToString() == CommonCls.DTListOutPlayer.Rows[j][4].ToString())
                        //    {
                        //        PlayerIsExists = 1;
                        //    }
                        //}
                        //if (PlayerIsExists == 0)
                        //    CommonCls.DTListOutPlayer.Rows.Add(CommonCls.MatchId, CommonCls.HalfID, CommonCls.RaidNo, CommonCls.EventID, CommonCls.RaiderID, "0", "0", "0", CommonCls.EventTypeId);

                        #endregion
                    }
                    if (DefenderClick && CommonCls.EventTypeId != 18)
                        pnlDefender.Show(); pnlDefender.BringToFront();
                }

                else if (CommonCls.EventTypeId == 37 || CommonCls.EventTypeId == 41 || CommonCls.EventTypeId == 42)
                {
                    lbDefender.SelectionMode = SelectionMode.One; pnlDefender.Show(); pnlDefender.BringToFront();
                }
                else if (CommonCls.EventTypeId == 36 || CommonCls.EventTypeId == 38 || CommonCls.EventTypeId == 39 || CommonCls.EventTypeId == 40 || CommonCls.EventTypeId == 44 || CommonCls.EventTypeId == 43 || CommonCls.EventTypeId == 45 || CommonCls.EventTypeId == 46 || CommonCls.EventTypeId == 47 || CommonCls.EventTypeId == 48 || CommonCls.EventTypeId == 49 || CommonCls.EventTypeId == 50 || CommonCls.EventTypeId == 51 || CommonCls.EventTypeId == 52 || CommonCls.EventTypeId == 53 || CommonCls.EventTypeId == 54 || CommonCls.EventTypeId == 62 || CommonCls.EventTypeId == 63 || CommonCls.EventTypeId == 64 || CommonCls.EventTypeId == 65 || CommonCls.EventTypeId == 77 || CommonCls.EventTypeId == 78)
                {
                    setEndtime = 0;
                    int Subid = objDL.ExeQueryStrDL("Select MAX(ISNULL(SubId,0))+1 from RaidSubjects Where MatchID=" + CommonCls.MatchId + " And RaidNo=" + CommonCls.RaidNo + "", 1);
                    objDL.ExeQueryRetBooDL("Insert Into RaidSubjects(Matchid,HalfID,RaidNo,SubId,EventtypeId,PlayerId,StanceTime,StartFrame,PX1,PY1) Values (" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + CommonCls.RaidNo + "," + Subid + "," + CommonCls.EventTypeId + "," + CommonCls.RaiderID + "," + 0 + "," + setEndtime + "," + CommonCls.PX + "," + CommonCls.PY + ")", 1);
                }
            }
            else
            {
                return;
            }
        }

        private void llblChangeSubstitute_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
        decimal RaidStarttime = 0;
        int Sec = 0;
        void BindDIP()
        {
            if (CommonCls.ClubId1 == CommonCls.RaidClubId)
            {
                lblRaidTeam.Text = CommonCls.Club1Prefix;
                lblDefenderTeam.Text = CommonCls.Club2Prefix;
                lblRaidDIP.Text = (lbTeamAINList.Items.Count + objDL.ExeQueryStrDL("Select Count(DISTINCT PlayerID) from SuspendedPlayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.ClubId1 + " And Issuspend=1", 1)).ToString();
                lblDefDIP.Text = (lbTeamBINList.Items.Count + objDL.ExeQueryStrDL("Select Count(DISTINCT PlayerID) from SuspendedPlayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.ClubId2 + " And Issuspend=1", 1)).ToString();
                if (!chkManualDIP.Checked)
                {
                    lblManualRaidDIP.Text = lbTeamAINList.Items.Count.ToString();
                    lblManualDefDIP.Text = lbTeamBINList.Items.Count.ToString();
                }
                TeamADipXML = Convert.ToInt16(lblRaidDIP.Text); TeamBDipXML = Convert.ToInt16(lblDefDIP.Text);

                TeamAManualDipXML = Convert.ToInt16(lblManualRaidDIP.Text); TeamBManualDipXML = Convert.ToInt16(lblManualDefDIP.Text);
            }
            else if (CommonCls.ClubId2 == CommonCls.RaidClubId)
            {
                lblRaidTeam.Text = CommonCls.Club2Prefix;
                lblDefenderTeam.Text = CommonCls.Club1Prefix;
                lblRaidDIP.Text = (lbTeamBINList.Items.Count + objDL.ExeQueryStrDL("Select Count(DISTINCT PlayerID) from SuspendedPlayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.ClubId2 + " And Issuspend=1", 1)).ToString();
                lblDefDIP.Text = (lbTeamAINList.Items.Count + objDL.ExeQueryStrDL("Select Count(DISTINCT PlayerID) from SuspendedPlayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.ClubId1 + " And Issuspend=1", 1)).ToString();
                if (!chkManualDIP.Checked)
                {
                    lblManualRaidDIP.Text = lbTeamBINList.Items.Count.ToString();
                    lblManualDefDIP.Text = lbTeamAINList.Items.Count.ToString();
                }
                TeamADipXML = Convert.ToInt16(lblDefDIP.Text); TeamBDipXML = Convert.ToInt16(lblRaidDIP.Text);
                TeamAManualDipXML = Convert.ToInt16(lblManualDefDIP.Text); TeamBManualDipXML = Convert.ToInt16(lblManualRaidDIP.Text);
            }
        }
        DataTable DIPError = new DataTable();
        double CurTimeinSec = 0;
        private void BtnStartEnd_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    CurTimeinSec = TimeSpan.Parse("00:" + dtp_MatchClock.Value.Minute.ToString("D2") + ":" + dtp_MatchClock.Value.Second.ToString("D2")).TotalSeconds;
                }
                catch { }
                MasterDL obj = new MasterDL();
                if (BtnStartEnd.Text == "Raid Start")
                {
                    if (lbTeamAINList.Items.Count == 0) { MessageBox.Show(CommonCls.Club1Prefix + " Team Players Should Not be Blank", "Kabaddi Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                    if (lbTeamBINList.Items.Count == 0) { MessageBox.Show(CommonCls.Club2Prefix + " Team Players Should Not be Blank", "Kabaddi Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }


                    if (btnTimerOn.Enabled)
                    {
                        btnTimerOn_Click(sender, e);
                        try
                        {
                            ObjFndCtrl.sendScorecardTimer("CONT");
                        }
                        catch { }
                    }
                    WriteToLog("Raid Start Starting");
                    Reset();
                    #region Start
                    CommonCls.StartTime = DateTime.Now;
                    CommonCls.StartTimer = "00:" + dtp_MatchClock.Value.Minute.ToString("D2") + ":" + dtp_MatchClock.Value.Second.ToString("D2");
                    chkSwap.Enabled = false;
                    chkAllplayer.Enabled = false;
                    chkRemove.Enabled = false;
                    try
                    {

                        if (!_timerRunning)
                        {
                            mySW.Start();
                            Timer_MatchClock.Start();
                            _timerRunning = true;

                            Starttime = DateTime.Now;

                            btn_MatchClock_Start.Text = "Timer Pause";
                        }
                    }
                    catch { }
                    WriteToLog("SP_GetDIPError Starting");
                    try
                    {
                        DIPError = new DataTable();
                        DIPError = objDL.ExeQueryStrRetDTDL("SP_GetDIPError " + CommonCls.MatchId + "," + CommonCls.RaidNo + "", 1);
                        if (DIPError.Rows[0]["ERROR"].ToString() == "1" && CommonCls.RaidNo != 0)
                        {
                            if (MessageBox.Show("last raid Inplayer not given for Team : " + (Convert.ToInt32(DIPError.Rows[0]["ERRORTEam"].ToString()) == CommonCls.ClubId1 ? CommonCls.Club1Prefix : CommonCls.Club2Prefix) + " Do you Continue to code", "Hockey Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                objDL.ExeQueryRetBooDL("Insert into InplayerFlag(Matchid,Raidno) Values(" + CommonCls.MatchId + ",RaidNo=" + (CommonCls.RaidNo + 1) + ")", 1);
                            }
                            else
                                return;
                            //MessageBox.Show("Inplayer not given last raid", "Kabaddi Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //return;
                        }
                    }
                    catch { }
                    WriteToLog("SP_GetDIPError Ending");

                    try
                    {
                        if (obj.ExeQueryStrRetStrDL("select COUNT(RaidNo) from Raid where Matchid=" + CommonCls.MatchId + "", 1) == "0")
                        {
                            CommonCls.RaidClubId = obj.ExeQueryStrDL("Select Case When Description='Ride' And LeftClubID=TossWin Then LeftClubID When Description='Ride' And RightClubID=TossWin Then RightClubID When Description='Defence' And LeftClubID=TossWin Then RightClubID When Description='Defence' And RightClubID=TossWin Then LeftClubID End from MatchHalf Where Matchid=" + CommonCls.MatchId + " And HalfID=1", 1);
                            CommonCls.DefenceClubId = obj.ExeQueryStrDL("Select LeftClubID from MatchHalf Where Matchid=" + CommonCls.MatchId + " And LeftClubID Not in(" + CommonCls.RaidClubId + ")", 1);
                        }
                        else if (CommonCls.HalfID == 2 && obj.ExeQueryStrRetStrDL("select COUNT(RaidNo) from Raid where Matchid=" + CommonCls.MatchId + " And HalfID=" + CommonCls.HalfID + "", 1) == "0")
                        {
                            CommonCls.DefenceClubId = Convert.ToInt32(obj.ExeQueryStrRetStrDL("select ClubID from Raid R Join LineUps L On R.Matchid=L.Matchid And R.RaiderID=L.PlayerID where R.Matchid=" + CommonCls.MatchId + " And RaidNo=1", 1));
                            CommonCls.RaidClubId = obj.ExeQueryStrDL("Select LeftClubID from MatchHalf Where Matchid=" + CommonCls.MatchId + " And LeftClubID Not in(" + CommonCls.DefenceClubId + ")", 1);
                        }
                        else
                        {
                            CommonCls.RaidNo = Convert.ToInt32(obj.ExeQueryStrRetStrDL("select ISNULL(MAX(RaidNo),0) from Raid where Matchid=" + CommonCls.MatchId + "", 1));
                            int PreviousRaiderID = obj.ExeQueryStrDL("Select RaiderID from Raid Where MatchID=" + CommonCls.MatchId + " And RaidNo=" + CommonCls.RaidNo + "", 1);
                            CommonCls.RaidClubId = obj.ExeQueryStrDL("Select L.ClubID from Raid R Join Lineups L ON R.MatchID=L.MatchID And R.RaiderID=L.PlayerID Where R.MatchID=" + CommonCls.MatchId + " And R.RaiderID=" + PreviousRaiderID + "", 1); // Previous Raid TeamID
                            CommonCls.DefenceClubId = obj.ExeQueryStrDL("Select LeftClubID from MatchHalf Where Matchid=" + CommonCls.MatchId + " And LeftClubID Not in(" + CommonCls.RaidClubId + ")", 1); // Previous Defender TeamID
                            int SwapTeam = 0;
                            SwapTeam = CommonCls.RaidClubId;
                            CommonCls.RaidClubId = CommonCls.DefenceClubId;
                            CommonCls.DefenceClubId = SwapTeam;
                        }
                        cbTeam.SelectedValue = CommonCls.RaidClubId;

                        WriteToLog("BindDIP Starting");
                        BindDIP();

                        WriteToLog("BindDIP Ending");

                        WriteToLog("LoadRaider_Defender Starting");
                        LoadRaider_Defender();

                        WriteToLog("LoadRaider_Defender Starting");
                        lbDefender.SelectedIndex = -1;
                        if (CommonCls.RaidNo != 0 && System.IO.File.Exists(CommonCls.Videopath))
                        {
                            if (objDL.ExeQueryStrDL("SELECT CASE when StartFrame ='0' Then 0 ELSE ISNULL(CAST(CAST(" + setStarttime + " as NUMERIC(8,1))as int)-CAST(CAST(Endframe as NUMERIC(8,1))as int),0) END From Raid Where MatchID=" + CommonCls.MatchId + " And Raidno=" + CommonCls.RaidNo + "", 1) > 10)
                            {
                                DialogResult Result = MessageBox.Show("Last raid time diff More than 10 seconds do u want to open stoppage form", "Kabaddi Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                if (Result == DialogResult.Yes)
                                {
                                    objDL.ExeQueryRetBooDL("Update Raid Set StoppageFlag=1 where Matchid=" + CommonCls.MatchId + "," + CommonCls.HalfID + ",RaidNo=" + CommonCls.RaidNo + "", 1);
                                    //frmBreakTime frm = new frmBreakTime(CommonCls.MatchId, CommonCls.HalfID);
                                    //frm.Show();
                                }
                            }
                        }
                        CommonCls.RaidNo = CommonCls.RaidNo + 1;
                        lblRaidNo.Text = CommonCls.RaidNo.ToString();
                    }
                    catch { }
                    try
                    {
                        if (ConfigurationSettings.AppSettings["DoOrDie"].ToString() == "1")
                            if (obj.ExeQueryStrRetDTDL("Select * from Raid Where MatchID=" + CommonCls.MatchId + " and HalfID=" + CommonCls.HalfID + " And RaidNo IN(Select top 2 RaidNo from Raid Where MatchID=" + CommonCls.MatchId + " and HalfID=" + CommonCls.HalfID + " and RaiderID IN(Select PlayerID from Lineups Where MatchID=" + CommonCls.MatchId + " and ClubID=" + CommonCls.RaidClubId + ") Order by RaidNo Desc) And Outcome=16 And BonusLine=0 And DoorDie=0", 1).Rows.Count == 2)
                            {
                                chkDoorDie.Checked = true;
                                MessageBox.Show("This Raider consider as Do or Die Raid", "Kabaddi Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                    }
                    catch { }

                    if (Convert.ToInt32(lblDefDIP.Text) <= 3)
                    { pnlSuperTackle.BackColor = Color.Red; CommonCls.DefSpecialCase = "SUPER TACKLE ON"; }
                    if (Convert.ToInt32(lblDefDIP.Text) >= 5)
                    { pnlBonus.BackColor = Color.Red; CommonCls.SpecialCase = ""; }
                    if (Convert.ToInt32(lblDefDIP.Text) == 1 || Convert.ToInt32(lblRaidDIP.Text) == 1)
                    {
                        pnlAllout.BackColor = Color.Red;// CommonCls.SpecialCase = "ALL OUT"; 
                    }
                    if (Convert.ToInt32(lblDefDIP.Text) >= 6)
                        CommonCls.RaidSpecialCase = "BONUS ON";
                    if (chkDoorDie.Checked)
                    {
                        CommonCls.RaidSpecialCase = "DO-OR-DIE RAID";
                    }


                    pnlRaider.Show();
                    pnlRaider.BringToFront();
                    BtnStartEnd.Text = "Raid End";
                    BtnStartEnd.BackColor = Color.Red;
                    #endregion
                    WriteToLog("Raid Start Ending");
                }
                else if (BtnStartEnd.Text == "Raid End")
                {
                    WriteToLog("Raid End Starting");
                    setEndtime = 0;
                    setEndtimevideo = label3.Text.Trim();
                    //if (CommonCls.RaidNo != 1 || System.IO.File.Exists(CommonCls.Videopath))
                    //{
                    //    Sec = objDL.ExeQueryStrDL(" SELECT CASE when " + RaidStarttime + " ='0' Then 0 ELSE ISNULL(CAST(CAST(" + setEndtime + " as NUMERIC(8,1))as int)-CAST(CAST(" + RaidStarttime + " as NUMERIC(8,1))as int),0) END ", 1);
                    //    if (Sec < 5)
                    //    {
                    //        DialogResult Result = MessageBox.Show("Current raid Total Seconds < 5 do u want condinue to code", "Kabaddi Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    //        if (Result == DialogResult.No)
                    //            return;
                    //    }
                    //    if (Sec > 30)
                    //    {
                    //        MessageBox.Show("Current raid Total Seconds > 30 please check it", "Kabaddi Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //        return;
                    //    }
                    //}


                    if ((CommonCls.DTListEvents.Rows.Count > 0 && CommonCls.RaiderOutCome == 0) || (CommonCls.RaiderOutType != 0 && CommonCls.RaiderOutCome == 0))
                    {
                        MessageBox.Show("Select Raider OutCome", "Kabaddi Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
                    }
                    else
                    {
                        if (CommonCls.RaiderOutCome == 0) CommonCls.RaiderOutCome = 16;
                    }
                    //if (CommonCls.RaiderOutCome == 0 && CommonCls.RaiderOutType == 0) { MessageBox.Show("Select Raider OutCome", "Kabaddi Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                    // if (CommonCls.RaiderOutCome == 15 || CommonCls.RaiderOutType == 0) { MessageBox.Show("Select Raider OutType", "Kabaddi Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                    if (CommonCls.RaiderID == 0) { MessageBox.Show("Raider Should Not be Blank", "Kabaddi Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

                    //foreach (DataRow dr in CommonCls.DTListOutPlayer.Rows)
                    //{
                    //    dr
                    //}
                    if (CommonCls.DTListOutPlayer.Rows.Count >= 3 && (CommonCls.RaiderOutCome == 12 || CommonCls.RaiderOutCome == 13 || CommonCls.RaiderOutCome == 14) && !chkSuperRaid.Checked)
                    {
                        DialogResult Result = MessageBox.Show("Do u continue to save with-out Check Super Raid ", "Kabaddi Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (Result == DialogResult.No) return;
                    }
                    if (CommonCls.RaiderOutCome == 15 && Convert.ToInt32(lblDefDIP.Text) <= 3 && !chkSuperTackle.Checked)
                    {
                        DialogResult Result = MessageBox.Show("Do u continue to save with-out Check Super Tackle ", "Kabaddi Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (Result == DialogResult.No) return;
                    }
                    #region End
                    CommonCls.EndTime = DateTime.Now;
                    string videopath = obj.ExeQueryStrRetStrDL("select videopath from videos where matchid=" + lblmatchid.Text + "", 1);


                    try
                    {
                        #region Check Special Case

                        int DoorDie = 0, BonusPoint = 0, SuperRaid = 0, SuperTackle = 0, Allout = 0, BonusType = 0;
                        if (chkDoorDie.Checked == true) DoorDie = 1;
                        if (chkBonusPoint.Checked == true) BonusPoint = 1;
                        if (chkSuperRaid.Checked == true) SuperRaid = 1;
                        if (chkSuperTackle.Checked == true) SuperTackle = 1;
                        if (chkAllOut.Checked == true) Allout = 1;

                        #endregion

                        CommonCls.EndTimer = "00:" + dtp_MatchClock.Value.Minute.ToString("D2") + ":" + dtp_MatchClock.Value.Second.ToString("D2");
                        //try
                        //{
                        //    obj.ExeQueryRetBooDL("Insert Into Raid(MatchID,HalfID,RaidNo,RaiderId,BonusLine,BLPX,BLPY,OutCome,SuperRaid,SuperTackle,DoorDie,RaiderOutType,[Escape],Allout,StartTime,EndTime,StartFrame,EndFrame,TimerStart,TimerEnd,RaiderCard,RaidDIP,DefDIP,BonusFrame,BonusType) Values (" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + CommonCls.RaidNo + "," + CommonCls.RaiderID + "," + BonusPoint + "," + CommonCls.BLPX + "," + CommonCls.BLPY + "," + CommonCls.RaiderOutCome + "," + SuperRaid + "," + SuperTackle + "," + DoorDie + "," + CommonCls.RaiderOutType + "," + CommonCls.RaiderEscape + "," + Allout + ",'" + CommonCls.StartTime + "','" + CommonCls.EndTime + "','" + RaidStarttime + "','" + setEndtime + "','" + CommonCls.StartTimer + "','" + CommonCls.EndTimer + "'," + CommonCls.RaiderCard + "," + lblRaidDIP.Text + "," + lblDefDIP.Text + ",'" + BonusFrame + "'," + BonusType +")", 1);
                        //}
                        //catch { }
                        try
                        {
                            obj.ExeQueryRetBooDL("Update Raid Set RaiderId=" + CommonCls.RaiderID + ",BonusLine=" + BonusPoint + ",BLPX=" + CommonCls.BLPX + ",BLPY=" + CommonCls.BLPY
                                + ",OutCome=" + CommonCls.RaiderOutCome + ",SuperRaid=" + SuperRaid + ",SuperTackle=" + SuperTackle + ",DoorDie=" + DoorDie
                                + ",RaiderOutType=" + CommonCls.RaiderOutType + ",[Escape]=" + CommonCls.RaiderEscape + ",Allout=" + Allout + ",StartTime='" + CommonCls.StartTime
                                + "',EndTime='" + CommonCls.EndTime + "',StartFrame='" + RaidStarttime + "',EndFrame='" + setEndtime + "',TimerStart='" + CommonCls.StartTimer
                                + "',TimerEnd='" + CommonCls.EndTimer + "',RaiderCard=" + CommonCls.RaiderCard + ",RaidDIP=" + lblRaidDIP.Text + ",DefDIP=" + lblDefDIP.Text
                                + ",BonusFrame='" + BonusFrame + "',BonusType=" + BonusType + " WHERE MatchID=" + CommonCls.MatchId + " AND HalfID=" + CommonCls.HalfID + " AND RaidNo=" + CommonCls.RaidNo + "", 1);
                        }
                        catch { }
                        try
                        {
                            foreach (DataRow dr in CommonCls.DTListEvents.Rows)
                            {
                                obj.ExeQueryRetBooDL("Insert Into Events(MatchID,HalfID,RaidNo,EventId,EventType,PX,PY,StartFrame,Initiator,Time) Values (" + dr["MatchID"] + "," + dr["HalfID"] + "," + dr["RaidNo"] + "," + dr["EventId"] + "," + dr["EventType"] + "," + dr["PX"] + "," + dr["PY"] + ",'" + dr["setEndtime"] + "'," + (dr["Initiator"].ToString() == "" ? "null" : dr["Initiator"]) + "," + dr["Time"] + ")", 1);
                            }
                        }
                        catch { }

                        try
                        {
                            int Isout = 0, Israiderout = 0;
                            int orderNo = 0;
                            dt = new DataTable();

                            if (obj.ExeQueryStrDL("SELECT COUNT(*) from MatchHalf where MatchID=" + CommonCls.MatchId + " and ((HalfID=3 AND HalfStart=1 and HalfEnd=0))", 1) == 0 && obj.ExeQueryStrDL("SELECT COUNT(*) from Raid where MatchID=" + CommonCls.MatchId + " And HalfID=" + CommonCls.HalfID + "", 1) == 0)
                            {

                            }
                            else
                            {
                                dt = obj.ExeQueryStrRetDTDL("Select *,ROW_NUMBER() OVER(ORDER BY raidno,orderno) Rank from OutPlayerRef Where Matchid=" + CommonCls.MatchId + " And RaidNo=" + (CommonCls.RaidNo - 1) + " And PlayerID Not IN(Select PlayerID from Innerplayer Where Matchid=" + CommonCls.MatchId + " AND RaidNo=" + (CommonCls.RaidNo - 1) + ")", 1);
                            }
                            foreach (DataRow dr in dt.Rows)
                            {
                                int Clubid = obj.ExeQueryStrDL("Select ClubID from Lineups Where MatchID=" + CommonCls.MatchId + " And PlayerID=" + dr["PlayerId"] + "", 1); // TeamID
                                obj.ExeQueryRetBooDL("Insert Into OutPlayerRef(MatchID,HalfID,RaidNo,PlayerId,Clubid,OrderNo) Values (" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + CommonCls.RaidNo + "," + dr["PlayerId"] + "," + dr["Clubid"] + "," + dr["Rank"] + ")", 1);
                            }
                            orderNo = dt.Rows.Count;

                            CommonCls.DTListOutPlayer.DefaultView.Sort = "EventID asc";
                            CommonCls.DTListOutPlayer = CommonCls.DTListOutPlayer.DefaultView.ToTable(true);

                            #region OutPlayer
                            foreach (DataRow dr in CommonCls.DTListOutPlayer.Rows)
                            {
                                orderNo = orderNo + 1;
                                Isout = 0;
                                if (Convert.ToInt32(CommonCls.RaiderID) == Convert.ToInt32(dr["PlayerId"]) && CommonCls.RaiderOutCome == 15)
                                {
                                    Isout = 1;
                                    Israiderout = 0;
                                }
                                else if (Convert.ToInt32(CommonCls.RaiderID) == Convert.ToInt32(dr["PlayerId"]) && CommonCls.RaiderOutCome != 15)
                                {
                                    Isout = 0;
                                    Israiderout = 0;
                                }
                                else if (RaiderClick && (CommonCls.RaiderOutType == 17 || CommonCls.RaiderOutType == 18) && (Convert.ToInt32(dr["OutType"]) == 17 || Convert.ToInt32(dr["OutType"]) == 18))
                                {
                                    Isout = 1;
                                    Israiderout = 1;
                                }
                                else if (RaiderClick && (CommonCls.RaiderOutType == 17 || CommonCls.RaiderOutType == 18 || CommonCls.RaiderOutType == 19 || CommonCls.RaiderOutType == 20 || CommonCls.RaiderOutType == 21 || CommonCls.RaiderOutType == 22))
                                {
                                    Isout = 0;
                                    Israiderout = 1;
                                }
                                else if (Convert.ToInt32(CommonCls.RaiderID) != Convert.ToInt32(dr["PlayerId"]) && (Convert.ToInt32(dr["OutType"]) == 17 || Convert.ToInt32(dr["OutType"]) == 18))
                                {
                                    Isout = 1;
                                    Israiderout = 0;
                                }
                                else if (Convert.ToInt32(CommonCls.RaiderID) != Convert.ToInt32(dr["PlayerId"]) && (Convert.ToInt32(dr["OutType"]) == 17 || Convert.ToInt32(dr["OutType"]) == 18))
                                {
                                    Isout = 1;
                                    Israiderout = 0;
                                }
                                else if (Convert.ToInt32(dr["OutType"]) == 23 || Convert.ToInt32(dr["OutType"]) == 24 || Convert.ToInt32(dr["OutType"]) == 24)
                                {
                                    Isout = 0;
                                }
                                //else if (CommonCls.RaiderOutCome != 15 &&(Convert.ToInt32(dr["OutType"]) == 19 || Convert.ToInt32(dr["OutType"]) == 20 || Convert.ToInt32(dr["OutType"]) == 21 || Convert.ToInt32(dr["OutType"]) == 22)
                                //{
                                //    Isout = 1;
                                //    Israiderout = 0;
                                //}
                                else if (Convert.ToInt32(CommonCls.RaiderID) != Convert.ToInt32(dr["PlayerId"]) && CommonCls.RaiderOutCome == 15)
                                    Isout = 0;
                                else if (Convert.ToInt32(CommonCls.RaiderID) != Convert.ToInt32(dr["PlayerId"]) && (CommonCls.RaiderOutCome == 12 || CommonCls.RaiderOutCome == 13 || CommonCls.RaiderOutCome == 14 || CommonCls.RaiderOutCome == 17 || CommonCls.RaiderOutCome == 18))
                                    Isout = 1;
                                obj.ExeQueryRetBooDL("Insert Into OutPlayer(MatchID,HalfID,RaidNo,EventId,PlayerId,KeyDefender,SupportedKeyDefender,IsOut,OutType) Values (" + dr["MatchID"] + "," + dr["HalfID"] + "," + dr["RaidNo"] + "," + dr["EventId"] + "," + dr["PlayerId"] + "," + dr["KeyDefender"] + "," + dr["SupportedKeyDefender"] + "," + Isout + "," + dr["OutType"] + ")", 1);
                                if (Isout == 1 && CommonCls.RaiderOutType != 24 && CommonCls.RaiderOutType != 25)
                                {
                                    int Clubid = obj.ExeQueryStrDL("Select ClubID from Lineups Where MatchID=" + CommonCls.MatchId + " And PlayerID=" + dr["PlayerId"] + "", 1); // TeamID
                                    obj.ExeQueryRetBooDL("Insert Into OutPlayerRef(MatchID,HalfID,RaidNo,PlayerId,Clubid,orderNo) Values (" + dr["MatchID"] + "," + dr["HalfID"] + "," + dr["RaidNo"] + "," + dr["PlayerId"] + "," + Clubid + "," + orderNo + ")", 1);
                                }
                                if (CommonCls.RaiderOutType == 24 || CommonCls.RaiderOutType == 25)
                                {
                                    int iskill = 0;
                                    if (CommonCls.RaiderOutType == 25)
                                        iskill = 1;
                                    int Clubid = obj.ExeQueryStrDL("Select ClubID from Lineups Where MatchID=" + CommonCls.MatchId + " And PlayerID=" + dr["PlayerId"] + "", 1); // TeamID
                                    obj.ExeQueryRetBooDL("Insert Into SuspendedPlayer(MatchID,HalfID,RaidNo,PlayerId,Clubid,Issuspend,iskill) Values (" + dr["MatchID"] + "," + dr["HalfID"] + "," + dr["RaidNo"] + "," + dr["PlayerId"] + "," + Clubid + ",1," + iskill + ")", 1);
                                }
                            }
                            //   if ((Israiderout == 0 && CommonCls.RaiderOutCome == 15) || (Israiderout == 1 && (CommonCls.RaiderOutCome == 17 || CommonCls.RaiderOutCome == 18)))

                            //   if (Israiderout == 0 && CommonCls.RaiderOutCome == 15)
                            if (CommonCls.RaiderOutCome == 15)
                                obj.ExeQueryRetBooDL("Insert Into OutPlayerRef(MatchID,HalfID,RaidNo,PlayerId,Clubid,orderNo) Values (" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + CommonCls.RaidNo + "," + CommonCls.RaiderID + "," + CommonCls.RaidClubId + "," + orderNo + ")", 1);
                            //if ( RaiderClick && (CommonCls.RaiderOutType ==17 || CommonCls.RaiderOutType == 18 || CommonCls.RaiderOutType == 19 || CommonCls.RaiderOutType == 20 || CommonCls.RaiderOutType == 21 || CommonCls.RaiderOutType == 22))
                            //    obj.ExeQueryRetBooDL("Insert Into OutPlayerRef(MatchID,HalfID,RaidNo,PlayerId,Clubid,orderNo) Values (" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + CommonCls.RaidNo + "," + CommonCls.RaiderID + "," + CommonCls.RaidClubId + "," + orderNo + ")", 1);

                            if (CommonCls.RaiderCard == 24 || CommonCls.RaiderCard == 25)
                            {
                                int iskill = 0;
                                if (CommonCls.RaiderOutType == 25)
                                    iskill = 1;
                                obj.ExeQueryRetBooDL("Insert Into SuspendedPlayer(MatchID,HalfID,RaidNo,PlayerId,Clubid,Issuspend,iskill) Values (" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + CommonCls.RaidNo + "," + CommonCls.RaiderID + "," + CommonCls.RaidClubId + ",1," + iskill + ")", 1);
                            }
                            #endregion

                        }
                        catch { }
                        try
                        {
                            int cnt = obj.ExeQueryStrDL("Select ISNULL(Count(Raidno),0)+1 From tblCorrectedRaid where Matchid=" + CommonCls.MatchId + " And HalfID=" + CommonCls.HalfID + " AND RaidNo=" + CommonCls.RaidNo + "", 1);
                            obj.ExeQueryRetBooDL("Insert into tblCorrectedRaid (Matchid,HalfID,Raidno,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + CommonCls.RaidNo + "," + cnt + ",'Raid','" + System.DateTime.Now + "',1,0,0)", 1);
                        }
                        catch { }
                        obj.ExeQueryRetBooDL("Insert into UserTracker (Matchid,HalfID,RaidNo,InsertTime,UserId)values(" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + CommonCls.RaidNo + ",'" + System.DateTime.Now + "'," + CommonCls.UserLoginID + ")", 1);
                    }
                    catch { }
                    InsertINOutPlayer(0);
                    try
                    {
                        string CurrentScore = obj.ExeQueryStrRetStrDL("Select dbo.fn_GetCurrentRaidScore(" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + CommonCls.RaidNo + ")", 1);
                        objDL.ExeQueryRetBooDL("Update Raid set raidpoint=" + CurrentScore.Split('-')[0] + ",defencepoint=" + CurrentScore.Split('-')[1] + "  Where Matchid=" + CommonCls.MatchId + " And HalfID=" + CommonCls.HalfID + " And RaidNo=" + CommonCls.RaidNo + "", 1);
                    }
                    catch { }
                    BtnStartEnd.Text = "Raid Start";
                    BtnStartEnd.BackColor = Color.OliveDrab;

                    pnlOutplayerlist.Hide();
                    Reset();





                    XMLPush(1, "END");
                    try
                    {
                        CurTimeinSec = TimeSpan.Parse("00:" + dtp_MatchClock.Value.Minute.ToString("D2") + ":" + dtp_MatchClock.Value.Second.ToString("D2")).TotalSeconds;
                    }
                    catch { CurTimeinSec = 0; }

                    try
                    {
                        if (chkMatchClock.Checked)
                        {
                            if (CurTimeinSec == 0 || CurTimeinSec == 1200)
                                MessageBox.Show("Match colck is zero" + dtp_MatchClock.Value.ToString());
                            objDL.ExeQueryRetBooDL("Update KB_Matches set MatchClock=" + CurTimeinSec + " Where MatchID=" + CommonCls.MatchId + "", 1);
                            //  dtpXML_MatchClock.Value = dtp_MatchClock.Value;
                        }
                    }
                    catch
                    {

                    }
                    #endregion

                    retriveVizSend();
                    WriteToLog("Raid End Ending");
                }
            }
            catch { }
        }

        void InsertINOutPlayer(int RaidPlus)
        {
            try
            {
                if (objDL.ExeQueryStrDL("select count(*) From INPlayerList where Matchid=" + CommonCls.MatchId + " AND RaidNo=" + (CommonCls.RaidNo + RaidPlus) + "", 1) > 0)
                    objDL.ExeQueryStrDL("Delete From INPlayerList where Matchid=" + CommonCls.MatchId + " AND RaidNo=" + (CommonCls.RaidNo + RaidPlus) + "", 1);

                if (objDL.ExeQueryStrDL("select count(*) From OutPlayerList where Matchid=" + CommonCls.MatchId + " AND RaidNo=" + CommonCls.RaidNo + "", 1) > 0)
                    objDL.ExeQueryStrDL("Delete From OutPlayerList where Matchid=" + CommonCls.MatchId + " AND RaidNo=" + CommonCls.RaidNo + "", 1);
                #region Inplayer
                lbTeamAINList.SelectionMode = SelectionMode.One;
                for (int i = 0; i < lbTeamAINList.Items.Count; i++)
                {
                    lbTeamAINList.SelectedIndex = i;
                    objDL.ExeQueryRetBooDL("Insert into INPlayerList(Matchid,RaidNo,PlayerID,ClubID) Values(" + CommonCls.MatchId + "," + (CommonCls.RaidNo + RaidPlus) + "," + lbTeamAINList.SelectedValue.ToString() + "," + CommonCls.ClubId1 + ")", 1);
                }
                lbTeamAINList.SelectionMode = SelectionMode.None;

                lbTeamBINList.SelectionMode = SelectionMode.One;
                for (int i = 0; i < lbTeamBINList.Items.Count; i++)
                {
                    lbTeamBINList.SelectedIndex = i;
                    objDL.ExeQueryRetBooDL("Insert into INPlayerList(Matchid,RaidNo,PlayerID,ClubID) Values(" + CommonCls.MatchId + "," + (CommonCls.RaidNo + RaidPlus) + "," + lbTeamBINList.SelectedValue.ToString() + "," + CommonCls.ClubId2 + ")", 1);
                }
                lbTeamBINList.SelectionMode = SelectionMode.None;
                #endregion

                #region Otplayer
                lbTeamAOutList.SelectionMode = SelectionMode.One;
                for (int i = 0; i < lbTeamAOutList.Items.Count; i++)
                {
                    lbTeamAOutList.SelectedIndex = i;
                    objDL.ExeQueryRetBooDL("Insert into OutPlayerList(Matchid,RaidNo,PlayerID,ClubID) Values(" + CommonCls.MatchId + "," + CommonCls.RaidNo + "," + lbTeamAOutList.SelectedValue.ToString() + "," + CommonCls.ClubId1 + ")", 1);
                }
                // lbTeamAOutList.SelectedIndex = 0;
                // lbTeamAOutList.SelectionMode = SelectionMode.None;

                lbTeamBOutList.SelectionMode = SelectionMode.One;
                for (int i = 0; i < lbTeamBOutList.Items.Count; i++)
                {
                    lbTeamBOutList.SelectedIndex = i;
                    objDL.ExeQueryRetBooDL("Insert into OutPlayerList(Matchid,RaidNo,PlayerID,ClubID) Values(" + CommonCls.MatchId + "," + CommonCls.RaidNo + "," + lbTeamBOutList.SelectedValue.ToString() + "," + CommonCls.ClubId2 + ")", 1);
                }
                // lbTeamBOutList.SelectedIndex = 0;
                //lbTeamBOutList.SelectionMode = SelectionMode.None;
                #endregion
            }
            catch { }
        }

        void PointCalculate()
        {
            try
            {
                dt = new DataTable();
                dt = objDL.ExeQueryStrRetDTDL("SP_GetTeamScore " + CommonCls.MatchId + "," + CommonCls.ClubId1 + "," + CommonCls.ClubId2 + "", 1);
                if (dt.Rows.Count > 0)
                {
                    lblTeamAScore.Text = dt.Rows[0][0].ToString();
                    lblTeamBScore.Text = dt.Rows[0][1].ToString();
                }
                lblResult.Text = objDL.ExeQueryStrRetStrDL("Select dbo.fn_MatchResult(" + Temp_matchid + ")", 1);
            }
            catch { }
        }

        void Reset()
        {
            try
            {
                PageLoad = false;
                chkSwap.Enabled = true;
                chkRemove.Enabled = true;
                chkSwap.Checked = false;
                chkRemove.Checked = false;

                chkAllplayer.Enabled = true;
                chkAllplayer.Checked = false;

                lbTeamAINList.SelectionMode = SelectionMode.None;
                // lbTeamAINList.SelectedIndex = -1;

                lbTeamBINList.SelectionMode = SelectionMode.None;
                // lbTeamBINList.SelectedIndex = -1;

                MasterDL obj = new MasterDL();
                CommonCls.RaidNo = Convert.ToInt32(obj.ExeQueryStrRetStrDL("select ISNULL(MAX(RaidNo),0) from Raid where Matchid=" + CommonCls.MatchId + "", 1));
                lblRaidNo.Text = CommonCls.RaidNo.ToString();
                CommonCls.EventID = 0;
                CommonCls.EventTypeId = 0;
                CommonCls.PX = 0;
                CommonCls.PY = 0;
                CommonCls.BLPX = 0;
                CommonCls.BLPY = 0;
                lbRaider.SelectedIndex = -1;
                lbKeyDefender.SelectedIndex = -1;
                lbSupportedDefender.SelectedIndex = -1;
                lbLineOutRaider.SelectedIndex = -1;
                lbLineOutDefender.SelectedIndex = -1;
                lbDefender.SelectedIndex = -1;
                lbInitiator.SelectedIndex = -1;
                chkBonusPoint.Checked = false;
                chkDoorDie.Checked = false;
                chkSuperRaid.Checked = false;
                chkSuperTackle.Checked = false;
                chkAllOut.Checked = false;
                CommonCls.RaiderOutType = 0;
                CommonCls.RaiderOutCome = 0;
                CommonCls.RaiderEscape = 0;
                CommonCls.RaiderCard = 0;
                CommonCls.StartTimer = "";
                CommonCls.EndTimer = "";
                BtnStartEnd.Text = "Raid Start";
                BtnStartEnd.BackColor = Color.OliveDrab;
                lblEventID.Text = CommonCls.EventTypeId.ToString();
                RaiderClick = false;
                DefenderClick = false;
                TouchClick = false;
                TackleClick = false;
                LoadPlayer();
                PointCalculate();
                pnlEvents.Enabled = false;
                pnlSpecialCase.Enabled = false;
                cbRaider.SelectedIndex = -1;
                pnlDefender.Hide();
                pnlLineOut.Hide();
                pnlRaider.Hide();
                pnlRaidPoint.Hide();
                pnlSubtitute.Hide();
                pnlSuspend.Hide();
                raiderchose = false;
                techPoint = false;
                isDeclare = false;
                pnlSuperTackle.BackColor = Color.White;
                pnlBonus.BackColor = Color.White;
                pnlAllout.BackColor = Color.White;
                lblRaidTime.Text = "0";
                chkBonusline.Checked = false;
                CommonCls.SpecialCase = "";
                CommonCls.RaidSpecialCase = "";
                CommonCls.DefSpecialCase = "";
                try
                {


                    CommonCls.DTListEvents = new DataTable();
                    CommonCls.DTListEvents.Columns.Add("MatchID", typeof(int));
                    CommonCls.DTListEvents.Columns.Add("HalfID", typeof(int));
                    CommonCls.DTListEvents.Columns.Add("RaidNo", typeof(int));
                    CommonCls.DTListEvents.Columns.Add("EventId", typeof(int));
                    CommonCls.DTListEvents.Columns.Add("EventType", typeof(int));
                    CommonCls.DTListEvents.Columns.Add("PX", typeof(int));
                    CommonCls.DTListEvents.Columns.Add("PY", typeof(int));
                    CommonCls.DTListEvents.Columns.Add("setEndtime", typeof(string));
                    CommonCls.DTListEvents.Columns.Add("Initiator", typeof(string));
                    CommonCls.DTListEvents.Columns.Add("Time", typeof(string));
                    CommonCls.DTListOutPlayer.Rows.Clear();
                    CommonCls.DTListEvents.Rows.Clear();
                }
                catch { }
                try
                {
                    pnlOutplayerlist.Hide();
                    dgvOutplayerlist.Rows.Clear();
                }
                catch { }
            }
            catch { }
            PageLoad = true;
            bonuscheck = false;
            retriveVizSend();
            //   XMLPush(1, "END");
        }

        void ReSetBeforeEvent()
        {
            CommonCls.EventTypeId = 0;
            CommonCls.PX = 0;
            CommonCls.PY = 0;
            lbRaider.SelectedIndex = -1;
            lbKeyDefender.SelectedIndex = -1;
            lbSupportedDefender.SelectedIndex = -1;
            lbLineOutRaider.SelectedIndex = -1;
            lbLineOutDefender.SelectedIndex = -1;
            lbDefender.SelectedIndex = -1;
            lbInitiator.SelectedIndex = -1;
            RaiderClick = false;
            DefenderClick = false;
            TouchClick = false;
            TackleClick = false;
            techPoint = false;
            isDeclare = false;
        }

        void LoadRaider_Defender()
        {
            try
            {
                MasterDL obj = new MasterDL();
                if (obj.ExeQueryStrRetStrDL("select COUNT(RaidNo) from Raid where Matchid=" + CommonCls.MatchId + "", 1) == "0")
                {
                    // DataSet sevensPlayerDS = obj.ExeQueryStrRetDsDL("Select * from (select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.RaidClubId + " and L.issub=0  order by CAST(JercyNo AS INT);select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,L.JercyNo   from lineups L INNER JOIN Player P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.DefenceClubId + "   and L.issub=0 )A GROUP BY playerid,JercyNo,firstname order by JercyNo", 1);
                    //  lbRaider.DataSource = sevensPlayerDS.Tables[0];
                    lbRaider.DataSource = obj.ExeQueryStrRetDsDL("Select * from (select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.RaidClubId + " and L.issub=0 )A GROUP BY playerid,JercyNo,firstname order by JercyNo", 1).Tables[0];
                    lbRaider.DisplayMember = "firstname";
                    lbRaider.ValueMember = "playerid";

                    // lbKeyDefender.DataSource = sevensPlayerDS.Tables[1];
                    lbKeyDefender.DataSource = obj.ExeQueryStrRetDsDL("Select * from (select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,L.JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.DefenceClubId + "   and L.issub=0 )A GROUP BY playerid,JercyNo,firstname order by JercyNo", 1).Tables[0];
                    lbKeyDefender.DisplayMember = "firstname";
                    lbKeyDefender.ValueMember = "playerid";

                    //sevensPlayerDS = obj.ExeQueryStrRetDsDL("select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,L.JercyNo   from lineups L INNER JOIN Player P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.RaidClubId + " and L.issub=0  order by CAST(JercyNo AS INT);select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,L.JercyNo   from lineups L INNER JOIN Player P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.DefenceClubId + "   and L.issub=0 order by CAST(JercyNo AS INT)", 1);
                    cbRaider.DataSource = null;
                    DataTable dt3 = new DataTable();
                    obj = new MasterDL();
                    dt3 = obj.ExeQueryStrRetDsDL("Select * from (select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,L.JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.RaidClubId + " and L.issub=0 )A GROUP BY playerid,JercyNo,firstname order by JercyNo", 1).Tables[0];
                    cbRaider.DataSource = dt3;
                    cbRaider.DisplayMember = "firstname";
                    cbRaider.ValueMember = "playerid";
                    cbRaider.SelectedIndex = -1;
                    raiderchose = true;

                    DataSet sevensPlayerDS = obj.ExeQueryStrRetDsDL("Select * from (select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,L.JercyNo from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.RaidClubId + " and L.issub=0  )A GROUP BY playerid,JercyNo,firstname order by JercyNo;Select * from (select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,L.JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.DefenceClubId + "   and L.issub=0)A GROUP BY playerid,JercyNo,firstname  order by JercyNo", 1);
                    lbLineOutRaider.DataSource = sevensPlayerDS.Tables[0];
                    lbLineOutRaider.DisplayMember = "firstname";
                    lbLineOutRaider.ValueMember = "playerid";

                    lbSupportedDefender.DataSource = sevensPlayerDS.Tables[1];
                    lbSupportedDefender.DisplayMember = "firstname";
                    lbSupportedDefender.ValueMember = "playerid";

                    sevensPlayerDS = obj.ExeQueryStrRetDsDL("Select * from (select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,L.JercyNo from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.RaidClubId + " and L.issub=0  )A GROUP BY playerid,JercyNo,firstname order by JercyNo;Select * from (select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,L.JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.DefenceClubId + "   and L.issub=0)A GROUP BY playerid,JercyNo,firstname order by JercyNo", 1);

                    lbLineOutDefender.DataSource = sevensPlayerDS.Tables[1];
                    lbLineOutDefender.DisplayMember = "firstname";
                    lbLineOutDefender.ValueMember = "playerid";

                    sevensPlayerDS = obj.ExeQueryStrRetDsDL("Select * from (select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,L.JercyNo from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.RaidClubId + " and L.issub=0  )A GROUP BY playerid,JercyNo,firstname order by JercyNo;Select * from (select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,L.JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.DefenceClubId + "   and L.issub=0)A GROUP BY playerid,JercyNo,firstname order by JercyNo", 1);

                    lbDefender.DataSource = sevensPlayerDS.Tables[1];
                    lbDefender.DisplayMember = "firstname";
                    lbDefender.ValueMember = "playerid";

                    lbInitiator.DataSource = sevensPlayerDS.Tables[1];
                    lbInitiator.DisplayMember = "firstname";
                    lbInitiator.ValueMember = "playerid";

                }
                else
                {
                    //dt = obj.ExeQueryStrRetDTDL("Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,L.JercyNo   from lineups L INNER JOIN Player P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.RaidClubId + " and L.issub=0 AND PlayerID Not IN(Select PlayerID from OutPlayerRef Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.RaidClubId + " AND RaidNo=" + CommonCls.RaidNo + ") order by CAST(JercyNo AS INT)", 1);
                    dt = new DataTable();
                    dt = obj.ExeQueryStrRetDTDL("Select * from (Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.RaidClubId + " and L.issub=0 AND PlayerID NOT IN(Select PlayerID from OutPlayerRef Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.RaidClubId + " AND RaidNo=" + CommonCls.RaidNo + ") AND PlayerID Not IN(Select PlayerID from SuspendedPlayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.RaidClubId + " And Issuspend=1) Union All Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.RaidClubId + " and L.issub=0 AND PlayerID IN(Select PlayerID from Innerplayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.RaidClubId + " AND RaidNo=" + CommonCls.RaidNo + ") AND PlayerID Not IN(Select PlayerID from SuspendedPlayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.RaidClubId + " And Issuspend=1))A GROUP BY playerid,JercyNo,firstname order by JercyNo", 1);

                    lbRaider.DataSource = dt;
                    lbRaider.DisplayMember = "firstname";
                    lbRaider.ValueMember = "playerid";

                    cbRaider.DataSource = null;
                    DataTable dt3 = new DataTable();
                    dt3 = obj.ExeQueryStrRetDTDL("Select * from (Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.RaidClubId + " and L.issub=0 AND PlayerID NOT IN(Select PlayerID from OutPlayerRef Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.RaidClubId + " AND RaidNo=" + CommonCls.RaidNo + ") AND PlayerID Not IN(Select PlayerID from SuspendedPlayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.RaidClubId + " And Issuspend=1) Union All Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.RaidClubId + " and L.issub=0 AND PlayerID IN(Select PlayerID from Innerplayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.RaidClubId + " AND RaidNo=" + CommonCls.RaidNo + ") AND PlayerID Not IN(Select PlayerID from SuspendedPlayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.RaidClubId + " And Issuspend=1))A GROUP BY playerid,JercyNo,firstname order by JercyNo", 1);
                    cbRaider.DataSource = dt3;
                    cbRaider.DisplayMember = "firstname";
                    cbRaider.ValueMember = "playerid";
                    cbRaider.SelectedIndex = -1;
                    raiderchose = true;
                    dt = new DataTable();
                    //dt = obj.ExeQueryStrRetDTDL("Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,L.JercyNo   from lineups L INNER JOIN Player P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.DefenceClubId + " and L.issub=0 AND PlayerID Not IN(Select PlayerID from OutPlayerRef Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.DefenceClubId + " AND RaidNo=" + CommonCls.RaidNo + ") order by CAST(JercyNo AS INT)", 1);
                    dt = obj.ExeQueryStrRetDTDL("Select * from (Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.DefenceClubId + " and L.issub=0 AND PlayerID NOT IN(Select PlayerID from OutPlayerRef Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.DefenceClubId + " AND RaidNo=" + CommonCls.RaidNo + ") AND PlayerID Not IN(Select PlayerID from SuspendedPlayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.DefenceClubId + " And Issuspend=1) Union All Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.DefenceClubId + " and L.issub=0 AND PlayerID IN(Select PlayerID from Innerplayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.DefenceClubId + " AND RaidNo=" + CommonCls.RaidNo + ") AND PlayerID Not IN(Select PlayerID from SuspendedPlayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.DefenceClubId + " And Issuspend=1))A GROUP BY playerid,JercyNo,firstname order by JercyNo", 1);
                    lbKeyDefender.DataSource = dt;
                    lbKeyDefender.DisplayMember = "firstname";
                    lbKeyDefender.ValueMember = "playerid";

                    dt = new DataTable();
                    dt = obj.ExeQueryStrRetDTDL("Select * from (Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.RaidClubId + " and L.issub=0 AND PlayerID NOT IN(Select PlayerID from OutPlayerRef Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.RaidClubId + " AND RaidNo=" + CommonCls.RaidNo + ") AND PlayerID Not IN(Select PlayerID from SuspendedPlayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.RaidClubId + " And Issuspend=1) Union All Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.RaidClubId + " and L.issub=0 AND PlayerID IN(Select PlayerID from Innerplayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.RaidClubId + " AND RaidNo=" + CommonCls.RaidNo + ") AND PlayerID Not IN(Select PlayerID from SuspendedPlayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.RaidClubId + " And Issuspend=1))A GROUP BY playerid,JercyNo,firstname order by JercyNo", 1);
                    lbLineOutRaider.DataSource = dt;
                    lbLineOutRaider.DisplayMember = "firstname";
                    lbLineOutRaider.ValueMember = "playerid";

                    dt = new DataTable();
                    dt = obj.ExeQueryStrRetDTDL("Select * from (Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.DefenceClubId + " and L.issub=0 AND PlayerID NOT IN(Select PlayerID from OutPlayerRef Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.DefenceClubId + " AND RaidNo=" + CommonCls.RaidNo + ") AND PlayerID Not IN(Select PlayerID from SuspendedPlayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.DefenceClubId + " And Issuspend=1) Union All Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.DefenceClubId + " and L.issub=0 AND PlayerID IN(Select PlayerID from Innerplayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.DefenceClubId + " AND RaidNo=" + CommonCls.RaidNo + ") AND PlayerID Not IN(Select PlayerID from SuspendedPlayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.DefenceClubId + " And Issuspend=1))A GROUP BY playerid,JercyNo,firstname order by JercyNo", 1);
                    lbSupportedDefender.DataSource = dt;
                    lbSupportedDefender.DisplayMember = "firstname";
                    lbSupportedDefender.ValueMember = "playerid";

                    dt = new DataTable();
                    dt = obj.ExeQueryStrRetDTDL("Select * from (Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.DefenceClubId + " and L.issub=0 AND PlayerID NOT IN(Select PlayerID from OutPlayerRef Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.DefenceClubId + " AND RaidNo=" + CommonCls.RaidNo + ") AND PlayerID Not IN(Select PlayerID from SuspendedPlayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.DefenceClubId + " And Issuspend=1) Union All Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.DefenceClubId + " and L.issub=0 AND PlayerID IN(Select PlayerID from Innerplayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.DefenceClubId + " AND RaidNo=" + CommonCls.RaidNo + ") AND PlayerID Not IN(Select PlayerID from SuspendedPlayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.DefenceClubId + " And Issuspend=1))A GROUP BY playerid,JercyNo,firstname order by JercyNo", 1);
                    lbLineOutDefender.DataSource = dt;
                    lbLineOutDefender.DisplayMember = "firstname";
                    lbLineOutDefender.ValueMember = "playerid";

                    dt = new DataTable();
                    dt = obj.ExeQueryStrRetDTDL("Select * from (Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.DefenceClubId + " and L.issub=0 AND PlayerID NOT IN(Select PlayerID from OutPlayerRef Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.DefenceClubId + " AND RaidNo=" + CommonCls.RaidNo + ") AND PlayerID Not IN(Select PlayerID from SuspendedPlayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.DefenceClubId + " And Issuspend=1) Union All Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.DefenceClubId + " and L.issub=0 AND PlayerID IN(Select PlayerID from Innerplayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.DefenceClubId + " AND RaidNo=" + CommonCls.RaidNo + ") AND PlayerID Not IN(Select PlayerID from SuspendedPlayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.DefenceClubId + " And Issuspend=1))A GROUP BY playerid,JercyNo,firstname order by JercyNo", 1);
                    lbDefender.DataSource = dt;
                    lbDefender.DisplayMember = "firstname";
                    lbDefender.ValueMember = "playerid";

                    dt = new DataTable();
                    dt = obj.ExeQueryStrRetDTDL("Select * from (Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.DefenceClubId + " and L.issub=0 AND PlayerID NOT IN(Select PlayerID from OutPlayerRef Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.DefenceClubId + " AND RaidNo=" + CommonCls.RaidNo + ") AND PlayerID Not IN(Select PlayerID from SuspendedPlayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.DefenceClubId + " And Issuspend=1) Union All Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.DefenceClubId + " and L.issub=0 AND PlayerID IN(Select PlayerID from Innerplayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.DefenceClubId + " AND RaidNo=" + CommonCls.RaidNo + ") AND PlayerID Not IN(Select PlayerID from SuspendedPlayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.DefenceClubId + " And Issuspend=1))A GROUP BY playerid,JercyNo,firstname order by JercyNo", 1);
                    lbInitiator.DataSource = dt;
                    lbInitiator.DisplayMember = "firstname";
                    lbInitiator.ValueMember = "playerid";
                }
                //INOUTPlayer();
                try
                {
                    string RaidColor = "", DefColor = "";
                    if (CommonCls.ClubId1 == CommonCls.RaidClubId)
                        RaidColor = CommonCls.TeamAColor;
                    else
                        RaidColor = CommonCls.TeamBColor;
                    if (CommonCls.ClubId1 == CommonCls.DefenceClubId)
                        DefColor = CommonCls.TeamAColor;
                    else
                        DefColor = CommonCls.TeamBColor;

                    lbRaider.BackColor = Color.FromName(RaidColor);
                    lbLineOutRaider.BackColor = Color.FromName(RaidColor);


                    lbKeyDefender.BackColor = Color.FromName(DefColor);
                    lbLineOutDefender.BackColor = Color.FromName(DefColor);
                    lbDefender.BackColor = Color.FromName(DefColor);
                    lbSupportedDefender.BackColor = Color.FromName(DefColor);
                    lbDefender.BackColor = Color.FromName(DefColor);
                }
                catch
                {
                    lbRaider.BackColor = Color.FromName("Silver");
                    lbLineOutRaider.BackColor = Color.FromName("Silver");


                    lbKeyDefender.BackColor = Color.FromName("Silver");
                    lbLineOutDefender.BackColor = Color.FromName("Silver");
                    lbDefender.BackColor = Color.FromName("Silver");
                    lbSupportedDefender.BackColor = Color.FromName("Silver");
                }

                lbRaider.SelectedIndex = -1;
                lbKeyDefender.SelectedIndex = -1;
                lbLineOutRaider.SelectedIndex = -1;
                lbSupportedDefender.SelectedIndex = -1;
                lbLineOutDefender.SelectedIndex = -1;
                lbDefender.SelectedIndex = -1;
                lbInitiator.SelectedIndex = -1;

            }
            catch
            { }

        }


        void INOUTPlayer()
        {
            MasterDL obj = new MasterDL();
            dt = new DataTable();
            dt = obj.ExeQueryStrRetDTDL("Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,L.JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.ClubId1 + " and L.issub=0 AND PlayerID NOT IN(Select PlayerID from OutPlayerRef Where Matchid=" + CommonCls.MatchId + " And Halfid=" + CommonCls.HalfID + " And Clubid=" + CommonCls.ClubId1 + " AND RaidNo=" + CommonCls.RaidNo + ")", 1);
            lbTeamAINList.DataSource = dt;
            lbTeamAINList.DisplayMember = "firstname";
            lbTeamAINList.ValueMember = "playerid";

            dt = new DataTable();
            dt = obj.ExeQueryStrRetDTDL("Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,L.JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.ClubId2 + " and L.issub=0 AND PlayerID NOT IN(Select PlayerID from OutPlayerRef Where Matchid=" + CommonCls.MatchId + " And Halfid=" + CommonCls.HalfID + " And Clubid=" + CommonCls.ClubId2 + " AND RaidNo=" + CommonCls.RaidNo + ")", 1);
            lbTeamBINList.DataSource = dt;
            lbTeamBINList.DisplayMember = "firstname";
            lbTeamBINList.ValueMember = "playerid";

            dt = new DataTable();
            dt = obj.ExeQueryStrRetDTDL("Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,L.JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.ClubId1 + " and L.issub=0 AND PlayerID IN(Select PlayerID from OutPlayerRef Where Matchid=" + CommonCls.MatchId + " And Halfid=" + CommonCls.HalfID + " And Clubid=" + CommonCls.ClubId1 + " AND RaidNo=" + CommonCls.RaidNo + ")", 1);
            lbTeamAOutList.DataSource = dt;
            lbTeamAOutList.DisplayMember = "firstname";
            lbTeamAOutList.ValueMember = "playerid";
            lbTeamAOutList.SelectedIndex = 0;

            dt = new DataTable();
            dt = obj.ExeQueryStrRetDTDL("Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,L.JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.ClubId2 + " and L.issub=0 AND PlayerID IN(Select PlayerID from OutPlayerRef Where Matchid=" + CommonCls.MatchId + " And Halfid=" + CommonCls.HalfID + " And Clubid=" + CommonCls.ClubId2 + " AND RaidNo=" + CommonCls.RaidNo + ")", 1);
            lbTeamBOutList.DataSource = dt;
            lbTeamBOutList.DisplayMember = "firstname";
            lbTeamBOutList.ValueMember = "playerid";
            lbTeamBOutList.SelectedIndex = 0;
        }
        private void pbRaiderClose_Click(object sender, EventArgs e)
        {
            pnlRaider.Hide();
        }

        private void pbDefenderClose_Click(object sender, EventArgs e)
        {
            pnlKeyDefender.Hide();
        }

        private void pbSubClose_Click(object sender, EventArgs e)
        {
            pnlSubtitute.Hide();
        }

        private void btnRaiderClear_Click(object sender, EventArgs e)
        {
            lbRaider.SelectedIndex = -1;
        }

        private void btnKeydefenderClear_Click(object sender, EventArgs e)
        {
            lbKeyDefender.SelectedIndex = -1;
        }

        private void btnSupportKeydefenderClear_Click(object sender, EventArgs e)
        {
            lbSupportedDefender.SelectedIndex = -1;
        }

        private void btnHalfStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnHalfStart.Text == "Half Start")
                {
                    #region HalfStart
                    try
                    {
                        dt = objDL.ExeQueryStrRetDTDL("SELECT * FROM MatchHalf where  matchID= " + CommonCls.MatchId + " and HalfStart=1 and HalfEnd=0", 1);
                        //   GVscorecard.DataSource = dt;
                        if (dt.Rows.Count > 0)
                        {
                            CommonCls.HalfID = Convert.ToInt32(dt.Rows[0]["HalfID"]);
                            lblhalfid.Text = dt.Rows[0]["HalfID"].ToString();
                        }
                        else
                        {
                            dt = objDL.ExeQueryStrRetDTDL("SELECT Min(HalfID)HalfID FROM MatchHalf where  matchID= " + CommonCls.MatchId + " and HalfStart=0 and HalfEnd=0", 1);

                            if (dt.Rows.Count > 0)
                            {
                                TimerReset();
                                if (dt.Rows[0]["HalfID"].ToString() != string.Empty)
                                {
                                    CommonCls.HalfID = Convert.ToInt32(dt.Rows[0]["HalfID"]);
                                    lblhalfid.Text = dt.Rows[0]["HalfID"].ToString();
                                    btnCard.Enabled = true;
                                    btnTechnicalPoint.Enabled = true;
                                }
                                else
                                {
                                    MessageBox.Show("2 Half are Completed", "Kabaddi Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                    btnCard.Enabled = false;
                                    btnTechnicalPoint.Enabled = false;
                                }
                            }
                            try
                            {
                                objDL.ExeQueryRetBooDL("Update MatchHalf set HalfStart=1,HalfEnd=0,StartTime='" + DateTime.Now + "' where Matchid=" + CommonCls.MatchId + " and HalfID=" + CommonCls.HalfID + "", 1);
                            }
                            catch { }
                        }

                        DataTable dtt1 = new DataTable();
                        dtt1 = objDL.ExeQueryStrRetDTDL("SELECT * FROM Raid where  matchID= " + CommonCls.MatchId + " and HalfID=" + CommonCls.HalfID + " order by TimerStart desc", 1);
                        if (dtt1.Rows.Count > 0)
                        {
                            btnCard.Enabled = true;
                            btnTechnicalPoint.Enabled = true;
                            CommonCls.LastTime = default(DateTime).Add(Convert.ToDateTime(dtt1.Rows[0]["TimerStart"]).TimeOfDay);
                            if (ConfigurationSettings.AppSettings["Timer"] == "0")
                            {
                                mySW.Stop();
                                if (_timerRunning)// If the timer is already running
                                {
                                    Timer_MatchClock.Stop();
                                    _timerRunning = false;
                                }
                                btn_MatchClock_Start.Text = "Timer Resume";
                                CommonCls.LastTime = default(DateTime).Add(Convert.ToDateTime(ConfigurationSettings.AppSettings["StartTime"]).TimeOfDay);
                            }
                            else if (ConfigurationSettings.AppSettings["Timer"] == "1")
                            {
                                mySW.Start();
                                Timer_MatchClock.Start();
                                _timerRunning = true;
                                Starttime = DateTime.Now;

                                btn_MatchClock_Start.Text = "Timer Pause";
                            }
                        }
                        else
                        {
                            //btnCard.Enabled = false;
                            //btnTechnicalPoint.Enabled = false;
                            btnCard.Enabled = true;
                            btnTechnicalPoint.Enabled = true;
                            TimerReset();
                            CommonCls.LastTime = default(DateTime).Add(Convert.ToDateTime("00:00:00").TimeOfDay);

                            startoffset = Convert.ToInt32(TimeSpan.FromTicks(CommonCls.LastTime.Ticks).TotalSeconds);
                            mySW = new Stopwatch();

                            TimeSpan span3 = TimeSpan.FromSeconds(startoffset).Add(mySW.Elapsed);
                            dtp_MatchClock.Value = DateTime.ParseExact(span3.ToString(@"mm\:ss"), "mm:ss", CultureInfo.InvariantCulture);
                            span3 = TimeSpan.FromSeconds(CurrntTime - startoffset + 1).Subtract(mySW.Elapsed);
                            dtp_ElapseClock.Value = DateTime.ParseExact(span3.ToString(@"mm\:ss"), "mm:ss", CultureInfo.InvariantCulture);
                            mySW.Start();
                            Timer_MatchClock.Start();
                            _timerRunning = true;

                            Starttime = DateTime.Now;

                            btn_MatchClock_Start.Text = "Timer Pause";
                        }
                    }
                    catch
                    {
                        CommonCls.LastTime = default(DateTime).Add(DateTime.Now.TimeOfDay);
                    }


                    panel1.Enabled = true;
                    btnHalfStart.Enabled = false;
                    BtnStartEnd.Enabled = true;
                    btnHalfStart.Text = "Half Continue";
                    btnHalfEnd.Enabled = true;
                    panel1.Enabled = true;
                    #endregion

                    try
                    {
                        int cnt = objDL.ExeQueryStrDL("Select ISNULL(Count(*),0)+1 From tblCorrectedTable where Matchid=" + CommonCls.MatchId + " And tablename='MatchHalf'", 1);
                        objDL.ExeQueryRetBooDL("Insert into tblCorrectedTable (Matchid,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + CommonCls.MatchId + "," + cnt + ",'MatchHalf','" + System.DateTime.Now + "',0,1,0)", 1);
                    }
                    catch { }
                    XMLPush(1, "END");
                }
                else if (btnHalfStart.Text == "Half Continue")
                {
                    #region HalfCondinue
                    try
                    {
                        DataTable dtt1 = new DataTable();
                        dtt1 = objDL.ExeQueryStrRetDTDL("SELECT * FROM Raid where  matchID= " + CommonCls.MatchId + " and HalfID=" + CommonCls.HalfID + " order by TimerStart desc", 1);
                        if (dtt1.Rows.Count > 0)
                        {
                            btnCard.Enabled = true;
                            btnTechnicalPoint.Enabled = true;
                            CommonCls.LastTime = default(DateTime).Add(Convert.ToDateTime(dtt1.Rows[0]["Timerend"]).TimeOfDay);
                            int sec = (CommonCls.LastTime.Minute * 60) + (CommonCls.LastTime.Second);
                            startoffset = sec;
                            mySW = new Stopwatch();
                            if (ConfigurationSettings.AppSettings["Timer"] == "0")
                            {
                                mySW.Stop();
                                if (_timerRunning)// If the timer is already running
                                {
                                    Timer_MatchClock.Stop();
                                    _timerRunning = false;
                                }
                                btn_MatchClock_Start.Text = "Timer Resume";
                                CommonCls.LastTime = default(DateTime).Add(Convert.ToDateTime(ConfigurationSettings.AppSettings["StartTime"]).TimeOfDay);
                            }
                            else if (ConfigurationSettings.AppSettings["Timer"] == "1")
                            {

                                startoffset = Convert.ToInt32(TimeSpan.FromTicks(CommonCls.LastTime.Ticks).TotalSeconds);
                                mySW.Start();
                                Timer_MatchClock.Start();
                                _timerRunning = true;
                                Starttime = DateTime.Now;
                                btn_MatchClock_Start.Text = "Timer Pause";
                            }
                        }
                        else
                        {
                            btnCard.Enabled = false;
                            btnTechnicalPoint.Enabled = false;
                            CommonCls.LastTime = default(DateTime).Add(Convert.ToDateTime("00:00:00").TimeOfDay);

                            startoffset = Convert.ToInt32(TimeSpan.FromTicks(CommonCls.LastTime.Ticks).TotalSeconds);
                            mySW = new Stopwatch();

                            TimeSpan span3 = TimeSpan.FromSeconds(startoffset).Add(mySW.Elapsed);
                            dtp_MatchClock.Value = DateTime.ParseExact(span3.ToString(@"mm\:ss"), "mm:ss", CultureInfo.InvariantCulture);
                            span3 = TimeSpan.FromSeconds(CurrntTime - startoffset + 1).Subtract(mySW.Elapsed);
                            dtp_ElapseClock.Value = DateTime.ParseExact(span3.ToString(@"mm\:ss"), "mm:ss", CultureInfo.InvariantCulture);
                            btn_MatchClock_Start.Text = "Timer Start";
                        }
                    }
                    catch
                    {
                        CommonCls.LastTime = default(DateTime).Add(DateTime.Now.TimeOfDay);
                    }
                    panel1.Enabled = true;
                    btnHalfStart.Enabled = false;
                    BtnStartEnd.Enabled = true;
                    btnHalfStart.Text = "Half Continue";
                    btnHalfEnd.Enabled = true;
                    panel1.Enabled = true;

                    #endregion

                    XMLPush(1, "END");
                }
                Reset();
                BtnStartEnd.Enabled = true;
            }
            catch { }
        }

        void StartMatch()
        {
            try
            {
                //ClearAll();
                // timer2.Start();
                ConfigurationManager.RefreshSection("appSettings");
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                ConfigurationManager.RefreshSection("appSettings");
                ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);

                string gettime = ConfigurationSettings.AppSettings["Timer"].ToString();

                if (ConfigurationSettings.AppSettings["Timer"] == "1")
                {
                    _timer = new System.Windows.Forms.Timer();
                    _timer.Interval = 1000;
                    _timer.Tick += new EventHandler(_timer_Tick);
                    if (!_timerRunning)
                    {
                        // Set the start time to Now
                        //_startTime = DateTime.Now;
                        _startTime = CommonCls.LastTime;
                        // Store the total elapsed time so far
                        _totalElapsedTime = _currentElapsedTime;

                        _timer.Start();
                        _timerRunning = true;
                    }
                    else
                    {
                        _startTime = CommonCls.LastTime;
                    }
                }
                else
                {
                    MessageBox.Show("timer off");
                }
            }
            catch { }
        }


        private System.Windows.Forms.Timer _timer;
        private TimeSpan _currentElapsedTime = TimeSpan.Zero;
        private TimeSpan _currentElapsedTimeN = TimeSpan.Zero;
        private TimeSpan _totalElapsedTime = TimeSpan.FromSeconds(1);
        private DateTime _startTime = DateTime.MinValue;
        private bool _timerRunning = false;

        void _timer_Tick(object sender, EventArgs e)
        {
            try
            {
                _totalElapsedTime = TimeSpan.FromSeconds(1);

                DateTime dtime = new DateTime();
                var timeSinceStartTime = DateTime.Parse(lblMatchTime.Text) - dtime;

                //var timeSinceStartTime = CommonCls.LastTime - _startTime; 
                timeSinceStartTime = new TimeSpan(timeSinceStartTime.Hours,
                                                  timeSinceStartTime.Minutes,
                                                  timeSinceStartTime.Seconds);
                _currentElapsedTime = timeSinceStartTime + _totalElapsedTime;
                // These are just two Label controls which display the current 
                // elapsed time and total elapsed time
                lblMatchTime.Text = _currentElapsedTime.ToString();
                try
                {

                    //_startTime = DateTime.MinValue;
                    DateTime _MTime = DateTime.Parse("11/7/2015 00:00:00 AM");
                    var timeElapseTime = DateTime.Parse(lblElapseTime.Text) - _MTime;
                    timeElapseTime = new TimeSpan(timeElapseTime.Hours,
                                                   timeElapseTime.Minutes,
                                                   timeElapseTime.Seconds);

                    _currentElapsedTimeN = timeElapseTime - _totalElapsedTime;
                    lblElapseTime.Text = _currentElapsedTimeN.ToString();
                }
                catch
                {
                    lblElapseTime.Text = "00:00:00";
                }

                if (BtnStartEnd.Text == "Raid End" && Convert.ToInt32(lblRaidTime.Text) < 30)//&& CommonCls.RaiderID != 0)
                    lblRaidTime.Text = (Convert.ToInt32(lblRaidTime.Text) + 1).ToString();

                //retriveVizSend();
                //lblMatchStrTime.Text = timeSinceStartTime.ToString();
            }
            catch
            {
            }
        }

        public void TimerReset()
        {
            #region Timer Reset

            try
            {
                lblMatchTime.Text = default(DateTime).Add(Convert.ToDateTime(ConfigurationSettings.AppSettings["StartTime"]).TimeOfDay).ToString("HH:mm:ss");
                CommonCls.LastTime = default(DateTime).Add(Convert.ToDateTime(ConfigurationSettings.AppSettings["StartTime"]).TimeOfDay);
                string ste1 = ConfigurationSettings.AppSettings["Timer"].ToString();
                string configFile = Application.ExecutablePath + ".config";  //c:\path\exename.exe.config
                XmlDocument xdoc = new XmlDocument();
                xdoc.Load(configFile);
                XmlNode node = xdoc.SelectSingleNode("/configuration/appSettings/add[@key='Timer']/@value");
                node.Value = "1";
                node = xdoc.SelectSingleNode("/configuration/appSettings/add[@key='StartTime']/@value");
                node.Value = "";
                File.WriteAllText(configFile, xdoc.InnerXml);
                ConfigurationManager.RefreshSection("appSettings");

                CommonCls.LastTime = default(DateTime).Add(Convert.ToDateTime("00:00:00").TimeOfDay);
                lblMatchTime.Text = default(DateTime).Add(Convert.ToDateTime("00:00:00").TimeOfDay).ToString("HH:mm:ss");
                lblElapseTime.Text = default(DateTime).Add(Convert.ToDateTime("00:20:00").TimeOfDay).ToString("HH:mm:ss");
                btnTimerOn.Enabled = false;
                btnTimerOff.Enabled = true;
            }
            catch
            {
                string ste1 = ConfigurationSettings.AppSettings["Timer"].ToString();
                string configFile = Application.ExecutablePath + ".config";  //c:\path\exename.exe.config
                XmlDocument xdoc = new XmlDocument();
                xdoc.Load(configFile);
                XmlNode node = xdoc.SelectSingleNode("/configuration/appSettings/add[@key='Timer']/@value");
                node.Value = "1";
                node = xdoc.SelectSingleNode("/configuration/appSettings/add[@key='StartTime']/@value");
                node.Value = "";
                File.WriteAllText(configFile, xdoc.InnerXml);
                ConfigurationManager.RefreshSection("appSettings");

                CommonCls.LastTime = default(DateTime).Add(Convert.ToDateTime("00:00:00").TimeOfDay);
                lblMatchTime.Text = default(DateTime).Add(Convert.ToDateTime("00:00:00").TimeOfDay).ToString("HH:mm:ss");
                lblElapseTime.Text = default(DateTime).Add(Convert.ToDateTime("00:20:00").TimeOfDay).ToString("HH:mm:ss");
                btnTimerOn.Enabled = false;
                btnTimerOff.Enabled = true;
            }

            #endregion
        }

        private void btnTimerReset_Click(object sender, EventArgs e)
        {
            TimerReset();
            try
            {
                ObjFndCtrl.sendScorecardTimer("START");
            }
            catch { }
        }

        private void btnLineoutRaiderClear_Click(object sender, EventArgs e)
        {
            lbLineOutRaider.SelectedIndex = -1;
        }

        private void btnLineoutDefenderClear_Click(object sender, EventArgs e)
        {
            lbLineOutDefender.SelectedIndex = -1;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (BtnStartEnd.Text == "Raid End")
            {
                objDL.ExeQueryRetBooDL("Delete FROM Raid where matchID= " + CommonCls.MatchId + " and RaidNo=" + CommonCls.RaidNo + "", 1);

                try
                {
                    MasterDL obj = new MasterDL();
                    int cnt = obj.ExeQueryStrDL("Select ISNULL(Count(Raidno),0)+1 From tblCorrectedRaid where Matchid=" + CommonCls.MatchId + " And HalfID=" + CommonCls.HalfID + " AND RaidNo=" + CommonCls.RaidNo + "", 1);
                    obj.ExeQueryRetBooDL("Insert into tblCorrectedRaid (Matchid,HalfID,Raidno,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + CommonCls.RaidNo + "," + cnt + ",'Raid_Start','" + System.DateTime.Now + "',0,0,1)", 1);
                }
                catch { }
            }


            //Reset();
            dt = objDL.ExeQueryStrRetDTDL("SELECT Min(HalfID)HalfID FROM MatchHalf where  matchID= " + CommonCls.MatchId + " and HalfStart=1 and HalfEnd=0", 1);

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["HalfID"].ToString() != string.Empty)
                {
                    btnCard.Enabled = true;
                    btnTechnicalPoint.Enabled = true;
                }
            }
            Reset();
            retriveVizSend();
            //if (BtnStartEnd.Text != "Raid End")
            //    XMLPush(1, "END");
            XMLPush(1, "END");
        }

        private void btnLineoutSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    CurTimeinSec = TimeSpan.Parse("00:" + dtp_MatchClock.Value.Minute.ToString("D2") + ":" + dtp_MatchClock.Value.Second.ToString("D2")).TotalSeconds;
                }
                catch { CurTimeinSec = 0; }
                setEndtime = 0;

                if (CommonCls.RaidClubId == CommonCls.ClubId1)
                {
                    lblTeamA1.Text = CommonCls.Club1Prefix;
                    lblTeamB1.Text = CommonCls.Club2Prefix;
                }
                else if (CommonCls.RaidClubId == CommonCls.ClubId2)
                {
                    lblTeamA1.Text = CommonCls.Club2Prefix;
                    lblTeamB1.Text = CommonCls.Club1Prefix;
                }

                if (techPoint)
                {
                    int playerID = 0;
                    if (BtnStartEnd.Text == "Raid Start")
                    {
                        if (CommonCls.RaidNo == 0)
                            CommonCls.RaidNo = 1;
                        int EventID = objDL.ExeQueryStrDL("Select (Isnull(Max(EventID),0)+1) from Events Where MatchID=" + CommonCls.MatchId + " And RaidNo=" + (CommonCls.RaidNo) + "", 1); // TeamID
                        objDL.ExeQueryRetBooDL("Insert Into Events(MatchID,HalfID,RaidNo,EventId,EventType,PX,PY,StartFrame,Initiator,Time) Values (" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + CommonCls.RaidNo + "," + EventID + ",30,0,0,'" + setEndtime + "',0," + CurTimeinSec + ")", 1);

                        if (lbLineOutRaider.SelectedItems.Count > 0)
                            playerID = Convert.ToInt32(lbLineOutRaider.SelectedValue);
                        else if (lbLineOutDefender.SelectedItems.Count > 0)
                            playerID = Convert.ToInt32(lbLineOutDefender.SelectedValue);
                        objDL.ExeQueryRetBooDL("Insert Into OutPlayer(MatchID,HalfID,RaidNo,EventId,PlayerId,KeyDefender,SupportedKeyDefender,IsOut,OutType) Values (" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + CommonCls.RaidNo + "," + EventID + "," + playerID + ",0,0,0,30)", 1);
                        try
                        {
                            int cnt = objDL.ExeQueryStrDL("Select ISNULL(Count(Raidno),0)+1 From tblCorrectedRaid where Matchid=" + CommonCls.MatchId + " And HalfID=" + CommonCls.HalfID + " AND RaidNo=" + CommonCls.RaidNo + "", 1);
                            objDL.ExeQueryRetBooDL("Insert into tblCorrectedRaid (Matchid,HalfID,Raidno,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + CommonCls.RaidNo + "," + cnt + ",'Raid','" + System.DateTime.Now + "',0,1,0)", 1);
                        }
                        catch { }
                        try
                        {
                            string CurrentScore = objDL.ExeQueryStrRetStrDL("Select dbo.fn_GetCurrentRaidScore(" + Temp_matchid + "," + CommonCls.MatchId + "," + CommonCls.RaidNo + ")", 1);
                            objDL.ExeQueryRetBooDL("Update Raid set raidpoint=" + CurrentScore.Split('-')[0] + ",defencepoint=" + CurrentScore.Split('-')[1] + "  Where Matchid=" + CommonCls.MatchId + "  And RaidNo=" + CommonCls.RaidNo + "", 1);
                        }
                        catch { }

                        XMLPush(1, "END");
                        Reset();
                    }
                    else
                    {
                        CommonCls.EventID = CommonCls.EventID + 1;
                        CommonCls.DTListEvents.Rows.Add(CommonCls.MatchId, CommonCls.HalfID, CommonCls.RaidNo, CommonCls.EventID, "30", "0", "0", setEndtime, 0, CurTimeinSec);
                        if (lbLineOutRaider.SelectedItems.Count > 0)
                            playerID = Convert.ToInt32(lbLineOutRaider.SelectedValue);
                        else if (lbLineOutDefender.SelectedItems.Count > 0)
                            playerID = Convert.ToInt32(lbLineOutDefender.SelectedValue);
                        CommonCls.DTListOutPlayer.Rows.Add(CommonCls.MatchId, CommonCls.HalfID, CommonCls.RaidNo, CommonCls.EventID, playerID, "0", "0", "0", 30, "0");
                    }
                }
                else if (isDeclare && BtnStartEnd.Text == "Raid Start")
                {
                    if (CommonCls.RaidNo == 0)
                        CommonCls.RaidNo = 1;
                    int EventID = objDL.ExeQueryStrDL("Select (Isnull(Max(EventID),0)+1) from Events Where MatchID=" + CommonCls.MatchId + " And RaidNo=" + (CommonCls.RaidNo) + "", 1); // TeamID
                    if (lbLineOutRaider.SelectedItems.Count > 0)
                        objDL.ExeQueryRetBooDL("Update raid set IsDeclare=" + CommonCls.RaidClubId + " where MatchID=" + CommonCls.MatchId + " And RaidNo=" + (CommonCls.RaidNo) + "", 1);
                    if (lbLineOutDefender.SelectedItems.Count > 0)
                        objDL.ExeQueryRetBooDL("Update raid set IsDeclare=" + CommonCls.DefenceClubId + " where MatchID=" + CommonCls.MatchId + " And RaidNo=" + (CommonCls.RaidNo) + "", 1);

                    objDL.ExeQueryRetBooDL("Insert Into Events(MatchID,HalfID,RaidNo,EventId,EventType,PX,PY,StartFrame,Initiator,Time) Values (" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + CommonCls.RaidNo + "," + EventID + ",62,0,0,'" + setEndtime + "',0," + CurTimeinSec + ")", 1);


                    if (lbLineOutRaider.SelectedItems.Count > 0)
                    {
                        dt = new DataTable();
                        dt = (DataTable)lbLineOutRaider.DataSource;
                        foreach (DataRow dr in dt.Rows)
                        {
                            objDL.ExeQueryRetBooDL("Insert Into OutPlayer(MatchID,HalfID,RaidNo,EventId,PlayerId,KeyDefender,SupportedKeyDefender,IsOut,OutType) Values (" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + CommonCls.RaidNo + "," + EventID + "," + dr["PlayerID"].ToString() + ",0,0,1,62)", 1);
                            int Rank = 1 + objDL.ExeQueryStrDL("Select top 1 ROW_NUMBER() OVER(ORDER BY raidno,orderno) Rank from OutPlayerRef Where Matchid=" + CommonCls.MatchId + " And RaidNo=" + (CommonCls.RaidNo - 1) + " And PlayerID Not IN(Select PlayerID from Innerplayer Where Matchid=" + CommonCls.MatchId + " AND RaidNo=" + (CommonCls.RaidNo - 1) + ") order by Rank desc", 1);

                            objDL.ExeQueryRetBooDL("Insert Into OutPlayerRef(MatchID,HalfID,RaidNo,PlayerId,Clubid,OrderNo) Values (" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + CommonCls.RaidNo + "," + dr["PlayerID"].ToString() + "," + CommonCls.RaidClubId + "," + Rank + ")", 1);

                        }
                    }
                    else if (lbLineOutDefender.SelectedItems.Count > 0)
                    {
                        dt = new DataTable();
                        dt = (DataTable)lbLineOutDefender.DataSource;
                        foreach (DataRow dr in dt.Rows)
                        {
                            objDL.ExeQueryRetBooDL("Insert Into OutPlayer(MatchID,HalfID,RaidNo,EventId,PlayerId,KeyDefender,SupportedKeyDefender,IsOut,OutType) Values (" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + CommonCls.RaidNo + "," + EventID + "," + dr["PlayerID"].ToString() + ",0,0,1,62)", 1);
                            int Rank = 1 + objDL.ExeQueryStrDL("Select top 1 ROW_NUMBER() OVER(ORDER BY raidno,orderno) Rank from OutPlayerRef Where Matchid=" + CommonCls.MatchId + " And RaidNo=" + (CommonCls.RaidNo - 1) + " And PlayerID Not IN(Select PlayerID from Innerplayer Where Matchid=" + CommonCls.MatchId + " AND RaidNo=" + (CommonCls.RaidNo - 1) + ") order by Rank desc", 1);

                            objDL.ExeQueryRetBooDL("Insert Into OutPlayerRef(MatchID,HalfID,RaidNo,PlayerId,Clubid,OrderNo) Values (" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + CommonCls.RaidNo + "," + dr["PlayerID"].ToString() + "," + CommonCls.DefenceClubId + "," + Rank + ")", 1);

                        }
                    }
                    try
                    {
                        int cnt = objDL.ExeQueryStrDL("Select ISNULL(Count(Raidno),0)+1 From tblCorrectedRaid where Matchid=" + CommonCls.MatchId + " And HalfID=" + CommonCls.HalfID + " AND RaidNo=" + CommonCls.RaidNo + "", 1);
                        objDL.ExeQueryRetBooDL("Insert into tblCorrectedRaid (Matchid,HalfID,Raidno,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + CommonCls.RaidNo + "," + cnt + ",'Raid','" + System.DateTime.Now + "',0,1,0)", 1);
                    }
                    catch { }
                    XMLPush(1, "END");
                    Reset();
                }
                else
                {
                    if (lbLineOutDefender.SelectedIndex == -1 && lbLineOutRaider.SelectedIndex == -1) { MessageBox.Show("Select LineOut Player", "Kabaddi", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

                    if (BtnStartEnd.Text != "Raid Start" && Convert.ToInt32(lbLineOutRaider.SelectedValue) != CommonCls.RaiderID)
                        CommonCls.DTListEvents.Rows.Add(CommonCls.MatchId, CommonCls.HalfID, CommonCls.RaidNo, CommonCls.EventID, CommonCls.EventTypeId, CommonCls.PX, CommonCls.PY, setEndtime, 0, CurTimeinSec);
                    int PlayerIsExists = 0;
                    #region Command
                    //if (lbLineOutDefender.SelectedItems.Count > 1)
                    //{
                    //    for (int i = 0; i < lbLineOutDefender.SelectedItems.Count; i++)
                    //    {
                    //        for (int j = 0; j < CommonCls.DTListOutPlayer.Rows.Count; j++)
                    //        {
                    //            if (lbLineOutDefender.SelectedIndices[i].ToString() == CommonCls.DTListOutPlayer.Rows[j][4].ToString())
                    //            {
                    //                PlayerIsExists = 1;
                    //            }
                    //        }
                    //        if (PlayerIsExists == 0)
                    //            CommonCls.DTListOutPlayer.Rows.Add(CommonCls.MatchId, CommonCls.HalfID, CommonCls.RaidNo, CommonCls.EventID, lbLineOutDefender.SelectedIndices[i], "1", "0", "0", CommonCls.EventTypeId);
                    //        PlayerIsExists = 0;
                    //    }
                    //}
                    //else
                    //{
                    //    for (int i = 0; i < lbLineOutRaider.SelectedItems.Count; i++)
                    //    {
                    //        for (int j = 0; j < CommonCls.DTListOutPlayer.Rows.Count; j++)
                    //        {
                    //            if (lbSupportedDefender.SelectedIndices[i].ToString() == CommonCls.DTListOutPlayer.Rows[j][4].ToString())
                    //            {
                    //                PlayerIsExists = 1;
                    //            }
                    //        }
                    //        if (PlayerIsExists == 0)
                    //            CommonCls.DTListOutPlayer.Rows.Add(CommonCls.MatchId, CommonCls.HalfID, CommonCls.RaidNo, CommonCls.EventID, lbLineOutRaider.SelectedIndices[i], "0", "1", "0", CommonCls.EventTypeId);
                    //        PlayerIsExists = 0;
                    //    }
                    //}
                    #endregion

                    if (lbLineOutDefender.SelectedItems.Count > 0 && CommonCls.EventTypeId != 18)
                    {
                        #region Defender Team
                        foreach (DataRowView drview in lbLineOutDefender.SelectedItems)
                        {
                            for (int j = 0; j < CommonCls.DTListOutPlayer.Rows.Count; j++)
                            {
                                //if (drview["PlayerID"].ToString() == CommonCls.DTListOutPlayer.Rows[j][4].ToString())
                                //{
                                //    PlayerIsExists = 1;
                                //}
                            }
                            if (PlayerIsExists == 0 && BtnStartEnd.Text == "Raid Start")
                            {
                                int Orderno = objDL.ExeQueryStrDL("Select (Max(Orderno)+1) from OutPlayerRef Where MatchID=" + CommonCls.MatchId + " And RaidNo=" + (CommonCls.RaidNo) + "", 1); // TeamID
                                int Clubid = objDL.ExeQueryStrDL("Select ClubID from Lineups Where MatchID=" + CommonCls.MatchId + " And PlayerID=" + drview["PlayerID"].ToString() + "", 1); // TeamID
                                //objDL.ExeQueryRetBooDL("Insert Into OutPlayerRef(MatchID,HalfID,RaidNo,PlayerId,Clubid,orderNo) Values (" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + (CommonCls.RaidNo) + "," + drview["PlayerID"].ToString() + "," + Clubid + "," + Orderno + ")", 1);

                                if (CommonCls.EventTypeId == 24 || CommonCls.EventTypeId == 25 || CommonCls.EventTypeId == 23)
                                {
                                    int iskill = 0;
                                    if (CommonCls.EventTypeId == 25)
                                        iskill = 1;
                                    // Clubid = obj.ExeQueryStrDL("Select ClubID from Lineups Where MatchID=" + CommonCls.MatchId + " And PlayerID=" + drview["PlayerId"] + "", 1); // TeamID
                                    int EventID = objDL.ExeQueryStrDL("Select (Isnull(Max(EventID),0)+1) from Events Where MatchID=" + CommonCls.MatchId + " And RaidNo=" + (CommonCls.RaidNo) + "", 1); // TeamID
                                    objDL.ExeQueryRetBooDL("Insert Into Events(MatchID,HalfID,RaidNo,EventId,EventType,PX,PY,StartFrame,Initiator,Time) Values (" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + CommonCls.RaidNo + "," + EventID + "," + CommonCls.EventTypeId + "," + CommonCls.PX + "," + CommonCls.PY + ",'" + setEndtime + "',0," + CurTimeinSec + ")", 1);

                                    objDL.ExeQueryRetBooDL("Insert Into OutPlayer(MatchID,HalfID,RaidNo,EventId,PlayerId,KeyDefender,SupportedKeyDefender,IsOut,OutType) Values (" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + CommonCls.RaidNo + "," + EventID + "," + drview["PlayerID"].ToString() + ",0,0,0," + CommonCls.EventTypeId + ")", 1);
                                    if (CommonCls.EventTypeId == 24 || CommonCls.EventTypeId == 25)
                                        objDL.ExeQueryRetBooDL("Insert Into SuspendedPlayer(MatchID,HalfID,RaidNo,PlayerId,Clubid,Issuspend,iskill) Values (" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + CommonCls.RaidNo + "," + drview["PlayerID"].ToString() + "," + Clubid + ",1," + iskill + ")", 1);

                                    try
                                    {
                                        int cnt = objDL.ExeQueryStrDL("Select ISNULL(Count(Raidno),0)+1 From tblCorrectedRaid where Matchid=" + CommonCls.MatchId + " And HalfID=" + CommonCls.HalfID + " AND RaidNo=" + CommonCls.RaidNo + "", 1);
                                        objDL.ExeQueryRetBooDL("Insert into tblCorrectedRaid (Matchid,HalfID,Raidno,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + CommonCls.RaidNo + "," + cnt + ",'Raid','" + System.DateTime.Now + "',0,1,0)", 1);
                                    }
                                    catch { }
                                }
                                Reset();
                            }
                            else if (PlayerIsExists == 0 && BtnStartEnd.Text == "Raid End")
                            {
                                if (CommonCls.EventTypeId == 24 || CommonCls.EventTypeId == 25 || CommonCls.EventTypeId == 23)
                                    CommonCls.DTListOutPlayer.Rows.Add(CommonCls.MatchId, CommonCls.HalfID, CommonCls.RaidNo, CommonCls.EventID, drview["PlayerID"], "0", "0", "0", CommonCls.EventTypeId, "0");
                                else
                                    CommonCls.DTListOutPlayer.Rows.Add(CommonCls.MatchId, CommonCls.HalfID, CommonCls.RaidNo, CommonCls.EventID, drview["PlayerID"], "1", "0", "0", CommonCls.EventTypeId, "0");
                            }
                            PlayerIsExists = 0;
                        }
                        #endregion
                    }
                    else
                    {
                        #region Raider Team
                        //foreach (DataRowView drview in lbLineOutRaider.SelectedItems)
                        //{
                        //    for (int j = 0; j < CommonCls.DTListOutPlayer.Rows.Count; j++)
                        //    {
                        //        if (drview["PlayerID"].ToString() == CommonCls.DTListOutPlayer.Rows[j][4].ToString())
                        //        {
                        //            PlayerIsExists = 1;
                        //        }
                        //    }
                        //    if (PlayerIsExists == 0)
                        //        CommonCls.DTListOutPlayer.Rows.Add(CommonCls.MatchId, CommonCls.HalfID, CommonCls.RaidNo, CommonCls.EventID, drview["PlayerID"], "0", "1", "0", CommonCls.EventTypeId);
                        //    PlayerIsExists = 0;
                        //}
                        if ((CommonCls.EventTypeId == 23 || CommonCls.EventTypeId == 24 || CommonCls.EventTypeId == 25) && BtnStartEnd.Text == "Raid Start" && Convert.ToInt32(lbLineOutRaider.SelectedValue) == CommonCls.RaiderID)
                        {
                            //  objDL.ExeQueryRetBooDL("Update Raid Set RaiderOutType=" + CommonCls.EventTypeId + " Where MatchID=" + CommonCls.MatchId + " And RaidNo=" + (CommonCls.RaidNo) + "", 1);
                            objDL.ExeQueryRetBooDL("Update Raid Set RaiderCard=" + CommonCls.EventTypeId + " Where MatchID=" + CommonCls.MatchId + " And RaidNo=" + (CommonCls.RaidNo) + "", 1);

                            if (CommonCls.EventTypeId == 24 || CommonCls.EventTypeId == 25)
                            {
                                int iskill = 0;
                                if (CommonCls.EventTypeId == 25)
                                    iskill = 1;
                                objDL.ExeQueryRetBooDL("Insert Into SuspendedPlayer(MatchID,HalfID,RaidNo,PlayerId,Clubid,Issuspend,iskill) Values (" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + CommonCls.RaidNo + "," + lbLineOutRaider.SelectedValue + "," + CommonCls.RaidClubId + ",1," + iskill + ")", 1);
                                try
                                {
                                    int cnt = objDL.ExeQueryStrDL("Select ISNULL(Count(Raidno),0)+1 From tblCorrectedRaid where Matchid=" + CommonCls.MatchId + " And HalfID=" + CommonCls.HalfID + " AND RaidNo=" + CommonCls.RaidNo + "", 1);
                                    objDL.ExeQueryRetBooDL("Insert into tblCorrectedRaid (Matchid,HalfID,Raidno,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + CommonCls.RaidNo + "," + cnt + ",'Raid','" + System.DateTime.Now + "',0,1,0)", 1);
                                }
                                catch { }
                            }
                            Reset();
                        }
                        else if ((CommonCls.EventTypeId == 23 || CommonCls.EventTypeId == 24 || CommonCls.EventTypeId == 25) && BtnStartEnd.Text == "Raid Start" && Convert.ToInt32(lbLineOutRaider.SelectedValue) != CommonCls.RaiderID)
                        {
                            int Clubid = objDL.ExeQueryStrDL("Select ClubID from Lineups Where MatchID=" + CommonCls.MatchId + " And PlayerID=" + lbLineOutRaider.SelectedValue.ToString() + "", 1); // TeamID
                            //objDL.ExeQueryRetBooDL("Insert Into OutPlayerRef(MatchID,HalfID,RaidNo,PlayerId,Clubid,orderNo) Values (" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + (CommonCls.RaidNo) + "," + drview["PlayerID"].ToString() + "," + Clubid + "," + Orderno + ")", 1);
                            int EventID = objDL.ExeQueryStrDL("Select (Isnull(Max(EventID),0)+1) from Events Where MatchID=" + CommonCls.MatchId + " And RaidNo=" + (CommonCls.RaidNo) + "", 1); // TeamID
                            objDL.ExeQueryRetBooDL("Insert Into Events(MatchID,HalfID,RaidNo,EventId,EventType,PX,PY,StartFrame,Initiator,Time) Values (" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + CommonCls.RaidNo + "," + EventID + "," + CommonCls.EventTypeId + "," + CommonCls.PX + "," + CommonCls.PY + ",'" + setEndtime + "',0," + CurTimeinSec + ")", 1);

                            objDL.ExeQueryRetBooDL("Insert Into OutPlayer(MatchID,HalfID,RaidNo,EventId,PlayerId,KeyDefender,SupportedKeyDefender,IsOut,OutType) Values (" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + CommonCls.RaidNo + "," + EventID + "," + lbLineOutRaider.SelectedValue + ",0,0,0," + CommonCls.EventTypeId + ")", 1);

                            if (CommonCls.EventTypeId == 24 || CommonCls.EventTypeId == 25)
                            {
                                int iskill = 0;
                                if (CommonCls.EventTypeId == 25)
                                    iskill = 1;
                                // Clubid = obj.ExeQueryStrDL("Select ClubID from Lineups Where MatchID=" + CommonCls.MatchId + " And PlayerID=" + drview["PlayerId"] + "", 1); // TeamID

                                objDL.ExeQueryRetBooDL("Insert Into SuspendedPlayer(MatchID,HalfID,RaidNo,PlayerId,Clubid,Issuspend,iskill) Values (" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + CommonCls.RaidNo + "," + lbLineOutRaider.SelectedValue + "," + Clubid + ",1," + iskill + ")", 1);
                            }
                            try
                            {
                                int cnt = objDL.ExeQueryStrDL("Select ISNULL(Count(Raidno),0)+1 From tblCorrectedRaid where Matchid=" + CommonCls.MatchId + " And HalfID=" + CommonCls.HalfID + " AND RaidNo=" + CommonCls.RaidNo + "", 1);
                                objDL.ExeQueryRetBooDL("Insert into tblCorrectedRaid (Matchid,HalfID,Raidno,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + CommonCls.RaidNo + "," + cnt + ",'Raid','" + System.DateTime.Now + "',0,1,0)", 1);
                            }
                            catch { }
                            Reset();
                        }
                        else if ((CommonCls.EventTypeId == 23 || CommonCls.EventTypeId == 24 || CommonCls.EventTypeId == 25) && Convert.ToInt32(lbLineOutRaider.SelectedValue) == CommonCls.RaiderID && BtnStartEnd.Text != "Raid Start")
                        {
                            CommonCls.RaiderCard = CommonCls.EventTypeId;
                            CommonCls.RaiderOutType = 0;
                        }
                        else if ((CommonCls.EventTypeId == 23 || CommonCls.EventTypeId == 24 || CommonCls.EventTypeId == 25) && Convert.ToInt32(lbLineOutRaider.SelectedValue) != CommonCls.RaiderID && BtnStartEnd.Text != "Raid Start")
                        {
                            CommonCls.RaiderCard = CommonCls.EventTypeId;
                            CommonCls.RaiderOutType = 0;
                            CommonCls.DTListOutPlayer.Rows.Add(CommonCls.MatchId, CommonCls.HalfID, CommonCls.RaidNo, CommonCls.EventID, lbLineOutRaider.SelectedValue, "1", "0", "0", CommonCls.EventTypeId, "0");
                        }
                        else if ((CommonCls.EventTypeId == 18) && BtnStartEnd.Text == "Raid Start")
                        {
                            string outplayid = "0";
                            if (lbLineOutRaider.SelectedIndex != -1)
                                outplayid = lbLineOutRaider.SelectedValue.ToString();
                            else if (lbLineOutDefender.SelectedIndex != -1)
                                outplayid = lbLineOutDefender.SelectedValue.ToString();

                            int Clubid = objDL.ExeQueryStrDL("Select ClubID from Lineups Where MatchID=" + CommonCls.MatchId + " And PlayerID=" + outplayid + "", 1); // TeamID
                            //objDL.ExeQueryRetBooDL("Insert Into OutPlayerRef(MatchID,HalfID,RaidNo,PlayerId,Clubid,orderNo) Values (" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + (CommonCls.RaidNo) + "," + drview["PlayerID"].ToString() + "," + Clubid + "," + Orderno + ")", 1);
                            int EventID = objDL.ExeQueryStrDL("Select (ISNULL(Max(EventID),0)+1) from Events Where MatchID=" + CommonCls.MatchId + " And RaidNo=" + (CommonCls.RaidNo) + "", 1); // TeamID
                            objDL.ExeQueryRetBooDL("Insert Into Events(MatchID,HalfID,RaidNo,EventId,EventType,PX,PY,StartFrame,Initiator,Time) Values (" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + CommonCls.RaidNo + "," + EventID + "," + CommonCls.EventTypeId + "," + CommonCls.PX + "," + CommonCls.PY + ",'" + setEndtime + "',0," + CurTimeinSec + ")", 1);
                            int Rank = 1 + objDL.ExeQueryStrDL("Select top 1 ROW_NUMBER() OVER(ORDER BY raidno,orderno) Rank from OutPlayerRef Where Matchid=" + CommonCls.MatchId + " And RaidNo=" + (CommonCls.RaidNo - 1) + " And PlayerID Not IN(Select PlayerID from Innerplayer Where Matchid=" + CommonCls.MatchId + " AND RaidNo=" + (CommonCls.RaidNo - 1) + ") order by Rank desc", 1);

                            objDL.ExeQueryRetBooDL("Insert Into OutPlayerRef(MatchID,HalfID,RaidNo,PlayerId,Clubid,OrderNo) Values (" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + CommonCls.RaidNo + "," + outplayid + "," + Clubid + "," + Rank + ")", 1);
                            objDL.ExeQueryRetBooDL("Insert Into OutPlayer(MatchID,HalfID,RaidNo,EventId,PlayerId,KeyDefender,SupportedKeyDefender,IsOut,OutType) Values (" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + CommonCls.RaidNo + "," + EventID + "," + outplayid + ",0,0,1," + CommonCls.EventTypeId + ")", 1);
                            try
                            {
                                int cnt = objDL.ExeQueryStrDL("Select ISNULL(Count(Raidno),0)+1 From tblCorrectedRaid where Matchid=" + CommonCls.MatchId + " And HalfID=" + CommonCls.HalfID + " AND RaidNo=" + CommonCls.RaidNo + "", 1);
                                objDL.ExeQueryRetBooDL("Insert into tblCorrectedRaid (Matchid,HalfID,Raidno,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + CommonCls.RaidNo + "," + cnt + ",'Raid','" + System.DateTime.Now + "',0,1,0)", 1);
                            }
                            catch { }

                            Reset();
                        }

                        else
                        {
                            if (lbLineOutRaider.SelectedIndex != -1)
                            {
                                if (CommonCls.RaiderID == Convert.ToInt32(lbLineOutRaider.SelectedValue))
                                { CommonCls.RaiderOutType = CommonCls.EventTypeId; }
                                else
                                {
                                    foreach (DataRowView drview in lbLineOutRaider.SelectedItems)
                                    {
                                        for (int j = 0; j < CommonCls.DTListOutPlayer.Rows.Count; j++)
                                        {
                                            //if (drview["PlayerID"].ToString() == CommonCls.DTListOutPlayer.Rows[j][4].ToString())
                                            //{
                                            //    PlayerIsExists = 1;
                                            //}
                                        }
                                        if (PlayerIsExists == 0)
                                            CommonCls.DTListOutPlayer.Rows.Add(CommonCls.MatchId, CommonCls.HalfID, CommonCls.RaidNo, CommonCls.EventID, drview["PlayerID"], "0", "0", "0", CommonCls.EventTypeId, "0");
                                        PlayerIsExists = 0;
                                    }
                                }
                            }
                            else if (lbLineOutDefender.SelectedIndex != -1)
                            {
                                foreach (DataRowView drview in lbLineOutDefender.SelectedItems)
                                {
                                    for (int j = 0; j < CommonCls.DTListOutPlayer.Rows.Count; j++)
                                    {
                                        //if (drview["PlayerID"].ToString() == CommonCls.DTListOutPlayer.Rows[j][4].ToString())
                                        //{
                                        //    PlayerIsExists = 1;
                                        //}
                                    }
                                    if (PlayerIsExists == 0)
                                        CommonCls.DTListOutPlayer.Rows.Add(CommonCls.MatchId, CommonCls.HalfID, CommonCls.RaidNo, CommonCls.EventID, drview["PlayerID"], "0", "0", "0", CommonCls.EventTypeId, "0");
                                    PlayerIsExists = 0;
                                }
                            }

                            ReSetBeforeEvent();
                            pnlLineOut.Hide();
                        }
                        #endregion
                    }
                }
                ReSetBeforeEvent();
                pnlLineOut.Hide();
                string Player = "";
                try
                {
                    dgvOutplayerlist.Rows.Clear();
                }
                catch { }
                foreach (DataRow drEvnt in CommonCls.DTListEvents.Rows)
                {
                    Player = "";
                    foreach (DataRow drOutply in CommonCls.DTListOutPlayer.Rows)
                    {
                        if (drEvnt["EventID"].ToString() == drOutply["EventID"].ToString())
                        {
                            Player = Player + "," + objDL.ExeQueryStrRetStrDL("select dbo.fn_getPlayerName(" + drOutply["PlayerID"] + ")", 1);
                        }
                    }
                    dgvOutplayerlist.Rows.Add(CommonCls.RaidNo, drEvnt["EventID"].ToString(), GetEventName(drEvnt["EventType"].ToString()), Player.Trim(','));

                    pnlOutplayerlist.Visible = true;
                    pnlOutplayerlist.BringToFront();
                }
            }
            catch { }
        }


        private void lbLineOutRaider_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lbLineOutRaider.SelectedItems.Count > 0)
                    lbLineOutDefender.SelectedIndex = -1;
                if (lbLineOutRaider.SelectedItems.Count > 0 && CommonCls.RaiderID == Convert.ToInt32(lbLineOutRaider.SelectedValue))
                    CommonCls.RaiderOutType = CommonCls.EventTypeId;
                else
                    CommonCls.RaiderOutType = 0;
            }
            catch { }
        }

        private void lbLineOutDefender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbLineOutDefender.SelectedItems.Count > 0)
                lbLineOutRaider.SelectedIndex = -1;
        }

        private void btnDefender_Click(object sender, EventArgs e)
        {
            try
            {
                int PlayerIsExists = 0;
                setEndtime = 0;
                int Initiator = 0;
                try
                {
                    Initiator = Convert.ToInt32(lbInitiator.SelectedValue);
                }
                catch { }
                try
                {
                    CurTimeinSec = TimeSpan.Parse("00:" + dtp_MatchClock.Value.Minute.ToString("D2") + ":" + dtp_MatchClock.Value.Second.ToString("D2")).TotalSeconds;
                }
                catch { CurTimeinSec = 0; }
                CommonCls.DTListEvents.Rows.Add(CommonCls.MatchId, CommonCls.HalfID, CommonCls.RaidNo, CommonCls.EventID, CommonCls.EventTypeId, CommonCls.PX, CommonCls.PY, setEndtime, Initiator, CurTimeinSec);

                foreach (DataRowView drview in lbInitiator.SelectedItems)
                {
                    //MessageBox.Show(lbKeyDefender.SelectedIndices[i].ToString());
                    for (int j = 0; j < CommonCls.DTListOutPlayer.Rows.Count; j++)
                    {
                        //if (drview["PlayerID"].ToString() == CommonCls.DTListOutPlayer.Rows[j][4].ToString())
                        //{
                        //    PlayerIsExists = 1;
                        //}
                    }
                    if (PlayerIsExists == 0)
                        CommonCls.DTListOutPlayer.Rows.Add(CommonCls.MatchId, CommonCls.HalfID, CommonCls.RaidNo, CommonCls.EventID, drview["PlayerID"], "1", "0", "0", CommonCls.EventTypeId, "1");
                    PlayerIsExists = 0;
                }
                foreach (DataRowView drview in lbKeyDefender.SelectedItems)
                {
                    //MessageBox.Show(lbKeyDefender.SelectedIndices[i].ToString());
                    for (int j = 0; j < CommonCls.DTListOutPlayer.Rows.Count; j++)
                    {
                        if (drview["PlayerID"].ToString() == CommonCls.DTListOutPlayer.Rows[j][4].ToString())
                        {
                            //PlayerIsExists = 1;
                            //CommonCls.DTListOutPlayer.Rows[j][5] = "1";
                        }
                    }
                    if (PlayerIsExists == 0)
                        CommonCls.DTListOutPlayer.Rows.Add(CommonCls.MatchId, CommonCls.HalfID, CommonCls.RaidNo, CommonCls.EventID, drview["PlayerID"], "1", "0", "0", CommonCls.EventTypeId, "0");
                    PlayerIsExists = 0;
                }

                foreach (DataRowView drview in lbSupportedDefender.SelectedItems)
                {
                    for (int j = 0; j < CommonCls.DTListOutPlayer.Rows.Count; j++)
                    {
                        if (drview["PlayerID"].ToString() == CommonCls.DTListOutPlayer.Rows[j][4].ToString())
                        {
                            //PlayerIsExists = 1;
                            //CommonCls.DTListOutPlayer.Rows[j][6] = "1";
                        }
                    }
                    if (PlayerIsExists == 0)
                        CommonCls.DTListOutPlayer.Rows.Add(CommonCls.MatchId, CommonCls.HalfID, CommonCls.RaidNo, CommonCls.EventID, drview["PlayerID"], "0", "1", "0", CommonCls.EventTypeId, "0");
                    PlayerIsExists = 0;
                }

                pnlKeyDefender.Hide();
                ReSetBeforeEvent();
                string Player = "";
                try
                {
                    dgvOutplayerlist.Rows.Clear();
                }
                catch { }
                foreach (DataRow drEvnt in CommonCls.DTListEvents.Rows)
                {
                    Player = "";
                    foreach (DataRow drOutply in CommonCls.DTListOutPlayer.Rows)
                    {
                        if (drEvnt["EventID"].ToString() == drOutply["EventID"].ToString())
                        {
                            Player = Player + "," + objDL.ExeQueryStrRetStrDL("select dbo.fn_getPlayerName(" + drOutply["PlayerID"] + ")", 1);
                        }
                    }
                    dgvOutplayerlist.Rows.Add(CommonCls.RaidNo, drEvnt["EventID"].ToString(), GetEventName(drEvnt["EventID"].ToString()), Player.Trim(','));
                }
                pnlOutplayerlist.Visible = true;
                pnlOutplayerlist.BringToFront();
            }
            catch { }
        }
        string GetEventName(string EID)
        {
            string EvntName = "";
            EvntName = objDL.ExeQueryStrRetStrDL("Select dbo.fn_getEventName(" + EID + ")", 1);
            return EvntName;
        }


        private void btnRaiderSubmit_Click(object sender, EventArgs e)
        {
            RaiderSubmitClick();
        }

        void RaiderSubmitClick()
        {
            try
            {
                if (lbRaider.SelectedIndex == -1) { MessageBox.Show("Select any one Raider", "Kabaddi", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                CommonCls.RaiderID = Convert.ToInt32(lbRaider.SelectedValue);
                pnlRaider.Hide();

                pnlEvents.Enabled = true;
                pnlSpecialCase.Enabled = true;
                try
                {
                    MasterDL obj = new MasterDL();
                    obj.ExeQueryRetBooDL("Insert Into Raid(MatchID,HalfID,RaidNo,RaiderId,StartTime,StartFrame,RaidDIP,DefDIP,Time) Values (" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + CommonCls.RaidNo + "," + CommonCls.RaiderID + ",'" + CommonCls.StartTime.ToString("yyyy-MM-dd HH:mm:ss") + "','" + RaidStarttime + "'," + lblRaidDIP.Text + "," + lblDefDIP.Text + "," + CurTimeinSec + ")", 1);
                }
                catch { }
                try
                {
                    MasterDL obj = new MasterDL();
                    int cnt = obj.ExeQueryStrDL("Select ISNULL(Count(Raidno),0)+1 From tblCorrectedRaid where Matchid=" + CommonCls.MatchId + " And HalfID=" + CommonCls.HalfID + " AND RaidNo=" + CommonCls.RaidNo + "", 1);
                    obj.ExeQueryRetBooDL("Insert into tblCorrectedRaid (Matchid,HalfID,Raidno,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + CommonCls.RaidNo + "," + cnt + ",'Raid_Start','" + System.DateTime.Now + "',1,0,0)", 1);
                }
                catch { }
                raiderchose = true;
                //var dsd = cbRaider.DataSource;
                cbRaider.SelectedValue = CommonCls.RaiderID;

                //XMLPush(0,"START");
                retriveVizSend();
            }
            catch { }
        }

        private void pbLineoutClose_Click(object sender, EventArgs e)
        {
            pnlLineOut.Hide();
        }
        Decimal BonusFrame = 0;
        bool bonuscheck = false;
        private void chkBonusPoint_CheckedChanged(object sender, EventArgs e)
        {
            if (!PageLoad) { return; }
            if (CommonCls.PX == 0 && CommonCls.PY == 0)
            {
                //  pnlPitchMapMsg.Show();
                //  pnlPitchMapMsg.BringToFront();
                //chkBonusPoint.Checked = false; return;
            }
            if (chkBonusPoint.Checked == true)
            {
                CommonCls.BLPX = CommonCls.PX;
                CommonCls.BLPY = CommonCls.PY;
            }
            TouchClick = false;
            TackleClick = false;
            bonuscheck = true;
        }

        private void btnDefenderSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    CurTimeinSec = TimeSpan.Parse("00:" + dtp_MatchClock.Value.Minute.ToString("D2") + ":" + dtp_MatchClock.Value.Second.ToString("D2")).TotalSeconds;
                }
                catch { CurTimeinSec = 0; }
                int PlayerIsExists = 0;
                setEndtime = 0;
                if (CommonCls.EventTypeId == 37 || CommonCls.EventTypeId == 41 || CommonCls.EventTypeId == 42)
                {
                    int Subid = objDL.ExeQueryStrDL("Select MAX(ISNULL(SubId,0))+1 from RaidSubjects Where MatchID=" + CommonCls.MatchId + " And RaidNo=" + CommonCls.RaidNo + "", 1);
                    objDL.ExeQueryRetBooDL("Insert Into RaidSubjects(Matchid,HalfID,RaidNo,SubId,EventtypeId,PlayerId,StanceTime,StartFrame) Values (" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + CommonCls.RaidNo + "," + Subid + "," + CommonCls.EventTypeId + "," + lbDefender.SelectedValue + "," + 0 + "," + setEndtime + ")", 1);
                }
                else
                {
                    setEndtime = 0;
                    CommonCls.DTListEvents.Rows.Add(CommonCls.MatchId, CommonCls.HalfID, CommonCls.RaidNo, CommonCls.EventID, CommonCls.EventTypeId, CommonCls.PX, CommonCls.PY, setEndtime, 0, CurTimeinSec);

                    foreach (DataRowView drview in lbDefender.SelectedItems)
                    {
                        for (int j = 0; j < CommonCls.DTListOutPlayer.Rows.Count; j++)
                        {
                            if (drview["PlayerID"].ToString() == CommonCls.DTListOutPlayer.Rows[j][4].ToString())
                            {
                                //PlayerIsExists = 1;
                            }
                        }
                        if (PlayerIsExists == 0)
                            CommonCls.DTListOutPlayer.Rows.Add(CommonCls.MatchId, CommonCls.HalfID, CommonCls.RaidNo, CommonCls.EventID, drview["PlayerID"], "0", "0", "0", CommonCls.EventTypeId, "0");
                        PlayerIsExists = 0;
                    }
                }
                pnlDefender.Hide();
                ReSetBeforeEvent();
                string Player = "";
                try
                {
                    dgvOutplayerlist.Rows.Clear();
                }
                catch { }
                foreach (DataRow drEvnt in CommonCls.DTListEvents.Rows)
                {
                    Player = "";
                    foreach (DataRow drOutply in CommonCls.DTListOutPlayer.Rows)
                    {
                        if (drEvnt["EventID"].ToString() == drOutply["EventID"].ToString())
                        {
                            Player = Player + "," + objDL.ExeQueryStrRetStrDL("select dbo.fn_getPlayerName(" + drOutply["PlayerID"] + ")", 1);
                        }
                    }
                    dgvOutplayerlist.Rows.Add(CommonCls.RaidNo, drEvnt["EventID"].ToString(), GetEventName(drEvnt["Eventtype"].ToString()), Player.Trim(','));
                }
                pnlOutplayerlist.Visible = true;
                pnlOutplayerlist.BringToFront();
            }
            catch { }
        }

        private void pbDefender1Close_Click(object sender, EventArgs e)
        {
            pnlDefender.Hide();
        }

        private void pbAOutPlayerSwap_Click(object sender, EventArgs e)
        {
            if (chkRemove.Checked)
                MoveINtoOUTPlayer(1);
            else
                MoveOUTtoINPlayer(1);
        }

        void MoveOUTtoINPlayer(int TeamFlag)
        {
            if (TeamFlag == 1)
            {
                if (BtnStartEnd.Text == "Raid End") { return; }

                try
                {
                    DIPError = new DataTable();
                    DIPError = objDL.ExeQueryStrRetDTDL("SP_GetDIPError " + CommonCls.MatchId + "," + CommonCls.RaidNo + "", 1);
                    if (DIPError.Rows[0]["ERROR"].ToString() == "1" && CommonCls.RaidNo != 0)
                    {
                        if (Convert.ToInt32(DIPError.Rows[0]["ERRORTEam"].ToString()) != CommonCls.ClubId1)
                        {

                            if (MessageBox.Show("your selected Inplayer is WRONG TEAM, Correct Team : " + (Convert.ToInt32(DIPError.Rows[0]["ERRORTEam"].ToString()) == CommonCls.ClubId1 ? CommonCls.Club1Prefix : CommonCls.Club2Prefix) + " You want continue", "Hockey Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                            { return; }
                        }

                        //MessageBox.Show("Inplayer not given last raid", "Kabaddi Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //return;
                    }
                }
                catch { }
                try
                {
                    if (lbTeamAOutList.SelectedIndex == -1 && chkAllplayer.Checked == false) { MessageBox.Show("Select Who's Come INPlayer", "Kabaddi", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                    MasterDL obj = new MasterDL();
                    int MaxRaidno = Convert.ToInt32(obj.ExeQueryStrRetStrDL("select ISNULL(MAX(RaidNo),0) from Raid where Matchid=" + CommonCls.MatchId + " And HalfID=" + CommonCls.HalfID + "", 1));
                    if (MaxRaidno == 0) MaxRaidno = Convert.ToInt32(obj.ExeQueryStrRetStrDL("select ISNULL(MAX(RaidNo),0) from Raid where Matchid=" + CommonCls.MatchId + " And HalfID=" + (CommonCls.HalfID - 1) + "", 1));
                    int playerId = Convert.ToInt32(lbTeamAOutList.SelectedValue);
                    if (chkSwap.Checked == true && chkAllplayer.Checked == false)
                    {
                        if (lbTeamAINList.SelectedIndex == -1) { MessageBox.Show("Select Who's Come INPlayer", "Kabaddi", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                        if (MessageBox.Show("Do you want Continue to swap these player", "Hockey Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                            return;
                        int Inplayer = Convert.ToInt32(lbTeamAINList.SelectedValue);
                        obj.ExeQueryRetBooDL("Update Outplayerref Set PlayerId=" + Inplayer + " Where Matchid=" + CommonCls.MatchId + " AND RaidNo=" + MaxRaidno + " And PlayerID=" + playerId + "", 1);
                        obj.ExeQueryRetBooDL("Insert Into SwapPlayer(Matchid,RaidNo,CurOutplayerId,CurInPlayerID) Values(" + CommonCls.MatchId + "," + MaxRaidno + "," + Inplayer + "," + playerId + ")", 1);
                        //MaxRaidno = Convert.ToInt32(obj.ExeQueryStrRetStrDL("select ISNULL(MAX(RaidNo),0) from Innerplayer where Matchid=" + CommonCls.MatchId + " And PlayerID=" + Inplayer + "", 1));
                        obj.ExeQueryRetBooDL("delete from Innerplayer where Matchid=" + CommonCls.MatchId + " And RaidNo=" + MaxRaidno + " AND playerId=" + Inplayer + "", 1);

                        obj.ExeQueryRetBooDL("Insert Into Innerplayer(Matchid,HalfID,RaidNo,playerId,ClubID) Values(" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + MaxRaidno + "," + playerId + "," + CommonCls.ClubId1 + ")", 1);

                        try
                        {
                            int cnt = obj.ExeQueryStrDL("Select ISNULL(Count(Raidno),0)+1 From tblCorrectedRaid where Matchid=" + CommonCls.MatchId + " And HalfID=" + CommonCls.HalfID + " AND RaidNo=" + MaxRaidno + "", 1);
                            obj.ExeQueryRetBooDL("Insert into tblCorrectedRaid (Matchid,HalfID,Raidno,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + MaxRaidno + "," + cnt + ",'SwapPlayer','" + System.DateTime.Now + "',1,0,0)", 1);
                        }
                        catch { }
                    }
                    else if (chkAllplayer.Checked == true)
                    {
                        for (int i = 0; i < lbTeamAOutList.Items.Count; i++)
                        {
                            lbTeamAOutList.SelectedIndex = i;
                            playerId = Convert.ToInt32(lbTeamAOutList.SelectedValue);
                            obj.ExeQueryRetBooDL("Insert Into Innerplayer(Matchid,HalfID,RaidNo,playerId,ClubID) Values(" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + MaxRaidno + "," + playerId + "," + CommonCls.ClubId1 + ")", 1);
                        }
                        try
                        {
                            int cnt = obj.ExeQueryStrDL("Select ISNULL(Count(Raidno),0)+1 From tblCorrectedRaid where Matchid=" + CommonCls.MatchId + " And HalfID=" + CommonCls.HalfID + " AND RaidNo=" + MaxRaidno + "", 1);
                            obj.ExeQueryRetBooDL("Insert into tblCorrectedRaid (Matchid,HalfID,Raidno,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + MaxRaidno + "," + cnt + ",'Innerplayer','" + System.DateTime.Now + "',1,0,0)", 1);
                        }
                        catch { }
                    }
                    else
                    {
                        if (MessageBox.Show("Do you want Continue to add this player", "Hockey Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                            return;
                        obj.ExeQueryRetBooDL("Insert Into Innerplayer(Matchid,HalfID,RaidNo,PlayerId,ClubID) Values(" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + MaxRaidno + "," + playerId + "," + CommonCls.ClubId1 + ")", 1);
                        try
                        {
                            int cnt = obj.ExeQueryStrDL("Select ISNULL(Count(Raidno),0)+1 From tblCorrectedRaid where Matchid=" + CommonCls.MatchId + " And HalfID=" + CommonCls.HalfID + " AND RaidNo=" + MaxRaidno + "", 1);
                            obj.ExeQueryRetBooDL("Insert into tblCorrectedRaid (Matchid,HalfID,Raidno,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + MaxRaidno + "," + cnt + ",'Innerplayer','" + System.DateTime.Now + "',1,0,0)", 1);
                        }
                        catch { }
                    }
                    //LoadPlayer();
                    Reset();
                    BindDIP();
                    XMLPush(1, "END");
                    retriveVizSend();
                }
                catch { }
            }
            else if (TeamFlag == 2)
            {
                if (BtnStartEnd.Text == "Raid End") { MessageBox.Show(""); return; }
                try
                {
                    try
                    {
                        DIPError = new DataTable();
                        DIPError = objDL.ExeQueryStrRetDTDL("SP_GetDIPError " + CommonCls.MatchId + "," + CommonCls.RaidNo + "", 1);
                        if (DIPError.Rows[0]["ERROR"].ToString() == "1" && CommonCls.RaidNo != 0)
                        {
                            if (Convert.ToInt32(DIPError.Rows[0]["ERRORTEam"].ToString()) != CommonCls.ClubId2)
                            {
                                if (MessageBox.Show("your selected Inplayer wrong team You want continue", "Hockey Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                                { return; }
                            }

                            //MessageBox.Show("Inplayer not given last raid", "Kabaddi Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //return;
                        }
                    }
                    catch { }
                    if (lbTeamBOutList.SelectedIndex == -1 && chkAllplayer.Checked == false) { MessageBox.Show("Select Who's Come INPlayer", "Kabaddi", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                    MasterDL obj = new MasterDL();
                    int MaxRaidno = Convert.ToInt32(obj.ExeQueryStrRetStrDL("select ISNULL(MAX(RaidNo),0) from Raid where Matchid=" + CommonCls.MatchId + " And HalfID=" + CommonCls.HalfID + "", 1));
                    if (MaxRaidno == 0) MaxRaidno = Convert.ToInt32(obj.ExeQueryStrRetStrDL("select ISNULL(MAX(RaidNo),0) from Raid where Matchid=" + CommonCls.MatchId + " And HalfID=" + (CommonCls.HalfID - 1) + "", 1));
                    int playerId = Convert.ToInt32(lbTeamBOutList.SelectedValue);
                    if (chkSwap.Checked == true && chkAllplayer.Checked == false)
                    {
                        if (lbTeamBINList.SelectedIndex == -1) { MessageBox.Show("Select Who's Come INPlayer", "Kabaddi", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                        if (MessageBox.Show("Do you want Continue to swap these player", "Hockey Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                            return;
                        int Inplayer = Convert.ToInt32(lbTeamBINList.SelectedValue);
                        // obj.ExeQueryRetBooDL("Update Innerplayer Set PlayerId=" + playerId + " Where Matchid=" + CommonCls.MatchId + " AND RaidNo=" + MaxRaidno + " And PlayerID=" + Inplayer + "", 1);
                        obj.ExeQueryRetBooDL("Update Outplayerref Set PlayerId=" + Inplayer + " Where Matchid=" + CommonCls.MatchId + " AND RaidNo=" + MaxRaidno + " And PlayerID=" + playerId + "", 1);
                        obj.ExeQueryRetBooDL("Insert Into SwapPlayer(Matchid,RaidNo,CurOutplayerId,CurInPlayerID) Values(" + CommonCls.MatchId + "," + MaxRaidno + "," + Inplayer + "," + playerId + ")", 1);
                        obj.ExeQueryRetBooDL("delete from Innerplayer where Matchid=" + CommonCls.MatchId + " And RaidNo=" + MaxRaidno + " AND playerId=" + Inplayer + "", 1);

                        obj.ExeQueryRetBooDL("Insert Into Innerplayer(Matchid,HalfID,RaidNo,playerId,ClubID) Values(" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + MaxRaidno + "," + playerId + "," + CommonCls.ClubId2 + ")", 1);


                        try
                        {
                            int cnt = obj.ExeQueryStrDL("Select ISNULL(Count(Raidno),0)+1 From tblCorrectedRaid where Matchid=" + CommonCls.MatchId + " And HalfID=" + CommonCls.HalfID + " AND RaidNo=" + MaxRaidno + "", 1);
                            obj.ExeQueryRetBooDL("Insert into tblCorrectedRaid (Matchid,HalfID,Raidno,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + MaxRaidno + "," + cnt + ",'SwapPlayer','" + System.DateTime.Now + "',1,0,0)", 1);
                        }
                        catch { }
                    }
                    else if (chkAllplayer.Checked == true)
                    {
                        for (int i = 0; i < lbTeamBOutList.Items.Count; i++)
                        {
                            lbTeamBOutList.SelectedIndex = i;
                            playerId = Convert.ToInt32(lbTeamBOutList.SelectedValue);
                            obj.ExeQueryRetBooDL("Insert Into Innerplayer(Matchid,HalfID,RaidNo,playerId,ClubID) Values(" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + MaxRaidno + "," + playerId + "," + CommonCls.ClubId2 + ")", 1);
                        }
                        try
                        {
                            int cnt = obj.ExeQueryStrDL("Select ISNULL(Count(Raidno),0)+1 From tblCorrectedRaid where Matchid=" + CommonCls.MatchId + " And HalfID=" + CommonCls.HalfID + " AND RaidNo=" + MaxRaidno + "", 1);
                            obj.ExeQueryRetBooDL("Insert into tblCorrectedRaid (Matchid,HalfID,Raidno,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + MaxRaidno + "," + cnt + ",'Innerplayer','" + System.DateTime.Now + "',1,0,0)", 1);
                        }
                        catch { }
                    }
                    else
                    {
                        if (MessageBox.Show("Do you want Continue to add this player", "Hockey Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                            return;
                        obj.ExeQueryRetBooDL("Insert Into Innerplayer(Matchid,HalfID,RaidNo,PlayerId,ClubID) Values(" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + MaxRaidno + "," + playerId + "," + CommonCls.ClubId2 + ")", 1);
                        try
                        {
                            int cnt = obj.ExeQueryStrDL("Select ISNULL(Count(Raidno),0)+1 From tblCorrectedRaid where Matchid=" + CommonCls.MatchId + " And HalfID=" + CommonCls.HalfID + " AND RaidNo=" + MaxRaidno + "", 1);
                            obj.ExeQueryRetBooDL("Insert into tblCorrectedRaid (Matchid,HalfID,Raidno,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + MaxRaidno + "," + cnt + ",'Innerplayer','" + System.DateTime.Now + "',1,0,0)", 1);
                        }
                        catch { }
                    }

                    //LoadPlayer();
                    Reset();
                    BindDIP();
                    XMLPush(1, "END");
                    retriveVizSend();
                }
                catch { }
            }

        }


        void MoveINtoOUTPlayer(int TeamFlag)
        {
            if (BtnStartEnd.Text == "Raid End") { return; }
            if (TeamFlag == 1)
            {
                try
                {
                    if (lbTeamAINList.SelectedIndex == -1) { MessageBox.Show("Select Who's Come INPlayer", "Kabaddi", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                    MasterDL obj = new MasterDL();
                    int MaxRaidno = Convert.ToInt32(obj.ExeQueryStrRetStrDL("select ISNULL(MAX(RaidNo),0) from Raid where Matchid=" + CommonCls.MatchId + " And HalfID=" + CommonCls.HalfID + "", 1));
                    if (MaxRaidno == 0) MaxRaidno = Convert.ToInt32(obj.ExeQueryStrRetStrDL("select ISNULL(MAX(RaidNo),0) from Raid where Matchid=" + CommonCls.MatchId + " And HalfID=" + (CommonCls.HalfID - 1) + "", 1));
                    int playerId = Convert.ToInt32(lbTeamAINList.SelectedValue);
                    int orderNo = obj.ExeQueryStrDL("Select ISNULL(Max(Orderno),0)+1  from OutPlayerRef Where Matchid=" + CommonCls.MatchId + " And RaidNo=" + (MaxRaidno) + "", 1);

                    obj.ExeQueryRetBooDL("Insert Into OutPlayerRef(MatchID,HalfID,RaidNo,PlayerId,Clubid,orderNo) Values (" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + MaxRaidno + "," + playerId + "," + CommonCls.ClubId1 + "," + orderNo + ")", 1);
                    obj.ExeQueryRetBooDL("Delete from Innerplayer Where MatchId=" + CommonCls.MatchId + " And HalfID=" + CommonCls.HalfID + " And RaidNo=" + MaxRaidno + " And PlayerId=" + playerId + "", 1);


                    //LoadPlayer();
                    Reset();
                    BindDIP();
                    XMLPush(1, "END");
                    retriveVizSend();
                }
                catch { }
            }
            else if (TeamFlag == 2)
            {
                try
                {
                    if (lbTeamBINList.SelectedIndex == -1) { MessageBox.Show("Select Who's Come INPlayer", "Kabaddi", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                    MasterDL obj = new MasterDL();
                    int MaxRaidno = Convert.ToInt32(obj.ExeQueryStrRetStrDL("select ISNULL(MAX(RaidNo),0) from Raid where Matchid=" + CommonCls.MatchId + " And HalfID=" + CommonCls.HalfID + "", 1));
                    if (MaxRaidno == 0) MaxRaidno = Convert.ToInt32(obj.ExeQueryStrRetStrDL("select ISNULL(MAX(RaidNo),0) from Raid where Matchid=" + CommonCls.MatchId + " And HalfID=" + (CommonCls.HalfID - 1) + "", 1));
                    int playerId = Convert.ToInt32(lbTeamBINList.SelectedValue);
                    int orderNo = obj.ExeQueryStrDL("Select ISNULL(Max(Orderno),0)+1  from OutPlayerRef Where Matchid=" + CommonCls.MatchId + " And RaidNo=" + (MaxRaidno) + "", 1);

                    obj.ExeQueryRetBooDL("Insert Into OutPlayerRef(MatchID,HalfID,RaidNo,PlayerId,Clubid,orderNo) Values (" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + MaxRaidno + "," + playerId + "," + CommonCls.ClubId2 + "," + orderNo + ")", 1);
                    obj.ExeQueryRetBooDL("Delete from Innerplayer Where MatchId=" + CommonCls.MatchId + " And HalfID=" + CommonCls.HalfID + " And RaidNo=" + MaxRaidno + " And PlayerId=" + playerId + "", 1);

                    //LoadPlayer();
                    Reset();
                    BindDIP();
                    XMLPush(1, "END");
                    retriveVizSend();
                }
                catch { }
            }
        }
        private void pbBOutPlayerSwap_Click(object sender, EventArgs e)
        {
            if (chkRemove.Checked)
                MoveINtoOUTPlayer(2);
            else
                MoveOUTtoINPlayer(2);
        }

        private void pbTeamASubstituteSwap_Click(object sender, EventArgs e)
        {
            SwapPlayer(1);
        }

        void SwapPlayer(int TeamFlag)
        {
            try
            {
                CurTimeinSec = TimeSpan.Parse("00:" + dtp_MatchClock.Value.Minute.ToString("D2") + ":" + dtp_MatchClock.Value.Second.ToString("D2")).TotalSeconds;
            }
            catch { }
            if (TeamFlag == 1)
            {
                try
                {
                    if (lbTeamASubList.SelectedIndex == -1 || lbTeamAINList1.SelectedIndex == -1) { MessageBox.Show("Select In Player & Substitute Player", "Kabaddi", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                    MasterDL obj = new MasterDL();
                    int MaxRaidno = Convert.ToInt32(obj.ExeQueryStrRetStrDL("select ISNULL(MAX(RaidNo),0) from Raid where Matchid=" + CommonCls.MatchId + " And HalfID=" + CommonCls.HalfID + "", 1));
                    int nextRaidNo=MaxRaidno+1;
                    int playerId = Convert.ToInt32(lbTeamAINList1.SelectedValue);
                    int SubplayerId = Convert.ToInt32(lbTeamASubList.SelectedValue);
                    obj.ExeQueryRetBooDL("Insert Into Substitute(Matchid,HalfID,RaidNo,PlayerId,SubPlayerId,Time) Values(" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + MaxRaidno + "," + playerId + "," + SubplayerId + "," + CurTimeinSec + ")", 1);
                    obj.ExeQueryRetBooDL("Update InplayerList SET Playerid=" + SubplayerId + " WHERE Matchid=" + CommonCls.MatchId + " AND RaidNo=" + nextRaidNo + " AND Playerid=" + playerId + "", 1);
                    obj.ExeQueryRetBooDL("Update Lineups Set Issub=1, Islive=0 Where Matchid=" + CommonCls.MatchId + " And PlayerID=" + playerId + "", 1);
                    obj.ExeQueryRetBooDL("Update Lineups Set Issub=0, Islive=1 Where Matchid=" + CommonCls.MatchId + " And PlayerID=" + SubplayerId + "", 1);
                    //LoadPlayer();
                    try
                    {
                        int cnt = obj.ExeQueryStrDL("Select ISNULL(Count(Raidno),0)+1 From tblCorrectedRaid where Matchid=" + CommonCls.MatchId + " And HalfID=" + CommonCls.HalfID + " AND RaidNo=" + MaxRaidno + "", 1);
                        obj.ExeQueryRetBooDL("Insert into tblCorrectedRaid (Matchid,HalfID,Raidno,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + MaxRaidno + "," + cnt + ",'Substitute','" + System.DateTime.Now + "',1,0,0)", 1);
                    }
                    catch { }
                    Reset();
                }
                catch { }
            }
            else if (TeamFlag == 2)
            {
                try
                {
                    if (lbTeamBSubList.SelectedIndex == -1 || lbTeamBINList1.SelectedIndex == -1) { MessageBox.Show("Select In Player & Substitute Player", "Kabaddi", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                    MasterDL obj = new MasterDL();
                    int MaxRaidno = Convert.ToInt32(obj.ExeQueryStrRetStrDL("select ISNULL(MAX(RaidNo),0) from Raid where Matchid=" + CommonCls.MatchId + " And HalfID=" + CommonCls.HalfID + "", 1));
                    int nextRaidNo = MaxRaidno + 1;
                    int playerId = Convert.ToInt32(lbTeamBINList1.SelectedValue);
                    int SubplayerId = Convert.ToInt32(lbTeamBSubList.SelectedValue);
                    obj.ExeQueryRetBooDL("Insert Into Substitute(Matchid,HalfID,RaidNo,PlayerId,SubPlayerId,Time) Values(" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + MaxRaidno + "," + playerId + "," + SubplayerId + "," + CurTimeinSec + ")", 1);
                    obj.ExeQueryRetBooDL("Update InplayerList SET Playerid=" + SubplayerId + " WHERE Matchid=" + CommonCls.MatchId + " AND RaidNo=" + nextRaidNo + " AND Playerid=" + playerId + "", 1);
                    obj.ExeQueryRetBooDL("Update Lineups Set Issub=1, Islive=0 Where Matchid=" + CommonCls.MatchId + " And PlayerID=" + playerId + "", 1);
                    obj.ExeQueryRetBooDL("Update Lineups Set Issub=0, Islive=1 Where Matchid=" + CommonCls.MatchId + " And PlayerID=" + SubplayerId + "", 1);
                    //LoadPlayer();
                    try
                    {
                        int cnt = obj.ExeQueryStrDL("Select ISNULL(Count(Raidno),0)+1 From tblCorrectedRaid where Matchid=" + CommonCls.MatchId + " And HalfID=" + CommonCls.HalfID + " AND RaidNo=" + MaxRaidno + "", 1);
                        obj.ExeQueryRetBooDL("Insert into tblCorrectedRaid (Matchid,HalfID,Raidno,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + MaxRaidno + "," + cnt + ",'Substitute','" + System.DateTime.Now + "',1,0,0)", 1);
                    }
                    catch { }
                    Reset();
                    //dt = new DataTable();
                    //dt = objDL.ExeQueryStrRetDTDL("select * from SwotengineMaster", 1);
                }
                catch { }
            }
        }
        private void pbTeamBSubstituteSwap_Click(object sender, EventArgs e)
        {
            SwapPlayer(2);
        }

        private void FrmScoringPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            if (BtnStartEnd.Text == "Raid End")
            {
                objDL.ExeQueryRetBooDL("Delete FROM Raid where matchID= " + CommonCls.MatchId + " and RaidNo=" + CommonCls.RaidNo + "", 1);
                try
                {
                    MasterDL obj = new MasterDL();
                    int cnt = obj.ExeQueryStrDL("Select ISNULL(Count(Raidno),0)+1 From tblCorrectedRaid where Matchid=" + CommonCls.MatchId + " And HalfID=" + CommonCls.HalfID + " AND RaidNo=" + CommonCls.RaidNo + "", 1);
                    obj.ExeQueryRetBooDL("Insert into tblCorrectedRaid (Matchid,HalfID,Raidno,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + CommonCls.RaidNo + "," + cnt + ",'Raid_Start','" + System.DateTime.Now + "',0,0,1)", 1);
                }
                catch { }
            }
        }

        private void cbQuarterID_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if()
        }

        private void deleteRaidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MasterDL obj = new MasterDL();
                DialogResult Result = MessageBox.Show("Continue to Delete This Raid", "Kabaddi Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (Result == DialogResult.Yes)
                {
                    int HalfID = Convert.ToInt32(gvRaidEvent.Rows[gvRaidEvent.CurrentRow.Index].Cells["HalfID"].Value);
                    int RaidNo = Convert.ToInt32(gvRaidEvent.Rows[gvRaidEvent.CurrentRow.Index].Cells["RaidNo"].Value);
                    bool lstraid = obj.ExeQueryRetBooDL("SELECT CASE WHEN MAX(RaidNo)=" + RaidNo + " then 'TRUE' else 'FALSE' END from Raid where MatchID=" + CommonCls.MatchId + "", 1);
                    if ((obj.ExeQueryRetBooDL("Delete from Raid Where MatchId=" + CommonCls.MatchId + " And HalfID=" + HalfID + " And RaidNo=" + RaidNo + "", 1)))
                    {
                        //obj.ExeQueryRetBooDL("Delete from RaidSubjects Where MatchId=" + CommonCls.MatchId + " And HalfID=" + HalfID + " And RaidNo=" + RaidNo + "", 1);
                        obj.ExeQueryRetBooDL("Delete from Events Where MatchId=" + CommonCls.MatchId + " And HalfID=" + HalfID + " And RaidNo=" + RaidNo + "", 1);
                        obj.ExeQueryRetBooDL("Delete from OutPlayer Where MatchId=" + CommonCls.MatchId + " And HalfID=" + HalfID + " And RaidNo=" + RaidNo + "", 1);
                        obj.ExeQueryRetBooDL("Delete from OutPlayerRef Where MatchId=" + CommonCls.MatchId + " And HalfID=" + HalfID + " And RaidNo=" + RaidNo + "", 1);
                        obj.ExeQueryRetBooDL("Delete from Innerplayer Where MatchId=" + CommonCls.MatchId + " And HalfID=" + HalfID + " And RaidNo=" + RaidNo + "", 1);
                        try
                        {
                            dt = new DataTable();
                            dt = obj.ExeQueryStrRetDTDL("Select * from Substitute Where MatchId=" + CommonCls.MatchId + " And HalfID=" + HalfID + " And RaidNo=" + RaidNo + "", 1);
                            foreach (DataRow dr in dt.Rows)
                            {
                                obj.ExeQueryRetBooDL("Update Lineups Set Issub=1, Islive=0 Where Matchid=" + CommonCls.MatchId + " And PlayerID=" + dr["SubplayerId"] + "", 1);
                                obj.ExeQueryRetBooDL("Update Lineups Set Issub=0, Islive=1 Where Matchid=" + CommonCls.MatchId + " And PlayerID=" + dr["playerId"] + "", 1);
                            }
                            obj.ExeQueryRetBooDL("Delete from Substitute Where MatchId=" + CommonCls.MatchId + " And HalfID=" + HalfID + " And RaidNo=" + RaidNo + "", 1);
                        }
                        catch { }
                        obj.ExeQueryRetBooDL("Delete from SuspendedPlayer Where MatchId=" + CommonCls.MatchId + " And HalfID=" + HalfID + " And RaidNo=" + RaidNo + "", 1);
                        if (lstraid)
                        {
                            obj.ExeQueryRetBooDL("Delete from INPlayerList Where MatchId=" + CommonCls.MatchId + " And RaidNo=" + (RaidNo + 1) + "", 1);
                            obj.ExeQueryRetBooDL("Delete from OutPlayerList Where MatchId=" + CommonCls.MatchId + " And RaidNo=" + (RaidNo + 1) + "", 1);
                        }
                        else
                        {
                            obj.ExeQueryRetBooDL("Delete from INPlayerList Where MatchId=" + CommonCls.MatchId + " And RaidNo=" + (RaidNo) + "", 1);
                            obj.ExeQueryRetBooDL("Delete from OutPlayerList Where MatchId=" + CommonCls.MatchId + " And RaidNo=" + (RaidNo) + "", 1);
                        }
                        obj.ExeQueryRetBooDL("Delete from SwapPlayer Where MatchId=" + CommonCls.MatchId + " And RaidNo=" + RaidNo + "", 1);

                        try
                        {
                            int cnt = obj.ExeQueryStrDL("Select ISNULL(Count(Raidno),0)+1 From tblCorrectedRaid where Matchid=" + CommonCls.MatchId + " And HalfID=" + CommonCls.HalfID + " AND RaidNo=" + CommonCls.RaidNo + "", 1);
                            obj.ExeQueryRetBooDL("Insert into tblCorrectedRaid (Matchid,HalfID,Raidno,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + CommonCls.RaidNo + "," + cnt + ",'Raid','" + System.DateTime.Now + "',0,0,1)", 1);
                        }
                        catch { }
                    }
                    Reset();
                    retriveVizSend();
                }
            }
            catch { }
        }


        private void deleteEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MasterDL obj = new MasterDL();
                DialogResult Result = MessageBox.Show("Continue to Delete This Event", "Kabaddi Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (Result == DialogResult.Yes)
                {
                    int HalfID = Convert.ToInt32(gvRaidEvent.Rows[gvRaidEvent.CurrentRow.Index].Cells["HalfID"].Value);
                    int RaidNo = Convert.ToInt32(gvRaidEvent.Rows[gvRaidEvent.CurrentRow.Index].Cells["RaidNo"].Value);
                    int EventID = Convert.ToInt32(gvRaidEvent.Rows[gvRaidEvent.CurrentRow.Index].Cells["EventID"].Value);
                    if ((obj.ExeQueryRetBooDL("Delete from Events Where MatchId=" + CommonCls.MatchId + " And HalfID=" + HalfID + " And RaidNo=" + RaidNo + " And EventID=" + EventID + "", 1)))
                    {
                        try
                        {
                            dt = new DataTable();
                            dt = obj.ExeQueryStrRetDTDL("Select * from OutPlayer Where MatchId=" + CommonCls.MatchId + " And HalfID=" + HalfID + " And RaidNo=" + RaidNo + " and EventID=" + EventID + "", 1);
                            foreach (DataRow dr in dt.Rows)
                            {
                                obj.ExeQueryRetBooDL("Delete from Outplayerref Where MatchId=" + CommonCls.MatchId + " And HalfID=" + HalfID + " And RaidNo=" + RaidNo + " and PlayerID=" + dr["playerId"] + "", 1);
                            }
                        }
                        catch { }
                        if ((obj.ExeQueryRetBooDL("Delete from OutPlayer Where MatchId=" + CommonCls.MatchId + " And HalfID=" + HalfID + " And RaidNo=" + RaidNo + " And EventID=" + EventID + "", 1)))
                        {

                        }
                    }
                    Reset();
                }
            }
            catch { }
        }

        private void lbTeamAINList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbTeamBINList1.SelectedIndex = -1;
            lbTeamBSubList.SelectedIndex = -1;
        }

        private void lbTeamBINList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbTeamAINList1.SelectedIndex = -1;
            lbTeamASubList.SelectedIndex = -1;
        }

        private void lbTeamASubList_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbTeamBINList1.SelectedIndex = -1;
            lbTeamBSubList.SelectedIndex = -1;
        }

        private void lbTeamBSubList_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbTeamAINList1.SelectedIndex = -1;
            lbTeamASubList.SelectedIndex = -1;
        }

        private void cbTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!PageLoad)
                { return; }
                MasterDL obj = new MasterDL();
                CommonCls.RaidClubId = Convert.ToInt32(cbTeam.SelectedValue);
                CommonCls.DefenceClubId = obj.ExeQueryStrDL("Select LeftClubID from MatchHalf Where Matchid=" + CommonCls.MatchId + " And LeftClubID Not in(" + CommonCls.RaidClubId + ")", 1);
                LoadRaider_Defender();
            }
            catch { }
        }

        private void btnTimerOn_Click(object sender, EventArgs e)
        {
            try
            {
                MasterDL objbl = new MasterDL();
                string ste = ConfigurationSettings.AppSettings["Timer"].ToString();
                if (ste == "0")
                {
                    lblMatchTime.Text = default(DateTime).Add(Convert.ToDateTime(ConfigurationSettings.AppSettings["StartTime"]).TimeOfDay).ToString("HH:mm:ss");
                    CommonCls.LastTime = default(DateTime).Add(Convert.ToDateTime(ConfigurationSettings.AppSettings["StartTime"]).TimeOfDay);
                    string ste1 = ConfigurationSettings.AppSettings["Timer"].ToString();
                    string configFile = Application.ExecutablePath + ".config";  //c:\path\exename.exe.config
                    XmlDocument xdoc = new XmlDocument();
                    xdoc.Load(configFile);
                    XmlNode node = xdoc.SelectSingleNode("/configuration/appSettings/add[@key='Timer']/@value");
                    node.Value = "1";
                    node = xdoc.SelectSingleNode("/configuration/appSettings/add[@key='StartTime']/@value");
                    node.Value = "";
                    File.WriteAllText(configFile, xdoc.InnerXml);

                    ConfigurationManager.RefreshSection("appSettings");
                }
                else
                {
                    try
                    {
                        DataTable dtt1 = new DataTable();
                        dtt1 = objbl.ExeQueryStrRetDTDL("SELECT * FROM Raid where  matchID= " + CommonCls.MatchId + " and HalfID=" + CommonCls.HalfID + " order by TimerStart desc", 1);
                        if (dtt1.Rows.Count > 0)
                        {
                            CommonCls.LastTime = default(DateTime).Add(Convert.ToDateTime(dtt1.Rows[0]["TimerStart"]).TimeOfDay);

                            lblMatchTime.Text = default(DateTime).Add(Convert.ToDateTime(dtt1.Rows[0]["TimerStart"]).TimeOfDay).ToString("HH:mm:ss");

                        }
                        else
                        {
                            CommonCls.LastTime = default(DateTime).Add(Convert.ToDateTime("00:00:00").TimeOfDay);
                            lblMatchTime.Text = default(DateTime).Add(Convert.ToDateTime("00:00:00").TimeOfDay).ToString("HH:mm:ss");
                        }


                    }
                    catch
                    {
                        CommonCls.LastTime = default(DateTime).Add(DateTime.Now.TimeOfDay);
                    }
                }
                var timeElapseTime = DateTime.Parse("00:20:00") - CommonCls.LastTime;
                timeElapseTime = new TimeSpan(timeElapseTime.Hours,
                                               timeElapseTime.Minutes,
                                               timeElapseTime.Seconds);

                lblElapseTime.Text = timeElapseTime.ToString();
                StartMatch();
                btnTimerOn.Enabled = false;
                btnTimerOff.Enabled = true;
            }
            catch { }

            try
            {
                ObjFndCtrl.sendScorecardTimer("CONT");
            }
            catch { }
        }

        private void btnTimerOff_Click(object sender, EventArgs e)
        {
            try
            {
                string configFile = Application.ExecutablePath + ".config";  //c:\path\exename.exe.config
                XmlDocument xdoc = new XmlDocument();
                xdoc.Load(configFile);
                XmlNode node = xdoc.SelectSingleNode("/configuration/appSettings/add[@key='Timer']/@value");
                node.Value = "0";
                node = xdoc.SelectSingleNode("/configuration/appSettings/add[@key='StartTime']/@value");
                node.Value = lblMatchTime.Text.Trim();
                File.WriteAllText(configFile, xdoc.InnerXml);
                ConfigurationManager.RefreshSection("appSettings");

                string ste = ConfigurationSettings.AppSettings["Timer"].ToString();
                if (_timerRunning)// If the timer is already running
                {
                    _timer.Stop();
                    _timerRunning = false;
                }
                btnTimerOn.Enabled = true;
                btnTimerOff.Enabled = false;
            }
            catch { }
            try
            {
                ObjFndCtrl.sendScorecardTimer("STOP");
            }
            catch { }
        }

        private void btnHalfEnd_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want Continue to Half End", "Hockey Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                mySW.Stop();

                if (_timerRunning)// If the timer is already running
                {
                    Timer_MatchClock.Stop();
                    _timerRunning = false;
                }

                MasterDL objbl = new MasterDL();
                objbl.ExeQueryRetBooDL("Update MatchHalf set HalfStart=1,HalfEnd=1,EndTime='" + DateTime.Now + "' where Matchid=" + CommonCls.MatchId + " and HalfID=" + CommonCls.HalfID + "", 1);
                try
                {
                    int cnt = objDL.ExeQueryStrDL("Select ISNULL(Count(*),0)+1 From tblCorrectedTable where Matchid=" + CommonCls.MatchId + " And tablename='MatchHalf'", 1);
                    objDL.ExeQueryRetBooDL("Insert into tblCorrectedTable (Matchid,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + CommonCls.MatchId + "," + cnt + ",'MatchHalf','" + System.DateTime.Now + "',0,1,0)", 1);
                }
                catch { }
                btnHalfEnd.Enabled = false;
                if (CommonCls.HalfID == 2)
                {
                    dt = objDL.ExeQueryStrRetDTDL("SELECT * FROM MatchHalf where  matchID= " + CommonCls.MatchId + " and (HalfStart!=1 and HalfEnd!=1) and HalfID=1", 1);
                    if (dt.Rows.Count > 0)
                    {
                        objbl.ExeQueryRetBooDL("Update MatchHalf set HalfStart=1,HalfEnd=1,EndTime='" + DateTime.Now + "' where Matchid=" + CommonCls.MatchId + " and HalfID=1", 1);
                    }
                    frmMatchResult frm = new frmMatchResult();
                    frm.Show();

                    frmManoftheMatch frm1 = new frmManoftheMatch();
                    frm1.Show();

                    BtnStartEnd.Enabled = false;
                    extraTimeToolStripMenuItem.Visible = true;
                    menuStrip1.Refresh();
                }
                else
                {
                    btnHalfStart.Enabled = true;
                    btnHalfStart.Text = "Half Start";
                    BtnStartEnd.Enabled = false;
                }
            }
        }

        private void lblMatchTime_Click(object sender, EventArgs e)
        {

        }

        private void lblMatchTime_TextChanged(object sender, EventArgs e)
        {
            string ss = lblMatchTime.Text;
        }

        private void llblRaidPoint_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlRaidPoint.Show();
            pnlRaidPoint.BringToFront();
        }

        private void pbRaidPointTableClose_Click(object sender, EventArgs e)
        {
            pnlRaidPoint.Hide();
        }

        private void gvRaidEvent_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int RaidNo = Convert.ToInt32(gvRaidEvent.CurrentRow.Cells["RaidNo"].Value.ToString());
            int EventID = Convert.ToInt32(gvRaidEvent.CurrentRow.Cells["EventID"].Value.ToString());
            string endframe = objDL.ExeQueryStrRetStrDL("select startFrame from videos where matchid=" + lblmatchid.Text + "", 1);

            try
            {
                FrmKabaddiQC frm = new FrmKabaddiQC(CommonCls.MatchId, CommonCls.HalfID, RaidNo, EventID);
                frm.Show();
            }
            catch { }
        }

        private void cbRaider_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!raiderchose || cbRaider.SelectedIndex == -1) { return; }
            CommonCls.RaiderID = Convert.ToInt32(cbRaider.SelectedValue);
            if (BtnStartEnd.Text == "Raid End")
            {
                try
                {
                    MasterDL obj = new MasterDL();
                    obj.ExeQueryRetBooDL("Update Raid Set RaiderId=" + CommonCls.RaiderID + " WHERE MatchID=" + CommonCls.MatchId + " AND HalfID=" + CommonCls.HalfID + " AND RaidNo=" + CommonCls.RaidNo + "", 1);
                }
                catch { }
                XMLPush(0, "START");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pbSuspendClose_Click(object sender, EventArgs e)
        {
            pnlSuspend.Hide();
        }

        private void btnSuspendClick_Click(object sender, EventArgs e)
        {
            try
            {

                foreach (DataGridViewRow dr in gvSuspend.Rows)
                {
                    int suspend = 0;

                    if (dr.Cells["IsSuspended"].Value != null)
                    {

                        if (dr.Cells["IsSuspended"].Value.ToString() == "True" || dr.Cells["IsSuspended"].Value.ToString() == "1")
                        {
                            suspend = 1;
                        }
                        else
                        {
                            suspend = 0;
                        }
                    }
                    else
                    {
                        suspend = 0;
                    }

                    string Query = "Update SuspendedPlayer Set Issuspend=" + suspend + ",ComebackRaidNo=" + CommonCls.RaidNo + " Where MatchID=" + CommonCls.MatchId + " And RaidNo=" + dr.Cells["RaidNosus"].Value + " And PlayerId=" + dr.Cells["PlayerId"].Value + "";
                    objDL.ExeQueryRetBooDL(Query, 1);
                }
                if (true)
                {
                    MessageBox.Show("Update Successfully", "Kabaddi Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pnlSuspend.Hide();
                }
            }
            catch
            {
                MessageBox.Show("Error On DataBase", "Kabaddi Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void llblChangeSuspend_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
        private void btnTechnicalPoint_Click(object sender, EventArgs e)
        {
            if (BtnStartEnd.Text == "Raid Start")
            {
                dt = new DataTable();
                dt = objDL.ExeQueryStrRetDTDL("Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.RaidClubId + " and L.issub=0 AND PlayerID NOT IN(Select PlayerID from OutPlayerRef Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.RaidClubId + " AND RaidNo=" + CommonCls.RaidNo + ") AND PlayerID Not IN(Select PlayerID from SuspendedPlayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.RaidClubId + " And Issuspend=1) Union All Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.RaidClubId + " and L.issub=0 AND PlayerID IN(Select PlayerID from Innerplayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.RaidClubId + " AND RaidNo=" + CommonCls.RaidNo + ") AND PlayerID Not IN(Select PlayerID from SuspendedPlayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.RaidClubId + " And Issuspend=1) order by JercyNo", 1);
                lbLineOutRaider.DataSource = dt;
                lbLineOutRaider.DisplayMember = "firstname";
                lbLineOutRaider.ValueMember = "playerid";

                dt = new DataTable();
                dt = objDL.ExeQueryStrRetDTDL("Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.DefenceClubId + " and L.issub=0 AND PlayerID NOT IN(Select PlayerID from OutPlayerRef Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.DefenceClubId + " AND RaidNo=" + CommonCls.RaidNo + ") AND PlayerID Not IN(Select PlayerID from SuspendedPlayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.DefenceClubId + " And Issuspend=1) Union All Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.DefenceClubId + " and L.issub=0 AND PlayerID IN(Select PlayerID from Innerplayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.DefenceClubId + " AND RaidNo=" + CommonCls.RaidNo + ") AND PlayerID Not IN(Select PlayerID from SuspendedPlayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.DefenceClubId + " And Issuspend=1) order by JercyNo", 1);
                lbLineOutDefender.DataSource = dt;
                lbLineOutDefender.DisplayMember = "firstname";
                lbLineOutDefender.ValueMember = "playerid";
                pnlLineOut.Show();
                pnlLineOut.BringToFront();
                techPoint = true;
            }
        }

        private void btnHalfReset_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want Continue to Remove Half End", "Hockey Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {

                    dt = objDL.ExeQueryStrRetDTDL("SELECT Max(HalfID)HalfID FROM MatchHalf where  matchID= " + CommonCls.MatchId + " and HalfStart=1 and HalfEnd=1", 1);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["HalfID"].ToString() != string.Empty)
                        {
                            objDL.ExeQueryRetBooDL("Update MatchHalf set HalfEnd=0 where Matchid=" + CommonCls.MatchId + " and HalfID=" + dt.Rows[0]["HalfID"] + "", 1);
                        }
                        btnClear_Click(sender, e);
                    }
                }
            }
            catch { }
        }


        private void btnUntoHalfEnd_Click(object sender, EventArgs e)
        {

        }

        private void FrmScoringPage_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void btnInitiatorClear_Click(object sender, EventArgs e)
        {
            lbInitiator.SelectedIndex = -1;
        }

        private void chkSwap_CheckedChanged(object sender, EventArgs e)
        {
            if (!PageLoad) return;
            if (chkSwap.Checked)
            {
                lbTeamAINList.SelectionMode = SelectionMode.One;
                lbTeamAINList.SelectedIndex = -1;

                lbTeamBINList.SelectionMode = SelectionMode.One;
                lbTeamBINList.SelectedIndex = -1;
            }
            else
            {
                lbTeamAINList.SelectionMode = SelectionMode.None;
                lbTeamBINList.SelectionMode = SelectionMode.None;
            }
        }

        void retriveVizSend()
        {
            if (CommonCls.EnableSendvizData == 0) { return; }
            try
            {
                VizKabaddiSendData viz = new VizKabaddiSendData();
                if (viz.TeamAPrefix == "" || viz.TeamAPrefix == null)
                    viz.TeamAPrefix = CommonCls.Club1Prefix;//"BENGALURU";
                if (viz.TeamBPrefix == "" || viz.TeamBPrefix == null)
                    viz.TeamBPrefix = CommonCls.Club2Prefix; //"SHIMOGA";
                if (viz.TeamAName == "" || viz.TeamAName == null)
                    viz.TeamAName = CommonCls.Club1Name;
                if (viz.TeamBName == "" || viz.TeamBName == null)
                    viz.TeamBName = CommonCls.Club2Name;
                if (lblTeamAScore.Text != "")
                    viz.TeamAScore = lblTeamAScore.Text;
                else
                    viz.TeamAScore = "0";
                if (lblTeamAScore.Text != "")
                    viz.TeamBScore = lblTeamBScore.Text;
                else
                    viz.TeamBScore = "0";
                viz.HalfID = CommonCls.HalfID == 1 || CommonCls.HalfID == 0 ? "1st" : "2nd";
                viz.Timer = lblElapseTime.Text.Split(':')[1] + ":" + lblElapseTime.Text.Split(':')[2];

                Dtgv1.Rows[0]["TeamAPrefix"] = viz.TeamAPrefix.ToString();
                Dtgv1.Rows[0]["TeamBPrefix"] = viz.TeamBPrefix.ToString();
                Dtgv2.Rows[0]["TeamAName"] = viz.TeamAName.ToString();
                Dtgv2.Rows[0]["TeamBName"] = viz.TeamBName.ToString();
                Dtgv2.Rows[0]["TeamAScore"] = viz.TeamAScore.ToString();
                Dtgv2.Rows[0]["TeamBScore"] = viz.TeamBScore.ToString();
                Dtgv1.Rows[0]["Timer"] = viz.Timer.ToString();
                Dtgv1.Rows[0]["HalfID"] = viz.HalfID.ToString();
                Dtgv1.Rows[0]["RaidStart"] = (BtnStartEnd.Text == "Raid Start" ? 0 : 1).ToString();

                if (CommonCls.ClubId1 == CommonCls.RaidClubId)
                {
                    Dtgv1.Rows[0]["TeamARaider"] = GetVizPlayerName(CommonCls.RaiderID);
                    Dtgv1.Rows[0]["TeamBRaider"] = "";

                    Dtgv2.Rows[0]["TeamASpecial"] = CommonCls.RaidSpecialCase;
                    Dtgv2.Rows[0]["TeamBSpecial"] = CommonCls.DefSpecialCase;


                    Dtgv1.Rows[0]["TeamAFreeText"] = "";
                    Dtgv1.Rows[0]["TeamBFreeText"] = "";
                    if (chkManualDIP.Checked)
                    {
                        Dtgv2.Rows[0]["TeamADIP"] = lblManualRaidDIP.Text;
                        Dtgv2.Rows[0]["TeamBDIP"] = lblManualDefDIP.Text;
                    }
                    else
                    {
                        Dtgv2.Rows[0]["TeamADIP"] = lblRaidDIP.Text;
                        Dtgv2.Rows[0]["TeamBDIP"] = lblDefDIP.Text;
                    }
                }
                else if (CommonCls.ClubId2 == CommonCls.RaidClubId)
                {
                    Dtgv1.Rows[0]["TeamARaider"] = "";
                    Dtgv1.Rows[0]["TeamBRaider"] = GetVizPlayerName(CommonCls.RaiderID);


                    Dtgv2.Rows[0]["TeamASpecial"] = CommonCls.DefSpecialCase;
                    Dtgv2.Rows[0]["TeamBSpecial"] = CommonCls.RaidSpecialCase;

                    Dtgv1.Rows[0]["TeamAFreeText"] = "";
                    Dtgv1.Rows[0]["TeamBFreeText"] = "";

                    if (chkManualDIP.Checked)
                    {
                        Dtgv2.Rows[0]["TeamADIP"] = lblManualDefDIP.Text;
                        Dtgv2.Rows[0]["TeamBDIP"] = lblManualRaidDIP.Text;
                    }
                    else
                    {
                        Dtgv2.Rows[0]["TeamADIP"] = lblDefDIP.Text;
                        Dtgv2.Rows[0]["TeamBDIP"] = lblRaidDIP.Text;
                    }
                }
                else
                {
                    Dtgv1.Rows[0]["TeamAFreeText"] = "";
                    Dtgv1.Rows[0]["TeamBFreeText"] = "";
                    Dtgv1.Rows[0]["TeamARaider"] = "";
                    Dtgv1.Rows[0]["TeamBRaider"] = "";
                    Dtgv2.Rows[0]["TeamADIP"] = "7";
                    Dtgv2.Rows[0]["TeamBDIP"] = "7";
                }
                ObjFndCtrl.dgv1.DataSource = Dtgv1;
                ObjFndCtrl.dgv2.DataSource = Dtgv2;
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

        DataTable Dtgv1, Dtgv2;
        void vizGridHeader()
        {
            ObjFndCtrl.dgv1.AutoGenerateColumns = false;
            Dtgv1 = new DataTable();
            Dtgv2 = new DataTable();
            Dtgv1.Columns.Add("HalfID");
            Dtgv1.Columns.Add("Timer");
            Dtgv1.Columns.Add("TeamAPrefix");
            Dtgv1.Columns.Add("TeamBPrefix");
            Dtgv1.Columns.Add("TeamARaider");
            Dtgv1.Columns.Add("TeamBRaider");
            Dtgv1.Columns.Add("TeamAFreeText");
            Dtgv1.Columns.Add("TeamBFreeText");
            Dtgv1.Columns.Add("RaidStart");
            Dtgv1.Rows.Add();


            Dtgv2.Columns.Add("TeamAScore");
            Dtgv2.Columns.Add("TeamBScore");
            Dtgv2.Columns.Add("TeamAName");
            Dtgv2.Columns.Add("TeamBName");
            Dtgv2.Columns.Add("TeamADIP");
            Dtgv2.Columns.Add("TeamBDIP");
            Dtgv2.Columns.Add("TeamASpecial");
            Dtgv2.Columns.Add("TeamBSpecial");
            Dtgv2.Rows.Add();
        }

        string GetVizPlayerName(int ID)
        {
            string Name = "";

            Name = objDL.ExeQueryStrRetStrDL("SELECT dbo.fn_GetPlayerFullName(" + ID + ")", 1);

            return Name;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
        int DIP = 0;
        private void btnRaidDIPplus_Click(object sender, EventArgs e)
        {
            try
            {
                DIP = Convert.ToInt32(lblManualRaidDIP.Text);
                if (DIP < 7)
                {
                    DIP = DIP + 1;
                }
                lblManualRaidDIP.Text = DIP.ToString();
                if (CommonCls.ClubId1 == CommonCls.RaidClubId)
                {
                    TeamAManualDipXML = Convert.ToInt16(lblManualRaidDIP.Text); TeamBManualDipXML = Convert.ToInt16(lblManualDefDIP.Text);
                }
                else if (CommonCls.ClubId2 == CommonCls.RaidClubId)
                {
                    TeamAManualDipXML = Convert.ToInt16(lblManualDefDIP.Text); TeamBManualDipXML = Convert.ToInt16(lblManualRaidDIP.Text);
                }
                XMLPush(1, "END");
            }
            catch (Exception ex) { MessageBox.Show("Error On Raid DIP"); }
        }

        private void btnRaidDIPminus_Click(object sender, EventArgs e)
        {
            try
            {
                DIP = Convert.ToInt32(lblManualRaidDIP.Text);
                if (DIP > 0)
                {
                    DIP = DIP - 1;
                }
                lblManualRaidDIP.Text = DIP.ToString();
                if (CommonCls.ClubId1 == CommonCls.RaidClubId)
                {
                    TeamAManualDipXML = Convert.ToInt16(lblManualRaidDIP.Text); TeamBManualDipXML = Convert.ToInt16(lblManualDefDIP.Text);
                }
                else if (CommonCls.ClubId2 == CommonCls.RaidClubId)
                {
                    TeamAManualDipXML = Convert.ToInt16(lblManualDefDIP.Text); TeamBManualDipXML = Convert.ToInt16(lblManualRaidDIP.Text);
                }
                XMLPush(1, "END");
            }
            catch (Exception ex) { MessageBox.Show("Error On Raid DIP"); }
        }

        private void btnDefDIPplus_Click(object sender, EventArgs e)
        {
            try
            {
                DIP = Convert.ToInt32(lblManualDefDIP.Text);
                if (DIP < 7)
                {
                    DIP = DIP + 1;
                }
                lblManualDefDIP.Text = DIP.ToString();

                if (CommonCls.ClubId1 == CommonCls.RaidClubId)
                {
                    TeamAManualDipXML = Convert.ToInt16(lblManualRaidDIP.Text); TeamBManualDipXML = Convert.ToInt16(lblManualDefDIP.Text);
                }
                else if (CommonCls.ClubId2 == CommonCls.RaidClubId)
                {
                    TeamAManualDipXML = Convert.ToInt16(lblManualDefDIP.Text); TeamBManualDipXML = Convert.ToInt16(lblManualRaidDIP.Text);
                }
                XMLPush(1, "END");
            }
            catch (Exception ex) { MessageBox.Show("Error On Def DIP"); }
        }

        private void btnDefDIPminus_Click(object sender, EventArgs e)
        {
            try
            {
                DIP = Convert.ToInt32(lblManualDefDIP.Text);
                if (DIP > 0)
                {
                    DIP = DIP - 1;
                }
                lblManualDefDIP.Text = DIP.ToString();
                if (CommonCls.ClubId1 == CommonCls.RaidClubId)
                {
                    TeamAManualDipXML = Convert.ToInt16(lblManualRaidDIP.Text); TeamBManualDipXML = Convert.ToInt16(lblManualDefDIP.Text);
                }
                else if (CommonCls.ClubId2 == CommonCls.RaidClubId)
                {
                    TeamAManualDipXML = Convert.ToInt16(lblManualDefDIP.Text); TeamBManualDipXML = Convert.ToInt16(lblManualRaidDIP.Text);
                }
                XMLPush(1, "END");
            }
            catch (Exception ex) { MessageBox.Show("Error On Def DIP"); }
        }

        private void chkManualDIP_CheckedChanged(object sender, EventArgs e)
        {
            if (chkManualDIP.Checked)
                pnlMaualDIP.Visible = true;
            else
                pnlMaualDIP.Visible = false;
        }

        private void btnQC_Click(object sender, EventArgs e)
        {

        }

        private void QCChange_Clicked(object sender, IdentityUpdateEventArgs e)
        {
            try
            {
                Reset();
                dt = objDL.ExeQueryStrRetDTDL("SELECT Min(HalfID)HalfID FROM MatchHalf where  matchID= " + CommonCls.MatchId + " and HalfStart=1 and HalfEnd=0", 1);

                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["HalfID"].ToString() != string.Empty)
                    {
                        btnCard.Enabled = true;
                        btnTechnicalPoint.Enabled = true;
                    }
                }
                retriveVizSend();
            }
            catch
            {

            }
        }


        private void FrmKabaddiScoring_Activated(object sender, EventArgs e)
        {

        }

        private void qCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKabaddiQC frm = new FrmKabaddiQC(CommonCls.MatchId, CommonCls.HalfID, CommonCls.RaidNo, CommonCls.EventID);

            frm.IdentityUpdated += new FrmKabaddiQC.IdentityUpdateHandler(QCChange_Clicked);
            frm.Show();
        }

        private void undoHalfEndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Do you want Continue to Undo Half End", "Hockey Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            //{
            //    MasterDL objbl = new MasterDL();
            //    objbl.ExeQueryRetBooDL("Update MatchHalf set HalfEnd=0 where Matchid=" + CommonCls.MatchId + " and HalfID=" + CommonCls.HalfID + "", 1);
            //    btnHalfEnd.Enabled = false;
            //    btnHalfStart.Enabled = true;
            //    btnHalfStart.Text = "Half Continue";
            //    BtnStartEnd.Enabled = false;
            //    btnClear_Click(sender, e);
            //}

            if (MessageBox.Show("Do you want Continue to Remove Half End", "Hockey Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                dt = objDL.ExeQueryStrRetDTDL("SELECT Max(HalfID)HalfID FROM MatchHalf where  matchID= " + CommonCls.MatchId + " and HalfStart=1 and HalfEnd=1", 1);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["HalfID"].ToString() != string.Empty)
                    {
                        objDL.ExeQueryRetBooDL("Update MatchHalf set HalfEnd=0 where Matchid=" + CommonCls.MatchId + " and HalfID=" + dt.Rows[0]["HalfID"] + "", 1);
                    }
                    else
                    {
                        if (CommonCls.HalfID == 2)
                        {
                            objDL.ExeQueryRetBooDL("Update MatchHalf set HalfStart=0,HalfEnd=0,StartTime=null,EndTime=null where Matchid=" + CommonCls.MatchId + " and HalfID=2", 1);
                            objDL.ExeQueryRetBooDL("Update MatchHalf set HalfEnd=0,EndTime=null where Matchid=" + CommonCls.MatchId + " and HalfID=1", 1);
                            objDL.ExeQueryRetBooDL("Delete from matchresult where Matchid=" + CommonCls.MatchId + "", 1);

                        }
                    }
                    dt = new DataTable();
                    dt = objDL.ExeQueryStrRetDTDL("SELECT * FROM MatchHalf where  matchID= " + CommonCls.MatchId + " and HalfStart=1 and HalfEnd=0", 1);
                    //   GVscorecard.DataSource = dt;
                    if (dt.Rows.Count > 0)
                    {
                        CommonCls.HalfID = Convert.ToInt32(dt.Rows[0]["HalfID"]);
                        lblhalfid.Text = dt.Rows[0]["HalfID"].ToString();

                        BtnStartEnd.Enabled = false;
                        btnHalfStart.Enabled = true;
                    }
                    else
                    {
                        dt = new DataTable();
                        dt = objDL.ExeQueryStrRetDTDL("SELECT Min(HalfID)HalfID FROM MatchHalf where  matchID= " + CommonCls.MatchId + " and HalfStart=0 and HalfEnd=0", 1);

                        if (dt.Rows.Count > 0)
                        {
                            TimerReset();
                            if (dt.Rows[0]["HalfID"].ToString() != string.Empty)
                            {
                                CommonCls.HalfID = Convert.ToInt32(dt.Rows[0]["HalfID"]);
                                lblhalfid.Text = dt.Rows[0]["HalfID"].ToString();

                                BtnStartEnd.Enabled = false;
                                btnHalfStart.Enabled = true;
                            }
                            else
                            {
                                MessageBox.Show("2 Half are Completed", "Kabaddi Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CommonCls.HalfID = 2;
                                BtnStartEnd.Enabled = false;
                                btnHalfStart.Enabled = false;
                            }
                        }
                    }
                    if (objDL.ExeQueryStrRetDTDL("Select * from Raid Where Matchid=" + CommonCls.MatchId + " And HalfID=" + CommonCls.HalfID + "", 1).Rows.Count > 0)
                    {
                        btnHalfStart.Text = "Half Continue";
                    }
                    else
                        btnHalfStart.Text = "Half Start";
                    btnClear_Click(sender, e);
                }
                try
                {
                    int cnt = objDL.ExeQueryStrDL("Select ISNULL(Count(*),0)+1 From tblCorrectedTable where Matchid=" + CommonCls.MatchId + " And tablename='MatchHalf'", 1);
                    objDL.ExeQueryRetBooDL("Insert into tblCorrectedTable (Matchid,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + CommonCls.MatchId + "," + cnt + ",'MatchHalf','" + System.DateTime.Now + "',0,1,0)", 1);
                }
                catch { }
            }
        }

        private void raidwisePointTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlRaidPoint.Show();
            pnlRaidPoint.BringToFront();
        }

        private void changeSubstituteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlSubtitute.Show();
            pnlSubtitute.BringToFront();
            lbTeamASubList.SelectedIndex = -1;
            lbTeamAINList1.SelectedIndex = -1;
            lbTeamBSubList.SelectedIndex = -1;
            lbTeamBINList1.SelectedIndex = -1;
        }

        private void changeSuspendedPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gvSuspend.Rows.Clear();
                }
                catch { }
                dt = new DataTable();
                dt = objDL.ExeQueryStrRetDTDL("Select Issuspend,PlayerID,dbo.fn_getPlayerName(PlayerID)PlayerName,IsKill,RaidNo,dbo.fn_GetTeamNameprefix(ClubId) Team,case when IsKill=1 THEN 'Red Card' Else 'Yellow Card' END Card from SuspendedPlayer Where Matchid=" + CommonCls.MatchId + " And Issuspend=1", 1);
                gvSuspend.AutoGenerateColumns = false;
                // gvSuspend.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ArrayList row1 = new ArrayList();
                        row1.Add(dt.Rows[i]["PlayerID"].ToString());
                        row1.Add(Convert.ToInt32(dt.Rows[i]["Issuspend"]));
                        row1.Add(dt.Rows[i]["PlayerName"].ToString());
                        row1.Add(dt.Rows[i]["RaidNo"].ToString());
                        row1.Add(dt.Rows[i]["Team"].ToString());
                        row1.Add(dt.Rows[i]["Card"].ToString());
                        gvSuspend.Rows.Add(row1[0], row1[1], row1[2].ToString(), row1[3], row1[4], row1[5]);
                    }
                }
                pnlSuspend.Show(); pnlSuspend.BringToFront();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[i]["IsKill"].ToString()))
                    {
                        if (Convert.ToInt32(dt.Rows[i]["IsKill"]) == 1)
                        {
                            gvSuspend.Rows[i].ReadOnly = true;
                        }
                        else
                            gvSuspend.Rows[i].ReadOnly = false;
                    }
                    else
                        gvSuspend.Rows[i].ReadOnly = false;
                }
            }
            catch { }
        }

        private void scorecardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScorecard frm = new frmScorecard(CommonCls.MatchId, CommonCls.ClubId1, CommonCls.ClubId2);
            frm.Show();
        }

        private void pbInplayerClose_Click(object sender, EventArgs e)
        {
            pnlInPlayer.Hide();
        }

        private void btnAddInPlayer_Click(object sender, EventArgs e)
        {
            foreach (DataRowView objDataRowView in lbPlayerList.SelectedItems)
            {
                gvInPlayer.Rows.Add(updtRaidno, Convert.ToInt32(objDataRowView["playerid"].ToString()), objDataRowView["firstname"].ToString(), false);
            }
        }

        private void btnInPlayer_Click(object sender, EventArgs e)
        {
            int clubid = 0;

            MasterDL obj = new MasterDL();
            obj.ExeQueryRetBooDL("DELETE FROM Innerplayer WHERE MatchID='" + CommonCls.MatchId + "' AND RaidNo='" + updtRaidno + "' " + (rbTeamAIN.Checked ? "and ClubID=" + CommonCls.ClubId1 : (rbTeamBIN.Checked ? "and ClubID=" + CommonCls.ClubId2 : "")), 1);

            foreach (DataGridViewRow row in gvInPlayer.Rows)
            {
                if (Convert.ToBoolean(row.Cells[3].Value) != true)
                {
                    clubid = obj.ExeQueryStrDL("SELECT Clubid FROM Lineups WHERE MatchID='" + CommonCls.MatchId + "' And PlayerID='" + Convert.ToString(row.Cells["PlayerID3"].Value) + "'", 1);
                    obj.ExeQueryRetBooDL("Insert into Innerplayer (MatchID,RaidNo,PlayerID,HalfID,ClubID)Values('" + CommonCls.MatchId + "','" + Convert.ToString(row.Cells["RaidNo3"].Value) + "','" + Convert.ToString(row.Cells["PlayerID3"].Value) + "'," + updtHalfID + "," + clubid + ")", 1);
                }
            }
            if (true)
                pnlInPlayer.Hide();
            else
                MessageBox.Show("Failed");
        }
        int updtHalfID = 0, updtRaidno = 0;
        private void showInPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                updtRaidno = Convert.ToInt32(gvRaidEvent.Rows[gvRaidEvent.CurrentRow.Index].Cells["RaidNo"].Value);
                updtHalfID = Convert.ToInt32(gvRaidEvent.Rows[gvRaidEvent.CurrentRow.Index].Cells["HalfID"].Value);
                BindInplayer("");
            }
            catch { }
        }

        void BindInplayer(string Filter)
        {
            MasterDL obj = new MasterDL();
            dt = new DataTable();
            dt = obj.ExeQueryStrRetDTDL("Select IP.RaidNo,L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS Player,CAST(L.JercyNo AS INT)JercyNo from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id INNER JOIN Innerplayer IP ON IP.PlayerId=L.PlayerID and IP.Matchid=L.MatchID WHERE IP.matchid=" + Temp_matchid + " " + Filter + " AND RaidNo=" + updtRaidno + "", 1);
            gvInPlayer.AutoGenerateColumns = false;
            //gvInPlayer.DataSource = dt;
            try
            {
                gvInPlayer.Rows.Clear();
            }
            catch { }
            foreach (DataRow row in dt.Rows)
            {
                ArrayList row2 = new ArrayList();
                row2.Add(Convert.ToInt32(row[0].ToString()));
                row2.Add(Convert.ToInt32(row[1].ToString()));
                row2.Add(row[2].ToString());
                gvInPlayer.Rows.Add(Convert.ToInt32(row2[0]), Convert.ToInt32(row2[1].ToString()), row2[2].ToString(), false);
            }

            //if (dt.Rows.Count > 0)
            //{
            pnlInPlayer.Visible = true;
            pnlInPlayer.BringToFront();
            //}
            //else
            //    pnlInPlayer.Visible = false;
        }

        void XMLPush(int i, string Format)
        {

            if (chkManualDIP.Checked)
            {
                CommonCls.TeamADIPXML = TeamAManualDipXML;
                CommonCls.TeamBDIPXML = TeamBManualDipXML;
            }
            else
            {
                CommonCls.TeamADIPXML = TeamADipXML;
                CommonCls.TeamBDIPXML = TeamBDipXML;
            }


            if (string.IsNullOrEmpty(CommonCls.xmlpath))
                return;
            try
            {
                try
                {
                    CurTimeinSec = TimeSpan.Parse("00:" + dtp_MatchClock.Value.Minute.ToString("D2") + ":" + dtp_MatchClock.Value.Second.ToString("D2")).TotalSeconds;
                }
                catch { CurTimeinSec = 0; }
                try
                {
                    InsertINOutPlayer(i);
                }
                catch
                {
                }
                try
                {
                    if (chkMatchClock.Checked)
                    {
                        if (CurTimeinSec == 0 || CurTimeinSec == 1200)
                            MessageBox.Show("Match colck is zero" + dtp_MatchClock.Value.ToString());
                        objDL.ExeQueryRetBooDL("Update KB_Matches set MatchClock=" + CurTimeinSec + " Where MatchID=" + CommonCls.MatchId + "", 1);
                        dtpXML_MatchClock.Value = dtp_MatchClock.Value;
                    }
                }
                catch
                {
                }
                if (!CommonCls.XmlPush) { return; }
                Xml.GenerateXML(objDL.ExeQueryStrRetDsDL("EXEC SP_MatchXML " + CommonCls.MatchId, 1), CommonCls.xmlpath + CommonCls.MatchId + "-in-match.xml");
                if (!Directory.Exists(CommonCls.xmlpath))
                    Directory.CreateDirectory(CommonCls.xmlpath);
                if (!Directory.Exists(CommonCls.xmlpath + "Match\\"))
                    Directory.CreateDirectory(CommonCls.xmlpath + "Match\\");
                if (!Directory.Exists(CommonCls.xmlpath + "Match\\" + CommonCls.MatchId))
                    Directory.CreateDirectory(CommonCls.xmlpath + "Match\\" + CommonCls.MatchId);

                File.Copy(CommonCls.xmlpath + CommonCls.MatchId + "-in-match.xml", CommonCls.xmlpath + "Match\\" + CommonCls.MatchId + "\\" + CommonCls.MatchId + "-in-match_" + CommonCls.RaidNo + "_" + Format + ".xml", true);
                if (!string.IsNullOrEmpty(CommonCls.xmlpath1))
                {
                    if (!Directory.Exists(CommonCls.xmlpath1))
                        Directory.CreateDirectory(CommonCls.xmlpath1);

                    File.Copy(CommonCls.xmlpath + CommonCls.MatchId + "-in-match.xml", CommonCls.xmlpath1 + "\\" + CommonCls.MatchId + "-in-match.xml", true);
                }
                try
                {
                    newgenerator(CommonCls.xmlpath + CommonCls.MatchId + "-in-match.xml");
                }
                catch { }
            }
            catch (Exception EX)
            {
                MessageBox.Show("Xml Push Failed. - " + EX.ToString());
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            MasterDL obj = new MasterDL();
            DialogResult Result = MessageBox.Show("Continue to remove This Event", "Kabaddi Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (Result == DialogResult.Yes)
            {
                int EventID = Convert.ToInt32(dgvOutplayerlist.Rows[dgvOutplayerlist.CurrentRow.Index].Cells["TempEventID"].Value);
                foreach (DataRow dr in CommonCls.DTListEvents.Rows)
                {
                    if (dr["EventID"].ToString() == EventID.ToString())
                    { dr.Delete(); break; }
                }
                foreach (DataRow dr in CommonCls.DTListOutPlayer.Rows)
                {
                    if (dr["EventID"].ToString() == EventID.ToString())
                    { dr.Delete(); break; }
                }
                dgvOutplayerlist.Rows.RemoveAt(dgvOutplayerlist.CurrentRow.Index);
            }
        }

        private void pbOutplayerlistClose_Click(object sender, EventArgs e)
        {
            pnlOutplayerlist.Hide();
        }

        private void pnlPitchMapMsg_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                pnlPitchMapMsg.Refresh();
                Graphics g = pnlPitchMapMsg.CreateGraphics();
                Brush brshGreen = new SolidBrush(Color.Red);
                Pen pn = new Pen(Color.Red);
                g.DrawEllipse(pn, e.X - 4, e.Y - 4, 8, 8);
                g.FillEllipse(brshGreen, e.X - 4, e.Y - 4, 8, 8);
                if (bonuscheck)
                {
                    CommonCls.BLPX = Convert.ToInt32(e.X);
                    CommonCls.BLPY = Convert.ToInt32(e.Y);
                }
                else
                {
                    CommonCls.PX = Convert.ToInt32(e.X);
                    CommonCls.PY = Convert.ToInt32(e.Y);
                }
                pnlPitchMapMsg.Hide();

                //pnlPitchMapMsg.Refresh();
                ////Draw Circel
                //g = pnlPitchMapMsg.CreateGraphics();
                //brshGreen = new SolidBrush(Color.Red);
                //pn = new Pen(Color.Red);
                //g.DrawEllipse(pn, CommonCls.PX - 4, CommonCls.PY - 4, 8, 8);
                //g.FillEllipse(brshGreen, CommonCls.PX - 4, CommonCls.PY - 4, 8, 8);
                if (TouchClick)
                    btnTouch_Click(sender, e);
                if (TackleClick)
                    btnTackle_Click(sender, e);
            }
            catch { }
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAllReport frm = new FrmAllReport();
            frm.Show();
        }

        private void resultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMatchResult frm = new frmMatchResult();
            frm.Show();
        }

        private void extraTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Are you sure to confirm this match added ' Extra Time '", "Kabaddi Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (Result == DialogResult.Yes)
            {
                objDL.ExeQueryRetBooDL("INSERT into matchhalf(Matchid,HalfID,LeftClubID,RightClubID,TossWin,Description,HalfStart,HalfEnd) SELECT Matchid,5-HalfID,LeftClubID,RightClubID,TossWin,Description,0,0 FROM matchhalf where Matchid=" + CommonCls.MatchId + "", 1);
                btnHalfStart.Enabled = true;
                btnHalfStart.Text = "Half Start";
                BtnStartEnd.Enabled = false;
                btnHalfEnd.Enabled = false;

                LoadTeam();
            }
        }

        void LoadTeam()
        {
            CMTossWinTeam.DataSource = objDL.ExeQueryStrRetDTDL("Select TeamA TeamID, dbo.fn_GetTeamName(TeamA)Name FROM KB_Matches where Matchid=" + CommonCls.MatchId + " Union All Select TeamB, dbo.fn_GetTeamName(TeamB)Name FROM KB_Matches where Matchid=" + CommonCls.MatchId + "", 1);
            CMTossWinTeam.DisplayMember = "Name";
            CMTossWinTeam.ValueMember = "TeamID";
            CMTossWinTeam.SelectedIndex = -1;

            CbRHSClubID.DataSource = objDL.ExeQueryStrRetDTDL("Select TeamA TeamID, dbo.fn_GetTeamName(TeamA)Name FROM KB_Matches where Matchid=" + CommonCls.MatchId + " Union All Select TeamB, dbo.fn_GetTeamName(TeamB)Name FROM KB_Matches where Matchid=" + CommonCls.MatchId + "", 1);
            CbRHSClubID.DisplayMember = "Name";
            CbRHSClubID.ValueMember = "TeamID";
            CbRHSClubID.SelectedIndex = -1;

            CbLHSClubID.DataSource = objDL.ExeQueryStrRetDTDL("Select TeamA TeamID, dbo.fn_GetTeamName(TeamA)Name FROM KB_Matches where Matchid=" + CommonCls.MatchId + " Union All Select TeamB, dbo.fn_GetTeamName(TeamB)Name FROM KB_Matches where Matchid=" + CommonCls.MatchId + "", 1);
            CbLHSClubID.DisplayMember = "Name";
            CbLHSClubID.ValueMember = "TeamID";
            CbLHSClubID.SelectedIndex = -1;

            try
            {
                dt = new DataTable();
                dt = objDL.ExeQueryStrRetDTDL("select * from matchhalf where matchid='" + CommonCls.MatchId + "' and HalfID>2 order by halfid", 1);
                if (dt.Rows.Count > 0)
                {
                    CMTossWinTeam.SelectedValue = dt.Rows[0]["TossWin"].ToString();
                    CMOption.Text = dt.Rows[0]["Description"].ToString();
                    CbRHSClubID.SelectedValue = dt.Rows[0]["RightClubID"].ToString();
                    CbLHSClubID.SelectedValue = dt.Rows[0]["LeftClubID"].ToString();
                    CmdTossOk.Text = "Update";
                }
            }
            catch
            {
                MessageBox.Show("Error on Toss Click", "Kabaddi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            GBToss.Visible = true;
        }

        private void CmdTossOk_Click(object sender, EventArgs e)
        {
            string SentQuery = "";
            string Query = "Select Count(*) from MatchHalf where matchid=" + CommonCls.MatchId + " And HalfID>2";
            if (objDL.ExeQueryStrDL(Query, 1) > 0)
            {
                //3rd innings
                SentQuery = "Update MatchHalf Set LeftClubID='" + CbLHSClubID.SelectedValue + "',RightClubID='" + CbRHSClubID.SelectedValue + "',TossWin='" + CMTossWinTeam.SelectedValue + "',Description='" + CMOption.Text + "' Where Matchid=" + CommonCls.MatchId + " AND HalfID=3";
                objDL.ExeQueryRetBooDL(SentQuery, 1);
                //4th innings
                SentQuery = "Update MatchHalf Set LeftClubID='" + CbRHSClubID.SelectedValue + "',RightClubID='" + CbLHSClubID.SelectedValue + "',TossWin='" + CMTossWinTeam.SelectedValue + "',Description='" + CMOption.Text + "' Where Matchid=" + CommonCls.MatchId + " AND HalfID=4";
                objDL.ExeQueryRetBooDL(SentQuery, 1);

                try
                {
                    int cnt = objDL.ExeQueryStrDL("Select ISNULL(Count(*),0)+1 From tblCorrectedTable where Matchid=" + CommonCls.MatchId + " And tablename='MatchHalf'", 1);
                    objDL.ExeQueryRetBooDL("Insert into tblCorrectedTable (Matchid,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + CommonCls.MatchId + "," + cnt + ",'MatchHalf','" + System.DateTime.Now + "',0,1,0)", 1);
                }
                catch { }
            }
            else
            {
                //3rd innings
                SentQuery = "Insert into MatchHalf(Matchid,HalfID,LeftClubID,RightClubID,TossWin,Description,HalfStart,HalfEnd) values(" + CommonCls.MatchId + ",3,'" + CbLHSClubID.SelectedValue + "','" + CbRHSClubID.SelectedValue + "','" + CMTossWinTeam.SelectedValue + "','" + CMOption.Text + "',0,0)";
                objDL.ExeQueryRetBooDL(SentQuery, 1);
                //4th innings
                SentQuery = "Insert into MatchHalf(Matchid,HalfID,LeftClubID,RightClubID,TossWin,Description,HalfStart,HalfEnd) values(" + CommonCls.MatchId + ",4,'" + CbRHSClubID.SelectedValue + "','" + CbLHSClubID.SelectedValue + "','" + CMTossWinTeam.SelectedValue + "','" + CMOption.Text + "',0,0)";
                objDL.ExeQueryRetBooDL(SentQuery, 1);
                try
                {
                    int cnt = objDL.ExeQueryStrDL("Select ISNULL(Count(*),0)+1 From tblCorrectedTable where Matchid=" + CommonCls.MatchId + " And tablename='MatchHalf'", 1);
                    objDL.ExeQueryRetBooDL("Insert into tblCorrectedTable (Matchid,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + CommonCls.MatchId + "," + cnt + ",'MatchHalf','" + System.DateTime.Now + "',1,0,0)", 1);
                }
                catch { }
            }

            int MAXHALFID = objDL.ExeQueryStrDL("Select MAX(HalfID) from MatchHalf where matchid=" + CommonCls.MatchId + "", 1);

            GBToss.Visible = false;
            btnHalfStart.Enabled = true;
            btnHalfStart.Text = "Half Start";
            BtnStartEnd.Enabled = false;
            btnHalfEnd.Enabled = false;
        }

        private void pbTossClose_Click(object sender, EventArgs e)
        {
            GBToss.Visible = false;
        }

        private void manualScoringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string query = "select UPPER(dbo.fn_GetTeamName(TeamA)) TeamA,UPPER(dbo.fn_GetTeamName(TeamB)) TeamB,TeamA TeamAid,TeamB TeamBid  from KB_Matches where MatchId=" + CommonCls.MatchId
                         + " exec SP_GetTeamScore @MatchID=" + CommonCls.MatchId + ",@ClubA=" + CommonCls.ClubId1 + ",@ClubB=" + CommonCls.ClubId2;
            ds = objDL.ExeQueryStrRetDsDL(query, 1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                FrmManualScore obj = new FrmManualScore(Convert.ToString(ds.Tables[0].Rows[0]["TeamA"]), Convert.ToString(ds.Tables[0].Rows[0]["TeamB"]), Convert.ToString(ds.Tables[1].Rows[0]["ClubA"]), Convert.ToString(ds.Tables[1].Rows[0]["ClubB"]));
                obj.Show();
            }
        }

        private void lbPlayerList_DrawItem(object sender, DrawItemEventArgs e)
        {

        }

        private void rbTeamINPlayerFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTeamAIN.Checked)
            {
                loadInplayerList(" And L.ClubID=" + CommonCls.ClubId1);
                BindInplayer(" And L.ClubID=" + CommonCls.ClubId1);
            }
            else if (rbTeamBIN.Checked)
            {
                loadInplayerList(" And L.ClubID=" + CommonCls.ClubId2);
                BindInplayer(" And L.ClubID=" + CommonCls.ClubId2);
            }
            else
            {
                loadInplayerList("");
                BindInplayer("");
            }
        }

        private void lbTeamASubList_DoubleClick(object sender, EventArgs e)
        {
            SwapPlayer(1);
        }

        private void lbTeamBSubList_DoubleClick(object sender, EventArgs e)
        {
            SwapPlayer(2);
        }

        private void lbTeamAOutList_DoubleClick(object sender, EventArgs e)
        {
            MoveOUTtoINPlayer(1);
        }

        private void lbTeamBOutList_DoubleClick(object sender, EventArgs e)
        {
            MoveOUTtoINPlayer(2);
        }

        private void manOfTheMatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManoftheMatch frm = new frmManoftheMatch();
            frm.Show();
        }

        private void timeOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CurTimeinSec = TimeSpan.Parse("00:" + dtp_MatchClock.Value.Minute.ToString("D2") + ":" + dtp_MatchClock.Value.Second.ToString("D2")).TotalSeconds;
            }
            catch { }
            frmTimeout frm = new frmTimeout(CommonCls.MatchId, CommonCls.HalfID, CommonCls.RaidNo, CurTimeinSec);
            frm.Show();
        }

        private void chkXmlPushEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkXmlPushEnable.Checked)
                CommonCls.XmlPush = true;
            else
                CommonCls.XmlPush = false;
        }

        private void btnDeclare_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Are you sure to confirm as a declare", "Kabaddi Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (Result == DialogResult.Yes)
            {
                isDeclare = true;

                LoadRaider_Defender();
                pnlLineOut.Show(); pnlLineOut.BringToFront();
            }
        }

        private void reviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CurTimeinSec = TimeSpan.Parse("00:" + dtp_MatchClock.Value.Minute.ToString("D2") + ":" + dtp_MatchClock.Value.Second.ToString("D2")).TotalSeconds;
            }
            catch { }
            frmReview frm = new frmReview(CommonCls.MatchId, CommonCls.HalfID, CommonCls.RaidNo, CurTimeinSec);
            frm.Show();

        }
        int Maina = 0, Mainb = 0, suba = 0, subb = 0, teamaid, teambid; int counta = 0, countb = 0;
        StreamReader sdr;
        public void newgenerator(string Path)
        {
            string cp = "";
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Inmatch));
                sdr = new StreamReader(Path);
                Inmatch Im = (Inmatch)serializer.Deserialize(sdr);
                sdr.Close();
                sdr.Dispose();

                txtteamA.Text = Im.Teamplayersstatistics.Team[0].Teamname;
                teamb.Text = Im.Teamplayersstatistics.Team[1].Teamname;
                txttotalpoints.Text = Im.Teamplayersstatistics.Team[0].Points.Totalpoints + "-" + Im.Teamplayersstatistics.Team[1].Points.Totalpoints;

                int teamaplayers = Im.Teamplayersstatistics.Team[0].Players.Player.Count;

                int teambplayers = Im.Teamplayersstatistics.Team[1].Players.Player.Count;

                counta = 0; countb = 0;
                for (int i = 0; i < teamaplayers; i++)
                {
                    var a = Im.Teamplayersstatistics.Team[0].Players.Player[i];
                    if (a.Playeroncourt == "true")
                    {
                        // var playera = Im.Teamplayersstatistics.Team[0].Players.Player[i].Playerraidingnow;

                        counta++;
                    }
                }
                for (int j = 0; j < teambplayers; j++)
                {
                    var b = Im.Teamplayersstatistics.Team[1].Players.Player[j];
                    if (b.Playeroncourt == "true")
                    {
                        //  var playerb = Im.Teamplayersstatistics.Team[1].Players.Player[j].Playerraidingnow;
                        countb++;
                    }
                }
                Maina = counta;
                Mainb = countb;
                suba = 7 - Maina;
                subb = 7 - Mainb;
                int countf = 1;
                foreach (var pb in pnlteamaDIP.Controls.OfType<Panel>())
                {
                    if (countf <= suba)
                    {
                        pb.BackColor = Color.Red;
                    }
                    else
                    {
                        pb.BackColor = Color.Green;
                    }
                    countf++;
                }
                int countg = 1;
                foreach (var pb in pnlteambdip.Controls.OfType<Panel>())
                {
                    if (countg <= subb)
                    {
                        pb.BackColor = Color.Red;
                    }
                    else
                    {
                        pb.BackColor = Color.Green;
                    }
                    countg++;
                }
                var lastRaid = Im.Playbyplay.Raid.LastOrDefault();
                int lastcount = Convert.ToInt32(lastRaid.Raidnumber);
                var currentRaidPlayerId = lastRaid.Raidingplayerid;
                var teamid = Im.Teamplayersstatistics.Team[0].Teamid;
                var RaidCount = Im.Playbyplay.Raid.Count;
                var currentRaidTeamId = lastRaid.Raidingteamid;
                var d = Im.Teamplayersstatistics.Team[0].Players.Player.LastOrDefault().Playerraidingnow;
                pnlraidpla.Visible = false;
                var currentateamid = ""; var currentbteamid = ""; var currentplayeraname = ""; var currentplayeraid = ""; var currentplayerbname = ""; var currentplayerbid = "";
                //  var currentbraidnum = "";
                for (int i = 0; i < teamaplayers; i++)
                {
                    if (Convert.ToString(Im.Teamplayersstatistics.Team[0].Players.Player[i].Playerraidingnow) == "true")
                    {
                        currentplayeraname = Im.Teamplayersstatistics.Team[0].Players.Player[i].Playername;
                        currentplayeraid = Im.Teamplayersstatistics.Team[0].Players.Player[i].Playerid;
                        currentateamid = Im.Teamplayersstatistics.Team[0].Teamid;
                        lblraidpla.Text = currentplayeraname;
                        pnlraidpla.Visible = true;
                    }
                }
                for (int i = 0; i < teambplayers; i++)
                {
                    if (Convert.ToString(Im.Teamplayersstatistics.Team[1].Players.Player[i].Playerraidingnow) == "true")
                    {
                        currentplayerbname = Im.Teamplayersstatistics.Team[1].Players.Player[i].Playername;
                        currentplayerbid = Im.Teamplayersstatistics.Team[1].Players.Player[i].Playerid;
                        currentbteamid = Im.Teamplayersstatistics.Team[1].Teamid;
                        lblraidpla.Text = currentplayerbname;
                        pnlraidpla.Visible = true;
                    }
                }
            }

            catch
            {
                sdr.Close();
                sdr.Dispose();
            }
        }

        private void chkLineoutShowAll_CheckedChanged(object sender, EventArgs e)
        {
            showLineoutPlayers();
        }

        void showLineoutPlayers()
        {
            if (chkLineoutShowAll.Checked)
            {
                dt = new DataTable();
                dt = objDL.ExeQueryStrRetDTDL("Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.RaidClubId + " order by JercyNo", 1);
                lbLineOutRaider.DataSource = dt;
                lbLineOutRaider.DisplayMember = "firstname";
                lbLineOutRaider.ValueMember = "playerid";

                dt = new DataTable();
                dt = objDL.ExeQueryStrRetDTDL("Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.DefenceClubId + " order by JercyNo", 1);
                lbLineOutDefender.DataSource = dt;
                lbLineOutDefender.DisplayMember = "firstname";
                lbLineOutDefender.ValueMember = "playerid";
            }
            else
            {
                dt = new DataTable();
                dt = objDL.ExeQueryStrRetDTDL("Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.RaidClubId + " and L.issub=0 AND PlayerID NOT IN(Select PlayerID from OutPlayerRef Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.RaidClubId + " AND RaidNo=" + CommonCls.RaidNo + ") AND PlayerID Not IN(Select PlayerID from SuspendedPlayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.RaidClubId + " And Issuspend=1) Union All Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.RaidClubId + " and L.issub=0 AND PlayerID IN(Select PlayerID from Innerplayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.RaidClubId + " AND RaidNo=" + CommonCls.RaidNo + ") AND PlayerID Not IN(Select PlayerID from SuspendedPlayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.RaidClubId + " And Issuspend=1) order by JercyNo", 1);
                lbLineOutRaider.DataSource = dt;
                lbLineOutRaider.DisplayMember = "firstname";
                lbLineOutRaider.ValueMember = "playerid";

                dt = new DataTable();
                dt = objDL.ExeQueryStrRetDTDL("Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.DefenceClubId + " and L.issub=0 AND PlayerID NOT IN(Select PlayerID from OutPlayerRef Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.DefenceClubId + " AND RaidNo=" + CommonCls.RaidNo + ") AND PlayerID Not IN(Select PlayerID from SuspendedPlayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.DefenceClubId + " And Issuspend=1) Union All Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " and L.clubid=" + CommonCls.DefenceClubId + " and L.issub=0 AND PlayerID IN(Select PlayerID from Innerplayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.DefenceClubId + " AND RaidNo=" + CommonCls.RaidNo + ") AND PlayerID Not IN(Select PlayerID from SuspendedPlayer Where Matchid=" + CommonCls.MatchId + " And Clubid=" + CommonCls.DefenceClubId + " And Issuspend=1) order by JercyNo", 1);
                lbLineOutDefender.DataSource = dt;
                lbLineOutDefender.DisplayMember = "firstname";
                lbLineOutDefender.ValueMember = "playerid";
            }
        }


        DateTime Starttime;
        Stopwatch mySW = new Stopwatch();
        int startoffset = 0;
        int CurrntTime = Convert.ToInt32(ConfigurationSettings.AppSettings["ClockTime"]);
        private void btn_MatchClock_Start_Click(object sender, EventArgs e)
        {
            if (btn_MatchClock_Start.Text == "Timer Start")
            {



                try
                {
                    MasterDL objbl = new MasterDL();
                    string ste = ConfigurationSettings.AppSettings["Timer"].ToString();
                    if (ste == "0")
                    {


                        mySW.Start();
                        Timer_MatchClock.Start();
                        _timerRunning = true;

                        Starttime = DateTime.Now;

                        btn_MatchClock_Start.Text = "Timer Pause";



                        CommonCls.LastTime = default(DateTime).Add(Convert.ToDateTime(ConfigurationSettings.AppSettings["StartTime"]).TimeOfDay);
                        string ste1 = ConfigurationSettings.AppSettings["Timer"].ToString();
                        string configFile = Application.ExecutablePath + ".config";  //c:\path\exename.exe.config
                        XmlDocument xdoc = new XmlDocument();
                        xdoc.Load(configFile);
                        XmlNode node = xdoc.SelectSingleNode("/configuration/appSettings/add[@key='Timer']/@value");
                        node.Value = "1";
                        node = xdoc.SelectSingleNode("/configuration/appSettings/add[@key='StartTime']/@value");
                        node.Value = "";
                        File.WriteAllText(configFile, xdoc.InnerXml);

                        ConfigurationManager.RefreshSection("appSettings");
                    }
                    else
                    {
                        try
                        {
                            DataTable dtt1 = new DataTable();
                            dtt1 = objbl.ExeQueryStrRetDTDL("SELECT * FROM Raid where  matchID= " + CommonCls.MatchId + " and HalfID=" + CommonCls.HalfID + " order by TimerStart desc", 1);
                            if (dtt1.Rows.Count > 0)
                            {
                                CommonCls.LastTime = default(DateTime).Add(Convert.ToDateTime(dtt1.Rows[0]["TimerStart"]).TimeOfDay);
                            }
                            else
                            {
                                CommonCls.LastTime = default(DateTime).Add(Convert.ToDateTime("00:00:00").TimeOfDay);
                            }
                        }
                        catch
                        {
                            CommonCls.LastTime = default(DateTime).Add(DateTime.Now.TimeOfDay);
                        }
                    }

                    mySW.Start();
                    Timer_MatchClock.Start();
                    _timerRunning = true;

                    Starttime = DateTime.Now;

                    int sec = (CommonCls.LastTime.Minute * 60) + (CommonCls.LastTime.Second);
                    startoffset = sec;
                    mySW = new Stopwatch();
                    btn_MatchClock_Start.Text = "Timer Pause";
                }
                catch { }

                try
                {
                    ObjFndCtrl.sendScorecardTimer("CONT");
                }
                catch { }
            }
            else if (btn_MatchClock_Start.Text == "Timer Resume")
            {
                mySW.Start();

                Timer_MatchClock.Start();
                _timerRunning = true;
                btn_MatchClock_Start.Text = "Timer Pause";
            }
            else if (btn_MatchClock_Start.Text == "Timer Pause")
            {
                mySW.Stop();

                if (_timerRunning)// If the timer is already running
                {
                    Timer_MatchClock.Stop();
                    _timerRunning = false;
                }

                btn_MatchClock_Start.Text = "Timer Resume";
            }
        }

        private void btn_ManualUpdate_Click(object sender, EventArgs e)
        {
            int sec = (dtp_MatchClock.Value.Minute * 60) + (dtp_MatchClock.Value.Second);
            startoffset = sec;

            TimeSpan span3 = TimeSpan.FromSeconds(startoffset).Add(mySW.Elapsed);
            dtp_MatchClock.Value = DateTime.ParseExact(span3.ToString(@"mm\:ss"), "mm:ss", CultureInfo.InvariantCulture);
            span3 = TimeSpan.FromSeconds(CurrntTime - startoffset).Subtract(mySW.Elapsed);
            dtp_ElapseClock.Value = DateTime.ParseExact(span3.ToString(@"mm\:ss"), "mm:ss", CultureInfo.InvariantCulture);
            mySW = new Stopwatch();
        }

        private void btn_MatchClock_Reset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you Continue to Reset the Timer", "Hockey Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                CommonCls.LastTime = default(DateTime).Add(Convert.ToDateTime("00:00:00").TimeOfDay);
                startoffset = Convert.ToInt32(TimeSpan.FromTicks(CommonCls.LastTime.Ticks).TotalSeconds);
                mySW = new Stopwatch();

                TimeSpan span3 = TimeSpan.FromSeconds(startoffset).Add(mySW.Elapsed);
                dtp_MatchClock.Value = DateTime.ParseExact(span3.ToString(@"mm\:ss"), "mm:ss", CultureInfo.InvariantCulture);
                span3 = TimeSpan.FromSeconds(CurrntTime - startoffset).Subtract(mySW.Elapsed);
                dtp_ElapseClock.Value = DateTime.ParseExact(span3.ToString(@"mm\:ss"), "mm:ss", CultureInfo.InvariantCulture);

                btn_MatchClock_Start.Text = "Timer Start";
            }
        }

        private void Timer_MatchClock_Tick(object sender, EventArgs e)
        {
            TimeSpan span3 = TimeSpan.FromSeconds(startoffset).Add(mySW.Elapsed);
            dtp_MatchClock.Value = DateTime.ParseExact(span3.ToString(@"mm\:ss"), "mm:ss", CultureInfo.InvariantCulture);
            span3 = TimeSpan.FromSeconds(CurrntTime - startoffset + 1).Subtract(mySW.Elapsed);
            dtp_ElapseClock.Value = DateTime.ParseExact(span3.ToString(@"mm\:ss"), "mm:ss", CultureInfo.InvariantCulture);
            if (BtnStartEnd.Text == "Raid End" && Convert.ToInt32(lblRaidTime.Text) < 30)//&& CommonCls.RaiderID != 0)
                lblRaidTime.Text = (Convert.ToInt32(lblRaidTime.Text) + 1).ToString();
        }

        private void lbRaider_DoubleClick(object sender, EventArgs e)
        {
            RaiderSubmitClick();
        }

        private void changeSubstituteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmSubstitute frm = new frmSubstitute(CommonCls.MatchId);
            frm.Show();
        }

        private void otherCardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CurTimeinSec = TimeSpan.Parse("00:" + dtp_MatchClock.Value.Minute.ToString("D2") + ":" + dtp_MatchClock.Value.Second.ToString("D2")).TotalSeconds;
            }
            catch { }
            frmOtherCards frm = new frmOtherCards(CommonCls.MatchId, CommonCls.HalfID, CommonCls.RaidNo, CurTimeinSec);
            frm.Show();
        }

        private void chkRemove_CheckedChanged(object sender, EventArgs e)
        {
            if (!PageLoad) return;
            if (chkRemove.Checked)
            {
                lbTeamAINList.SelectionMode = SelectionMode.One;
                lbTeamAOutList.SelectionMode = SelectionMode.None;
                lbTeamAINList.SelectedIndex = -1;

                lbTeamBINList.SelectionMode = SelectionMode.One;
                lbTeamBOutList.SelectionMode = SelectionMode.None;
                lbTeamBINList.SelectedIndex = -1;
            }
            else
            {
                lbTeamAOutList.SelectionMode = SelectionMode.One;
                lbTeamBOutList.SelectionMode = SelectionMode.One;
                lbTeamAINList.SelectionMode = SelectionMode.None;
                lbTeamBINList.SelectionMode = SelectionMode.None;
            }
        }
    }
}
