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
    public partial class frmDeleteMatchcs : Form
    {

        BusinessLy ObjMsBL = new BusinessLy();
        bool Pageload = false;
        string strMatchid = "";
        int Matchid = 0;
        string[] strMat = new string[2];
        DataTable dt;
        public frmDeleteMatchcs()
        {
            InitializeComponent();
        }

        private void frmDeleteMatchcs_Load(object sender, EventArgs e)
        {
            Pageload = true;
            dt = new DataTable();
            dt = ObjMsBL.ExeQueryStrRetDTBL("Select Matchid,CAST(Matchid AS VARCHAR)+' - '+dbo.fn_GetMatchNamePreDate(Matchid)MatchName From KB_Matches Order by MatchID Desc", 1);
            cbMatches.DataSource = dt;
            cbMatches.DisplayMember = "MatchName";
            cbMatches.ValueMember = "Matchid";
            cbMatches.SelectedIndex= - 1;
            Pageload = false;
        }

        private void CmdSave_Click(object sender, EventArgs e)
        {
            if (txtMatchid.Text.Trim() == "")
            { MessageBox.Show("please enter Matchid"); return; }
            strMatchid = txtMatchid.Text;

            strMat=strMatchid.Split('-');
            try
            {
                Matchid=Convert.ToInt32(strMat[1]);
            }
            catch{MessageBox.Show("please enter correct format");return;}
            if(strMat[0].ToString().ToUpper()!="KADAMBA")
            {MessageBox.Show("please enter correct format");return;}
            if(!strMatchid.Contains("-"))
            {MessageBox.Show("please enter correct format");return;}
            //if(txtMatchid.Text)
            if (Convert.ToInt32(cbMatches.SelectedValue) != Matchid)
            { MessageBox.Show("Selected Match and Entered match is Worng"); return; }
            try
            {
                if (MessageBox.Show("Continue to clear all transaction for this match", "Kabaddi", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string Query = "";
                    Query = "SP_Kabaddi_DeleteMatch '" + Matchid + "'";
                    if (ObjMsBL.ExeQueryRetBooDL(Query, 1))
                        MessageBox.Show("Transaction clear successfully");
                    else
                        MessageBox.Show("Transaction clear Failed");
                }
            }
            catch { 
            {MessageBox.Show("Transaction clear Failed");return;}}
        }

        private void cbMatches_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (!Pageload)
            //    txtMatchid.Text = cbMatches.SelectedValue.ToString();
        }
    }
}
