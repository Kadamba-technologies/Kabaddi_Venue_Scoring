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
    public partial class FrmCompetition : Form
    {
        BusinessLy objMB = new BusinessLy();
        int ID = 0;
        DataTable DT;
        Boolean pageload = false;
        public FrmCompetition()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "Edit")
            {
                bindCompetition();
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

        int gender = 0;
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                objMB = new BusinessLy();
                if (objMB.ExeQueryStrRetDTBL("Select * from Competition Where Name like '%" + TxtName.Text.Trim() + "%'", 1).Rows.Count > 0 && btnSubmit.Text == "Submit")
                {
                    MessageBox.Show("This Competition Already Exists", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if(rdmen.Checked)
                {
                    gender = 1;
                }
                else
                {
                    gender = 2;
                }
                if (btnSubmit.Text == "Submit")
                {
                    ID = objMB.ExeQueryStrIntBL("Select Isnull(Max(CompID),0)+1 from Competition", 1);

                    if (objMB.ExeQueryRetBooDL("Insert Into Competition (CompID,SportID,Name,Fromdate,Todate,Matchtype,gender)values(" + ID + "," + mycommon.SportID + ",'" + TxtName.Text.Trim() + "','" + DTPFrom.Value + "','" + DTPTo.Value + "'," + cbcompmatchtype.SelectedValue + ","+gender+")", 1))
                    {
                        MessageBox.Show("Insert Sucessfully", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        pageload = false;
                        Clear();
                    }
                }

                else if (btnSubmit.Text == "Update")
                {
                    if (objMB.ExeQueryRetBooDL("Update Competition set SportID=" + mycommon.SportID + ",Name='" + TxtName.Text.Trim() + "',Fromdate='" + DTPFrom.Value + "',Todate='" + DTPTo.Value + "',Matchtype=" + cbcompmatchtype.SelectedValue + ", Gender="+gender+" where CompID=" + cbName.SelectedValue + "", 1))
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
            cbName.SelectedIndex = -1;
            DTPFrom.Value = System.DateTime.Now;
            DTPTo.Value = System.DateTime.Now;
            cbcompmatchtype.SelectedIndex = -1;
            btnSubmit.Text = "Submit";
            btnEdit.Text = "Edit";
        }

        private void FrmCompetition_Load(object sender, EventArgs e)
        {
            DTPFrom.Value = System.DateTime.Now;
            DTPTo.Value = System.DateTime.Now;
            loadmatchtype();
            bindCompetition();
            pageload = true;
        }


        void loadmatchtype()
        {
            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            comboSource.Add(1, "Team-Wise");
            comboSource.Add(2, "Players-Wise");
            cbcompmatchtype.DataSource = new BindingSource(comboSource, null);
            cbcompmatchtype.DisplayMember = "Value";
            cbcompmatchtype.ValueMember = "Key";
        }

        void bindCompetition()
        {
            cbName.DataSource = objMB.ExeQueryStrRetDTBL("Select CompID ID,Name from competition Where SportID=" + mycommon.SportID + "", 1);
            cbName.DisplayMember = "Name";
            cbName.ValueMember = "ID";
            cbName.SelectedIndex = -1;
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
                    DT = objMB.ExeQueryStrRetDTBL("Select * from Competition where CompID=" + cbName.SelectedValue + "", 1);
                    if (DT.Rows.Count > 0)
                    {
                        TxtName.Text = DT.Rows[0]["Name"].ToString();
                        DTPFrom.Value = Convert.ToDateTime(DT.Rows[0]["Fromdate"]);
                        DTPTo.Value = Convert.ToDateTime(DT.Rows[0]["Todate"]);
                        cbcompmatchtype.SelectedValue =Convert.ToInt32(DT.Rows[0]["matchtype"].ToString());
                       string gen= Convert.ToString(DT.Rows[0]["gender"].ToString());
                        if(!string.IsNullOrEmpty(gen))
                        {
                            if(gen == "1")
                            {
                                rdmen.Checked = true;
                            }
                            else
                            {
                                rdwomen.Checked = true;
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }
    }
}
