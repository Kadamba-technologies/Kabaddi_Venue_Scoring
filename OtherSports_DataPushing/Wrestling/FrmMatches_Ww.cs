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

namespace OtherSports_DataPushing.Wrestling
{
    public partial class FrmMatches_Ww : Form
    {
        public FrmMatches_Ww()
        {
            InitializeComponent();
        }

        BusinessLy objMB = new BusinessLy();
        int ID = 0;
        DataTable DT, Dt;
        Boolean pageload = false, LoadPlayer = false, LoadTeam = false;
        bool pbAColor = false;
        bool pbBColor = false;
        string type = "";

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "Edit")
            {
                pageload = false;
                bindMatches();
                lblName.Visible = true;
                cbName.Visible = true;
                btnEdit.Text = "New";
                BindCategory();
                bindData();
                ID = objMB.ExeQueryStrIntBL("Select Isnull(Max(MatchId),0)+1 from WW_Matches", 1);
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
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!pageload) { return; }

                int MatchTypeId = Convert.ToInt32(cbMatchType.SelectedValue);
                if (cbCompetition.SelectedIndex == -1 || cbVenue.SelectedIndex == -1 || cbTeamA.SelectedIndex == -1 || cbTeamA.SelectedIndex == -1 || cbMatchType.SelectedIndex == -1)
                {
                    MessageBox.Show("Enter All Fields", mycommon.ApplicationName + " Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if ((cbTeamA.SelectedValue == cbTeamB.SelectedValue))
                {
                    MessageBox.Show("Teams Must be Differ", mycommon.ApplicationName + " Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((cbTeamA.Text == cbTeamB.Text))
                {
                    MessageBox.Show("Teams Must be Differ", mycommon.ApplicationName + " Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //if (rbSingles.Checked == true)
                //{
                //    type = rbSingles.Name.Replace("rb", "");
                //}
                //else if (rbDoubles.Checked == true)
                //{
                //    type = rbDoubles.Name.Replace("rb", "");
                //}
                if (btnSubmit.Text == "Submit")
                {
                    ID = objMB.ExeQueryStrIntBL("Select Isnull(Max(MatchId),0)+1 from WW_Matches", 1);
                    lblMatchID.Text = ID.ToString();
                    bool Success = false;
                    GlobalAssingvalues();
                    Success = objMB.ExeQueryRetBooDL("Insert Into WW_Matches(MatchId,CompetitionID,MatchTypeID,TeamA,TeamB,VenueID,[Date],ClubAColor,ClubBColor,StageType,Category,EventName,RoundType)values(" + mycommon.MatchId + "," + mycommon.CompId + "," + cbMatchType.SelectedValue + "," + cbTeamA.SelectedValue + "," + cbTeamB.SelectedValue + "," + cbVenue.SelectedValue + ",'" + dtpMatchDate.Value + "','" + mycommon.TeamAColor + "','" + mycommon.TeamBColor + "','" + cbstage.Text.Replace("'", "''") + "','" + cbcategory.SelectedValue + "','" + cbEvename.SelectedValue + "','" + cbRoundType.SelectedValue + "');", 1);

                    if (Success)
                    {
                        MessageBox.Show("Insert Sucessfully", mycommon.ApplicationName + " Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GlobalAssingvalues();
                        btnSubmit.Text = "Update";
                        btnEdit.Text = "Edit";
                    }
                    else
                    {
                        MessageBox.Show("Error Please Check It", mycommon.ApplicationName + " Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                else if (btnSubmit.Text == "Update")
                {
                    bool Success = false;
                    GlobalAssingvalues();
                    Success = objMB.ExeQueryRetBooDL("UPDATE WW_Matches SET CompetitionID = " + mycommon.CompId + ",MatchTypeID = " + cbMatchType.SelectedValue + ",TeamA = " + cbTeamA.SelectedValue + ",TeamB = " + cbTeamB.SelectedValue + ",VenueID = " + cbVenue.SelectedValue + ",[Date] = '" + dtpMatchDate.Value + "',ClubAColor = '" + mycommon.TeamAColor + "',ClubBColor = '" + mycommon.TeamBColor + "',StageType = '" + cbstage.Text.Replace("'", "''") + "',Category = '" + cbcategory.SelectedValue + "',EventName = '" + cbEvename.SelectedValue + "',RoundType= '" + cbRoundType.SelectedValue + "' WHERE MatchID = " + mycommon.MatchId, 1);

                    if (Success)
                    {
                        MessageBox.Show("Update Sucessfully", mycommon.ApplicationName + " Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnSubmit.Text = "Submit";
                        btnEdit.Text = "New";
                        GlobalAssingvalues();
                    }
                    else
                    {
                        MessageBox.Show("Error Please Check It", mycommon.ApplicationName + " Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                if (objMB.ExeQueryStrRetDTBL("Select * From WW_Lineup where Matchid=" + mycommon.MatchId + "", 1).Rows.Count > 0)
                    objMB.ExeQueryRetBooDL("Delete from WW_Lineup where Matchid=" + mycommon.MatchId + " ", 1);

                try
                {
                    objMB.ExeQueryRetBooDL("Insert into WW_Lineup values(" + mycommon.MatchId + "," + cbTeamA.SelectedValue + "," + cbPlayerA.SelectedValue + ",0,1,0,'" + cbColorA.Text + "')", 1);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Team A Lineup Insert Error "+ex.ToString());
                }
                try
                {
                    objMB.ExeQueryRetBooDL("Insert into WW_Lineup values(" + mycommon.MatchId + "," + cbTeamB.SelectedValue + "," + cbPlayerB.SelectedValue + ",0,1,0,'" + cbColorB.Text + "')", 1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Team A Lineup Insert Error " + ex.ToString());
                }


                try
                {
                    objMB.ExeQueryRetBooDL("Update Player_Master set DisplayName='" + txtPlayerA.Text.Trim() + "' Where ID=" + cbPlayerA.SelectedValue + "", 1);
                    objMB.ExeQueryRetBooDL("Update Player_Master set DisplayName='" + txtPlayerB.Text.Trim() + "' Where ID=" + cbPlayerB.SelectedValue +"", 1);
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }

            }
            catch
            {
                MessageBox.Show("Error On DataBase", mycommon.ApplicationName + " Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                mycommon.singledouble = type;
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
                string Prefix = objMB.ExeQueryStrRetStrBL("Select Prefix from Team_Master Where TeamId=" + TeamId + "", 1);

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
            cbRoundType.SelectedIndex = -1;
            dtpMatchDate.Value = System.DateTime.Now;
            cbName.SelectedIndex = -1;
            btnSubmit.Text = "Submit";
            btnEdit.Text = "Edit";
            cbName.Hide();
            lblName.Hide();
            cbPlayerA.SelectedIndex = -1;
            cbPlayerB.SelectedIndex = -1;

            //rbSingles.Checked = false;
            //rbDoubles.Checked = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        void bindData()
        {
            DT = new DataTable();
            if (mycommon.SportID == 2)
            {
                Dictionary<int, string> comboSource = new Dictionary<int, string>();
                comboSource.Add(1, "Team-Wise");
                comboSource.Add(2, "Players-Wise");
                cbMatchType.DataSource = new BindingSource(comboSource, null);
                cbMatchType.DisplayMember = "Value";
                cbMatchType.ValueMember = "Key";
                cbMatchType.SelectedIndex = -1;

                cbVenue.DataSource = objMB.ExeQueryStrRetDTBL("Select ID,Name from Venue_Master", 1);
                cbVenue.DisplayMember = "Name";
                cbVenue.ValueMember = "ID";
                cbVenue.SelectedIndex = -1;

                cbCompetition.DataSource = objMB.ExeQueryStrRetDTBL("Select CompID ID,Name from Competition --Where SportID=" + mycommon.SportID + "", 1);
                cbCompetition.DisplayMember = "Name";
                cbCompetition.ValueMember = "ID";
                cbCompetition.SelectedIndex = -1;


                cbstage.DataSource = objMB.ExeQueryStrRetDTBL("Select distinct StageType Stage from WW_Matches", 1);
                cbstage.DisplayMember = "Stage";
                cbstage.ValueMember = "Stage";
                cbstage.SelectedIndex = -1;


                cbRoundType.DataSource = objMB.ExeQueryStrRetDTBL("Select ID,RoundType Name from WW_RoundType", 1);
                cbRoundType.DisplayMember = "Name";
                cbRoundType.ValueMember = "ID";
                cbRoundType.SelectedIndex = -1;
                
            }
        }

        void bindMatches()
        {
            cbName.DataSource = objMB.ExeQueryStrRetDTBL("Select MatchID,CAST(MatchID As Varchar)+' - '+dbo.fn_GetMatchName_WW(MatchId)Name from WW_Matches Order by date desc", 1);
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
                    DT = objMB.ExeQueryStrRetDTBL("Select * from WW_Matches where MatchID=" + cbName.SelectedValue + "", 1);
                    if (DT.Rows.Count > 0)
                    {

                        cbCompetition.SelectedValue = DT.Rows[0]["CompetitionID"].ToString();
                        cbVenue.SelectedValue = DT.Rows[0]["VenueID"].ToString();
                        cbTeamA.SelectedValue = DT.Rows[0]["TeamA"].ToString();
                        cbTeamB.SelectedValue = DT.Rows[0]["TeamB"].ToString();
                        dtpMatchDate.Value = Convert.ToDateTime(DT.Rows[0]["Date"]);
                        cbMatchType.SelectedValue = Convert.ToInt32(DT.Rows[0]["MatchTypeID"]);
                        cbstage.Text = DT.Rows[0]["StageType"].ToString();
                        cbcategory.SelectedValue = DT.Rows[0]["Category"].ToString();
                        cbEvename.SelectedValue = DT.Rows[0]["EventName"].ToString();
                        mycommon.MatchId = Convert.ToInt32(cbName.SelectedValue);
                        try
                        {

                            cbRoundType.SelectedValue = DT.Rows[0]["RoundType"].ToString();
                        }
                        catch { }
                        GlobalAssingvalues();
                        cbstage.DataSource = DT;
                        cbstage.DisplayMember = "StageType";             
           
                        try
                        {
                           
                            cbPlayerA.SelectedValue=objMB.ExeQueryStrIntBL("Select PlayerID from WW_Lineup where Matchid="+mycommon.MatchId+" And Clubid="+cbTeamA.SelectedValue+"", 1);
                            cbColorA.Text = objMB.ExeQueryStrRetStrBL("Select Color from WW_Lineup where Matchid=" + mycommon.MatchId + " And Clubid=" + cbTeamA.SelectedValue + "", 1);
                            txtPlayerA.Text = objMB.ExeQueryStrRetStrBL("Select dbo.fn_GetPlayerFullName(" + cbPlayerA.SelectedValue + ")", 1);
                        }
                        catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                        try
                        {

                            cbPlayerB.SelectedValue = objMB.ExeQueryStrIntBL("Select PlayerID from WW_Lineup where Matchid=" + mycommon.MatchId + " And Clubid=" + cbTeamB.SelectedValue + "", 1);
                            cbColorB.Text = objMB.ExeQueryStrRetStrBL("Select Color from WW_Lineup where Matchid=" + mycommon.MatchId + " And Clubid=" + cbTeamB.SelectedValue + "", 1);
                            txtPlayerB.Text = objMB.ExeQueryStrRetStrBL("Select dbo.fn_GetPlayerFullName(" + cbPlayerB.SelectedValue + ")", 1);
                        }
                        catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                   
                        //if (mycommon.Type == "Singles")
                        //{
                        //    rbSingles.Checked = true;
                        //}
                        //else if (mycommon.Type == "Doubles")
                        //{
                        //    rbDoubles.Checked = true;
                        //}
                    }
                }
            }
            catch
            {

            }
        }

        private void btnLineup_Click(object sender, EventArgs e)
        {
            GlobalAssingvalues();
            FrmLineup_Ww frmLine = new FrmLineup_Ww();
            frmLine.Show();
        }

        private void cbCompetition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageload) { return; }

            pageload = false;
            cbTeamA.DataSource = objMB.ExeQueryStrRetDTBL("Select distinct TeamID, dbo.fn_GetTeamName(TeamID)Name from CompetitionTeam Where CompID=" + cbCompetition.SelectedValue + " Order by Name", 1);
            cbTeamA.DisplayMember = "Name";
            cbTeamA.ValueMember = "TeamID";
            cbTeamA.SelectedIndex = -1;


            cbTeamB.DataSource = objMB.ExeQueryStrRetDTBL("Select distinct TeamID, dbo.fn_GetTeamName(TeamID)Name from CompetitionTeam Where CompID=" + cbCompetition.SelectedValue + " Order by Name", 1);
            cbTeamB.DisplayMember = "Name";
            cbTeamB.ValueMember = "TeamID";
            cbTeamB.SelectedIndex = -1;

            pageload = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to continue to delete Match", mycommon.ApplicationName + " Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (objMB.ExeQueryRetBooDL("delete from WW_Matches where MatchId=" + lblMatchID.Text.Trim() + "", 1))
                {
                    MessageBox.Show("Delete Sucessfully", mycommon.ApplicationName + " Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSubmit.Text = "Submit";
                    GlobalAssingvalues();
                    Clear();
                }
                else
                {
                    MessageBox.Show("Error Please Check It", mycommon.ApplicationName + " Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {

        }

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
                mycommon.TeamAColor = Name;
                pbTeamA.BackColor = Color.FromName(Name);
            }
            else if (pbBColor)
            {
                mycommon.TeamBColor = Name;
                pbTeamB.BackColor = Color.FromName(Name);
            }
            pnlColor.Hide();
        }

        private void BindCategory()
        {
            DataTable dtEventName = objMB.ExeQueryStrRetDTBL("SELECT * FROM WW_EventName", 1);
            cbEvename.DataSource = dtEventName;
            cbEvename.DisplayMember = "EventName";
            cbEvename.ValueMember = "ID";
            cbEvename.SelectedIndex = -1;

            DataTable dtcat = new DataTable();
            dtcat.Columns.Add("Category");
            dtcat.Columns.Add("ID");
            dtcat.Rows.Add("Under 17 Boys", 1);
            dtcat.Rows.Add("Under 17 Girls", 2);
            cbcategory.DataSource = dtcat;
            cbcategory.DisplayMember = "Category";
            cbcategory.ValueMember = "ID";
            cbcategory.SelectedIndex = -1;
        }

        private void FrmMatches_Ww_Load(object sender, EventArgs e)
        {
            bindMatches();
            bindData();
            BindCategory();
            ID = objMB.ExeQueryStrIntBL("Select Isnull(Max(MatchId),0)+1 from WW_Matches", 1);
            lblMatchID.Text = ID.ToString();
            dtpMatchDate.Value = System.DateTime.Now;
            pageload = true;
        }

        private void cbTeamA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageload) { return; }
            GetPlayerABind();
        }

        public void GetPlayerABind()
        {
            try
            {
                objMB = new BusinessLy();
                DataTable Dt3 = new DataTable();
                    pageload = false;
                cbPlayerA.DataSource = objMB.ExeQueryStrRetDTBL("select PlayerId ID,Cast(JercyNo As varchar)+' - '+dbo.fn_GetPlayerName(playerID) Name,JercyNo from CompetitionSquad Where TeamID=" + cbTeamA.SelectedValue + " and CompId=" + cbCompetition.SelectedValue + " order by JercyNo asc", 1);
                cbPlayerA.DisplayMember = "Name";
                cbPlayerA.ValueMember = "ID";
                cbPlayerA.SelectedIndex = -1;
                pageload = true;
            }
            catch
            {
                MessageBox.Show("Error on Player name fill", mycommon.ApplicationName + " Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cbTeamB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageload) { return; }
            GetPlayerBBind();
        }

        public void GetPlayerBBind()
        {
            try
            {
                objMB = new BusinessLy();
                DataTable Dt3 = new DataTable();
                pageload = false;
                cbPlayerB.DataSource = objMB.ExeQueryStrRetDTBL("select PlayerId ID,Cast(JercyNo As varchar)+' - '+dbo.fn_GetPlayerName(playerID) Name,JercyNo from CompetitionSquad Where TeamID=" + cbTeamB.SelectedValue + " and CompId=" + cbCompetition.SelectedValue + " order by JercyNo asc", 1);
                cbPlayerB.DisplayMember = "Name";
                cbPlayerB.ValueMember = "ID";
                cbPlayerB.SelectedIndex = -1;
                pageload = true;
            }
            catch
            {
                MessageBox.Show("Error on Player name fill", mycommon.ApplicationName + " Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cbColorA_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

    }
}
