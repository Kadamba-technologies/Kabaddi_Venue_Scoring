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
    public partial class frmMedalEntry : Form
    {
        BusinessLy objMB = new BusinessLy();
        int ID = 0;
        DataTable DT, Dt;
        Boolean pageload = false, LoadPlayer = false, LoadTeam = false;
        int UpdateID = 0;
        public frmMedalEntry()
        {
            InitializeComponent();
        }

        private void frmMedalEntry_Load(object sender, EventArgs e)
        {
            pageload = false;
            bindData();
            bindGrid();
            pageload = true;
        }

        void bindData()
        {
            cbSportName.DataSource = objMB.ExeQueryStrRetDTBL("select ID,Replace(UPPER(Name),'_',' ')Name from Sports_Master Where ID!=0", 1);
            cbSportName.DisplayMember = "Name";
            cbSportName.ValueMember = "ID";
            cbSportName.SelectedIndex = -1;

            cbEventMaster.DataSource = objMB.ExeQueryStrRetDTBL("Select ID,Name from AthleticEventMaster", 1);
            cbEventMaster.DisplayMember = "Name";
            cbEventMaster.ValueMember = "ID";
            cbEventMaster.SelectedIndex = -1;

            cbTeams.DataSource = objMB.ExeQueryStrRetDTBL("Select distinct TeamID,TeamName  Name from Team_Master Order by Name", 1);
            cbTeams.DisplayMember = "Name";
            cbTeams.ValueMember = "TeamID";
            cbTeams.SelectedIndex = -1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((!rdbGold.Checked && !rdbSilver.Checked && !rdbBronze.Checked)) { MessageBox.Show("Select Medal Type"); return; }
            if (cbEventMaster.SelectedIndex == -1 || cbTeams.SelectedIndex == -1) { MessageBox.Show("Select Eventmaster and Team"); return; }
            int MedalType = 0;
            if (rdbGold.Checked)
                MedalType = 1;
            else if (rdbSilver.Checked)
                MedalType = 2;
            else if (rdbBronze.Checked)
                MedalType = 3;

            if (btnSave.Text == "SAVE")
            {
                if (objMB.ExeQueryRetBooDL("Insert into MetalsTally(SportID,EventId,TeamID,PlayerID,MedalType,Gold,Silver,Bronze) values(" + cbSportName.SelectedValue + "," + cbEventMaster.SelectedValue + "," + cbTeams.SelectedValue + "," + (cbPlayerName.SelectedIndex == -1 ? "Null" : cbPlayerName.SelectedValue) + "," + MedalType + "," + (rdbGold.Checked ? 1 : 0) + "," + (rdbSilver.Checked ? 1 : 0) + "," + (rdbBronze.Checked ? 1 : 0) + ")", 1))
                { bindGrid(); clear(); }
                else
                { MessageBox.Show("Error on Medals Insert"); return; }
            }
            else
            {
                if (objMB.ExeQueryRetBooDL("Update MetalsTally set SportID=" + cbSportName.SelectedValue + ",EventId=" + cbEventMaster.SelectedValue + ",TeamID=" + cbTeams.SelectedValue + ",PlayerID=" + (cbPlayerName.SelectedIndex == -1 ? "Null" : cbPlayerName.SelectedValue) + ",MedalType=" + MedalType + ",Gold=" + (rdbGold.Checked ? 1 : 0) + ",Silver=" + (rdbSilver.Checked ? 1 : 0) + ",Bronze =" + (rdbBronze.Checked ? 1 : 0) + "", 1))
                { bindGrid(); clear(); }
                else
                { MessageBox.Show("Error on Medals Insert"); return; }
            }
        }

        void bindGrid()
        {
            DT = new DataTable();
            DT = objMB.ExeQueryStrRetDTBL("Select AutoId,dbo.fn_GetTeamName(MT.TeamID)Teamname,ISNULL(dbo.fn_GetPlayerFullName(MT.PlayerID),'')Playername,ev.Name EventName,MTM.Name MedalType from MetalsTally MT JOIN AthleticEventMaster Ev ON MT.EventId=EV.ID JOIN MedalTypeMaster MTM ON MTM.ID=MT.MedalType Order by AutoID desc", 1);
            dgvMedals.AutoGenerateColumns = false;
            dgvMedals.DataSource = DT;
        }

        void clear()
        {
            cbSportName.SelectedIndex = -1;
            cbEventMaster.SelectedIndex = -1;
            cbTeams.SelectedIndex = -1;
            cbPlayerName.SelectedIndex = -1;
            rdbGold.Checked = false;
            rdbSilver.Checked = false;
            rdbBronze.Checked = false;
            UpdateID = 0;
            btnSave.Text = "SAVE";
        }

        private void dgvMedals_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateID = Convert.ToInt32(dgvMedals.CurrentRow.Cells["AutoID"].Value.ToString());
            Dt = new DataTable();
            Dt = objMB.ExeQueryStrRetDTBL("Select * From MetalsTally where AutoID="+UpdateID+"", 1);
            if(Dt.Rows.Count>0)
            {
                cbSportName.SelectedValue = Convert.ToInt32(Dt.Rows[0]["SportID"].ToString());
                cbEventMaster.SelectedValue = Convert.ToInt32(Dt.Rows[0]["EventId"].ToString());
                cbTeams.SelectedValue = Convert.ToInt32(Dt.Rows[0]["TeamID"].ToString());
                try
                {
                    cbPlayerName.SelectedValue = Convert.ToInt32(Dt.Rows[0]["PlayerID"].ToString());
                }
                catch { cbPlayerName.SelectedIndex = -1; }

                int MedalType = Convert.ToInt32(Dt.Rows[0]["MedalType"].ToString());
                if (MedalType == 1)
                    rdbGold.Checked=true;
                else if (MedalType ==2)
                    rdbSilver.Checked = true;
                else if (MedalType ==3)
                    rdbBronze.Checked = true;
                btnSave.Text = "UPDATE";

            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmHome frm = new FrmHome();
            frm.Show();
            this.Hide();
        }

        private void frmMedalEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            Environment.Exit(-1);
        }

        private void cbTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageload) { return; }
            cbPlayerName.DataSource = objMB.ExeQueryStrRetDTBL("Select  ID,dbo.fn_GetPlayerFullName(ID)Name from Player_Master where TeamID="+cbTeams.SelectedValue+" Order by Name", 1);
            cbPlayerName.DisplayMember = "Name";
            cbPlayerName.ValueMember = "ID";
            cbPlayerName.SelectedIndex = -1;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
            bindGrid();
        }


    }
}
