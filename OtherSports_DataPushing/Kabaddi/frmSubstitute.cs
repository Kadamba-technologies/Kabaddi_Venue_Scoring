using OtherSports_DataPushing.Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtherSports_DataPushing
{
    public partial class frmSubstitute : Form
    {
        DataTable Dt;
        MasterDL obj = new MasterDL();
        bool pageload = false;
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
        public frmSubstitute()
        {
            InitializeComponent();
        }

        public frmSubstitute(int Matchid)
        {
            pageload = true;
            InitializeComponent();
            Temp_matchid = Matchid;
            rbTeamA.Text = CommonCls.Club1Prefix;
            rbTeamB.Text = CommonCls.Club2Prefix;
            rbTeamA.Checked = true;
            BindGrid();
            pageload = false;
        }

        private void frmSubstitute_Load(object sender, EventArgs e)
        {

        }
        void loadInplayerList(string Filter)
        {
            try
            {
                Dt = new DataTable();
                Dt = obj.ExeQueryStrRetDTDL("Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20))+'('+dbo.fn_getTeamnameprefix(L.clubid)+')' AS firstname,L.JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + Temp_matchid + " " + Filter + "", 1);
                lbCurPlayerList.DataSource = Dt;
                lbCurPlayerList.DisplayMember = "firstname";
                lbCurPlayerList.ValueMember = "playerid";
                lbCurPlayerList.SelectedIndex = -1;

                Dt = new DataTable();
                Dt = obj.ExeQueryStrRetDTDL("Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20))+'('+dbo.fn_getTeamnameprefix(L.clubid)+')' AS firstname,L.JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + Temp_matchid + " " + Filter + "", 1);
                lbSubPlayerList.DataSource = Dt;
                lbSubPlayerList.DisplayMember = "firstname";
                lbSubPlayerList.ValueMember = "playerid";
                lbSubPlayerList.SelectedIndex = -1;
            }
            catch { }
        }

        private void rbTeam_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTeamA.Checked)
            {
                loadInplayerList(" And L.ClubID=" + CommonCls.ClubId1);
            }
            else if (rbTeamB.Checked)
            {
                loadInplayerList(" And L.ClubID=" + CommonCls.ClubId2);
            }
        }
        double CurTimeinSec = 0;

        private void btnAdd_Click(object sender, EventArgs e)
        {

            int playerId = Convert.ToInt32(lbCurPlayerList.SelectedValue);
            int SubplayerId = Convert.ToInt32(lbSubPlayerList.SelectedValue);
            try
            {
                CurTimeinSec = TimeSpan.Parse("00:" + dtp_MatchClock.Value.Minute.ToString("D2") + ":" + dtp_MatchClock.Value.Second.ToString("D2")).TotalSeconds;
            }
            catch { }
            if (btnAdd.Text == "Update")
            {
                obj.ExeQueryRetBooDL("Update Substitute set PlayerId=" + playerId + ",SubPlayerId=" + SubplayerId + ",Time=" + CurTimeinSec + "  Where Matchid=" + Temp_matchid + " And RaidNo=" + cbRaidNo.SelectedValue + " And PlayerId=" + CurINPlayer + "  And SubPlayerId=" + CursubPlayer+"", 1);
                //obj.ExeQueryRetBooDL("Update Lineups Set Issub=1, Islive=0 Where Matchid=" + Temp_matchid + " And PlayerID=" + playerId + "", 1);
                //obj.ExeQueryRetBooDL("Update Lineups Set Issub=0, Islive=1 Where Matchid=" + Temp_matchid + " And PlayerID=" + SubplayerId + "", 1);
                try
                {
                    int cnt = obj.ExeQueryStrDL("Select ISNULL(Count(Raidno),0)+1 From tblCorrectedRaid where Matchid=" + Temp_matchid + " And HalfID=" + lblHalfID.Text + " AND RaidNo=" + cbRaidNo.SelectedValue + "", 1);
                    obj.ExeQueryRetBooDL("Insert into tblCorrectedRaid (Matchid,HalfID,Raidno,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + Temp_matchid + "," + lblHalfID.Text + "," + cbRaidNo.SelectedValue + "," + cnt + ",'Substitute','" + System.DateTime.Now + "',0,0,1)", 1);
                }
                catch { }
            }
            else
            {
                if (btnAdd.Text == "ADD")
                {
                    obj.ExeQueryRetBooDL("Insert Into Substitute(Matchid,HalfID,RaidNo,PlayerId,SubPlayerId,Time) Values(" + Temp_matchid + "," + lblHalfID.Text + "," + cbRaidNo.SelectedValue + "," + playerId + "," + SubplayerId + "," + CurTimeinSec + ")", 1);
                    //obj.ExeQueryRetBooDL("Update Lineups Set Issub=1, Islive=0 Where Matchid=" + Temp_matchid + " And PlayerID=" + playerId + "", 1);
                    //obj.ExeQueryRetBooDL("Update Lineups Set Issub=0, Islive=1 Where Matchid=" + Temp_matchid + " And PlayerID=" + SubplayerId + "", 1);
                    try
                    {
                        int cnt = obj.ExeQueryStrDL("Select ISNULL(Count(Raidno),0)+1 From tblCorrectedRaid where Matchid=" + Temp_matchid + " And HalfID=" + lblHalfID.Text + " AND RaidNo=" + cbRaidNo.SelectedValue + "", 1);
                        obj.ExeQueryRetBooDL("Insert into tblCorrectedRaid (Matchid,HalfID,Raidno,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + Temp_matchid + "," + lblHalfID.Text + "," + cbRaidNo.SelectedValue + "," + cnt + ",'Substitute','" + System.DateTime.Now + "',1,0,0)", 1);
                    }
                    catch { }
                }
            }
            BindGrid();
            btnClear.PerformClick();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Continue to Delete This Substitution", "Kabaddi Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (Result == DialogResult.Yes)
            {
               int DelRaidno = Convert.ToInt32(gvSubstitute.Rows[gvSubstitute.CurrentRow.Index].Cells["AutoID"].Value);
               int DelsubPlayer = Convert.ToInt32(gvSubstitute.CurrentRow.Cells["SubInID"].Value.ToString());
               int DelINPlayer = Convert.ToInt32(gvSubstitute.CurrentRow.Cells["SubOutID"].Value.ToString());
               if ((obj.ExeQueryRetBooDL("Delete from [Substitute] Where MatchId=" + Temp_matchid + " And Subplayerid=" + DelsubPlayer + " and playerid=" + DelINPlayer + "", 1)))
                {
                    obj.ExeQueryRetBooDL("Update Lineups Set Issub=1, Islive=0 Where Matchid=" + Temp_matchid + " And PlayerID=" + DelsubPlayer + "", 1);
                    obj.ExeQueryRetBooDL("Update Lineups Set Issub=0, Islive=1 Where Matchid=" + Temp_matchid + " And PlayerID=" + DelINPlayer + "", 1);
                   
                    try
                    {
                        int cnt = obj.ExeQueryStrDL("Select ISNULL(Count(Raidno),0)+1 From tblCorrectedRaid where Matchid=" + Temp_matchid + " And HalfID=" + lblHalfID.Text + " AND RaidNo=" + cbRaidNo.SelectedValue + "", 1);
                        obj.ExeQueryRetBooDL("Insert into tblCorrectedRaid (Matchid,HalfID,Raidno,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + Temp_matchid + "," + lblHalfID.Text + "," + cbRaidNo.SelectedValue + "," + cnt + ",'Substitute','" + System.DateTime.Now + "',0,0,1)", 1);
                    }
                    catch { }
                    BindGrid();
                }
            }
        }


        void BindGrid()
        {
            pageload = true;
            Dt = new DataTable();
            Dt = obj.ExeQueryStrRetDTDL("SELECT Matchid,Halfid,RaidNo,time,dbo.Fn_GetPlayerTeamid(Matchid,playerid)TeamID,dbo.fn_GetTeamNameprefix(dbo.Fn_GetPlayerTeamid(Matchid,playerid))TeamName,playerid SubOutID,dbo.fn_GetPlayerFullName(playerid)SubOut,Subplayerid SubInID,dbo.fn_GetPlayerFullName(Subplayerid)SubIN FROM Substitute where matchid=" + Temp_matchid + " order by halfID,Time", 1);
            gvSubstitute.AutoGenerateColumns = false;
            gvSubstitute.DataSource = Dt;

            Dt = new DataTable();
            Dt = obj.ExeQueryStrRetDTDL("SELECT RaidNo FROM Raid where matchid=" + Temp_matchid + " order by RaidNo desc", 1);
            cbRaidNo.DataSource = Dt;
            cbRaidNo.DisplayMember = "Raidno";
            cbRaidNo.ValueMember = "Raidno";
            cbRaidNo.SelectedIndex = -1;
            pageload = false;
        }

        private void cbRaider_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pageload || cbRaidNo.SelectedIndex==-1) { return; }

            lblHalfID.Text = obj.ExeQueryStrRetStrDL("Select Halfid From Raid where MAtchid=" + Temp_matchid + " and RaidNo=" + cbRaidNo.SelectedValue + "", 1);
        }

        int CurRaidno = 0, CursubPlayer = 0, CurINPlayer = 0, CurTime = 0;
        private void gvSubstitute_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                CurRaidno = Convert.ToInt32(gvSubstitute.CurrentRow.Cells["RaidNo"].Value.ToString());
                CurINPlayer = Convert.ToInt32(gvSubstitute.CurrentRow.Cells["SubOutID"].Value.ToString());
                CursubPlayer = Convert.ToInt32(gvSubstitute.CurrentRow.Cells["SubInID"].Value.ToString());
                CurTime = Convert.ToInt32(gvSubstitute.CurrentRow.Cells["Time"].Value.ToString());
                cbRaidNo.SelectedValue = CurRaidno;
                if (Convert.ToInt32(gvSubstitute.CurrentRow.Cells["TeamID"].Value.ToString()) == CommonCls.ClubId1)
                {
                    rbTeamA.Checked = true;
                }
                else if (Convert.ToInt32(gvSubstitute.CurrentRow.Cells["TeamID"].Value.ToString()) == CommonCls.ClubId2)
                {
                    rbTeamB.Checked = true;
                }
                TimeSpan span3 = TimeSpan.FromSeconds(Convert.ToInt32(CurTime));
                dtp_MatchClock.Value = DateTime.ParseExact(span3.ToString(@"mm\:ss"), "mm:ss", CultureInfo.InvariantCulture);
                btnAdd.Text = "Update";
                lbCurPlayerList.SelectedValue = CurINPlayer;
                lbSubPlayerList.SelectedValue = CursubPlayer;
            }
            catch { MessageBox.Show("retrive Error"); }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lbSubPlayerList.SelectedIndex = -1;
            lbCurPlayerList.SelectedIndex = -1;
            cbRaidNo.SelectedIndex= - 1;
            btnAdd.Text = "ADD";
        }
    }
}
