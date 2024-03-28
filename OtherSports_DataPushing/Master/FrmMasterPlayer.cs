using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OtherSports_DataPushing.Layer;

namespace OtherSports_DataPushing
{
    public partial class FrmMasterPlayer : Form
    {
        BusinessLy objMB = new BusinessLy();
        string Query = "";
        int ID = 0, Gender = 0;
        DataTable DT;
        Boolean pageload = false;
        public FrmMasterPlayer()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (TxtID.Text != "")
            {
                cbPlayerName.SelectedValue = TxtID.Text;
            }
            try
            {
                objMB = new BusinessLy();
                if (objMB.ExeQueryStrRetDTBL("Select * from Player_Master Where FirstName like '%" + TxtFirstName.Text.Trim() + "%' and LastName like '%" + TxtLastName.Text.Trim() + "%'", 1).Rows.Count > 0 && btnSubmit.Text == "Submit")
                {
                    // MessageBox.Show("This Player Already Exists", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (MessageBox.Show("This Player Already Exists. Do you want to continue to Create as new Player", "BadMinton Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                        return;
                }
                if (cbTeamName.SelectedIndex != -1)
                {
                    //MessageBox.Show("Select Team"); return;


                    if (rbtnMen.Checked)
                        Gender = 1;
                    else if (rbtnWomen.Checked)
                        Gender = 2;
                    else
                        Gender = 0;
                    string strTeamPrefix = objMB.ExeQueryStrRetStrBL("Select dbo.fn_GetTeamNameprefix(" + cbTeamName.SelectedValue + ")", 1);
                    if (btnSubmit.Text == "Submit")
                    {

                        if (objMB.ExeQueryStrRetDTBL("Select * from Player_Master Where RefPlayer_id =" + txt_refID.Text.Trim() + "", 1).Rows.Count > 0)
                        {
                            MessageBox.Show("This Reference ID Already Exists", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        ID = objMB.ExeQueryStrIntBL("Select Isnull(Max(Id),0)+1 from Player_Master", 1);

                        if (objMB.ExeQueryRetBooDL("Insert Into Player_Master (Id,FirstName,MiddleName,LastName,DOB,Gender,SportID,TeamID,PickNo,Role,RefPlayer_id,NickName,Mashal_Player_id)values(" + ID + ",'" + TxtFirstName.Text.Trim() + "','" + txtMiddleName.Text.Trim() + "','" + TxtLastName.Text.Trim() + "',case when '" + chkDOBNull.Checked + "'='true' then Null else'" + DTPDOB.Value.ToString() + "' END ," + Gender + "," + mycommon.SportID + "," + cbTeamName.SelectedValue + "," + txtPickNo.Text.Trim() + ",'" + cbRole.Text + "'," + (txt_refID.Text == "" ? "NUll" : txt_refID.Text) + ",'" + txtNickName.Text + "','" + txtmarshal.Text + "')", 1))
                        {
                            // if (objMB.ExeQueryStrRetDTBL("Select * from Player_Broadcast_Master Where playerid =" + cbPlayerName.SelectedValue + "", 1).Rows.Count > 0)
                            if (objMB.ExeQueryStrRetDTBL("Select * from Player_Broadcast_Master Where playerid =" + ID + "", 1).Rows.Count > 0)
                            {
                                if (objMB.ExeQueryRetBooDL("Update Player_Broadcast_Master set  Compid=" + cbCompetition.SelectedValue + ",TeamName='" + cbTeamName.Text + "',TeamShort='" + strTeamPrefix + "',RefPlayerid=" + txt_refID.Text + ",Player_FullName='" + (TxtFirstName.Text + " " + txtMiddleName.Text + " " + TxtLastName.Text).Replace("  ", " ") + "' ,Player_BroadcastName='" + txtBroadcastName.Text.Trim() + "',Role_id=" + cbRole.SelectedValue + ",[Playing Position]='" + cbRole.Text + "' where playerid=" + cbPlayerName.SelectedValue + "", 1))
                                {

                                }
                                else
                                    MessageBox.Show("Update Failed in Player_Broadcast_Master", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            else
                            {
                                if (objMB.ExeQueryRetBooDL("Insert into Player_Broadcast_Master(Compid,TeamName,TeamShort,playerid,RefPlayerid,Player_FullName,Player_BroadcastName,Role_id,[Playing Position]) values(" + cbCompetition.SelectedValue + ",'" + cbTeamName.Text + "','" + strTeamPrefix + "'," + ID + "," + (txt_refID.Text == "" ? "Null" : txt_refID.Text) + ",'" + (TxtFirstName.Text + " " + txtMiddleName.Text + " " + TxtLastName.Text).Replace("  ", " ") + "' ,'" + txtBroadcastName.Text.Trim() + "'," + (cbRole.SelectedValue == null ? "Null" : cbRole.SelectedValue) + ",'" + cbRole.Text + "')", 1))
                                {
                                }
                                else
                                    MessageBox.Show("Update Failed in Player_Broadcast_Master", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            MessageBox.Show("Insert Sucessfully", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            pageload = false;
                            Clear();
                        }
                    }
                    else if (btnSubmit.Text == "Update")
                    {
                        if (objMB.ExeQueryStrRetDTBL("Select * from Player_Master Where RefPlayer_id =" + txt_refID.Text.Trim() + " and ID!=" + cbPlayerName.SelectedValue + "", 1).Rows.Count > 0)
                        {
                            MessageBox.Show("This Reference ID Already Exists", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (objMB.ExeQueryRetBooDL("Update Player_Master set FirstName='" + TxtFirstName.Text.Trim() + "',MiddleName='" + txtMiddleName.Text.Trim() + "',LastName='" + TxtLastName.Text.Trim() + "',DOB=case when '" + chkDOBNull.Checked + "'='true' then Null else'" + DTPDOB.Value.ToString() + "' End,Gender=" + Gender + ",TeamID=" + cbTeamName.SelectedValue + ",PickNo=" + (txtPickNo.Text == "" ? "Null" : txtPickNo.Text.Trim()) + ",Mashal_Player_id=" + (txtmarshal.Text == "" ? "Null" : txtmarshal.Text.Trim()) + ",Role='" + cbRole.Text + "',RefPlayer_id=" + (txt_refID.Text == "" ? "NUll" : txt_refID.Text) + ",NickName='" + txtNickName.Text + "' where Id=" + cbPlayerName.SelectedValue + "", 1))
                        {
                            if (objMB.ExeQueryStrRetDTBL("Select * from Player_Broadcast_Master Where playerid =" + cbPlayerName.SelectedValue + "", 1).Rows.Count > 0)
                            {
                                if (objMB.ExeQueryRetBooDL("Update Player_Broadcast_Master set  Compid=" + cbCompetition.SelectedValue + ",TeamName='" + cbTeamName.Text + "',TeamShort='" + strTeamPrefix + "',RefPlayerid=" + (txt_refID.Text == "" ? "Null" : txt_refID.Text) + ",Player_FullName='" + (TxtFirstName.Text + " " + txtMiddleName.Text + " " + TxtLastName.Text).Replace("  ", " ") + "' ,Player_BroadcastName='" + txtBroadcastName.Text.Trim() + "',Role_id=" + cbRole.SelectedValue + ",[Playing Position]='" + cbRole.Text + "' where playerid=" + cbPlayerName.SelectedValue + "", 1))
                                {

                                }
                                else
                                    MessageBox.Show("Update Failed in Player_Broadcast_Master", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                if (objMB.ExeQueryRetBooDL("Insert into Player_Broadcast_Master(Compid,TeamName,TeamShort,playerid,RefPlayerid,Player_FullName,Player_BroadcastName,Role_id,[Playing Position]) values(" + cbCompetition.SelectedValue + ",'" + cbTeamName.Text + "','" + strTeamPrefix + "'," + cbPlayerName.SelectedValue + "," + (txt_refID.Text == "" ? "Null" : txt_refID.Text) + ",'" + (TxtFirstName.Text + " " + txtMiddleName.Text + " " + TxtLastName.Text).Replace("  ", " ") + "' ,'" + txtBroadcastName.Text.Trim() + "'," + cbRole.SelectedValue + ",'" + cbRole.Text + "')", 1))
                                {
                                }
                                else
                                    MessageBox.Show("Update Failed in Player_Broadcast_Master", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

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
                else
                {
                    
                    if (rbtnMen.Checked)
                        Gender = 1;
                    else if (rbtnWomen.Checked)
                        Gender = 2;
                    else
                        Gender = 0;
                    string strTeamPrefix = " ";
                    if (btnSubmit.Text == "Submit")
                    {

                        if (objMB.ExeQueryStrRetDTBL("Select * from Player_Master Where RefPlayer_id =" + txt_refID.Text.Trim() + "", 1).Rows.Count > 0)
                        {
                            MessageBox.Show("This Reference ID Already Exists", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        ID = objMB.ExeQueryStrIntBL("Select Isnull(Max(Id),0)+1 from Player_Master", 1);

                        if (objMB.ExeQueryRetBooDL("Insert Into Player_Master (Id,FirstName,MiddleName,LastName,DOB,Gender,SportID,PickNo,Role,RefPlayer_id,NickName,Mashal_Player_id)values(" + ID + ",'" + TxtFirstName.Text.Trim() + "','" + txtMiddleName.Text.Trim() + "','" + TxtLastName.Text.Trim() + "',case when '" + chkDOBNull.Checked + "'='true' then Null else'" + DTPDOB.Value.ToString() + "' END ," + Gender + "," + mycommon.SportID + "," + txtPickNo.Text.Trim() + ",'" + cbRole.Text + "'," + (txt_refID.Text == "" ? "NUll" : txt_refID.Text) + ",'" + txtNickName.Text + "','" + txtmarshal.Text + "')", 1))
                        {
                            // if (objMB.ExeQueryStrRetDTBL("Select * from Player_Broadcast_Master Where playerid =" + cbPlayerName.SelectedValue + "", 1).Rows.Count > 0)
                            if (objMB.ExeQueryStrRetDTBL("Select * from Player_Broadcast_Master Where playerid =" + ID + "", 1).Rows.Count > 0)
                            {
                                if (objMB.ExeQueryRetBooDL("Update Player_Broadcast_Master set  Compid=" + cbCompetition.SelectedValue + ",TeamName='" + cbTeamName.Text + "',TeamShort='" + strTeamPrefix + "',RefPlayerid=" + txt_refID.Text + ",Player_FullName='" + (TxtFirstName.Text + " " + txtMiddleName.Text + " " + TxtLastName.Text).Replace("  ", " ") + "' ,Player_BroadcastName='" + txtBroadcastName.Text.Trim() + "',Role_id=" + cbRole.SelectedValue + ",[Playing Position]='" + cbRole.Text + "' where playerid=" + cbPlayerName.SelectedValue + "", 1))
                                {

                                }
                                else
                                    MessageBox.Show("Update Failed in Player_Broadcast_Master", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            else
                            {
                                if (objMB.ExeQueryRetBooDL("Insert into Player_Broadcast_Master(Compid,TeamName,TeamShort,playerid,RefPlayerid,Player_FullName,Player_BroadcastName,Role_id,[Playing Position]) values(" + cbCompetition.SelectedValue + ",'" + cbTeamName.Text + "','" + strTeamPrefix + "'," + ID + "," + (txt_refID.Text == "" ? "Null" : txt_refID.Text) + ",'" + (TxtFirstName.Text + " " + txtMiddleName.Text + " " + TxtLastName.Text).Replace("  ", " ") + "' ,'" + txtBroadcastName.Text.Trim() + "'," + (cbRole.SelectedValue == null ? "Null" : cbRole.SelectedValue) + ",'" + cbRole.Text + "')", 1))
                                {
                                }
                                else
                                    MessageBox.Show("Update Failed in Player_Broadcast_Master", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            MessageBox.Show("Insert Sucessfully", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            pageload = false;
                            Clear();
                        }
                    }
                    else if (btnSubmit.Text == "Update")
                    {
                        if (objMB.ExeQueryStrRetDTBL("Select * from Player_Master Where RefPlayer_id =" + txt_refID.Text.Trim() + " and ID!=" + cbPlayerName.SelectedValue + "", 1).Rows.Count > 0)
                        {
                            MessageBox.Show("This Reference ID Already Exists", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (objMB.ExeQueryRetBooDL("Update Player_Master set FirstName='" + TxtFirstName.Text.Trim() + "',MiddleName='" + txtMiddleName.Text.Trim() + "',LastName='" + TxtLastName.Text.Trim() + "',DOB=case when '" + chkDOBNull.Checked + "'='true' then Null else'" + DTPDOB.Value.ToString() + "' End,Gender=" + Gender + ",PickNo=" + (txtPickNo.Text == "" ? "Null" : txtPickNo.Text.Trim()) + ",Mashal_Player_id=" + (txtmarshal.Text == "" ? "Null" : txtmarshal.Text.Trim()) + ",Role='" + cbRole.Text + "',RefPlayer_id=" + (txt_refID.Text == "" ? "NUll" : txt_refID.Text) + ",NickName='" + txtNickName.Text + "' where Id=" + cbPlayerName.SelectedValue + "", 1))
                        {
                            if (objMB.ExeQueryStrRetDTBL("Select * from Player_Broadcast_Master Where playerid =" + cbPlayerName.SelectedValue + "", 1).Rows.Count > 0)
                            {
                                if (objMB.ExeQueryRetBooDL("Update Player_Broadcast_Master set  Compid=" + cbCompetition.SelectedValue + ",RefPlayerid=" + (txt_refID.Text == "" ? "Null" : txt_refID.Text) + ",Player_FullName='" + (TxtFirstName.Text + " " + txtMiddleName.Text + " " + TxtLastName.Text).Replace("  ", " ") + "' ,Player_BroadcastName='" + txtBroadcastName.Text.Trim() + "',Role_id=" + cbRole.SelectedValue + ",[Playing Position]='" + cbRole.Text + "' where playerid=" + cbPlayerName.SelectedValue + "", 1))
                                {

                                }
                                else
                                    MessageBox.Show("Update Failed in Player_Broadcast_Master", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                if (objMB.ExeQueryRetBooDL("Insert into Player_Broadcast_Master(Compid,TeamName,TeamShort,playerid,RefPlayerid,Player_FullName,Player_BroadcastName,Role_id,[Playing Position]) values(" + cbCompetition.SelectedValue + ",'" + cbTeamName.Text + "','" + strTeamPrefix + "'," + cbPlayerName.SelectedValue + "," + (txt_refID.Text == "" ? "Null" : txt_refID.Text) + ",'" + (TxtFirstName.Text + " " + txtMiddleName.Text + " " + TxtLastName.Text).Replace("  ", " ") + "' ,'" + txtBroadcastName.Text.Trim() + "'," + cbRole.SelectedValue + ",'" + cbRole.Text + "')", 1))
                                {
                                }
                                else
                                    MessageBox.Show("Update Failed in Player_Broadcast_Master", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

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
            }
            catch
            {
                MessageBox.Show("Error On DataBase", "Sports Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "Edit")
            {
                cbPlayerName.SelectedIndex = -1;
                bindPlayer();
                lblPlayerName.Visible = true;
                //cbPlayerName.Visible = true;
                TxtSearch.Visible = true;
                TxtID.Visible = true;
                btnEdit.Text = "New";
                pageload = true;
            }
            else if (btnEdit.Text == "New")
            {

                Clear();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            pageload = false;
            TxtFirstName.Clear();
            txtMiddleName.Clear();
            TxtLastName.Clear();
            cbPlayerName.SelectedIndex = -1;
            cbTeamName.SelectedIndex = -1;
            txtPickNo.Text = "0";
            DTPDOB.Value = System.DateTime.Now;
            chkRandomID.Checked = false;
            cbRole.SelectedIndex = -1;
            txt_refID.Clear();
            txtBroadcastName.Clear();
            txtNickName.Clear();
            chkDOBNull.Checked = true;
            // btnEdit.PerformClick();
            //btnSubmit.Text = "Submit";
            //btnEdit.Text = "Edit";
            lblPlayerName.Visible = false;
            cbPlayerName.Visible = false;
            TxtSearch.Visible = false;
            TxtID.Visible = false;
            btnEdit.Text = "Edit";
            btnSubmit.Text = "Submit";
            bindPlayer();
            pageload = true;
            cbCompetition.SelectedValue = CommonCls.CompId;
        }

        private void FrmMasterPlayer_Load(object sender, EventArgs e)
        {
            DTPDOB.Value = System.DateTime.Now;
            bindPlayer();
            bindTeam();
            pageload = true;
        }

        void bindTeam()
        {
            cbCompetition.DataSource = objMB.ExeQueryStrRetDTBL("Select CompID ID,Name from Competition  Where SportID=" + mycommon.SportID + "", 1);
            cbCompetition.DisplayMember = "Name";
            cbCompetition.ValueMember = "ID";
            cbCompetition.SelectedValue = CommonCls.CompId;


            cbTeamName.DataSource = objMB.ExeQueryStrRetDTBL("SELECT * FROM Team_Master WHERE TeamID IN (37,40,45,54,57,61,71,95) ", 1);
            cbTeamName.DisplayMember = "TeamName";
            cbTeamName.ValueMember = "TeamID";
            cbTeamName.SelectedIndex = -1;


            cbRole.DataSource = objMB.ExeQueryStrRetDTBL("SELECT 1 ID,'Raider'Role UNION All SELECT 2 ID,'Defender' UNION All SELECT 3 ID,'All-Rounder' order by id desc ", 1);
            cbRole.DisplayMember = "Role";
            cbRole.ValueMember = "ID";
            cbRole.SelectedIndex = -1;
        }

        void bindPlayer()
        {
            if (!pageload) { return; }
            try
            {
                cbPlayerName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cbPlayerName.AutoCompleteSource = AutoCompleteSource.ListItems;

                this.cbPlayerName.SelectedIndexChanged -= new EventHandler(cbPlayerName_SelectedIndexChanged);

                cbPlayerName.SelectedIndex = -1;
                cbPlayerName.DataSource = objMB.ExeQueryStrRetDTBL("Select ID,ISNULL(DisplayName, Isnull(FirstName,'') + ' ' + Isnull(LastName,'')) Name from Player_Master", 1);
                cbPlayerName.DisplayMember = "Name";
                cbPlayerName.ValueMember = "ID";
                cbPlayerName.SelectedIndex = -1;

                //cbPlayerName.AutoCompleteMode = AutoCompleteMode.Suggest;
                //cbPlayerName.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cbPlayerName.SelectedIndexChanged += new EventHandler(cbPlayerName_SelectedIndexChanged);
            }
            catch { }
        }


        public void cbPlayerName_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbPlayerName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtMiddleName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPickNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbTeamName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DTPDOB_ValueChanged(object sender, EventArgs e)
        {
            chkDOBNull.Checked = false;
        }

        private void TxtLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkRandomID_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRandomID.Checked)
            {
                // txt_refID.Text = objMB.ExeQueryStrRetStrBL("Select 10000+Isnull(Max(Id),0)+1 from Player_Master ", 1);
                int refid = 0;
                for (int i = 1; i < 10000; i++)
                {
                    refid = objMB.ExeQueryStrIntBL("Select 10000+Isnull(Max(Id),0)+" + i + " from Player_Master ", 1);
                    if (objMB.ExeQueryStrIntBL("Select Count(*) from Player_Master Where RefPlayer_id =" + refid + "", 1) <= 0)
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

        private void lblPlayerID_Click(object sender, EventArgs e)
        {

        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var Dt = new DataTable();
                if (TxtSearch.Text != "")
                    Dt = objMB.ExeQueryStrRetDTBL("Select ID,isnull(Firstname,'')+' '+ isnull(LastName,'') Name from Player_Master where isnull(Firstname,'')+' '+ isnull(LastName,'') like '%" + TxtSearch.Text + "%'  order by name", 1);
                //Dt = ObjMB.ExeQueryStrRetDTBL("Select id,(firstname+' '+lastname) as name  from player Where (firstname+' '+lastname+','+Nationality) like '%" + TxtFirstName.Text + "%'");

                else
                    Dt = objMB.ExeQueryStrRetDTBL("Select ID,isnull(Firstname,'')+' '+ isnull(LastName,'') Name  from Player_Master order by name", 1);

                listBox1.DataSource = Dt;
                listBox1.DisplayMember = "name";
                listBox1.ValueMember = "ID";
                listBox1.Visible = true;
                listBox1.BringToFront();
                if (Dt.Rows.Count > 0)
                {
                    btnClear.Text = "Clear";
                }
                else
                {
                    listBox1.Visible = false;
                    //string result = msg.ShowBox("Player Not Found");
                    //if (result.Equals("Add"))
                    //{
                    //    TxtSearch.Enabled = false;
                    //    groupBox1.Enabled = true;
                    //    TxtFirstName.Focus();
                    //    listBox1.Visible = false;
                    //    ClearFrm();
                    //    CmdSave.Enabled = true;
                    //    ChkBowler.Checked = true;
                    //    MessageBox.Show("Please In Search Cricket21 Player also");
                    //}
                    //if (result.Equals("Quit"))
                    //{
                    //    TxtSearch.Focus();
                    //    listBox1.Visible = false;
                    //    MessageBox.Show("Please In Search Cricket21 Player also");
                    //}
                }
            }
            catch
            {

            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtID.Text = listBox1.SelectedValue.ToString();
            //listBox1.Focus();

            listBox1.Visible = false;
            //string result = msg.ShowBox("Player  Found", "View");

            //if (result.Equals("Add"))
            //{
            //    groupBox1.Enabled = true;
            //    TxtSearch.Focus();

            //}
            //if (result.Equals("Quit"))
            //{
            //    TxtSearch.Focus();
            //}
            //listBox1.Visible = false;
          //  btnClear.Text = "Update";
            btnClear.Enabled = true;

            try
            {
                //if (!pageload) { return; }
                btnSubmit.Text = "Update";
                //if (cbPlayerName.SelectedIndex != -1)
                {
                    DT = new DataTable();
                    DT = objMB.ExeQueryStrRetDTBL("Select *,CASE WHEN Role IN('Role') THEN 1 WHEN Role IN('Defender') THEN 2 WHEN Role IN('All Rounder','AllRounder','All-Rounder') THEN 3 else 3 END RoleID from Player_Master where ID=" + listBox1.SelectedValue + "", 1);
                    if (DT.Rows.Count > 0)
                    {
                        TxtFirstName.Text = DT.Rows[0]["FirstName"].ToString();
                        txtMiddleName.Text = DT.Rows[0]["MiddleName"].ToString();
                        TxtLastName.Text = DT.Rows[0]["LastName"].ToString();
                        txtPickNo.Text = DT.Rows[0]["PickNo"].ToString();
                        txtNickName.Text = DT.Rows[0]["NickName"].ToString();
                        try
                        {
                            cbTeamName.SelectedValue = Convert.ToInt32(DT.Rows[0]["TeamID"].ToString());
                        }
                        catch { }
                        try
                        {
                            DTPDOB.Value = Convert.ToDateTime(DT.Rows[0]["DOB"]);
                            chkDOBNull.Checked = false;
                        }
                        catch { chkDOBNull.Checked = true; }

                        if (DT.Rows[0]["Gender"].ToString() == "1")
                        {
                            rbtnMen.Checked = true;
                        }
                        else if (DT.Rows[0]["Gender"].ToString() == "2")
                        {
                            rbtnWomen.Checked = true;
                        }
                        try
                        {
                            txtmarshal.Text = Convert.ToString(DT.Rows[0]["Mashal_Player_id"].ToString());
                        }
                        catch
                        {

                        }
                        try
                        {
                            txt_refID.Text = DT.Rows[0]["RefPlayer_id"].ToString();
                        }
                        catch { }
                        try
                        {
                            cbRole.SelectedValue = DT.Rows[0]["RoleID"].ToString();
                        }
                        catch { }
                        try
                        {
                            DT = objMB.ExeQueryStrRetDTBL("Select * from Player_Broadcast_Master where playerid=" + cbPlayerName.SelectedValue + "", 1);
                            if (DT.Rows.Count == 1)
                            {
                                try
                                {
                                    txt_refID.Text = DT.Rows[0]["RefPlayerid"].ToString();
                                }
                                catch { }
                                txtBroadcastName.Text = DT.Rows[0]["Player_BroadcastName"].ToString();
                                try
                                {
                                    cbRole.SelectedValue = DT.Rows[0]["Role_id"].ToString();
                                }
                                catch { }
                                try
                                {
                                    cbTeamName.Text = DT.Rows[0]["TeamName"].ToString();
                                }
                                catch { }

                            }
                            else
                            {
                                txt_refID.Text = "";
                                txtBroadcastName.Text = "";
                            }
                        }
                        catch { }
                    }
                }
            }
            catch
            {

            }
        }

        private void TxtSearch_Leave(object sender, EventArgs e)
        {

        }

        private void FrmMasterPlayer_MouseDown(object sender, MouseEventArgs e)
        {
            listBox1.Visible = false;

            var tt = TxtID.Text;
            var tt1 = TxtSearch.Text;
        }
    }
}
