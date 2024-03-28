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
using System.Diagnostics;
using System.Collections;
using OtherSports_DataPushing.Kabaddi;
using System.Globalization;

namespace OtherSports_DataPushing
{

    public partial class FrmKabaddiQC : Form
    {

        KabaddiXmlGenerate Xml = new KabaddiXmlGenerate();
        public delegate void IdentityUpdateHandler(object sender, IdentityUpdateEventArgs e);
        public event IdentityUpdateHandler IdentityUpdated;
        DataTable dt;
        Boolean PageLoad = false;
        MasterDL objDL = new MasterDL();
        decimal setStarttime, setEndtime;
        string setStarttimevideo, setEndtimevideo;
        int ClubAID = 0, ClubBID = 0;
       

        int Temp_matchid;
        int halfid;
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
                return halfid;
            }
            set
            {
                halfid = value;
            }
        }


        string matchid = string.Empty;
        string Temp_HalfID = string.Empty;
        string videorunningflag = string.Empty;
        string Ins_Upd_flag = "";

        MasterDL obj = new MasterDL();
        public FrmKabaddiQC()
        {
            InitializeComponent();
            LoadMatches();
        }
        public FrmKabaddiQC(int Matchid,int HalfId,int raidno,int eventid)
        {
            InitializeComponent();
            LoadMatches();
            cbMatches.SelectedValue = Matchid;
            if (HalfId == 1)
                rdb1stHalf.Checked = true;
            else
                rdb2ndHalf.Checked = true;
            halfid = HalfId;
            CurRaidno = raidno;
            lblRaidNo.Text = CurRaidno.ToString();
            CurEventID = eventid;
            BindEvents();
        }

        private void FrmQCScore_Load(object sender, EventArgs e)
        {
            DataTable DT1 = new DataTable();
            DT1 = objDL.ExeQueryStrRetDTDL("select TeamA,TeamB,dbo.fn_GetTeamNameprefix(TeamA)TeamAPrefix,dbo.fn_GetTeamNameprefix(TeamB)TeamBPrefix from KB_Matches Where MAtchid=" + Temp_matchid + "", 1);
            
            if(DT1.Rows.Count>0)
            {
                ClubAID = Convert.ToInt32(DT1.Rows[0]["TeamA"].ToString());
                ClubBID = Convert.ToInt32(DT1.Rows[0]["TeamB"].ToString());
                rbTeamAIN.Text = DT1.Rows[0]["TeamAPrefix"].ToString();
                rbTeamBIN.Text = DT1.Rows[0]["TeamBPrefix"].ToString();
            }
            //ClubAID = objDL.ExeQueryStrDL("select TeamA,TeamB from KB_Matches Where MAtchid=" + Temp_matchid + "", 1);
            //ClubBID = objDL.ExeQueryStrDL("select TeamB from KB_Matches Where MAtchid=" + Temp_matchid + "", 1);


        }

        DataTable DTTouch, DTTackle;
        void LoadMatches()
        {
            obj = new MasterDL();
            dt = new DataTable();
            dt = obj.ExeQueryStrRetDTDL("Select Matchid,CAST(Matchid AS VARCHAR)+' - '+dbo.fn_GetMatchNamePreDate(Matchid)MatchName From KB_Matches Order by MatchID Desc", 1);
            cbMatches.DataSource = dt;
            cbMatches.DisplayMember = "MatchName";
            cbMatches.ValueMember = "Matchid";

            dt = new DataTable();
            dt = obj.ExeQueryStrRetDTDL("Select ID,dbo.fn_GetEventName(ID)Outcome From EventMaster Where ID IN(12,13,14,15,16)", 1);
            cbOutcome.DataSource = dt;
            cbOutcome.DisplayMember = "Outcome";
            cbOutcome.ValueMember = "ID";

            dt = new DataTable();
            dt = obj.ExeQueryStrRetDTDL("Select ID,dbo.fn_GetEventName(ID)Outcome From EventMaster Where ID IN(12,13,14,15,16) Union All Select 0 ID ,'All' Name order by id", 1);
            cbOutComeFilter.DataSource = dt;
            cbOutComeFilter.DisplayMember = "Outcome";
            cbOutComeFilter.ValueMember = "ID";
            cbOutComeFilter.SelectedIndex = -1;

            dt = new DataTable();
            dt = obj.ExeQueryStrRetDTDL("Select ID,dbo.fn_GetEventName(ID)Events From EventMaster Where ID Not IN(12,13,14,15,16)", 1);
            cbEvents.DataSource = dt;
            cbEvents.DisplayMember = "Events";
            cbEvents.ValueMember = "ID";

            dt = new DataTable();
            dt = obj.ExeQueryStrRetDTDL("Select ID,dbo.fn_GetEventName(ID)Cards From EventMaster Where ID IN(23,24,25)", 1);
            cbRaiderCards.DataSource = dt;
            cbRaiderCards.DisplayMember = "Cards";
            cbRaiderCards.ValueMember = "ID";

            dt = new DataTable();
            dt = obj.ExeQueryStrRetDTDL("Select ID,dbo.fn_GetEventName(ID)Cards From EventMaster Where ID IN(23,24,25)", 1);
            cbRaiderCards.DataSource = dt;
            cbRaiderCards.DisplayMember = "Cards";
            cbRaiderCards.ValueMember = "ID";

            dt = new DataTable();
            dt = obj.ExeQueryStrRetDTDL("Select ID,dbo.fn_GetEventName(ID)OutType From EventMaster Where ID IN(17,18,19,20,21,22)", 1);
            cbRaiderOutType.DataSource = dt;
            cbRaiderOutType.DisplayMember = "OutType";
            cbRaiderOutType.ValueMember = "ID";

            DTTouch = new DataTable();
            DTTouch = obj.ExeQueryStrRetDTDL("Select ID,dbo.fn_GetEventName(ID)EventType From EventMaster where EventGroup='Touch'", 1);

            DTTackle = new DataTable();
            DTTackle = obj.ExeQueryStrRetDTDL("Select ID,dbo.fn_GetEventName(ID)EventType From EventMaster where EventGroup='Tackle'", 1);

            cbMatches.SelectedIndex = -1;
            cbOutcome.SelectedIndex = -1;
            cbEvents.SelectedIndex = -1;
            cbRaiderCards.SelectedIndex = -1;
            PageLoad = true;

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
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void cbMatches_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!PageLoad) { return; }
            Temp_matchid=Convert.ToInt32(cbMatches.SelectedValue);
            dt=new DataTable();
           // dt = obj.ExeQueryStrRetDTDL("Select R.Matchid,HalfID,Timerstart Time,Raidno,dbo.fn_GetPlayerName(RaiderID)+' ('+CAST(L.JercyNo AS VARCHAR)+')' Raider,dbo.fn_getEventName(Outcome)OutCome  from Raid R JOIN Lineups L ON R.Matchid=L.Matchid AND R.RaiderID=L.PlayerID  Where R.Matchid=" + Temp_matchid + " Order by R.RaidNo Desc", 1);

            lblRaidNo.Text = "0";
            dt = new DataTable();
            //if (chkOverall.Checked)
           // if(cmb)
            if(chkScore.Checked==true)
                dt = obj.ExeQueryStrRetDTDL("Select R.Matchid,dbo.fn_GetMatchNamePreDate(R.Matchid)MatchName,R.HalfID,MAX(Timerstart) Time,R.Raidno,MAX(dbo.fn_GetPlayerName(RaiderID)) Raider,MAX(dbo.fn_getEventName(Outcome))OutCome, MAX(ISNULL(dbo.fn_GetEventName(RaiderOutType),''))RaiderOutType,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,3),'') SpecialCase ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,4),'') KeyDefender,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,5),'') SupportedKeyDefender ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,6),'') Defenderevents ,MAX(dbo.fn_GetEventName(R.RaiderCard))Card ,dbo.fn_GetRaidbyRaidScore(R.MatchID,R.HalfID,R.RaidNo) Score,''DIP from Raid R JOIN KB_Matches M ON R.Matchid=M.Matchid JOIN Lineups L ON R.Matchid=L.Matchid AND R.RaiderID=L.PlayerID FULL JOIN OutPlayer O ON O.MatchID=R.MatchID And O.HalfID=R.HalfID And O.RaidNo=R.RaidNo FULL JOIN Events e ON e.MatchID=R.MatchID And e.HalfID=R.HalfID And e.RaidNo=R.RaidNo and E.EventId=O.EventID Where R.Matchid IN(" + cbMatches.SelectedValue + ")  GROUP by M.date, R.Matchid,R.HalfID,R.RaidNo Order by M.date desc,R.Matchid,R.HalfID desc,R.RaidNo desc", 1);
            else
                dt = obj.ExeQueryStrRetDTDL("Select R.Matchid,dbo.fn_GetMatchNamePreDate(R.Matchid)MatchName,R.HalfID,MAX(Timerstart) Time,R.Raidno,MAX(dbo.fn_GetPlayerName(RaiderID)) Raider,MAX(dbo.fn_getEventName(Outcome))OutCome, MAX(ISNULL(dbo.fn_GetEventName(RaiderOutType),''))RaiderOutType,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,3),'') SpecialCase ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,4),'') KeyDefender,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,5),'') SupportedKeyDefender ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,6),'') Defenderevents ,MAX(dbo.fn_GetEventName(R.RaiderCard))Card ,'' Score,''DIP from Raid R JOIN KB_Matches M ON R.Matchid=M.Matchid JOIN Lineups L ON R.Matchid=L.Matchid AND R.RaiderID=L.PlayerID FULL JOIN OutPlayer O ON O.MatchID=R.MatchID And O.HalfID=R.HalfID And O.RaidNo=R.RaidNo FULL JOIN Events e ON e.MatchID=R.MatchID And e.HalfID=R.HalfID And e.RaidNo=R.RaidNo and E.EventId=O.EventID Where R.Matchid IN(" + cbMatches.SelectedValue + ") GROUP by M.date, R.Matchid,R.HalfID,R.RaidNo Order by M.date desc,R.Matchid,R.HalfID desc,R.RaidNo desc", 1);
            //else if (rdbRaider.Checked)
            //    dt = obj.ExeQueryStrRetDTDL("Select R.Matchid,dbo.fn_GetMatchNamePreDate(R.Matchid)MatchName,R.HalfID,MAX(Timerstart) Time,R.Raidno,MAX(dbo.fn_GetPlayerName(RaiderID)) Raider,MAX(dbo.fn_getEventName(Outcome))OutCome, MAX(ISNULL(dbo.fn_GetEventName(RaiderOutType),''))RaiderOutType,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,3),'') SpecialCase ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,4),'') KeyDefender,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,5),'') SupportedKeyDefender ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,6),'') Defenderevents ,MAX(dbo.fn_GetEventName(R.RaiderCard))Card ,dbo.fn_GetRaidbyRaidScore(R.MatchID,R.HalfID,R.RaidNo)Score,''DIP from Raid R JOIN Matches M ON R.Matchid=M.Matchid FULL JOIN OutPlayer O ON O.MatchID=R.MatchID And O.HalfID=R.HalfID And O.RaidNo=R.RaidNo FULL JOIN Events e ON e.MatchID=R.MatchID And e.HalfID=R.HalfID And e.RaidNo=R.RaidNo and E.EventId=O.EventID Where R.Matchid IN(" + Temp_matchids + ") and R.RaiderID=" + CommonCls.RaiderID + " " + CommonCls.Filter + " GROUP by M.date, R.Matchid,R.HalfID,R.RaidNo Order by M.date desc,R.Matchid,R.HalfID,R.RaidNo", 1);
            //else if (rdbDefender.Checked)
            //    dt = obj.ExeQueryStrRetDTDL("Select R.Matchid,dbo.fn_GetMatchNamePreDate(R.Matchid)MatchName,R.HalfID,MAX(Timerstart) Time,R.Raidno,MAX(dbo.fn_GetPlayerName(RaiderID)) Raider,MAX(dbo.fn_getEventName(Outcome))OutCome, MAX(ISNULL(dbo.fn_GetEventName(RaiderOutType),''))RaiderOutType,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,3),'') SpecialCase ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,4),'') KeyDefender,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,5),'') SupportedKeyDefender ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,6),'') Defenderevents ,MAX(dbo.fn_GetEventName(R.RaiderCard))Card ,dbo.fn_GetRaidbyRaidScore(R.MatchID,R.HalfID,R.RaidNo)Score,''DIP from Raid R JOIN Matches M ON R.Matchid=M.Matchid FULL JOIN OutPlayer O ON O.MatchID=R.MatchID And O.HalfID=R.HalfID And O.RaidNo=R.RaidNo FULL JOIN Events e ON e.MatchID=R.MatchID And e.HalfID=R.HalfID And e.RaidNo=R.RaidNo and E.EventId=O.EventID Where R.Matchid IN(" + Temp_matchids + ") and O.PlayerID=" + CommonCls.DefenderID + " " + CommonCls.Filter + " GROUP by M.date, R.Matchid,R.HalfID,R.RaidNo Order by M.date desc,R.Matchid,R.HalfID,R.RaidNo", 1);
             
            gvRaidEvent.AutoGenerateColumns = false;
            gvRaidEvent.DataSource = dt;

            PageLoad = false;
            dt = new DataTable();
            dt = obj.ExeQueryStrRetDTDL("Select Distinct L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + Temp_matchid + " Union All Select 0 ID ,'All',0 Name order by JercyNo", 1);
            cbRaiderFilter.DataSource = dt;
            cbRaiderFilter.DisplayMember = "firstname";
            cbRaiderFilter.ValueMember = "playerid";
            cbRaiderFilter.SelectedIndex = -1;
            loadInplayerList("");
            LoadDefenderFilter();
            rdbAll.Checked = true;
            PageLoad = true;
        }

        void LoadDefenderFilter()
        {
            try
            {
                dt = new DataTable();
               // dt = obj.ExeQueryStrRetDTDL("Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20))+'('+dbo.fn_getTeamnameprefix(L.clubid)+')' AS firstname,L.JercyNo   from lineups L INNER JOIN Player P ON L.Playerid=P.id WHERE L.matchid=" + Temp_matchid + "", 1);
                dt = obj.ExeQueryStrRetDTDL("select CASE When Initiator IS NULL OR Initiator=0 Then OP.PlayerID else Initiator END PlayerID,dbo.fn_GetPlayerName(CASE When Initiator IS NULL OR Initiator=0 Then OP.PlayerID else Initiator END)Name from OutPlayer OP Right Join Events E ON OP.MatchID=E.MatchID And OP.HalfID=E.HalfID And OP.RaidNo=E.RaidNo And OP.EventID=E.EventId Where E.Matchid=" + Temp_matchid + " and (KeyDefender=1 Or Initiator IS NOT NULL) group by CASE When Initiator IS NULL OR Initiator=0 Then OP.PlayerID else Initiator END", 1);
                cmbDefenderFilter.DataSource = dt;
                cmbDefenderFilter.DisplayMember = "Name";
                cmbDefenderFilter.ValueMember = "PlayerID";
            }
            catch { }
        }

        void loadInplayerList(string Filter)
        {
            try
            {
                dt = new DataTable();
                dt = obj.ExeQueryStrRetDTDL("Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20))+'('+dbo.fn_getTeamnameprefix(L.clubid)+')' AS firstname,L.JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + Temp_matchid + " " + Filter + "", 1);
                lbPlayerList.DataSource = dt;
                lbPlayerList.DisplayMember = "firstname";
                lbPlayerList.ValueMember = "playerid";
                lbPlayerList.SelectedIndex = -1;
            }
            catch { }
        }

        void BindInplayer(string Filter)
        {
            try
            {
                dt = new DataTable();
                dt = obj.ExeQueryStrRetDTDL("Select IP.RaidNo,L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS Player,CAST(L.JercyNo AS INT)JercyNo from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id INNER JOIN Innerplayer IP ON IP.PlayerId=L.PlayerID and IP.Matchid=L.MatchID WHERE IP.matchid=" + Temp_matchid + " " + Filter + " AND RaidNo=" + CurRaidno + "", 1);
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

                if (dt.Rows.Count > 0)
                {
                    InorOutplayer = 1;
                    pnlInPlayer.Visible = true;
                    pnlInPlayer.BringToFront();
                }
                else if (Filter != "")
                {
                    InorOutplayer = 1;
                    pnlInPlayer.Visible = true;
                    pnlInPlayer.BringToFront();
                }

            }
            catch { }
        }
        void BindOutplayer(string Filter)
        {
            try
            {
                dt = new DataTable();
                dt = obj.ExeQueryStrRetDTDL("Select IP.RaidNo,L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS Player,CAST(L.JercyNo AS INT)JercyNo from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id INNER JOIN Outplayerref IP ON IP.PlayerId=L.PlayerID and IP.Matchid=L.MatchID WHERE IP.matchid=" + Temp_matchid + " " + Filter + " AND RaidNo=" + CurRaidno + "", 1);
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

                if (dt.Rows.Count > 0)
                {
                    pnlInPlayer.Visible = true;
                    pnlInPlayer.BringToFront();
                }
                else
                    pnlInPlayer.Visible = false;

            }
            catch { }
        }



        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void gvRaidEvent_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            reset();
            CurRaidno = Convert.ToInt32(gvRaidEvent.CurrentRow.Cells["RaidNo"].Value.ToString());

              
            lblRaidNo.Text = CurRaidno.ToString();
            BindEvents();
        }
        int PreviousOutcome = 0;
        void BindEvents()
        {
            cbRaiderCards.SelectedIndex = -1;
            cbRaider.SelectedIndex = -1;
            cbEvents.SelectedIndex = -1;
            cbOutcome.SelectedIndex = -1;
            cbRaiderOutType.SelectedIndex = -1;
            pnlDefender.Hide();
            pnlKeyDefender.Hide();
            pnlLineOut.Hide();
            bonuscheck = false;
            CommonCls.PX = 0;
            CommonCls.PY = 0;
          
            pnlEvents.Hide();
            LoadSubGrid();
            BindInplayer("");
            try
            {
                dt = new DataTable();
                dt = obj.ExeQueryStrRetDTDL("Select TeamA ClubA,TeamB ClubB,dbo.fn_GetTeamName(TeamA)ClubAName,dbo.fn_GetTeamName(TeamB)ClubBName,*,dbo.fn_GetRaidbyRaidScore(M.MatchID,HalfID,RaidNo)Score,DATEDIFF(second, 0, TimerStart)TimeStart,DATEDIFF(second, 0, TimerEnd)TimeEnd from Raid R Join KB_Matches M ON R.Matchid=M.Matchid Where M.MatchID=" + Temp_matchid + " And RaidNo=" + CurRaidno + "", 1);
                if (dt.Rows.Count > 0)
                {
                    halfid = Convert.ToInt32(dt.Rows[0]["HalfID"]);
                    cbOutcome.SelectedValue = obj.ExeQueryStrDL("Select Outcome from Raid Where MatchID=" + Temp_matchid + " And RaidNo=" + dt.Rows[0]["RaidNo"] + "", 1);
                    RaidClubId = obj.ExeQueryStrDL("Select L.ClubID from Raid R Join Lineups L ON R.MatchID=L.MatchID And R.RaiderID=L.PlayerID Where R.MatchID=" + Temp_matchid + " And R.RaiderID=" + dt.Rows[0]["RaiderID"] + "", 1); // Previous Raid TeamID
                    DefenceClubId = obj.ExeQueryStrDL("Select LeftClubID from MatchHalf Where Matchid=" + Temp_matchid + " And LeftClubID Not in(" + RaidClubId + ")", 1); // Previous Defender TeamID
                    LoadRaider_Defender(RaidClubId, DefenceClubId, true);
                    cbRaider.SelectedValue = Convert.ToInt32(dt.Rows[0]["RaiderID"]);
                    PreviousOutcome = Convert.ToInt32(cbOutcome.SelectedValue);
                    CommonCls.RaiderID = Convert.ToInt32(cbRaider.SelectedValue);
                    CommonCls.BLPX = Convert.ToInt32(dt.Rows[0]["BLPX"]);
                    CommonCls.BLPY = Convert.ToInt32(dt.Rows[0]["BLPY"]);

                    
                   

                    try
                    { cbRaiderOutType.SelectedValue = Convert.ToInt32(dt.Rows[0]["RaiderOutType"]); }
                    catch
                    {

                    }
                    
                    try
                    {
                        RaidOutPlyerID = Convert.ToInt32(cbRaider.SelectedValue);
                    }
                    catch { }

                    try
                    {
                        TimeSpan span3 = TimeSpan.FromSeconds(Convert.ToInt32(dt.Rows[0]["TimeStart"]));
                        dtp_StartTime.Value = DateTime.ParseExact(span3.ToString(@"mm\:ss"), "mm:ss", CultureInfo.InvariantCulture);
                        span3 = TimeSpan.FromSeconds(Convert.ToInt32(dt.Rows[0]["TimeEnd"]));
                        dtp_EndTime.Value = DateTime.ParseExact(span3.ToString(@"mm\:ss"), "mm:ss", CultureInfo.InvariantCulture);                        
                    }
                    catch { }


                    if (chkShowAll.Checked)
                    {
                        RaidFilter = ""; DefFilter = "";
                    }
                    else
                    {
                        RaidFilter = " And L.PlayerID IN(Select PlayerID from Inplayerlist where matchid=" + Temp_matchid + " and clubid=" + RaidClubId + " and RaidNo=" + CurRaidno + ")";
                        DefFilter = " And L.PlayerID IN(Select PlayerID from Inplayerlist where matchid=" + Temp_matchid + " and clubid=" + DefenceClubId + " and RaidNo=" + CurRaidno + ")";
                    }
                    if (dt.Rows[0]["RaiderCard"].ToString() != string.Empty && dt.Rows[0]["RaiderCard"].ToString() != null)
                        cbRaiderCards.SelectedValue = Convert.ToInt32(dt.Rows[0]["RaiderCard"]);
                    else
                        cbRaiderCards.SelectedValue = 0;
                    if (cbRaiderCards.SelectedIndex == -1)
                        try
                        {
                            cbRaiderCards.SelectedValue = Convert.ToInt32(dt.Rows[0]["RaiderOutType"]);
                        }
                        catch
                        {

                        }
                    if (Convert.ToInt32(dt.Rows[0]["DoorDie"]) == 1)
                        chkDoorDie.Checked = true;
                    else
                        chkDoorDie.Checked = false;
                    if (Convert.ToInt32(dt.Rows[0]["SuperRaid"]) == 1)
                        chkSuperRaid.Checked = true;
                    else
                        chkSuperRaid.Checked = false;
                    if (Convert.ToInt32(dt.Rows[0]["SuperTackle"]) == 1)
                        chkSuperTackle.Checked = true;
                    else
                        chkSuperTackle.Checked = false;
                    if (Convert.ToInt32(dt.Rows[0]["BonusLine"]) == 1)
                    {
                        chkBonusPoint.Checked = true;
                        pnlPitchMap.Show();
                        pnlPitchMap.Refresh();
                        Graphics g = pnlPitchMap.CreateGraphics();
                        Brush brshGreen = new SolidBrush(Color.Red);
                        Pen pn = new Pen(Color.Red);
                        g.DrawEllipse(pn, (Convert.ToInt32(dt.Rows[0]["BLPX"]) - 4), (Convert.ToInt32(dt.Rows[0]["BLPY"]) - 4), 8, 8);
                        g.FillEllipse(brshGreen, (Convert.ToInt32(dt.Rows[0]["BLPX"]) - 4), (Convert.ToInt32(dt.Rows[0]["BLPY"]) - 4), 8, 8);
                    }

                    else
                        chkBonusPoint.Checked = false;
                    if (Convert.ToInt32(dt.Rows[0]["Allout"]) == 1)
                        chkAllOut.Checked = true;
                    else
                        chkAllOut.Checked = false;
                    lblScore.Text = dt.Rows[0]["Score"].ToString();

                    txtRaidDIP.Text = dt.Rows[0]["RaidDIP"].ToString();
                    txtDefDIP.Text = dt.Rows[0]["DefDIP"].ToString();

                    try
                    {
                        lblAID.Text = dt.Rows[0]["ClubA"].ToString();
                        lblBID.Text = dt.Rows[0]["ClubB"].ToString();
                        rbTeamA.Text = dt.Rows[0]["ClubAName"].ToString();
                        rbTeamB.Text = dt.Rows[0]["ClubBName"].ToString();
                        if (Convert.ToInt32(lblAID.Text) == RaidClubId)
                            rbTeamA.Checked = true;
                        else if (Convert.ToInt32(lblBID.Text) == RaidClubId)
                            rbTeamB.Checked = true;
                    }
                    catch { }
                }
                else
                {
                }
            }
            catch { }
            Ins_Upd_flag = "Update";
            bonuscheck = true;
        }

        void LoadSubGrid()
        {
            try
            {
                dt = new DataTable();
                dt = obj.ExeQueryStrRetDTDL("Select RaidNo,EventId,dbo.fn_GetEventName(eventtype)eventtype from Events Where Matchid=" + Temp_matchid + " And Raidno=" + CurRaidno + " order by RaidNo,EventId", 1);
                gvEvents.AutoGenerateColumns = false;
                gvEvents.DataSource = dt;
            }
            catch { }
        }
        int RaidClubId = 0, DefenceClubId = 0,CurRaidno=0,CurEventID=0;
        string RaidFilter = "", DefFilter = "";
        void LoadRaider_Defender(int RaiderClub, int DefClub,bool RaiderReset)
        {
            try
            {
                MasterDL obj = new MasterDL();
                DataTable dt1 = new DataTable();
                if (!eventClick && RaiderReset)
                {
                    dt1 = new DataTable();
                    dt1 = obj.ExeQueryStrRetDTDL("Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + Temp_matchid + " and L.clubid=" + RaiderClub + " order by JercyNo", 1);
                    cbRaider.DataSource = dt1;
                    cbRaider.DisplayMember = "firstname";
                    cbRaider.ValueMember = "playerid";
                }

                //dt = obj.ExeQueryStrRetDTDL("Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,L.JercyNo   from lineups L INNER JOIN Player P ON L.Playerid=P.id WHERE L.matchid=" + Temp_matchid + " and L.clubid=" + DefClub + " and L.issub=0 AND PlayerID Not IN(Select PlayerID from OutPlayerRef Where Matchid=" + Temp_matchid + " And Clubid=" + DefClub + " AND RaidNo=" + CurRaidno + ") order by CAST(JercyNo AS INT)", 1);
                dt1 = obj.ExeQueryStrRetDTDL("Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + Temp_matchid + " and L.clubid=" + DefClub + " " + DefFilter + " order by JercyNo", 1);
                lbKeyDefender.DataSource = dt1;
                lbKeyDefender.DisplayMember = "firstname";
                lbKeyDefender.ValueMember = "playerid";

                dt1 = obj.ExeQueryStrRetDTDL("Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + Temp_matchid + " and L.clubid=" + DefClub + " " + DefFilter + " order by JercyNo", 1);
                lbInitiator.DataSource = dt1;
                lbInitiator.DisplayMember = "firstname";
                lbInitiator.ValueMember = "playerid";

                dt1 = new DataTable();
                dt1 = obj.ExeQueryStrRetDTDL("Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + Temp_matchid + " and L.clubid=" + RaiderClub + " " + RaidFilter + " order by JercyNo", 1);
                lbLineOutRaider.DataSource = dt1;
                lbLineOutRaider.DisplayMember = "firstname";
                lbLineOutRaider.ValueMember = "playerid";

                dt1 = new DataTable();
                dt1 = obj.ExeQueryStrRetDTDL("Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + Temp_matchid + " and L.clubid=" + DefClub + " " + DefFilter + " order by JercyNo", 1);
                lbSupportedDefender.DataSource = dt1;
                lbSupportedDefender.DisplayMember = "firstname";
                lbSupportedDefender.ValueMember = "playerid";

                dt1 = new DataTable();
                dt1 = obj.ExeQueryStrRetDTDL("Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + Temp_matchid + " and L.clubid=" + DefClub + " " + DefFilter + " order by JercyNo", 1);
                lbLineOutDefender.DataSource = dt1;
                lbLineOutDefender.DisplayMember = "firstname";
                lbLineOutDefender.ValueMember = "playerid";

                dt1 = new DataTable();
                dt1 = obj.ExeQueryStrRetDTDL("Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + Temp_matchid + " and L.clubid=" + DefClub + " " + DefFilter + " order by JercyNo", 1);
                lbDefender.DataSource = dt1;
                lbDefender.DisplayMember = "firstname";
                lbDefender.ValueMember = "playerid";
                //INOUTPlayer();

                try
                {
                    string RaidColor = "", DefColor = "";
                    if (CommonCls.ClubId1 == RaiderClub)
                        RaidColor = CommonCls.TeamAColor;
                    else
                        RaidColor = CommonCls.TeamBColor;
                    if (CommonCls.ClubId1 == DefClub)
                        DefColor = CommonCls.TeamAColor;
                    else
                        DefColor = CommonCls.TeamBColor;

                    lbLineOutRaider.BackColor = Color.FromName(RaidColor);

                    lbKeyDefender.BackColor = Color.FromName(DefColor);
                    lbInitiator.BackColor = Color.FromName(DefColor);
                    lbLineOutDefender.BackColor = Color.FromName(DefColor);
                    lbDefender.BackColor = Color.FromName(DefColor);
                    lbSupportedDefender.BackColor = Color.FromName(DefColor);
                    lbDefender.BackColor = Color.FromName(DefColor);
                }
                catch
                {
                    lbLineOutRaider.BackColor = Color.FromName("Silver");


                    lbKeyDefender.BackColor = Color.FromName("Silver");
                    lbInitiator.BackColor = Color.FromName("Silver");
                    lbLineOutDefender.BackColor = Color.FromName("Silver");
                    lbDefender.BackColor = Color.FromName("Silver");
                    lbSupportedDefender.BackColor = Color.FromName("Silver");
                }

                lbKeyDefender.SelectedIndex = -1;
                lbInitiator.SelectedIndex = -1;
                lbLineOutRaider.SelectedIndex = -1;
                lbSupportedDefender.SelectedIndex = -1;
                lbLineOutDefender.SelectedIndex = -1;
                lbDefender.SelectedIndex = -1;

            }
            catch
            { }

        }

        private void pbLineoutClose_Click(object sender, EventArgs e)
        {
            pnlLineOut.Hide();
        }

        private void pbDefenderClose_Click(object sender, EventArgs e)
        {
            pnlKeyDefender.Hide();
        }

        private void pbDefender1Close_Click(object sender, EventArgs e)
        {
            pnlDefender.Hide();
        }
        bool eventClick = false;
        private void gvEvents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            eventClick = true;
            Ins_Upd_flag = "Update";
            lbDefender.SelectedIndex = -1;
            lbKeyDefender.SelectedIndex = -1; lbInitiator.SelectedIndex = -1;
            lbLineOutDefender.SelectedIndex = -1;
            lbLineOutRaider.SelectedIndex = -1;
            lbSupportedDefender.SelectedIndex = -1;

            pnlDefender.Hide();
            pnlKeyDefender.Hide();
            pnlLineOut.Hide();
            bonuscheck = false;
            CurEventID = Convert.ToInt32(gvEvents.CurrentRow.Cells["EventID"].Value.ToString());
            LoadRaider_Defender(RaidClubId, DefenceClubId, false);
            dt = new DataTable();
            dt = obj.ExeQueryStrRetDTDL("Select EventType,ClubID,ISNULL(E.Initiator,0)Initiator,OP.PlayerID,KeyDefender,SupportedKeyDefender,PX,PY,ABS(Startframe)Startframe from events E Join Outplayer OP ON E.MatchID=OP.MatchID AND E.RaidNo=OP.RaidNo And E.EventId=OP.EventID Join Lineups L ON OP.Matchid=L.MatchID AND L.PlayerID=OP.PlayerID Where E.Matchid=" + Temp_matchid + " And E.RaidNo=" + CurRaidno + " And E.EventID=" + CurEventID + "", 1);
            if (dt.Rows.Count > 0)
            {
                int eventtype= Convert.ToInt32(dt.Rows[0]["EventType"]);

              
                cbEvents.SelectedValue = eventtype;
                try
                {
                    lbInitiator.SelectedValue = Convert.ToInt32(dt.Rows[0]["Initiator"]);
                }
                catch { }
                if (eventtype == 17 || eventtype == 18 || eventtype == 23 || eventtype == 24 || eventtype == 25 || eventtype == 30)
                {
                    pnlLineOut.Show();
                    pnlLineOut.BringToFront();
                    if (RaidClubId == Convert.ToInt32(dt.Rows[0]["ClubID"]))
                    {
                        lbLineOutRaider.SelectedValue = Convert.ToInt32(dt.Rows[0]["PlayerID"]);
                    }
                    else
                        lbLineOutDefender.SelectedValue = Convert.ToInt32(dt.Rows[0]["PlayerID"]);
                }
                else if (eventtype == 62)
                {
                    showDeclarePlayers(Convert.ToInt32(dt.Rows[0]["ClubID"]));
                    pnlDefender.Show();
                    pnlDefender.BringToFront();
                    foreach (DataRow dr in dt.Rows)
                    {
                        lbDefender.SelectedValue = Convert.ToInt32(dr["PlayerID"]);
                    }
                }
                else if (eventtype == 1 || eventtype == 33 || eventtype == 34 || eventtype == 35 || eventtype == 2 || eventtype == 3 || eventtype == 4 || eventtype == 5 || eventtype == 6 || eventtype == 7 || eventtype == 8 || eventtype == 55 || eventtype == 56 || eventtype == 57 || eventtype == 58 || eventtype == 66 || eventtype == 67 || eventtype == 68 || eventtype == 69)
                {
                    pnlDefender.Show();
                    pnlDefender.BringToFront();
                    //lbDefender.SelectionMode = SelectionMode.MultiSimple;
                    foreach (DataRow dr in dt.Rows)
                    {
                        lbDefender.SelectedValue = Convert.ToInt32(dr["PlayerID"]);
                    }

                    pnlPitchMap.Show();
                    pnlPitchMap.BringToFront();
                }
                else if (eventtype == 9 || eventtype == 10 || eventtype == 11 || eventtype == 26 || eventtype == 27 || eventtype == 28 || eventtype == 29 || eventtype == 59 || eventtype == 60 || eventtype == 61 || eventtype == 70 || eventtype == 71 || eventtype == 72 || eventtype == 73 || eventtype == 74 || eventtype == 75 || eventtype == 76 || eventtype == 79)
                {
                    pnlKeyDefender.Show();
                    pnlKeyDefender.BringToFront();

                    pnlPitchMap.Show();
                    pnlPitchMap.BringToFront();
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (Convert.ToInt32(dr["KeyDefender"]) == 1)
                        {
                            lbKeyDefender.SelectedValue = Convert.ToInt32(dr["PlayerID"]);
                        }
                        else if (Convert.ToInt32(dr["SupportedKeyDefender"]) == 1)
                        {
                            lbSupportedDefender.SelectedValue = Convert.ToInt32(dr["PlayerID"]);
                        }
                    }
                }
                try
                {
                    if (CommonCls.BLPX != null &&eventtype!=62)//&& CommonCls.BLPX != 0)
                    {
                        pnlPitchMap.Show();
                        pnlPitchMap.Refresh();
                        Graphics g = pnlPitchMap.CreateGraphics();
                        Brush brshGreen = new SolidBrush(Color.Red);
                        Pen pn = new Pen(Color.Red);
                        g.DrawEllipse(pn, (Convert.ToInt32(dt.Rows[0]["PX"]) - 4), (Convert.ToInt32(dt.Rows[0]["PY"]) - 4), 8, 8);
                        g.FillEllipse(brshGreen, (Convert.ToInt32(dt.Rows[0]["PX"]) - 4), (Convert.ToInt32(dt.Rows[0]["PY"]) - 4), 8, 8);
                    }
                }
                catch { }
            }
        }

        private void cbEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!PageLoad) { return; }
            int eventtype = Convert.ToInt32(cbEvents.SelectedValue);
            if (eventtype == 17 || eventtype == 18 || eventtype == 23 || eventtype == 24 || eventtype == 25 || eventtype == 30)
            {
                if (!DefenderClick && !RaiderClick)
                {
                    pnlLineOut.Show();
                    pnlLineOut.BringToFront();
                }
            }
            else if (eventtype == 1 || eventtype == 2 || eventtype == 3 || eventtype == 4 || eventtype == 5 || eventtype == 6 || eventtype == 7 || eventtype == 8 || eventtype == 33 || eventtype == 34 || eventtype == 35 || eventtype == 55 || eventtype == 56 || eventtype == 57 || eventtype == 58 || eventtype == 66 || eventtype == 67 || eventtype == 68 || eventtype == 69)
            {
                pnlDefender.Show();
                pnlDefender.BringToFront();
            }
            else if (eventtype == 9 || eventtype == 10 || eventtype == 11 || eventtype == 26 || eventtype == 27 || eventtype == 28 || eventtype == 29 || eventtype == 59 || eventtype == 60 || eventtype == 61 || eventtype == 70 || eventtype == 71 || eventtype == 72 || eventtype == 73 || eventtype == 74 || eventtype == 75 || eventtype == 76 || eventtype == 79)
            {
                pnlKeyDefender.Show();
                pnlKeyDefender.BringToFront();
            }
        }

        private void cbOutcome_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        int RaidOutPlyerID = 0;
        private void cbRaider_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnKeydefenderClear_Click(object sender, EventArgs e)
        {
            lbKeyDefender.SelectedIndex = -1;
        }

        private void btnSupportKeydefenderClear_Click(object sender, EventArgs e)
        {
            lbSupportedDefender.SelectedIndex = -1;
        }

        private void btnLineoutRaiderClear_Click(object sender, EventArgs e)
        {
            lbLineOutRaider.SelectedIndex = -1;
        }

        private void btnLineoutDefenderClear_Click(object sender, EventArgs e)
        {
            lbLineOutDefender.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lbDefender.SelectedIndex = -1;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Continue to Reset", "Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                rdb1stHalf.Checked = false;
                rdb2ndHalf.Checked = false;
                cbMatches.SelectedIndex = -1;
                gvRaidEvent.DataSource = null;
                reset();
            }
        }

        void reset()
        {
            chkBonusPoint.Checked = false;
            chkDoorDie.Checked = false;
            chkSuperRaid.Checked = false;
            chkSuperTackle.Checked = false;
            chkAllOut.Checked = false;
            lbDefender.SelectedIndex = -1;
            lbKeyDefender.SelectedIndex = -1;
            lbLineOutDefender.SelectedIndex = -1;
            lbLineOutRaider.SelectedIndex = -1;
            lbSupportedDefender.SelectedIndex = -1;
            cbRaiderCards.SelectedIndex = -1;
            cbRaider.SelectedIndex = -1;
            cbEvents.SelectedIndex = -1;
            cbOutcome.SelectedIndex = -1;
            gvEvents.DataSource = null;
            CurRaidno = 0;
            DefenceClubId = 0;
            RaidClubId = 0;
            pnlDefender.Hide();
            pnlKeyDefender.Hide();
            pnlLineOut.Hide();
            pnlInPlayer.Hide();
            CurEventID = 0;
            eventClick = false;
            try
            {
                CommonCls.DTListEvents.Rows.Clear();
                CommonCls.DTListOutPlayer.Rows.Clear();
            }
            catch { }

            TouchClick = true;
            TackleClick = false;
            bonuscheck = false;
            pnlPitchMap.Hide();
            InorOutplayer = 0;
        }

        private void rdb1stHalf_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb1stHalf.Checked == true)
            {
                if (!PageLoad) { return; }
                dt = new DataTable();
                // dt = obj.ExeQueryStrRetDTDL("Select R.Matchid,HalfID,Timerstart Time,Raidno,dbo.fn_GetPlayerName(RaiderID)+' ('+CAST(L.JercyNo AS VARCHAR)+')' Raider,dbo.fn_getEventName(Outcome)OutCome  from Raid R JOIN Lineups L ON R.Matchid=L.Matchid AND R.RaiderID=L.PlayerID  Where R.Matchid=" + Temp_matchid+" And R.halfid=1 Order by R.RaidNo", 1);
                if (chkScore.Checked)
                    dt = obj.ExeQueryStrRetDTDL("Select R.Matchid,dbo.fn_GetMatchNamePreDate(R.Matchid)MatchName,R.HalfID,MAX(Timerstart) Time,R.Raidno,MAX(dbo.fn_GetPlayerName(RaiderID)) Raider,MAX(dbo.fn_getEventName(Outcome))OutCome, MAX(ISNULL(dbo.fn_GetEventName(RaiderOutType),''))RaiderOutType,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,3),'') SpecialCase ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,4),'') KeyDefender,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,5),'') SupportedKeyDefender ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,6),'') Defenderevents ,MAX(dbo.fn_GetEventName(R.RaiderCard))Card ,dbo.fn_GetRaidbyRaidScore(R.MatchID,R.HalfID,R.RaidNo) Score,''DIP from Raid R JOIN KB_Matches M ON R.Matchid=M.Matchid JOIN Lineups L ON R.Matchid=L.Matchid AND R.RaiderID=L.PlayerID FULL JOIN OutPlayer O ON O.MatchID=R.MatchID And O.HalfID=R.HalfID And O.RaidNo=R.RaidNo FULL JOIN Events e ON e.MatchID=R.MatchID And e.HalfID=R.HalfID And e.RaidNo=R.RaidNo and E.EventId=O.EventID Where R.Matchid IN(" + cbMatches.SelectedValue + ") And R.halfid=1 GROUP by M.date, R.Matchid,R.HalfID,R.RaidNo Order by M.date desc,R.Matchid,R.HalfID,R.RaidNo  desc", 1);
                else
                    dt = obj.ExeQueryStrRetDTDL("Select R.Matchid,dbo.fn_GetMatchNamePreDate(R.Matchid)MatchName,R.HalfID,MAX(Timerstart) Time,R.Raidno,MAX(dbo.fn_GetPlayerName(RaiderID)) Raider,MAX(dbo.fn_getEventName(Outcome))OutCome, MAX(ISNULL(dbo.fn_GetEventName(RaiderOutType),''))RaiderOutType,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,3),'') SpecialCase ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,4),'') KeyDefender,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,5),'') SupportedKeyDefender ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,6),'') Defenderevents ,MAX(dbo.fn_GetEventName(R.RaiderCard))Card ,'' Score,''DIP from Raid R JOIN KB_Matches M ON R.Matchid=M.Matchid JOIN Lineups L ON R.Matchid=L.Matchid AND R.RaiderID=L.PlayerID FULL JOIN OutPlayer O ON O.MatchID=R.MatchID And O.HalfID=R.HalfID And O.RaidNo=R.RaidNo FULL JOIN Events e ON e.MatchID=R.MatchID And e.HalfID=R.HalfID And e.RaidNo=R.RaidNo and E.EventId=O.EventID Where R.Matchid IN(" + cbMatches.SelectedValue + ") And R.halfid=1 GROUP by M.date, R.Matchid,R.HalfID,R.RaidNo Order by M.date desc,R.Matchid,R.HalfID desc,R.RaidNo desc", 1);

                gvRaidEvent.AutoGenerateColumns = false;
                gvRaidEvent.DataSource = dt;
            }
        }

        private void rdb2ndHalf_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb2ndHalf.Checked == true)
            {
                if (!PageLoad) { return; }
                dt = new DataTable();
              //  dt = obj.ExeQueryStrRetDTDL("Select R.Matchid,HalfID,Timerstart Time,Raidno,dbo.fn_GetPlayerName(RaiderID)+' ('+CAST(L.JercyNo AS VARCHAR)+')' Raider,dbo.fn_getEventName(Outcome)OutCome  from Raid R JOIN Lineups L ON R.Matchid=L.Matchid AND R.RaiderID=L.PlayerID  Where R.Matchid=" + Temp_matchid + " And R.halfid=2 Order by R.RaidNo", 1);
              if(chkScore.Checked)
                  dt = obj.ExeQueryStrRetDTDL("Select R.Matchid,dbo.fn_GetMatchNamePreDate(R.Matchid)MatchName,R.HalfID,MAX(Timerstart) Time,R.Raidno,MAX(dbo.fn_GetPlayerName(RaiderID)) Raider,MAX(dbo.fn_getEventName(Outcome))OutCome, MAX(ISNULL(dbo.fn_GetEventName(RaiderOutType),''))RaiderOutType,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,3),'') SpecialCase ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,4),'') KeyDefender,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,5),'') SupportedKeyDefender ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,6),'') Defenderevents ,MAX(dbo.fn_GetEventName(R.RaiderCard))Card ,dbo.fn_GetRaidbyRaidScore(R.MatchID,R.HalfID,R.RaidNo) Score,''DIP from Raid R JOIN KB_Matches M ON R.Matchid=M.Matchid JOIN Lineups L ON R.Matchid=L.Matchid AND R.RaiderID=L.PlayerID FULL JOIN OutPlayer O ON O.MatchID=R.MatchID And O.HalfID=R.HalfID And O.RaidNo=R.RaidNo FULL JOIN Events e ON e.MatchID=R.MatchID And e.HalfID=R.HalfID And e.RaidNo=R.RaidNo and E.EventId=O.EventID Where R.Matchid IN(" + cbMatches.SelectedValue + ") And R.halfid=2 GROUP by M.date, R.Matchid,R.HalfID,R.RaidNo Order by M.date desc,R.Matchid,R.HalfID desc,R.RaidNo desc", 1);
              else
                  dt = obj.ExeQueryStrRetDTDL("Select R.Matchid,dbo.fn_GetMatchNamePreDate(R.Matchid)MatchName,R.HalfID,MAX(Timerstart) Time,R.Raidno,MAX(dbo.fn_GetPlayerName(RaiderID)) Raider,MAX(dbo.fn_getEventName(Outcome))OutCome, MAX(ISNULL(dbo.fn_GetEventName(RaiderOutType),''))RaiderOutType,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,3),'') SpecialCase ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,4),'') KeyDefender,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,5),'') SupportedKeyDefender ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,6),'') Defenderevents ,MAX(dbo.fn_GetEventName(R.RaiderCard))Card ,'' Score,''DIP from Raid R JOIN KB_Matches M ON R.Matchid=M.Matchid JOIN Lineups L ON R.Matchid=L.Matchid AND R.RaiderID=L.PlayerID FULL JOIN OutPlayer O ON O.MatchID=R.MatchID And O.HalfID=R.HalfID And O.RaidNo=R.RaidNo FULL JOIN Events e ON e.MatchID=R.MatchID And e.HalfID=R.HalfID And e.RaidNo=R.RaidNo and E.EventId=O.EventID Where R.Matchid IN(" + cbMatches.SelectedValue + ") And R.halfid=2 GROUP by M.date, R.Matchid,R.HalfID,R.RaidNo Order by M.date desc,R.Matchid,R.HalfID desc,R.RaidNo desc", 1);
            
                gvRaidEvent.AutoGenerateColumns = false;
                gvRaidEvent.DataSource = dt;
            }
        }

        private void rdbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbAll.Checked == true)
            {
                if (!PageLoad) { return; }
                dt = new DataTable();
                //dt = obj.ExeQueryStrRetDTDL("Select R.Matchid,HalfID,Timerstart Time,Raidno,dbo.fn_GetPlayerName(RaiderID)+' ('+CAST(L.JercyNo AS VARCHAR)+')' Raider,dbo.fn_getEventName(Outcome)OutCome  from Raid R JOIN Lineups L ON R.Matchid=L.Matchid AND R.RaiderID=L.PlayerID  Where R.Matchid=" + Temp_matchid + " Order by R.RaidNo", 1);
                if (chkScore.Checked)
                    dt = obj.ExeQueryStrRetDTDL("Select R.Matchid,dbo.fn_GetMatchNamePreDate(R.Matchid)MatchName,R.HalfID,MAX(Timerstart) Time,R.Raidno,MAX(dbo.fn_GetPlayerName(RaiderID)) Raider,MAX(dbo.fn_getEventName(Outcome))OutCome, MAX(ISNULL(dbo.fn_GetEventName(RaiderOutType),''))RaiderOutType,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,3),'') SpecialCase ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,4),'') KeyDefender,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,5),'') SupportedKeyDefender ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,6),'') Defenderevents ,MAX(dbo.fn_GetEventName(R.RaiderCard))Card ,dbo.fn_GetRaidbyRaidScore(R.MatchID,R.HalfID,R.RaidNo) Score,''DIP from Raid R JOIN KB_Matches M ON R.Matchid=M.Matchid JOIN Lineups L ON R.Matchid=L.Matchid AND R.RaiderID=L.PlayerID FULL JOIN OutPlayer O ON O.MatchID=R.MatchID And O.HalfID=R.HalfID And O.RaidNo=R.RaidNo FULL JOIN Events e ON e.MatchID=R.MatchID And e.HalfID=R.HalfID And e.RaidNo=R.RaidNo and E.EventId=O.EventID Where R.Matchid IN(" + cbMatches.SelectedValue + ") GROUP by M.date, R.Matchid,R.HalfID,R.RaidNo Order by M.date desc,R.Matchid,R.HalfID desc,R.RaidNo desc", 1);
                else
                    dt = obj.ExeQueryStrRetDTDL("Select R.Matchid,dbo.fn_GetMatchNamePreDate(R.Matchid)MatchName,R.HalfID,MAX(Timerstart) Time,R.Raidno,MAX(dbo.fn_GetPlayerName(RaiderID)) Raider,MAX(dbo.fn_getEventName(Outcome))OutCome, MAX(ISNULL(dbo.fn_GetEventName(RaiderOutType),''))RaiderOutType,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,3),'') SpecialCase ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,4),'') KeyDefender,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,5),'') SupportedKeyDefender ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,6),'') Defenderevents ,MAX(dbo.fn_GetEventName(R.RaiderCard))Card ,'' Score,''DIP from Raid R JOIN KB_Matches M ON R.Matchid=M.Matchid JOIN Lineups L ON R.Matchid=L.Matchid AND R.RaiderID=L.PlayerID FULL JOIN OutPlayer O ON O.MatchID=R.MatchID And O.HalfID=R.HalfID And O.RaidNo=R.RaidNo FULL JOIN Events e ON e.MatchID=R.MatchID And e.HalfID=R.HalfID And e.RaidNo=R.RaidNo and E.EventId=O.EventID Where R.Matchid IN(" + cbMatches.SelectedValue + ") GROUP by M.date, R.Matchid,R.HalfID,R.RaidNo Order by M.date desc,R.Matchid,R.HalfID desc,R.RaidNo desc", 1);
                
                gvRaidEvent.AutoGenerateColumns = false;
                gvRaidEvent.DataSource = dt;
            }
        }
        double CurTimeinSec = 0;
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cbRaiderOutType.SelectedValue) != 0 && (Convert.ToInt32(cbOutcome.SelectedValue) == 12 || Convert.ToInt32(cbOutcome.SelectedValue) == 13 || Convert.ToInt32(cbOutcome.SelectedValue) == 14)) { MessageBox.Show("Successfull Raid Please remove RaiderOutType"); return; }
                if (CurRaidno == 0) { MessageBox.Show("Select Raid"); return; }
                int Raidercards = 0, Excape = 0, Raiderouttype = 0;

                #region Check Special Case

                int DoorDie = 0, BonusPoint = 0, SuperRaid = 0, SuperTackle = 0, Allout = 0, BonusType = 0;
                if (chkDoorDie.Checked == true) DoorDie = 1;
                if (chkBonusPoint.Checked == true) BonusPoint = 1;
                if (chkSuperRaid.Checked == true) SuperRaid = 1;
                if (chkSuperTackle.Checked == true) SuperTackle = 1;
                if (chkAllOut.Checked == true) Allout = 1;
                if (cbRaiderOutType.SelectedValue != null)
                { Raiderouttype = Convert.ToInt32(cbRaiderOutType.SelectedValue); }
                #endregion

                if (cbRaiderCards.SelectedIndex != -1)
                {
                    Raidercards = Convert.ToInt32(cbRaiderCards.SelectedValue);
                }
                if (cbRaiderOutType.SelectedIndex != -1)
                {
                    if (Convert.ToInt32(Raiderouttype) == 12 || Convert.ToInt32(Raiderouttype) == 13 || Convert.ToInt32(Raiderouttype) == 14)
                        Excape = Convert.ToInt32(Raiderouttype);
                }
                setEndtime = 0;
                if (Ins_Upd_flag == "Insert")
                {
                    #region Insert

                    try
                    {
                        //try
                        //{
                        //    CurTimeinSec = Convert.ToDouble(obj.ExeQueryStrRetStrDL("Select Time From Raid Where Matchid=" + cbMatches.SelectedValue + " And HalfID=" + halfid + " AND RaidNo=" + CurRaidno + "", 1));
                        //}
                        //catch { CurTimeinSec = 0; }
                        string strTime = "", EnTime = "";
                        try
                        {
                            strTime = "00:" + dtp_StartTime.Value.Minute.ToString("D2") + ":" + dtp_StartTime.Value.Second.ToString("D2");
                            EnTime = "00:" + dtp_EndTime.Value.Minute.ToString("D2") + ":" + dtp_EndTime.Value.Second.ToString("D2");

                            CurTimeinSec = TimeSpan.Parse("00:" + dtp_StartTime.Value.Minute.ToString("D2") + ":" + dtp_StartTime.Value.Second.ToString("D2")).TotalSeconds;

                        }
                        catch { }

                        obj.ExeQueryRetBooDL("Update Raid Set RaiderId=" + cbRaider.SelectedValue + ",BonusLine=" + BonusPoint + ",OutCome=" + cbOutcome.SelectedValue + ",SuperRaid=" + SuperRaid + ",SuperTackle=" + SuperTackle + ",DoorDie=" + DoorDie + ",RaiderOutType=" + Raiderouttype + ",[Escape]=" + Excape + ",Allout=" + Allout + ",RaiderCard=" + Raidercards + ",BLPX=" + CommonCls.BLPX + ",BLPY=" + CommonCls.BLPY + ",RaidDIP=" + txtRaidDIP.Text + ",DefDIP=" + txtDefDIP.Text + ",BonusType=" + BonusType + ",Time=" + CurTimeinSec + ",TimerStart='" + strTime + "',TimerEnd='" + EnTime + "' Where MatchID=" + Temp_matchid + " AND RaidNo=" + CurRaidno + "", 1);

                        try
                        {
                            objDL.ExeQueryRetBooDL("delete from SuspendedPlayer Where MatchID=" + Temp_matchid + " AND HalfID=" + halfid + " AND RaidNo=" + CurRaidno + " AND PlayerId=" + cbRaider.SelectedValue + "", 1);

                            if (Raidercards != 0)
                            {
                                int iskill = 0;
                                 if (Raidercards == 24)
                                    objDL.ExeQueryRetBooDL("Insert Into SuspendedPlayer(MatchID,HalfID,RaidNo,PlayerId,Clubid,Issuspend,iskill) Values (" + Temp_matchid + "," + halfid + "," + CurRaidno + "," + cbRaider.SelectedValue + "," + RaidClubId + ",1," + 0 + ")", 1);

                                else if (Raidercards == 25)
                                    objDL.ExeQueryRetBooDL("Insert Into SuspendedPlayer(MatchID,HalfID,RaidNo,PlayerId,Clubid,Issuspend,iskill) Values (" + Temp_matchid + "," + halfid + "," + CurRaidno + "," + cbRaider.SelectedValue + "," + RaidClubId + ",1," + 1 + ")", 1);
                            }
                        }
                        catch { }
                        foreach (DataRow dr in CommonCls.DTListEvents.Rows)
                        {
                            obj.ExeQueryRetBooDL("Insert Into Events(MatchID,HalfID,RaidNo,EventId,EventType,PX,PY,StartFrame,Initiator,Time) Values (" + dr["MatchID"] + "," + dr["HalfID"] + "," + dr["RaidNo"] + "," + dr["EventId"] + "," + dr["EventType"] + "," + dr["PX"] + "," + dr["PY"] + ",'" + dr["setEndtime"] + "'," + (dr["Initiator"].ToString() == "" ? "null" : dr["Initiator"]) + "," + CurTimeinSec + ")", 1);

                            try
                            {
                                int cnt = obj.ExeQueryStrDL("Select ISNULL(Count(Raidno),0)+1 From tblCorrectedRaid where Matchid=" + cbMatches.SelectedValue + " And HalfID=" + halfid + " AND RaidNo=" + RaidNo + "", 1);
                                obj.ExeQueryRetBooDL("Insert into tblCorrectedRaid (Matchid,HalfID,Raidno,EventID,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + cbMatches.SelectedValue + "," + halfid + "," + CurRaidno + "," + dr["EventId"] + "," + cnt + ",'Events','" + System.DateTime.Now + "',1,0,0)", 1);
                            }
                            catch { }
                        }
                    }
                    catch { }

                    try
                    {
                        int Isout = 0, Israiderout = 0;
                        int orderNo = 0;
                        obj.ExeQueryRetBooDL("Delete from OutPlayerRef where MatchID=" + Temp_matchid + " and RaidNo=" + CurRaidno + "", 1);
                        dt = new DataTable();
                        dt = obj.ExeQueryStrRetDTDL("Select *,ROW_NUMBER() OVER(ORDER BY raidno,orderno) Rank from OutPlayerRef Where Matchid=" + Temp_matchid + " And RaidNo=" + (CurRaidno - 1) + " And PlayerID Not IN(Select PlayerID from Innerplayer Where Matchid=" + Temp_matchid + " AND RaidNo=" + (CurRaidno - 1) + ")", 1);
                        foreach (DataRow dr in dt.Rows)
                        {
                            int Clubid = obj.ExeQueryStrDL("Select ClubID from Lineups Where MatchID=" + Temp_matchid + " And PlayerID=" + dr["PlayerId"] + "", 1); // TeamID
                            obj.ExeQueryRetBooDL("Insert Into OutPlayerRef(MatchID,HalfID,RaidNo,PlayerId,Clubid,OrderNo) Values (" + Temp_matchid + "," + halfid + "," + CurRaidno + "," + dr["PlayerId"] + "," + dr["Clubid"] + "," + dr["Rank"] + ")", 1);
                        }

                        orderNo = dt.Rows.Count;

                        CommonCls.DTListOutPlayer.DefaultView.Sort = "EventID asc";
                        CommonCls.DTListOutPlayer = CommonCls.DTListOutPlayer.DefaultView.ToTable(true);

                        #region OutPlayer
                        foreach (DataRow dr in CommonCls.DTListOutPlayer.Rows)
                        {
                            orderNo = orderNo + 1;
                            Isout = 0;
                            if (Convert.ToInt32(cbRaider.SelectedValue) == Convert.ToInt32(dr["PlayerId"]) && Convert.ToInt32(cbOutcome.SelectedValue) == 15)
                            {
                                Isout = 1;
                                Israiderout = 0;
                            }
                            else if (Convert.ToInt32(cbRaider.SelectedValue) == Convert.ToInt32(dr["PlayerId"]) && Convert.ToInt32(cbOutcome.SelectedValue) != 15)
                            {
                                Isout = 0;
                                Israiderout = 0;
                            }
                            else if (Convert.ToInt32(dr["OutType"]) == 17 || Convert.ToInt32(dr["OutType"]) == 18)
                                Isout = 1;
                            else if (cbRaiderOutType.SelectedIndex != -1 && Convert.ToInt32(cbRaiderOutType.SelectedValue) == 17 || Convert.ToInt32(cbRaiderOutType.SelectedValue) == 18 || Convert.ToInt32(cbRaiderOutType.SelectedValue) == 19 || Convert.ToInt32(cbRaiderOutType.SelectedValue) == 20 || Convert.ToInt32(cbRaiderOutType.SelectedValue) == 21 || Convert.ToInt32(cbRaiderOutType.SelectedValue) == 22)
                            {
                                Isout = 0;
                                Israiderout = 1;
                            }
                            else if (Convert.ToInt32(cbRaider.SelectedValue) != Convert.ToInt32(dr["PlayerId"]) && (Convert.ToInt32(dr["OutType"]) == 17 || Convert.ToInt32(dr["OutType"]) == 18))
                            {
                                Isout = 1;
                                Israiderout = 0;
                            }
                            else if (Convert.ToInt32(cbRaider.SelectedValue) != Convert.ToInt32(dr["PlayerId"]) && Convert.ToInt32(cbOutcome.SelectedValue) == 15)
                                Isout = 0;
                            else if (Convert.ToInt32(cbRaider.SelectedValue) != Convert.ToInt32(dr["PlayerId"]) && (Convert.ToInt32(cbOutcome.SelectedValue) == 12 || Convert.ToInt32(cbOutcome.SelectedValue) == 13 || Convert.ToInt32(cbOutcome.SelectedValue) == 14 || Convert.ToInt32(cbOutcome.SelectedValue) == 17 || Convert.ToInt32(cbOutcome.SelectedValue) == 18))
                                Isout = 1;
                            obj.ExeQueryRetBooDL("Insert Into OutPlayer(MatchID,HalfID,RaidNo,EventId,PlayerId,KeyDefender,SupportedKeyDefender,IsOut,OutType,ISInitiator) Values (" + dr["MatchID"] + "," + dr["HalfID"] + "," + dr["RaidNo"] + "," + dr["EventId"] + "," + dr["PlayerId"] + "," + dr["KeyDefender"] + "," + dr["SupportedKeyDefender"] + "," + Isout + "," + dr["OutType"] + "," + dr["ISInitiator"] + ")", 1);
                            if (Isout == 1 && CommonCls.RaiderOutType != 24 && CommonCls.RaiderOutType != 25)
                            {
                                int Clubid = obj.ExeQueryStrDL("Select ClubID from Lineups Where MatchID=" + Temp_matchid + " And PlayerID=" + dr["PlayerId"] + "", 1); // TeamID
                                obj.ExeQueryRetBooDL("Insert Into OutPlayerRef(MatchID,HalfID,RaidNo,PlayerId,Clubid,orderNo) Values (" + dr["MatchID"] + "," + dr["HalfID"] + "," + dr["RaidNo"] + "," + dr["PlayerId"] + "," + Clubid + "," + orderNo + ")", 1);
                            }
                            if (Convert.ToInt32(cbRaiderOutType.SelectedValue) == 24 || Convert.ToInt32(cbRaiderOutType.SelectedValue) == 25)
                            {
                                int iskill = 0;
                                if (Convert.ToInt32(cbRaiderOutType.SelectedValue) == 25)
                                    iskill = 1;
                                int Clubid = obj.ExeQueryStrDL("Select ClubID from Lineups Where MatchID=" + Temp_matchid + " And PlayerID=" + dr["PlayerId"] + "", 1); // TeamID
                                obj.ExeQueryRetBooDL("Insert Into SuspendedPlayer(MatchID,HalfID,RaidNo,PlayerId,Clubid,Issuspend,iskill) Values (" + dr["MatchID"] + "," + dr["HalfID"] + "," + dr["RaidNo"] + "," + dr["PlayerId"] + "," + Clubid + ",1," + iskill + ")", 1);
                            }
                        }

                        if (Convert.ToInt32(cbOutcome.SelectedValue) == 15)
                        {
                            orderNo = obj.ExeQueryStrDL("Select ISNULL(Max(Orderno),0)+1  from OutPlayerRef Where Matchid=" + Temp_matchid + " And RaidNo=" + (CurRaidno) + "", 1);

                            obj.ExeQueryRetBooDL("Insert Into OutPlayerRef(MatchID,HalfID,RaidNo,PlayerId,Clubid,orderNo) Values (" + Temp_matchid + "," + halfid + "," + CurRaidno + "," + cbRaider.SelectedValue + "," + RaidClubId + "," + orderNo + ")", 1);
                        }

                        if (Convert.ToInt32(cbRaiderCards.SelectedValue) == 24 || Convert.ToInt32(cbRaiderCards.SelectedValue) == 25)
                        {
                            int iskill = 0;
                            if (Convert.ToInt32(cbRaiderOutType.SelectedValue) == 25)
                                iskill = 1;
                            obj.ExeQueryRetBooDL("Insert Into SuspendedPlayer(MatchID,HalfID,RaidNo,PlayerId,Clubid,Issuspend,iskill) Values (" + Temp_matchid + "," + halfid + "," + CurRaidno + "," + cbRaider.SelectedValue + "," + RaidClubId + ",1," + iskill + ")", 1);
                        }
                        #endregion

                        obj.ExeQueryRetBooDL("Insert into UserTrackerQC (Matchid,HalfID,RaidNo,UpdateTime,UserId,isDelete)values(" + Temp_matchid + "," + halfid + "," + CurRaidno + ",'" + System.DateTime.Now + "'," + CommonCls.UserLoginID + ",0)", 1);

                        try
                        {
                            string CurrentScore = obj.ExeQueryStrRetStrDL("Select dbo.fn_GetCurrentRaidScore(" + Temp_matchid + "," + halfid + "," + CurRaidno + ")", 1);
                            objDL.ExeQueryRetBooDL("Update Raid set raidpoint=" + CurrentScore.Split('-')[0] + ",defencepoint=" + CurrentScore.Split('-')[1] + "  Where Matchid=" + Temp_matchid + " And HalfID=" + halfid + " And RaidNo=" + CurRaidno + "", 1);
                        }
                        catch { }

                        try
                        {
                            int cnt = obj.ExeQueryStrDL("Select ISNULL(Count(Raidno),0)+1 From tblCorrectedRaid where Matchid=" + cbMatches.SelectedValue + " And HalfID=" + halfid + " AND RaidNo=" + CurRaidno + "", 1);
                            obj.ExeQueryRetBooDL("Insert into tblCorrectedRaid (Matchid,HalfID,Raidno,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + cbMatches.SelectedValue + "," + halfid + "," + CurRaidno + "," + cnt + ",'Raid','" + System.DateTime.Now + "',0,1,0)", 1);
                        }
                        catch { }
                        MessageBox.Show("Update Successfully", "Kabaddi Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        reset();
                    }
                    catch { }
                    #endregion
                }
                if (Ins_Upd_flag == "Update")
                {
                    int lastoutcome = objDL.ExeQueryStrDL("select Outcome from raid Where MatchID=" + Temp_matchid + " AND RaidNo=" + CurRaidno + "", 1);
                    #region Update

                    string strTime = "", EnTime = "";
                    try
                    {
                        strTime = "00:" + dtp_StartTime.Value.Minute.ToString("D2") + ":" + dtp_StartTime.Value.Second.ToString("D2");
                        EnTime = "00:" + dtp_EndTime.Value.Minute.ToString("D2") + ":" + dtp_EndTime.Value.Second.ToString("D2");

                        CurTimeinSec = TimeSpan.Parse("00:" + dtp_StartTime.Value.Minute.ToString("D2") + ":" + dtp_StartTime.Value.Second.ToString("D2")).TotalSeconds;

                    }
                    catch { }


                    if (obj.ExeQueryRetBooDL("Update Raid Set RaiderId=" + cbRaider.SelectedValue + ",BonusLine=" + BonusPoint + ",OutCome=" + cbOutcome.SelectedValue + ",SuperRaid=" + SuperRaid + ",SuperTackle=" + SuperTackle + ",DoorDie=" + DoorDie + ",RaiderOutType=" + Raiderouttype + ",[Escape]=" + Excape + ",Allout=" + Allout + ",RaiderCard=" + Raidercards + ",BLPX=" + CommonCls.BLPX + ",BLPY=" + CommonCls.BLPY + ",BonusType=" + BonusType + ",Time=" + CurTimeinSec + ",TimerStart='" + strTime + "',TimerEnd='" + EnTime + "' Where MatchID=" + Temp_matchid + " AND RaidNo=" + CurRaidno + "", 1))
                    {
                        try
                        {
                            objDL.ExeQueryRetBooDL("delete from SuspendedPlayer Where MatchID=" + Temp_matchid + " AND HalfID=" + halfid + " AND RaidNo=" + CurRaidno + " AND PlayerId=" + cbRaider.SelectedValue + "", 1);

                            if (Raidercards != 0)
                            {
                                int iskill = 0;
                                if (Raidercards == 24)
                                    objDL.ExeQueryRetBooDL("Insert Into SuspendedPlayer(MatchID,HalfID,RaidNo,PlayerId,Clubid,Issuspend,iskill) Values (" + Temp_matchid + "," + halfid + "," + CurRaidno + "," + cbRaider.SelectedValue + "," + RaidClubId + ",1," + 0 + ")", 1);

                                else if (Raidercards == 25)
                                    objDL.ExeQueryRetBooDL("Insert Into SuspendedPlayer(MatchID,HalfID,RaidNo,PlayerId,Clubid,Issuspend,iskill) Values (" + Temp_matchid + "," + halfid + "," + CurRaidno + "," + cbRaider.SelectedValue + "," + RaidClubId + ",1," + 1 + ")", 1);
                            }
                        }
                        catch { }
                        try
                        {
                            if ((RaidOutPlyerID != Convert.ToInt32(cbRaider.SelectedValue) || PreviousOutcome != Convert.ToInt32(cbOutcome.SelectedValue)) && Convert.ToInt32(cbOutcome.SelectedValue) == 15)
                            {
                                obj.ExeQueryRetBooDL("Delete From OutPlayerref Where MatchID=" + Temp_matchid + " AND RaidNo=" + CurRaidno + " And PlayerID IN(" + RaidOutPlyerID + ")", 1);
                                int orderNo = obj.ExeQueryStrDL("Select ISNULL(Max(Orderno),0)+1  from OutPlayerRef Where Matchid=" + Temp_matchid + " And RaidNo=" + (CurRaidno) + "", 1);
                                obj.ExeQueryRetBooDL("Insert INTO OutPlayerref (Matchid,Halfid,RaidNo,PlayerId,Clubid,Orderno) Values(" + Temp_matchid + "," + halfid + "," + CurRaidno + "," + cbRaider.SelectedValue + "," + RaidClubId + "," + orderNo + ")", 1);
                            }
                            else if (PreviousOutcome == 15 && Convert.ToInt32(cbOutcome.SelectedValue) != 15)
                                obj.ExeQueryRetBooDL("Delete From OutPlayerref Where MatchID=" + Temp_matchid + " AND RaidNo=" + CurRaidno + " And PlayerID IN(" + RaidOutPlyerID + ")", 1);

                        }
                        catch { }
                        if (Convert.ToInt32(cbEvents.SelectedValue) == 62)
                        {
                            reset(); return;
                        }
                        int Initiator = 0;
                        try
                        {
                            Initiator = Convert.ToInt32(lbInitiator.SelectedValue);
                        }
                        catch { }
                        if (obj.ExeQueryRetBooDL("Update Events Set EventType=" + cbEvents.SelectedValue + ",Initiator=" + Initiator + ",StartFrame=" + setEndtime + ",PX=" + CommonCls.PX + ",PY=" + CommonCls.PY + " Where MatchID=" + Temp_matchid + " AND RaidNo=" + CurRaidno + " And EventId=" + CurEventID + "", 1))
                        {
                            string OutPlayerlist = obj.ExeQueryStrRetStrDL("Select STUFF((SELECT ',' + CAST(PlayerID as NVARCHAR(MAX)) from OutPlayer Where Matchid=" + Temp_matchid + " And RaidNo=" + (CurRaidno) + " and eventid=" + CurEventID + " and isout=1 FOR XML PATH('')), 1, 1, '')V", 1);



                            int PlyerID = obj.ExeQueryStrDL("Select PlayerID From OutPlayer Where MatchID=" + Temp_matchid + " AND RaidNo=" + CurRaidno + " And EventId=" + CurEventID + "", 1);
                            obj.ExeQueryRetBooDL("Delete From OutPlayerref Where MatchID=" + Temp_matchid + " AND RaidNo=" + CurRaidno + " And PlayerID IN(" + OutPlayerlist + ")", 1);

                            if (obj.ExeQueryRetBooDL("Delete From OutPlayer Where MatchID=" + Temp_matchid + " AND RaidNo=" + CurRaidno + " And EventId=" + CurEventID + "", 1))
                            {

                                int IsOut = 0;
                                int eventtype = Convert.ToInt32(cbEvents.SelectedValue);

                                if (eventtype == 17 || eventtype == 18 || eventtype == 30)
                                {
                                    int orderNo = obj.ExeQueryStrDL("Select ISNULL(Max(Orderno),0)+1  from OutPlayerRef Where Matchid=" + Temp_matchid + " And RaidNo=" + (CurRaidno) + "", 1);

                                    if (lbLineOutRaider.SelectedItems.Count > 0)
                                    {
                                        // obj.ExeQueryRetBooDL("Update OutPlayer Set PlayerId=" + lbLineOutRaider.SelectedValue + ",KeyDefender=0,SupportedKeyDefender=0,IsOut=1,OutType=" + cbEvents.SelectedValue + " Where MatchID=" + Temp_matchid + " AND RaidNo=" + CurRaidno + " And EventId=" + CurEventID + "", 1);
                                        obj.ExeQueryRetBooDL("Insert INTO OutPlayer (MatchID,HalfID,RaidNo,EventId,PlayerId,KeyDefender,SupportedKeyDefender,IsOut,OutType,ISInitiator) Values(" + Temp_matchid + "," + halfid + "," + CurRaidno + " ," + CurEventID + "," + lbLineOutRaider.SelectedValue + ",0,0,1," + cbEvents.SelectedValue + ",0)", 1);
                                        obj.ExeQueryRetBooDL("Insert INTO OutPlayerref (Matchid,Halfid,RaidNo,PlayerId,Clubid,Orderno) Values(" + Temp_matchid + "," + halfid + "," + CurRaidno + "," + lbLineOutRaider.SelectedValue + "," + RaidClubId + "," + orderNo + ")", 1);
                                    }
                                    else if (lbLineOutDefender.SelectedItems.Count > 0)
                                    {
                                        //obj.ExeQueryRetBooDL("Update OutPlayer Set PlayerId=" + lbLineOutDefender.SelectedValue + ",KeyDefender=1,SupportedKeyDefender=0,IsOut=1,OutType=" + cbEvents.SelectedValue + " Where MatchID=" + Temp_matchid + " AND RaidNo=" + CurRaidno + " And EventId=" + CurEventID + "", 1);
                                        obj.ExeQueryRetBooDL("Insert INTO OutPlayer (MatchID,HalfID,RaidNo,EventId,PlayerId,KeyDefender,SupportedKeyDefender,IsOut,OutType,ISInitiator) Values(" + Temp_matchid + "," + halfid + "," + CurRaidno + " ," + CurEventID + "," + lbLineOutDefender.SelectedValue + ",1,0,1," + cbEvents.SelectedValue + ",0)", 1);
                                        obj.ExeQueryRetBooDL("Insert INTO OutPlayerref (Matchid,Halfid,RaidNo,PlayerId,Clubid,Orderno) Values(" + Temp_matchid + "," + halfid + "," + CurRaidno + "," + lbLineOutDefender.SelectedValue + "," + DefenceClubId + "," + orderNo + ")", 1);
                                    }
                                }

                                else if (eventtype == 23 || eventtype == 24 || eventtype == 25)
                                {
                                    int orderNo = obj.ExeQueryStrDL("Select ISNULL(Max(Orderno),0)+1  from OutPlayerRef Where Matchid=" + Temp_matchid + " And RaidNo=" + (CurRaidno) + "", 1);

                                    if (lbLineOutRaider.SelectedItems.Count > 0)
                                    {
                                        int Clubid = obj.ExeQueryStrDL("Select dbo.Fn_GetPlayerTeamid(" + Temp_matchid + "," + PlyerID + ")", 1);

                                        // obj.ExeQueryRetBooDL("Update OutPlayer Set PlayerId=" + lbLineOutRaider.SelectedValue + ",KeyDefender=0,SupportedKeyDefender=0,IsOut=1,OutType=" + cbEvents.SelectedValue + " Where MatchID=" + Temp_matchid + " AND RaidNo=" + CurRaidno + " And EventId=" + CurEventID + "", 1);
                                        obj.ExeQueryRetBooDL("Insert INTO OutPlayer (MatchID,HalfID,RaidNo,EventId,PlayerId,KeyDefender,SupportedKeyDefender,IsOut,OutType,ISInitiator) Values(" + Temp_matchid + "," + halfid + "," + CurRaidno + " ," + CurEventID + "," + lbLineOutRaider.SelectedValue + ",0,0,0," + cbEvents.SelectedValue + ",0)", 1);
                                        if (eventtype == 24 || eventtype == 25)
                                        {
                                            objDL.ExeQueryRetBooDL("delete from SuspendedPlayer Where MatchID=" + Temp_matchid + " AND HalfID=" + halfid + " AND RaidNo=" + CurRaidno + " AND PlayerId=" + PlyerID + "", 1);

                                            if (eventtype == 24)
                                                objDL.ExeQueryRetBooDL("Insert Into SuspendedPlayer(MatchID,HalfID,RaidNo,PlayerId,Clubid,Issuspend,iskill) Values (" + Temp_matchid + "," + halfid + "," + CurRaidno + "," + PlyerID + "," + Clubid + ",1," + 0 + ")", 1);

                                            else if (eventtype == 25)
                                                objDL.ExeQueryRetBooDL("Insert Into SuspendedPlayer(MatchID,HalfID,RaidNo,PlayerId,Clubid,Issuspend,iskill) Values (" + Temp_matchid + "," + halfid + "," + CurRaidno + "," + PlyerID + "," + Clubid + ",1," + 1 + ")", 1);
                           
                                            //   obj.ExeQueryRetBooDL("Update SuspendedPlayer set PlayerId=" + lbLineOutRaider.SelectedValue + ",ClubId=" + Clubid + " Where Matchid=" + Temp_matchid + " And RaidNo=" + (CurRaidno) + " And PlayerID=" + PlyerID + "", 1);
                                        }
                                        else if (eventtype == 23)
                                            obj.ExeQueryRetBooDL("Delete from SuspendedPlayer Where Matchid=" + Temp_matchid + " And RaidNo=" + (CurRaidno) + " And PlayerID=" + PlyerID + "", 1);                                       
                                    }
                                    else if (lbLineOutDefender.SelectedItems.Count > 0)
                                    {
                                        int Clubid = obj.ExeQueryStrDL("Select dbo.Fn_GetPlayerTeamid(" + Temp_matchid + "," + PlyerID + ")", 1);


                                        obj.ExeQueryRetBooDL("Insert INTO OutPlayer (MatchID,HalfID,RaidNo,EventId,PlayerId,KeyDefender,SupportedKeyDefender,IsOut,OutType,ISInitiator) Values(" + Temp_matchid + "," + halfid + "," + CurRaidno + " ," + CurEventID + "," + lbLineOutDefender.SelectedValue + ",0,0,0," + cbEvents.SelectedValue + ",0)", 1);
                                        if (eventtype == 24 || eventtype == 25)
                                        {
                                            objDL.ExeQueryRetBooDL("delete from SuspendedPlayer Where MatchID=" + Temp_matchid + " AND HalfID=" + halfid + " AND RaidNo=" + CurRaidno + " AND PlayerId=" + PlyerID + "", 1);

                                            if (eventtype == 24)
                                                objDL.ExeQueryRetBooDL("Insert Into SuspendedPlayer(MatchID,HalfID,RaidNo,PlayerId,Clubid,Issuspend,iskill) Values (" + Temp_matchid + "," + halfid + "," + CurRaidno + "," + PlyerID + "," + Clubid + ",1," + 0 + ")", 1);

                                            else if (eventtype == 25)
                                                objDL.ExeQueryRetBooDL("Insert Into SuspendedPlayer(MatchID,HalfID,RaidNo,PlayerId,Clubid,Issuspend,iskill) Values (" + Temp_matchid + "," + halfid + "," + CurRaidno + "," + PlyerID + "," + Clubid + ",1," + 1 + ")", 1);
                           

                                         //   obj.ExeQueryRetBooDL("Update SuspendedPlayer set PlayerId=" + lbLineOutDefender.SelectedValue + ",ClubId=" + Clubid + " Where Matchid=" + Temp_matchid + " And RaidNo=" + (CurRaidno) + " And PlayerID=" + PlyerID + "", 1);
                                        }
                                        else if (eventtype == 23)
                                            obj.ExeQueryRetBooDL("Delete from SuspendedPlayer Where Matchid=" + Temp_matchid + " And RaidNo=" + (CurRaidno) + " And PlayerID=" + PlyerID + "", 1);                                       
                                   
                                    }
                                }
                                else if (eventtype == 1 || eventtype == 2 || eventtype == 3 || eventtype == 4 || eventtype == 5 || eventtype == 6 || eventtype == 7 || eventtype == 8 || eventtype == 33 || eventtype == 34 || eventtype == 35 || eventtype == 55 || eventtype == 56 || eventtype == 57 || eventtype == 58 || eventtype == 66 || eventtype == 67 || eventtype == 68 || eventtype == 69)
                                {
                                    //if (Convert.ToInt32(cbOutcome.SelectedValue) == 15)
                                    //    IsOut = 1;
                                    //else
                                    //    IsOut = 0;
                                    foreach (DataRowView drview in lbDefender.SelectedItems)
                                    {
                                        string aa = drview["playerid"].ToString();
                                        IsOut = 0;

                                        int touchortackle = 0;
                                        touchortackle = objDL.ExeQueryStrDL("select ID From EventMaster where EventGroup IN('Touch','Tackle') and ID=" + cbEvents.SelectedValue + "", 1);
                                        if (touchortackle == 1 && Convert.ToInt32(cbOutcome.SelectedValue) == 15)
                                            IsOut = 0;
                                        else if (Convert.ToInt32(CommonCls.RaiderID) == Convert.ToInt32(drview["PlayerId"]) && Convert.ToInt32(cbOutcome.SelectedValue) == 15)
                                        {
                                            IsOut = 1;
                                            //Israiderout = 0;
                                        }
                                        else if (Convert.ToInt32(CommonCls.RaiderID) == Convert.ToInt32(drview["PlayerId"]) && Convert.ToInt32(cbOutcome.SelectedValue) != 15)
                                        {
                                            IsOut = 0;
                                            //Israiderout = 0;
                                        }
                                        else if (RaiderClick && (Convert.ToInt32(cbRaiderOutType.SelectedValue) == 17 || Convert.ToInt32(cbRaiderOutType.SelectedValue) == 18))
                                        {
                                            IsOut = 1;
                                            //Israiderout = 1;
                                        }
                                        else if (RaiderClick && (Convert.ToInt32(cbRaiderOutType.SelectedValue) == 17 || Convert.ToInt32(cbRaiderOutType.SelectedValue) == 18 || Convert.ToInt32(cbRaiderOutType.SelectedValue) == 19 || Convert.ToInt32(cbRaiderOutType.SelectedValue) == 20 || Convert.ToInt32(cbRaiderOutType.SelectedValue) == 21 || Convert.ToInt32(cbRaiderOutType.SelectedValue) == 22))
                                        {
                                            IsOut = 0;
                                            //Israiderout = 1;
                                        }
                                        else if (Convert.ToInt32(CommonCls.RaiderID) != Convert.ToInt32(drview["PlayerId"]) && (Convert.ToInt32(cbRaiderOutType.SelectedValue) == 17 || Convert.ToInt32(cbRaiderOutType.SelectedValue) == 18))
                                        {
                                            IsOut = 1;
                                            //Israiderout = 0;
                                        }
                                        else if (Convert.ToInt32(CommonCls.RaiderID) != Convert.ToInt32(drview["PlayerId"]) && (Convert.ToInt32(cbRaiderOutType.SelectedValue) == 17 || Convert.ToInt32(cbRaiderOutType.SelectedValue) == 18))
                                        {
                                            IsOut = 1;
                                            //Israiderout = 0;
                                        }
                                        else if (Convert.ToInt32(CommonCls.RaiderID) != Convert.ToInt32(drview["PlayerId"]) && Convert.ToInt32(cbOutcome.SelectedValue) == 15)
                                            IsOut = 0;
                                        else if (Convert.ToInt32(CommonCls.RaiderID) != Convert.ToInt32(drview["PlayerId"]) && (Convert.ToInt32(cbOutcome.SelectedValue) == 12 || Convert.ToInt32(cbOutcome.SelectedValue) == 13 || Convert.ToInt32(cbOutcome.SelectedValue) == 14 || Convert.ToInt32(cbOutcome.SelectedValue) == 17 || Convert.ToInt32(cbOutcome.SelectedValue) == 18))
                                            IsOut = 1;
                                        //obj.ExeQueryRetBooDL("Update OutPlayer Set PlayerId=" + drview["PlayerID"].ToString() + ",KeyDefender=0,SupportedKeyDefender=0,IsOut=" + IsOut + ",OutType=" + cbEvents.SelectedValue + " Where MatchID=" + Temp_matchid + " AND RaidNo=" + CurRaidno + " And EventId=" + CurEventID + "", 1);
                                        obj.ExeQueryRetBooDL("Insert INTO OutPlayer (MatchID,HalfID,RaidNo,EventId,PlayerId,KeyDefender,SupportedKeyDefender,IsOut,OutType,ISInitiator) Values(" + Temp_matchid + "," + halfid + "," + CurRaidno + " ," + CurEventID + "," + drview["playerid"].ToString() + ",0,0," + IsOut + "," + cbEvents.SelectedValue + ",0)", 1);
                                        int orderNo = obj.ExeQueryStrDL("Select ISNULL(Max(Orderno),0)+1  from OutPlayerRef Where Matchid=" + Temp_matchid + " And RaidNo=" + (CurRaidno) + "", 1);
                                        //  DataTable DTOut = new DataTable();
                                        //DTOut = obj.ExeQueryStrRetDTDL("Select STUFF((SELECT ',' + CAST(PlayerID as NVARCHAR(MAX)) from OutPlayer Where Matchid=" + Temp_matchid + " And RaidNo=" + (CurRaidno) + " and eventid=" + CurEventID + " and isout=1 FOR XML PATH('')), 1, 1, '')V", 1);

                                        //obj.ExeQueryRetBooDL("Delete From OutPlayerref Where MatchID=" + Temp_matchid + " AND RaidNo=" + CurRaidno + " And PlayerID IN(" + OutPlayerlist + ")", 1);
                                        if (IsOut == 1)
                                        {
                                            obj.ExeQueryRetBooDL("Insert INTO OutPlayerref (MatchID,HalfID,RaidNo,PlayerId,Clubid,orderNo) Values(" + Temp_matchid + "," + halfid + "," + CurRaidno + " ," + drview["playerid"].ToString() + "," + DefenceClubId + "," + orderNo + ")", 1);
                                        }
                                    }
                                    if (lbInitiator.SelectedIndex != -1)
                                    {
                                        #region Initiator Insert
                                        IsOut = 0;
                                        if (Convert.ToInt32(CommonCls.RaiderID) == Initiator && Convert.ToInt32(cbOutcome.SelectedValue) == 15)
                                        {
                                            IsOut = 1;
                                            //Israiderout = 0;
                                        }
                                        else if (Convert.ToInt32(CommonCls.RaiderID) == Initiator && Convert.ToInt32(cbOutcome.SelectedValue) != 15)
                                        {
                                            IsOut = 0;
                                            //Israiderout = 0;
                                        }
                                        else if (RaiderClick && (CommonCls.RaiderOutType == 17 || CommonCls.RaiderOutType == 18) && (Convert.ToInt32(cbRaiderOutType.SelectedValue) == 17 || Convert.ToInt32(cbRaiderOutType.SelectedValue) == 18))
                                        {
                                            IsOut = 1;
                                            //Israiderout = 1;
                                        }
                                        else if (RaiderClick && CommonCls.RaiderOutType == 17 || CommonCls.RaiderOutType == 18 || CommonCls.RaiderOutType == 19 || CommonCls.RaiderOutType == 20 || CommonCls.RaiderOutType == 21 || CommonCls.RaiderOutType == 22)
                                        {
                                            IsOut = 0;
                                            //Israiderout = 1;
                                        }
                                        else if (Convert.ToInt32(CommonCls.RaiderID) != Initiator && (Convert.ToInt32(cbRaiderOutType.SelectedValue) == 17 || Convert.ToInt32(cbRaiderOutType.SelectedValue) == 18))
                                        {
                                            IsOut = 1;
                                            //Israiderout = 0;
                                        }
                                        else if (Convert.ToInt32(CommonCls.RaiderID) != Initiator && (Convert.ToInt32(cbRaiderOutType.SelectedValue) == 17 || Convert.ToInt32(cbRaiderOutType.SelectedValue) == 18))
                                        {
                                            IsOut = 1;
                                            //Israiderout = 0;
                                        }
                                        else if (Convert.ToInt32(CommonCls.RaiderID) != Initiator && Convert.ToInt32(cbOutcome.SelectedValue) == 15)
                                            IsOut = 0;
                                        else if (Convert.ToInt32(CommonCls.RaiderID) != Initiator && (Convert.ToInt32(cbOutcome.SelectedValue) == 12 || Convert.ToInt32(cbOutcome.SelectedValue) == 13 || Convert.ToInt32(cbOutcome.SelectedValue) == 14 || Convert.ToInt32(cbOutcome.SelectedValue) == 17 || Convert.ToInt32(cbOutcome.SelectedValue) == 18))
                                            IsOut = 1;
                                        obj.ExeQueryRetBooDL("Insert INTO OutPlayer (MatchID,HalfID,RaidNo,EventId,PlayerId,KeyDefender,SupportedKeyDefender,IsOut,OutType,ISInitiator) Values(" + Temp_matchid + "," + halfid + "," + CurRaidno + " ," + CurEventID + "," + Initiator + ",0,0,0," + cbEvents.SelectedValue + ",1)", 1);
                                        #endregion
                                    }
                                }
                                else if (eventtype == 9 || eventtype == 10 || eventtype == 11 || eventtype == 26 || eventtype == 27 || eventtype == 28 || eventtype == 29 || eventtype == 59 || eventtype == 60 || eventtype == 61 || eventtype == 70 || eventtype == 71 || eventtype == 72 || eventtype == 73 || eventtype == 74 || eventtype == 75 || eventtype == 76 || eventtype == 79)
                                {
                                    //if (Convert.ToInt32(cbOutcome.SelectedValue) == 15)
                                    //    IsOut = 1;
                                    //else
                                    //    IsOut = 0;

                                    foreach (DataRowView drview in lbKeyDefender.SelectedItems)
                                    {
                                        IsOut = 0;
                                        if (Convert.ToInt32(CommonCls.RaiderID) == Convert.ToInt32(drview["PlayerId"]) && Convert.ToInt32(cbOutcome.SelectedValue) == 15)
                                        {
                                            IsOut = 1;
                                            //Israiderout = 0;
                                        }
                                        else if (Convert.ToInt32(CommonCls.RaiderID) == Convert.ToInt32(drview["PlayerId"]) && Convert.ToInt32(cbOutcome.SelectedValue) != 15)
                                        {
                                            IsOut = 0;
                                            //Israiderout = 0;
                                        }
                                        else if (RaiderClick && (CommonCls.RaiderOutType == 17 || CommonCls.RaiderOutType == 18) && (Convert.ToInt32(cbRaiderOutType.SelectedValue) == 17 || Convert.ToInt32(cbRaiderOutType.SelectedValue) == 18))
                                        {
                                            IsOut = 1;
                                            //Israiderout = 1;
                                        }
                                        else if (RaiderClick && (CommonCls.RaiderOutType == 17 || CommonCls.RaiderOutType == 18 || CommonCls.RaiderOutType == 19 || CommonCls.RaiderOutType == 20 || CommonCls.RaiderOutType == 21 || CommonCls.RaiderOutType == 22))
                                        {
                                            IsOut = 0;
                                            //Israiderout = 1;
                                        }
                                        else if (Convert.ToInt32(CommonCls.RaiderID) != Convert.ToInt32(drview["PlayerId"]) && (Convert.ToInt32(cbRaiderOutType.SelectedValue) == 17 || Convert.ToInt32(cbRaiderOutType.SelectedValue) == 18))
                                        {
                                            IsOut = 1;
                                            //Israiderout = 0;
                                        }
                                        else if (Convert.ToInt32(CommonCls.RaiderID) != Convert.ToInt32(drview["PlayerId"]) && (Convert.ToInt32(cbRaiderOutType.SelectedValue) == 17 || Convert.ToInt32(cbRaiderOutType.SelectedValue) == 18))
                                        {
                                            IsOut = 1;
                                            //Israiderout = 0;
                                        }
                                        else if (Convert.ToInt32(CommonCls.RaiderID) != Convert.ToInt32(drview["PlayerId"]) && Convert.ToInt32(cbOutcome.SelectedValue) == 15)
                                            IsOut = 0;
                                        else if (Convert.ToInt32(CommonCls.RaiderID) != Convert.ToInt32(drview["PlayerId"]) && (Convert.ToInt32(cbOutcome.SelectedValue) == 12 || Convert.ToInt32(cbOutcome.SelectedValue) == 13 || Convert.ToInt32(cbOutcome.SelectedValue) == 14 || Convert.ToInt32(cbOutcome.SelectedValue) == 17 || Convert.ToInt32(cbOutcome.SelectedValue) == 18))
                                            IsOut = 1;
                                        //obj.ExeQueryRetBooDL("Update OutPlayer Set PlayerId=" + drview["PlayerID"].ToString() + ",KeyDefender=1,SupportedKeyDefender=0,IsOut=" + IsOut + ",OutType=" + cbEvents.SelectedValue + " Where MatchID=" + Temp_matchid + " AND RaidNo=" + CurRaidno + " And EventId=" + CurEventID + "", 1);
                                        if (obj.ExeQueryStrRetDTDL("select * from outplayer where Matchid=" + Temp_matchid + " and raidno=" + CurRaidno + " and eventid=" + CurEventID + " and playerID=" + drview["PlayerID"].ToString() + "", 1).Rows.Count > 0)
                                            obj.ExeQueryRetBooDL("update OutPlayer set KeyDefender=1 where MatchID=" + Temp_matchid + " And HalfID=" + halfid + " And RaidNo=" + CurRaidno + " And EventId=" + CurEventID + "", 1);
                                        else
                                            obj.ExeQueryRetBooDL("Insert INTO OutPlayer (MatchID,HalfID,RaidNo,EventId,PlayerId,KeyDefender,SupportedKeyDefender,IsOut,OutType,ISInitiator) Values(" + Temp_matchid + "," + halfid + "," + CurRaidno + " ," + CurEventID + "," + drview["PlayerID"].ToString() + ",1,0," + IsOut + "," + cbEvents.SelectedValue + ",0)", 1);
                                        int orderNo = obj.ExeQueryStrDL("Select ISNULL(Max(Orderno),0)+1  from OutPlayerRef Where Matchid=" + Temp_matchid + " And RaidNo=" + (CurRaidno) + "", 1);

                                        //obj.ExeQueryRetBooDL("Insert INTO OutPlayerref (MatchID,HalfID,RaidNo,PlayerId,Clubid,orderNo) Values(" + Temp_matchid + "," + halfid + "," + CurRaidno + " ," + CurEventID + "," + drview["playerid"].ToString() + "," + DefenceClubId + "," + orderNo + ")", 1);
                                        if (IsOut == 1)
                                        {

                                            obj.ExeQueryRetBooDL("Insert INTO OutPlayerref (MatchID,HalfID,RaidNo,PlayerId,Clubid,orderNo) Values(" + Temp_matchid + "," + halfid + "," + CurRaidno + " ," + drview["playerid"].ToString() + "," + DefenceClubId + "," + orderNo + ")", 1);
                                        }
                                    }
                                    foreach (DataRowView drview in lbSupportedDefender.SelectedItems)
                                    {
                                        IsOut = 0;
                                        if (Convert.ToInt32(CommonCls.RaiderID) == Convert.ToInt32(drview["PlayerId"]) && Convert.ToInt32(cbOutcome.SelectedValue) == 15)
                                        {
                                            IsOut = 1;
                                            //Israiderout = 0;
                                        }
                                        else if (Convert.ToInt32(CommonCls.RaiderID) == Convert.ToInt32(drview["PlayerId"]) && Convert.ToInt32(cbOutcome.SelectedValue) != 15)
                                        {
                                            IsOut = 0;
                                            //Israiderout = 0;
                                        }
                                        else if (RaiderClick && (CommonCls.RaiderOutType == 17 || CommonCls.RaiderOutType == 18) && (Convert.ToInt32(cbRaiderOutType.SelectedValue) == 17 || Convert.ToInt32(cbRaiderOutType.SelectedValue) == 18))
                                        {
                                            IsOut = 1;
                                            //Israiderout = 1;
                                        }
                                        else if (RaiderClick && (CommonCls.RaiderOutType == 17 || CommonCls.RaiderOutType == 18 || CommonCls.RaiderOutType == 19 || CommonCls.RaiderOutType == 20 || CommonCls.RaiderOutType == 21 || CommonCls.RaiderOutType == 22))
                                        {
                                            IsOut = 0;
                                            //Israiderout = 1;
                                        }
                                        else if (Convert.ToInt32(CommonCls.RaiderID) != Convert.ToInt32(drview["PlayerId"]) && (Convert.ToInt32(cbRaiderOutType.SelectedValue) == 17 || Convert.ToInt32(cbRaiderOutType.SelectedValue) == 18))
                                        {
                                            IsOut = 1;
                                            //Israiderout = 0;
                                        }
                                        else if (Convert.ToInt32(CommonCls.RaiderID) != Convert.ToInt32(drview["PlayerId"]) && (Convert.ToInt32(cbRaiderOutType.SelectedValue) == 17 || Convert.ToInt32(cbRaiderOutType.SelectedValue) == 18))
                                        {
                                            IsOut = 1;
                                            //Israiderout = 0;
                                        }
                                        else if (Convert.ToInt32(CommonCls.RaiderID) != Convert.ToInt32(drview["PlayerId"]) && Convert.ToInt32(cbOutcome.SelectedValue) == 15)
                                            IsOut = 0;
                                        else if (Convert.ToInt32(CommonCls.RaiderID) != Convert.ToInt32(drview["PlayerId"]) && (Convert.ToInt32(cbOutcome.SelectedValue) == 12 || Convert.ToInt32(cbOutcome.SelectedValue) == 13 || Convert.ToInt32(cbOutcome.SelectedValue) == 14 || Convert.ToInt32(cbOutcome.SelectedValue) == 17 || Convert.ToInt32(cbOutcome.SelectedValue) == 18))
                                            IsOut = 1;
                                        //obj.ExeQueryRetBooDL("Update OutPlayer Set PlayerId=" + drview["PlayerID"].ToString() + ",KeyDefender=0,SupportedKeyDefender=1,IsOut=" + IsOut + ",OutType=" + cbEvents.SelectedValue + " Where MatchID=" + Temp_matchid + " AND RaidNo=" + CurRaidno + " And EventId=" + CurEventID + "", 1);
                                        if (obj.ExeQueryStrRetDTDL("select * from outplayer where Matchid=" + Temp_matchid + " and raidno=" + CurRaidno + " and eventid=" + CurEventID + " and playerID=" + drview["PlayerID"].ToString() + "", 1).Rows.Count > 0)
                                            obj.ExeQueryRetBooDL("update OutPlayer set SupportedKeyDefender=1 where MatchID=" + Temp_matchid + " And HalfID=" + halfid + " And RaidNo=" + CurRaidno + " And EventId=" + CurEventID + "", 1);
                                        else
                                            obj.ExeQueryRetBooDL("Insert INTO OutPlayer (MatchID,HalfID,RaidNo,EventId,PlayerId,KeyDefender,SupportedKeyDefender,IsOut,OutType,ISInitiator) Values(" + Temp_matchid + "," + halfid + "," + CurRaidno + " ," + CurEventID + "," + drview["PlayerID"].ToString() + ",0,1," + IsOut + "," + cbEvents.SelectedValue + ",0)", 1);
                                        int orderNo = obj.ExeQueryStrDL("Select ISNULL(Max(Orderno),0)+1  from OutPlayerRef Where Matchid=" + Temp_matchid + " And RaidNo=" + (CurRaidno) + "", 1);

                                        //obj.ExeQueryRetBooDL("Insert INTO OutPlayerref (MatchID,HalfID,RaidNo,PlayerId,Clubid,orderNo) Values(" + Temp_matchid + "," + halfid + "," + CurRaidno + " ," + CurEventID + "," + drview["playerid"].ToString() + "," + DefenceClubId + "," + orderNo + ")", 1);
                                        if (IsOut == 1)
                                        {
                                            obj.ExeQueryRetBooDL("Insert INTO OutPlayerref (MatchID,HalfID,RaidNo,PlayerId,Clubid,orderNo) Values(" + Temp_matchid + "," + halfid + "," + CurRaidno + " ," + drview["playerid"].ToString() + "," + DefenceClubId + "," + orderNo + ")", 1);
                                        }
                                    }
                                    if (lbInitiator.SelectedIndex != -1)
                                    {
                                        #region Initiator Insert
                                        IsOut = 0;
                                        if (Convert.ToInt32(CommonCls.RaiderID) == Initiator && Convert.ToInt32(cbOutcome.SelectedValue) == 15)
                                        {
                                            IsOut = 1;
                                        }
                                        else if (Convert.ToInt32(CommonCls.RaiderID) == Initiator && Convert.ToInt32(cbOutcome.SelectedValue) != 15)
                                        {
                                            IsOut = 0;
                                        }
                                        else if (RaiderClick && (CommonCls.RaiderOutType == 17 || CommonCls.RaiderOutType == 18) && (Convert.ToInt32(cbRaiderOutType.SelectedValue) == 17 || Convert.ToInt32(cbRaiderOutType.SelectedValue) == 18))
                                        {
                                            IsOut = 1;
                                        }
                                        else if (RaiderClick && (CommonCls.RaiderOutType == 17 || CommonCls.RaiderOutType == 18 || CommonCls.RaiderOutType == 19 || CommonCls.RaiderOutType == 20 || CommonCls.RaiderOutType == 21 || CommonCls.RaiderOutType == 22))
                                        {
                                            IsOut = 0;
                                        }
                                        else if (Convert.ToInt32(CommonCls.RaiderID) != Initiator && (Convert.ToInt32(cbRaiderOutType.SelectedValue) == 17 || Convert.ToInt32(cbRaiderOutType.SelectedValue) == 18))
                                        {
                                            IsOut = 1;
                                        }
                                        else if (Convert.ToInt32(CommonCls.RaiderID) != Initiator && (Convert.ToInt32(cbRaiderOutType.SelectedValue) == 17 || Convert.ToInt32(cbRaiderOutType.SelectedValue) == 18))
                                        {
                                            IsOut = 1;
                                        }
                                        else if (Convert.ToInt32(CommonCls.RaiderID) != Initiator && Convert.ToInt32(cbOutcome.SelectedValue) == 15)
                                            IsOut = 0;
                                        else if (Convert.ToInt32(CommonCls.RaiderID) != Initiator && (Convert.ToInt32(cbOutcome.SelectedValue) == 12 || Convert.ToInt32(cbOutcome.SelectedValue) == 13 || Convert.ToInt32(cbOutcome.SelectedValue) == 14 || Convert.ToInt32(cbOutcome.SelectedValue) == 17 || Convert.ToInt32(cbOutcome.SelectedValue) == 18))
                                            IsOut = 1;
                                        if (obj.ExeQueryStrRetDTDL("select * from outplayer where Matchid=" + Temp_matchid + " and raidno=" + CurRaidno + " and eventid=" + CurEventID + " and playerID=" + Initiator + "", 1).Rows.Count > 0)
                                            obj.ExeQueryRetBooDL("update OutPlayer set ISInitiator=1 where MatchID=" + Temp_matchid + " And HalfID=" + halfid + " And RaidNo=" + CurRaidno + " And EventId=" + CurEventID + "", 1);
                                        else
                                            obj.ExeQueryRetBooDL("Insert INTO OutPlayer (MatchID,HalfID,RaidNo,EventId,PlayerId,KeyDefender,SupportedKeyDefender,IsOut,OutType,ISInitiator) Values(" + Temp_matchid + "," + halfid + "," + CurRaidno + " ," + CurEventID + "," + Initiator + ",0,0,0," + cbEvents.SelectedValue + ",1)", 1);
                                        #endregion
                                    }
                                }

                                obj.ExeQueryRetBooDL("Insert into UserTrackerQC (Matchid,HalfID,RaidNo,UpdateTime,UserId)values(" + Temp_matchid + "," + halfid + "," + CurRaidno + ",'" + System.DateTime.Now + "'," + CommonCls.UserLoginID + ")", 1);

                            }

                            if (Convert.ToInt32(cbOutcome.SelectedValue) == 15)
                            {
                                int orderNo = obj.ExeQueryStrDL("Select ISNULL(Max(Orderno),0)+1  from OutPlayerRef Where Matchid=" + Temp_matchid + " And RaidNo=" + (CurRaidno) + "", 1);

                                obj.ExeQueryRetBooDL("Insert INTO OutPlayerref (MatchID,HalfID,RaidNo,PlayerId,Clubid,orderNo) Values(" + Temp_matchid + "," + halfid + "," + CurRaidno + " ," + cbRaider.SelectedValue + "," + RaidClubId + "," + orderNo + ")", 1);
                            }
                            MessageBox.Show("Update Successfully", "Kabaddi Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            try
                            {
                                string CurrentScore = obj.ExeQueryStrRetStrDL("Select dbo.fn_GetCurrentRaidScore(" + Temp_matchid + "," + halfid + "," + CurRaidno + ")", 1);
                                objDL.ExeQueryRetBooDL("Update Raid set raidpoint=" + CurrentScore.Split('-')[0] + ",defencepoint=" + CurrentScore.Split('-')[1] + "  Where Matchid=" + Temp_matchid + " And HalfID=" + halfid + " And RaidNo=" + CurRaidno + "", 1);
                            }
                            catch { }

                            try
                            {
                                int cnt = obj.ExeQueryStrDL("Select ISNULL(Count(Raidno),0)+1 From tblCorrectedRaid where Matchid=" + cbMatches.SelectedValue + " And HalfID=" + halfid + " AND RaidNo=" + CurRaidno + "", 1);
                                obj.ExeQueryRetBooDL("Insert into tblCorrectedRaid (Matchid,HalfID,Raidno,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + cbMatches.SelectedValue + "," + halfid + "," + CurRaidno + "," + cnt + ",'Raid','" + System.DateTime.Now + "',0,1,0)", 1);
                            }
                            catch { }
                            //MessageBox.Show("Update Successfully", "Kabaddi Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            reset();
                        }
                        else
                        {
                            obj.ExeQueryRetBooDL("Insert into UserTrackerQC (Matchid,HalfID,RaidNo,UpdateTime,UserId)values(" + Temp_matchid + "," + halfid + "," + CurRaidno + ",'" + System.DateTime.Now + "'," + CommonCls.UserLoginID + ")", 1);
                            if (Convert.ToInt32(cbOutcome.SelectedValue) == 15 && lastoutcome == 16)
                            {
                                int orderNo = obj.ExeQueryStrDL("Select ISNULL(Max(Orderno),0)+1  from OutPlayerRef Where Matchid=" + Temp_matchid + " And RaidNo=" + (CurRaidno) + "", 1);

                                obj.ExeQueryRetBooDL("Insert INTO OutPlayerref (MatchID,HalfID,RaidNo,PlayerId,Clubid,orderNo) Values(" + Temp_matchid + "," + halfid + "," + CurRaidno + " ," + cbRaider.SelectedValue + "," + RaidClubId + "," + orderNo + ")", 1);
                            }
                            else if (Convert.ToInt32(cbOutcome.SelectedValue) == 16 && lastoutcome == 15)
                            {
                                int orderNo = obj.ExeQueryStrDL("Select ISNULL(Max(Orderno),0)+1  from OutPlayerRef Where Matchid=" + Temp_matchid + " And RaidNo=" + (CurRaidno) + "", 1);

                                obj.ExeQueryRetBooDL("Delete From OutPlayerref Where MatchID=" + Temp_matchid + " And HalfID=" + halfid + " And RaidNo=" + CurRaidno + " And PlayerId=" + cbRaider.SelectedValue + " And Clubid=" + RaidClubId + "", 1);
                            }

                            if (Convert.ToInt32(cbOutcome.SelectedValue) == 15 && lastoutcome != 15)
                            {
                                dt = new DataTable();
                                dt = objDL.ExeQueryStrRetDTDL("select * From OutPlayer where MatchID=" + Temp_matchid + " And RaidNo=" + CurRaidno + " and OutType IN(select ID From EventMaster where EventGroup IN('Touch','Tackle')) and IsOut=1", 1);
                                if (dt.Rows.Count > 0)
                                {
                                    foreach (DataRow dr in dt.Rows)
                                    {
                                        obj.ExeQueryRetBooDL("Update OutPlayer Isout=0 Where MatchID=" + Temp_matchid + " And RaidNo=" + CurRaidno + " And EventID=" + dr["EventID"] + " And PlayerId=" + dr["PlayerID"] + "", 1);
                                        obj.ExeQueryRetBooDL("Delete From OutPlayerref Where MatchID=" + Temp_matchid + " And HalfID=" + halfid + " And RaidNo=" + CurRaidno + " And PlayerId IN (" + dr["PlayerID"] + ")", 1);
                                    }
                                }
                            }
                            else if ((Convert.ToInt32(cbOutcome.SelectedValue) == 12 || Convert.ToInt32(cbOutcome.SelectedValue) == 13 || Convert.ToInt32(cbOutcome.SelectedValue) == 14) && lastoutcome == 15)
                            {
                                dt = new DataTable();
                                dt = objDL.ExeQueryStrRetDTDL("select * From OutPlayer where MatchID=" + Temp_matchid + " And RaidNo=" + CurRaidno + " and OutType IN(select ID From EventMaster where EventGroup IN('Touch','Tackle'))", 1);
                                if (dt.Rows.Count > 0)
                                {
                                    string outDefIDs = "";
                                    foreach (DataRow dr in dt.Rows)
                                    {
                                        obj.ExeQueryRetBooDL("Update OutPlayer Set Isout=1 Where MatchID=" + Temp_matchid + " And RaidNo=" + CurRaidno + " And EventID=" + dr["EventID"] + " And PlayerId=" + dr["PlayerID"] + "", 1);
                                        int orderNo = obj.ExeQueryStrDL("Select ISNULL(Max(Orderno),0)+1  from OutPlayerRef Where Matchid=" + Temp_matchid + " And RaidNo=" + (CurRaidno) + "", 1);
                                        int clubID = obj.ExeQueryStrDL("select dbo.Fn_GetPlayerTeamid(" + Temp_matchid + "," + dr["PlayerID"] + ")", 1);
                                        obj.ExeQueryRetBooDL("Insert INTO OutPlayerref (MatchID,HalfID,RaidNo,PlayerId,Clubid,orderNo) Values(" + Temp_matchid + "," + halfid + "," + CurRaidno + " ," + dr["PlayerID"] + "," + clubID + "," + orderNo + ")", 1);

                                    }
                                }
                            }
                            MessageBox.Show("Update Successfully", "Kabaddi Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //MessageBox.Show("Update Successfully", "Kabaddi Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            try
                            {
                                string CurrentScore = obj.ExeQueryStrRetStrDL("Select dbo.fn_GetCurrentRaidScore(" + Temp_matchid + "," + halfid + "," + CurRaidno + ")", 1);
                                objDL.ExeQueryRetBooDL("Update Raid set raidpoint=" + CurrentScore.Split('-')[0] + ",defencepoint=" + CurrentScore.Split('-')[1] + "  Where Matchid=" + Temp_matchid + "  And RaidNo=" + CurRaidno + "", 1);
                            }
                            catch { }

                            try
                            {
                                int cnt = obj.ExeQueryStrDL("Select ISNULL(Count(Raidno),0)+1 From tblCorrectedRaid where Matchid=" + cbMatches.SelectedValue + " And HalfID=" + halfid + " AND RaidNo=" + CurRaidno + "", 1);
                                obj.ExeQueryRetBooDL("Insert into tblCorrectedRaid (Matchid,HalfID,Raidno,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + cbMatches.SelectedValue + "," + halfid + "," + CurRaidno + "," + cnt + ",'Raid','" + System.DateTime.Now + "',0,1,0)", 1);
                            }
                            catch { }
                            reset();

                            //IdentityUpdateEventArgs args = new IdentityUpdateEventArgs();
                            //IdentityUpdated(this, args);
                        }
                    }
                    #endregion
                }

                Ins_Upd_flag = "";
                objDL.ExeQueryRetBooDL("update KB_Matches set QCUpdate=1 where MatchID=" + Temp_matchid + "", 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void lbLineOutRaider_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbLineOutRaider.SelectedItems.Count > 0)
                lbLineOutDefender.SelectedIndex = -1;
        }

        private void lbLineOutDefender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbLineOutDefender.SelectedItems.Count > 0)
                lbLineOutRaider.SelectedIndex = -1;
        }

        private void btnNewEvent_Click(object sender, EventArgs e)
        {
            if (CurRaidno == 0) { MessageBox.Show("Select Raid"); return; }
           // if (Ins_Upd_flag == "Update")
            if(pnlEvents.Visible==false)
            {
                pnlEvents.Visible = true;
                pnlEvents.BringToFront();
                Ins_Upd_flag = "Insert";
            }
          //  else if (Ins_Upd_flag == "Insert")
            else if (pnlEvents.Visible == true)
            {
                pnlEvents.Visible = false;
                Ins_Upd_flag = "Update";
            }
            //CommonCls.DTListEvents.Rows.Clear();
            //CommonCls.DTListOutPlayer.Rows.Clear();
        }

        private void btnDefenderSubmit_Click(object sender, EventArgs e)
        {
            if (Ins_Upd_flag != "Insert") { return; }

                setEndtime = 0;
            try
            {
                if (CommonCls.EventTypeId == 37 || CommonCls.EventTypeId == 41 || CommonCls.EventTypeId == 42)
                {
                        setEndtime = 0;
                    int Subid = objDL.ExeQueryStrDL("Select MAX(ISNULL(SubId,0))+1 from RaidSubjects Where MatchID=" + Temp_matchid + " And RaidNo=" + CurRaidno + "", 1);
                    objDL.ExeQueryRetBooDL("Insert Into RaidSubjects(Matchid,HalfID,RaidNo,SubId,EventtypeId,PlayerId,StanceTime,StartFrame,PX1,PY1) Values (" + Temp_matchid + "," + halfid + "," + CurRaidno + "," + Subid + "," + CommonCls.EventTypeId + "," + lbDefender.SelectedValue + "," + 0 + "," + setEndtime + "," + CommonCls.PX + "," + CommonCls.PY + ")", 1);
                }
                else
                {
                    int EventID = objDL.ExeQueryStrDL("Select ISNULL(Max(EventID),0)+1 from Events Where MatchID=" + Temp_matchid + " And RaidNo=" + (CurRaidno) + "", 1); // TeamID
                    int PlayerIsExists = 0;
                    EventID = CommonCls.DTListEvents.Rows.Count + EventID;
                    int Initiator = 0;
                    try
                    {
                        if (lbInitiator.SelectedIndex != -1)
                            CommonCls.DTListOutPlayer.Rows.Add(Temp_matchid, halfid, CurRaidno, EventID, lbInitiator.SelectedValue, "0", "0", "0", cbEvents.SelectedValue, "1");
                        Initiator = Convert.ToInt32(lbInitiator.SelectedValue);
                    }
                    catch { }
                    CommonCls.DTListEvents.Rows.Add(Temp_matchid, halfid, CurRaidno, EventID, cbEvents.SelectedValue, CommonCls.PX, CommonCls.PY, setEndtime, Initiator);


                    foreach (DataRowView drview in lbDefender.SelectedItems)
                    {
                        for (int j = 0; j < CommonCls.DTListOutPlayer.Rows.Count; j++)
                        {
                            if (drview["PlayerID"].ToString() == CommonCls.DTListOutPlayer.Rows[j][4].ToString())
                            {
                                PlayerIsExists = 1;
                            }
                        }
                        if (PlayerIsExists == 0)
                            CommonCls.DTListOutPlayer.Rows.Add(Temp_matchid, halfid, CurRaidno, EventID, drview["PlayerID"], "0", "0", "0", cbEvents.SelectedValue,"0");
                        PlayerIsExists = 0;
                    }
                }
                pnlDefender.Hide();
            }
            catch { }
        }

        private void btnDefender_Click(object sender, EventArgs e)
        {
            if (Ins_Upd_flag != "Insert") { return; }
            try
            {
                int EventID = objDL.ExeQueryStrDL("Select (ISNULL(Max(EventID),0)+1) from Events Where MatchID=" + Temp_matchid + " And RaidNo=" + (CurRaidno) + "", 1); // TeamID
                
                int PlayerIsExists = 0;
                int Initiator=0;
                try{
                    if (lbInitiator.SelectedIndex!=-1)
                        CommonCls.DTListOutPlayer.Rows.Add(Temp_matchid, halfid, CurRaidno, EventID, lbInitiator.SelectedValue, "0", "0", "0", cbEvents.SelectedValue,"1");

                  Initiator=  Convert.ToInt32(lbInitiator.SelectedValue);
                }
                catch{}
                    setEndtime = 0;
                CommonCls.DTListEvents.Rows.Add(Temp_matchid, halfid, CurRaidno, EventID, cbEvents.SelectedValue, CommonCls.PX, CommonCls.PY, setEndtime, Initiator);

                foreach (DataRowView drview in lbKeyDefender.SelectedItems)
                {
                    for (int j = 0; j < CommonCls.DTListOutPlayer.Rows.Count; j++)
                    {
                        if (drview["PlayerID"].ToString() == CommonCls.DTListOutPlayer.Rows[j][4].ToString())
                        {
                            PlayerIsExists = 1;
                        }
                    }
                    if (PlayerIsExists == 0)
                        CommonCls.DTListOutPlayer.Rows.Add(Temp_matchid, halfid, CurRaidno, EventID, drview["PlayerID"], "1", "0", "0", cbEvents.SelectedValue, "0");
                    PlayerIsExists = 0;
                }
                
                foreach (DataRowView drview in lbSupportedDefender.SelectedItems)
                {
                    for (int j = 0; j < CommonCls.DTListOutPlayer.Rows.Count; j++)
                    {
                        if (drview["PlayerID"].ToString() == CommonCls.DTListOutPlayer.Rows[j][4].ToString())
                        {
                            PlayerIsExists = 1;
                        }
                    }
                    if (PlayerIsExists == 0)
                        CommonCls.DTListOutPlayer.Rows.Add(Temp_matchid, halfid, CurRaidno, EventID, drview["PlayerID"], "0", "1", "0", cbEvents.SelectedValue, "0");
                    PlayerIsExists = 0;
                }

                pnlKeyDefender.Hide();
            }
            catch { }

        }

        private void btnLineoutSubmit_Click(object sender, EventArgs e)
        {
            try
            {
               // int EventID = objDL.ExeQueryStrDL("Select (Max(EventID)+1) from Events Where MatchID=" + Temp_matchid + " And RaidNo=" + (CurRaidno) + "", 1); // TeamID
                
                if (Ins_Upd_flag != "Insert") { return; }
                if (RaidClubId == CommonCls.ClubId1)
                {
                    lblTeamA1.Text = CommonCls.Club1Prefix;
                    lblTeamB1.Text = CommonCls.Club2Prefix;
                }
                else if (RaidClubId == CommonCls.ClubId2)
                {
                    lblTeamA1.Text = CommonCls.Club2Prefix;
                    lblTeamB1.Text = CommonCls.Club1Prefix;
                }
                    setEndtime = 0;
                if (techPoint)
                {
                    int playerID = 0;
                    int EventID = objDL.ExeQueryStrDL("Select (Max(EventID)+1) from Events Where MatchID=" + Temp_matchid + " And RaidNo=" + (CurRaidno) + "", 1); // TeamID
                    objDL.ExeQueryRetBooDL("Insert Into Events(MatchID,HalfID,RaidNo,EventId,EventType,PX,PY,StartFrame,Initiator) Values (" + Temp_matchid + "," + halfid + "," + CurRaidno + "," + EventID + ",30,0,0,'" + setEndtime + "',0)", 1);

                    if (lbLineOutRaider.SelectedItems.Count > 0)
                        playerID = Convert.ToInt32(lbLineOutRaider.SelectedValue);
                    else if (lbLineOutDefender.SelectedItems.Count > 0)
                        playerID = Convert.ToInt32(lbLineOutDefender.SelectedValue);
                    objDL.ExeQueryRetBooDL("Insert Into OutPlayer(MatchID,HalfID,RaidNo,EventId,PlayerId,KeyDefender,SupportedKeyDefender,IsOut,OutType,ISInitiator) Values (" + Temp_matchid + "," + halfid + "," + CurRaidno + "," + EventID + "," + playerID + ",0,0,0," + Convert.ToInt32(cbEvents.SelectedValue) + ",0)", 1);
                }
                else
                {
                    if (lbLineOutDefender.SelectedIndex == -1 && lbLineOutRaider.SelectedIndex == -1) { MessageBox.Show("Select LineOut Player", "Kabaddi", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

                    int PlayerIsExists = 0;


                    if (lbLineOutDefender.SelectedItems.Count > 0 && Convert.ToInt32(cbEvents.SelectedValue) != 18)
                    {
                        #region Defender Team
                        foreach (DataRowView drview in lbLineOutDefender.SelectedItems)
                        {
                            for (int j = 0; j < CommonCls.DTListOutPlayer.Rows.Count; j++)
                            {
                                if (drview["PlayerID"].ToString() == CommonCls.DTListOutPlayer.Rows[j][4].ToString())
                                {
                                    PlayerIsExists = 1;
                                }
                            }
                            if (PlayerIsExists == 0)
                            {
                                int Orderno = objDL.ExeQueryStrDL("Select (Max(Orderno)+1) from OutPlayerRef Where MatchID=" + Temp_matchid + " And RaidNo=" + (CurRaidno) + "", 1); // TeamID
                                int Clubid = objDL.ExeQueryStrDL("Select ClubID from Lineups Where MatchID=" + Temp_matchid + " And PlayerID=" + drview["PlayerID"].ToString() + "", 1); // TeamID

                                if (Convert.ToInt32(cbEvents.SelectedValue) == 23)
                                {
                                    // Clubid = obj.ExeQueryStrDL("Select ClubID from Lineups Where MatchID=" + Temp_matchid + " And PlayerID=" + drview["PlayerId"] + "", 1); // TeamID
                                    int EventID = objDL.ExeQueryStrDL("Select (Max(EventID)+1) from Events Where MatchID=" + Temp_matchid + " And RaidNo=" + (CurRaidno) + "", 1); // TeamID
                                    objDL.ExeQueryRetBooDL("Insert Into Events(MatchID,HalfID,RaidNo,EventId,EventType,PX,PY,StartFrame,Initiator) Values (" + Temp_matchid + "," + halfid + "," + CurRaidno + "," + EventID + "," + Convert.ToInt32(cbEvents.SelectedValue) + "," + CommonCls.PX + "," + CommonCls.PY + ",'" + setEndtime + "',0)", 1);

                                    objDL.ExeQueryRetBooDL("Insert Into OutPlayer(MatchID,HalfID,RaidNo,EventId,PlayerId,KeyDefender,SupportedKeyDefender,IsOut,OutType,ISInitiator) Values (" + Temp_matchid + "," + halfid + "," + CurRaidno + "," + EventID + "," + drview["PlayerID"].ToString() + ",0,0,0," + Convert.ToInt32(cbEvents.SelectedValue) + ",0)", 1);
                                }
                                else if (Convert.ToInt32(cbEvents.SelectedValue) == 24 || Convert.ToInt32(cbEvents.SelectedValue) == 25)
                                {
                                    int iskill = 0;
                                    if (Convert.ToInt32(cbEvents.SelectedValue) == 25)
                                        iskill = 1;
                                    // Clubid = obj.ExeQueryStrDL("Select ClubID from Lineups Where MatchID=" + Temp_matchid + " And PlayerID=" + drview["PlayerId"] + "", 1); // TeamID
                                    int EventID = objDL.ExeQueryStrDL("Select (Max(EventID)+1) from Events Where MatchID=" + Temp_matchid + " And RaidNo=" + (CurRaidno) + "", 1); // TeamID
                                    objDL.ExeQueryRetBooDL("Insert Into Events(MatchID,HalfID,RaidNo,EventId,EventType,PX,PY,StartFrame,Initiator) Values (" + Temp_matchid + "," + halfid + "," + CurRaidno + "," + EventID + "," + Convert.ToInt32(cbEvents.SelectedValue) + "," + CommonCls.PX + "," + CommonCls.PY + ",'" + setEndtime + "',0)", 1);

                                    objDL.ExeQueryRetBooDL("Insert Into OutPlayer(MatchID,HalfID,RaidNo,EventId,PlayerId,KeyDefender,SupportedKeyDefender,IsOut,OutType,ISInitiator) Values (" + Temp_matchid + "," + halfid + "," + CurRaidno + "," + EventID + "," + drview["PlayerID"].ToString() + ",0,0,0," + Convert.ToInt32(cbEvents.SelectedValue) + ",0)", 1);

                                    objDL.ExeQueryRetBooDL("Insert Into SuspendedPlayer(MatchID,HalfID,RaidNo,PlayerId,Clubid,Issuspend,iskill) Values (" + Temp_matchid + "," + halfid + "," + CurRaidno + "," + drview["PlayerID"].ToString() + "," + Clubid + ",1," + iskill + ")", 1);
                                }
                            }
                            PlayerIsExists = 0;
                        }
                        #endregion
                    }
                    else
                    {
                        #region Raider Team

                        if ((Convert.ToInt32(cbEvents.SelectedValue) == 23 || Convert.ToInt32(cbEvents.SelectedValue) == 24 || Convert.ToInt32(cbEvents.SelectedValue) == 25) && Convert.ToInt32(lbLineOutRaider.SelectedValue) == Convert.ToInt32(cbRaider.SelectedValue))
                        {
                            cbRaiderCards.SelectedValue = Convert.ToInt32(cbEvents.SelectedValue);
                            objDL.ExeQueryRetBooDL("Update Raid Set RaiderOutType=" + Convert.ToInt32(cbEvents.SelectedValue) + " Where MatchID=" + Temp_matchid + " And RaidNo=" + (CurRaidno) + "", 1);
                            if (Convert.ToInt32(cbEvents.SelectedValue) == 24 || Convert.ToInt32(cbEvents.SelectedValue) == 25)
                            {
                                int iskill = 0;
                                if (Convert.ToInt32(cbEvents.SelectedValue) == 25)
                                    iskill = 1;
                                objDL.ExeQueryRetBooDL("Insert Into SuspendedPlayer(MatchID,HalfID,RaidNo,PlayerId,Clubid,Issuspend,iskill) Values (" + Temp_matchid + "," + halfid + "," + CurRaidno + "," + lbLineOutRaider.SelectedValue + "," + RaidClubId + ",1," + iskill + ")", 1);
                            }
                        }
                        else if ((Convert.ToInt32(cbEvents.SelectedValue) == 23 || Convert.ToInt32(cbEvents.SelectedValue) == 24 || Convert.ToInt32(cbEvents.SelectedValue) == 25) && Convert.ToInt32(lbLineOutRaider.SelectedValue) != Convert.ToInt32(cbRaider.SelectedValue))
                        {
                            int Clubid = objDL.ExeQueryStrDL("Select ClubID from Lineups Where MatchID=" + Temp_matchid + " And PlayerID=" + lbLineOutRaider.SelectedValue.ToString() + "", 1); // TeamID
                            int EventID = objDL.ExeQueryStrDL("Select (ISNULL(Max(EventID),0)+1) from Events Where MatchID=" + Temp_matchid + " And RaidNo=" + (CurRaidno) + "", 1); // TeamID
                            objDL.ExeQueryRetBooDL("Insert Into Events(MatchID,HalfID,RaidNo,EventId,EventType,PX,PY,StartFrame,Initiator) Values (" + Temp_matchid + "," + halfid + "," + CurRaidno + "," + EventID + "," + Convert.ToInt32(cbEvents.SelectedValue) + "," + CommonCls.PX + "," + CommonCls.PY + ",'"+setEndtime+"',0)", 1);

                            objDL.ExeQueryRetBooDL("Insert Into OutPlayer(MatchID,HalfID,RaidNo,EventId,PlayerId,KeyDefender,SupportedKeyDefender,IsOut,OutType,ISInitiator) Values (" + Temp_matchid + "," + halfid + "," + CurRaidno + "," + EventID + "," + lbLineOutRaider.SelectedValue + ",0,0,0," + Convert.ToInt32(cbEvents.SelectedValue) + ",0)", 1);

                            if (Convert.ToInt32(cbEvents.SelectedValue) == 24 || Convert.ToInt32(cbEvents.SelectedValue) == 25)
                            {
                                int iskill = 0;
                                if (Convert.ToInt32(cbEvents.SelectedValue) == 25)
                                    iskill = 1;
                                objDL.ExeQueryRetBooDL("Insert Into SuspendedPlayer(MatchID,HalfID,RaidNo,PlayerId,Clubid,Issuspend,iskill) Values (" + Temp_matchid + "," + halfid + "," + CurRaidno + "," + lbLineOutRaider.SelectedValue + "," + Clubid + ",1," + iskill + ")", 1);
                            }
                        }
                        else if (Convert.ToInt32(cbEvents.SelectedValue) == 18)
                        {
                            string outplayid = "0";
                            if (lbLineOutRaider.SelectedIndex != -1)
                                outplayid = lbLineOutRaider.SelectedValue.ToString();
                            else if (lbLineOutDefender.SelectedIndex != -1)
                                outplayid = lbLineOutDefender.SelectedValue.ToString();
                            int Clubid = objDL.ExeQueryStrDL("Select ClubID from Lineups Where MatchID=" + Temp_matchid + " And PlayerID=" + outplayid + "", 1); // TeamID
                            //objDL.ExeQueryRetBooDL("Insert Into OutPlayerRef(MatchID,HalfID,RaidNo,PlayerId,Clubid,orderNo) Values (" + CommonCls.MatchId + "," + CommonCls.HalfID + "," + (CommonCls.RaidNo) + "," + drview["PlayerID"].ToString() + "," + Clubid + "," + Orderno + ")", 1);
                            int EventID = objDL.ExeQueryStrDL("Select (ISNULL(Max(EventID),0)+1) from Events Where MatchID=" + Temp_matchid + " And RaidNo=" + (CurRaidno) + "", 1); // TeamID
                            objDL.ExeQueryRetBooDL("Insert Into Events(MatchID,HalfID,RaidNo,EventId,EventType,PX,PY,StartFrame,Initiator) Values (" + Temp_matchid + "," + halfid + "," + CurRaidno + "," + EventID + "," + CommonCls.EventTypeId + "," + CommonCls.PX + "," + CommonCls.PY + ",'" + setEndtime + "',0)", 1);
                            int Rank = 1 + objDL.ExeQueryStrDL("Select top 1 ROW_NUMBER() OVER(ORDER BY raidno,orderno) Rank from OutPlayerRef Where Matchid=" + Temp_matchid + " And RaidNo=" + (CurRaidno - 1) + " And PlayerID Not IN(Select PlayerID from Innerplayer Where Matchid=" + Temp_matchid + " AND RaidNo=" + (CurRaidno - 1) + ") order by Rank desc", 1);

                            objDL.ExeQueryRetBooDL("Insert Into OutPlayerRef(MatchID,HalfID,RaidNo,PlayerId,Clubid,OrderNo) Values (" + Temp_matchid + "," + halfid + "," + CurRaidno + "," + outplayid + "," + Clubid + "," + Rank + ")", 1);
                            objDL.ExeQueryRetBooDL("Insert Into OutPlayer(MatchID,HalfID,RaidNo,EventId,PlayerId,KeyDefender,SupportedKeyDefender,IsOut,OutType) Values (" + Temp_matchid + "," + halfid + "," + CurRaidno + "," + EventID + "," + outplayid + ",0,0,1," + CommonCls.EventTypeId + ")", 1);
                        }
                        #endregion
                    }
                }
                pnlLineOut.Hide();
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
                    int RaidNo = Convert.ToInt32(gvEvents.Rows[gvEvents.CurrentRow.Index].Cells["RaidNo1"].Value);
                    int EventID = Convert.ToInt32(gvEvents.Rows[gvEvents.CurrentRow.Index].Cells["EventID"].Value);
                    if ((obj.ExeQueryRetBooDL("Delete from Events Where MatchId=" + Temp_matchid + " And HalfID=" + halfid + " And RaidNo=" + RaidNo + " And EventID=" + EventID + "", 1)))
                    {
                        DataTable dt1=new DataTable();
                        dt1=obj.ExeQueryStrRetDTDL("Select * from OutPlayer Where MatchId=" + Temp_matchid + " And HalfID=" + halfid + " And RaidNo=" + RaidNo + " And EventID=" + EventID + " and isout=1",1);

                        DataTable dt2 = new DataTable();
                        dt2 = obj.ExeQueryStrRetDTDL("Select * from OutPlayer Where MatchId=" + Temp_matchid + " And HalfID=" + halfid + " And RaidNo=" + RaidNo + " And EventID=" + EventID + " and outType IN(24,25)", 1);

                        foreach (DataRow dr in dt2.Rows)
                        {
                            objDL.ExeQueryRetBooDL("delete from SuspendedPlayer Where MatchID=" + Temp_matchid + " AND HalfID=" + halfid + " AND RaidNo=" + CurRaidno + " AND PlayerId=" + dr["PlayerID"] + "", 1);

                        }

                        if ((obj.ExeQueryRetBooDL("Delete from OutPlayer Where MatchId=" + Temp_matchid + " And HalfID=" + halfid + " And RaidNo=" + RaidNo + " And EventID=" + EventID + "", 1)))
                        {
                            if (dt1.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dt1.Rows)
                                    obj.ExeQueryRetBooDL("Delete from OutPlayerRef Where MatchId=" + Temp_matchid + " And HalfID=" + halfid + " And RaidNo=" + RaidNo + " And PlayerID=" + dr["PlayerID"] + "", 1);
                            }
                            MessageBox.Show("Deleted Successfully", "Kabaddi Info", MessageBoxButtons.OK, MessageBoxIcon.Information);                            
                            LoadSubGrid();
                            BindInplayer("");
                        }
                        try
                        {
                            int cnt = obj.ExeQueryStrDL("Select ISNULL(Count(Raidno),0)+1 From tblCorrectedRaid where Matchid=" + cbMatches.SelectedValue + " And HalfID=" + halfid + " AND RaidNo=" + RaidNo + "", 1);
                            obj.ExeQueryRetBooDL("Insert into tblCorrectedRaid (Matchid,HalfID,Raidno,EventID,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + cbMatches.SelectedValue + "," + halfid + "," + RaidNo + "," + EventID + "," + cnt + ",'Events','" + System.DateTime.Now + "',0,0,1)", 1);
                        }
                        catch { }
                    }
                }
            }
            catch { }
        }
        bool bonuscheck = false;
        private void chkBonusPoint_CheckedChanged(object sender, EventArgs e)
        {
            if (CommonCls.PX == 0 && CommonCls.PY == 0)
            {
                pnlPitchMap.Show();
                pnlPitchMap.BringToFront();
                //chkBonusPoint.Checked = false; return;
            }
            if (chkBonusPoint.Checked == true)
            {
                CommonCls.BLPX = CommonCls.PX;
                CommonCls.BLPY = CommonCls.PY;
            }
            pnlEvents.Visible = false;
            TouchClick = false;
            TackleClick = false;
            bonuscheck = true;
        }
        
        private void FrmQCScore_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                GC.Collect();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void FrmQCScore_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                GC.Collect();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void cbRaiderFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!PageLoad) { return; }
            if (Convert.ToInt32(cbRaiderFilter.SelectedValue) == 0)
            {
                //  dt = obj.ExeQueryStrRetDTDL("Select R.Matchid,HalfID,Timerstart Time,Raidno,dbo.fn_GetPlayerName(RaiderID)+' ('+CAST(L.JercyNo AS VARCHAR)+')' Raider,dbo.fn_getEventName(Outcome)OutCome  from Raid R JOIN Lineups L ON R.Matchid=L.Matchid AND R.RaiderID=L.PlayerID  Where R.Matchid=" + Temp_matchid + " Order by R.RaidNo Desc", 1);
                if (chkScore.Checked)
                    dt = obj.ExeQueryStrRetDTDL("Select R.Matchid,dbo.fn_GetMatchNamePreDate(R.Matchid)MatchName,R.HalfID,MAX(Timerstart) Time,R.Raidno,MAX(dbo.fn_GetPlayerName(RaiderID)) Raider,MAX(dbo.fn_getEventName(Outcome))OutCome, MAX(ISNULL(dbo.fn_GetEventName(RaiderOutType),''))RaiderOutType,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,3),'') SpecialCase ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,4),'') KeyDefender,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,5),'') SupportedKeyDefender ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,6),'') Defenderevents ,MAX(dbo.fn_GetEventName(R.RaiderCard))Card ,dbo.fn_GetRaidbyRaidScore(R.MatchID,R.HalfID,R.RaidNo) Score,''DIP from Raid R JOIN KB_Matches M ON R.Matchid=M.Matchid JOIN Lineups L ON R.Matchid=L.Matchid AND R.RaiderID=L.PlayerID FULL JOIN OutPlayer O ON O.MatchID=R.MatchID And O.HalfID=R.HalfID And O.RaidNo=R.RaidNo FULL JOIN Events e ON e.MatchID=R.MatchID And e.HalfID=R.HalfID And e.RaidNo=R.RaidNo and E.EventId=O.EventID Where R.Matchid IN(" + cbMatches.SelectedValue + ")  GROUP by M.date, R.Matchid,R.HalfID,R.RaidNo Order by M.date desc,R.Matchid,R.HalfID desc,R.RaidNo desc", 1);
                else
                    dt = obj.ExeQueryStrRetDTDL("Select R.Matchid,dbo.fn_GetMatchNamePreDate(R.Matchid)MatchName,R.HalfID,MAX(Timerstart) Time,R.Raidno,MAX(dbo.fn_GetPlayerName(RaiderID)) Raider,MAX(dbo.fn_getEventName(Outcome))OutCome, MAX(ISNULL(dbo.fn_GetEventName(RaiderOutType),''))RaiderOutType,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,3),'') SpecialCase ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,4),'') KeyDefender,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,5),'') SupportedKeyDefender ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,6),'') Defenderevents ,MAX(dbo.fn_GetEventName(R.RaiderCard))Card ,'' Score,''DIP from Raid R JOIN KB_Matches M ON R.Matchid=M.Matchid JOIN Lineups L ON R.Matchid=L.Matchid AND R.RaiderID=L.PlayerID FULL JOIN OutPlayer O ON O.MatchID=R.MatchID And O.HalfID=R.HalfID And O.RaidNo=R.RaidNo FULL JOIN Events e ON e.MatchID=R.MatchID And e.HalfID=R.HalfID And e.RaidNo=R.RaidNo and E.EventId=O.EventID Where R.Matchid IN(" + cbMatches.SelectedValue + ")  GROUP by M.date, R.Matchid,R.HalfID,R.RaidNo Order by M.date desc,R.Matchid,R.HalfID desc,R.RaidNo desc", 1);
            }
            else
            {  // dt = obj.ExeQueryStrRetDTDL("Select R.Matchid,HalfID,Timerstart Time,Raidno,dbo.fn_GetPlayerName(RaiderID)+' ('+CAST(L.JercyNo AS VARCHAR)+')' Raider,dbo.fn_getEventName(Outcome)OutCome  from Raid R JOIN Lineups L ON R.Matchid=L.Matchid AND R.RaiderID=L.PlayerID  Where R.Matchid=" + Temp_matchid + " And RaiderID=" + cbRaiderFilter.SelectedValue + " Order by R.RaidNo Desc", 1);
                if (chkScore.Checked)
                    dt = obj.ExeQueryStrRetDTDL("Select R.Matchid,dbo.fn_GetMatchNamePreDate(R.Matchid)MatchName,R.HalfID,MAX(Timerstart) Time,R.Raidno,MAX(dbo.fn_GetPlayerName(RaiderID)) Raider,MAX(dbo.fn_getEventName(Outcome))OutCome, MAX(ISNULL(dbo.fn_GetEventName(RaiderOutType),''))RaiderOutType,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,3),'') SpecialCase ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,4),'') KeyDefender,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,5),'') SupportedKeyDefender ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,6),'') Defenderevents ,MAX(dbo.fn_GetEventName(R.RaiderCard))Card ,dbo.fn_GetRaidbyRaidScore(R.MatchID,R.HalfID,R.RaidNo) Score,''DIP from Raid R JOIN KB_Matches M ON R.Matchid=M.Matchid JOIN Lineups L ON R.Matchid=L.Matchid AND R.RaiderID=L.PlayerID FULL JOIN OutPlayer O ON O.MatchID=R.MatchID And O.HalfID=R.HalfID And O.RaidNo=R.RaidNo FULL JOIN Events e ON e.MatchID=R.MatchID And e.HalfID=R.HalfID And e.RaidNo=R.RaidNo and E.EventId=O.EventID Where R.Matchid IN(" + cbMatches.SelectedValue + ") And R.RaiderID=" + cbRaiderFilter.SelectedValue + "  GROUP by M.date, R.Matchid,R.HalfID,R.RaidNo Order by M.date desc,R.Matchid,R.HalfID desc,R.RaidNo desc", 1);
                else
                    dt = obj.ExeQueryStrRetDTDL("Select R.Matchid,dbo.fn_GetMatchNamePreDate(R.Matchid)MatchName,R.HalfID,MAX(Timerstart) Time,R.Raidno,MAX(dbo.fn_GetPlayerName(RaiderID)) Raider,MAX(dbo.fn_getEventName(Outcome))OutCome, MAX(ISNULL(dbo.fn_GetEventName(RaiderOutType),''))RaiderOutType,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,3),'') SpecialCase ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,4),'') KeyDefender,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,5),'') SupportedKeyDefender ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,6),'') Defenderevents ,MAX(dbo.fn_GetEventName(R.RaiderCard))Card ,dbo.fn_GetRaidbyRaidScore(R.MatchID,R.HalfID,R.RaidNo) Score,''DIP from Raid R JOIN KB_Matches M ON R.Matchid=M.Matchid JOIN Lineups L ON R.Matchid=L.Matchid AND R.RaiderID=L.PlayerID FULL JOIN OutPlayer O ON O.MatchID=R.MatchID And O.HalfID=R.HalfID And O.RaidNo=R.RaidNo FULL JOIN Events e ON e.MatchID=R.MatchID And e.HalfID=R.HalfID And e.RaidNo=R.RaidNo and E.EventId=O.EventID Where R.Matchid IN(" + cbMatches.SelectedValue + ") And R.RaiderID=" + cbRaiderFilter.SelectedValue + "  GROUP by M.date, R.Matchid,R.HalfID,R.RaidNo Order by M.date desc,R.Matchid,R.HalfID desc,R.RaidNo desc", 1);
            }

            gvRaidEvent.AutoGenerateColumns = false;
            gvRaidEvent.DataSource = dt;
        }


        void GridBind()
        {

        }

        private void cbEventTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (!PageLoad) { return; }
            if (Convert.ToInt32(cbOutComeFilter.SelectedValue) == 0)
            { //  dt = obj.ExeQueryStrRetDTDL("Select R.Matchid,HalfID,Timerstart Time,Raidno,dbo.fn_GetPlayerName(RaiderID)+' ('+CAST(L.JercyNo AS VARCHAR)+')' Raider,dbo.fn_getEventName(Outcome)OutCome  from Raid R JOIN Lineups L ON R.Matchid=L.Matchid AND R.RaiderID=L.PlayerID  Where R.Matchid=" + Temp_matchid + " Order by R.RaidNo Desc", 1);
                if (chkScore.Checked)
                    dt = obj.ExeQueryStrRetDTDL("Select R.Matchid,dbo.fn_GetMatchNamePreDate(R.Matchid)MatchName,R.HalfID,MAX(Timerstart) Time,R.Raidno,MAX(dbo.fn_GetPlayerName(RaiderID)) Raider,MAX(dbo.fn_getEventName(Outcome))OutCome, MAX(ISNULL(dbo.fn_GetEventName(RaiderOutType),''))RaiderOutType,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,3),'') SpecialCase ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,4),'') KeyDefender,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,5),'') SupportedKeyDefender ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,6),'') Defenderevents ,MAX(dbo.fn_GetEventName(R.RaiderCard))Card ,dbo.fn_GetRaidbyRaidScore(R.MatchID,R.HalfID,R.RaidNo) Score,''DIP from Raid R JOIN KB_Matches M ON R.Matchid=M.Matchid JOIN Lineups L ON R.Matchid=L.Matchid AND R.RaiderID=L.PlayerID FULL JOIN OutPlayer O ON O.MatchID=R.MatchID And O.HalfID=R.HalfID And O.RaidNo=R.RaidNo FULL JOIN Events e ON e.MatchID=R.MatchID And e.HalfID=R.HalfID And e.RaidNo=R.RaidNo and E.EventId=O.EventID Where R.Matchid IN(" + cbMatches.SelectedValue + ") GROUP by M.date, R.Matchid,R.HalfID,R.RaidNo Order by M.date desc,R.Matchid,R.HalfID desc,R.RaidNo desc", 1);
                else
                    dt = obj.ExeQueryStrRetDTDL("Select R.Matchid,dbo.fn_GetMatchNamePreDate(R.Matchid)MatchName,R.HalfID,MAX(Timerstart) Time,R.Raidno,MAX(dbo.fn_GetPlayerName(RaiderID)) Raider,MAX(dbo.fn_getEventName(Outcome))OutCome, MAX(ISNULL(dbo.fn_GetEventName(RaiderOutType),''))RaiderOutType,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,3),'') SpecialCase ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,4),'') KeyDefender,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,5),'') SupportedKeyDefender ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,6),'') Defenderevents ,MAX(dbo.fn_GetEventName(R.RaiderCard))Card ,'' Score,''DIP from Raid R JOIN KB_Matches M ON R.Matchid=M.Matchid JOIN Lineups L ON R.Matchid=L.Matchid AND R.RaiderID=L.PlayerID FULL JOIN OutPlayer O ON O.MatchID=R.MatchID And O.HalfID=R.HalfID And O.RaidNo=R.RaidNo FULL JOIN Events e ON e.MatchID=R.MatchID And e.HalfID=R.HalfID And e.RaidNo=R.RaidNo and E.EventId=O.EventID Where R.Matchid IN(" + cbMatches.SelectedValue + ") GROUP by M.date, R.Matchid,R.HalfID,R.RaidNo Order by M.date desc,R.Matchid,R.HalfID desc,R.RaidNo desc", 1);
            }
            else
            {   //dt = obj.ExeQueryStrRetDTDL("Select R.Matchid,HalfID,Timerstart Time,Raidno,dbo.fn_GetPlayerName(RaiderID)+' ('+CAST(L.JercyNo AS VARCHAR)+')' Raider,dbo.fn_getEventName(Outcome)OutCome  from Raid R JOIN Lineups L ON R.Matchid=L.Matchid AND R.RaiderID=L.PlayerID  Where R.Matchid=" + Temp_matchid + " And OutCome=" + cbOutComeFilter.SelectedValue + " Order by R.RaidNo Desc", 1);
                if (chkScore.Checked)
                    dt = obj.ExeQueryStrRetDTDL("Select R.Matchid,dbo.fn_GetMatchNamePreDate(R.Matchid)MatchName,R.HalfID,MAX(Timerstart) Time,R.Raidno,MAX(dbo.fn_GetPlayerName(RaiderID)) Raider,MAX(dbo.fn_getEventName(Outcome))OutCome, MAX(ISNULL(dbo.fn_GetEventName(RaiderOutType),''))RaiderOutType,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,3),'') SpecialCase ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,4),'') KeyDefender,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,5),'') SupportedKeyDefender ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,6),'') Defenderevents ,MAX(dbo.fn_GetEventName(R.RaiderCard))Card ,dbo.fn_GetRaidbyRaidScore(R.MatchID,R.HalfID,R.RaidNo) Score,''DIP from Raid R JOIN KB_Matches M ON R.Matchid=M.Matchid JOIN Lineups L ON R.Matchid=L.Matchid AND R.RaiderID=L.PlayerID FULL JOIN OutPlayer O ON O.MatchID=R.MatchID And O.HalfID=R.HalfID And O.RaidNo=R.RaidNo FULL JOIN Events e ON e.MatchID=R.MatchID And e.HalfID=R.HalfID And e.RaidNo=R.RaidNo and E.EventId=O.EventID Where R.Matchid IN(" + cbMatches.SelectedValue + ") And R.OutCome=" + cbOutComeFilter.SelectedValue + "  GROUP by M.date, R.Matchid,R.HalfID,R.RaidNo Order by M.date desc,R.Matchid,R.HalfID desc,R.RaidNo desc", 1);
                else
                    dt = obj.ExeQueryStrRetDTDL("Select R.Matchid,dbo.fn_GetMatchNamePreDate(R.Matchid)MatchName,R.HalfID,MAX(Timerstart) Time,R.Raidno,MAX(dbo.fn_GetPlayerName(RaiderID)) Raider,MAX(dbo.fn_getEventName(Outcome))OutCome, MAX(ISNULL(dbo.fn_GetEventName(RaiderOutType),''))RaiderOutType,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,3),'') SpecialCase ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,4),'') KeyDefender,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,5),'') SupportedKeyDefender ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,6),'') Defenderevents ,MAX(dbo.fn_GetEventName(R.RaiderCard))Card ,'' Score,''DIP from Raid R JOIN KB_Matches M ON R.Matchid=M.Matchid JOIN Lineups L ON R.Matchid=L.Matchid AND R.RaiderID=L.PlayerID FULL JOIN OutPlayer O ON O.MatchID=R.MatchID And O.HalfID=R.HalfID And O.RaidNo=R.RaidNo FULL JOIN Events e ON e.MatchID=R.MatchID And e.HalfID=R.HalfID And e.RaidNo=R.RaidNo and E.EventId=O.EventID Where R.Matchid IN(" + cbMatches.SelectedValue + ") And R.OutCome=" + cbOutComeFilter.SelectedValue + "  GROUP by M.date, R.Matchid,R.HalfID,R.RaidNo Order by M.date desc,R.Matchid,R.HalfID desc,R.RaidNo desc", 1);

            } 
            gvRaidEvent.AutoGenerateColumns = false;
            gvRaidEvent.DataSource = dt;
        }

        Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
      
        int PX = 0, PY = 0, PX1 = 0, PY1 = 0;
        Boolean RaiderClick = false, DefenderClick = false;
        bool TouchClick = false, TackleClick = false;

        private void btnTouch_Click(object sender, EventArgs e)
        {
            //TouchClick = true;
            //TackleClick = false;
            //CommonCls.EventTypeId = 1;
            //CommonCls.EventID = CommonCls.EventID + 1;
            //cbEvents.SelectedValue = CommonCls.EventTypeId;
            //lbKeyDefender.SelectedIndex = -1;
            //lbSupportedDefender.SelectedIndex = -1;
            //pnlDefender.Show(); pnlDefender.BringToFront();

            TouchClick = true;
            TackleClick = false;
            bonuscheck = false;
            contextMenuStrip1.Items.Clear();
            //contextMenuStrip1.Items.Add("Hand touch");
            //contextMenuStrip1.Items.Add("Toe Touch");
            //contextMenuStrip1.Items.Add("Dubki");
            //contextMenuStrip1.Items.Add("Front Kick");
            //contextMenuStrip1.Items.Add("Escape");
            //contextMenuStrip1.Items.Add("Back Kick");
            //contextMenuStrip1.Items.Add("Jump");
            foreach (DataRow dr in DTTouch.Rows)
                contextMenuStrip1.Items.Add(dr["EventType"].ToString());

            contextMenuStrip1.Show(btnTouch, new Point(btnTouch.Width, 0));
        }

        private void btnTackle_Click(object sender, EventArgs e)
        {
            //TouchClick = false;
            //TackleClick = true;
            //CommonCls.EventTypeId = 9;
            //CommonCls.EventID = CommonCls.EventID + 1;
            //cbEvents.SelectedValue = CommonCls.EventTypeId;
            //lbKeyDefender.SelectedIndex = -1;
            //lbSupportedDefender.SelectedIndex = -1;
            //pnlKeyDefender.Show(); pnlKeyDefender.BringToFront();

            TouchClick = false;
            TackleClick = true;
            bonuscheck = false;
            if (CommonCls.PX == 0 && CommonCls.PY == 0) { pnlPitchMap.Show(); pnlPitchMap.BringToFront(); return; }
            contextMenuStrip1.Items.Clear();
            //contextMenuStrip1.Items.Add("Ankle Hold");
            //contextMenuStrip1.Items.Add("Dash");
            //contextMenuStrip1.Items.Add("Hand Hold");
            //contextMenuStrip1.Items.Add("Thigh Hold");
            //contextMenuStrip1.Items.Add("Block");
            //contextMenuStrip1.Items.Add("Back Hold");
            //contextMenuStrip1.Items.Add("Chain");
            foreach (DataRow dr in DTTackle.Rows)
                contextMenuStrip1.Items.Add(dr["EventType"].ToString());

            contextMenuStrip1.Show(btnTackle, new Point(btnTackle.Width, 0));
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
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            lbDefender.SelectionMode = SelectionMode.MultiSimple;
            //stopwatch.Stop();
            dt = new DataTable();
            dt = objDL.ExeQueryStrRetDTDL("Select * from EventMaster Where EventName ='" + e.ClickedItem.Text.Trim() + "'", 1);
            if (dt.Rows.Count > 0)
            {
                CommonCls.EventTypeId = Convert.ToInt32(dt.Rows[0]["ID"]);
                cbEvents.SelectedValue = CommonCls.EventTypeId;
                if (CommonCls.EventTypeId != 31 && CommonCls.EventTypeId != 32 && CommonCls.EventTypeId != 37 && CommonCls.EventTypeId != 41 && CommonCls.EventTypeId != 42 && CommonCls.EventTypeId != 36 && CommonCls.EventTypeId != 38 && CommonCls.EventTypeId != 39 && CommonCls.EventTypeId != 40 && CommonCls.EventTypeId != 42 && CommonCls.EventTypeId != 43 && CommonCls.EventTypeId != 45)
                {
                    CommonCls.EventID = CommonCls.EventID + 1;
                }
                lbKeyDefender.SelectedIndex = -1;
                lbSupportedDefender.SelectedIndex = -1;
                if (CommonCls.EventTypeId == 23 || CommonCls.EventTypeId == 24 || CommonCls.EventTypeId == 25)
                {
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
                    }
                    if (DefenderClick)
                        pnlDefender.Show(); pnlDefender.BringToFront();
                }
                else if (CommonCls.EventTypeId == 31 || CommonCls.EventTypeId == 32)
                {
                    setEndtime = 0;
                    int Subid = objDL.ExeQueryStrDL("Select ISNULL(MAX(SubId),0)+1 from RaidSubjects Where MatchID=" + Temp_matchid + " And RaidNo=" + CurRaidno + "", 1);
                    objDL.ExeQueryRetBooDL("Insert Into RaidSubjects(Matchid,HalfID,RaidNo,SubId,EventtypeId,PlayerId,StanceTime,StartFrame,PX1,PY1) Values (" + Temp_matchid + "," + halfid + "," + CurRaidno + "," + Subid + "," + CommonCls.EventTypeId + "," + CommonCls.RaiderID + "," + Convert.ToInt32(stopwatch.Elapsed.TotalSeconds) + "," + setEndtime + "," + CommonCls.PX + "," + CommonCls.PY + ")", 1);
                }
                else if (CommonCls.EventTypeId == 37 || CommonCls.EventTypeId == 41 || CommonCls.EventTypeId == 42)
                {
                    lbDefender.SelectionMode = SelectionMode.One; pnlDefender.Show(); pnlDefender.BringToFront();
                }
                else if (CommonCls.EventTypeId == 36 || CommonCls.EventTypeId == 38 || CommonCls.EventTypeId == 39 || CommonCls.EventTypeId == 40 || CommonCls.EventTypeId == 44 || CommonCls.EventTypeId == 43 || CommonCls.EventTypeId == 45 || CommonCls.EventTypeId == 46 || CommonCls.EventTypeId == 47 || CommonCls.EventTypeId == 48 || CommonCls.EventTypeId == 49 || CommonCls.EventTypeId == 50 || CommonCls.EventTypeId == 51 || CommonCls.EventTypeId == 52 || CommonCls.EventTypeId == 53 || CommonCls.EventTypeId == 54 || CommonCls.EventTypeId == 62 || CommonCls.EventTypeId == 63 || CommonCls.EventTypeId == 64 || CommonCls.EventTypeId == 65 || CommonCls.EventTypeId == 77 || CommonCls.EventTypeId == 78)
                {
                    setEndtime = 0;
                    int Subid = objDL.ExeQueryStrDL("Select MAX(ISNULL(SubId,0))+1 from RaidSubjects Where MatchID=" + Temp_matchid + " And RaidNo=" + CurRaidno + "", 1);
                    objDL.ExeQueryRetBooDL("Insert Into RaidSubjects(Matchid,HalfID,RaidNo,SubId,EventtypeId,PlayerId,StanceTime,StartFrame,PX1,PY1) Values (" + Temp_matchid + "," + halfid + "," + CurRaidno + "," + Subid + "," + CommonCls.EventTypeId + "," + cbRaider.SelectedValue + "," + 0 + "," + setEndtime + "," + CommonCls.PX + "," + CommonCls.PY + ")", 1);
                }
            }
            else
            {
                return;
            }
            //stopwatch.Start();
        }
        
        private void btnInPlayer_Click(object sender, EventArgs e)
        {
            int clubid = 0;
            if (InorOutplayer == 1)
            {
                obj.ExeQueryRetBooDL("DELETE FROM Innerplayer WHERE MatchID='" + cbMatches.SelectedValue + "' AND RaidNo='" + CurRaidno + "' " + (rbTeamAIN.Checked ? "and ClubID=" + CommonCls.ClubId1 : (rbTeamBIN.Checked ? "and ClubID=" + CommonCls.ClubId2 : "")) + "", 1);
               
                foreach (DataGridViewRow row in gvInPlayer.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[3].Value) != true)
                    {
                        clubid = obj.ExeQueryStrDL("SELECT Clubid FROM Lineups WHERE MatchID='" + cbMatches.SelectedValue + "' And PlayerID='" + Convert.ToString(row.Cells["PlayerID"].Value) + "'", 1);
                        obj.ExeQueryRetBooDL("Insert into Innerplayer (MatchID,RaidNo,PlayerID,HalfID,ClubID)Values('" + cbMatches.SelectedValue + "','" + Convert.ToString(row.Cells["RaidNo3"].Value) + "','" + Convert.ToString(row.Cells["PlayerID"].Value) + "'," + halfid + "," + clubid + ")", 1);
                        
                    }
                }
                if (true)
                    pnlInPlayer.Hide();
                else
                    MessageBox.Show("Failed");
            }
            else if (InorOutplayer == 2)
            {
                obj.ExeQueryRetBooDL("DELETE FROM Outplayerref WHERE MatchID='" + cbMatches.SelectedValue + "' AND RaidNo='" + CurRaidno + "' " + (rbTeamAIN.Checked ? "and ClubID=" + CommonCls.ClubId1 : (rbTeamBIN.Checked ? "and ClubID=" + CommonCls.ClubId2 : "")) + "", 1);
                int orderNo = 1;
                foreach (DataGridViewRow row in gvInPlayer.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[3].Value) != true)
                    {
                        orderNo = orderNo + 1;
                        clubid = obj.ExeQueryStrDL("SELECT Clubid FROM Lineups WHERE MatchID='" + cbMatches.SelectedValue + "' And PlayerID='" + Convert.ToString(row.Cells["PlayerID"].Value) + "'", 1);
        
                        obj.ExeQueryRetBooDL("Insert Into OutPlayerRef(MatchID,HalfID,RaidNo,PlayerId,Clubid,orderNo) Values (" + cbMatches.SelectedValue + "," + halfid + "," + CurRaidno + "," + Convert.ToString(row.Cells["PlayerID"].Value) + "," + clubid + "," + orderNo + ")", 1);

                      
                    }
                }
                  if (true)
                      pnlInPlayer.Hide();
                  else
                      MessageBox.Show("Failed");
            }
        }

        private void pbInplayerClose_Click(object sender, EventArgs e)
        {
            pnlInPlayer.Hide();
        }

        bool techPoint = false;
        private void btnTechnicalPoint_Click(object sender, EventArgs e)
        {
            if (CurRaidno == 0) { return; }
            showLineoutPlayers();
            pnlLineOut.Show();
            pnlLineOut.BringToFront();
            cbEvents.SelectedValue = 30;
            techPoint = true;
        }
        void showDeclarePlayers(int ClubID)
        {
            DataTable dt2 = new DataTable();
            dt2 = objDL.ExeQueryStrRetDTDL("Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + Temp_matchid + " and L.clubid=" + ClubID + "  And L.PlayerID IN(Select PlayerID from Inplayerlist where matchid=" + Temp_matchid + " and clubid=" + ClubID + " and RaidNo=" + CurRaidno + ")  and L.PlayerID IN(Select PlayerID from Outplayer where matchid=" + Temp_matchid + " and RaidNo=" + CurRaidno + " And EventID=" + CurEventID + ")  order by JercyNo", 1);
            lbDefender.DataSource = dt2;
            lbDefender.DisplayMember = "firstname";
            lbDefender.ValueMember = "playerid";

        }
         void showLineoutPlayers()
        {
            if (chkShowAll.Checked)
            {
                dt = new DataTable();
                dt = objDL.ExeQueryStrRetDTDL("Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + Temp_matchid + " and L.clubid=" + RaidClubId + " and L.issub=0 AND PlayerID NOT IN(Select PlayerID from OutPlayerRef Where Matchid=" + Temp_matchid + " And Clubid=" + RaidClubId + " AND RaidNo=" + CurRaidno + ") AND PlayerID Not IN(Select PlayerID from SuspendedPlayer Where Matchid=" + Temp_matchid + " And Clubid=" + RaidClubId + " And Issuspend=1) Union All Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + Temp_matchid + " and L.clubid=" + RaidClubId + " and L.issub=0 AND PlayerID IN(Select PlayerID from Innerplayer Where Matchid=" + Temp_matchid + " And Clubid=" + RaidClubId + " AND RaidNo=" + CurRaidno + ") AND PlayerID Not IN(Select PlayerID from SuspendedPlayer Where Matchid=" + Temp_matchid + " And Clubid=" + RaidClubId + " And Issuspend=1) order by JercyNo", 1);
                lbLineOutRaider.DataSource = dt;
                lbLineOutRaider.DisplayMember = "firstname";
                lbLineOutRaider.ValueMember = "playerid";

                dt = new DataTable();
                dt = objDL.ExeQueryStrRetDTDL("Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + Temp_matchid + " and L.clubid=" + DefenceClubId + " and L.issub=0 AND PlayerID NOT IN(Select PlayerID from OutPlayerRef Where Matchid=" + Temp_matchid + " And Clubid=" + DefenceClubId + " AND RaidNo=" + CurRaidno + ") AND PlayerID Not IN(Select PlayerID from SuspendedPlayer Where Matchid=" + Temp_matchid + " And Clubid=" + DefenceClubId + " And Issuspend=1) Union All Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + Temp_matchid + " and L.clubid=" + DefenceClubId + " and L.issub=0 AND PlayerID IN(Select PlayerID from Innerplayer Where Matchid=" + Temp_matchid + " And Clubid=" + DefenceClubId + " AND RaidNo=" + CurRaidno + ") AND PlayerID Not IN(Select PlayerID from SuspendedPlayer Where Matchid=" + Temp_matchid + " And Clubid=" + DefenceClubId + " And Issuspend=1) order by JercyNo", 1);
                lbLineOutDefender.DataSource = dt;
                lbLineOutDefender.DisplayMember = "firstname";
                lbLineOutDefender.ValueMember = "playerid";
            }
            else
            {
                dt = new DataTable();
                dt = objDL.ExeQueryStrRetDTDL("Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + Temp_matchid + " and L.clubid=" + RaidClubId + " "+RaidFilter+" order by JercyNo", 1);
                lbLineOutRaider.DataSource = dt;
                lbLineOutRaider.DisplayMember = "firstname";
                lbLineOutRaider.ValueMember = "playerid";

                dt = new DataTable();
                dt = objDL.ExeQueryStrRetDTDL("Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20)) AS firstname,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + Temp_matchid + " and L.clubid=" + DefenceClubId + " " + DefFilter + " order by JercyNo", 1);
                lbLineOutDefender.DataSource = dt;
                lbLineOutDefender.DisplayMember = "firstname";
                lbLineOutDefender.ValueMember = "playerid";
            }
        }

         private void btnCard_Click(object sender, EventArgs e)
         {
             if (CurRaidno == 0) { return; }
             showLineoutPlayers();

             contextMenuStrip1.Items.Clear();
             contextMenuStrip1.Items.Add("Green Card");
             contextMenuStrip1.Items.Add("Yellow Card");
             contextMenuStrip1.Items.Add("Red Card");
             contextMenuStrip1.Items.Add("Foul");
             contextMenuStrip1.Show(btnCard, new Point(btnCard.Width, 0));
         }

        private void deleteRaidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MasterDL obj = new MasterDL();
                DialogResult Result = MessageBox.Show("Continue to Delete This Raid", "Kabaddi Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (Result == DialogResult.Yes)
                {
                    //int HalfID = Convert.ToInt32(gvRaidEvent.Rows[gvRaidEvent.CurrentRow.Index].Cells["HalfID"].Value);
                    int RaidNo = Convert.ToInt32(gvRaidEvent.Rows[gvRaidEvent.CurrentRow.Index].Cells["RaidNo"].Value);

                    bool lstraid = obj.ExeQueryRetBooDL("SELECT CASE WHEN MAX(RaidNo)=" + RaidNo + " then 'TRUE' else 'FALSE' END from Raid where MatchID=" + cbMatches.SelectedValue + "", 1);
                 
                    if ((obj.ExeQueryRetBooDL("Delete from Raid Where MatchId=" + cbMatches.SelectedValue + " And RaidNo=" + RaidNo + "", 1)))
                    {
                        obj.ExeQueryRetBooDL("Delete from RaidSubjects Where MatchId=" + cbMatches.SelectedValue + " And RaidNo=" + RaidNo + "", 1);
                        obj.ExeQueryRetBooDL("Delete from Events Where MatchId=" + cbMatches.SelectedValue + " And RaidNo=" + RaidNo + "", 1);
                        obj.ExeQueryRetBooDL("Delete from OutPlayer Where MatchId=" + cbMatches.SelectedValue + "  And RaidNo=" + RaidNo + "", 1);
                        obj.ExeQueryRetBooDL("Delete from OutPlayerRef Where MatchId=" + cbMatches.SelectedValue + " And RaidNo=" + RaidNo + "", 1);
                        obj.ExeQueryRetBooDL("Delete from Innerplayer Where MatchId=" + cbMatches.SelectedValue + " And RaidNo=" + RaidNo + "", 1);
                        obj.ExeQueryRetBooDL("Delete from Substitute Where MatchId=" + cbMatches.SelectedValue + " And RaidNo=" + RaidNo + "", 1);
                        obj.ExeQueryRetBooDL("Delete from SuspendedPlayer Where MatchId=" + cbMatches.SelectedValue + " And RaidNo=" + RaidNo + "", 1);

                        if (lstraid)
                        {
                            obj.ExeQueryRetBooDL("Delete from INPlayerList Where MatchId=" + cbMatches.SelectedValue + " And RaidNo=" + (RaidNo + 1) + "", 1);
                            obj.ExeQueryRetBooDL("Delete from OutPlayerList Where MatchId=" + cbMatches.SelectedValue + " And RaidNo=" + (RaidNo + 1) + "", 1);
                        }
                        else
                        {
                            obj.ExeQueryRetBooDL("Delete from INPlayerList Where MatchId=" + cbMatches.SelectedValue + " And RaidNo=" + (RaidNo) + "", 1);
                            obj.ExeQueryRetBooDL("Delete from OutPlayerList Where MatchId=" + cbMatches.SelectedValue + " And RaidNo=" + (RaidNo) + "", 1);
                        }

                        try
                        {
                            int cnt = obj.ExeQueryStrDL("Select ISNULL(Count(Raidno),0)+1 From tblCorrectedRaid where Matchid=" + cbMatches.SelectedValue + " And HalfID=" + halfid + " AND RaidNo=" + RaidNo + "", 1);
                            obj.ExeQueryRetBooDL("Insert into tblCorrectedRaid (Matchid,HalfID,Raidno,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + cbMatches.SelectedValue + "," + halfid + "," + RaidNo + "," + cnt + ",'Raid','" + System.DateTime.Now + "',0,0,1)", 1);
                        }
                        catch { }
                    }
                }
                obj.ExeQueryRetBooDL("Insert into UserTrackerQC (Matchid,HalfID,RaidNo,UpdateTime,UserId,isDelete)values(" + Temp_matchid + "," + halfid + "," + CurRaidno + ",'" + System.DateTime.Now + "'," + CommonCls.UserLoginID + ",1)", 1);
            }
            catch { }
        }

        private void addNewRaidBeforeRaidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                    setStarttime = 0;
                MasterDL obj = new MasterDL();
                DialogResult Result = MessageBox.Show("Continue to add new Raid", "Kabaddi Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (Result == DialogResult.Yes)
                {
                    //int HalfID = Convert.ToInt32(gvRaidEvent.Rows[gvRaidEvent.CurrentRow.Index].Cells["HalfID"].Value);
                    int RaidNo = Convert.ToInt32(gvRaidEvent.Rows[gvRaidEvent.CurrentRow.Index].Cells["RaidNo"].Value);

                    if ((obj.ExeQueryRetBooDL("SP_UpdateRaidNo " + cbMatches.SelectedValue + "," + RaidNo + "", 1)))
                    {
                        obj.ExeQueryRetBooDL("INSERT into Raid(MatchID,HalfID,RaidNo,RaiderID,BonusLine,BLPX,BLPY,Outcome,SuperRaid,SuperTackle,DoorDie,RaiderOutType,[Escape],Allout,Starttime,Endtime,Startframe,Endframe,TimerStart,TimerEnd,RaiderCard) SELECT MatchID,HalfID," + (RaidNo) + ",RaiderID,0,BLPX,BLPY,16,0,0,0,0,0,0,Starttime,Endtime,'" + setStarttime + "','" + setStarttime + "',TimerStart,TimerEnd,0 from Raid where MatchID=" + cbMatches.SelectedValue + " and RaidNo=" + (RaidNo + 1), 1);

                        try
                        {
                            int cnt = obj.ExeQueryStrDL("Select ISNULL(Count(Raidno),0)+1 From tblCorrectedRaid where Matchid=" + cbMatches.SelectedValue + " And HalfID=" + halfid + " AND RaidNo=" + RaidNo + "", 1);
                            obj.ExeQueryRetBooDL("Insert into tblCorrectedRaid (Matchid,HalfID,Raidno,EventID,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + cbMatches.SelectedValue + "," + halfid + "," + RaidNo + "," + EventID + "," + cnt + ",'Raid','" + System.DateTime.Now + "',1,0,0)", 1);
                        }
                        catch { }
                    }
                }
            }
            catch { }
        }


        private void btnTeamChange_Click(object sender, EventArgs e)
        {
            if (rbTeamA.Checked)
            {
                RaidClubId = Convert.ToInt32(lblAID.Text);
                DefenceClubId = Convert.ToInt32(lblBID.Text);
            }
            else
            {
                RaidClubId = Convert.ToInt32(lblBID.Text);
                DefenceClubId = Convert.ToInt32(lblAID.Text);
            }

            LoadRaider_Defender(RaidClubId, DefenceClubId,true);
            cbRaider.SelectedIndex = -1;
            CommonCls.RaiderID = 0;
            pnlTeamChange.Hide();
        }

        private void lblTeamchange_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlTeamChange.Visible = true;
            pnlTeamChange.BringToFront();
        }

        private void lblcloseTeamChange_Click(object sender, EventArgs e)
        {
            pnlTeamChange.Visible = false;
        }

        private void btnInitiatorClear_Click(object sender, EventArgs e)
        {
            lbInitiator.SelectedIndex = -1;
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void lbInitiator_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (CurRaidno == 0) { MessageBox.Show("Select Raid"); return; }
            if (obj.ExeQueryRetBooDL("Update Raid Set RaidDIP=" + txtRaidDIP.Text + ",DefDIP=" + txtDefDIP.Text + " Where MatchID=" + Temp_matchid + " AND RaidNo=" + CurRaidno + "", 1))
            {
                MessageBox.Show("Update Successfully", "Kabaddi Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Update Failed", "Kabaddi Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        int InorOutplayer = 0;
        private void llblInnerplayer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            rbTeamAIN.Checked = false;
            rbTeamBIN.Checked = false;
            lblInorOutPlayer.Text = "IN PLAYER";
            InorOutplayer = 1;
            loadInplayerList("");
            BindInplayer("");
            pnlInPlayer.Show();
            pnlInPlayer.BringToFront();
        }

        private void btnAddInPlayer_Click(object sender, EventArgs e)
        {
            foreach (DataRowView objDataRowView in lbPlayerList.SelectedItems)
            {
                gvInPlayer.Rows.Add(CurRaidno, Convert.ToInt32(objDataRowView["playerid"].ToString()), objDataRowView["firstname"].ToString(), false);
            }
        }
        
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (!PageLoad) { return; }
            dt = new DataTable();
            string Filter = "";

            if (rdb1stHalf.Checked)
                Filter = "1";
            else if (rdb2ndHalf.Checked)
                Filter = "2";
            else if (rdbAll.Checked)
                Filter = "1,2";

            if (chkScore.Checked)
                dt = obj.ExeQueryStrRetDTDL("Select R.Matchid,dbo.fn_GetMatchNamePreDate(R.Matchid)MatchName,R.HalfID,MAX(Timerstart) Time,R.Raidno,MAX(dbo.fn_GetPlayerName(RaiderID)) Raider,MAX(dbo.fn_getEventName(Outcome))OutCome, MAX(ISNULL(dbo.fn_GetEventName(RaiderOutType),''))RaiderOutType,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,3),'') SpecialCase ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,4),'') KeyDefender,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,5),'') SupportedKeyDefender ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,6),'') Defenderevents ,MAX(dbo.fn_GetEventName(R.RaiderCard))Card ,dbo.fn_GetRaidbyRaidScore(R.MatchID,R.HalfID,R.RaidNo) Score,''DIP from Raid R JOIN KB_Matches M ON R.Matchid=M.Matchid JOIN Lineups L ON R.Matchid=L.Matchid AND R.RaiderID=L.PlayerID FULL JOIN OutPlayer O ON O.MatchID=R.MatchID And O.HalfID=R.HalfID And O.RaidNo=R.RaidNo FULL JOIN Events e ON e.MatchID=R.MatchID And e.HalfID=R.HalfID And e.RaidNo=R.RaidNo and E.EventId=O.EventID Where R.Matchid IN(" + cbMatches.SelectedValue + ") And R.halfid IN(" + Filter + ") GROUP by M.date, R.Matchid,R.HalfID,R.RaidNo Order by M.date desc,R.Matchid,R.HalfID desc,R.RaidNo desc", 1);
            else
                dt = obj.ExeQueryStrRetDTDL("Select R.Matchid,dbo.fn_GetMatchNamePreDate(R.Matchid)MatchName,R.HalfID,MAX(Timerstart) Time,R.Raidno,MAX(dbo.fn_GetPlayerName(RaiderID)) Raider,MAX(dbo.fn_getEventName(Outcome))OutCome, MAX(ISNULL(dbo.fn_GetEventName(RaiderOutType),''))RaiderOutType,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,3),'') SpecialCase ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,4),'') KeyDefender,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,5),'') SupportedKeyDefender ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,6),'') Defenderevents ,MAX(dbo.fn_GetEventName(R.RaiderCard))Card ,'' Score,''DIP from Raid R JOIN KB_Matches M ON R.Matchid=M.Matchid JOIN Lineups L ON R.Matchid=L.Matchid AND R.RaiderID=L.PlayerID FULL JOIN OutPlayer O ON O.MatchID=R.MatchID And O.HalfID=R.HalfID And O.RaidNo=R.RaidNo FULL JOIN Events e ON e.MatchID=R.MatchID And e.HalfID=R.HalfID And e.RaidNo=R.RaidNo and E.EventId=O.EventID Where R.Matchid IN(" + cbMatches.SelectedValue + ") And R.halfid IN(" + Filter + ") GROUP by M.date, R.Matchid,R.HalfID,R.RaidNo Order by M.date desc,R.Matchid,R.HalfID desc,R.RaidNo desc", 1);

            gvRaidEvent.AutoGenerateColumns = false;
            gvRaidEvent.DataSource = dt;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cmbDefenderFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!PageLoad) { return; }
            if (Convert.ToInt32(cmbDefenderFilter.SelectedValue) == 0)
            {
                //  dt = obj.ExeQueryStrRetDTDL("Select R.Matchid,HalfID,Timerstart Time,Raidno,dbo.fn_GetPlayerName(RaiderID)+' ('+CAST(L.JercyNo AS VARCHAR)+')' Raider,dbo.fn_getEventName(Outcome)OutCome  from Raid R JOIN Lineups L ON R.Matchid=L.Matchid AND R.RaiderID=L.PlayerID  Where R.Matchid=" + Temp_matchid + " Order by R.RaidNo Desc", 1);
                if (chkScore.Checked)
                    dt = obj.ExeQueryStrRetDTDL("Select R.Matchid,dbo.fn_GetMatchNamePreDate(R.Matchid)MatchName,R.HalfID,MAX(Timerstart) Time,R.Raidno,MAX(dbo.fn_GetPlayerName(RaiderID)) Raider,MAX(dbo.fn_getEventName(Outcome))OutCome, MAX(ISNULL(dbo.fn_GetEventName(RaiderOutType),''))RaiderOutType,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,3),'') SpecialCase ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,4),'') KeyDefender,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,5),'') SupportedKeyDefender ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,6),'') Defenderevents ,MAX(dbo.fn_GetEventName(R.RaiderCard))Card ,dbo.fn_GetRaidbyRaidScore(R.MatchID,R.HalfID,R.RaidNo) Score,''DIP from Raid R JOIN KB_Matches M ON R.Matchid=M.Matchid JOIN Lineups L ON R.Matchid=L.Matchid AND R.RaiderID=L.PlayerID FULL JOIN OutPlayer O ON O.MatchID=R.MatchID And O.HalfID=R.HalfID And O.RaidNo=R.RaidNo FULL JOIN Events e ON e.MatchID=R.MatchID And e.HalfID=R.HalfID And e.RaidNo=R.RaidNo and E.EventId=O.EventID Where R.Matchid IN(" + cbMatches.SelectedValue + ")  GROUP by M.date, R.Matchid,R.HalfID,R.RaidNo Order by M.date desc,R.Matchid,R.HalfID desc,R.RaidNo desc", 1);
                else
                    dt = obj.ExeQueryStrRetDTDL("Select R.Matchid,dbo.fn_GetMatchNamePreDate(R.Matchid)MatchName,R.HalfID,MAX(Timerstart) Time,R.Raidno,MAX(dbo.fn_GetPlayerName(RaiderID)) Raider,MAX(dbo.fn_getEventName(Outcome))OutCome, MAX(ISNULL(dbo.fn_GetEventName(RaiderOutType),''))RaiderOutType,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,3),'') SpecialCase ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,4),'') KeyDefender,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,5),'') SupportedKeyDefender ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,6),'') Defenderevents ,MAX(dbo.fn_GetEventName(R.RaiderCard))Card ,'' Score,''DIP from Raid R JOIN KB_Matches M ON R.Matchid=M.Matchid JOIN Lineups L ON R.Matchid=L.Matchid AND R.RaiderID=L.PlayerID FULL JOIN OutPlayer O ON O.MatchID=R.MatchID And O.HalfID=R.HalfID And O.RaidNo=R.RaidNo FULL JOIN Events e ON e.MatchID=R.MatchID And e.HalfID=R.HalfID And e.RaidNo=R.RaidNo and E.EventId=O.EventID Where R.Matchid IN(" + cbMatches.SelectedValue + ")  GROUP by M.date, R.Matchid,R.HalfID,R.RaidNo Order by M.date desc,R.Matchid,R.HalfID desc,R.RaidNo desc", 1);
            }
            else
            {  // dt = obj.ExeQueryStrRetDTDL("Select R.Matchid,HalfID,Timerstart Time,Raidno,dbo.fn_GetPlayerName(RaiderID)+' ('+CAST(L.JercyNo AS VARCHAR)+')' Raider,dbo.fn_getEventName(Outcome)OutCome  from Raid R JOIN Lineups L ON R.Matchid=L.Matchid AND R.RaiderID=L.PlayerID  Where R.Matchid=" + Temp_matchid + " And RaiderID=" + cbRaiderFilter.SelectedValue + " Order by R.RaidNo Desc", 1);
                if (chkScore.Checked)
                    dt = obj.ExeQueryStrRetDTDL("Select R.Matchid,dbo.fn_GetMatchNamePreDate(R.Matchid)MatchName,R.HalfID,MAX(Timerstart) Time,R.Raidno,MAX(dbo.fn_GetPlayerName(RaiderID)) Raider,MAX(dbo.fn_getEventName(Outcome))OutCome, MAX(ISNULL(dbo.fn_GetEventName(RaiderOutType),''))RaiderOutType,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,3),'') SpecialCase ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,4),'') KeyDefender,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,5),'') SupportedKeyDefender ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,6),'') Defenderevents ,MAX(dbo.fn_GetEventName(R.RaiderCard))Card ,dbo.fn_GetRaidbyRaidScore(R.MatchID,R.HalfID,R.RaidNo) Score,''DIP from Raid R JOIN KB_Matches M ON R.Matchid=M.Matchid JOIN Lineups L ON R.Matchid=L.Matchid AND R.RaiderID=L.PlayerID FULL JOIN OutPlayer O ON O.MatchID=R.MatchID And O.HalfID=R.HalfID And O.RaidNo=R.RaidNo FULL JOIN Events e ON e.MatchID=R.MatchID And e.HalfID=R.HalfID And e.RaidNo=R.RaidNo and E.EventId=O.EventID Where R.Matchid IN(" + cbMatches.SelectedValue + ")  AND R.RaidNo IN(select  E.RaidNo from OutPlayer OP Right Join Events E ON OP.MatchID=E.MatchID And OP.HalfID=E.HalfID And OP.RaidNo=E.RaidNo And OP.EventID=E.EventId Where E.Matchid=" + Temp_matchid + " and (CASE When Initiator IS NULL OR Initiator=0 Then OP.PlayerID else Initiator END)=" + cmbDefenderFilter.SelectedValue + ") GROUP by M.date, R.Matchid,R.HalfID,R.RaidNo Order by M.date desc,R.Matchid,R.HalfID,R.RaidNo", 1);
                else
                    dt = obj.ExeQueryStrRetDTDL("Select R.Matchid,dbo.fn_GetMatchNamePreDate(R.Matchid)MatchName,R.HalfID,MAX(Timerstart) Time,R.Raidno,MAX(dbo.fn_GetPlayerName(RaiderID)) Raider,MAX(dbo.fn_getEventName(Outcome))OutCome, MAX(ISNULL(dbo.fn_GetEventName(RaiderOutType),''))RaiderOutType,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,3),'') SpecialCase ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,4),'') KeyDefender,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,5),'') SupportedKeyDefender ,ISNULL(dbo.fn_GetEventPlayerList(R.MatchID,R.HalfID,R.RaidNo,0,6),'') Defenderevents ,MAX(dbo.fn_GetEventName(R.RaiderCard))Card ,dbo.fn_GetRaidbyRaidScore(R.MatchID,R.HalfID,R.RaidNo) Score,''DIP from Raid R JOIN KB_Matches M ON R.Matchid=M.Matchid JOIN Lineups L ON R.Matchid=L.Matchid AND R.RaiderID=L.PlayerID FULL JOIN OutPlayer O ON O.MatchID=R.MatchID And O.HalfID=R.HalfID And O.RaidNo=R.RaidNo FULL JOIN Events e ON e.MatchID=R.MatchID And e.HalfID=R.HalfID And e.RaidNo=R.RaidNo and E.EventId=O.EventID Where R.Matchid IN(" + cbMatches.SelectedValue + ")  AND R.RaidNo IN(select  E.RaidNo from OutPlayer OP Right Join Events E ON OP.MatchID=E.MatchID And OP.HalfID=E.HalfID And OP.RaidNo=E.RaidNo And OP.EventID=E.EventId Where E.Matchid=" + Temp_matchid + " and (CASE When Initiator IS NULL OR Initiator=0 Then OP.PlayerID else Initiator END)=" + cmbDefenderFilter.SelectedValue + ") GROUP by M.date, R.Matchid,R.HalfID,R.RaidNo Order by M.date desc,R.Matchid,R.HalfID,R.RaidNo", 1);
            }

            gvRaidEvent.AutoGenerateColumns = false;
            gvRaidEvent.DataSource = dt;
        }

        private void btnScorecard_Click(object sender, EventArgs e)
        {
            frmScorecard frm = new frmScorecard(Temp_matchid, ClubAID, ClubBID);
            frm.Show();
        }

        private void chkScore_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnViz_Click(object sender, EventArgs e)
        {
            XMLPush(0);
        }


        void XMLPush(int i)
        {
            try
            {
                Xml.GenerateXML(objDL.ExeQueryStrRetDsDL("EXEC SP_MatchXML " + CommonCls.MatchId, 1), CommonCls.xmlpath + CommonCls.MatchId + "-in-match.xml");
                if (!Directory.Exists(CommonCls.xmlpath + "Match\\"))
                    Directory.CreateDirectory(CommonCls.xmlpath + "Match\\");

                File.Copy(CommonCls.xmlpath + CommonCls.MatchId + "-in-match.xml", CommonCls.xmlpath + "Match\\" + CommonCls.MatchId + "-in-match_" + CommonCls.RaidNo + "_END.xml", true);
            }
            catch (Exception EX)
            {
                MessageBox.Show("Xml Push Failed. - " + EX.ToString());
            }
        }

        private void pnlPitchMap_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                pnlPitchMap.Refresh();
                Graphics g = pnlPitchMap.CreateGraphics();
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
                pnlPitchMap.Hide();

                if (TouchClick)
                    btnTouch_Click(sender, e);
                if (TackleClick)
                    btnTackle_Click(sender, e);
            }
            catch { }
        }

        private void rbTeamINPlayerFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (InorOutplayer == 1)
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
            else
            {
                if (rbTeamAIN.Checked)
                {
                    loadInplayerList(" And L.ClubID=" + CommonCls.ClubId1);
                    BindOutplayer(" And L.ClubID=" + CommonCls.ClubId1);
                }
                else if (rbTeamBIN.Checked)
                {
                    loadInplayerList(" And L.ClubID=" + CommonCls.ClubId2);
                    BindOutplayer(" And L.ClubID=" + CommonCls.ClubId2);
                }
                else
                {
                    loadInplayerList("");
                    BindOutplayer("");
                }
            }
        }

        private void chkLineoutShowAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowAll.Checked)
            {
                RaidFilter = ""; DefFilter = "";
                LoadRaider_Defender(RaidClubId, DefenceClubId,false);
               // showLineoutPlayers();
            }
            else
            {
                RaidFilter = " And L.PlayerID IN(Select PlayerID from Inplayerlist where matchid=" + Temp_matchid + " and clubid=" + RaidClubId + " and RaidNo=" + CurRaidno + ")";
                DefFilter = " And L.PlayerID IN(Select PlayerID from Inplayerlist where matchid=" + Temp_matchid + " and clubid=" + DefenceClubId + " and RaidNo=" + CurRaidno + ")";

                LoadRaider_Defender(RaidClubId, DefenceClubId,false);
                showLineoutPlayers();
            }
              
        }

        private void llblRemovePlayer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            rbTeamAIN.Checked = false;
            rbTeamBIN.Checked = false;
            lblInorOutPlayer.Text = "OUT PLAYER"; 
            InorOutplayer = 2;
            loadInplayerList("");
            BindOutplayer("");
            pnlInPlayer.Show();
            pnlInPlayer.BringToFront();
        }

   
    }
    public class IdentityUpdateEventArgs : System.EventArgs
    {
        public IdentityUpdateEventArgs()
        {
        }
    }
}
