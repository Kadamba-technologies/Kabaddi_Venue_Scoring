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
    public partial class frmTimeout : Form
    {
        DataTable Dt;
        MasterDL obj = new MasterDL();

        int Temp_matchid;
        int Temp_halfid;
        int Temp_RaidNo;
        double Temp_Time;
        int startoffset = 0;
        int TimerStart = 0;
        int TimerReverse = 0;
        Stopwatch mySW = new Stopwatch();
        DateTime Starttime;
        int clocksplit = 0;
        int CurTimeOutID = 0;
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
        public frmTimeout()
        {
            InitializeComponent();
        }
        public frmTimeout(int Matchid, int HalfId, int Raidno, double Time)
        {
            InitializeComponent();

         
               //DateTime.Now.ToString("HH:mm:ss tt");



            Temp_matchid = Matchid;
            Temp_halfid = HalfId;
            Temp_RaidNo = Raidno;
            Temp_Time = Time;
            rbTeamA.Text = CommonCls.Club1Prefix;
            rbTeamB.Text = CommonCls.Club2Prefix;
            BindGrid();
            
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Continue to Delete This Event", "Kabaddi Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (Result == DialogResult.Yes)
            {
                int AutoID = Convert.ToInt32(gvTimeout.Rows[gvTimeout.CurrentRow.Index].Cells["AutoID"].Value);
                if ((obj.ExeQueryRetBooDL("Delete from [Timeout] Where MatchId=" + Temp_matchid + " And AutoID=" + AutoID + "", 1)))
                {
                    try
                    {
                        int cnt = obj.ExeQueryStrDL("Select ISNULL(Count(Raidno),0)+1 From tblCorrectedRaid where Matchid=" + Temp_matchid + " And HalfID=" + Temp_halfid + " AND RaidNo=" + Temp_RaidNo + "", 1);
                        obj.ExeQueryRetBooDL("Insert into tblCorrectedRaid (Matchid,HalfID,Raidno,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + Temp_matchid + "," + Temp_halfid + "," + Temp_RaidNo + "," + cnt + ",'Timeout','" + System.DateTime.Now + "',0,0,1)", 1);
                    }
                    catch { }
                    BindGrid();
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string sys_time = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
            if (btnSubmit.Text == "TIMEOUT START")
            {
                
                double Temp_Time2 = TimeSpan.Parse("00:" + Clock2.Value.Minute.ToString("D2") + ":" + Clock2.Value.Second.ToString("D2")).TotalSeconds;
                string aaa = string.Format("Insert into [Timeout] (Matchid,HalfID,RaidNo,Time,TeamID,Duration,Type,System_Starttime) Values({0},{1},{2},{3},{4},{5},'{6}','{7}')",
                    Temp_matchid, Temp_halfid, Temp_RaidNo, Temp_Time,
                    (rbTeamA.Checked ? CommonCls.ClubId1.ToString() : (rbTeamB.Checked ? CommonCls.ClubId2.ToString() : ("0"))), Temp_Time2, rdtype, sys_time);
                obj.ExeQueryRetBooDL(aaa, 1);
                OnStartTimer();
                btnSubmit.Text = "TIMEOUT END";

                string qurey = string.Format("update kb_matches set [Match_currentstatus]='TIMEOUT' where Matchid='{0}'", Temp_matchid);
                obj.ExeQueryRetBooDL(qurey, 1);

                

            }
            else if (btnSubmit.Text == "UPDATE")
            {
                double Temp_Time2 = TimeSpan.Parse("00:" + Clock2.Value.Minute.ToString("D2") + ":" + Clock2.Value.Second.ToString("D2")).TotalSeconds;
                string q = "update [Timeout] set Duration ='" + Temp_Time2 + "',System_Endtime='" + sys_time + "' where autoid=" + CurTimeOutID + "";
                obj.ExeQueryRetBooDL(q, 1);
                stop();
                btnSubmit.Text = "TIMEOUT START";
                string qurey = string.Format("update kb_matches set [Match_currentstatus]='' where Matchid='{0}'", Temp_matchid);
                obj.ExeQueryRetBooDL(qurey, 1);
            }
            else
            {

                int autoid = obj.ExeQueryStrDL("SELECT max(autoid) FROM [Timeout] where matchid=" + Temp_matchid + "", 1);
                double Temp_Time2 = TimeSpan.Parse("00:" + Clock2.Value.Minute.ToString("D2") + ":" + Clock2.Value.Second.ToString("D2")).TotalSeconds;
                string q = "update [Timeout] set Duration ='" + Temp_Time2 + "',System_Endtime='" + sys_time + "' where autoid=" + autoid + "";
                obj.ExeQueryRetBooDL(q, 1);
                stop();
                btnSubmit.Text = "TIMEOUT START";
                string qurey = string.Format("update kb_matches set [Match_currentstatus]='' where Matchid='{0}'", Temp_matchid);
                obj.ExeQueryRetBooDL(qurey, 1);
            }
            

            try
            {
                int cnt = obj.ExeQueryStrDL("Select ISNULL(Count(Raidno),0)+1 From tblCorrectedRaid where Matchid=" + Temp_matchid + " And HalfID=" + Temp_halfid + " AND RaidNo=" + Temp_RaidNo + "", 1);
                obj.ExeQueryRetBooDL("Insert into tblCorrectedRaid (Matchid,HalfID,Raidno,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + Temp_matchid + "," + Temp_halfid + "," + Temp_RaidNo + "," + cnt + ",'Timeout','" + System.DateTime.Now + "',1,0,0)", 1);
            }
            catch { }
            BindGrid();
        }

        void BindGrid()
        {
            Dt = new DataTable();
            Dt = obj.ExeQueryStrRetDTDL("Select AutoID,Matchid,HalfID,RaidNo,dbo.Fn_SecondsConversion(Time)Time,dbo.fn_GetTeamNameprefix(TeamID)TeamName,Duration,Type from [Timeout] where Matchid=" + Temp_matchid + "", 1);
            gvTimeout.AutoGenerateColumns = false;
            gvTimeout.DataSource = Dt;
        }

        private void frmTimeout_Load(object sender, EventArgs e)
        {

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




            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OnStartTimer();
        }

        private void Timer_Clock_Tick_1(object sender, EventArgs e)
        {

            TimeSpan span3 = TimeSpan.FromSeconds(startoffset).Add(mySW.Elapsed);
            Clock2.Value = DateTime.ParseExact(span3.ToString(@"hh\:mm\:ss"), "hh:mm:ss", CultureInfo.InvariantCulture);
        }

        public void stop()
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


        private void btnpause_Click(object sender, EventArgs e)
        {
            TimerStart = 0;
            mySW.Stop();

            if (_timerRunning)// If the timer is already running
            {
                Timer_Clock.Stop();
                _timerRunning = false;
            }
        }

        private void btnstop_Click(object sender, EventArgs e)
        {
            btnSubmit.Text = "TIMEOUT START";

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
        string rdtype = string.Empty;
        private void rbTeamA_CheckedChanged(object sender, EventArgs e)
        {
             rdtype = (sender as RadioButton).Text;
        }

        private void gvTimeout_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CurTimeOutID = Convert.ToInt32(gvTimeout.CurrentRow.Cells["AutoID"].Value.ToString());
            GetStats();
        }
        void GetStats()
        {
            try
            {
                Dt = new DataTable();
                Dt = obj.ExeQueryStrRetDTDL("Select * from Timeout where Matchid=" + Temp_matchid + " and AutoID=" + CurTimeOutID + "", 1);
                if (Dt.Rows.Count > 0)
                {
                    
                    Temp_halfid = Convert.ToInt16(Dt.Rows[0]["HalfID"].ToString());
                    Temp_RaidNo = Convert.ToInt16(Dt.Rows[0]["Raidno"].ToString());
                    //if (CommonCls.ClubId1 == Convert.ToInt16(Dt.Rows[0]["TeamID"].ToString()))
                    //    rbTeamA.Checked = true;
                    //else
                    //    rbTeamB.Checked = true;
                   

                    TimeSpan span3 = TimeSpan.FromSeconds(Convert.ToInt32(Dt.Rows[0]["Duration"].ToString()));
                    Clock2.Value = DateTime.ParseExact(span3.ToString(@"mm\:ss"), "mm:ss", CultureInfo.InvariantCulture);
                    

                    btnSubmit.Text="UPDATE";
                    
                }
            }
            catch (Exception ex) { MessageBox.Show("error : " + ex.Message.ToString()); }
        }

    }
}
