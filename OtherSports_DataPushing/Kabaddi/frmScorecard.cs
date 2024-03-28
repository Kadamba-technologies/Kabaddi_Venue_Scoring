using OtherSports_DataPushing.Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OtherSports_DataPushing
{
    public partial class frmScorecard : Form
    {
        DataTable Dt, DTScore;
        DataSet Dset;
        int Temp_matchid;
        int ClubAID;
        int ClubBID;
        int Temp_HalfID;
        bool Pageload = false;
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
                return Temp_HalfID;
            }
            set
            {
                Temp_HalfID = value;
            }
        }

        public Int32 Score_ClubAID
        {
            get
            {
                return ClubAID;
            }
            set
            {
                ClubAID = value;
            }
        }


        public Int32 Score_ClubBID
        {
            get
            {
                return ClubBID;
            }
            set
            {
                ClubBID = value;
            }
        }


        MasterDL obj = new MasterDL();
        public frmScorecard()
        {
            InitializeComponent();
            LoadMatches();
        }
        public frmScorecard(int Mid,int ClubA,int ClubB)
        {
            InitializeComponent();
            LoadMatches();

            Pageload = true;
            cbMatches.SelectedValue = Mid ;
            ClubAID = ClubA;
            ClubBID = ClubB;
        }
        private void frmScorecard_Load(object sender, EventArgs e)
        {
          Pageload = true;
        }

        void LoadMatches()
        {
            obj = new MasterDL();
            Dt = new DataTable();
            Dt = obj.ExeQueryStrRetDTDL("Select Matchid,CAST(Matchid AS VARCHAR)+' - '+dbo.fn_GetMatchNamePreDate(Matchid)MatchName From KB_Matches Order by MatchID Desc", 1);
            cbMatches.DataSource = Dt;
            cbMatches.DisplayMember = "MatchName";
            cbMatches.ValueMember = "Matchid";
            cbMatches.SelectedIndex = -1;
        }

        void BindGrid()
        {
            Dset = new DataSet();
            Dset = obj.ExeQueryStrRetDsDL("Exec SP_GetFruitHome " + Temp_matchid + "", 1);
            if(Dset.Tables.Count>0)
            {
                dgvTeamscore.DataSource = Dset.Tables[0];
                dgvTeamA.DataSource = Dset.Tables[7];
                dgvTeamB.DataSource = Dset.Tables[8];
                lblTeamA.Text = Dset.Tables[9].Rows[0][0].ToString();
                lblTeamB.Text = Dset.Tables[9].Rows[0][1].ToString();
            }
        }
        void BindTeamScore()
        {
            DTScore = new DataTable();
            DTScore = obj.ExeQueryStrRetDTDL("SP_GetTeamScore " + Temp_matchid + "," + ClubAID + "," + ClubBID + "", 1);
            if (DTScore.Rows.Count > 0)
            {
                lblTeamAScore.Text = DTScore.Rows[0][0].ToString();
                lblTeamBScore.Text = DTScore.Rows[0][1].ToString();
            }
            lblResult.Text = obj.ExeQueryStrRetStrDL("Select dbo.fn_MatchResult(" + Temp_matchid + ")", 1);
        }

        private void cbMatches_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Pageload) return;
            Temp_matchid = Convert.ToInt32(cbMatches.SelectedValue);
            ClubAID = obj.ExeQueryStrDL("select TeamA from KB_Matches Where MAtchid=" + Temp_matchid + "", 1);
            ClubBID = obj.ExeQueryStrDL("select TeamB from KB_Matches Where MAtchid=" + Temp_matchid + "", 1);
            lblTeamANameGoal.Text = obj.ExeQueryStrRetStrDL("select dbo.fn_GetTeamNameprefix(" + ClubAID + ")", 1);
            lblTeamBNameGoal.Text = obj.ExeQueryStrRetStrDL("select dbo.fn_GetTeamNameprefix(" + ClubBID + ")", 1);
            
            BindGrid();
            BindTeamScore();
        }

    }
}
