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
    public partial class frmCoachMaster : Form
    {
        BusinessLy objMB = new BusinessLy();
        int ID = 0, Gender = 0;
        DataTable DT;
        Boolean pageload = false;
        public frmCoachMaster()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "Edit")
            {
                bindCoach();
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
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                objMB = new BusinessLy();
                if (objMB.ExeQueryStrRetDTBL("Select * from CoachMaster Where SportID=" + mycommon.SportID + " AND Firstname +' '+Middlename+' '+Lastname like '" + TxtFirstName.Text.Trim() + " " + TxtMiddleName.Text.Trim() + " " + txtLastName.Text.Trim() + " " +"'", 1).Rows.Count > 0 && btnSubmit.Text == "Submit")
                {
                    MessageBox.Show("This Team Already Exists", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (btnSubmit.Text == "Submit")
                {
                    ID = objMB.ExeQueryStrIntBL("Select Isnull(Max(Id),0)+1 from CoachMaster", 1);

                    if (objMB.ExeQueryRetBooDL("Insert Into CoachMaster (Id,Firstname,Middlename,Lastname,Country,SportID)values(" + ID + ",'" + TxtFirstName.Text.Trim() + "','" + TxtMiddleName.Text.Trim() + "','" + txtLastName.Text.Trim() + "','" + txtCountry.Text.Trim() + "'," + mycommon.SportID + ")", 1))
                    {
                        MessageBox.Show("Insert Sucessfully", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        pageload = false;
                        Clear();
                    }
                }

                else if (btnSubmit.Text == "Update")
                {
                    if (objMB.ExeQueryRetBooDL("Update CoachMaster set Firstname='" + TxtFirstName.Text.Trim() + "',Middlename='" + TxtMiddleName.Text.Trim() + "',Lastname='" + txtLastName.Text.Trim() + "',Country='" + txtCountry.Text.Trim() + "' where Id=" + cbName.SelectedValue + " AND SportID=" + mycommon.SportID + "", 1))
                    {
                        MessageBox.Show("Insert Sucessfully", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                        btnSubmit.Text = "Submit";
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
            TxtFirstName.Clear();
            TxtMiddleName.Clear();
            txtLastName.Clear();
            txtCountry.Clear();
            cbName.SelectedIndex = -1;
            lblName.Visible = false;
            cbName.Visible = false;
            btnEdit.Text = "Edit";
            btnSubmit.Text = "Submit";
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
                    DT = objMB.ExeQueryStrRetDTBL("Select * from CoachMaster where Id=" + cbName.SelectedValue + "", 1);
                    if (DT.Rows.Count > 0)
                    {
                        TxtFirstName.Text = DT.Rows[0]["Firstname"].ToString();
                        TxtMiddleName.Text = DT.Rows[0]["Middlename"].ToString();
                        txtLastName.Text = DT.Rows[0]["Lastname"].ToString();
                        txtCountry.Text = DT.Rows[0]["Country"].ToString();
                    }
                }
            }
            catch
            {

            }
        }

        private void FrmTeam_Load(object sender, EventArgs e)
        {
            bindCoach();
            pageload = true;
        }
        void bindCoach()
        {
            cbName.DataSource = objMB.ExeQueryStrRetDTBL("Select ID,Firstname+' '+Middlename+' '+Lastname Name from CoachMaster", 1);
            cbName.DisplayMember = "Name";
            cbName.ValueMember = "ID";
            cbName.SelectedIndex = -1;
        }
    }
}
