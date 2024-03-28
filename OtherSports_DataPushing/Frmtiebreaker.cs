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
    public partial class Frmtiebreaker : Form
    {
        BusinessLy objMB = new BusinessLy();
        public Frmtiebreaker()
        {
            InitializeComponent();
        }

        private void Frmtiebreaker_Load(object sender, EventArgs e)
        {
            bindata();
            cbWintype.SelectedItem = "select";
        }

        void bindata()
        {
            this.cbCompetition.SelectedIndexChanged -= new EventHandler(cbCompetition_SelectedIndexChanged);
            cbCompetition.DataSource = objMB.ExeQueryStrRetDTBL("Select CompID ID,Name from Competition  Where SportID=" + mycommon.SportID + "", 1);
            cbCompetition.DisplayMember = "Name";
            cbCompetition.ValueMember = "ID";
            cbCompetition.SelectedIndex = -1;
            this.cbCompetition.SelectedIndexChanged += new EventHandler(cbCompetition_SelectedIndexChanged);
        }
        void bindMatches(string Filter)
        {
            this.cbName.SelectedIndexChanged -= new EventHandler(cbName_SelectedIndexChanged);
            cbName.DataSource = objMB.ExeQueryStrRetDTBL("Select MatchID,CAST(MatchID As Varchar)+' - '+dbo.fn_GetMatchNamePreDate_KB(MatchId)Name from KB_Matches " + Filter + " Order by MatchID desc", 1);
            cbName.DisplayMember = "Name";
            cbName.ValueMember = "MatchID";
            cbName.SelectedIndex = -1;
            this.cbName.SelectedIndexChanged += new EventHandler(cbName_SelectedIndexChanged);
        }
        private void cbCompetition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCompetition.SelectedIndex != -1)
            {
                bindMatches(" Where CompetitionID=" + cbCompetition.SelectedValue);
            }
        }

        public int TeamA = 0, TeamB = 0;
        public string TeamAId = "", TeamBId = "";
        private void cbName_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (cbName.SelectedIndex != -1)
            {
                string qurey = "select TeamA,TeamB,(select Prefix from Team_Master where TeamID=TeamA) as TeamAprifix,(select Prefix from Team_Master where TeamID=TeamB) as TeamBprifix from KB_Matches where MatchId=" + cbName.SelectedValue;
                DataTable dt = objMB.ExeQueryStrRetDTBL(qurey, 1);

                TeamAId = dt.Rows[0]["TeamA"].ToString();
               
                label1.Text = "T-" + dt.Rows[0]["TeamAprifix"].ToString();
                LblteamBName.Text = "T-" + dt.Rows[0]["TeamBprifix"].ToString();

                TeamBId = dt.Rows[0]["TeamB"].ToString();

                DataTable df = objMB.ExeQueryStrRetDTBL("select Score from  TieBreake where Matchid=" + cbName.SelectedValue + " and Teamid=" + TeamAId + "", 1);

                setvalue();
                teamdrop();

            }

        }

        void setvalue()
        {
          //  DataTable df1 = objMB.ExeQueryStrRetDTBL("select * from  TieBreak_score where Matchid=" + cbName.SelectedValue + "", 1);

            string qurey = "SELECT T.Matchid ,ISNULL([5R_TeamA_Points],0) AS [5R_TeamA_Points],ISNULL([5R_TeamB_Points],0) AS [5R_TeamB_Points],ISNULL([GR_TeamA_Points],0) AS [GR_TeamA_Points],ISNULL([GR_TeamB_Points],0) AS [GR_TeamB_Points] ,case when wintype='' then 'select' else wintype end as Wintype FROM [Kabaddi21].[dbo].[TieBreak_score] T where matchid=" + cbName.SelectedValue;
            DataTable df1 = objMB.ExeQueryStrRetDTBL(qurey, 1);
            if (df1.Rows.Count>0)
            {
                if (chkFiveR.Checked)
                {
                    TxtSet1A.Text = df1.Rows[0]["5R_TeamA_Points"].ToString() ;//== "" ? "0" : df1.Rows[0]["5R_TeamA_Points"].ToString();
                    TxtSet1B.Text = df1.Rows[0]["5R_TeamB_Points"].ToString() ;//== "" ? "0" : df1.Rows[0]["5R_TeamB_Points"].ToString();
                }
                else
                    if(chkGR.Checked)
                    {

                        TxtSet1A.Text = df1.Rows[0]["GR_TeamA_Points"].ToString() ;//== "" ? "0" : df1.Rows[0]["GR_TeamA_Points"].ToString();
                        TxtSet1B.Text = df1.Rows[0]["GR_TeamB_Points"].ToString() ;//== "" ? "0" : df1.Rows[0]["GR_TeamB_Points"].ToString();
                    }

                cbWintype.SelectedItem = df1.Rows[0]["Wintype"].ToString();
            }
            else
            {
                TxtSet1A.Text = "0";
                TxtSet1B.Text = "0";
                cbWintype.SelectedItem = "select";
            }

        }


        void teamdrop()
        {
            this.cbTeam.SelectedIndexChanged -= new EventHandler(cbTeam_SelectedIndexChanged);
            string qurey = "Select TeamA as ID,dbo.fn_GetTeamName(TeamA)Name from KB_Matches  where MatchId=" + cbName.SelectedValue + " union Select TeamB as ID,dbo.fn_GetTeamName(TeamB)Name from KB_Matches  where MatchId=" + cbName.SelectedValue + "";

            DataTable da = objMB.ExeQueryStrRetDTBL(qurey, 1);
            if (da.Rows.Count > 0)
            {

                cbTeam.DataSource = objMB.ExeQueryStrRetDTBL(qurey, 1);
                cbTeam.DisplayMember = "Name";
                cbTeam.ValueMember = "ID";
                cbTeam.SelectedIndex = -1;
                this.cbTeam.SelectedIndexChanged += new EventHandler(cbTeam_SelectedIndexChanged);
                TxtRaidNo.Text = "1";
                TxtBonuspoint.Text = "0";
                Txtdefendpoint.Text = "0";
                TxtRaidpoint.Text = "0";
            }
        }

        private void btnSet1AInc_Click(object sender, EventArgs e)
        {
            if (cbName.SelectedIndex != -1)
            {
                // if (TxtSet1A.Text.Trim() != "")
                {
                    TeamA = Convert.ToInt32(TxtSet1A.Text.Trim()) + 1;
                    TxtSet1A.Text = TeamA.ToString();
                    UpdateSetValues("TeamA", TeamA, TeamAId , TxtSet1A.Text,TxtSet1B.Text);
                }
            }
            else
            {
                MessageBox.Show("please select match");
            }
        }

        private void btnSet1ADes_Click(object sender, EventArgs e)
        {
            if (cbName.SelectedIndex != -1)
            {
                if (TxtSet1A.Text.Trim() != "0")
                {
                    TeamA = Convert.ToInt32(TxtSet1A.Text.Trim()) - 1;
                    TxtSet1A.Text = TeamA.ToString();

                    UpdateSetValues("TeamA", TeamA, TeamAId, TxtSet1A.Text, TxtSet1B.Text);
                }
            }
            else
            {
                MessageBox.Show("please select match");
            }
        }

        private void btnSet1BInc_Click(object sender, EventArgs e)
        {
            if (cbName.SelectedIndex != -1)
            {
                // if (TxtSet1B.Text.Trim() != "")
                {
                    TeamB = Convert.ToInt32(TxtSet1B.Text.Trim()) + 1;
                    TxtSet1B.Text = TeamB.ToString();
                    UpdateSetValues("TeamB", TeamB, TeamBId, TxtSet1A.Text, TxtSet1B.Text);
                }
            }
            else
            {
                MessageBox.Show("please select match");
            }
        }

        private void btnSet1BDes_Click(object sender, EventArgs e)
        {
            if (cbName.SelectedIndex != -1)
            {
                if (TxtSet1B.Text.Trim() != "0")
                {
                    TeamB = Convert.ToInt32(TxtSet1B.Text.Trim()) - 1;
                    TxtSet1B.Text = TeamB.ToString();

                    UpdateSetValues("TeamB", TeamB, TeamBId, TxtSet1A.Text, TxtSet1B.Text);
                }
            }
            else
            {
                MessageBox.Show("please select match");
            }
        }

        private void BtnSave_btn_Click(object sender, EventArgs e)
        {
            if (cbName.SelectedIndex != -1)
            {
                UpdateSetValues("TeamB", TeamB, TeamBId, TxtSet1A.Text, TxtSet1B.Text);
                setvalue();
            }
        }

        public void UpdateSetValues(string team, int value, string teamid,string teamA,string teamB)
        {
            int setval_A = 0;
            int setval_B = 0;

            var wintype = cbWintype.SelectedItem == "select" ? "" : cbWintype.SelectedItem;
            if (objMB.ExeQueryStrRetDTBL("select * from  TieBreak_score where Matchid=" + cbName.SelectedValue + "", 1).Rows.Count > 0)
            {
                if(chkFiveR.Checked)
                {
                    string qurey = "update TieBreak_score set [5R_TeamA_Points]=" + teamA + ",[5R_TeamB_Points]=" + teamB + ",WinType='" + wintype + "' where Matchid=" + cbName.SelectedValue + " ";
                    bool data = objMB.ExeQueryRetBooDL(qurey, 1);
                }
                if(chkGR.Checked)
                {
                    string qurey = "update TieBreak_score set [GR_TeamA_Points]=" + teamA + ",[GR_TeamB_Points]=" + teamB + ",WinType='" + wintype + "' where Matchid=" + cbName.SelectedValue + " ";
                    bool data = objMB.ExeQueryRetBooDL(qurey, 1);
                }
            }
            else
            {
                if (chkFiveR.Checked)
                {
                    string qurey = string.Format("insert into TieBreak_score(Compid,Matchid,[5R_TeamA_Points],[5R_TeamB_Points],WinType)values({0},{1},{2},{3},'{4}')", cbCompetition.SelectedValue, cbName.SelectedValue, teamA, teamB, wintype);
                    bool data = objMB.ExeQueryRetBooDL(qurey, 1);
                }
                if (chkGR.Checked)
                {
                    string qurey = string.Format("insert into TieBreak_score(Compid,Matchid,[GR_TeamA_Points],[GR_TeamB_Points],WinType)values({0},{1},{2},{3},'{4}')", cbCompetition.SelectedValue, cbName.SelectedValue, teamA, teamB, wintype);
                    bool data = objMB.ExeQueryRetBooDL(qurey, 1);
                }
            }












            if (objMB.ExeQueryStrRetDTBL("select * from  TieBreake where Matchid=" + cbName.SelectedValue + " and Teamid=" + teamid + "", 1).Rows.Count > 0)
            {
                string qurey = "update TieBreake set Score=" + value + " where Matchid=" + cbName.SelectedValue + " and Teamid=" + teamid + " ";
               // bool data = objMB.ExeQueryRetBooDL(qurey, 1);
            }
            else
            {
                string qurey = string.Format("insert into TieBreake(Compid,Matchid,Teamid,Score)values({0},{1},{2},{3})", cbCompetition.SelectedValue, cbName.SelectedValue, teamid, value);
               // bool data = objMB.ExeQueryRetBooDL(qurey, 1);
            }

        }



        private void cbTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            string qurey = " select Distinct L.playerid as ID,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname";
            qurey += " else P.firstname END AS VARCHAR(20)) AS Name,CAST(L.JercyNo AS INT)JercyNo   from lineups L INNER JOIN Player_Master P";
            qurey += " ON L.Playerid=P.id WHERE L.matchid=" + cbName.SelectedValue + " and L.ClubID=" + cbTeam.SelectedValue + " order by JercyNo-- Union All Select 0 ID ,'All',0 Name order by JercyNo";

            cbraider.DataSource = objMB.ExeQueryStrRetDTBL(qurey, 1);
            cbraider.DisplayMember = "Name";
            cbraider.ValueMember = "ID";
            cbraider.SelectedIndex = -1;

            GetTieEvent(TxtRaidNo.Text);
            Bindgridview();



        }

        private void BtnSave_event_Click(object sender, EventArgs e)
        {
            if(cbTeam.SelectedIndex==-1)
            {
                MessageBox.Show("Please  select Team");
                return;
            }

            if (cbraider.SelectedIndex == -1)
            {
                MessageBox.Show("Please select Raider");
                return;
            }

            var RaidNo = TxtRaidNo.Text;
            var TeamId = cbTeam.SelectedValue;
            var Raider = cbraider.SelectedValue;
            var Raidpoint = TxtRaidpoint.Text;
            var Defenderpoint = Txtdefendpoint.Text;
            var Bonuspoint = TxtBonuspoint.Text;

            string Insqurey = string.Format("insert into TieBreaker_event(Compid,Matchid,Teamid,RaidNo,Raider,RaidingPoint,Defendingpoint,BonusPoint) values({0},{1},{2},{3},{4},{5},{6},{7})",
                cbCompetition.SelectedValue,
                cbName.SelectedValue,
                TeamId,
                RaidNo,
                Raider,
                Raidpoint,
                Defenderpoint,
                Bonuspoint);


            string Updqurey = string.Format("update TieBreaker_event set Raider={0},RaidingPoint={1},Defendingpoint={2},BonusPoint={3} where Matchid={4} and Teamid={5} and RaidNo={6}",
               Raider,
                Raidpoint,
                Defenderpoint,
                Bonuspoint,
                cbName.SelectedValue,
                 TeamId,
                RaidNo
                );



            if (objMB.ExeQueryStrRetDTBL("select * from TieBreaker_event where Matchid=" + cbName.SelectedValue + " and Teamid=" + TeamId + " and RaidNo=" + RaidNo + "", 1).Rows.Count > 0)
            {
                // bool data = objMB.ExeQueryRetBooDL(Updqurey, 1);

                if (MessageBox.Show("This RaidNo already is ther,Do you want to update it?", "TieEvent", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    if (objMB.ExeQueryRetBooDL(Updqurey, 1))
                    {
                        MessageBox.Show("Succefully Updated");
                        var raidno = 0;
                        raidno = Convert.ToInt32(TxtRaidNo.Text.Trim()) + 1;
                        TxtRaidNo.Text = Convert.ToString(raidno);
                        GetTieEvent(TxtRaidNo.Text);
                        Bindgridview();
                    }
                    else
                    {
                        MessageBox.Show("Someting went wrong");
                    }
                }
            }
            else
            {
                if (objMB.ExeQueryRetBooDL(Insqurey, 1))
                {
                    MessageBox.Show("Succefully Inserted");
                    var raidno = 0;
                    raidno = Convert.ToInt32(TxtRaidNo.Text.Trim()) + 1;
                    TxtRaidNo.Text = Convert.ToString(raidno);
                    GetTieEvent(TxtRaidNo.Text);
                    Bindgridview(); 
                }
                else
                {
                    MessageBox.Show("Someting went wrong");
                }
            }

        }

        private void BtnRaidNo_asc_Click(object sender, EventArgs e)
        {
            var raidno = 0;
            raidno = Convert.ToInt32(TxtRaidNo.Text.Trim()) + 1;
            TxtRaidNo.Text = Convert.ToString(raidno);
            GetTieEvent(TxtRaidNo.Text);
            Bindgridview();

        }

        private void BtnRaidNo_dasc_Click(object sender, EventArgs e)
        {
            var raidno = 0;
            if (TxtRaidNo.Text.Trim() != "1")
            {
                raidno = Convert.ToInt32(TxtRaidNo.Text.Trim()) - 1;
                TxtRaidNo.Text = Convert.ToString(raidno);

                GetTieEvent(TxtRaidNo.Text);
                Bindgridview();
            }
        }

        void GetTieEvent(string raidno)
        {
            if (cbTeam.SelectedIndex != -1)
            {
                string qurey = "select * from  TieBreaker_event where Matchid=" + cbName.SelectedValue + " and Teamid=" + cbTeam.SelectedValue + " and RaidNo=" + raidno + "";
                DataTable de = objMB.ExeQueryStrRetDTBL(qurey, 1);

                if (de.Rows.Count > 0)
                {
                    TxtRaidNo.Text = de.Rows[0]["RaidNo"].ToString();
                    cbTeam.SelectedValue = de.Rows[0]["Teamid"];
                    cbraider.SelectedValue = de.Rows[0]["Raider"];
                    TxtRaidpoint.Text = de.Rows[0]["RaidingPoint"].ToString();
                    Txtdefendpoint.Text = de.Rows[0]["Defendingpoint"].ToString();
                    TxtBonuspoint.Text = de.Rows[0]["BonusPoint"].ToString();

                    dataGridView1.DataSource = de;

                    //BtnSave_event.Text = "UPDATE";

                    //sdataGridView1.DataBindings;
                }
                else
                {
                    TxtRaidpoint.Text = "0";
                    Txtdefendpoint.Text ="0";
                    TxtBonuspoint.Text = "0";
                    cbraider.SelectedValue = -1;
                }
            }

            // DataTable de = objMB.ExeQueryStrRetDTBL("",1);
        }

       
        void Bindgridview()
        {
           // string qurey = "select Matchid,RaidNo,Raider,RaidingPoint,Defendingpoint,BonusPoint from  TieBreaker_event where Matchid=" + cbName.SelectedValue + " and Teamid=" + cbTeam.SelectedValue + "";

            string qurey = "select T.Matchid,T.Teamid,T.RaidNo,T.Raider as Raiderid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname";
            qurey += " else P.firstname END AS VARCHAR(20))  as Raider,RaidingPoint,Defendingpoint,BonusPoint from  TieBreaker_event T inner join  Player_Master P";
            qurey += " on T.Raider=P.ID inner join Lineups L  ON L.Playerid=P.id and T.MatchID=L.MatchID and T.Teamid=L.ClubID where T.MatchID=" + cbName.SelectedValue + " and T.Teamid=" + cbTeam.SelectedValue + "";
            DataTable de = objMB.ExeQueryStrRetDTBL(qurey, 1);
            if (de.Rows.Count > 0)
            {
                dataGridView1.DataSource = de;
                dataGridView1.Visible = true;
                //sdataGridView1.DataBindings;
            }
            
        }

        private void chkGR_CheckedChanged(object sender, EventArgs e)
        {
            if(chkGR.Checked)
            {
                chkFiveR.Checked = false;
                if (cbName.SelectedIndex != -1)
                {
                    setvalue();
                }
            }
            else
            {
                chkFiveR.Checked = true;
            }

        }

        private void chkFiveR_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFiveR.Checked)
            {
                chkGR.Checked = false;
                if (cbName.SelectedIndex != -1)
                {
                    setvalue();
                }
            }
            else
            {
                chkGR.Checked = true;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                var RaidNo = dataGridView1.CurrentRow.Cells["RaidNo"].Value.ToString();
                var Teamid = Convert.ToInt32(dataGridView1.CurrentRow.Cells["TeamId"].Value.ToString());
                var Defendingpoint = dataGridView1.CurrentRow.Cells["Defendingpoint"].Value.ToString();
                var RaidingPoint = dataGridView1.CurrentRow.Cells["RaidPoint"].Value.ToString();
                var BonusPoint = dataGridView1.CurrentRow.Cells["BonusPoint"].Value.ToString();
                var Raider = dataGridView1.CurrentRow.Cells["Raiderid"].Value.ToString();

                TxtRaidNo.Text = RaidNo;
                cbTeam.SelectedValue = Teamid;
                Txtdefendpoint.Text = Defendingpoint;
                TxtRaidpoint.Text = RaidingPoint;
                TxtBonuspoint.Text = BonusPoint;
                cbraider.SelectedValue = Raider;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

      
        

       

       

    }
}
