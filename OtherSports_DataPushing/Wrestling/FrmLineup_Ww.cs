using OtherSports_DataPushing.Layer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtherSports_DataPushing.Wrestling
{
    public partial class FrmLineup_Ww : Form
    {
        BusinessLy objMB = new BusinessLy();
        int ID = 0;
        DataTable Dt;
        Boolean PageLoad = false;
        int Temp_matchid = mycommon.MatchId;
        int Temp_clubidA = mycommon.TeamID1;
        int Temp_clubidB = mycommon.TeamID2;
        SqlCommand SqlCmd;
        string Query = "";

        public FrmLineup_Ww()
        {
            InitializeComponent();
        }

        private void btnassigntoclubplayerlist_Click(object sender, EventArgs e)
        {
            moveFromList();
        }

        private void moveFromList()
        {
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
                    //string[] row1 = new string[] { lstPlayersList.SelectedValue.ToString(), lstPlayersList.Text.ToString(), getJercyNo(Convert.ToInt32(lstPlayersList.SelectedValue)).ToString() };
                    //gvTeamDetails.Rows.Add(row1);
                    try
                    {
                        string[] PlayerFullName = lstPlayersList.Text.Split('-');
                        int PlayerJercyNo = Convert.ToInt32(PlayerFullName[0].Trim());
                        string PlayerN = PlayerFullName[1].Trim();
                        ArrayList row2 = new ArrayList();
                        row2.Add(lstPlayersList.SelectedValue);
                        //row2.Add(lstPlayersList.Text.ToString());
                        //row2.Add(getJercyNo(Convert.ToInt32(lstPlayersList.SelectedValue)));
                        row2.Add(PlayerN);
                        row2.Add(PlayerJercyNo);
                        gvTeamDetails.Rows.Add(row2[0], 0, row2[1].ToString(), Convert.ToInt32(row2[2]));
                    }
                    catch
                    { }
                }
                else
                {
                    MessageBox.Show("Player Already Contain the list", mycommon.ApplicationName + " Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                TxtTotal.Text = gvTeamDetails.Rows.Count.ToString();
                gvTeamDetails.Sort(this.gvTeamDetails.Columns["JercyNo"], ListSortDirection.Ascending);
            }
            else
            {
                if (lstPlayersList.DataSource != null)
                {
                    MessageBox.Show("Please select the valid player name");
                }
            }
        }

        public void GetPlayerBind()
        {
            try
            {
                objMB = new BusinessLy();
                DataTable Dt3 = new DataTable();
                try
                {
                    lstPlayersList.DataSource = null;
                    PageLoad = false;
                }
                catch
                {
                }
                lstPlayersList.DataSource = objMB.ExeQueryStrRetDTBL("select PlayerId ID,Cast(JercyNo As varchar)+' - '+dbo.fn_GetPlayerName(playerID) Name,JercyNo from CompetitionSquad Where TeamID=" + cbTeams.SelectedValue + " and CompId=" + mycommon.CompId + " order by JercyNo asc", 1);
                lstPlayersList.DisplayMember = "Name";
                lstPlayersList.ValueMember = "ID";
                PageLoad = true;
            }
            catch
            {
                MessageBox.Show("Error on Player name fill", mycommon.ApplicationName + " Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TxtPlayerFilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                objMB = new BusinessLy();
                Dt = new DataTable();
                if (TxtPlayerFilter.Text != "")
                    Dt = objMB.ExeQueryStrRetDTBL("Select id,(firstname+' '+lastname) as name  from Player_Master Where (firstname+' '+lastname) like '%" + TxtPlayerFilter.Text + "%'Order by id desc", 1);
                else
                    Dt = objMB.ExeQueryStrRetDTBL("Select id,(firstname+' '+lastname) as name  from Player_Master Order by id desc", 1);

                if (Dt.Rows.Count > 0)
                {
                    lstPlayersList.DataSource = Dt;
                    lstPlayersList.DisplayMember = "name";
                    lstPlayersList.ValueMember = "ID";
                    lstPlayersList.SelectedIndex = -1;
                    lstPlayersList.Visible = true;
                }
                else
                {
                    MessageBox.Show("Player Not Found", mycommon.ApplicationName + " Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {

            }
        }

        private void cbTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PageLoad == false) return;
            if (cbTeams.Text == "") return;

            GetPlayerBind();
            gvTeamDetails.DataSource = null;
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

                Dt = new DataTable();
                Dt = objMB.ExeQueryStrRetDTBL("select Pl.ID PlayerID, Pl.firstname +' '+ Pl.lastname PlayerName,JercyNo,IsLive from WW_Lineup L inner join Player_Master Pl on L.playerid=Pl.id where L.Matchid ='" + Temp_matchid + "' and L.ClubID='" + cbTeams.SelectedValue + "' order by Cast(JercyNo as int) asc", 1);

                if (Dt.Rows.Count > 0)
                {
                    gvTeamDetails.AutoGenerateColumns = false;
                    //for (int i = 0; i < Dt.Rows.Count; i++)
                    //{
                    //    ArrayList row1 = new ArrayList();
                    //    row1.Add(Dt.Rows[i]["PlayerID"].ToString());
                    //    row1.Add(Convert.ToInt32(Dt.Rows[i]["Islive"]));
                    //    row1.Add(Dt.Rows[i]["PlayerName"].ToString());
                    //    row1.Add(Dt.Rows[i]["JercyNo"]);
                    //    row1.Add(Dt.Rows[i]["Position"].ToString());
                    //    row1.Add(Dt.Rows[i]["Role"].ToString());
                    //    gvTeamDetails.Rows.Add(row1[0], row1[1], row1[2].ToString(), Convert.ToInt32(row1[3]), row1[4], row1[5]);
                    //}
                    int i = 0, n = Dt.Rows.Count;
                    gvTeamDetails.Rows.Add(n);

                    while (n != 0)
                    {
                        gvTeamDetails.Rows[i].Cells[0].Value = Dt.Rows[i]["PlayerID"].ToString();
                        gvTeamDetails.Rows[i].Cells[1].Value = Dt.Rows[i]["Islive"];
                        gvTeamDetails.Rows[i].Cells[2].Value = Dt.Rows[i]["PlayerName"].ToString();
                        gvTeamDetails.Rows[i].Cells[3].Value = Dt.Rows[i]["JercyNo"];
                        n--;
                        i++;
                    }
                    TxtTotal.Text = gvTeamDetails.Rows.Count.ToString();
                }
                else
                {
                    Dt = new DataTable();
                    //Dt = objMB.ExeQueryStrRetDTBL("select Distinct Pl.ID PlayerID, Pl.firstname +' '+ Pl.lastname PlayerName,JercyNo,IsSubstitute,IsCaptain,IsGoalKeeper from Lineup L inner join player Pl on L.playerid=Pl.id where L.TeamId='" + cbTeams.SelectedValue + "' order by PlayerName asc", 1);
                    Dt = objMB.ExeQueryStrRetDTBL("select Distinct Pl.ID PlayerID, Pl.firstname +' '+ Pl.lastname PlayerName,JercyNo,Islive from WW_Lineup L inner join Player_Master Pl on L.playerid=Pl.id where L.Clubid='" + cbTeams.SelectedValue + "' and L.MatchID=(SElect Max(matchid) from Lineups Lu Where Lu.Clubid='" + cbTeams.SelectedValue + "') order by PlayerName asc", 1);
                    if (Dt.Rows.Count > 0)
                    {
                        gvTeamDetails.AutoGenerateColumns = false;
                        for (int i = 0; i < Dt.Rows.Count; i++)
                        {
                            //string[] row1 = new string[] { Dt.Rows[i]["PlayerID"].ToString(), Dt.Rows[i]["PlayerName"].ToString(), Dt.Rows[i]["JercyNo"].ToString(), Dt.Rows[i]["IsSubstitute"].ToString(), Dt.Rows[i]["IsCaptain"].ToString(), Dt.Rows[i]["IsGoalKeeper"].ToString() };
                            ArrayList row1 = new ArrayList();
                            row1.Add(Dt.Rows[i]["PlayerID"].ToString());
                            row1.Add(Convert.ToInt32(Dt.Rows[i]["Islive"]));
                            row1.Add(Dt.Rows[i]["PlayerName"].ToString());
                            row1.Add(Dt.Rows[i]["JercyNo"]);
                            //row1.Add(Dt.Rows[i]["Position"]);
                            //row1.Add(Dt.Rows[i]["Role"]);
                            //gvTeamDetails.Rows.Add(row1);
                            gvTeamDetails.Rows.Add(row1[0], row1[1], row1[2].ToString(), Convert.ToInt32(row1[3]));
                        }
                        TxtTotal.Text = gvTeamDetails.Rows.Count.ToString();
                    }
                    else
                    {
                        gvTeamDetails.Rows.Clear();
                    }
                }
                gvTeamDetails.Sort(this.gvTeamDetails.Columns["JercyNo"], ListSortDirection.Ascending);
            }
            catch
            {

            }
            finally
            {

            }
        }

        private void lstPlayersList_DoubleClick(object sender, EventArgs e)
        {
            if (!PageLoad)
            { return; }
            moveFromList();
        }

        public int getJercyNo(int PlayerID)
        {
            try
            {
                objMB = new BusinessLy();
                int JercyNo = objMB.ExeQueryStrIntBL("Select JercyNo from CompetitionSquad Where CompID=" + mycommon.CompId + " and PlayerID=" + PlayerID + "", 1);
                return JercyNo;
            }
            catch
            {
                return 0;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            removeFromList();
        }

        private void removeFromList()
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

        private void gvTeamDetails_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        int[] GkPlayerId = new int[2];

        private void gvTeamDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnInsertall_Click(object sender, EventArgs e)
        {
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
                //string Name = row1[1].ToString();

                string[] PlayerFullName = row1[1].ToString().Split('-');
                int PlayerJercyNo = Convert.ToInt32(PlayerFullName[0].Trim());
                string PlayerN = PlayerFullName[1].Trim();
                //string[] row2 = new string[] { ID, Name, getJercyNo(Convert.ToInt32(ID)).ToString() };
                ArrayList row2 = new ArrayList();
                row2.Add(ID.ToString());
                //row2.Add(Name.ToString());
                //row2.Add(getJercyNo(Convert.ToInt32(ID)).ToString());
                row2.Add(PlayerN);
                row2.Add(PlayerJercyNo);
                gvTeamDetails.Rows.Add(row2[0], 0, row2[1].ToString(), Convert.ToInt32(row2[2]));

                TxtTotal.Text = gvTeamDetails.Rows.Count.ToString();
            }
            gvTeamDetails.Sort(this.gvTeamDetails.Columns["JercyNo"], ListSortDirection.Ascending);
            //gvTeamDetails.Refresh();
        }

        private void fillCombo()
        {
            //try
            //{
            //    objMB = new BusinessLy();
            //    Dt = new DataTable();
            //    Dt = objMB.ExeQueryStrRetDTBL("select Id,Name From Role", 1);
            //    Dictionary<string, string> lstRole = new Dictionary<string, string>();
            //    foreach (DataRow dr in Dt.Rows)
            //    {
            //        lstRole.Add(dr["Id"].ToString(), dr["Name"].ToString());
            //    }
            //    Role.DataSource = new BindingSource(lstRole, null);
            //    Role.DisplayMember = "Value";
            //    Role.ValueMember = "Key";


            //    Dt = new DataTable();
            //    Dt = objMB.ExeQueryStrRetDTBL("select Id,Name From Position", 1);
            //    Dictionary<string, string> lstPosition = new Dictionary<string, string>();
            //    foreach (DataRow dr in Dt.Rows)
            //    {
            //        lstPosition.Add(dr["Id"].ToString(), dr["Name"].ToString());
            //    }
            //    Position.DataSource = new BindingSource(lstPosition, null);
            //    Position.DisplayMember = "Value";
            //    Position.ValueMember = "Key";

            //Dictionary<string, string> lstForB = new Dictionary<string, string>();
            //lstForB.Add("1", "Forehand");
            //lstForB.Add("2", "Backhand");
            //ForB.DataSource = new BindingSource(lstForB, null);
            //ForB.DisplayMember = "Value";
            //ForB.ValueMember = "Key";
            //}

            //catch { }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            gvTeamDetails.Refresh();
            int sub = 0, Live = 0;
            try
            {
                if (objMB.ExeQueryStrRetDTBL("Select * from WW_Lineup where matchid=" + Temp_matchid + " and ClubID=" + cbTeams.SelectedValue + "", 1).Rows.Count > 0)
                {
                    objMB.ExeQueryRetBooDL("Delete from WW_Lineup where matchid=" + Temp_matchid + " and ClubID=" + cbTeams.SelectedValue + "", 1);
                }
                foreach (DataGridViewRow dr in gvTeamDetails.Rows)
                {
                    Live = 0;
                    sub = 0;

                    if (dr.Cells["IsLive"].Value != null)
                    {

                        if (dr.Cells["IsLive"].Value.ToString() == "True" || dr.Cells["IsLive"].Value.ToString() == "1")
                        {
                            Live = 1;
                            sub = 0;
                        }
                        else
                        {
                            Live = 0;
                            sub = 1;
                        }
                    }
                    else
                    {
                        sub = 0;
                    }

                    Query = "Insert Into WW_Lineup (MatchID,ClubID,PlayerId,IsSub,JercyNo,islive)values(" + Temp_matchid + "," + cbTeams.SelectedValue + "," + dr.Cells["PlayerId"].Value + "," + sub + "," + dr.Cells["JercyNo"].Value + ",'" + Live + "')";
                    objMB.ExeQueryRetBooDL(Query, 1);
                }
                if (true)
                {
                    MessageBox.Show("Update Successfully", mycommon.ApplicationName + " Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Error On DataBase", mycommon.ApplicationName + " Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gvTeamDetails_CellErrorTextChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gvTeamDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void FrmLineup_Ww_Load(object sender, EventArgs e)
        {
            try
            {
                //fillCombo();
                objMB = new BusinessLy();
                Dt = new DataTable();
                Dt = objMB.ExeQueryStrRetDTBL("select TeamID,TeamName from Team_Master where TeamID in(select TeamA from WW_Matches where Matchid=" + Temp_matchid + " Union select TeamB from WW_Matches where Matchid=" + Temp_matchid + ")", 1);
                string tempstr = "select TeamID,TeamName from Team_Master where TeamID in(select TeamA from WW_Matches where Matchid=" + Temp_matchid + " Union select TeamB from WW_Matches where Matchid=" + Temp_matchid + ")";
                cbTeams.DataSource = Dt;
                cbTeams.DisplayMember = "Teamname";
                cbTeams.ValueMember = "TeamID";

                cbTeams.SelectedValue = Temp_clubidA;

                cbTeams_SelectedIndexChanged(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
            }
            GetPlayerBind();
            PageLoad = true;
        }
    }
}
