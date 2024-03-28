using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OtherSports_DataPushing.Layer;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;
using System.Net;


namespace OtherSports_DataPushing
{
    public partial class frmMatchResult : Form
    {

        Int32 ClubAID = 0;
        Int32 ClubBID = 0;
        Int32 MatchdID = CommonCls.MatchId;
        Int32 ClubAWin = 0;
        Int32 ClubBwin = 0;
       // Thread thCrayon;
       // SqlConnectionStringBuilder strBuild = new SqlConnectionStringBuilder();
        BusinessLy ObjMsBL = new BusinessLy();
        //MaterProp ObjMP = new MaterProp();
        //MasterComp ObjCom = new MasterComp();
        DataTable Dt;
       // string Query = "";
        int DBval;
        //SqlConnection Con = new SqlConnection(ConfigurationSettings.AppSettings["MainDB"]);
        //SqlDataAdapter Ada;
        //DataSet Dset;
       // SqlCommand sqlcmd;
       // string AppPath = System.Windows.Forms.Application.StartupPath;
       // string ListStr;
        //byte[] byteBlobData = null;
       // Boolean SaveFlg = false;
        //bool flagCrayon = false;

        public frmMatchResult()
        {
            InitializeComponent();
            LoadCombo();
        }
        public void LoadCombo()
        {
            Dictionary<int, string> lstResult = new Dictionary<int, string>();
            lstResult.Add(4, "Match Tied");
            lstResult.Add(2, "No Result");
            lstResult.Add(3, "Match Abandoned");
            lstResult.Add(5, "Match Result");
            cmbResult.DataSource = new BindingSource(lstResult, null);
            cmbResult.DisplayMember = "value";
            cmbResult.ValueMember = "key";
            cmbResult.SelectedIndex = 3;

        }

