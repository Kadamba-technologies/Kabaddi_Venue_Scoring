using OtherSports_DataPushing.Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtherSports_DataPushing.Kabaddi
{
    public partial class frmReview : Form
    {
        DataTable Dt;
        MasterDL obj = new MasterDL();

        int Temp_matchid;
        int Temp_halfid;
        int Temp_RaidNo;
        double Temp_Time;
        int TimerStart = 0;
        int TimerReverse = 0;
        int startoffset = 0;
        Stopwatch mySW = new Stopwatch();
        DateTime Starttime;
        int clocksplit = 0;

        string System_Starttime = "";
        string System_Endtime = "";


        private bool _timerRunning = false;

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
        public frmReview()
        {
            InitializeComponent();
        }
        public frmReview(int Matchid, int HalfId, int Raidno, double Time)
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
                 if ((obj.ExeQueryRetBooDL("Delete from [Review] Where MatchId=" + Temp_matchid + " And AutoID=" + AutoID + "", 1)))
                 {
                     try
                     {
                         int cnt = obj.ExeQueryStrDL("Select ISNULL(Count(Raidno),0)+1 From tblCorrectedRaid where Matchid=" + Temp_matchid + " And HalfID=" + Temp_halfid + " AND RaidNo=" + Temp_RaidNo + "", 1);
                         obj.ExeQueryRetBooDL("Insert into tblCorrectedRaid (Matchid,HalfID,Raidno,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + Temp_matchid + "," + Temp_halfid + "," + Temp_RaidNo + "," + cnt + ",'Review','" + System.DateTime.Now + "',0,0,1)", 1);
                     }
                     catch { }
                     BindGrid();
                 }
             }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Temp_Time = TimeSpan.Parse("00:" + dtp_MatchClock.Value.Minute.ToString("D2") + ":" + dtp_MatchClock.Value.Second.ToString("D2")).TotalSeconds;
            double Temp_Time2 = TimeSpan.Parse("00:" + Clock2.Value.Minute.ToString("D2") + ":" + Clock2.Value.Second.ToString("D2")).TotalSeconds;
            if (cmbOutcome.SelectedIndex == -1)
            {
                DialogResult Result = MessageBox.Show("Are you sure without update result ", "Kabaddi Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (Result == DialogResult.No)
                {
                    return;
                }
            }
            if (btnSubmit.Text == "ADD")
            {
                string aaa = string.Format("Insert into [Review](Matchid,HalfID,RaidNo,Time,ReviewTeamID,Outcome,Duration,System_Starttime,System_Endtime) Values({0},{1},{2},{3},{4},{5},{6},'{7}','{8}')",
                    Temp_matchid,
                    Temp_halfid, 
                    Temp_RaidNo, 
                    Temp_Time,
                    (rbTeamA.Checked ? CommonCls.ClubId1.ToString() : (rbTeamB.Checked ? CommonCls.ClubId2.ToString() : ("0"))),
                    (cmbOutcome.SelectedIndex + 1), Temp_Time2, System_Starttime, System_Endtime);
                obj.ExeQueryRetBooDL(aaa, 1);
                try
                {
                    int cnt = obj.ExeQueryStrDL("Select ISNULL(Count(Raidno),0)+1 From tblCorrectedRaid where Matchid=" + Temp_matchid + " And HalfID=" + Temp_halfid + " AND RaidNo=" + Temp_RaidNo + "", 1);
                    obj.ExeQueryRetBooDL("Insert into tblCorrectedRaid (Matchid,HalfID,Raidno,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + Temp_matchid + "," + Temp_halfid + "," + Temp_RaidNo + "," + cnt + ",'Review','" + System.DateTime.Now + "',1,0,0)", 1);
                }
                catch { }
            }
            else
            {
                string aaa = string.Format("Update [Review] set Time={0},ReviewTeamID={1},Outcome={2},Duration='{4}',System_Starttime='{5}',System_Endtime='{6}' where AutoID={3}",
                     Temp_Time,
                    (rbTeamA.Checked ? CommonCls.ClubId1.ToString() : (rbTeamB.Checked ? CommonCls.ClubId2.ToString() : ("0"))), (cmbOutcome.SelectedIndex + 1), CurReviewID, Temp_Time2, System_Starttime, System_Endtime);
                obj.ExeQueryRetBooDL(aaa, 1);
                try
                {
                    int cnt = obj.ExeQueryStrDL("Select ISNULL(Count(Raidno),0)+1 From tblCorrectedRaid where Matchid=" + Temp_matchid + " And HalfID=" + CurHalfID + " AND RaidNo=" + CurRaidno + "", 1);
                    obj.ExeQueryRetBooDL("Insert into tblCorrectedRaid (Matchid,HalfID,Raidno,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + Temp_matchid + "," + CurHalfID + "," + CurRaidno + "," + cnt + ",'Review','" + System.DateTime.Now + "',0,1,0)", 1);
                }
                catch { }
                btnSubmit.Text = "ADD";
            }
            BindGrid();
        }

        void BindGrid()
        {
            Dt = new DataTable();
            Dt = obj.ExeQueryStrRetDTDL("Select AutoID,Matchid,HalfID,RaidNo,dbo.Fn_SecondsConversion(Time)Time,dbo.fn_GetTeamNameprefix(ReviewTeamID)TeamName,CASE when Outcome=1 then 'Success' when Outcome=2 then  'Fail' END Outcome,Duration from [Review] where Matchid=" + Temp_matchid + " order by halfID,Time", 1);
            gvTimeout.AutoGenerateColumns = false;
            gvTimeout.DataSource = Dt;
        }
        int CurReviewID = 0, CurHalfID = 0, CurRaidno = 0;
        private void gvTimeout_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CurReviewID = Convert.ToInt32(gvTimeout.CurrentRow.Cells["AutoID"].Value.ToString());
            GetStats();
        }
        void GetStats()
        {
            try
            {
                Dt = new DataTable();
                Dt = obj.ExeQueryStrRetDTDL("Select * from Review where Matchid=" + Temp_matchid + " and AutoID=" + CurReviewID + "", 1);
                if (Dt.Rows.Count > 0)
                {
                    btnSubmit.Text = "Update";
                    CurHalfID = Convert.ToInt16(Dt.Rows[0]["HalfID"].ToString());
                    CurRaidno = Convert.ToInt16(Dt.Rows[0]["Raidno"].ToString());
                    if (CommonCls.ClubId1 == Convert.ToInt16(Dt.Rows[0]["ReviewTeamID"].ToString()))
                        rbTeamA.Checked = true;
                    else
                        rbTeamB.Checked = true;
                    try
                    {
                        cmbOutcome.SelectedIndex = Convert.ToInt16(Dt.Rows[0]["outcome"].ToString()) - 1;
                    }
                    catch { }

                    TimeSpan span3 = TimeSpan.FromSeconds(Convert.ToInt32(Dt.Rows[0]["Time"].ToString()));
                    dtp_MatchClock.Value = DateTime.ParseExact(span3.ToString(@"mm\:ss"), "mm:ss", CultureInfo.InvariantCulture);

                    TimeSpan span4 = TimeSpan.FromSeconds(Convert.ToInt32(Dt.Rows[0]["Duration"].ToString()));
                    Clock2.Value = DateTime.ParseExact(span4.ToString(@"mm\:ss"), "mm:ss", CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex) { MessageBox.Show("error : " + ex.Message.ToString()); }
        }

        private void frmReview_Load(object sender, EventArgs e)
        {

        }

        private void Timer_Clock_Tick(object sender, EventArgs e)
        {

            TimeSpan span3 = TimeSpan.FromSeconds(startoffset).Add(mySW.Elapsed);
            Clock2.Value = DateTime.ParseExact(span3.ToString(@"hh\:mm\:ss"), "hh:mm:ss", CultureInfo.InvariantCulture);
        }

        private void OnStartTimer()
        {
            try
            {
                TimerStart = 1;
                DateTime clockcurrentTime = default(DateTime).Add(Convert.ToDateTime(Clock2.Value).TimeOfDay);
                startoffset = Convert.ToInt32(TimeSpan.FromTicks(clockcurrentTime.Ticks).TotalSeconds);
                mySW = new Stopwatch();
                TimeSpan span3 = TimeSpan.FromSeconds(startoffset).Add(mySW.Elapsed);
                Clock2.Value = DateTime.ParseExact(span3.ToString(@"hh\:mm\:ss"), "hh:mm:ss", CultureInfo.InvariantCulture);
                mySW.Start();
                Timer_Clock.Start();
                _timerRunning = true;
                Starttime = DateTime.Now;

                
                  System_Starttime = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
                




            }
            catch
            {

            }
        }

        private void btnplay_Click(object sender, EventArgs e)
        {
            OnStartTimer();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System_Endtime = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now); 
            TimerStart = 0;
            mySW.Stop();

            if (_timerRunning)// If the timer is already running
            {
                Timer_Clock.Stop();
                _timerRunning = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime LastTime = default(DateTime).Add(Convert.ToDateTime("00:00:00").TimeOfDay);
            startoffset = Convert.ToInt32(TimeSpan.FromTicks(LastTime.Ticks).TotalSeconds);
            mySW = new Stopwatch();

            TimeSpan span3 = TimeSpan.FromSeconds(startoffset).Add(mySW.Elapsed);
            Clock2.Value = DateTime.ParseExact(span3.ToString(@"mm\:ss"), "mm:ss", CultureInfo.InvariantCulture);

            TimerStart = 0;
            mySW.Stop();

            if (_timerRunning)// If the timer is already running
            {
                Timer_Clock.Stop();
                _timerRunning = false;
            }

        }

        private void gvTimeout_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
