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

namespace OtherSports_DataPushing.Kabaddi
{
    public partial class Manual_Capture : Form
    {
        BusinessLy objMB = new BusinessLy();
        DataTable dt;
        Boolean pageload = false;
        public Manual_Capture()
        {
            InitializeComponent();
        }

        private void Manual_Capture_Load(object sender, EventArgs e)
        {
            BindData();
            pageload = true;
        }
        void BindData()
        {
            cbCompetition.DataSource = objMB.ExeQueryStrRetDTBL("Select CompID ID,Name from Competition  Where SportID=" + mycommon.SportID + " ORDER BY CompID DESC", 1);
            cbCompetition.DisplayMember = "Name";
            cbCompetition.ValueMember = "ID";
            cbCompetition.SelectedIndex = -1;
        }

        private void cbCompetition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageload) { return; }
            bindMatches(" Where CompetitionID=" + cbCompetition.SelectedValue);
        }
        void bindMatches(string Filter)
        {
            pageload = false;
            cbMatches.DataSource = objMB.ExeQueryStrRetDTBL("Select MatchID,CAST(MatchID As Varchar)+' - '+dbo.fn_GetMatchNamePreDate_KB(MatchId)Name from KB_Matches " + Filter + " Order by MatchID desc", 1);
            cbMatches.DisplayMember = "Name";
            cbMatches.ValueMember = "MatchID";
            cbMatches.SelectedIndex = -1;
            pageload = true;
        }
        private void cbMatches_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageload) { return; }
            bindEvents();

        }


        private void cbRaid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageload) { return; }


        }
        void bindEvents()
        {
            pageload = false;
            dgRaids.DataSource = objMB.ExeQueryStrRetDTBL("EXEC Sp_getManualComments @matchid=" + cbMatches.SelectedValue + "", 1);
            this.dgRaids.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgRaids.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            pageload = true;
        }




        private void dgRaids_RowValidated(object sender, DataGridViewCellEventArgs data)
        {
            DataGridViewRow row = dgRaids.Rows[data.RowIndex];
           
            string RaidNo = (dgRaids.Rows[data.RowIndex].Cells[0].Value).ToString();
            string Comments = dgRaids.Rows[data.RowIndex].Cells[1].Value.ToString();

            string check_query = "SELECT COUNT(*) FROM ManualCapture WHERE Matchid=" + cbMatches.SelectedValue + " AND RaidNO=" + RaidNo + "";
            if (objMB.ExeQueryStrIntBL(check_query,1) > 0)
            {
                objMB.ExeQueryRetBooDL("UPDATE ManualCapture SET Comments='" + Comments + "' WHERE Matchid=" + cbMatches.SelectedValue + " AND RaidNO=" + RaidNo, 1);
            }
            else
            {
                objMB.ExeQueryRetBooDL("INSERT INTO ManualCapture(Matchid,RaidNo,Comments) VALUES (" + cbMatches.SelectedValue + "," + RaidNo + ",'" + Comments + "')", 1);
            }
            //Refresh();
        }

        void Refresh()
        {
            dgRaids.DataSource = objMB.ExeQueryStrRetDTBL("EXEC Sp_getManualComments @matchid=" + cbMatches.SelectedValue + "", 1);
        }
    }
}
