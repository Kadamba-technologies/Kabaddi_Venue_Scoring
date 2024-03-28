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

namespace OtherSports_DataPushing
{
    public partial class FrmLineup_Kabaddi : Form
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

        public FrmLineup_Kabaddi()
        {
            InitializeComponent();
        }

        private void btnassigntoclubplayerlist_Click(object sender, EventArgs e)
        {
            moveFromList();
            gvTeamDetails.ClearSelection();

            gvTeamDetails.CurrentCell = null;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            gvTeamDetails.Refresh();
            int sub = 0, Live = 0;
            int Rank_val = 0, Raval = 1, Sub_Rank = 0, Captain = 0, Started = 0; 

            try
            {

                if (objMB.ExeQueryStrRetDTBL("Select * from Lineups where matchid=" + Temp_matchid + " and ClubID Not IN(select L.TeamA FROM KB_Matches L where L.MatchID=" + Temp_matchid + " UNION ALL select L.TeamB FROM KB_Matches L where L.MatchID=" + Temp_matchid + ")", 1).Rows.Count > 0)
                {
                    objMB.ExeQueryRetBooDL("Delete from Lineups where matchid=" + Temp_matchid + " and ClubID Not IN(select L.TeamA FROM KB_Matches L where L.MatchID=" + Temp_matchid + " UNION ALL select L.TeamB FROM KB_Matches L where L.MatchID=" + Temp_matchid + ")", 1);                   
                }

                if (objMB.ExeQueryStrRetDTBL("Select * from Lineups where matchid=" + Temp_matchid + " and ClubID=" + cbTeams.SelectedValue + "", 1).Rows.Count > 0)
                {
                    objMB.ExeQueryRetBooDL("Delete from Lineups where matchid=" + Temp_matchid + " and ClubID=" + cbTeams.SelectedValue + "", 1);
                    try
                    {
                        int cnt = objMB.ExeQueryStrIntBL("Select ISNULL(Count(*),0)+1 From tblCorrectedTable where Matchid=" + Temp_matchid + " And tablename='Lineups'", 1);
                        objMB.ExeQueryRetBooDL("Insert into tblCorrectedTable (Matchid,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + Temp_matchid + "," + cnt + ",'Lineups','" + System.DateTime.Now + "',0,0,1)", 1);
                    }
                    catch { }
                }
                foreach (DataGridViewRow dr in gvTeamDetails.Rows)
                {
                    Live = 0;
                    sub = 0;
                    Sub_Rank = 0;
                    Captain = 0;
                    Started = 0;
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
                            Sub_Rank = Convert.ToInt32(dr.Cells["Sorder"].Value.ToString());
                        }
                    }
                    else
                    {
                        sub = 0;
                    }
                    try
                    {
                        Rank_val = Convert.ToInt32(dr.Cells["Rank"].Value.ToString());
                    }
                    catch
                    {

                        Rank_val = 0;
                    }
                    try
                    {
                        if (dr.Cells["IsCaptain"].Value.ToString() == "True" || dr.Cells["IsCaptain"].Value.ToString() == "1")
                            Captain = 1;
                        else
                            Captain = 0;
                    }
                    catch
                    {

                        Captain = 0;
                    }
                    try
                    {
                        if (dr.Cells["IsStarted"].Value.ToString() == "True" || dr.Cells["IsStarted"].Value.ToString() == "1")
                            Started = 1;
                        else
                            Started = 0;
                    }
                    catch
                    {

                        Started = 0;
                    }
                    Query = "Insert Into Lineups (MatchID,ClubID,PlayerId,IsSub,JercyNo,islive,Role,Position,sno,Sub_Sno,IsCaptain,IsStarted)values(" + Temp_matchid + "," + cbTeams.SelectedValue + "," + dr.Cells["PlayerId"].Value + "," + sub + "," + dr.Cells["JercyNo"].Value + ",'" + Live + "'," + (dr.Cells["Role"].Value != null ? dr.Cells["Role"].Value : 0) + "," + (dr.Cells["Position"].Value != null ? dr.Cells["Position"].Value : 0) + "," + (Rank_val == 0 ? "Null" : Rank_val.ToString()) + "," + (Sub_Rank == 0 ? "Null" : Sub_Rank.ToString()) + "," + Captain + ",'" + Started + "')";
                    objMB.ExeQueryRetBooDL(Query, 1);
                }
                if (true)
                {
                    MessageBox.Show("Update Successfully", "Kabaddi Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    try
                    {
                        int cnt = objMB.ExeQueryStrIntBL("Select ISNULL(Count(*),0)+1 From tblCorrectedTable where Matchid=" + Temp_matchid + " And tablename='Lineups'", 1);
                        objMB.ExeQueryRetBooDL("Insert into tblCorrectedTable (Matchid,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + Temp_matchid + "," + cnt + ",'Lineups','" + System.DateTime.Now + "',1,0,0)", 1);
                    }
                    catch { }
                }
            }
            catch
            {
                MessageBox.Show("Error On DataBase", "Kabaddi Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FrmLineup_Load(object sender, EventArgs e)
        {
           
            try
            {
                fillCombo();
                objMB = new BusinessLy();
                Dt = new DataTable();
                Dt = objMB.ExeQueryStrRetDTBL("select TeamID,TeamName from Team_Master where TeamID in(select TeamA from KB_Matches where Matchid=" + Temp_matchid + " Union select TeamB from KB_Matches where Matchid=" + Temp_matchid + ")", 1);
                string tempstr = "select TeamID,TeamName from Team_Master where TeamID in(select TeamA from KB_Matches where Matchid=" + Temp_matchid + " Union select TeamB from KB_Matches where Matchid=" + Temp_matchid + ")";
                cbTeams.DataSource = Dt;
                cbTeams.DisplayMember = "Teamname";
                cbTeams.ValueMember = "TeamID";

                cbTeams.SelectedValue = Temp_clubidA;
                PageLoad = true;
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
                MessageBox.Show("Error on Player name fill", "Kabaddi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TxtPlayerFilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                objMB = new BusinessLy();
                Dt = new DataTable();
                if (TxtPlayerFilter.Text != "")
                    Dt = objMB.ExeQueryStrRetDTBL("Select id,(firstname+' '+lastname) as name  from Player_Master Where SportID="+mycommon.SportID+" And (firstname+' '+lastname) like '%" + TxtPlayerFilter.Text + "%'Order by id desc", 1);
                else
                    Dt = objMB.ExeQueryStrRetDTBL("Select id,(firstname+' '+lastname) as name  from Player_Master Where SportID=" + mycommon.SportID + " And Order by id desc", 1);

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
                    MessageBox.Show("Player Not Found", "Kabaddi Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            gvTeamDetails.DataSource=null;
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
                Dt = objMB.ExeQueryStrRetDTBL("select Pl.ID PlayerID, Pl.firstname +' '+ Pl.lastname PlayerName,JercyNo,IsLive,Position,L.Role,ISNULL(Sno,Sub_Sno) Rank,ISNULL(Sub_Sno,0)Sub_Sno,ISNULL(IsCaptain,0)IsCaptain,ISNULL(IsStarted,0)IsStarted from Lineups L inner join Player_Master Pl on L.playerid=Pl.id where L.Matchid ='" + Temp_matchid + "' and L.ClubID='" + cbTeams.SelectedValue + "' order by Cast(Sno as int) asc", 1);

                num = 0;
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
                        gvTeamDetails.Rows[i].Cells[4].Value = Dt.Rows[i]["Position"].ToString();
                        gvTeamDetails.Rows[i].Cells[5].Value = Dt.Rows[i]["Role"].ToString();
                        gvTeamDetails.Rows[i].Cells[6].Value = Dt.Rows[i]["Rank"];
                        gvTeamDetails.Rows[i].Cells[7].Value = Dt.Rows[i]["Sub_Sno"];
                        gvTeamDetails.Rows[i].Cells[8].Value = Dt.Rows[i]["IsCaptain"];
                        gvTeamDetails.Rows[i].Cells[9].Value = Dt.Rows[i]["IsStarted"];
                        if (Dt.Rows[i]["Islive"].ToString() == "1")
                            num++;
                        n--;
                        i++;
                    }
                    TxtTotal.Text = gvTeamDetails.Rows.Count.ToString();
                    txtIslive.Text = num.ToString();
                }
                else
                {
                    Dt = new DataTable();
                    //Dt = objMB.ExeQueryStrRetDTBL("select Distinct Pl.ID PlayerID, Pl.firstname +' '+ Pl.lastname PlayerName,JercyNo,IsSubstitute,IsCaptain,IsGoalKeeper from Lineup L inner join player Pl on L.playerid=Pl.id where L.TeamId='" + cbTeams.SelectedValue + "' order by PlayerName asc", 1);
                    Dt = objMB.ExeQueryStrRetDTBL("select Distinct Pl.ID PlayerID, Pl.firstname +' '+ Pl.lastname PlayerName,JercyNo,Islive,Position,Role,ISNULL(Sno,Sub_Sno) Rank,ISNULL(Sub_Sno,0)Sub_Sno,ISNULL(IsCaptain,0)IsCaptain,ISNULL(IsStarted,0)IsStarted from Lineups L inner join Player_Master Pl on L.playerid=Pl.id where L.Clubid='" + cbTeams.SelectedValue + "' and L.MatchID=(SElect Max(matchid) from Lineups Lu Where Lu.Clubid='" + cbTeams.SelectedValue + "') order by Sno asc", 1);
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
                            row1.Add(Dt.Rows[i]["Position"]);
                            row1.Add(Dt.Rows[i]["Role"]);
                            row1.Add(Dt.Rows[i]["Rank"]);
                            row1.Add(Dt.Rows[i]["Sub_Sno"]);
                            row1.Add(Dt.Rows[i]["IsCaptain"]);
                            row1.Add(Dt.Rows[i]["IsStarted"]);
                            //gvTeamDetails.Rows.Add(row1);
                            gvTeamDetails.Rows.Add(row1[0], row1[1], row1[2].ToString(), Convert.ToInt32(row1[3]), row1[4], row1[5], row1[6], row1[7], row1[8], row1[9]);

                            if (Dt.Rows[i]["Islive"].ToString() == "1")
                                num++;
                        }
                        TxtTotal.Text = gvTeamDetails.Rows.Count.ToString();
                    }
                    else
                    {
                        gvTeamDetails.Rows.Clear();
                        txtIslive.Text = "0";
                    }
                }
                gvTeamDetails.Sort(this.gvTeamDetails.Columns["Rank"], ListSortDirection.Ascending);
                gvTeamDetails.Sort(gvTeamDetails.Columns["Sorder"], ListSortDirection.Ascending);

                gvTeamDetails.ClearSelection();

                gvTeamDetails.CurrentCell = null;

            }
            catch
            {

            }
            finally
            {

            }
            Rankchange = true;
        }
        bool Onebyone = true;

