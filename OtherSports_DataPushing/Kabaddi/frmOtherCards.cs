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

namespace OtherSports_DataPushing.Kabaddi
{
    public partial class frmOtherCards : Form
    {
        DataTable Dt;
        MasterDL obj = new MasterDL();

        int Temp_matchid;
        int Temp_halfid;
        int Temp_RaidNo;
        double Temp_Time;

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
        public Int32 Score_HalfID
        {
            get
            {
                return Temp_halfid;
            }
            set
            {
                Temp_halfid = value;
            }
        }
        public Int32 Score_RaidNo
        {
            get
            {
                return Temp_RaidNo;
            }
            set
            {
                Temp_RaidNo = value;
            }
        }
        public double Score_Time
        {
            get
            {
                return Temp_Time;
            }
            set
            {
                Temp_Time = value;
            }
        }
        public frmOtherCards()
        {
            InitializeComponent();
        }
        public frmOtherCards(int Matchid, int HalfId, int Raidno, double Time)
        {
            InitializeComponent();
            Temp_matchid = Matchid;
            Temp_halfid = HalfId;
            Temp_RaidNo = Raidno;
            Temp_Time = Time;
            rbTeamA.Text = CommonCls.Club1Prefix;
            rbTeamB.Text = CommonCls.Club2Prefix;
            TimeSpan span3 = TimeSpan.FromSeconds(Convert.ToInt32(Temp_Time));
            dtp_MatchClock.Value = DateTime.ParseExact(span3.ToString(@"mm\:ss"), "mm:ss", CultureInfo.InvariantCulture);
            BindGrid();
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Continue to Delete This Event", "Kabaddi Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (Result == DialogResult.Yes)
            {
                int AutoID = Convert.ToInt32(gvTimeout.Rows[gvTimeout.CurrentRow.Index].Cells["AutoID"].Value);
                if ((obj.ExeQueryRetBooDL("Delete from [Othercard] Where MatchId=" + Temp_matchid + " And AutoID=" + AutoID + "", 1)))
                {
                    try
                    {
                        int cnt = obj.ExeQueryStrDL("Select ISNULL(Count(Raidno),0)+1 From tblCorrectedRaid where Matchid=" + Temp_matchid + " And HalfID=" + Temp_halfid + " AND RaidNo=" + Temp_RaidNo + "", 1);
                        obj.ExeQueryRetBooDL("Insert into tblCorrectedRaid (Matchid,HalfID,Raidno,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + Temp_matchid + "," + Temp_halfid + "," + Temp_RaidNo + "," + cnt + ",'Othercard','" + System.DateTime.Now + "',0,0,1)", 1);
                    }
                    catch { }
                    BindGrid();
                }
            }
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Temp_Time = TimeSpan.Parse("00:" + dtp_MatchClock.Value.Minute.ToString("D2") + ":" + dtp_MatchClock.Value.Second.ToString("D2")).TotalSeconds;
            if (cbCardType.SelectedIndex == -1)
            {
                DialogResult Result = MessageBox.Show("Are you sure without update result ", "Kabaddi Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (Result == DialogResult.No)
                {
                    return;
                }
            }
            if (btnSubmit.Text == "ADD")
            {
                string aaa = string.Format("Insert into [Othercard](Matchid,HalfID,RaidNo,Time,TeamID,[Team/Coach],CardType) Values({0},{1},{2},{3},{4},{5},{6})",
                    Temp_matchid,
                    Temp_halfid, 
                    Temp_RaidNo, 
                    Temp_Time,
                    (rbTeamA.Checked ? CommonCls.ClubId1.ToString() : (rbTeamB.Checked ? CommonCls.ClubId2.ToString() : ("0"))),
                    (cbTeamorCoach.SelectedIndex + 1),
                     (cbCardType.SelectedValue));
                obj.ExeQueryRetBooDL(aaa, 1);
                try
                {
                    int cnt = obj.ExeQueryStrDL("Select ISNULL(Count(Raidno),0)+1 From tblCorrectedRaid where Matchid=" + Temp_matchid + " And HalfID=" + Temp_halfid + " AND RaidNo=" + Temp_RaidNo + "", 1);
                    obj.ExeQueryRetBooDL("Insert into tblCorrectedRaid (Matchid,HalfID,Raidno,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + Temp_matchid + "," + Temp_halfid + "," + Temp_RaidNo + "," + cnt + ",'Othercard','" + System.DateTime.Now + "',1,0,0)", 1);
                }
                catch { }
            }
            else
            {
                string aaa = string.Format("Update [Othercard] set Time={0},TeamID={1},CardType={2},[Team/Coach]={3} where AutoID={4}",
                     Temp_Time,
                    (rbTeamA.Checked ? CommonCls.ClubId1.ToString() : (rbTeamB.Checked ? CommonCls.ClubId2.ToString() : ("0"))),
                    (cbCardType.SelectedValue),
                     (cbTeamorCoach.SelectedIndex + 1),
                    CurCardAutoID);
                obj.ExeQueryRetBooDL(aaa, 1);
                try
                {
                    int cnt = obj.ExeQueryStrDL("Select ISNULL(Count(Raidno),0)+1 From tblCorrectedRaid where Matchid=" + Temp_matchid + " And HalfID=" + CurHalfID + " AND RaidNo=" + CurRaidno + "", 1);
                    obj.ExeQueryRetBooDL("Insert into tblCorrectedRaid (Matchid,HalfID,Raidno,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + Temp_matchid + "," + CurHalfID + "," + CurRaidno + "," + cnt + ",'Othercard','" + System.DateTime.Now + "',0,1,0)", 1);
                }
                catch { }
            }
            Clear();
        }
        void BindGrid()
        {
            Dt = new DataTable();
            Dt = obj.ExeQueryStrRetDTDL("Select AutoID,Matchid,HalfID,RaidNo,dbo.Fn_SecondsConversion(Time)Time,dbo.fn_GetTeamNameprefix(TeamID)TeamName,CASE when [Team/Coach]=1 then 'Team' when [Team/Coach]=2 then 'Coach' END TeamorCoach,dbo.fn_GetEventName(CardType) CardType from [Othercard] where Matchid=" + Temp_matchid + " order by halfID,Time", 1);
            gvTimeout.AutoGenerateColumns = false;
            gvTimeout.DataSource = Dt;
        }
        int CurCardAutoID = 0, CurHalfID = 0, CurRaidno = 0;
        private void gvTimeout_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CurCardAutoID = Convert.ToInt32(gvTimeout.CurrentRow.Cells["AutoID"].Value.ToString());
            GetStats();
        }
        void GetStats()
        {
            try
            {
                Dt = new DataTable();
                Dt = obj.ExeQueryStrRetDTDL("Select * from Othercard where Matchid=" + Temp_matchid + " and AutoID=" + CurCardAutoID + "", 1);
                if (Dt.Rows.Count > 0)
                {
                    btnSubmit.Text = "Update";
                    CurHalfID = Convert.ToInt16(Dt.Rows[0]["HalfID"].ToString());
                    CurRaidno = Convert.ToInt16(Dt.Rows[0]["Raidno"].ToString());
                    if (CommonCls.ClubId1 == Convert.ToInt16(Dt.Rows[0]["TeamID"].ToString()))
                        rbTeamA.Checked = true;
                    else
                        rbTeamB.Checked = true;
                    try
                    {
                        cbCardType.SelectedValue = Convert.ToInt16(Dt.Rows[0]["CardType"].ToString());
                    }
                    catch { }

                    cbTeamorCoach.SelectedIndex = Convert.ToInt16(Dt.Rows[0]["Team/Coach"].ToString()) - 1;
                    TimeSpan span3 = TimeSpan.FromSeconds(Convert.ToInt32(Dt.Rows[0]["Time"].ToString()));
                    dtp_MatchClock.Value = DateTime.ParseExact(span3.ToString(@"mm\:ss"), "mm:ss", CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex) { MessageBox.Show("error : " + ex.Message.ToString()); }
        }
        private void frmReview_Load(object sender, EventArgs e)
        {
            BindCard();
        }
        DataTable dt;
        void BindCard()
        {
            dt = new DataTable();
            dt = obj.ExeQueryStrRetDTDL("Select ID,dbo.fn_GetEventName(ID)Card From EventMaster Where ID IN(23,24,25)", 1);
            cbCardType.DataSource = dt;
            cbCardType.DisplayMember = "Card";
            cbCardType.ValueMember = "ID";
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        void Clear()
        {
            rbTeamA.Checked = false;
            rbTeamB.Checked = false;
            cbTeamorCoach.SelectedIndex = -1;
            cbCardType.SelectedIndex = -1;
            btnSubmit.Text = "ADD";
            BindGrid();
        }
    }
}
