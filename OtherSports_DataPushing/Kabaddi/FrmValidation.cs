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
    public partial class FrmValidation : Form
    {
        bool Pageload = false;
        MasterDL ObjBl=new MasterDL();
        DataTable Dt;

        public FrmValidation()
        {
            InitializeComponent();
            LoadMatches("");
        }

        public FrmValidation(string MatID)
        {
            InitializeComponent();
            LoadMatches(MatID);
        }

        private void FrmValidation_Load(object sender, EventArgs e)
        {
            LoadMatches("");
        }

        void LoadMatches(string MID)
        {
            Pageload = false;
            ObjBl = new MasterDL();
            Dt = new DataTable();
            Dt = ObjBl.ExeQueryStrRetDTDL("Select Matchid,CAST(Matchid AS VARCHAR)+' - '+dbo.fn_GetMatchNamePreDate(Matchid)MatchName From KB_Matches Order by MatchID Desc", 1);
            cbMatches.DataSource = Dt;
            cbMatches.DisplayMember = "MatchName";
            cbMatches.ValueMember = "Matchid";
            if (MID != "")
                cbMatches.SelectedValue = MID;
            else
                cbMatches.SelectedIndex = -1;
            Pageload = true;
        }
        string strRaidTime = string.Empty;
        string strInplayer = string.Empty;
        private void cbMatches_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtValidation = new DataTable();
                dtValidation.Columns.Add("Head");
                dtValidation.Columns.Add("MatchID");
                dtValidation.Columns.Add("RaidNo");
                dtValidation.Columns.Add("Description");

                if (!Pageload) { return; }
                strRaidTime = string.Empty;
                strInplayer = string.Empty;
                //DataTable dtLocalValid = ObjBl.ExeQueryStrRetDTDL("SP_GetValidation " + cbMatches.SelectedValue + "", 1);
                //if (dtLocalValid.Rows.Count > 0)
                DataSet Dset = ObjBl.ExeQueryStrRetDsDL("SP_GetValidation " + cbMatches.SelectedValue + "", 1);
                if (Dset.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drMasters in Dset.Tables[0].Rows)
                    {
                        if (Convert.ToString(drMasters["Seconds"]) == "1")
                            strRaidTime = (strRaidTime == "" ? strRaidTime : strRaidTime + ",") + Convert.ToString(drMasters["RaidNo"]);
                    }
                }
                if (Dset.Tables[2].Rows.Count > 0)
                {
                    foreach (DataRow drMasters in Dset.Tables[2].Rows)
                    {
                        if (Convert.ToString(drMasters["Error"]) == "1")
                            strInplayer = (strInplayer == "" ? strInplayer : strInplayer + ",") + Convert.ToString(drMasters["RaidNo"]);
                    }
                }
                if (strRaidTime != string.Empty)
                    dtValidation.Rows.Add("Raid Time", cbMatches.SelectedValue.ToString(), strRaidTime, " Not correct");
                if (strInplayer != string.Empty)
                    dtValidation.Rows.Add("In Player", cbMatches.SelectedValue.ToString(), strInplayer, " Not given");
                if (Dset.Tables[3].Rows[0]["QCUpdate"].ToString() == "1")
                {
                    dtValidation.Rows.Add("Qc Changed", cbMatches.SelectedValue.ToString(), "", " Please Update DIP");
                }
                gvValidate.DataSource = dtValidation;

                Dt = new DataTable();
                Dt = ObjBl.ExeQueryStrRetDTDL("SP_GetDIPMinus1data " + cbMatches.SelectedValue + "", 1);
                dataGridView1.DataSource = Dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnDIPRecalculate_Click(object sender, EventArgs e)
        {
            if (cbMatches.SelectedIndex == -1) { MessageBox.Show("Select Match"); return; }

            if (ObjBl.ExeQueryRetBooDL("SP_UpdatePointDiff_Matchwise " + cbMatches.SelectedValue + "", 1))
            {
                MessageBox.Show("DIP Update Successfully");
                cbMatches_SelectedIndexChanged(sender, e);
            }
        }

        private void llblErrorGrid_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlError.Visible = true;
        }

        private void pbInplayerClose_Click(object sender, EventArgs e)
        {
            pnlError.Visible = false;
        }

        private void FrmValidation_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