        private void lstPlayersList_DoubleClick(object sender, EventArgs e)
        {
            if(!PageLoad)
        { return; }
            Onebyone = false;
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
                       // int j = Convert.ToInt32(row2[2]);
                       // var c = gvTeamDetails.Rows.Count;
                        gvTeamDetails.Rows.Add(row2[0], (gvTeamDetails.Rows.Count < 7 ? 1 : 0), row2[1].ToString(), Convert.ToInt32(row2[2]), null, null, (gvTeamDetails.Rows.Count < 7 ? gvTeamDetails.Rows.Count + 1 : 0), (gvTeamDetails.Rows.Count >= 7 ? gvTeamDetails.Rows.Count + 1 : 0), (gvTeamDetails.Rows.Count == 0 ? 1 : 0), (gvTeamDetails.Rows.Count < 7 ? 1 : 0));

                        txtIslive.Text = Convert.ToInt32((gvTeamDetails.Rows.Count <= 7 ? 1 : 0)+Convert.ToInt32(txtIslive.Text)).ToString();
                    }
                    catch
                    { }
                }
                else
                {
                    MessageBox.Show("Player Already Contain the list", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                TxtTotal.Text = gvTeamDetails.Rows.Count.ToString();
                if (Onebyone)
                gvTeamDetails.Sort(this.gvTeamDetails.Columns["Rank"], ListSortDirection.Ascending);
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
        int[] GkPlayerId= new int[2];

        private void gvTeamDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 8))
            {
                foreach (DataGridViewRow dgr in gvTeamDetails.Rows)
                {
                    DataGridViewCheckBoxCell chk1 = (DataGridViewCheckBoxCell)dgr.Cells[8];
                    if (dgr.Index == e.RowIndex)
                    {
                        chk1.Value = 1;
                    }
                    else
                    {
                        chk1.Value = 0;
                    }
                }
                gvTeamDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 1;
            }
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
                    gvTeamDetails.Rows.Add(row2[0],0, row2[1].ToString(), Convert.ToInt32(row2[2]));
              
                TxtTotal.Text = gvTeamDetails.Rows.Count.ToString();
            }
            gvTeamDetails.Sort(this.gvTeamDetails.Columns["Rank"], ListSortDirection.Ascending);
            //gvTeamDetails.Refresh();
        }

        private void fillCombo()
        {
            try
            {
                objMB = new BusinessLy();
                Dt = new DataTable();
                Dt = objMB.ExeQueryStrRetDTBL("select Id,Name From Role", 1);
                Dictionary<string, string> lstRole = new Dictionary<string, string>();
                foreach (DataRow dr in Dt.Rows)
                {
                    lstRole.Add(dr["Id"].ToString(), dr["Name"].ToString());
                }
                Role.DataSource = new BindingSource(lstRole, null);
                Role.DisplayMember = "Value";
                Role.ValueMember = "Key";


                Dt = new DataTable();
                Dt = objMB.ExeQueryStrRetDTBL("select Id,Name From Position", 1);
                Dictionary<string, string> lstPosition = new Dictionary<string, string>();
                foreach (DataRow dr in Dt.Rows)
                {
                    lstPosition.Add(dr["Id"].ToString(), dr["Name"].ToString());
                }
                Position.DataSource = new BindingSource(lstPosition, null);
                Position.DisplayMember = "Value";
                Position.ValueMember = "Key";

                //Dictionary<string, string> lstForB = new Dictionary<string, string>();
                //lstForB.Add("1", "Forehand");
                //lstForB.Add("2", "Backhand");
                //ForB.DataSource = new BindingSource(lstForB, null);
                //ForB.DisplayMember = "Value";
                //ForB.ValueMember = "Key";
            }
            catch { }
        }

        private void gvTeamDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void gvTeamDetails_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8 || e.ColumnIndex == 3) { return; }
            if (e.ColumnIndex == 1)
            {
                gvTeamDetails.Refresh();
                Int32 Selectcount = 1;
                //Int32 Mincount = 0;
                Int32 Maxcount = 0;
                List<int> boList = new List<int>();
                foreach (DataGridViewRow dr in gvTeamDetails.Rows)
                {
                    if (dr.Cells[1].Value.ToString() != "")
                    {
                        if (Convert.ToInt32(dr.Cells[1].Value) == 1 && Convert.ToInt32(dr.Cells[6].Value) != 0)
                        {
                            if (Convert.ToInt32(dr.Cells[6].Value) > Maxcount)
                            {
                                Maxcount = Convert.ToInt32(dr.Cells[6].Value);
                            }
                            boList.Add(Convert.ToInt32(dr.Cells[6].Value));

                            Selectcount++;
                        }
                    }
                }

                boList.Sort();
                for (int i = 0; i < boList.Count; i++)
                {
                    if (i + 1 != boList[i])
                    {
                        Selectcount = i + 1;
                        i = boList.Count;

                    }
                }
                if (gvTeamDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
                {
                    if (Convert.ToInt32(gvTeamDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) == 1)
                        gvTeamDetails.Rows[e.RowIndex].Cells[6].Value = Selectcount;
                    else
                        gvTeamDetails.Rows[e.RowIndex].Cells[6].Value = 0;
                }
                else
                    gvTeamDetails.Rows[e.RowIndex].Cells[6].Value = 0;
            }
        }
        bool Rankchange = true;
        int num = 0;

        private void gvTeamDetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 8) { return; }
                if (!Rankchange) { Rankchange = true; return; }
                bool isChecked = Convert.ToBoolean(gvTeamDetails.Rows[gvTeamDetails.CurrentCell.RowIndex].Cells[1].Value.ToString());

                if (isChecked)
                {
                    num += 1;
                }
                else
                {
                    num -= 1;
                }
                txtIslive.Text = num.ToString();

                Rankchange = true;
            }
            catch
            {
            }
        }

        private void gvTeamDetails_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (gvTeamDetails.IsCurrentCellDirty)
            {
                gvTeamDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }

        }

        private void gvTeamDetails_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            Rankchange = false;
            gvTeamDetails.EndEdit();
        }
    }
}
