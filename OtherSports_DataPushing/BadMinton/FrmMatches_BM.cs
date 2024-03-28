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

namespace OtherSports_DataPushing.BadMinton
{
    public partial class FrmMatches_BM : Form
    {
        public FrmMatches_BM()
        {
            InitializeComponent();
        }
        BusinessLy objMB = new BusinessLy();
        int ID = 0;
        DataTable DT, Dt;
        Boolean pageload = false, LoadPlayer = false, LoadTeam = false;
        string type = "";

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "Edit")
            {
                bindData();
                bindMatches();
                lblName.Visible = true;
                cbName.Visible = true;
                btnEdit.Text = "New";

                pageload = false;
                ID = objMB.ExeQueryStrIntBL("Select Isnull(Max(MatchId),0)+1 from BM_Matches", 1);
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
                    MessageBox.Show("Enter All Fields", "BadMinton Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //if ((cbTeamA.SelectedValue == cbTeamB.SelectedValue))
                //{
                //    MessageBox.Show("Teams Must be Differ", "BadMinton Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}
                //if ((cbTeamA.Text == cbTeamB.Text))
                //{
                //    MessageBox.Show("Teams Must be Differ", "BadMinton Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}
                if (rbSingles.Checked == true)
                {
                    type = rbSingles.Name.Replace("rb", "");
                }
                else if (rbDoubles.Checked == true)
                {
                    type = rbDoubles.Name.Replace("rb", "");
                }
                if (btnSubmit.Text == "Submit")
                {
                    ID = objMB.ExeQueryStrIntBL("Select Isnull(Max(MatchId),0)+1 from BM_Matches", 1);
                    lblMatchID.Text = ID.ToString();
                    bool Success = false;

                    Success = objMB.ExeQueryRetBooDL("Insert Into BM_Matches (MatchId,CompId,VenueID,TeamA,TeamB,Date,MatchType,Type,ClubAColor,ClubBColor,StageType)values(" + ID + "," + cbCompetition.SelectedValue + "," + cbVenue.SelectedValue + "," + cbTeamA.SelectedValue + "," + cbTeamB.SelectedValue + ",'" + dtpMatchDate.Value + "'," + cbMatchType.SelectedValue + ",'" + type + "','" + mycommon.TeamAColor + "','" + mycommon.TeamBColor + "','" + cbStagetype.Text.Replace("'", "''") + "')", 1);

                    if (Success)
                    {
                        MessageBox.Show("Insert Sucessfully", "BadMinton Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GlobalAssingvalues();
                        btnEdit.Text = "Edit";
                    }
                    else
                    {
                        MessageBox.Show("Error Please Check It", "BadMinton Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                else if (btnSubmit.Text == "Update")
                {
                    bool Success = false;

                    Success = objMB.ExeQueryRetBooDL("Update BM_Matches set CompId=" + cbCompetition.SelectedValue + ",VenueID=" + cbVenue.SelectedValue + ",TeamA=" + cbTeamA.SelectedValue + ",TeamB=" + cbTeamB.SelectedValue + ",Date='" + dtpMatchDate.Value + "',MatchType=" + cbMatchType.SelectedValue + ",Type='" + type + "',StageType='" + cbStagetype.Text.Replace("'", "''") + "' where MatchId=" + lblMatchID.Text.Trim() + "", 1);

                    if (Success)
                    {
                        MessageBox.Show("Update Sucessfully", "BadMinton Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnSubmit.Text = "Submit";
                        GlobalAssingvalues();
                    }
                    else
                    {
                        MessageBox.Show("Error Please Check It", "BadMinton Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch
            {
                MessageBox.Show("Error On DataBase", "BadMinton Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            dtpMatchDate.Value = System.DateTime.Now;
            cbName.SelectedIndex = -1;
            cbStagetype.SelectedIndex = -1;
            btnSubmit.Text = "Submit";
            btnEdit.Text = "Edit";
            cbName.Hide();
            lblName.Hide();
            rbSingles.Checked = false;
            rbDoubles.Checked = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        void bindData()
        {
            DT = new DataTable();
            if (mycommon.SportID == 15)
            {
               //// Dictionary<int, string> comboSource = new Dictionary<int, string>();
               // comboSource.Add(1, "Team-Wise");
               // comboSource.Add(2, "Players-Wise");
               // cbMatchType.DataSource = new BindingSource(comboSource, null);

                Dt = new DataTable();
                Dt.Columns.Add("Key");
                Dt.Columns.Add("Value");
                Dt.Rows.Add(1, "Team-Wise");
                Dt.Rows.Add(2, "Players-Wise");
                cbMatchType.DataSource = Dt;
                cbMatchType.DisplayMember = "Value";
                cbMatchType.ValueMember = "Key";
                cbMatchType.SelectedIndex = -1;

                cbVenue.DataSource = objMB.ExeQueryStrRetDTBL("Select ID,Name from Venue_Master", 1);
                cbVenue.DisplayMember = "Name";
                cbVenue.ValueMember = "ID";
                cbVenue.SelectedIndex = -1;

                cbCompetition.DataSource = objMB.ExeQueryStrRetDTBL("Select CompID ID,Name from Competition", 1);
                cbCompetition.DisplayMember = "Name";
                cbCompetition.ValueMember = "ID";
                cbCompetition.SelectedIndex = -1;

                cbStagetype.DataSource = objMB.ExeQueryStrRetDTBL("Select distinct StageType Stage from BM_Matches", 1);
                cbStagetype.DisplayMember = "Stage";
                cbStagetype.ValueMember = "Stage";
                cbStagetype.SelectedIndex = -1;
            }
        }

        void bindMatches()
        {
            try
            {
                cbName.DataSource = objMB.ExeQueryStrRetDTBL("Select MatchID,CAST(MatchID As Varchar)+' - '+dbo.fn_GetMatchNamePreDate_BM(MatchId)Name from BM_Matches Order by date desc", 1);
                cbName.DisplayMember = "Name";
                cbName.ValueMember = "MatchID";
                cbName.SelectedIndex = -1;
            }
            catch { }
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
                    DT = objMB.ExeQueryStrRetDTBL("Select * from BM_Matches where MatchID=" + cbName.SelectedValue + "", 1);
                    if (DT.Rows.Count > 0)
                    {
                        cbCompetition.SelectedValue = DT.Rows[0]["CompID"].ToString();
                        cbVenue.SelectedValue = DT.Rows[0]["VenueID"].ToString();
                        cbTeamA.SelectedValue = DT.Rows[0]["TeamA"].ToString();
                        cbTeamB.SelectedValue = DT.Rows[0]["TeamB"].ToString();
                        dtpMatchDate.Value = Convert.ToDateTime(DT.Rows[0]["Date"]);
                        cbMatchType.SelectedValue = DT.Rows[0]["MatchType"].ToString();
                        mycommon.MatchId = Convert.ToInt32(cbName.SelectedValue);
                        cbStagetype.Text = DT.Rows[0]["StageType"].ToString();
                        GlobalAssingvalues();
                        if (mycommon.Type == "Singles")
                        {
                            rbSingles.Checked = true;
                        }
                        else if (mycommon.Type == "Doubles")
                        {
                            rbDoubles.Checked = true;
                        }
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
            FrmLineup_BM frmLine = new FrmLineup_BM();
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
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to continue to delete Match", "BadMinton Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (objMB.ExeQueryRetBooDL("delete from BM_Matches where ID=" + lblMatchID.Text.Trim() + "", 1))
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

        private void FrmMatches_BM_Load(object sender, EventArgs e)
        {
            bindMatches();
            bindData();
            ID = objMB.ExeQueryStrIntBL("Select Isnull(Max(MatchId),0)+1 from BM_Matches", 1);
            lblMatchID.Text = ID.ToString();
            dtpMatchDate.Value = System.DateTime.Now;
            pageload = true;
        }
    }
}
