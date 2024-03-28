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
    public partial class FrmCompetitionSquad : Form
    {
        BusinessLy objMB = new BusinessLy();
        DataTable DT;
        Boolean pageload = false;
        public FrmCompetitionSquad()
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
                if (cbTeam.Text == string.Empty || cbTeam.SelectedIndex == -1)
                {
                    MessageBox.Show("Select TeamName", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                objMB = new BusinessLy();
                if (objMB.ExeQueryStrRetDTBL("Select * from CompetitionSquad Where CompId=" + cbCompetition.SelectedValue + " and TeamID=" + cbTeam.SelectedValue + "", 1).Rows.Count > 0)
                {
                    if (objMB.ExeQueryRetBooDL("Delete from CompetitionSquad Where CompId=" + cbCompetition.SelectedValue + " and TeamID=" + cbTeam.SelectedValue + "", 1))
                    {
                    }
                }
                Boolean success = false;
                foreach (DataGridViewRow dr in gvTeamDetails.Rows)
                {
                    string JercyNo = "0";

                    if (dr.Cells["JercyNo"].Value == null || dr.Cells["JercyNo"].Value == "")
                    {
                        JercyNo = "0";
                    }
                    else
                    {
                        JercyNo = dr.Cells["JercyNo"].Value.ToString();
                    }

                    var IsWithdraw = Convert.ToBoolean(dr.Cells["IsWithdraw"].Value) == true ? 1 : 0;
                    var isReserved = Convert.ToBoolean(dr.Cells["isReserved"].Value) == true ? 1 : 0;

                    int playerid = 0;
                    if (dr.Cells["DGV2NewPlayer"].Value == null)
                    {
                        playerid = Convert.ToInt16(dr.Cells["PlayerId"].Value);
                    }
                    else
                    {
                        playerid = Convert.ToInt16(dr.Cells["DGV2NewPlayer"].Value);
                    }

                    success = objMB.ExeQueryRetBooDL("Insert Into CompetitionSquad (CompId,TeamID,PlayerId,JercyNo,IsWithdraw,isReserved)values(" + cbCompetition.SelectedValue + "," + cbTeam.SelectedValue + "," + playerid + "," + JercyNo + "," + IsWithdraw + "," + isReserved + ")", 1);
                }
                if (success)
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
            cbCompetition.DataSource = objMB.ExeQueryStrRetDTBL("Select compID,Name from competition", 1);// Where SportID=" + mycommon.SportID + "
            cbCompetition.DisplayMember = "Name";
            cbCompetition.ValueMember = "compID";
            cbCompetition.SelectedIndex = -1;

            //cbTeam.DataSource = objMB.ExeQueryStrRetDTBL("Select ID,Name from Team", 1);
            //cbTeam.DisplayMember = "Name";
            //cbTeam.ValueMember = "ID";
            //cbTeam.SelectedIndex = -1;

            lstPlayersList.DataSource = objMB.ExeQueryStrRetDTBL("Select ID,dbo.fn_GetPlayerName(ID)+'_'+CAST(ID as NVARCHAR(MAX))+ case WHEN NickName is NULL then '' ELSE '_'+(NickName) END Name from Player_Master Order by Name", 1);
            lstPlayersList.DisplayMember = "Name";
            lstPlayersList.ValueMember = "ID";
            lstPlayersList.SelectedIndex = -1;
        }

        private void FrmCompetitionSquad_Load(object sender, EventArgs e)
        {
            try
            {
                bindData();
                pageload = true;
            }
            catch { }
        }

        private void TxtPlayerFilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                objMB = new BusinessLy();
                DT = new DataTable();
                if (TxtPlayerFilter.Text != "")
                    DT = objMB.ExeQueryStrRetDTBL("Select id,(firstname+' '+lastname)+'_'+CAST(ID as NVARCHAR(MAX))+ case WHEN NickName is NULL then '' ELSE '_'+(NickName) END as name  from Player_Master Where ((firstname+' '+lastname) like '%" + TxtPlayerFilter.Text + "%' OR CAST (ID AS VARCHAR)= '" + TxtPlayerFilter.Text + "') and gender=isnull((select gender from Competition where CompID=" + cbCompetition.SelectedValue + "),1)Order by Name desc", 1);
                else
                    DT = objMB.ExeQueryStrRetDTBL("Select id,(firstname+' '+lastname)+'_'+CAST(ID as NVARCHAR(MAX))+ case WHEN NickName is NULL then '' ELSE '_'+(NickName) END as name  from Player_Master Order by Name desc", 1);

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
            try
            {
                if (cbCompetition.SelectedIndex == -1)
                { MessageBox.Show("Select Competition", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                if (cbTeam.SelectedIndex == -1)
                { MessageBox.Show("Select Team", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

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
                            // gvTeamDetails.Rows.Add();

                            ArrayList row2 = new ArrayList();
                            row2.Add(lstPlayersList.SelectedValue);
                            row2.Add(lstPlayersList.Text);
                            row2.Add(0);

                            //DataTable DTT=
                            DT = objMB.ExeQueryStrRetDTBL("select PlayerId, dbo.fn_GetPlayerName(PlayerId)+'_'+CAST(PlayerId as NVARCHAR(MAX))+'_'+cast(isnull(p.Mashal_Player_id,0) as NVARCHAR(MAX)) PlayerName,JercyNo,IsWithdraw,isReserved  from CompetitionSquad c join Player_Master p on p.ID=c.PlayerId where CompId=" + cbCompetition.SelectedValue + " And c.TeamID=" + cbTeam.SelectedValue + " and c.PlayerId=" + lstPlayersList.SelectedValue + "", 1);
                            try
                            {
                                if (DT.Rows.Count > 0)
                                {
                                    gvTeamDetails.Rows.Add(DT.Rows[0]["PlayerId"], DT.Rows[0]["PlayerName"].ToString(), Convert.ToInt32(DT.Rows[0]["JercyNo"]), Convert.ToBoolean(DT.Rows[0]["IsWithdraw"]), Convert.ToBoolean(DT.Rows[0]["isReserved"]));
                                }
                                else
                                {
                                    gvTeamDetails.Rows.Add(row2[0], row2[1].ToString(), Convert.ToInt32(row2[2]), 0, 0);
                                }
                            }
                            catch
                            {

                            }
                        }
                        catch
                        { }
                    }
                    else
                    {
                        MessageBox.Show("Player Already Contain the list", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            catch { }
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
            try
            {
                if (cbCompetition.SelectedIndex == -1)
                { MessageBox.Show("Select Competition", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                if (cbTeam.SelectedIndex == -1)
                { MessageBox.Show("Select Team", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
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
                    row2.Add(0);
                    gvTeamDetails.Rows.Add(row2[0], row2[1].ToString(), Convert.ToInt32(row2[2]));
                }
                TxtTotal.Text = gvTeamDetails.Rows.Count.ToString();
                gvTeamDetails.Sort(this.gvTeamDetails.Columns["JercyNo"], ListSortDirection.Ascending);

            }
            catch { }
        }


        void DGV2NewPlayer_fun()
        {

            //      Dt = Objbl.ExeQueryStrRetDTDL("select Pl.ID,Pl.firstname+' '+Pl.lastname BowlerName from Teams Te inner join Player Pl on Te.Playerid=Pl.id inner join Innings Inn on Inn.Matchid=Te.Matchid and Inn.Battingclubid=Te.Clubid where Te.Matchid=" + Matchid + " and Inn.ID=" + TempID + " and pl.Wicketkeeper=0 group by Pl.ID,Pl.firstname+' '+Pl.lastname", ConnectString);

            //      DGV2NewPlayer.DataSource = Dt;
            //      DGV2NewPlayer.DisplayMember = "BowlerName";
            //DGV2Newbolwer.ValueMember = "ID";



            DataTable DV = objMB.ExeQueryStrRetDTBL("select '-1' ID,'--select--'Name union Select ID,dbo.fn_GetPlayerName(ID)+'_'+CAST(ID as NVARCHAR(MAX))+ case WHEN NickName is NULL then '' ELSE '_'+(NickName) END Name from Player_Master", 1);
            DGV2NewPlayer.DataSource = DV;
            DGV2NewPlayer.DisplayMember = "Name";
            DGV2NewPlayer.ValueMember = "ID";
            //  DGV2NewPlayer.Selected = "-1";
            //DGV2NewPlayer.Selected = "--select--";
        }


        private void cbTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {




                if (!pageload) { return; }
                DT = objMB.ExeQueryStrRetDTBL("select PlayerId, dbo.fn_GetPlayerName(PlayerId)+'_'+CAST(PlayerId as NVARCHAR(MAX))+'_'+cast(isnull(p.Mashal_Player_id,0) as NVARCHAR(MAX)) PlayerName,ISNULL(JercyNo,0)JercyNo,IsWithdraw,isReserved  from CompetitionSquad c join Player_Master p on p.ID=c.PlayerId where CompId=" + cbCompetition.SelectedValue + " And c.TeamID=" + cbTeam.SelectedValue + "", 1);
                if (DT.Rows.Count > 0)
                {
                    DGV2NewPlayer_fun();
                    try
                    {
                        gvTeamDetails.Rows.Clear();
                    }
                    catch
                    {
                    }
                    for (int i = 0; i < DT.Rows.Count; i++)
                    {
                        // gvTeamDetails.Rows.Add();
                        ArrayList row2 = new ArrayList();
                        row2.Add(DT.Rows[i]["PlayerId"].ToString());
                        row2.Add(DT.Rows[i]["PlayerName"].ToString());
                        row2.Add(DT.Rows[i]["JercyNo"].ToString());
                        row2.Add(Convert.ToBoolean(DT.Rows[i]["IsWithdraw"]));
                        row2.Add(Convert.ToBoolean(DT.Rows[i]["isReserved"]));
                        gvTeamDetails.Rows.Add(row2[0], row2[1].ToString(), Convert.ToInt32(row2[2]), Convert.ToBoolean(row2[3]), Convert.ToBoolean(row2[4]));
                    }
                    TxtTotal.Text = gvTeamDetails.Rows.Count.ToString();
                    gvTeamDetails.Sort(this.gvTeamDetails.Columns["JercyNo"], ListSortDirection.Ascending);
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
            catch { }
        }

        private void cbCompetition_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!pageload) { return; }
                cbTeam.DataSource = objMB.ExeQueryStrRetDTBL("Select distinct TeamID, dbo.fn_GetTeamName(TeamID)Name from CompetitionTeam Where CompID=" + cbCompetition.SelectedValue + " Order by Name", 1);
                cbTeam.DisplayMember = "Name";
                cbTeam.ValueMember = "TeamID";
                cbTeam.SelectedIndex = -1;

            }
            catch { }
        }

        private void lstPlayersList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                MoveList();
            }
            catch { }
        }

        private void gvTeamDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