        private void frmMatchResult_Load(object sender, EventArgs e)
        {
            try
            {
                ObjMsBL = new BusinessLy();
               
                Dt = new DataTable();
                DataTable dtMres = new DataTable();
                Dt = ObjMsBL.ExeQueryStrRetDTBL("select Ca.TeamId ClubAId,Ca.TeamName ClubA,Cb.TeamId ClubBId,Cb.TeamName ClubB from KB_Matches Ma inner join Team_Master Ca on Ma.TeamA=Ca.Teamid inner join Team_Master Cb on Ma.TeamB=Cb.Teamid Where Ma.Matchid=" + MatchdID, DBval = 1);
                if (Dt.Rows.Count > 0)
                {
                    lbClubA.Text = Dt.Rows[0]["ClubA"].ToString();
                    TxtCubAID.Text = Dt.Rows[0]["ClubAID"].ToString();
                    ClubAID = Convert.ToInt32(Dt.Rows[0]["ClubAID"].ToString());
                    dtMres = ObjMsBL.ExeQueryStrRetDTBL("Select * from MatchResult where Matchid=" + MatchdID + " and ClubiD in(" + ClubAID + ")",DBval=1);
                    if (dtMres.Rows.Count > 0)
                    {
                        if ((dtMres.Rows[0]["ResultType"].ToString() == "1") || (dtMres.Rows[0]["ResultType"].ToString() == "0"))
                        {
                            TxtClubAResult.Text = Convert.ToString(dtMres.Rows[0]["Description"]);
                            if (Convert.ToInt32(dtMres.Rows[0]["ResultType"]) == 1)
                            {
                                RdClubA.Checked = true;
                            }
                            else
                                RdClubA.Checked = false;
                        }
                        else
                        {
                            cmbResult.SelectedValue = dtMres.Rows[0]["ResultType"].ToString();
                        }
                        if (dtMres.Rows[0]["IsGolden"].ToString() == "1")
                        {
                            chkIsgoldenRaid.Checked = true;
                            txtTeamApts.Text = dtMres.Rows[0]["GoldenPts"].ToString();
                        }
                        else
                        {
                            chkIsgoldenRaid.Checked = false;
                            txtTeamApts.Text = "0";
                        }
                    }
                   
                    lbClubB.Text = Dt.Rows[0]["ClubB"].ToString();
                    TxtCubBID.Text = Dt.Rows[0]["ClubBID"].ToString();
                    ClubBID = Convert.ToInt32(Dt.Rows[0]["ClubBID"].ToString());
                    dtMres = ObjMsBL.ExeQueryStrRetDTBL("Select * from MatchResult where Matchid=" + MatchdID + " and ClubiD in(" + ClubBID + ")", DBval = 1);
                    if (dtMres.Rows.Count > 0)
                    {
                        if ((dtMres.Rows[0]["ResultType"].ToString() == "1")||(dtMres.Rows[0]["ResultType"].ToString() == "0"))
                        {
                            TxtClubBResult.Text = Convert.ToString(dtMres.Rows[0]["Description"]);
                            if (Convert.ToInt32(dtMres.Rows[0]["ResultType"]) == 1)
                            {
                                RdClubB.Checked = true;
                            }
                            else
                                RdClubB.Checked = false;  
                        }
                        else
                        {
                            cmbResult.SelectedValue = dtMres.Rows[0]["ResultType"].ToString();
                        }
                        if (dtMres.Rows[0]["IsGolden"].ToString() == "1")
                        {
                            chkIsgoldenRaid.Checked = true;
                            txtTeamBpts.Text = dtMres.Rows[0]["GoldenPts"].ToString();
                        }
                        else
                        {
                            chkIsgoldenRaid.Checked = false;
                            txtTeamBpts.Text = "0";
                        }
                    }

                   
                }
            }
            catch
            {

            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            try
            {
                ObjMsBL = new BusinessLy();

                string Query = "Select Count(*) from MatchResult where matchid=" + MatchdID + "";
                if (ObjMsBL.ExeQueryStrIntBL(Query, DBval = 1) > 0)
                {
                    Query = "delete from MatchResult where matchid=" + MatchdID + "";
                    ObjMsBL.ExeQueryRetBooDL(Query, DBval = 1);
                }
                //else
                {
                    if ((Convert.ToString(cmbResult.SelectedValue) == "5") || (Convert.ToString(cmbResult.Text) == "Match Result"))
                    {
                        if (ObjMsBL.ExeQueryStrIntBL("Select * from MatchResult where Matchid=" + MatchdID + " and ClubiD in(" + ClubAID + "," + ClubBID + ")", DBval = 1) > 0)
                        {
                            ObjMsBL.ExeQueryRetBooDL("Delete from Matchresult where MatchID=" + MatchdID + " and ClubID in(" + ClubAID + "," + ClubBID + ")", DBval = 1);
                            try
                            {
                                int cnt = ObjMsBL.ExeQueryStrIntBL("Select ISNULL(Count(*),0)+1 From tblCorrectedTable where Matchid=" + MatchdID + " And tablename='Matchresult'", 1);
                                ObjMsBL.ExeQueryRetBooDL("Insert into tblCorrectedTable (Matchid,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + MatchdID + "," + cnt + ",'Matchresult','" + System.DateTime.Now + "',0,0,1)", 1);
                            }
                            catch { }
                        }
                        //else
                        //{
                        if (ObjMsBL.ExeQueryRetBooDL("Insert into MatchResult(MatchID,ClubID,ResultType,Description,IsGolden,GoldenPts) values(" + MatchdID + "," + ClubAID + "," + ClubAWin + ",'" + TxtClubAResult.Text + "'," + (chkIsgoldenRaid.Checked ? 1 : 0) + "," + txtTeamApts.Text + ")", DBval = 1))
                        {
                            MessageBox.Show("Insert sucessfully");
                        }
                        if (ObjMsBL.ExeQueryRetBooDL("Insert into MatchResult(MatchID,ClubID,ResultType,Description,IsGolden,GoldenPts) values(" + MatchdID + "," + ClubBID + "," + ClubBwin + ",'" + TxtClubBResult.Text + "'," + (chkIsgoldenRaid.Checked ? 1 : 0) + "," + txtTeamBpts.Text + ")", DBval = 1))
                        {
                            MessageBox.Show("Insert sucessfully");
                        }
                        try
                        {
                            int cnt = ObjMsBL.ExeQueryStrIntBL("Select ISNULL(Count(*),0)+1 From tblCorrectedTable where Matchid=" + MatchdID + " And tablename='Matchresult'", 1);
                            ObjMsBL.ExeQueryRetBooDL("Insert into tblCorrectedTable (Matchid,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + MatchdID + "," + cnt + ",'Matchresult','" + System.DateTime.Now + "',1,0,0)", 1);
                        }
                        catch { }
                    }
                    else if (Convert.ToString(cmbResult.SelectedValue) == "4")
                    {
                        if (ObjMsBL.ExeQueryStrIntBL("Select * from MatchResult where Matchid=" + MatchdID + " and ClubiD in(" + ClubAID + "," + ClubBID + ")", DBval = 1) > 0)
                        {
                            ObjMsBL.ExeQueryRetBooDL("Delete from Matchresult where MatchID=" + MatchdID + " and ClubID in(" + ClubAID + "," + ClubBID + ")", DBval = 1);
                            try
                            {
                                int cnt = ObjMsBL.ExeQueryStrIntBL("Select ISNULL(Count(*),0)+1 From tblCorrectedTable where Matchid=" + MatchdID + " And tablename='Matchresult'", 1);
                                ObjMsBL.ExeQueryRetBooDL("Insert into tblCorrectedTable (Matchid,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + MatchdID + "," + cnt + ",'Matchresult','" + System.DateTime.Now + "',0,0,1)", 1);
                            }
                            catch { }
                        }
                        //else
                        //{
                        if (ObjMsBL.ExeQueryRetBooDL("Insert into MatchResult(MatchID,ClubID,ResultType,Description,IsGolden,GoldenPts) values(" + MatchdID + "," + ClubAID + "," + Convert.ToString(cmbResult.SelectedValue) + ",'" + TxtClubAResult.Text + "'," + (chkIsgoldenRaid.Checked ? 1 : 0) + "," + txtTeamApts.Text + ")", DBval = 1))
                        {
                            MessageBox.Show("Insert sucessfully");
                        }
                        if (ObjMsBL.ExeQueryRetBooDL("Insert into MatchResult(MatchID,ClubID,ResultType,Description,IsGolden,GoldenPts) values(" + MatchdID + "," + ClubBID + "," + Convert.ToString(cmbResult.SelectedValue) + ",'" + TxtClubBResult.Text + "'," + (chkIsgoldenRaid.Checked ? 1 : 0) + "," + txtTeamBpts.Text + ")", DBval = 1))
                        {
                            MessageBox.Show("Insert sucessfully");
                        }
                        try
                        {
                            int cnt = ObjMsBL.ExeQueryStrIntBL("Select ISNULL(Count(*),0)+1 From tblCorrectedTable where Matchid=" + MatchdID + " And tablename='Matchresult'", 1);
                            ObjMsBL.ExeQueryRetBooDL("Insert into tblCorrectedTable (Matchid,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + MatchdID + "," + cnt + ",'Matchresult','" + System.DateTime.Now + "',1,0,0)", 1);
                        }
                        catch { }
                    }
                    else
                    {
                        if (ObjMsBL.ExeQueryStrIntBL("Select * from MatchResult where Matchid=" + MatchdID + " and ClubiD in(" + ClubAID + "," + ClubBID + ")", DBval = 1) > 0)
                        {
                            ObjMsBL.ExeQueryRetBooDL("Delete from Matchresult where MatchID=" + MatchdID + " and ClubID in(" + ClubAID + "," + ClubBID + ")", DBval = 1);
                            try
                            {
                                int cnt = ObjMsBL.ExeQueryStrIntBL("Select ISNULL(Count(*),0)+1 From tblCorrectedTable where Matchid=" + MatchdID + " And tablename='Matchresult'", 1);
                                ObjMsBL.ExeQueryRetBooDL("Insert into tblCorrectedTable (Matchid,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + MatchdID + "," + cnt + ",'Matchresult','" + System.DateTime.Now + "',0,0,1)", 1);
                            }
                            catch { }
                        }
                        //else
                        //{
                        if (ObjMsBL.ExeQueryRetBooDL("Insert into MatchResult(MatchID,ClubID,ResultType,Description,IsGolden,GoldenPts) values(" + MatchdID + "," + ClubAID + "," + Convert.ToString(cmbResult.SelectedValue) + ",'" + Convert.ToString(cmbResult.Text) + "'," + (chkIsgoldenRaid.Checked ? 1 : 0) + "," + txtTeamApts.Text + ")", DBval = 1))
                        {
                            MessageBox.Show("Insert sucessfully");
                        }
                        if (ObjMsBL.ExeQueryRetBooDL("Insert into MatchResult(MatchID,ClubID,ResultType,Description,IsGolden,GoldenPts) values(" + MatchdID + "," + ClubBID + "," + Convert.ToString(cmbResult.SelectedValue) + ",'" + Convert.ToString(cmbResult.Text) + "'," + (chkIsgoldenRaid.Checked ? 1 : 0) + "," + txtTeamBpts.Text + ")", DBval = 1))
                        {
                            MessageBox.Show("Insert sucessfully");
                        }
                        try
                        {
                            int cnt = ObjMsBL.ExeQueryStrIntBL("Select ISNULL(Count(*),0)+1 From tblCorrectedTable where Matchid=" + MatchdID + " And tablename='Matchresult'", 1);
                            ObjMsBL.ExeQueryRetBooDL("Insert into tblCorrectedTable (Matchid,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + MatchdID + "," + cnt + ",'Matchresult','" + System.DateTime.Now + "',1,0,0)", 1);
                        }
                        catch { }
                    }
                }
                this.Hide();
            }
            catch (Exception ex)
            {
                if (Convert.ToString(ex.Message).Contains("trigger"))
                    MessageBox.Show(Convert.ToString(ex.Message).Remove(Convert.ToString(ex.Message).LastIndexOf("!") + 1));
            }

        }

        private void RdClubA_CheckedChanged(object sender, EventArgs e)
        {
            if (RdClubA.Checked)
            {
                ClubAWin = 1;
                ClubBwin = 0;
            }
            else if (RdClubB.Checked)
            {
                ClubBwin = 1;
                ClubAWin = 0;
            }
        }

        private void RdClubB_CheckedChanged(object sender, EventArgs e)
        {
            if (RdClubB.Checked)
            {
                ClubBwin = 1;
                ClubAWin = 0;
            }
            else if (RdClubA.Checked)
            {
                ClubBwin = 0;
                ClubAWin = 1;
            }   
        }

        private void cmbResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(cmbResult.SelectedValue) == "5"||Convert.ToString(cmbResult.SelectedValue) == "4")
                gbResult.Visible = true;
            else
                gbResult.Visible = false;
        }

        private void CmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CmdClear_Click(object sender, EventArgs e)
        {

        }

        private void chkIsgoldenRaid_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsgoldenRaid.Checked)
            {
                lblGoldenRaid.Enabled = true;
                txtTeamApts.Enabled = true;
                txtTeamBpts.Enabled = true;
                txtTeamApts.Text = "0";
                txtTeamBpts.Text = "0";
            }
            else
            {
                lblGoldenRaid.Enabled = false;
                txtTeamApts.Enabled = false;
                txtTeamBpts.Enabled = false;
                txtTeamApts.Text = "0";
                txtTeamBpts.Text = "0";
            }
        }
    }
}
