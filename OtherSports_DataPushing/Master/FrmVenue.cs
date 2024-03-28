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
    public partial class FrmVenue : Form
    {
        BusinessLy objMB = new BusinessLy();
        int ID = 0, Gender = 0;
        DataTable DT;
        Boolean pageload = false;
        public FrmVenue()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                objMB = new BusinessLy();
                if (objMB.ExeQueryStrRetDTBL("Select * from Venue_Master Where Name like '%" + TxtName.Text.Trim() + "%'", 1).Rows.Count > 0 && btnSubmit.Text == "Submit")
                {
                    MessageBox.Show("This Venue Already Exists", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (btnSubmit.Text == "Submit")
                {
                    ID = objMB.ExeQueryStrIntBL("Select Isnull(Max(Id),0)+1 from Venue_Master", 1);

                    if (objMB.ExeQueryRetBooDL("Insert Into Venue_Master (Id,Name,City,Country,SportID)values(" + ID + ",'" + TxtName.Text.Trim() + "','" + TxtCity.Text.Trim() + "','" + txtCountry.Text.Trim() + "'," + mycommon.SportID + ")", 1))
                    {
                        MessageBox.Show("Insert Sucessfully", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        pageload = false;
                        Clear();
                    }
                }

                else if (btnSubmit.Text == "Update")
                {
                    if (objMB.ExeQueryRetBooDL("Update Venue_Master set Name='" + TxtName.Text.Trim() + "',City='" + TxtCity.Text.Trim() + "',Country='" + txtCountry.Text.Trim() + "' where Id=" + cbName.SelectedValue + "", 1))
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
            TxtName.Clear();
            txtCountry.Clear();
            TxtCity.Clear();
            cbName.SelectedIndex = -1;
            btnSubmit.Text = "Submit";
            btnEdit.Text = "Edit";
        }


        private void Venue_Load(object sender, EventArgs e)
        {
            bindVenue();
            pageload = true;
        }

        void bindVenue()
        {
            cbName.DataSource = objMB.ExeQueryStrRetDTBL("Select ID,Name from Venue_Master Where SportID="+mycommon.SportID, 1);
            cbName.DisplayMember = "Name";
            cbName.ValueMember = "ID";
            cbName.SelectedIndex = -1;
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
                    DT = objMB.ExeQueryStrRetDTBL("Select * from Venue_Master where ID=" + cbName.SelectedValue + "", 1);
                    if (DT.Rows.Count > 0)
                    {
                        TxtName.Text = DT.Rows[0]["Name"].ToString();
                        TxtCity.Text = DT.Rows[0]["City"].ToString();
                        txtCountry.Text = DT.Rows[0]["Country"].ToString();
                    }
                }
            }
            catch
            {

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "Edit")
            {
                bindVenue();
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
    }
}
