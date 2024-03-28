using OtherSports_DataPushing.Kabaddi;
using OtherSports_DataPushing.Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtherSports_DataPushing
{
    public partial class FrmMatches_Kabaddi : Form
    {
        BusinessLy objMB = new BusinessLy();
        int ID = 0;
        DataTable DT, Dt;
        Boolean pageload = false, LoadPlayer = false, LoadTeam = false;

        #region Value Get from CommonCls.cs Static Class Concept
        int Temp_matchid = CommonCls.MatchId;
        int Temp_clubidA = CommonCls.ClubId1;
        int Temp_clubidB = CommonCls.ClubId2;
        #endregion
        public FrmMatches_Kabaddi()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "Edit")
            {
                lblName.Visible = true;
                cbName.Visible = true;
                btnEdit.Text = "New";

                pageload = false;
                bindData();
                cbCompetition.SelectedValue = CommonCls.CompId;
                bindMatches(" Where competitionID=" + cbCompetition.SelectedValue);
                ID = objMB.ExeQueryStrIntBL("Select Isnull(Max(MatchId),0)+1 from KB_Matches", 1);
                lblMatchID.Text = ID.ToString();
                dtpMatchDate.Value = System.DateTime.Now;
                pageload = true;
            }
            else if (btnEdit.Text == "New")
            {
                lblName.Visible = false;
                cbName.Visible = false;
                btnEdit.Text = "Edit";
                btnSubmit.Text = "Submit";
                Clear();
            }

            cbCompetition.SelectedValue = CommonCls.CompId;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                if (!pageload) { return; }

                int MatchTypeId = Convert.ToInt32(cbMatchType.SelectedValue);
                if (cbCompetition.SelectedIndex == -1 || cbVenue.SelectedIndex == -1 || cbStagetype.Text == "" || cbTeamA.SelectedIndex == -1 || cbTeamA.SelectedIndex == -1 || cbGroup.SelectedIndex == -1 || cbLeg.SelectedIndex == -1)// cbMatchType.SelectedIndex == -1)
                {
                    MessageBox.Show("Enter All Fields", "BadMinton Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if ((cbTeamA.SelectedValue == cbTeamB.SelectedValue))
                {
                    MessageBox.Show("Teams Must be Differ", "BadMinton Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((cbTeamA.Text == cbTeamB.Text))
                {
                    MessageBox.Show("Teams Must be Differ", "BadMinton Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //if ((!chkTeamAHome.Checked && !chkTeamBHome.Checked))
                //{
                //    MessageBox.Show("Select Home team", "BadMinton Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}
                if (btnSubmit.Text == "Submit")
                {
                    ID = objMB.ExeQueryStrIntBL("Select Isnull(Max(MatchId),0)+1 from KB_Matches", 1);
                    lblMatchID.Text = ID.ToString();
                    bool Success = false;
                    if (MatchTypeId == 1 || MatchTypeId == 2)
                    {
                        Success = objMB.ExeQueryRetBooDL("Insert Into KB_Matches (MatchId,CompetitionId,VenueID,TeamA,TeamB,Date,ClubAColor,ClubBColor,StageType,RefMatchid,MatchGroup,MatchNo,HomeTeamid,LegID)values(" + ID + "," + cbCompetition.SelectedValue + "," + cbVenue.SelectedValue + "," + cbTeamA.SelectedValue + "," + cbTeamB.SelectedValue + ",'" + dtpMatchDate.Value.ToString("MM/dd/yyyy hh:mm:ss tt") + "','" + CommonCls.TeamAColor + "','" + CommonCls.TeamBColor + "','" + cbStagetype.SelectedValue + "'," + txtRefMatchID.Text + "," + cbGroup.SelectedValue + ",'" + txtMatchNo.Text + "'," + (chkTeamAHome.Checked ? cbTeamA.SelectedValue : (chkTeamBHome.Checked ? cbTeamB.SelectedValue : 0)) + "," + cbLeg.SelectedValue + ")", 1);
                    }
                    else if (MatchTypeId == 3 || MatchTypeId == 4 || MatchTypeId == 5)
                    {
                        Success = objMB.ExeQueryRetBooDL("Insert Into KB_Matches (MatchId,CompetitionId,VenueID,TeamA,TeamB,Date,ClubAColor,ClubBColor,StageType,RefMatchid,MatchGroup,MatchNo,HomeTeamid,LegID)values(" + ID + "," + cbCompetition.SelectedValue + "," + cbVenue.SelectedValue + "," + cbTeamA.SelectedValue + "," + cbTeamB.SelectedValue + ",'" + dtpMatchDate.Value.ToString("MM/dd/yyyy hh:mm:ss tt") + "','" + CommonCls.TeamAColor + "','" + CommonCls.TeamBColor + "','" + cbStagetype.SelectedValue + "'," + txtRefMatchID.Text + "," + cbGroup.SelectedValue + ",'" + txtMatchNo.Text + "'," + (chkTeamAHome.Checked ? cbTeamA.SelectedValue : (chkTeamBHome.Checked ? cbTeamB.SelectedValue : 0)) + "," + cbLeg.SelectedValue + ")", 1);
                    }
                    else
                    {
                        Success = objMB.ExeQueryRetBooDL("Insert Into KB_Matches (MatchId,CompetitionId,VenueID,TeamA,TeamB,Date,ClubAColor,ClubBColor,StageType,RefMatchid,MatchGroup,MatchNo,HomeTeamid,LegID)values(" + ID + "," + cbCompetition.SelectedValue + "," + cbVenue.SelectedValue + "," + cbTeamA.SelectedValue + "," + cbTeamB.SelectedValue + ",'" + dtpMatchDate.Value.ToString("MM/dd/yyyy hh:mm:ss tt") + "','" + CommonCls.TeamAColor + "','" + CommonCls.TeamBColor + "','" + cbStagetype.SelectedValue + "'," + txtRefMatchID.Text + "," + cbGroup.SelectedValue + ",'" + txtMatchNo.Text + "'," + (chkTeamAHome.Checked ? cbTeamA.SelectedValue : (chkTeamBHome.Checked ? cbTeamB.SelectedValue : 0)) + "," + cbLeg.SelectedValue + ")", 1);
                    }
                    if (Success)
                    {
                        MessageBox.Show("Insert Sucessfully", "BadMinton Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        try
                        {
                            int cnt = objMB.ExeQueryStrIntBL("Select ISNULL(Count(*),0)+1 From tblCorrectedTable where Matchid=" + ID + " And tablename='KB_Matches'", 1);
                            objMB.ExeQueryRetBooDL("Insert into tblCorrectedTable (Matchid,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + ID + "," + cnt + ",'KB_Matches','" + System.DateTime.Now + "',1,0,0)", 1);
                        }
                        catch { }
                        GlobalAssingvalues();
                        btnEdit.Text = "Edit";
                        btnToss.Enabled = true;
                        btnLineup.Enabled = true;
                        btnSubmit.Text = "Update";
                        CmdTossOk.Text = "OK";
                    }
                    else
                    {
                        MessageBox.Show("Insert Into KB_Matches (MatchId,CompetitionId,VenueID,TeamA,TeamB,Date,ClubAColor,ClubBColor,StageType,RefMatchid,MatchGroup,MatchNo,HomeTeamid,LegID)values(" + ID + "," + cbCompetition.SelectedValue + "," + cbVenue.SelectedValue + "," + cbTeamA.SelectedValue + "," + cbTeamB.SelectedValue + ",'" + dtpMatchDate.Value.ToString("MM/dd/yyyy hh:mm:ss tt") + "','" + CommonCls.TeamAColor + "','" + CommonCls.TeamBColor + "','" + cbStagetype.SelectedValue + "'," + txtRefMatchID.Text + "," + cbGroup.SelectedValue + ",'" + txtMatchNo.Text + "'," + (chkTeamAHome.Checked ? cbTeamA.SelectedValue : (chkTeamBHome.Checked ? cbTeamB.SelectedValue : 0)) + "," + cbLeg.SelectedValue + ")");
                        MessageBox.Show("Error Please Check It", "BadMinton Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                else if (btnSubmit.Text == "Update")
                {
                    bool Success = false;
                    if (MatchTypeId == 1 || MatchTypeId == 2)
                    {
                        Success = objMB.ExeQueryRetBooDL("Update KB_Matches set CompetitionId=" + cbCompetition.SelectedValue + ",VenueID=" + cbVenue.SelectedValue + ",TeamA=" + cbTeamA.SelectedValue + ",TeamB=" + cbTeamB.SelectedValue + ",Date='" + dtpMatchDate.Value.ToString("MM/dd/yyyy hh:mm:ss tt") + "',StageType='" + cbStagetype.SelectedValue + "',RefMatchID=" + txtRefMatchID.Text + ",ClubAColor='" + CommonCls.TeamAColor + "',ClubBColor='" + CommonCls.TeamBColor + "',MatchGroup=" + cbGroup.SelectedValue + ",MatchNo='" + txtMatchNo.Text + "',HomeTeamid=" + (chkTeamAHome.Checked ? cbTeamA.SelectedValue : (chkTeamBHome.Checked ? cbTeamB.SelectedValue : 0)) + ",LegID=" + cbLeg.SelectedValue + " where MatchId=" + lblMatchID.Text.Trim() + "", 1);
                    }
                    else if (MatchTypeId == 3 || MatchTypeId == 4 || MatchTypeId == 5)
                    {
                        Success = objMB.ExeQueryRetBooDL("Update KB_Matches set CompetitionId=" + cbCompetition.SelectedValue + ",VenueID=" + cbVenue.SelectedValue + ",TeamA=" + cbTeamA.SelectedValue + ",TeamB=" + cbTeamB.SelectedValue + ",Date='" + dtpMatchDate.Value.ToString("MM/dd/yyyy hh:mm:ss tt") + "',StageType='" + cbStagetype.SelectedValue + "',RefMatchID=" + txtRefMatchID.Text + ",ClubAColor='" + CommonCls.TeamAColor + "',ClubBColor='" + CommonCls.TeamBColor + "',MatchGroup=" + cbGroup.SelectedValue + ",MatchNo='" + txtMatchNo.Text + "',HomeTeamid=" + (chkTeamAHome.Checked ? cbTeamA.SelectedValue : (chkTeamBHome.Checked ? cbTeamB.SelectedValue : 0)) + ",LegID=" + cbLeg.SelectedValue + " where MatchId=" + lblMatchID.Text.Trim() + "", 1);
                    }
                    else
                    {
                        Success = objMB.ExeQueryRetBooDL("Update KB_Matches set CompetitionId=" + cbCompetition.SelectedValue + ",VenueID=" + cbVenue.SelectedValue + ",TeamA=" + cbTeamA.SelectedValue + ",TeamB=" + cbTeamB.SelectedValue + ",Date='" + dtpMatchDate.Value.ToString("MM/dd/yyyy hh:mm:ss tt") + "',StageType='" + cbStagetype.SelectedValue + "',RefMatchID=" + txtRefMatchID.Text + ",ClubAColor='" + CommonCls.TeamAColor + "',ClubBColor='" + CommonCls.TeamBColor + "',MatchGroup=" + cbGroup.SelectedValue + ",MatchNo='" + txtMatchNo.Text + "',HomeTeamid=" + (chkTeamAHome.Checked ? cbTeamA.SelectedValue : (chkTeamBHome.Checked ? cbTeamB.SelectedValue : 0)) + ",LegID=" + cbLeg.SelectedValue + " where MatchId=" + lblMatchID.Text.Trim() + "", 1);
                    }
                    if (Success)
                    {
                        MessageBox.Show("Update Sucessfully", "Kabaddi Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        try
                        {
                            int cnt = objMB.ExeQueryStrIntBL("Select ISNULL(Count(*),0)+1 From tblCorrectedTable where Matchid=" + CommonCls.MatchId + " And tablename='KB_Matches'", 1);
                            objMB.ExeQueryRetBooDL("Insert into tblCorrectedTable (Matchid,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + CommonCls.MatchId + "," + cnt + ",'KB_Matches','" + System.DateTime.Now + "',0,1,0)", 1);
                        }
                        catch { }
                        // btnSubmit.Text = "Submit";
                        GlobalAssingvalues();
                    }
                    else
                    {
                        MessageBox.Show("Error Please Check It", "Kabaddi Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error On DataBase", "Kabaddi Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void GlobalAssingvalues()
        {
            FrmOpenMatches objfrm = new FrmOpenMatches();
            if (!CheckOpened(objfrm.Text))
            {
                mycommon.MatchId = Convert.ToInt32(lblMatchID.Text);
                mycommon.MatchTypeId = Convert.ToInt32(cbMatchType.SelectedValue);
                mycommon.CompId = Convert.ToInt32(cbCompetition.SelectedValue);
                mycommon.MatchDate = dtpMatchDate.Value;
                mycommon.TeamID1 = Convert.ToInt32(cbTeamA.SelectedValue);
                mycommon.TeamID2 = Convert.ToInt32(cbTeamB.SelectedValue);
                mycommon.Team1Name = cbTeamA.Text;
                mycommon.Team2Name = cbTeamB.Text;
                mycommon.Team1Prefix = GetTeamPrefix(mycommon.TeamID1);
                mycommon.Team2Prefix = GetTeamPrefix(mycommon.TeamID2);
            }
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

        string GetTeamPrefix(int TeamId)
        {
            try
            {
                string Prefix = objMB.ExeQueryStrRetStrBL("Select Prefix from Team Where Id=" + TeamId + "", 1);

                return Prefix;
            }
            catch
            {
                return "";
            }
        }
        public void Clear()
        {
            cbCompetition.SelectedIndex = -1;
            cbVenue.SelectedIndex = -1;
            cbTeamA.SelectedIndex = -1;
            cbTeamB.SelectedIndex = -1;
            cbMatchType.SelectedIndex = -1;

            cbStagetype.SelectedIndex = -1;
            cbGroup.SelectedIndex = -1;
            cbStagetype.Text = "";
            txtRefMatchID.Text = "";
            txtMatchNo.Text = "";
            dtpMatchDate.Value = System.DateTime.Now;
            cbName.SelectedIndex = -1;
            btnSubmit.Text = "Submit";
            btnEdit.Text = "Edit";
            GBToss.Visible = false;
            btnToss.Enabled = false;
            btnLineup.Enabled = false;

            chkTeamAHome.Checked = false;
            chkTeamBHome.Checked = false;
            cbName.Hide();
            lblName.Hide();
            cbLeg.SelectedIndex = -1;
            cbCompetition.SelectedValue = CommonCls.CompId;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void FrmMatches_Load(object sender, EventArgs e)
        {
            bindMatches("");
            bindData();
            ID = objMB.ExeQueryStrIntBL("Select Isnull(Max(MatchId),0)+1 from KB_Matches", 1);
            lblMatchID.Text = ID.ToString();
            dtpMatchDate.Value = System.DateTime.Now;
            pageload = true;

            cbCompetition.SelectedValue = CommonCls.CompId;
        }

        void bindData()
        {
            DT = new DataTable();
            if (mycommon.SportID == 8)
                DT = objMB.ExeQueryStrRetDTBL("Select ID,Description Name from Stage", 1);

            cbMatchType.DataSource = DT;
            cbMatchType.DisplayMember = "Name";
            cbMatchType.ValueMember = "ID";
            cbMatchType.SelectedIndex = -1;

            cbVenue.DataSource = objMB.ExeQueryStrRetDTBL("Select ID,Name+', '+City Name from Venue_Master", 1);
            cbVenue.DisplayMember = "Name";
            cbVenue.ValueMember = "ID";
            cbVenue.SelectedIndex = -1;

            cbCompetition.DataSource = objMB.ExeQueryStrRetDTBL("Select CompID ID,Name from Competition  Where SportID=" + mycommon.SportID + "", 1);
            cbCompetition.DisplayMember = "Name";
            cbCompetition.ValueMember = "ID";
            cbCompetition.SelectedIndex = -1;
            //cbCompetition.SelectedValue = CommonCls.CompId;


            //cbStagetype.DataSource = objMB.ExeQueryStrRetDTBL("Select distinct StageType Stage from KB_Matches", 1);
            //cbStagetype.DisplayMember = "Stage";
            //cbStagetype.ValueMember = "Stage";
            //cbStagetype.SelectedIndex = -1;

            cbStagetype.DataSource = objMB.ExeQueryStrRetDTBL("Select ID,Description Name from Stage", 1);
            cbStagetype.DisplayMember = "Name";
            cbStagetype.ValueMember = "ID";
            cbStagetype.SelectedIndex = -1;

            cbGroup.DataSource = objMB.ExeQueryStrRetDTBL("SELECT auto_ID ID,groups Name from kb_groups", 1);
            cbGroup.DisplayMember = "Name";
            cbGroup.ValueMember = "ID";
            cbGroup.SelectedIndex = -1;

            cbLeg.DataSource = objMB.ExeQueryStrRetDTBL("Select ID,LegName Name from Leg_Master", 1);
            cbLeg.DisplayMember = "Name";
            cbLeg.ValueMember = "ID";
            cbLeg.SelectedIndex = -1;
        }

        void bindMatches(string Filter)
        {
            cbName.DataSource = objMB.ExeQueryStrRetDTBL("Select MatchID,CAST(MatchID As Varchar)+' - '+dbo.fn_GetMatchNamePreDate_KB(MatchId)Name from KB_Matches " + Filter + " Order by MatchID desc", 1);
            cbName.DisplayMember = "Name";
            cbName.ValueMember = "MatchID";
            cbName.SelectedIndex = -1;
        }

        private void cbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!pageload) { return; }
                btnSubmit.Text = "Update";
                if (cbName.SelectedIndex != -1)
                {
                    lblMatchID.Text = cbName.SelectedValue.ToString();
                    DT = new DataTable();
                    DT = objMB.ExeQueryStrRetDTBL("Select * from KB_Matches where MatchID=" + cbName.SelectedValue + "", 1);
                    if (DT.Rows.Count > 0)
                    {
                        cbCompetition.SelectedValue = DT.Rows[0]["CompetitionID"].ToString();
                        cbVenue.SelectedValue = DT.Rows[0]["VenueID"].ToString();
                        cbTeamA.SelectedValue = DT.Rows[0]["TeamA"].ToString();
                        cbTeamB.SelectedValue = DT.Rows[0]["TeamB"].ToString();
                        try
                        {
                            dtpMatchDate.Value = Convert.ToDateTime(DT.Rows[0]["Date"]);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        //cbMatchType.SelectedValue = DT.Rows[0]["MatchTypeID"].ToString();
                        // cbStagetype.Text = DT.Rows[0]["StageType"].ToString();
                        CommonCls.MatchId = Convert.ToInt32(cbName.SelectedValue);

                        txtRefMatchID.Text = DT.Rows[0]["RefMatchID"].ToString();
                        // MessageBox.Show(DT.Rows[0]["RefMatchID"].ToString());
                        txtMatchNo.Text = DT.Rows[0]["MatchNo"].ToString();
                        GlobalAssingvalues();
                        GBToss.Visible = false;

                        btnToss.Enabled = true;
                        btnLineup.Enabled = true;
                        try
                        {
                            cbStagetype.SelectedValue = DT.Rows[0]["StageType"].ToString();
                        }
                        catch (Exception ex)
                        {
                            // MessageBox.Show(ex.Message);
                            cbStagetype.SelectedIndex = -1;

                        }
                        try
                        {
                            cbGroup.SelectedValue = DT.Rows[0]["MatchGroup"].ToString();
                        }
                        catch (Exception ex)
                        {
                            // MessageBox.Show(ex.Message); cbGroup.SelectedIndex = -1;
                        }

                        try
                        {
                            cbLeg.SelectedValue = DT.Rows[0]["LegID"].ToString();
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); cbLeg.SelectedIndex = -1; }

                        try
                        {
                            if (DT.Rows[0]["TeamA"].ToString() == DT.Rows[0]["HomeTeamid"].ToString())
                                chkTeamAHome.Checked = true;
                            else if (DT.Rows[0]["TeamB"].ToString() == DT.Rows[0]["HomeTeamid"].ToString())
                                chkTeamBHome.Checked = true;
                            else
                            {
                                chkTeamAHome.Checked = false;
                                chkTeamBHome.Checked = false;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message); chkTeamAHome.Checked = false;
                            chkTeamBHome.Checked = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLineup_Click(object sender, EventArgs e)
        {
            GlobalAssingvalues();
            FrmLineup_Kabaddi frmLine = new FrmLineup_Kabaddi();
            frmLine.Show();
        }

        private void cbCompetition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageload) { return; }

            cbTeamA.DataSource = objMB.ExeQueryStrRetDTBL("Select distinct TeamID, dbo.fn_GetTeamName(TeamID)Name from CompetitionTeam Where CompID=" + cbCompetition.SelectedValue + " Order by Name", 1);
            cbTeamA.DisplayMember = "Name";
            cbTeamA.ValueMember = "TeamID";
            cbTeamA.SelectedIndex = -1;


            cbTeamB.DataSource = objMB.ExeQueryStrRetDTBL("Select distinct TeamID, dbo.fn_GetTeamName(TeamID)Name from CompetitionTeam Where CompID=" + cbCompetition.SelectedValue + " Order by Name", 1);
            cbTeamB.DisplayMember = "Name";
            cbTeamB.ValueMember = "TeamID";
            cbTeamB.SelectedIndex = -1;
            if (btnEdit.Text == "New")
                bindMatches(" Where CompetitionID=" + cbCompetition.SelectedValue);
        }

        private void cbTeamA_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cbTeamB_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cbMatchType_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to continue to delete Match", "BadMinton Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (objMB.ExeQueryRetBooDL("delete from KB_Matches where ID=" + lblMatchID.Text.Trim() + "", 1))
                {
                    MessageBox.Show("Delete Sucessfully", "BadMinton Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSubmit.Text = "Submit";
                    GlobalAssingvalues();
                    Clear();
                }
                else
                {
                    MessageBox.Show("Error Please Check It", "BadMinton Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {

        }

        private void CmdTossOk_Click(object sender, EventArgs e)
        {
            objMB = new BusinessLy();

            GlobalAssingvalues();
            Temp_matchid = CommonCls.MatchId;
            string SentQuery;
            int LHSClubID = 0, RHSClubID = 0;

            if (CbRHSClubID.Text.Trim() == cbTeamA.Text.Trim())
            {
                RHSClubID = Convert.ToInt32(cbTeamA.SelectedValue);
            }
            else
            {
                RHSClubID = Convert.ToInt32(cbTeamB.SelectedValue);
            }

            if (CbLHSClubID.Text.Trim() == cbTeamA.Text.Trim())
            {
                LHSClubID = Convert.ToInt32(cbTeamA.SelectedValue);
            }
            else
            {
                LHSClubID = Convert.ToInt32(cbTeamB.SelectedValue);
            }
            //  string Query = "Select Count(*) from MatchHalf where matchid=" + mycommon.MatchId + "";
            string Query = "Select Count(*) from MatchHalf where matchid=" + mycommon.MatchId + "";
            if (objMB.ExeQueryStrIntBL(Query, 1) > 0)
            {
                if (CMTossWinTeam.Text == cbTeamA.Text)
                {
                    //1st innings
                    SentQuery = "Update MatchHalf Set LeftClubID='" + LHSClubID + "',RightClubID='" + RHSClubID + "',TossWin='" + cbTeamA.SelectedValue + "',Description='" + CMOption.Text + "' Where Matchid=" + mycommon.MatchId + " AND HalfID=1";
                    objMB.ExeQueryRetBooDL(SentQuery, 1);
                    //2nd innings
                    SentQuery = "Update MatchHalf Set LeftClubID='" + RHSClubID + "',RightClubID='" + LHSClubID + "',TossWin='" + cbTeamA.SelectedValue + "',Description='" + CMOption.Text + "' Where Matchid=" + mycommon.MatchId + " AND HalfID=2";
                    objMB.ExeQueryRetBooDL(SentQuery, 1);
                }

                if (CMTossWinTeam.Text == cbTeamB.Text)
                {
                    //1st innings
                    SentQuery = "Update MatchHalf Set LeftClubID='" + LHSClubID + "',RightClubID='" + RHSClubID + "',TossWin='" + cbTeamB.SelectedValue + "',Description='" + CMOption.Text + "' Where Matchid=" + mycommon.MatchId + " AND HalfID=1";
                    objMB.ExeQueryRetBooDL(SentQuery, 1);

                    //2nd innings
                    SentQuery = "Update MatchHalf Set LeftClubID='" + RHSClubID + "',RightClubID='" + LHSClubID + "',TossWin='" + cbTeamB.SelectedValue + "',Description='" + CMOption.Text + "' Where Matchid=" + mycommon.MatchId + " AND HalfID=2";
                    objMB.ExeQueryRetBooDL(SentQuery, 1);
                }
                try
                {
                    int cnt = objMB.ExeQueryStrIntBL("Select ISNULL(Count(*),0)+1 From tblCorrectedTable where Matchid=" + CommonCls.MatchId + " And tablename='MatchHalf'", 1);
                    objMB.ExeQueryRetBooDL("Insert into tblCorrectedTable (Matchid,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + CommonCls.MatchId + "," + cnt + ",'MatchHalf','" + System.DateTime.Now + "',0,1,0)", 1);
                }
                catch { }
            }
            else
            {
                if (CMTossWinTeam.Text == cbTeamA.Text)
                {
                    //1st innings
                    SentQuery = "Insert into MatchHalf(Matchid,HalfID,LeftClubID,RightClubID,TossWin,Description,HalfStart,HalfEnd) values(" + mycommon.MatchId + ",1,'" + LHSClubID + "','" + RHSClubID + "','" + cbTeamA.SelectedValue + "','" + CMOption.Text + "',0,0)";
                    objMB.ExeQueryRetBooDL(SentQuery, 1);
                    //2nd innings
                    SentQuery = "Insert into MatchHalf(Matchid,HalfID,LeftClubID,RightClubID,TossWin,Description,HalfStart,HalfEnd) values(" + mycommon.MatchId + ",2,'" + RHSClubID + "','" + LHSClubID + "','" + cbTeamA.SelectedValue + "','" + CMOption.Text + "',0,0)";
                    objMB.ExeQueryRetBooDL(SentQuery, 1);
                }

                if (CMTossWinTeam.Text == cbTeamB.Text)
                {
                    //1st innings
                    SentQuery = "Insert into MatchHalf(Matchid,HalfID,LeftClubID,RightClubID,TossWin,Description,HalfStart,HalfEnd) values(" + mycommon.MatchId + ",1,'" + LHSClubID + "','" + RHSClubID + "','" + cbTeamB.SelectedValue + "','" + CMOption.Text + "',0,0)";
                    objMB.ExeQueryRetBooDL(SentQuery, 1);
                    //2nd innings
                    SentQuery = "Insert into MatchHalf(Matchid,HalfID,LeftClubID,RightClubID,TossWin,Description,HalfStart,HalfEnd) values(" + mycommon.MatchId + ",2,'" + RHSClubID + "','" + LHSClubID + "','" + cbTeamB.SelectedValue + "','" + CMOption.Text + "',0,0)";
                    objMB.ExeQueryRetBooDL(SentQuery, 1);
                }
                try
                {
                    int cnt = objMB.ExeQueryStrIntBL("Select ISNULL(Count(*),0)+1 From tblCorrectedTable where Matchid=" + mycommon.MatchId + " And tablename='MatchHalf'", 1);
                    objMB.ExeQueryRetBooDL("Insert into tblCorrectedTable (Matchid,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + mycommon.MatchId + "," + cnt + ",'MatchHalf','" + System.DateTime.Now + "',1,0,0)", 1);
                }
                catch { }
            }
            GBToss.Visible = false;
            btnLineup.Enabled = true;
        }

        private void btnToss_Click(object sender, EventArgs e)
        {
            CMTossWinTeam.SelectedIndex = -1;
            CMOption.SelectedIndex = -1;
            GlobalAssingvalues();
            CMTossWinTeam.Items.Clear();
            CbRHSClubID.Items.Clear();
            CbLHSClubID.Items.Clear();

            CMTossWinTeam.Items.Add(cbTeamA.Text);
            CMTossWinTeam.Items.Add(cbTeamB.Text);

            //RHS
            CbRHSClubID.Items.Add(cbTeamA.Text);
            CbRHSClubID.Items.Add(cbTeamB.Text);
            //LHS
            CbLHSClubID.Items.Add(cbTeamA.Text);
            CbLHSClubID.Items.Add(cbTeamB.Text);

            GBToss.Visible = true;

            try
            {
                Dt = new DataTable();
                Dt = objMB.ExeQueryStrRetDTBL("select * from matchhalf where matchid='" + mycommon.MatchId + "' order by halfid", 1);
                if (Dt.Rows.Count > 0)
                {
                    if (cbTeamA.SelectedValue.ToString() == Dt.Rows[0]["Tosswin"].ToString())
                    {
                        CMTossWinTeam.Text = cbTeamA.Text;
                    }
                    else if (cbTeamB.SelectedValue.ToString() == Dt.Rows[0]["Tosswin"].ToString())
                    {
                        CMTossWinTeam.Text = cbTeamB.Text;
                    }
                    CMOption.Text = Dt.Rows[0]["Description"].ToString();

                    if (cbTeamA.SelectedValue.ToString() == Dt.Rows[0]["RightClubID"].ToString())
                    {
                        CbRHSClubID.Text = cbTeamA.Text;
                    }
                    else if (cbTeamB.SelectedValue.ToString() == Dt.Rows[0]["RightClubID"].ToString())
                    {
                        CbRHSClubID.Text = cbTeamB.Text;
                    }

                    if (cbTeamA.SelectedValue.ToString() == Dt.Rows[0]["LeftClubID"].ToString())
                    {
                        CbLHSClubID.Text = cbTeamA.Text;
                    }
                    else if (cbTeamB.SelectedValue.ToString() == Dt.Rows[0]["LeftClubID"].ToString())
                    {
                        CbLHSClubID.Text = cbTeamB.Text;
                    }
                    CmdTossOk.Text = "Update";
                }
            }
            catch
            {
                MessageBox.Show("Error on Toss Click", "Kabaddi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        bool pbAColor = false;
        bool pbBColor = false;
        private void pbTeamA_Click(object sender, EventArgs e)
        {
            pbAColor = true;
            pbBColor = false;
            pnlColor.Show();
        }

        private void pbTeamB_Click(object sender, EventArgs e)
        {
            pbAColor = false;
            pbBColor = true;
            pnlColor.Show();
        }

        private void pbColor_Click(object sender, EventArgs e)
        {
            string Name = ((Control)sender).Name.Replace("pb", "");
            if (pbAColor)
            {
                CommonCls.TeamAColor = Name;
                pbTeamA.BackColor = Color.FromName(Name);
            }
            else if (pbBColor)
            {
                CommonCls.TeamBColor = Name;
                pbTeamB.BackColor = Color.FromName(Name);
            }
            pnlColor.Hide();
        }

        private void btnPrematchXml_Click(object sender, EventArgs e)
        {
            XMLPush("");
        }

        KabaddiXmlGenerate Xml = new KabaddiXmlGenerate();
        void XMLPush(string Format)
        {
            try
            {
                var ccc = cbCompetition.Text;
                var digits = ccc.Where(Char.IsDigit).ToArray();
                var test = digits[0].ToString();
                if (digits.Length > 5)
                    test = digits[0].ToString()+digits[1].ToString();
                //Xml.GeneratePrematchXML(objMB.ExeQueryStrRetDsBL("EXEC SP_PreMatchXML " + CommonCls.MatchId, 1), CommonCls.xmlpath + "pre-match_" + CommonCls.MatchId + "m.xml");
                Xml.GeneratePrematchXML(objMB.ExeQueryStrRetDsBL("EXEC SP_PreMatchXML " + CommonCls.MatchId, 1), CommonCls.xmlpath + "pre-match_" + test + "m.xml");

                File.Copy(CommonCls.xmlpath + "pre-match_" + test + "m.xml", CommonCls.xmlpath1 + "\\pre-match_" + test + "m.xml", true);
                MessageBox.Show("Pre-Match Xml Pushed Successfully. ");
            }
            catch (Exception EX)
            {
                MessageBox.Show("Pre-Match Xml Push Failed. - " + EX.ToString());
            }
        }
        void legwisexml(string Format)
        {
            try
            {
                Xml.GenerateLegWiseXml(objMB.ExeQueryStrRetDsBL("EXEC [dbo].[SP_PreMatchXML_LW]  " + CommonCls.MatchId, 1), CommonCls.xmlpath + "7m_legdata.xml");

                File.Copy(CommonCls.xmlpath + "7m_legdata.xml", CommonCls.xmlpath1 + "\\7m_legdata.xml", true);
                MessageBox.Show("Pre-Match_Legwise Xml Pushed Successfully. ");
            }
            catch
            {
                MessageBox.Show("Pre-Match_Legwise Xml Push Failed ... ");
            }
        }





        void IN_MatchXMLPush()
        {

            if (string.IsNullOrEmpty(CommonCls.xmlpath))
                return;
            try
            {

                var dt = objMB.ExeQueryStrRetDsBL("SP_GetCurrentIN_Outplayer " + CommonCls.MatchId + "", 1);
                CommonCls.TeamADIPXML = dt.Tables[0].Rows.Count;
                CommonCls.TeamBDIPXML = dt.Tables[1].Rows.Count;


                if (!CommonCls.XmlPush) { return; }
                Xml.GenerateXML(objMB.ExeQueryStrRetDsBL("EXEC SP_MatchXML " + CommonCls.MatchId, 1), CommonCls.xmlpath + CommonCls.MatchId + "-in-match.xml");
                if (!Directory.Exists(CommonCls.xmlpath))
                    Directory.CreateDirectory(CommonCls.xmlpath);
                if (!Directory.Exists(CommonCls.xmlpath + "Match\\"))
                    Directory.CreateDirectory(CommonCls.xmlpath + "Match\\");
                if (!Directory.Exists(CommonCls.xmlpath + "Match\\" + CommonCls.MatchId))
                    Directory.CreateDirectory(CommonCls.xmlpath + "Match\\" + CommonCls.MatchId);

                //  File.Copy(CommonCls.xmlpath + CommonCls.MatchId + "-in-match.xml", CommonCls.xmlpath + "Match\\" + CommonCls.MatchId + "\\" + CommonCls.MatchId + "-in-match_dummy.xml", true);
                File.Copy(CommonCls.xmlpath + CommonCls.MatchId + "-in-match.xml", CommonCls.xmlpath + "Match\\" + CommonCls.MatchId + "\\" + CommonCls.MatchId + "-in-match.xml", true);
                if (string.IsNullOrEmpty(CommonCls.xmlpath1))
                    File.Copy(CommonCls.xmlpath1 + CommonCls.MatchId + "-in-match.xml", CommonCls.xmlpath1 + "Match\\" + CommonCls.MatchId + "\\" + CommonCls.MatchId + "-in-match.xml", true);

                File.Copy(CommonCls.xmlpath + CommonCls.MatchId + "-in-match.xml", CommonCls.xmlpath1 + "\\" + CommonCls.MatchId + "-in-match.xml", true);
                MessageBox.Show("IN-Match Xml Pushed Successfully.");
            }
            catch (Exception EX)
            {
                MessageBox.Show("IN-Match Xml Push Failed. - " + EX.ToString());
            }
        }

        private void chkTeamAHome_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTeamAHome.Checked)
            {
                chkTeamBHome.Checked = false;
                chkTeamAHome.Checked = true;
            }
        }

        private void chkTeamBHome_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTeamBHome.Checked)
            {
                chkTeamBHome.Checked = true;
                chkTeamAHome.Checked = false;
            }
        }

        private void btnINMatchXml_Click(object sender, EventArgs e)
        {
            IN_MatchXMLPush();
        }

        private void btnLegxml_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to publish " + cbVenue.Text + " xml", "BadMinton Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                legwisexml("");
            }
        }

        private void btnPrematchXmlWeekly_Click(object sender, EventArgs e)
        {
            XMLPush_weekly("");
        }
        void XMLPush_weekly(string Format)
        {
            try
            {
                var ccc = cbCompetition.Text;
                var digits = new String(ccc.Where(Char.IsDigit).ToArray());
                //Xml.GeneratePrematchXML(objMB.ExeQueryStrRetDsBL("EXEC SP_PreMatchXML " + CommonCls.MatchId, 1), CommonCls.xmlpath + "pre-match_" + CommonCls.MatchId + "m.xml");
                Xml.GeneratePrematchXML(objMB.ExeQueryStrRetDsBL("EXEC SP_PreMatchXML_Weekly " + CommonCls.MatchId, 1), CommonCls.xmlpath + "Weekly_Data_" + digits[0].ToString() + "m.xml");

                File.Copy(CommonCls.xmlpath + "Weekly_Data_" + digits[0].ToString() + "m.xml", CommonCls.xmlpath1 + "\\Weekly_Data_" + digits[0].ToString() + "m.xml", true);
                MessageBox.Show("Pre-Match Xml Pushed Successfully. ");
            }
            catch (Exception EX)
            {
                MessageBox.Show("Pre-Match_Weekly Xml Push Failed. - " + EX.ToString());
            }
        }
    }
}
