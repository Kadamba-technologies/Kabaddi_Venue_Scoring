using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OtherSports_DataPushing.Layer;
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;

namespace OtherSports_DataPushing
{
    public partial class FrmCompetitionTeam : Form
    {
        BusinessLy objMB = new BusinessLy();
        DataTable DT;
        Boolean pageload = false;
        SqlCommand SqlCmd;
        string Query = "";

        public FrmCompetitionTeam()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbCompetition.Text == string.Empty || cbCompetition.SelectedIndex == -1)
                {
                    MessageBox.Show("Select Competition", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (gvTeamDetails.Rows.Count <= 0)
                {
                    MessageBox.Show("Teams are Empty", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
               
                objMB = new BusinessLy();
                if (objMB.ExeQueryStrRetDTBL("Select * from CompetitionTeam Where CompId=" + cbCompetition.SelectedValue + "", 1).Rows.Count > 0)
                {
                    if (objMB.ExeQueryRetBooDL("Delete from CompetitionTeam Where CompId=" + cbCompetition.SelectedValue + "", 1))
                    {
                    }
                }
                Boolean success = false;
                string Coachname = "";
                foreach (DataGridViewRow dr in gvTeamDetails.Rows)
                {
                    if (string.IsNullOrEmpty(Convert.ToString(dr.Cells["Coach"].Value)))
                        Coachname = "Null";
                    else
                        Coachname = dr.Cells["Coach"].Value.ToString();
                    success = objMB.ExeQueryRetBooDL("Insert Into CompetitionTeam (CompId,TeamID,CoachID)values(" + cbCompetition.SelectedValue + "," + dr.Cells["TeamID"].Value + "," + Coachname + ")", 1);                    
                }
                if(success)
                {     
                    MessageBox.Show("Insert Sucessfully", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error Please Check It", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Error On DataBase", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
              
        void bindData()
        {
            try
            {
                cbCompetition.DataSource = objMB.ExeQueryStrRetDTBL("Select compID,Name from competition order by Name", 1);// Where SportID=" + mycommon.SportID + "
                cbCompetition.DisplayMember = "Name";
                cbCompetition.ValueMember = "compID";
                cbCompetition.SelectedIndex = -1;

                lstTeamList.DataSource = objMB.ExeQueryStrRetDTBL("Select TeamID,TeamName from Team_Master order by TeamName", 1);
                lstTeamList.DisplayMember = "TeamName";
                lstTeamList.ValueMember = "TeamID";
                lstTeamList.SelectedIndex = -1;

                DT = new DataTable();
                DT = objMB.ExeQueryStrRetDTBL("Select ID,Firstname +' '+Lastname Name From CoachMaster order by Name", 1);
                Dictionary<string, string> lstcoach = new Dictionary<string, string>();
                foreach (DataRow dr in DT.Rows)
                {
                    lstcoach.Add(dr["Id"].ToString(), dr["Name"].ToString());
                }
                Coach.DataSource = new BindingSource(lstcoach, null);
                Coach.DisplayMember = "Value";
                Coach.ValueMember = "Key";

            }
            catch { }
        }

        private void FrmCompetitionSquad_Load(object sender, EventArgs e)
        {
            bindData();
            pageload = true;
        }

        private void TxtPlayerFilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                objMB = new BusinessLy();
                DT = new DataTable();
                if (TxtTeamFilter.Text != "")
                    DT = objMB.ExeQueryStrRetDTBL("Select Teamid,Teamname from Team_Master Where Teamname like '%" + TxtTeamFilter.Text + "%' order by Teamname", 1);
                else
                    DT = objMB.ExeQueryStrRetDTBL("Select Teamid, as Teamname from Team_Master Order by Teamname", 1);

                if (DT.Rows.Count > 0)
                {
                }
                else
                {
                   MessageBox.Show("Team Not Found");
                   return;
                }

                lstTeamList.DataSource = DT;
                lstTeamList.DisplayMember = "Teamname";
                lstTeamList.ValueMember = "TeamID";
                lstTeamList.SelectedIndex = -1;
                lstTeamList.Visible = true;
            }
            catch
            {

            }
        }

        private void btnassigntoclubplayerlist_Click(object sender, EventArgs e)
        {
            MoveList();   
        }

        void MoveList()
        {
            if(cbCompetition.SelectedIndex==-1)
            { MessageBox.Show("Select Competition", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (lstTeamList.Text.Trim() != "")
            {
                string str = lstTeamList.SelectedValue.ToString();
                Boolean IsAlready = false;

                foreach (DataGridViewRow row in gvTeamDetails.Rows)
                {
                    if (row.Cells[0].Value.ToString() == str)
                    {
                        IsAlready = true;
                    }
                }
                if (!IsAlready)
                {
                    try
                    {
                        ArrayList row2 = new ArrayList();
                        row2.Add(lstTeamList.SelectedValue);
                        row2.Add(lstTeamList.Text);

                        gvTeamDetails.Rows.Add(row2[0], row2[1].ToString());
                    }
                    catch
                    { }
                }
                else
                {
                    MessageBox.Show("Team Already Contain the list", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                TxtTotal.Text = gvTeamDetails.Rows.Count.ToString();
                gvTeamDetails.Sort(this.gvTeamDetails.Columns["TeamName"], ListSortDirection.Ascending);
            }
            else
            {
                if (lstTeamList.DataSource != null)
                {
                    MessageBox.Show("Please select the valid Team name");
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvTeamDetails.SelectedRows.Count != 0)
                {
                    gvTeamDetails.Rows.RemoveAt(gvTeamDetails.CurrentCell.RowIndex);
                    TxtTotal.Text = gvTeamDetails.Rows.Count.ToString();
                }
                else
                    MessageBox.Show("Select Team !");
            }
            catch
            {

            }
        }

        private void btnRemoveall_Click(object sender, EventArgs e)
        {
            gvTeamDetails.Rows.Clear();
        }

        private void btnInsertall_Click(object sender, EventArgs e)
        {
            if (cbCompetition.SelectedIndex == -1)
            { MessageBox.Show("Select Competition", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            try
            {
                gvTeamDetails.Rows.Clear();
            }
            catch
            { }
            DataTable dd = (DataTable)lstTeamList.DataSource;
            foreach (DataRow row1 in dd.Rows)
            {
                string ID = row1[0].ToString();
                string TeamNam = row1[1].ToString();
               
                ArrayList row2 = new ArrayList();
                row2.Add(ID);
                row2.Add(TeamNam);
                gvTeamDetails.Rows.Add(row2[0], row2[1].ToString());
            }
            TxtTotal.Text = gvTeamDetails.Rows.Count.ToString();
            gvTeamDetails.Sort(this.gvTeamDetails.Columns["TeamName"], ListSortDirection.Ascending);
        }

        private void cbCompetition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageload) { return; }
            try
            {
                gvTeamDetails.Rows.Clear();
            }
            catch
            { 
            }
            DT = objMB.ExeQueryStrRetDTBL("select TeamID, dbo.fn_GetTeamName(TeamID) TeamName,coachID from CompetitionTeam where CompId=" + cbCompetition.SelectedValue + "", 1);
            if (DT.Rows.Count > 0)
            {
                for (int i = 0; i < DT.Rows.Count; i++)
                {
                    ArrayList row2 = new ArrayList();
                    row2.Add(DT.Rows[i]["TeamID"].ToString());
                    row2.Add(DT.Rows[i]["TeamName"].ToString());
                    row2.Add(DT.Rows[i]["coachID"].ToString());
                    gvTeamDetails.Rows.Add(row2[0], row2[1].ToString(), row2[2]);
                }
                TxtTotal.Text = DT.Rows.Count.ToString();
                gvTeamDetails.Sort(this.gvTeamDetails.Columns["TeamName"], ListSortDirection.Ascending);
                //gvTeamDetails.AutoGenerateColumns = false;
                //gvTeamDetails.DataSource = DT;
            }
            else
            {
                try
                {
                    gvTeamDetails.Rows.Clear();
                }
                catch
                {
                }
            }
        }

        private void lstTeamList_DoubleClick(object sender, EventArgs e)
        {
            MoveList();
        }

        private void gvTeamDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
