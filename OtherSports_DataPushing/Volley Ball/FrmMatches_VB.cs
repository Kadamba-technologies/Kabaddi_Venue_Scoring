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
    public partial class FrmMatches_VB : Form
    {
        BusinessLy objMB = new BusinessLy();
        int ID = 0;
        DataTable DT;
        Boolean pageload = false;
        public FrmMatches_VB()
        {
            InitializeComponent();
        }

        private void FrmMatches_VB_Load(object sender, EventArgs e)
        {
            bindData();
            loadmatchtype();
        }
        void bindData()
        {
            try
            {
                cbCompetition.DataSource = objMB.ExeQueryStrRetDTBL("Select CompID,Name from Competition Where SportID=" + mycommon.SportID, 1);
                cbCompetition.DisplayMember = "Name";
                cbCompetition.ValueMember = "CompID";
                cbCompetition.SelectedIndex = -1;

                cbVenue.DataSource = objMB.ExeQueryStrRetDTBL("Select ID,Name from Venue_Master Where SportID="+mycommon.SportID, 1);
                cbVenue.DisplayMember = "Name";
                cbVenue.ValueMember = "ID";
                cbVenue.SelectedIndex = -1;

                cbTeamA.DataSource = objMB.ExeQueryStrRetDTBL("Select TeamID,TeamName from Team_Master", 1);
                cbTeamA.DisplayMember = "TeamName";
                cbTeamA.ValueMember = "TeamID";
                cbTeamA.SelectedIndex = -1;

                cbTeamB.DataSource = objMB.ExeQueryStrRetDTBL("Select TeamID,TeamName from Team_Master", 1);
                cbTeamB.DisplayMember = "TeamName";
                cbTeamB.ValueMember = "TeamID";
                cbTeamB.SelectedIndex = -1;
            }
            catch { }
        }

        void loadmatchtype()
        {
            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            comboSource.Add(1, "Team-Wise");
            comboSource.Add(2, "Players-Wise");
            cbMatchtype.DataSource = new BindingSource(comboSource, null);
            cbMatchtype.DisplayMember = "Value";
            cbMatchtype.ValueMember = "Key";
            cbMatchtype.SelectedIndex = -1;
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
           clear();
        }
        void clear()
        {
            cbCompetition.SelectedIndex = -1;
            cbVenue.SelectedIndex = -1;
            cbTeamA.SelectedIndex = -1;
            cbTeamB.SelectedIndex = -1;
            cbMatchtype.SelectedIndex = -1;
            dtpMatchDate.Value = System.DateTime.Now;
        }
        void GlobalAssingvalues(int ID)
        {
            mycommon.MatchId = ID;
            mycommon.CompId = Convert.ToInt32(cbCompetition.SelectedValue);
            mycommon.MatchDate = Convert.ToDateTime(dtpMatchDate.Value);
            mycommon.TeamID1 = Convert.ToInt32(cbTeamA.SelectedValue);
            mycommon.TeamID2 = Convert.ToInt32(cbTeamB.SelectedValue);
            mycommon.Team1Name = cbTeamA.Text;
            mycommon.Team2Name = cbTeamB.Text;
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbCompetition.SelectedValue.ToString() == "" || cbVenue.SelectedValue.ToString() == "" || cbTeamA.SelectedValue.ToString() == "" || cbTeamA.SelectedValue.ToString() == "")
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
                ID = objMB.ExeQueryStrIntBL("Select Isnull(Max(MatchID),0)+1 from VB_Matches", 1);
                if (objMB.ExeQueryRetBooDL("Insert Into VB_Matches (MatchId,CompetitionID,MatchTypeID,TeamA,TeamB,VenueId,Date)values(" + ID + "," + cbCompetition.SelectedValue + "," + cbMatchtype.SelectedValue + "," + cbTeamA.SelectedValue + "," + cbTeamB.SelectedValue + "," + cbVenue.SelectedValue + ",'" + dtpMatchDate.Value + "')", 1))
                {
                    MessageBox.Show("Insert Sucessfully", mycommon.ApplicationName + " Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    GlobalAssingvalues(ID);
                }
                else
                {
                    MessageBox.Show("Error Please Check It", mycommon.ApplicationName + " Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch { }
        }

        private void btnLineup_Click(object sender, EventArgs e)
        {
            FrmLineup_VB frmLine = new FrmLineup_VB();
            frmLine.Show();
        }

        private void cbMatchtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cbMatchtype.SelectedValue) == 1)
                {
                    cbTeamA.Enabled = true;
                    cbTeamB.Enabled = true;
                    cbTeamA.SelectedIndex = -1;
                    cbTeamB.SelectedIndex = -1;
                }
                else if (Convert.ToInt32(cbMatchtype.SelectedValue) == 2)
                {
                    cbTeamA.Enabled = false;
                    cbTeamB.Enabled = false;
                    cbTeamA.SelectedValue = 1;
                    cbTeamB.SelectedValue = 2;
                }
            }
            catch { }
        }
    }
}
