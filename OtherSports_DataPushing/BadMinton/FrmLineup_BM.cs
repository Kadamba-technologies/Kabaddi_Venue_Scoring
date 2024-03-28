using OtherSports_DataPushing.Layer;
using System;
using System.Collections;
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
    public partial class FrmLineup_BM : Form
    {
        BusinessLy objMB = new BusinessLy();
        DataTable DT;
        Boolean pageload = false;
        public FrmLineup_BM()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                objMB = new BusinessLy();
                if (objMB.ExeQueryStrRetDTBL("Select * from BM_Lineup Where MatchID=" + mycommon.MatchId + " and TeamId=" + cbTeam.SelectedValue + "", 1).Rows.Count > 0)
                {
                    if (objMB.ExeQueryRetBooDL("Delete from BM_Lineup Where MatchID=" + mycommon.MatchId + " and TeamId=" + cbTeam.SelectedValue + "", 1))
                    {
                    }
                }
                Boolean success = false;
                foreach (DataGridViewRow dr in gvTeamDetails.Rows)
                {
                    success = objMB.ExeQueryRetBooDL("Insert Into BM_Lineup (MatchId,TeamId,PlayerId)values(" + mycommon.MatchId + "," + cbTeam.SelectedValue + "," + dr.Cells["PlayerID"].Value + ")", 1);
                }
                if (success)
                {
                    MessageBox.Show("Insert Sucessfully", "BadMinton Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error Please Check It", "BadMinton Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Error On DataBase", "BadMinton Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void bindData()
        {
            try
            {
                cbTeam.DataSource = objMB.ExeQueryStrRetDTBL("Select Distinct TeamA ID, Dbo.fn_GetTeamName(TeamA)Name from BM_Matches Where MatchId=" + mycommon.MatchId + " Union All Select Distinct TeamB ID, Dbo.fn_GetTeamName(TeamB)Name from BM_Matches Where MatchId=" + mycommon.MatchId + " ", 1);
                cbTeam.DisplayMember = "Name";
                cbTeam.ValueMember = "ID";
                cbTeam.SelectedIndex = -1;
            }
            catch { }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        void Clear()
        {
            cbTeam.SelectedIndex = -1;
        }

        private void FrmLineup_BM_Load(object sender, EventArgs e)
        {
            bindData();
            cbTeam.SelectedValue = Convert.ToInt32(mycommon.TeamID1);
            pageload = true;
            cbTeam_SelectedIndexChanged(sender, e);
        }

        private void TxtPlayerFilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                objMB = new BusinessLy();
                DT = new DataTable();
                if (TxtPlayerFilter.Text != "")
                    DT = objMB.ExeQueryStrRetDTBL("Select id,(firstname+' '+lastname) as name  from Player_Master Where (firstname+' '+lastname) like '%" + TxtPlayerFilter.Text + "%'Order by id desc", 1);
                else
                    DT = objMB.ExeQueryStrRetDTBL("Select id,(firstname+' '+lastname) as name  from Player_Master Order by id desc", 1);

                if (DT.Rows.Count > 0)
                {
                }
                else
                {
                    MessageBox.Show("Player Not Found");
                    return;
                }

                lstPlayersList.DataSource = DT;
                lstPlayersList.DisplayMember = "name";
                lstPlayersList.ValueMember = "ID";
                lstPlayersList.SelectedIndex = -1;
                lstPlayersList.Visible = true;
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
            if (cbTeam.SelectedIndex == -1)
            { MessageBox.Show("Select Team", "BadMinton Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (lstPlayersList.Text.Trim() != "")
            {
                string str = lstPlayersList.SelectedValue.ToString();
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
                        row2.Add(lstPlayersList.SelectedValue);
                        row2.Add(lstPlayersList.Text);
                        gvTeamDetails.Rows.Add(row2[0], row2[1].ToString());
                    }
                    catch
                    { }
                }
                else
                {
                    MessageBox.Show("Player Already Contain the list", "BadMinton Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                TxtTotal.Text = gvTeamDetails.Rows.Count.ToString();
                gvTeamDetails.Sort(this.gvTeamDetails.Columns["PlayerName"], ListSortDirection.Ascending);
            }
            else
            {
                if (lstPlayersList.DataSource != null)
                {
                    MessageBox.Show("Please select the valid player name");
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
                    MessageBox.Show("Select Player !");
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
            if (cbTeam.SelectedIndex == -1)
            { MessageBox.Show("Select Team", "BadMinton Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            try
            {
                gvTeamDetails.Rows.Clear();
            }
            catch
            { }
            DataTable dd = (DataTable)lstPlayersList.DataSource;
            foreach (DataRow row1 in dd.Rows)
            {
                string ID = row1[0].ToString();
                string PlayerFullName = row1[1].ToString();

                ArrayList row2 = new ArrayList();
                row2.Add(ID);
                row2.Add(PlayerFullName);
                gvTeamDetails.Rows.Add(row2[0], row2[1].ToString());
                TxtTotal.Text = gvTeamDetails.Rows.Count.ToString();
            }
        }

        private void cbTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageload) { return; }

            try
            {
                lstPlayersList.DataSource = objMB.ExeQueryStrRetDTBL("Select PlayerID ID,dbo.fn_GetPlayerFullName(PlayerID)Name from [dbo].[CompetitionSquad] Where CompId=" + mycommon.CompId + " AND TeamID=" + cbTeam.SelectedValue, 1);
                lstPlayersList.DisplayMember = "Name";
                lstPlayersList.ValueMember = "ID";
                lstPlayersList.SelectedIndex = -1;
            }
            catch { }

            DT = new DataTable();
            DT = objMB.ExeQueryStrRetDTBL("select Matchid,TeamId,PlayerId, dbo.fn_GetPlayerFullName(PlayerId) PlayerName from BM_Lineup where MatchId=" + mycommon.MatchId + " And TeamId=" + cbTeam.SelectedValue + "", 1);
            if (DT.Rows.Count > 0)
            {
                try
                {
                    try
                    {
                        gvTeamDetails.Rows.Clear();
                    }
                    catch
                    {
                        gvTeamDetails.Rows.Clear();
                    }

                    gvTeamDetails.AutoGenerateColumns = false;
                    int i = 0, n = DT.Rows.Count;
                    gvTeamDetails.Rows.Add(n);

                    while (n != 0)
                    {
                        gvTeamDetails.Rows[i].Cells[0].Value = DT.Rows[i]["PlayerID"].ToString();
                        gvTeamDetails.Rows[i].Cells[1].Value = DT.Rows[i]["PlayerName"].ToString();
                        n--;
                        i++;
                    }
                    TxtTotal.Text = gvTeamDetails.Rows.Count.ToString();
                }
                catch { }
                //gvTeamDetails.AutoGenerateColumns = false;
                //gvTeamDetails.DataSource = DT;
            }
            else
            {
                DT = objMB.ExeQueryStrRetDTBL("select Matchid,TeamId,PlayerId, dbo.fn_GetPlayerFullName(PlayerId) PlayerName from BM_Lineup where MatchId=(select Max(MatchId) from Lineups where TeamId=" + cbTeam.SelectedValue + ") And TeamId=" + cbTeam.SelectedValue + "", 1);
                if (DT.Rows.Count > 0)
                {

                    gvTeamDetails.AutoGenerateColumns = false;
                    int i = 0, n = DT.Rows.Count;
                    gvTeamDetails.Rows.Add(n);

                    while (n != 0)
                    {
                        gvTeamDetails.Rows[i].Cells[0].Value = DT.Rows[i]["PlayerID"].ToString();
                        gvTeamDetails.Rows[i].Cells[1].Value = DT.Rows[i]["PlayerName"].ToString();
                        n--;
                        i++;
                    }

                  //  gvTeamDetails.DataSource = DT;
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
                    gvTeamDetails.DataSource = null;
                }
            }
        }

        private void lstPlayersList_DoubleClick(object sender, EventArgs e)
        {
            MoveList();
        }

        private void gvTeamDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

    }
}
