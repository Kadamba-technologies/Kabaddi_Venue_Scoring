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
    public partial class FrmTeam : Form
    {
        BusinessLy objMB = new BusinessLy();
        int ID = 0, Gender = 0;
        DataTable DT;
        Boolean pageload = false;
        public FrmTeam()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "Edit")
            {
                
                bindTeam();
                Clear();
                lblName.Visible = true;
                cbName.Visible = true;
                btnEdit.Text = "New";
                pageload = true;
                cbName.SelectedIndex = -1;
            }
            else if (btnEdit.Text == "New")
            {
                lblName.Visible = false;
                cbName.Visible = false;
                btnEdit.Text = "Edit";
                btnSubmit.Text = "Submit";
                Clear();
                cbName.SelectedIndex = -1;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                objMB = new BusinessLy();
                if (objMB.ExeQueryStrRetDTBL("Select * from Team_Master Where SportID="+mycommon.SportID+" AND Name like '%" + TxtName.Text.Trim() + "%'", 1).Rows.Count > 0 && btnSubmit.Text == "Submit")
                {
                    MessageBox.Show("This Team Already Exists", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txt_refID.Text.Trim() == "")
                {
                    MessageBox.Show("Reference ID is must", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (btnSubmit.Text == "Submit")
                {
                    if (objMB.ExeQueryStrRetDTBL("Select * from Team_Master Where refTeam_id =" + txt_refID.Text.Trim() + "", 1).Rows.Count > 0)
                    {
                        MessageBox.Show("This Reference ID Already Exists", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    ID = objMB.ExeQueryStrIntBL("Select Isnull(Max(TeamId),0)+1 from Team_Master", 1);

                    if (objMB.ExeQueryRetBooDL("Insert Into Team_Master (TeamId,TeamName,Prefix,Country,SportID,[Group],refTeam_id)values(" + ID + ",'" + TxtName.Text.Trim() + "','" + TxtPrefix.Text.Trim() + "','" + txtCountry.Text.Trim() + "'," + mycommon.SportID + ",'" + (string.IsNullOrEmpty(cbgroups.Text) ? "" : cbgroups.Text) + "'," + txt_refID.Text.Trim() + ")", 1))
                    {
                        MessageBox.Show("Insert Sucessfully", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        pageload = false;
                        Clear();
                    }
                }

                else if (btnSubmit.Text == "Update")
                {
                    if (objMB.ExeQueryStrRetDTBL("Select * from Team_Master Where refTeam_id =" + txt_refID.Text.Trim() + " and TeamID!=" + cbName.SelectedValue + "", 1).Rows.Count > 0)
                    {
                        MessageBox.Show("This Reference ID Already Exists", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (objMB.ExeQueryRetBooDL("Update Team_Master set TeamName='" + TxtName.Text.Trim() + "',Prefix='" + TxtPrefix.Text.Trim() + "',Country='" + txtCountry.Text.Trim() + "',refTeam_id=" + txt_refID.Text.Trim() + " where TeamId=" + cbName.SelectedValue + " AND SportID=" + mycommon.SportID + " ", 1))
                    {
                        MessageBox.Show("Update Sucessfully", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                        btnSubmit.Text = "Submit";
                        lblName.Visible = false;
                        cbName.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Error Please Check It", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Error On DataBase", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        public void Clear()
        {
            TxtName.Clear();
            TxtPrefix.Clear();
            txtCountry.Clear();
            txt_refID.Clear();
            cbgroups.SelectedIndex = -1;
            cbName.SelectedIndex = -1;
            btnSubmit.Text = "Submit";
            btnEdit.Text = "Edit";
            chkRandomID.Checked = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void cbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!pageload) { return; }
                btnSubmit.Text = "Update";
                if (cbName.SelectedIndex != -1)
                {
                    DT = new DataTable();
                    DT = objMB.ExeQueryStrRetDTBL("Select * from Team_Master where TeamID=" + cbName.SelectedValue + "", 1);
                    if (DT.Rows.Count > 0)
                    {
                        TxtName.Text = DT.Rows[0]["TeamName"].ToString();
                        TxtPrefix.Text = DT.Rows[0]["Prefix"].ToString();
                        txtCountry.Text = DT.Rows[0]["Country"].ToString();
                        txt_refID.Text = DT.Rows[0]["refTeam_id"].ToString();
                        cbgroups.Text = Convert.ToString(DT.Rows[0]["Group"]);
                    }
                }
            }
            catch
            {

            }
        }

        private void FrmTeam_Load(object sender, EventArgs e)
        {
            bindTeam();
            pageload = true;
        }
        void bindTeam()
        {
            cbName.DataSource = objMB.ExeQueryStrRetDTBL("Select TeamID,TeamName from Team_Master", 1);
            cbName.DisplayMember = "TeamName";
            cbName.ValueMember = "TeamID";
            cbName.SelectedIndex = -1;
        }

        private void chkRandomID_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRandomID.Checked)
            {
                // txt_refID.Text = objMB.ExeQueryStrRetStrBL("Select 10000+Isnull(Max(Id),0)+1 from Player_Master ", 1);
                int refid = 0;
                for (int i = 1; i < 10000; i++)
                {
                    refid = objMB.ExeQueryStrIntBL("Select Isnull(Max(TeamId),0)+1 from Team_Master ", 1);
                    if (objMB.ExeQueryStrIntBL("Select Count(*) from Team_Master Where refTeam_id =" + refid + "", 1) <= 0)
                    {
                        txt_refID.Text = refid.ToString();
                        break;
                    }
                }
            }
            else
            {
                txt_refID.Clear();
            }
        }
    }
}
