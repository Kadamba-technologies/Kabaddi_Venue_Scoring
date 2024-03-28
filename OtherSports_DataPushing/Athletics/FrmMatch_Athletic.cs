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

namespace OtherSports_DataPushing
{
    public partial class FrmMatch_Athletic : Form
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
        public FrmMatch_Athletic()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "Edit")
            {
                bindMatches();
                lblName.Visible = true;
                cbName.Visible = true;
                btnEdit.Text = "New";

                pageload = false;
                bindData();
                ID = objMB.ExeQueryStrIntBL("Select Isnull(Max(MatchId),0)+1 from AthleticMatches", 1);
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
                if (cbEventMaster.SelectedIndex == -1 || cbVenue.SelectedIndex == -1 || cbMatchType.SelectedIndex == -1 || cbRoundType.SelectedIndex == -1)
                {
                    MessageBox.Show("Enter All Fields", "Athletic Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (btnSubmit.Text == "Submit")
                {
                    ID = objMB.ExeQueryStrIntBL("Select Isnull(Max(MatchId),0)+1 from AthleticMatches", 1);
                    lblMatchID.Text = ID.ToString();
                    bool Success = false;
                    Success = objMB.ExeQueryRetBooDL("Insert Into AthleticMatches (MatchId,VenueID,Date,EventID,MatchTypeID,RoundID)values(" + ID + "," + cbVenue.SelectedValue + ",'" + dtpMatchDate.Value + "'," + cbEventMaster.SelectedValue + "," + cbMatchType.SelectedValue + "," + cbRoundType.SelectedValue + ")", 1);

                    if (Success)
                    {
                        MessageBox.Show("Insert Sucessfully", "Athletic Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GlobalAssingvalues();
                        btnEdit.Text = "Edit";
                    }
                    else
                    {
                        MessageBox.Show("Error Please Check It", "Athletic Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                else if (btnSubmit.Text == "Update")
                {
                    bool Success = false;
                    Success = objMB.ExeQueryRetBooDL("Update AthleticMatches set VenueID=" + cbVenue.SelectedValue + ",Date='" + dtpMatchDate.Value + "',EventID=" + cbEventMaster.SelectedValue + ",MatchTypeID=" + cbMatchType.SelectedValue + ",RoundID="+cbRoundType.SelectedValue+" where MatchId=" + lblMatchID.Text.Trim() + "", 1);

                    if (Success)
                    {
                        MessageBox.Show("Update Sucessfully", "Athletic Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnSubmit.Text = "Submit";
                        GlobalAssingvalues();
                    }
                    else
                    {
                        MessageBox.Show("Error Please Check It", "Athletic Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch
            {
                MessageBox.Show("Error On DataBase", "Athletic Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void GlobalAssingvalues()
        {
            FrmOpenMatches objfrm = new FrmOpenMatches();
            if (!CheckOpened(objfrm.Text))
            {
                mycommon.MatchId = Convert.ToInt32(lblMatchID.Text);
                mycommon.MatchTypeId = Convert.ToInt32(cbMatchType.SelectedValue);
                mycommon.MatchDate = dtpMatchDate.Value;
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
            cbVenue.SelectedIndex = -1;
            cbMatchType.SelectedIndex = -1;
            cbEventMaster.SelectedIndex = -1;
            cbRoundType.SelectedIndex = -1;
            dtpMatchDate.Value = System.DateTime.Now;
            cbName.SelectedIndex = -1;
            btnSubmit.Text = "Submit";
            btnEdit.Text = "Edit";
            cbName.Hide();
            lblName.Hide();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void FrmMatches_Load(object sender, EventArgs e)
        {
            bindMatches();
            bindData();
            ID = objMB.ExeQueryStrIntBL("Select Isnull(Max(MatchId),0)+1 from AthleticMatches", 1);
            lblMatchID.Text = ID.ToString();
            dtpMatchDate.Value = System.DateTime.Now;
            pageload = true;
        }

        void bindData()
        {
            cbEventMaster.DataSource = objMB.ExeQueryStrRetDTBL("Select ID,Name from AthleticEventMaster where SportID="+mycommon.SportID+"", 1);
            cbEventMaster.DisplayMember = "Name";
            cbEventMaster.ValueMember = "ID";
            cbEventMaster.SelectedIndex = -1;

            cbRoundType.DataSource = objMB.ExeQueryStrRetDTBL("Select ID,RoundName Name from RoundType", 1);
            cbRoundType.DisplayMember = "Name";
            cbRoundType.ValueMember = "ID";
            cbRoundType.SelectedIndex = -1;

            cbMatchType.DataSource = objMB.ExeQueryStrRetDTBL("Select ID, Name from AthleticMatchType", 1);
            cbMatchType.DisplayMember = "Name";
            cbMatchType.ValueMember = "ID";
            cbMatchType.SelectedIndex = -1;

            cbVenue.DataSource = objMB.ExeQueryStrRetDTBL("Select ID,Name from Venue_Master", 1);
            cbVenue.DisplayMember = "Name";
            cbVenue.ValueMember = "ID";
            cbVenue.SelectedIndex = -1;
        }
         
        void bindMatches()
        {
            cbName.DataSource = objMB.ExeQueryStrRetDTBL("Select MatchID,CAST(MatchID As Varchar)+' - '+dbo.fn_GetMatchNamePreDate_Athletic(MatchId)Name from AthleticMatches Order by MatchID asc", 1);
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
                    DT = objMB.ExeQueryStrRetDTBL("Select * from AthleticMatches where MatchID=" + cbName.SelectedValue + "", 1);
                    if (DT.Rows.Count > 0)
                    {
                        cbVenue.SelectedValue = DT.Rows[0]["VenueID"].ToString();
                        dtpMatchDate.Value = Convert.ToDateTime(DT.Rows[0]["Date"]);
                        cbEventMaster.SelectedValue = DT.Rows[0]["EventID"].ToString();
                        cbRoundType.SelectedValue = DT.Rows[0]["RoundID"].ToString();
                        cbMatchType.SelectedValue = DT.Rows[0]["MatchTypeID"].ToString();
                        CommonCls.MatchId = Convert.ToInt32(cbName.SelectedValue);
                        GlobalAssingvalues();
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
            FrmLineup_Athletic frmLine = new FrmLineup_Athletic();
            frmLine.Show();
        }

        private void cbCompetition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageload) { return; }

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
            if(MessageBox.Show("Do you want to continue to delete Match", "Athletic Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information)==DialogResult.Yes)
            {
                if (objMB.ExeQueryRetBooDL("delete from AthleticMatches where ID=" + lblMatchID.Text.Trim() + "", 1))
              {
                  MessageBox.Show("Delete Sucessfully", "Athletic Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  btnSubmit.Text = "Submit";
                  GlobalAssingvalues();
                  Clear();
              }
              else
              {
                  MessageBox.Show("Error Please Check It", "Athletic Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
              }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
           
        }
    }
}
