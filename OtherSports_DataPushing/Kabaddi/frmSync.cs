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
    public partial class frmSync : Form
    {

        SqlConnection conSyncTo = new SqlConnection(ConfigurationSettings.AppSettings["ConnectString"]);
        SqlConnection conSyncFrom = new SqlConnection(ConfigurationSettings.AppSettings["ConnectFrom"]);
        bool Pageload = false;
        MasterDL ObjBl=new MasterDL();
        DataTable Dt;

        public frmSync()
        {
            InitializeComponent();
        }

        private void frmSync_Load(object sender, EventArgs e)
        {
            LoadMatches();
        }

        void LoadMatches()
        {
            Pageload = false;
            ObjBl = new MasterDL();
            Dt = new DataTable();
            Dt = ObjBl.ExeQueryStrRetDTDL("Select Matchid,CAST(Matchid AS VARCHAR)+' - '+dbo.fn_GetMatchNamePreDate(Matchid)MatchName From KB_Matches where CompetitionID="+CommonCls.CompId+" Order by MatchID Desc", 1);
            cbMatches.DataSource = Dt;
            cbMatches.DisplayMember = "MatchName";
            cbMatches.ValueMember = "Matchid";
            cbMatches.SelectedIndex = -1;
            Pageload = true;
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Are you sync data from " + conSyncFrom.DataSource + " to " + conSyncTo.DataSource + ".", "Kabaddi Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (Result == DialogResult.Yes)
            {
                if (ObjBl.ExeQueryRetBooDL("SP_Kabaddi_Sync " + cbMatches.SelectedValue + ",'" + conSyncFrom.DataSource + "','" + conSyncTo.Database + "'", 1))
                    MessageBox.Show("Sync Successfully");
                else
                    MessageBox.Show("Sync Failed");
            }
        }
    }
}
