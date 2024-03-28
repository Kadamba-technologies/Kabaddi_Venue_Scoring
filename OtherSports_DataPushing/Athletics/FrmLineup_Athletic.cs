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
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;
using OtherSports_DataPushing.Athletics;

namespace OtherSports_DataPushing
{
    public partial class FrmLineup_Athletic : Form
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

        public FrmLineup_Athletic()
        {
            InitializeComponent();
        }

        private void btnassigntoclubplayerlist_Click(object sender, EventArgs e)
        {
            moveFromList();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            gvTeamDetails.Refresh();
            try
            {
                if (objMB.ExeQueryStrRetDTBL("Select * from AthleticLineups where matchid=" + Temp_matchid + "", 1).Rows.Count > 0)
                {
                    objMB.ExeQueryRetBooDL("Delete from AthleticLineups where matchid=" + Temp_matchid + "", 1);                   
                }
                foreach (DataGridViewRow dr in gvTeamDetails.Rows)
                {
                    Query = "Insert Into AthleticLineups (MatchID,ClubID,PlayerId,JercyNo,LaneNo)values(" + Temp_matchid + "," + dr.Cells["TeamId"].Value + "," + dr.Cells["PlayerId"].Value + "," + dr.Cells["JercyNo"].Value + ",'" + dr.Cells["LaneNo"].Value + "')";
                    objMB.ExeQueryRetBooDL(Query, 1);
                }
                if (true)
                {
                    MessageBox.Show("Update Successfully", "Athletics Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Error On DataBase", "Athletics Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FrmLineup_Load(object sender, EventArgs e)
        {
           
            try
            {
                objMB = new BusinessLy();

                cbTeams.DataSource = objMB.ExeQueryStrRetDTBL("Select distinct TeamID,TeamName  Name from Team_Master Order by Name", 1);

                //cbTeams.DataSource = objMB.ExeQueryStrRetDTBL("Select distinct TeamID, dbo.fn_GetTeamName(TeamID)Name from CompetitionTeam Where CompID=" + CommonCls.CompId + " Order by Name", 1);

                cbTeams.DisplayMember = "Name";
                cbTeams.ValueMember = "TeamID";
                cbTeams.SelectedIndex = -1;
                loadGird();
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

        void loadGird()
        {
            try
            {
                gvTeamDetails.DataSource = null;
                try
                {
                    gvTeamDetails.Rows.Clear();
                }
                catch
                {
                    gvTeamDetails.Rows.Clear();
                }

                Dt = new DataTable();
                Dt = objMB.ExeQueryStrRetDTBL("select Pl.ID PlayerID, Pl.firstname +' '+ Pl.lastname PlayerName,JercyNo,PickNo,dbo.fn_GetTeamName(TeamID)TeamName,TeamID,LaneNo from AthleticLineups L inner join Player_Master Pl on L.playerid=Pl.id where L.Matchid ='" + Temp_matchid + "' order by Cast(JercyNo as int) asc", 1);

                if (Dt.Rows.Count > 0)
                {
                    gvTeamDetails.AutoGenerateColumns = false;

                    int i = 0, n = Dt.Rows.Count;
                    gvTeamDetails.Rows.Add(n);

                    while (n != 0)
                    {
                        gvTeamDetails.Rows[i].Cells[0].Value = Dt.Rows[i]["PlayerID"].ToString();
                        gvTeamDetails.Rows[i].Cells[1].Value = Dt.Rows[i]["PlayerName"].ToString();
                        gvTeamDetails.Rows[i].Cells[2].Value = Dt.Rows[i]["JercyNo"];
                        gvTeamDetails.Rows[i].Cells[3].Value = Dt.Rows[i]["PickNo"];
                        gvTeamDetails.Rows[i].Cells[4].Value = Dt.Rows[i]["TeamID"];
                        gvTeamDetails.Rows[i].Cells[5].Value = Dt.Rows[i]["TeamName"];
                        gvTeamDetails.Rows[i].Cells[6].Value = Dt.Rows[i]["LaneNo"];
                        n--;
                        i++;
                    }
                    TxtTotal.Text = gvTeamDetails.Rows.Count.ToString();
                }
                gvTeamDetails.Sort(this.gvTeamDetails.Columns["PickNo"], ListSortDirection.Ascending);
            }
            catch
            {

            }
            finally
            {

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
                Dt = new DataTable();
                Dt = objMB.ExeQueryStrRetDTBL("select Id ID,Isnull(Cast(PickNo As varchar),'0')+' - '+dbo.fn_GetPlayerFullName(ID) Name,0 JercyNo from Player_Master Where TeamID=" + (cbTeams.SelectedValue == null ? 0 : cbTeams.SelectedValue) + " order by Name asc", 1); 
                if(Dt.Rows.Count== 0)
                    Dt = objMB.ExeQueryStrRetDTBL("select Id ID,Isnull(Cast(PickNo As varchar),'0')+' - '+dbo.fn_GetPlayerFullName(ID) Name,0 JercyNo from Player_Master order by Name asc", 1);

                lstPlayersList.DataSource = Dt;
                lstPlayersList.DisplayMember = "Name";
                lstPlayersList.ValueMember = "ID";
                PageLoad = true;
            }
            catch
            {
                MessageBox.Show("Error on Player name fill", "Athletics", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TxtPlayerFilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if (cbTeams.SelectedIndex == -1) { MessageBox.Show("Error on Player name fill", "Athletics", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                objMB = new BusinessLy();

                Dt = new DataTable();
                if (TxtPlayerFilter.Text != "")
                {
                    Dt = objMB.ExeQueryStrRetDTBL("select Id ID,Isnull(Cast(PickNo As varchar),'0')+' - '+dbo.fn_GetPlayerFullName(ID) Name,0 JercyNo from Player_Master Where TeamID=" + (cbTeams.SelectedValue == null ? 0 : cbTeams.SelectedValue) + "And (firstname+' '+lastname) like '%" + TxtPlayerFilter.Text + "%'Order by Name asc", 1);
                    if (Dt.Rows.Count == 0)
                        Dt = objMB.ExeQueryStrRetDTBL("select Id ID,Isnull(Cast(PickNo As varchar),'0')+' - '+dbo.fn_GetPlayerFullName(ID) Name,0 JercyNo from Player_Master where Isnull(Cast(PickNo As varchar),'0')+' - '+FirstName+' '+MiddleName+' '+LastName like '%" + TxtPlayerFilter.Text + "%'Order by Name asc", 1);
                }
                else
                {
                    Dt = objMB.ExeQueryStrRetDTBL("select Id ID,Isnull(Cast(PickNo As varchar),'0')+' - '+dbo.fn_GetPlayerFullName(ID) Name,0 JercyNo from Player_Master Where TeamID=" + (cbTeams.SelectedValue == null ? 0 : cbTeams.SelectedValue) + " order by Name asc", 1);
                    if (Dt.Rows.Count == 0)
                        Dt = objMB.ExeQueryStrRetDTBL("select Id ID,Isnull(Cast(PickNo As varchar),'0')+' - '+dbo.fn_GetPlayerFullName(ID) Name,0 JercyNo from Player_Master order by Name asc", 1);                
                }

                if (Dt.Rows.Count > 0)
                {
                    PageLoad = false;
                    lstPlayersList.DataSource = Dt;
                    lstPlayersList.DisplayMember = "name";
                    lstPlayersList.ValueMember = "ID";
                    lstPlayersList.SelectedIndex = -1;
                    lstPlayersList.Visible = true;
                    PageLoad = true;
                }
                else
                {
                    MessageBox.Show("Player Not Found", "Athletics Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }

        private void lstPlayersList_DoubleClick(object sender, EventArgs e)
        {
            if(!PageLoad)
        { return; }
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
                    if (row.Cells[0].Value.ToString()==str)
                    {                        
                        IsAlready = true;
                    }
                }
                if (!IsAlready)
                {
                    try
                    {
                        string[] PlayerFullName = lstPlayersList.Text.Split('-');
                       // int PlayerJercyNo = Convert.ToInt32(PlayerFullName[0].Trim());
                        string PlayerN = PlayerFullName[1].Trim();
                        ArrayList row2 = new ArrayList();
                        row2.Add(lstPlayersList.SelectedValue);
                        row2.Add(PlayerN);
                        row2.Add(0);
                        row2.Add(Convert.ToInt32(PlayerFullName[0].Trim()));
                        row2.Add(getTeamID(lstPlayersList.SelectedValue.ToString()));
                        row2.Add(getTeamName(lstPlayersList.SelectedValue.ToString()));
                        gvTeamDetails.Rows.Add(row2[0], row2[1].ToString(), Convert.ToInt32(row2[2]), Convert.ToInt32(row2[3]), Convert.ToInt32(row2[4]), row2[5],"");
                    }
                    catch
                    { }
                }
                else
                {
                    MessageBox.Show("Player Already Contain the list", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                TxtTotal.Text = gvTeamDetails.Rows.Count.ToString();
                gvTeamDetails.Sort(this.gvTeamDetails.Columns["PickNo"], ListSortDirection.Ascending);
            }
            else
            {
                if (lstPlayersList.DataSource != null)
                {
                    MessageBox.Show("Please select the valid player name");
                }
            }
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

        public string getTeamName(string PlayerID)
        {
            try
            {
                objMB = new BusinessLy();
                string TeamName = objMB.ExeQueryStrRetStrBL("Select T.TeamName from Player_Master P Join Team_Master T ON P.TeamID=T.TeamId Where ID=" + PlayerID + "", 1);
                return TeamName;
            }
            catch
            {
                return "";
            }
        }


        public int getTeamID(string PlayerID)
        {
            try
            {
                objMB = new BusinessLy();
                int TeamID = objMB.ExeQueryStrIntBL("Select T.TeamID from Player_Master P Join Team_Master T ON P.TeamID=T.TeamId Where ID=" + PlayerID + "", 1);
                return TeamID;
            }
            catch
            {
                return 0;
            }
        }


        public int getPickNo(string PlayerID)
        {
            try
            {
                objMB = new BusinessLy();
                int PickNo = objMB.ExeQueryStrIntBL("Select PickNo from Player_Master Where ID=" + PlayerID + "", 1);
                return PickNo;
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
        int[] GkPlayerId= new int[2];

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
            DataTable dd=(DataTable)lstPlayersList.DataSource;
            foreach (DataRow row1 in dd.Rows)
            {
                string ID = row1[0].ToString();

                string[] PlayerFullName = row1[1].ToString().Split('-');
                int PlayerJercyNo = Convert.ToInt32(PlayerFullName[0].Trim());
                string PlayerN = PlayerFullName[1].Trim();
                    ArrayList row2 = new ArrayList();
                    row2.Add(ID.ToString());
                    row2.Add(PlayerN);
                    row2.Add(0);
                    row2.Add(Convert.ToInt32(PlayerFullName[0].Trim()));
                    row2.Add(getTeamID(ID));
                    row2.Add(getTeamName(ID));
               //     row2.Add(getPickNo(ID));

                    gvTeamDetails.Rows.Add(row2[0], row2[1].ToString(), Convert.ToInt32(row2[2]), Convert.ToInt32(row2[3]), Convert.ToInt32(row2[4]), row2[5],"");
              
                TxtTotal.Text = gvTeamDetails.Rows.Count.ToString();
            }
            gvTeamDetails.Sort(this.gvTeamDetails.Columns["PickNo"], ListSortDirection.Ascending);
        }

        private void gvTeamDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            FrmAthletics_Attempts frm = new FrmAthletics_Attempts();
            frm.Score_Matchid = CommonCls.MatchId;
            frm.Show();
        }
    }
}
