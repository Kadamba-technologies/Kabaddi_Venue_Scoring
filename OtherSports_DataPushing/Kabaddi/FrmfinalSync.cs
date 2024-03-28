using OtherSports_DataPushing.Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtherSports_DataPushing.Kabaddi
{
    public partial class FrmfinalSync : Form
    {
        SqlConnection conSyncFrom = new SqlConnection(ConfigurationSettings.AppSettings["ConnectFrom"]);
        int interval = Convert.ToInt32(ConfigurationSettings.AppSettings["Interval"]);
        bool Pageload = false;
        MasterDL ObjBl = new MasterDL();
        DataTable Dt;
        Timer MyTimer = new Timer();
        public FrmfinalSync()
        {
            InitializeComponent();


            MyTimer.Interval = (interval); // 45 mins
            MyTimer.Tick += new EventHandler(Timer1_Tick);


            // Enable timer.  
            // timer1.Enabled = true;

            //Button1.Text = "Stop";
            //Button1.Click += new EventHandler(Button1_Click);  

        }

        private void cbMatches_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set to 1 second.  
            //timer1.Interval = 1000;
            //timer1.Tick += new EventHandler(Timer1_Tick);

            // Enable timer.  


            // Button1.Text = "Stop";
            // Button1.Click += new EventHandler(Button1_Click);  
        }

        private void Timer1_Tick(object Sender, EventArgs e)
        {
            // Set the caption to the current time.  
            //label1.Text = DateTime.Now.ToString();
            try
            {
                if (Convert.ToInt32(ObjBl.ExeQueryStrRetStrDL("SELECT ISNULL(QCUpdate,1) FROM Kabaddifinal..Matches WHERE Scoring_MatchID=" + cbMatches.SelectedValue, 1)) < 2)
                {
                    if (ObjBl.ExeQueryRetBooDL("exec Sp_Sync21_to_Final @Matchid=" + cbMatches.SelectedValue + "", 1))
                    {
                        label1.Text = "Success";
                    }
                    else
                    {
                        label1.Text = "Failed";
                    }
                }
                else
                {
                    label1.Text = "Match Already Locked";
                    MyTimer.Stop();
                }
            }
            catch (Exception ex)
            {
                label1.Text = ex.ToString();
            }

        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            MyTimer.Start();
        }

        void LoadMatches()
        {
            Pageload = false;

            Dt = new DataTable();
            Dt = ObjBl.ExeQueryStrRetDTDL("Select Matchid,CAST(Matchid AS VARCHAR)+' - '+dbo.fn_GetMatchNamePreDate(Matchid)MatchName From KB_Matches where CompetitionID=" + CommonCls.CompId + " Order by MatchID Desc", 1);
            cbMatches.DataSource = Dt;
            cbMatches.DisplayMember = "MatchName";
            cbMatches.ValueMember = "Matchid";
            cbMatches.SelectedIndex = -1;
            Pageload = true;
        }

        private void Stop_sync_Click(object sender, EventArgs e)
        {
            MyTimer.Stop();
            label1.Text = "Stoped";
        }

        private void FrmfinalSync_Load(object sender, EventArgs e)
        {
            LoadMatches();
        }


    }
}
