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
    public partial class FrmAthletics_Attempts : Form
    {

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

        BusinessLy objMB = new BusinessLy();
        int r1_f = 0, r2_f = 0, r3_f = 0, r4_f = 0, r5_f = 0, r6_f = 0;
        bool pageload = false;
        DataTable Dt;
        public FrmAthletics_Attempts()
        {
            InitializeComponent();
        }

        private void FrmAthletics_Attempts_Load(object sender, EventArgs e)
        {
            pageload = false;
            bindMatches();
            pageload = true;
        }
        void bindMatches()
        {
            cbName.DataSource = objMB.ExeQueryStrRetDTBL("Select MatchID,CAST(MatchID As Varchar)+' - '+dbo.fn_GetMatchNamePreDate_Athletic(MatchId)Name from AthleticMatches Order by MatchID asc", 1);
            cbName.DisplayMember = "Name";
            cbName.ValueMember = "MatchID";
            cbName.SelectedIndex = -1;
            cbName.SelectedValue = Temp_matchid;
        }

        void clear()
        {
            txt_1.Text = "";
            txt_2.Text = "";
            txt_3.Text = "";
            txt_4.Text = "";
            txt_5.Text = "";
            txt_6.Text = "";
            chk_1.Checked = false;
            chk_2.Checked = false;
            chk_3.Checked = false;
            chk_4.Checked = false;
            chk_5.Checked = false;
            chk_6.Checked = false;
        }

        private void cbplayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            clear();
            DataTable dt3 = new DataTable();
            dt3 = objMB.ExeQueryStrRetDTBL("select * from Athletic_Entry where MatchID ="+cbName.SelectedValue+" AND PlayerID=" + cbplayer.SelectedValue, 1);
            if (dt3.Rows.Count > 0)
            {
                try
                {
                    txt_1.Text = Convert.ToString(dt3.Rows[0]["R1"]);
                    txt_2.Text = Convert.ToString(dt3.Rows[0]["R2"]);
                    txt_3.Text = Convert.ToString(dt3.Rows[0]["R3"]);
                    txt_4.Text = Convert.ToString(dt3.Rows[0]["R4"]);
                    txt_5.Text = Convert.ToString(dt3.Rows[0]["R5"]);
                    txt_6.Text = Convert.ToString(dt3.Rows[0]["R6"]);
                    if (Convert.ToInt32(dt3.Rows[0]["R1_Foul"]) == 1) { chk_1.Checked = true; }
                    if (Convert.ToInt32(dt3.Rows[0]["R2_Foul"]) == 1) { chk_2.Checked = true; }
                    if (Convert.ToInt32(dt3.Rows[0]["R3_Foul"]) == 1) { chk_3.Checked = true; }
                    if (Convert.ToInt32(dt3.Rows[0]["R4_Foul"]) == 1) { chk_4.Checked = true; }
                    if (Convert.ToInt32(dt3.Rows[0]["R5_Foul"]) == 1) { chk_5.Checked = true; }
                    if (Convert.ToInt32(dt3.Rows[0]["R6_Foul"]) == 1) { chk_6.Checked = true; }
                }
                catch { }
            }
        }
        void cleardata()
        {
            r1_f = 0;
            r2_f = 0;
            r3_f = 0;
            r4_f = 0;
            r5_f = 0;
            r6_f = 0;
        }
        private void btnpush_Click(object sender, EventArgs e)
        {
            if (cbplayer.Text == "") { MessageBox.Show("Select Player..!"); return; }
            cleardata();
            if (chk_1.Checked == true) { r1_f = 1; }
            if (chk_2.Checked == true) { r2_f = 1; }
            if (chk_3.Checked == true) { r3_f = 1; }
            if (chk_4.Checked == true) { r4_f = 1; }
            if (chk_5.Checked == true) { r5_f = 1; }
            if (chk_6.Checked == true) { r6_f = 1; }

            if (objMB.ExeQueryStrRetDTBL("select * from Athletic_Entry where MatchID=" + cbName.SelectedValue + " AND PlayerID=" + cbplayer.SelectedValue + "", 1).Rows.Count > 0)
            {
                if (objMB.ExeQueryRetBooDL("update Athletic_Entry set R1='" + txt_1.Text + "',R2='" + txt_2.Text + "',R3='" + txt_3.Text + "',R4='" + txt_4.Text + "',R5='" + txt_5.Text + "',R6='" + txt_6.Text + "',R1_Foul=" + r1_f + ",R2_Foul=" + r2_f + ",R3_Foul=" + r3_f + ",R4_Foul=" + r4_f + ",R5_Foul=" + r5_f + ",R6_Foul=" + r6_f + " where MatchID=" + cbName.SelectedValue + " AND PlayerID=" + cbplayer.SelectedValue + "", 1))
                {
                    MessageBox.Show("data pushed");
                }
            }
            else
            {
                if (objMB.ExeQueryRetBooDL("insert into Athletic_Entry(MatchID,PlayerID,R1,R2,R3,R4,R5,R6,R1_Foul,R2_Foul,R3_Foul,R4_Foul,R5_Foul,R6_Foul)values(" + cbName.SelectedValue + "," + cbplayer.SelectedValue + ",'" + txt_1.Text + "','" + txt_2.Text + "','" + txt_3.Text + "','" + txt_4.Text + "','" + txt_5.Text + "','" + txt_6.Text + "'," + r1_f + "," + r2_f + "," + r3_f + "," + r4_f + "," + r5_f + "," + r6_f + ")", 1))
                {
                    MessageBox.Show("data pushed");
                }
            }
        }

        private void cbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageload) { return; }
            Dt = new DataTable();
            Dt = objMB.ExeQueryStrRetDTBL("select Pl.ID PlayerID, Pl.firstname +' '+ Pl.lastname PlayerName,JercyNo,PickNo,dbo.fn_GetTeamName(TeamID)TeamName,TeamID,LaneNo from AthleticLineups L inner join Player_Master Pl on L.playerid=Pl.id where L.Matchid ='" + cbName.SelectedValue + "' order by Cast(JercyNo as int) asc", 1);

            cbplayer.DataSource = Dt;
            cbplayer.DisplayMember = "PlayerName";
            cbplayer.ValueMember = "PlayerID";

            lblEventName.Text = objMB.ExeQueryStrRetStrBL("Select AE.Name from AthleticMatches AM JOIN AthleticEventMaster AE ON Am.EventID=Ae.ID where AM.Matchid=" + cbName.SelectedValue + "", 1);
             
        }
    }
}
