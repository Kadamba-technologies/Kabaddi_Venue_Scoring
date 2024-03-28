using OtherSports_DataPushing.Athletics;
using OtherSports_DataPushing.Kho_Kho;
using OtherSports_DataPushing.Layer;
using OtherSports_DataPushing.Volley_Ball;
using OtherSports_DataPushing.Wrestling;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtherSports_DataPushing
{
    public partial class FrmOpenMatches : Form
    {
        BusinessLy objMB = new BusinessLy();
        DataTable DT,DtGrid;
        bool Pageload = false;
        public FrmOpenMatches()
        {
            InitializeComponent();
        }

        private void FrmOpenMatches_Load(object sender, EventArgs e)
        {
            Pageload = true;
            bindComp();
            Pageload = false;
            BindGrid();
        }

        void bindComp()
        {
           // Pageload = true;
            cbCompetition.DataSource = objMB.ExeQueryStrRetDTBL("Select CompID ID,Name from Competition  Where SportID=" + mycommon.SportID + "", 1);
            cbCompetition.DisplayMember = "Name";
            cbCompetition.ValueMember = "ID";
            cbCompetition.SelectedIndex = -1;
            cbCompetition.SelectedValue = CommonCls.CompId;
          //  Pageload = false;
        }

        void BindGrid()
        {
            if (Pageload) { return; }
            DtGrid = new DataTable();
            if (mycommon.SportID == 15)
                DtGrid = objMB.ExeQueryStrRetDTBL("select MatchId as MatchID,[dbo].[fn_GetCompetitionName](CompID) CompetitionName ,[dbo].[fn_GetMatchName_BM](MatchId,MatchType) MatchName,convert(char, date, 107)Date from BM_Matches where competitionid=" + cbCompetition.SelectedValue + " Order by MatchID desc", 1);

            if (mycommon.SportID == 8)
                DtGrid = objMB.ExeQueryStrRetDTBL("select Distinct Ma.Matchid,cmp.name as CompetitionName,TA.TeamName+' Vs '+TB.TeamName MatchName,convert(char, date, 107)Date from KB_Matches Ma Join MatchHalf MH ON Ma.MatchID=MH.Matchid inner join Team_Master TA on TA.TeamID=Ma.TeamA inner join Team_Master TB on TB.TeamID=Ma.TeamB inner join Competition cmp on Ma.competitionid=cmp.CompID where Ma.competitionid=" + cbCompetition.SelectedValue + " Order by Ma.Matchid desc", 1);

            if (mycommon.SportID == 14)
                DtGrid = objMB.ExeQueryStrRetDTBL("select Distinct Ma.Matchid,cmp.name as CompetitionName,TA.TeamName+' Vs '+TB.TeamName MatchName,convert(char, date, 107)Date from BB_Matches Ma Left Join BB_MatchQuarters MH ON Ma.MatchID=MH.Matchid inner join Team_Master TA on TA.TeamID=Ma.TeamA inner join Team_Master TB on TB.TeamID=Ma.TeamB inner join Competition cmp on Ma.competitionid=cmp.CompID where Ma.competitionid=" + cbCompetition.SelectedValue + " Order by Ma.Matchid desc", 1);

            if (mycommon.SportID == 4)
                DtGrid = objMB.ExeQueryStrRetDTBL("select Distinct Ma.Matchid,cmp.name as CompetitionName,TA.TeamName+' Vs '+TB.TeamName MatchName,convert(char, date, 107)Date from VB_Matches Ma LEFT Join SetCard_VB MH ON Ma.MatchID=MH.Matchid LEFT join Team_Master TA on TA.TeamID=Ma.TeamA LEFT join Team_Master TB on TB.TeamID=Ma.TeamB LEFT join Competition cmp on Ma.competitionid=cmp.CompID where Ma.competitionid=" + cbCompetition.SelectedValue + " Order by Ma.Matchid desc", 1);

            if (mycommon.SportID == 2   )
//                DT = objMB.ExeQueryStrRetDTBL("select Distinct Ma.Matchid,cmp.name as CompetitionName,TA.TeamName+' Vs '+TB.TeamName+' - '+case when Category=1 then 'Under 17 Boys' else 'Under 17 Girls' end MatchName,convert(char, date, 107)Date from WW_Matches Ma LEFT Join KK_MatchInnings MH ON Ma.MatchID=MH.Matchid LEFT join Team_Master TA on TA.TeamID=Ma.TeamA LEFT join Team_Master TB on TB.TeamID=Ma.TeamB LEFT join Competition cmp on Ma.competitionid=cmp.CompID Order by Ma.Matchid desc", 1);
                DtGrid = objMB.ExeQueryStrRetDTBL("select Distinct Ma.Matchid,dbo.fn_GetEventName_WW(EventName) as CompetitionName,dbo.fn_GetMatchName_WW(Ma.Matchid) MatchName,convert(char, date, 107)Date from WW_Matches Ma LEFT Join KK_MatchInnings MH ON Ma.MatchID=MH.Matchid LEFT join Team_Master TA on TA.TeamID=Ma.TeamA LEFT join Team_Master TB on TB.TeamID=Ma.TeamB LEFT join Competition cmp on Ma.competitionid=cmp.CompID where Ma.competitionid=" + cbCompetition.SelectedValue + " Order by Ma.Matchid desc", 1);

            if (mycommon.SportID == 16)
                DtGrid = objMB.ExeQueryStrRetDTBL("select Distinct Ma.Matchid,'' CompetitionName, Isnull(Ev.Name,'') MatchName ,convert(char, date, 107)Date from AthleticMatches Ma LEFT join AthleticEventMaster Ev on Ev.ID=Ma.EventID  Order by Ma.Matchid desc", 1);
          
            if (mycommon.SportID == 7)
                DtGrid = objMB.ExeQueryStrRetDTBL("select Distinct Ma.Matchid,cmp.name as CompetitionName,TA.TeamName+' Vs '+TB.TeamName MatchName,convert(char, date, 107)Date from KK_Matches Ma LEFT Join KK_MatchInnings MH ON Ma.MatchID=MH.Matchid LEFT join Team_Master TA on TA.TeamID=Ma.TeamA LEFT join Team_Master TB on TB.TeamID=Ma.TeamB LEFT join Competition cmp on Ma.competitionid=cmp.CompID where Ma.competitionid=" + cbCompetition.SelectedValue + " Order by Ma.Matchid desc", 1);

            if (DtGrid.Rows.Count > 0)
            {
                gvMatches.AutoGenerateColumns = false;
                gvMatches.DataSource = DtGrid;
            }
        }

        private void gvMatches_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                objMB = new BusinessLy();
                DT = new DataTable();
                if (mycommon.SportID == 15)
                {
                    mycommon.MatchId = Convert.ToInt32(gvMatches.Rows[e.RowIndex].Cells["Matchid"].Value);
                    DT = new DataTable();
                    DT = objMB.ExeQueryStrRetDTBL("Select MatchId,Date,[dbo].[fn_GetMatchName_BM](MatchId,MatchType) Match,MatchType,dbo.fn_GetCompetitionName(CompID)CompetitionName,TeamA,dbo.fn_GetTeamName(TeamA)TeamAName,TeamB,dbo.fn_GetTeamName(TeamB)TeamBName,dbo.fn_GetTeamNameprefix(TeamA)TeamAPrefix,dbo.fn_GetTeamNameprefix(teamB)TeamBPrefix ,CompID,Type from BM_Matches Where MatchId=" + mycommon.MatchId, 1);
                    if (DT.Rows.Count > 0)
                    {
                        //FrmScoringPageOld objfrm = new FrmScoringPageOld();
                        FrmBadminton objfrm = new FrmBadminton();
                        //FrmScoring objfrm = new FrmScoring();
                        if (!CheckOpened(objfrm.Text))
                        {
                            mycommon.MatchDate = Convert.ToDateTime(DT.Rows[0]["Date"].ToString());
                            mycommon.MatchTypeId = Convert.ToInt32(DT.Rows[0]["MatchType"].ToString());
                            mycommon.CompId = Convert.ToInt32(DT.Rows[0]["CompID"].ToString());
                            mycommon.TeamID1 = Convert.ToInt32(DT.Rows[0]["TeamA"].ToString());
                            mycommon.TeamID2 = Convert.ToInt32(DT.Rows[0]["TeamB"].ToString());
                            mycommon.Team1Name = DT.Rows[0]["TeamAName"].ToString();
                            mycommon.Team2Name = DT.Rows[0]["TeamBName"].ToString();
                            mycommon.Team1Prefix = DT.Rows[0]["TeamAPrefix"].ToString();
                            mycommon.Team2Prefix = DT.Rows[0]["TeamBPrefix"].ToString();
                            mycommon.Type = DT.Rows[0]["Type"].ToString();
                            this.Dispose(true);
                            this.Hide();
                            objfrm.Show();
                            objfrm.BringToFront();
                        }
                        else
                        {
                            MessageBox.Show("Scoring Page Already Open", mycommon.ApplicationName + " Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                }
                if (mycommon.SportID == 8)
                {
                    CommonCls.MatchId = Convert.ToInt32(gvMatches.Rows[e.RowIndex].Cells["Matchid"].Value);
                    DT = objMB.ExeQueryStrRetDTBL("Select M.Matchid,convert(datetime,Date) [Date],dbo.fn_GetMatchNamePreDate_KB(M.Matchid)MatchName,dbo.fn_GetCompetitionName(CompetitionID)CompetitionName,teamA,TeamB,dbo.fn_GetTeamName(teamA)ClubAName,dbo.fn_GetTeamName(TeamB)ClubBName,dbo.fn_GetTeamNameprefix(TeamA)ClubAPrefix,dbo.fn_GetTeamNameprefix(teamB)ClubBPrefix ,CompetitionID,ClubAColor,ClubBColor from KB_Matches M  Where M.Matchid=" + CommonCls.MatchId + "", 1);
                    if (DT.Rows.Count > 0)
                    {
                        FrmKabaddiScoring Objfrm = new FrmKabaddiScoring();
                        this.Dispose(true);
                        if (!CheckOpened(Objfrm.Text))
                        {
                            CommonCls.MatchDate = Convert.ToDateTime(DT.Rows[0]["Date"].ToString());
                            CommonCls.CompId = Convert.ToInt32(DT.Rows[0]["CompetitionID"].ToString());
                            CommonCls.ClubId1 = Convert.ToInt32(DT.Rows[0]["TeamA"].ToString());
                            CommonCls.ClubId2 = Convert.ToInt32(DT.Rows[0]["TeamB"].ToString());
                            CommonCls.Club1Name = DT.Rows[0]["ClubAName"].ToString();
                            CommonCls.Club2Name = DT.Rows[0]["ClubBName"].ToString();
                            CommonCls.Club1Prefix = DT.Rows[0]["ClubAPrefix"].ToString();
                            CommonCls.Club2Prefix = DT.Rows[0]["ClubBPrefix"].ToString();
                            CommonCls.Club1Prefix = DT.Rows[0]["ClubAPrefix"].ToString();
                            CommonCls.Club2Prefix = DT.Rows[0]["ClubBPrefix"].ToString();
                            CommonCls.TeamAColor = DT.Rows[0]["ClubAColor"].ToString();
                            CommonCls.TeamBColor = DT.Rows[0]["ClubBColor"].ToString();
                            Objfrm.Score_Matchid = CommonCls.MatchId;
                            Objfrm.Score_HalfID = CommonCls.HalfID;
                            Objfrm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Scoring Page Already Open", "Kabaddi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                }
                if (mycommon.SportID == 14)
                {
                    mycommon.MatchId = Convert.ToInt32(gvMatches.Rows[e.RowIndex].Cells["Matchid"].Value);
                    DT = objMB.ExeQueryStrRetDTBL("Select M.Matchid,Date,[dbo].[fn_GetMatchName_BB](M.Matchid)MatchName,dbo.fn_GetCompetitionName(CompetitionID)CompetitionName,TeamA,TeamB,dbo.fn_GetTeamName(teamA)ClubAName,dbo.fn_GetTeamName(TeamB)ClubBName,dbo.fn_GetTeamNameprefix(TeamA)ClubAPrefix,dbo.fn_GetTeamNameprefix(teamB)ClubBPrefix ,CompetitionID from BB_Matches M  Where M.Matchid=" + mycommon.MatchId + "", 1);
                    if (DT.Rows.Count > 0)
                    {
                        FrmBasketBall Objfrm = new FrmBasketBall();
                        this.Dispose(true);
                        if (!CheckOpened(Objfrm.Text))
                        {
                            mycommon.MatchDate = Convert.ToDateTime(DT.Rows[0]["Date"].ToString());
                            mycommon.CompId = Convert.ToInt32(DT.Rows[0]["CompetitionID"].ToString());
                            mycommon.TeamID1 = Convert.ToInt32(DT.Rows[0]["TeamA"].ToString());
                            mycommon.TeamID2 = Convert.ToInt32(DT.Rows[0]["TeamB"].ToString());
                            mycommon.Team1Name = DT.Rows[0]["ClubAName"].ToString();
                            mycommon.Team2Name = DT.Rows[0]["ClubBName"].ToString();
                            mycommon.Team1Prefix = DT.Rows[0]["ClubAPrefix"].ToString();
                            mycommon.Team2Prefix = DT.Rows[0]["ClubBPrefix"].ToString();
                            mycommon.MatchName = DT.Rows[0]["MatchName"].ToString();
                            //Objfrm.Score_Matchid = CommonCls.MatchId;
                            Objfrm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Scoring Page Already Open", mycommon.ApplicationName + " Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                }
                if (mycommon.SportID == 4)
                {
                    mycommon.MatchId = Convert.ToInt32(gvMatches.Rows[e.RowIndex].Cells["Matchid"].Value);
                    DT = objMB.ExeQueryStrRetDTBL("Select M.Matchid,Date,[dbo].[fn_GetMatchName_VB](M.Matchid)MatchName,dbo.fn_GetCompetitionName(CompetitionID)CompetitionName,teamA,TeamB,dbo.fn_GetTeamName(teamA)ClubAName,dbo.fn_GetTeamName(TeamB)ClubBName,dbo.fn_GetTeamNameprefix(TeamA)ClubAPrefix,dbo.fn_GetTeamNameprefix(teamB)ClubBPrefix ,CompetitionID from VB_Matches M  Where M.Matchid=" + mycommon.MatchId + "", 1);
                    if (DT.Rows.Count > 0)
                    {
                        FrmVolleyBall Objfrm = new FrmVolleyBall();
                        this.Dispose(true);
                        if (!CheckOpened(Objfrm.Text))
                        {
                            mycommon.MatchDate = Convert.ToDateTime(DT.Rows[0]["Date"].ToString());
                            mycommon.CompId = Convert.ToInt32(DT.Rows[0]["CompetitionID"].ToString());
                            mycommon.TeamID1 = Convert.ToInt32(DT.Rows[0]["TeamA"].ToString());
                            mycommon.TeamID2 = Convert.ToInt32(DT.Rows[0]["TeamB"].ToString());
                            mycommon.Team1Name = DT.Rows[0]["ClubAName"].ToString();
                            mycommon.Team2Name = DT.Rows[0]["ClubBName"].ToString();
                            mycommon.Team1Prefix = DT.Rows[0]["ClubAPrefix"].ToString();
                            mycommon.Team2Prefix = DT.Rows[0]["ClubBPrefix"].ToString();
                            mycommon.MatchName = DT.Rows[0]["MatchName"].ToString();
                            //Objfrm.Score_Matchid = CommonCls.MatchId;
                            Objfrm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Scoring Page Already Open", mycommon.ApplicationName+" Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                }
                if (mycommon.SportID == 7)
                {
                    mycommon.MatchId = Convert.ToInt32(gvMatches.Rows[e.RowIndex].Cells["Matchid"].Value);
                    DT = objMB.ExeQueryStrRetDTBL("Select M.Matchid,Date,[dbo].[fn_GetMatchName_KK](M.Matchid)MatchName,dbo.fn_GetCompetitionName(CompetitionID)CompetitionName,teamA,TeamB,dbo.fn_GetTeamName(teamA)ClubAName,dbo.fn_GetTeamName(TeamB)ClubBName,dbo.fn_GetTeamNameprefix(TeamA)ClubAPrefix,dbo.fn_GetTeamNameprefix(teamB)ClubBPrefix ,CompetitionID from KK_Matches M  Where M.Matchid=" + mycommon.MatchId + "", 1);
                    if (DT.Rows.Count > 0)
                    {
                        //Frmtoss Objfrm = new Frmtoss();
                        FrmKhoKho Objfrm = new FrmKhoKho();
                        this.Dispose(true);
                        if (!CheckOpened(Objfrm.Text))
                        {
                            mycommon.MatchDate = Convert.ToDateTime(DT.Rows[0]["Date"].ToString());
                            mycommon.CompId = Convert.ToInt32(DT.Rows[0]["CompetitionID"].ToString());
                            mycommon.TeamID1 = Convert.ToInt32(DT.Rows[0]["TeamA"].ToString());
                            mycommon.TeamID2 = Convert.ToInt32(DT.Rows[0]["TeamB"].ToString());
                            mycommon.Team1Name = DT.Rows[0]["ClubAName"].ToString();
                            mycommon.Team2Name = DT.Rows[0]["ClubBName"].ToString();
                            mycommon.Team1Prefix = DT.Rows[0]["ClubAPrefix"].ToString();
                            mycommon.Team1Prefix = DT.Rows[0]["ClubBPrefix"].ToString();
                            mycommon.MatchName = DT.Rows[0]["MatchName"].ToString();

                            //Objfrm.Score_Matchid = CommonCls.MatchId;

                            Objfrm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Scoring Page Already Open", mycommon.ApplicationName + " Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                }
                if (mycommon.SportID == 16)
                {
                    CommonCls.MatchId = Convert.ToInt32(gvMatches.Rows[e.RowIndex].Cells["Matchid"].Value);
                    DT = objMB.ExeQueryStrRetDTBL("Select M.Matchid,Date,dbo.fn_GetMatchNamePreDate_Athletic(M.Matchid)MatchName from AthleticMatches M Where M.Matchid=" + CommonCls.MatchId + "", 1);
                    if (DT.Rows.Count > 0)
                    {
                        frmResult_Athletic Objfrm = new frmResult_Athletic();
                        this.Dispose(true);
                        if (!CheckOpened(Objfrm.Text))
                        {
                            CommonCls.MatchDate = Convert.ToDateTime(DT.Rows[0]["Date"].ToString());
                            Objfrm.Score_Matchid = CommonCls.MatchId;
                            Objfrm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Scoring Page Already Open", mycommon.ApplicationName + " Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                }


                if (mycommon.SportID == 2)
                {
                    mycommon.MatchId = Convert.ToInt32(gvMatches.Rows[e.RowIndex].Cells["Matchid"].Value);
                    DT = objMB.ExeQueryStrRetDTBL("Select M.Matchid,Date,[dbo].[fn_GetMatchName_WW](M.Matchid)MatchName,dbo.fn_GetCompetitionName(CompetitionID)CompetitionName,teamA,TeamB,dbo.fn_GetTeamName(teamA)ClubAName,dbo.fn_GetTeamName(TeamB)ClubBName,ClubAColor,ClubBColor,dbo.fn_GetTeamNameprefix(TeamA)ClubAPrefix,dbo.fn_GetTeamNameprefix(teamB)ClubBPrefix,CompetitionID,Category,dbo.fn_GetEventName_WW(EventName)EventName from WW_Matches M  Where M.Matchid=" + mycommon.MatchId + "", 1);
                    if (DT.Rows.Count > 0)
                    {
                        FrmWrestling Objfrm = new FrmWrestling();
                        this.Dispose(true);
                        if (!CheckOpened(Objfrm.Text))
                        {
                            mycommon.MatchDate = Convert.ToDateTime(DT.Rows[0]["Date"].ToString());
                            mycommon.CompId = Convert.ToInt32(DT.Rows[0]["CompetitionID"].ToString());
                            mycommon.TeamID1 = Convert.ToInt32(DT.Rows[0]["teamA"].ToString());
                            mycommon.TeamID2 = Convert.ToInt32(DT.Rows[0]["TeamB"].ToString());
                            mycommon.Team1Name = DT.Rows[0]["ClubAName"].ToString();
                            mycommon.Team2Name = DT.Rows[0]["ClubBName"].ToString();
                            mycommon.Team1Prefix = DT.Rows[0]["ClubAPrefix"].ToString();
                            mycommon.Team2Prefix = DT.Rows[0]["ClubBPrefix"].ToString();
                            //mycommon.TeamAColor = DT.Rows[0]["ClubAColor"].ToString();
                            //mycommon.TeamBColor = DT.Rows[0]["ClubBColor"].ToString();
                            mycommon.MatchName = DT.Rows[0]["MatchName"].ToString();
                            mycommon.WWCategory = DT.Rows[0]["Category"].ToString();
                            mycommon.EventName = DT.Rows[0]["EventName"].ToString();
                            //Objfrm.Score_Matchid = CommonCls.MatchId;


                            mycommon.TeamAColor = objMB.ExeQueryStrRetStrBL("Select Color from WW_Lineup where Matchid=" + mycommon.MatchId + " And Clubid=" + mycommon.TeamID1 + "", 1);
                            mycommon.TeamBColor = objMB.ExeQueryStrRetStrBL("Select Color from WW_Lineup where Matchid=" + mycommon.MatchId + " And Clubid=" + mycommon.TeamID2 + "", 1);
           

                            Objfrm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Scoring Page Already Open", mycommon.ApplicationName + " Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                }

                if (mycommon.SportID == 7)
                {
                    mycommon.MatchId = Convert.ToInt32(gvMatches.Rows[e.RowIndex].Cells["Matchid"].Value);
                    DT = objMB.ExeQueryStrRetDTBL("Select M.Matchid,Date,[dbo].[fn_GetMatchName_KK](M.Matchid)MatchName,dbo.fn_GetCompetitionName(CompetitionID)CompetitionName,teamA,TeamB,dbo.fn_GetTeamName(teamA)ClubAName,dbo.fn_GetTeamName(TeamB)ClubBName,dbo.fn_GetTeamNameprefix(TeamA)ClubAPrefix,dbo.fn_GetTeamNameprefix(teamB)ClubBPrefix ,CompetitionID from KK_Matches M  Where M.Matchid=" + mycommon.MatchId + "", 1);
                    if (DT.Rows.Count > 0)
                    {
                        FrmKhoKho Objfrm = new FrmKhoKho();
                        this.Dispose(true);
                        if (!CheckOpened(Objfrm.Text))
                        {
                            mycommon.MatchDate = Convert.ToDateTime(DT.Rows[0]["Date"].ToString());
                            mycommon.CompId = Convert.ToInt32(DT.Rows[0]["CompetitionID"].ToString());
                            mycommon.TeamID1 = Convert.ToInt32(DT.Rows[0]["TeamA"].ToString());
                            mycommon.TeamID2 = Convert.ToInt32(DT.Rows[0]["TeamB"].ToString());
                            mycommon.Team1Name = DT.Rows[0]["ClubAName"].ToString();
                            mycommon.Team2Name = DT.Rows[0]["ClubBName"].ToString();
                            mycommon.Team1Prefix = DT.Rows[0]["ClubAPrefix"].ToString();
                            mycommon.Team2Prefix = DT.Rows[0]["ClubBPrefix"].ToString();
                            mycommon.MatchName = DT.Rows[0]["MatchName"].ToString();
                            //Objfrm.Score_Matchid = CommonCls.MatchId;

                            Objfrm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Scoring Page Already Open", mycommon.ApplicationName + " Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                }
            }
            catch { }
        }

        private bool CheckOpened(string name)
        {
            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc)
            {
                if (frm.Text == name)
                {
                    return true;
                }
            }
            return false;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable Dt = new DataTable();

                Dt.Columns.Add("MatchID");
                Dt.Columns.Add("Date");
                Dt.Columns.Add("MatchName");
                Dt.Columns.Add("CompetitionName");

                if (txtSearch.Text != "")
                {
                    //foreach (DataRow dr in _DGviewDT.Select("Competitionid like '%" + txtSearch.Text + "%'"))
                    foreach (DataRow dr in DtGrid.Select(string.Format("convert(MatchID, 'System.String') Like '%{0}%'", Convert.ToInt32(txtSearch.Text))))
                    {
                        DataRow dr1 = dr;
                        Dt.ImportRow(dr);
                    }
                    gvMatches.DataSource = Dt;
                }
                else
                {
                    gvMatches.DataSource = DtGrid;
                }


            }
            catch
            {

            }
        }

        private void gvMatches_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbCompetition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Pageload) { return; }
            BindGrid();

            //cbCompetition.SelectedValue = CommonCls.CompId;
        }
    }
}
