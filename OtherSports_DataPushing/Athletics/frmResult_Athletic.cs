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

namespace OtherSports_DataPushing.Athletics
{
    public partial class frmResult_Athletic : Form
    {
        SendtoViz ObjFndCtrl = new SendtoViz();
        DataTable Dt;
        MasterDL objMB = new MasterDL();
        Boolean PageLoad = false;
        string Query = "";
        int Temp_matchid;
        public Int32 Score_Matchid
        {
            get
            {
                return Temp_matchid;
            }
            set
            {
                Temp_matchid = value;
            }
        }

        public frmResult_Athletic()
        {
            InitializeComponent();
        }

        private void frmResult_Athletic_Load(object sender, EventArgs e)
        {
            loadGird();
        }

        void loadGird()
        {
            try
            {
                dgvResult.DataSource = null;
                try
                {
                    dgvResult.Rows.Clear();
                }
                catch
                {
                    dgvResult.Rows.Clear();
                }
                string Statsname = objMB.ExeQueryStrRetStrDL("Select case when MatchTypeID=1 then 'Time' Else 'Distance' END from AthleticMatches where Matchid=" + Temp_matchid + "", 1);

                dgvResult.Columns[7].HeaderText = Statsname;
                lblEventName.Text = objMB.ExeQueryStrRetStrDL("Select AE.Name from AthleticMatches AM JOIN AthleticEventMaster AE ON Am.EventID=Ae.ID where AM.Matchid=" + Temp_matchid + "", 1);
                Dt = new DataTable();
                Dt = objMB.ExeQueryStrRetDTDL("select Pl.ID PlayerID, Pl.firstname +' '+ Pl.lastname PlayerName,PickNo,dbo.fn_GetTeamName(TeamID)TeamName,TeamID,L.Rank, L.Value [" + Statsname + "] from AthleticResult L inner join Player_Master Pl on L.playerid=Pl.id where L.Matchid ='" + Temp_matchid + "' order by Cast(L.Rank as int) asc", 1);
                if (Dt.Rows.Count <= 0)
                {
                    Dt = new DataTable();
                    Dt = objMB.ExeQueryStrRetDTDL("select Pl.ID PlayerID, Pl.firstname +' '+ Pl.lastname PlayerName,PickNo,dbo.fn_GetTeamName(TeamID)TeamName,TeamID,0 Rank,'' " + Statsname + "  from AthleticLineups L inner join Player_Master Pl on L.playerid=Pl.id where L.Matchid ='" + Temp_matchid + "' order by Cast(JercyNo as int) asc", 1);

                }
                if (Dt.Rows.Count > 0)
                {
                    dgvResult.AutoGenerateColumns = false;

                    int i = 0, n = Dt.Rows.Count;
                    dgvResult.Rows.Add(n);

                    while (n != 0)
                    {
                        dgvResult.Rows[i].Cells[0].Value = (Dt.Rows[i]["Rank"].ToString() == "0" ? 0 : 1);
                        dgvResult.Rows[i].Cells[1].Value = Dt.Rows[i]["Rank"].ToString();
                        dgvResult.Rows[i].Cells[2].Value = Dt.Rows[i]["PlayerID"].ToString();
                        dgvResult.Rows[i].Cells[3].Value = Dt.Rows[i]["PlayerName"].ToString();
                        dgvResult.Rows[i].Cells[4].Value = Dt.Rows[i]["TeamID"];
                        dgvResult.Rows[i].Cells[5].Value = Dt.Rows[i]["TeamName"];
                        dgvResult.Rows[i].Cells[6].Value = Dt.Rows[i]["PickNo"];
                        dgvResult.Rows[i].Cells[7].Value = Dt.Rows[i][Statsname];
                        n--;
                        i++;
                    }
                }
                dgvResult.Sort(this.dgvResult.Columns["PickNo"], ListSortDirection.Ascending);
            }
            catch
            {

            }
            finally
            {

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dgvResult.Refresh();
            try
            {
                if (objMB.ExeQueryStrRetDTDL("Select * from AthleticResult where matchid=" + Temp_matchid + "", 1).Rows.Count > 0)
                {
                    objMB.ExeQueryRetBooDL("Delete from AthleticResult where matchid=" + Temp_matchid + "", 1);
                }
                foreach (DataGridViewRow dr in dgvResult.Rows)
                {
                    Query = "Insert Into AthleticResult (MatchID,ClubID,PlayerId,Rank,Value)values(" + Temp_matchid + "," + dr.Cells["TeamId"].Value + "," + dr.Cells["PlayerId"].Value + "," + dr.Cells["Rank"].Value + ",'" + dr.Cells["Stats"].Value + "')";
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

        private void dgvResult_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != 0) { return; }
                Int32 Selectcount = 1;
                //Int32 Mincount = 0;
                Int32 Maxcount = 0;
                List<int> boList = new List<int>();
                foreach (DataGridViewRow dr in dgvResult.Rows)
                {
                    if (dr.Cells[0].Value.ToString() != "")
                    {
                        if (Convert.ToInt32(dr.Cells[0].Value) == 1 && Convert.ToInt32(dr.Cells[1].Value) != 0)
                        {
                            if (Convert.ToInt32(dr.Cells[1].Value) > Maxcount)
                            {
                                Maxcount = Convert.ToInt32(dr.Cells[1].Value);
                            }
                            boList.Add(Convert.ToInt32(dr.Cells[1].Value));

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
                if (dgvResult.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
                {
                    if (Convert.ToInt32(dgvResult.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) == 1)
                        dgvResult.Rows[e.RowIndex].Cells[1].Value = Selectcount;
                    else
                        dgvResult.Rows[e.RowIndex].Cells[1].Value = 0;
                }
                else
                    dgvResult.Rows[e.RowIndex].Cells[1].Value = 0;

            }
            catch { }
        }

        private void dgvResult_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvResult_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvResult.EndEdit();
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            FrmAthletics_Attempts frm = new FrmAthletics_Attempts();
            frm.Score_Matchid = CommonCls.MatchId;
            frm.Show();
        }
    }
}
