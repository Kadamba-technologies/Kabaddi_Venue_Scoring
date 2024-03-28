using OtherSports_DataPushing.Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OtherSports_DataPushing
{
    public partial class frmImportExport : Form
    {
        BusinessLy Objbl = new BusinessLy();
        DataTable Dt;
        DataSet Dset;
        bool Pageload = false;
        string FolderPath = "";
        string newtournamentid;
        int newmatchid = 1;
        Int32 Matchid = 1;
        int MiD;

        public string[] newids;
        public string[] oldids;
        public string[] oldclubids;
        public string[] newclubids;
        public string[] oldVnids;
        public string[] newVnids;
        public string[] oldcompids;
        public string[] newcompids;

        public frmImportExport()
        {
            InitializeComponent();
        }

        private void frmImportExport_Load(object sender, EventArgs e)
        {
            Pageload = false;
            BindCompetition();
            Pageload = true;
        }

        void BindCompetition()
        {
            cmbcompetition.DataSource = Objbl.ExeQueryStrRetDTBL("Select CompID Id,Name From Competition Order by id desc", 1); 
            cmbcompetition.DisplayMember = "name";
            cmbcompetition.ValueMember = "ID";
            cmbcompetition.SelectedIndex = -1;
        }

        private void cmbcompetition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Pageload) { return; }
            Pageload = false;
            cmbmatch.DataSource = Objbl.ExeQueryStrRetDTBL("select q.MatchID,CAST(q.MatchID as Nvarchar(100))+' - '+(q.Team1 +' Vs '+q.Team2+' '+convert(varchar,q.date,105)) Match "
                       + " from(select KB_Matches.MatchID,a.[TeamName] Team1,b.[TeamName] Team2,KB_Matches.date from KB_Matches "
                       + " inner join competition on KB_Matches.competitionid = competition.CompID "
                       + " inner join Team_Master a on KB_Matches.TeamA= a.TeamID "
                       + " inner join Team_Master b on KB_Matches.TeamB = b.TeamID"
                       + " where competition.CompID=" + cmbcompetition.SelectedValue + ")q Order by MatchID", 1);
            cmbmatch.DisplayMember = "Match";
            cmbmatch.ValueMember = "MatchID";
            cmbmatch.SelectedIndex = -1;
            Pageload = true;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {

            browsebox.ShowDialog();
            FolderPath = browsebox.SelectedPath.ToString();

            if (FolderPath != "")
            {
                Cursor.Current = Cursors.WaitCursor;
                DirectoryInfo di = new DirectoryInfo(FolderPath);
                foreach (FileInfo fi in di.GetFiles())
                {
                    string FieldName;
                    string FieldValue;
                    string UpQuery;
                    string Condition;

                    switch (fi.Name)
                    {
                        case "A.xml":
                            {
                                //EventMaster
                                try
                                {
                                    Dset = new DataSet();
                                    Dset.ReadXml(FolderPath + "\\A.XML");
                                    if (Dset.Tables.Count > 0)
                                    {
                                        if (Dset.Tables[0].Rows.Count > 0)
                                        {
                                            foreach (DataRow dr in Dset.Tables[0].Rows)
                                            {
                                                FieldName = "";
                                                FieldValue = "";
                                                UpQuery = "";
                                                Condition = "";

                                                foreach (DataColumn dc in Dset.Tables[0].Columns)
                                                {
                                                    if (dc.ColumnName.ToUpper().ToString() != "ID")
                                                    {
                                                        if (UpQuery != "")
                                                            UpQuery = UpQuery + ",";
                                                        UpQuery = UpQuery + dc.ColumnName + "='" + dr[dc].ToString() + "'";

                                                        if (FieldName != "")
                                                            FieldName = FieldName + ",";
                                                        FieldName = FieldName + dc.ColumnName;

                                                        if (FieldValue != "")
                                                            FieldValue = FieldValue + "','";
                                                        FieldValue = FieldValue + dr[dc].ToString();
                                                    }
                                                }
                                                FieldValue = "'" + FieldValue + "'";
                                                Condition = "Id =" + dr["Id"].ToString();

                                                Objbl = new BusinessLy();
                                                Int32 Recount = Objbl.ExeQueryStrIntBL("Select count(*) from EventMaster where " + Condition, 1);
                                                if (Recount == 0)
                                                    ImportMatchDataInsert("EventMaster", FieldName, FieldValue);
                                                else if (Recount > 0)
                                                    ImportMatchDataUpdate("EventMaster", UpQuery, Condition);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No Records in EventMaster");
                                    }
                                }
                                catch
                                {
                                    MessageBox.Show("Error in EventMaster");
                                }
                            }
                            break;
                        case "B.xml":
                            {
                                //Stage
                                try
                                {
                                    Dset = new DataSet();
                                    Dset.ReadXml(FolderPath + "\\B.XML");
                                    if (Dset.Tables.Count > 0)
                                    {
                                        if (Dset.Tables[0].Rows.Count > 0)
                                        {
                                            foreach (DataRow dr in Dset.Tables[0].Rows)
                                            {
                                                FieldName = "";
                                                FieldValue = "";
                                                UpQuery = "";
                                                Condition = "";

                                                foreach (DataColumn dc in Dset.Tables[0].Columns)
                                                {
                                                    if (dc.ColumnName.ToUpper().ToString() != "ID")
                                                    {
                                                        if (UpQuery != "")
                                                            UpQuery = UpQuery + ",";
                                                        UpQuery = UpQuery + dc.ColumnName + "='" + dr[dc].ToString() + "'";

                                                        if (FieldName != "")
                                                            FieldName = FieldName + ",";
                                                        FieldName = FieldName + dc.ColumnName;

                                                        if (FieldValue != "")
                                                            FieldValue = FieldValue + "','";
                                                        FieldValue = FieldValue + dr[dc].ToString();
                                                    }
                                                }
                                                FieldValue = "'" + FieldValue + "'";
                                                Condition = "Id =" + dr["Id"].ToString();

                                                Objbl = new BusinessLy();
                                                Int32 Recount = Objbl.ExeQueryStrIntBL("Select count(*) from Stage where " + Condition, 1);
                                                if (Recount == 0)
                                                    ImportMatchDataInsert("Stage", FieldName, FieldValue);
                                                else if (Recount > 0)
                                                    ImportMatchDataUpdate("Stage", UpQuery, Condition);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No Records in Stage");
                                    }
                                }
                                catch
                                {
                                    MessageBox.Show("Error in Stage");
                                }
                            }
                            break;
                        case "C.xml":
                            {
                                string oldLnm = "";
                                string oldfnm = "";
                                string oldMnm = "";
                                //Player
                                try
                                {

                                    DataSet dtcxml = new DataSet();
                                    dtcxml.ReadXml(FolderPath + "\\C.xml", XmlReadMode.Auto);
                                    oldids = new string[dtcxml.Tables[0].Rows.Count];
                                    for (int j = 0; j < dtcxml.Tables[0].Rows.Count; j++)
                                    {
                                        oldids[j] = dtcxml.Tables[0].Rows[j]["ID"].ToString();
                                    }
                                    if (dtcxml.Tables.Count > 0)
                                    {
                                        if (dtcxml.Tables[0].Rows.Count > 0)
                                        {
                                            for (int i = 0; i < dtcxml.Tables[0].Rows.Count; i++)
                                            {
                                                string oldid = dtcxml.Tables[0].Rows[i]["ID"].ToString();
                                                oldfnm = dtcxml.Tables[0].Rows[i]["FirstName"].ToString();
                                                oldMnm = dtcxml.Tables[0].Rows[i]["MiddleName"].ToString();
                                                oldLnm = dtcxml.Tables[0].Rows[i]["LastName"].ToString();
                                                DateTime converteddate; string DOB;
                                                if (dtcxml.Tables[0].Rows[i]["DOB"].ToString() == "")
                                                {
                                                    converteddate = new DateTime();
                                                    DOB = Convert.ToString(converteddate);
                                                }
                                                else
                                                {
                                                    converteddate = DateTime.Parse(dtcxml.Tables[0].Rows[i]["DOB"].ToString());
                                                    DOB = converteddate.ToString("yyyy-MM-dd HH:mm:ss");
                                                }

                                                string Role = Convert.ToString(dtcxml.Tables[0].Rows[i]["Role"]);
                                                int Gender=1;
                                                try
                                                {
                                                    Gender = Convert.ToInt32(dtcxml.Tables[0].Rows[i]["Gender"]);
                                                }
                                                catch { }
                                                string TeamID = Convert.ToString(dtcxml.Tables[0].Rows[i]["TeamID"]);
                                                string SportID = Convert.ToString(dtcxml.Tables[0].Rows[i]["SportID"]);
                                                string Country = Convert.ToString(dtcxml.Tables[0].Rows[i]["Country"]);
                                                string PickNo = Convert.ToString(dtcxml.Tables[0].Rows[i]["PickNo"]);


                                                string newplid = createNwXMLID(oldid, oldfnm, oldMnm, oldLnm, DOB, Gender, SportID, TeamID, PickNo, Role, Country);
                                               // string newplid = Objbl.ExeQueryStrRetStrBL("Select dbo.Fn_GetlayerNewId(" + oldid + ")", 1);
                                                if (Convert.ToInt32(newplid) != Convert.ToInt32(oldid))
                                                {
                                                    dtcxml.Tables[0].Rows[i]["ID"] = newplid.ToString();
                                                }
                                            }
                                            newids = new string[dtcxml.Tables[0].Rows.Count];
                                            for (int j = 0; j < dtcxml.Tables[0].Rows.Count; j++)
                                            {
                                                newids[j] = dtcxml.Tables[0].Rows[j]["ID"].ToString();
                                            }

                                        }
                                    }
                                    if (dtcxml.Tables.Count > 0)
                                    {
                                        if (dtcxml.Tables[0].Rows.Count > 0)
                                        {
                                            foreach (DataRow dr in dtcxml.Tables[0].Rows)
                                            {
                                                FieldName = "";
                                                FieldValue = "";
                                                UpQuery = "";
                                                Condition = "";

                                                foreach (DataColumn dc in dtcxml.Tables[0].Columns)
                                                {
                                                    if (dc.ColumnName.ToUpper().ToString() != "ID")
                                                    {
                                                        if (UpQuery != "")
                                                            UpQuery = UpQuery + ",";
                                                        UpQuery = UpQuery + dc.ColumnName + "='" + dr[dc].ToString() + "'";

                                                        if (FieldName != "")
                                                            FieldName = FieldName + ",";
                                                        FieldName = FieldName + dc.ColumnName;

                                                        if (FieldValue != "")
                                                            FieldValue = FieldValue + "','";
                                                        FieldValue = FieldValue + dr[dc].ToString();
                                                    }
                                                }
                                                FieldValue = "'" + FieldValue + "'";
                                                Condition = "Id =" + dr["Id"].ToString();

                                                Int32 Recount = Objbl.ExeQueryStrIntBL("Select count(*) from Player_Master where id=" + dr["Id"].ToString(), 1);
                                                if (Recount == 0)
                                                {
                                                    ImportMatchDataInsert("Player_Master", FieldName, FieldValue);
                                                }
                                                else if (Recount > 0)
                                                {
                                                    ImportMatchDataUpdate("Player_Master", UpQuery, Condition);
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No Records in Player");
                                    }
                                }

                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message + "," + oldfnm + "," + oldMnm + "," + oldLnm);
                                    WriteToLog(ex.Message + "," + oldfnm + "," + oldMnm + "," + oldLnm);
                                    MessageBox.Show("Error on Player");

                                }
                            }
                            break;
                        case "D.xml":
                            {
                                //Team_Master
                                try
                                {
                                    Dset = new DataSet();
                                    Dset.ReadXml(FolderPath + "\\D.xml");
                                    oldclubids = new string[Dset.Tables[0].Rows.Count];
                                    for (int j = 0; j < Dset.Tables[0].Rows.Count; j++)
                                    {
                                        oldclubids[j] = Dset.Tables[0].Rows[j]["TeamID"].ToString();
                                        WriteToLog("Old TeamID(Team_Master xml) from xml " + oldclubids[j]);
                                    }
                                    if (Dset.Tables.Count > 0)
                                    {
                                        if (Dset.Tables[0].Rows.Count > 0)
                                        {
                                            for (int i = 0; i < Dset.Tables[0].Rows.Count; i++)
                                            {
                                                string oldclubid = Dset.Tables[0].Rows[i]["TeamID"].ToString();
                                                string oldclubnm = Dset.Tables[0].Rows[i]["TeamName"].ToString();
                                                string oldprefix = Dset.Tables[0].Rows[i]["Prefix"].ToString();
                                                string Country = Dset.Tables[0].Rows[i]["Country"].ToString();
                                                string SportID="8";
                                                try
                                                {
                                                    SportID = Dset.Tables[0].Rows[i]["SportID"].ToString();
                                                }
                                                catch { }
                                                string newclubid = createNwClubID(oldclubid, oldclubnm, oldprefix, Country, SportID);

                                                if (Convert.ToInt32(newclubid) == Convert.ToInt32(oldclubid))
                                                { }
                                                else
                                                {
                                                    Dset.Tables[0].Rows[i]["TeamID"] = newclubid.ToString();
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No Records in Team_Master");
                                    }
                                    newclubids = new string[Dset.Tables[0].Rows.Count];
                                    for (int j = 0; j < Dset.Tables[0].Rows.Count; j++)
                                    {
                                        newclubids[j] = Dset.Tables[0].Rows[j]["TeamID"].ToString();
                                    }
                                    if (Dset.Tables.Count > 0)
                                    {
                                        if (Dset.Tables[0].Rows.Count > 0)
                                        {
                                            foreach (DataRow dr in Dset.Tables[0].Rows)
                                            {
                                                FieldName = "";
                                                FieldValue = "";
                                                UpQuery = "";
                                                Condition = "";

                                                foreach (DataColumn dc in Dset.Tables[0].Columns)
                                                {
                                                    if (dc.ColumnName.ToUpper().ToString() != "TeamID")
                                                    {
                                                        if (UpQuery != "")
                                                            UpQuery = UpQuery + ",";
                                                        UpQuery = UpQuery + dc.ColumnName + "='" + dr[dc].ToString() + "'";

                                                        if (FieldName != "")
                                                            FieldName = FieldName + ",";
                                                        FieldName = FieldName + dc.ColumnName;

                                                        if (FieldValue != "")
                                                            FieldValue = FieldValue + "','";
                                                        FieldValue = FieldValue + dr[dc].ToString();
                                                    }
                                                }
                                                FieldValue = "'" + FieldValue + "'";
                                                Condition = "TeamID =" + dr["TeamID"].ToString();

                                                Int32 Recount = Objbl.ExeQueryStrIntBL("Select count(*) from Team_Master where TeamID=" + dr["TeamID"].ToString(), 1);
                                                if (Recount == 0)
                                                {
                                                    ImportMatchDataInsert("Team_Master", FieldName, FieldValue);
                                                }
                                                else if (Recount > 0)
                                                {
                                                    ImportMatchDataUpdate("Team_Master", UpQuery, Condition);
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No Records in Team_Master");
                                    }
                                }
                                catch
                                {
                                    MessageBox.Show("Error on Team_Master");
                                }
                            }
                            break;
                        case "E1.xml":
                            {
                                //COMPETITION
                                try
                                {
                                    Dset = new DataSet();
                                    Dset.ReadXml(FolderPath + "\\E1.XML");
                                    oldcompids = new string[Dset.Tables[0].Rows.Count];
                                    for (int j = 0; j < Dset.Tables[0].Rows.Count; j++)
                                    {
                                        oldcompids[j] = Dset.Tables[0].Rows[j]["CompID"].ToString();
                                    }
                                    if (Dset.Tables.Count > 0)
                                    {
                                        if (Dset.Tables[0].Rows.Count > 0)
                                        {
                                            for (int i = 0; i < Dset.Tables[0].Rows.Count; i++)
                                            {
                                                string oldid = Dset.Tables[0].Rows[i]["CompID"].ToString();
                                                string compname = Dset.Tables[0].Rows[i]["Name"].ToString();
                                                int SportID = Convert.ToInt32(Dset.Tables[0].Rows[i]["SportID"]);

                                                DateTime converteddate = DateTime.Parse(Dset.Tables[0].Rows[i]["FromDate"].ToString());
                                                string FromDate = converteddate.ToString("yyyy-MM-dd HH:mm:ss");

                                                DateTime converteddate1 = DateTime.Parse(Dset.Tables[0].Rows[i]["Todate"].ToString());
                                                string Todate = converteddate1.ToString("yyyy-MM-dd HH:mm:ss");
                                                int MatchType = Convert.ToInt32(Dset.Tables[0].Rows[i]["MatchType"]); ;


                                                string newid = createNwCompId(oldid, SportID, compname, FromDate, Todate, MatchType);

                                                if (Convert.ToInt32(newid) == Convert.ToInt32(oldid))
                                                { }
                                                else
                                                {
                                                    Dset.Tables[0].Rows[i]["CompID"] = newid.ToString();
                                                }
                                            }
                                            newcompids = new string[Dset.Tables[0].Rows.Count];
                                            for (int j = 0; j < Dset.Tables[0].Rows.Count; j++)
                                            {
                                                newcompids[j] = Dset.Tables[0].Rows[j]["CompID"].ToString();
                                            }
                                        }

                                        foreach (DataRow dr in Dset.Tables[0].Rows)
                                        {
                                            foreach (DataColumn dc in Dset.Tables[0].Columns)
                                            {
                                                if (dc.ColumnName.ToUpper().ToString() == "FROMDATE")
                                                {
                                                    DateTime converteddate = DateTime.Parse(dr[dc].ToString());
                                                    dr[dc] = converteddate.ToString("yyyy-MM-dd HH:mm:ss");
                                                }
                                                if (dc.ColumnName.ToUpper().ToString() == "TODATE")
                                                {
                                                    DateTime converteddate = DateTime.Parse(dr[dc].ToString());
                                                    dr[dc] = converteddate.ToString("yyyy-MM-dd HH:mm:ss");
                                                }
                                            }
                                        }

                                    }
                                    if (Dset.Tables.Count > 0)
                                    {
                                        if (Dset.Tables[0].Rows.Count > 0)
                                        {
                                            foreach (DataRow dr in Dset.Tables[0].Rows)
                                            {
                                                FieldName = "";
                                                FieldValue = "";
                                                UpQuery = "";
                                                Condition = "";

                                                foreach (DataColumn dc in Dset.Tables[0].Columns)
                                                {
                                                    if (dc.ColumnName.ToUpper().ToString() != "ID")
                                                    {
                                                        if (UpQuery != "")
                                                            UpQuery = UpQuery + ",";
                                                        UpQuery = UpQuery + dc.ColumnName + "='" + dr[dc].ToString() + "'";

                                                        if (FieldName != "")
                                                            FieldName = FieldName + ",";
                                                        FieldName = FieldName + dc.ColumnName;

                                                        if (FieldValue != "")
                                                            FieldValue = FieldValue + "','";
                                                        FieldValue = FieldValue + dr[dc].ToString();
                                                    }
                                                }
                                                FieldValue = "'" + FieldValue + "'";
                                                Condition = "CompID =" + dr["CompID"].ToString();

                                                Int32 Recount = Objbl.ExeQueryStrIntBL("Select count(*) from Competition where CompID=" + dr["CompID"].ToString(), 1);
                                                if (Recount == 0)
                                                    ImportMatchDataInsert("Competition", FieldName, FieldValue);
                                                else if (Recount > 0)
                                                    ImportMatchDataUpdate("Competition", UpQuery, Condition);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No Records in COMPETITION");
                                    }
                                }
                                catch
                                {
                                    MessageBox.Show("Error on Competition");

                                }
                            }
                            break;
                        case "F.xml":
                            {
                                // Venue_Master
                                try
                                {
                                    Dset = new DataSet();
                                    Dset.ReadXml(FolderPath + "\\F.XML");
                                    oldVnids = new string[Dset.Tables[0].Rows.Count];
                                    for (int i = 0; i < Dset.Tables[0].Rows.Count; i++)
                                    {
                                        oldVnids[i] = Dset.Tables[0].Rows[i]["ID"].ToString();
                                    }
                                    if (Dset.Tables.Count > 0)
                                    {
                                        if (Dset.Tables[0].Rows.Count > 0)
                                        {
                                            for (int i = 0; i < Dset.Tables[0].Rows.Count; i++)
                                            {
                                                string oldVnid = Dset.Tables[0].Rows[i]["ID"].ToString();
                                                string oldVnname = Dset.Tables[0].Rows[i]["Name"].ToString();
                                                string city = Dset.Tables[0].Rows[i]["City"].ToString();
                                                string Country = Dset.Tables[0].Rows[i]["Country"].ToString();
                                                string SportID ="8";
                                                try
                                                {
                                                    SportID = Dset.Tables[0].Rows[i]["SportID"].ToString();
                                                }
                                                catch { }
                                                string newVnid = createNwVenueID(oldVnid, oldVnname, city, Country, SportID);
                                                if (Convert.ToInt32(newVnid) == Convert.ToInt32(oldVnid))
                                                { }
                                                else
                                                {
                                                    Dset.Tables[0].Rows[i]["ID"] = newVnid.ToString();
                                                }
                                            }
                                            newVnids = new string[Dset.Tables[0].Rows.Count];
                                            for (int j = 0; j < Dset.Tables[0].Rows.Count; j++)
                                            {
                                                newVnids[j] = Dset.Tables[0].Rows[j]["ID"].ToString();
                                            }
                                        }
                                    }
                                    if (Dset.Tables.Count > 0)
                                    {
                                        if (Dset.Tables[0].Rows.Count > 0)
                                        {
                                            foreach (DataRow dr in Dset.Tables[0].Rows)
                                            {
                                                FieldName = "";
                                                FieldValue = "";
                                                UpQuery = "";
                                                Condition = "";

                                                foreach (DataColumn dc in Dset.Tables[0].Columns)
                                                {
                                                    if (dc.ColumnName.ToUpper().ToString() != "ID")
                                                    {
                                                        if (UpQuery != "")
                                                            UpQuery = UpQuery + ",";
                                                        UpQuery = UpQuery + dc.ColumnName + "='" + dr[dc].ToString() + "'";

                                                        if (FieldName != "")
                                                            FieldName = FieldName + ",";
                                                        FieldName = FieldName + dc.ColumnName;

                                                        if (FieldValue != "")
                                                            FieldValue = FieldValue + "','";
                                                        FieldValue = FieldValue + dr[dc].ToString();
                                                    }
                                                }
                                                FieldValue = "'" + FieldValue + "'";
                                                Condition = "ID =" + dr["ID"].ToString();

                                                Int32 Recount = Objbl.ExeQueryStrIntBL("Select count(*) from Venue_Master where ID=" + dr["ID"].ToString(), 1);
                                                if (Recount == 0)
                                                    ImportMatchDataInsert("Venue_Master", FieldName, FieldValue);
                                                else if (Recount > 0)
                                                    ImportMatchDataUpdate("Venue_Master", UpQuery, Condition);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No Records in Venue_Master");
                                    }
                                }

                                catch
                                {
                                    MessageBox.Show("Error on Venue_Master");
                                }
                            }
                            break;
                        case "G0.xml":
                            {
                                //CompetitionTeam
                                try
                                {
                                    Dset = new DataSet();
                                    Dset.ReadXml(FolderPath + "\\G0.XML");
                                    if (Dset.Tables.Count > 0)
                                    {
                                        if (Dset.Tables[0].Rows.Count > 0)
                                        {
                                            foreach (DataRow dr in Dset.Tables[0].Rows)
                                            {
                                                FieldName = "";
                                                FieldValue = "";
                                                UpQuery = "";
                                                Condition = "";

                                                foreach (DataColumn dc in Dset.Tables[0].Columns)
                                                {
                                                    if (UpQuery != "")
                                                        UpQuery = UpQuery + ",";
                                                    UpQuery = UpQuery + dc.ColumnName + "='" + dr[dc].ToString() + "'";

                                                    if (FieldName != "")
                                                        FieldName = FieldName + ",";
                                                    FieldName = FieldName + dc.ColumnName;

                                                    if (FieldValue != "")
                                                        FieldValue = FieldValue + "','";
                                                    FieldValue = FieldValue + dr[dc].ToString();
                                                }
                                                FieldValue = "'" + FieldValue + "'";
                                                Condition = "CompId =" + dr["CompId"].ToString() + " and TeamID =" + dr["TeamID"].ToString();

                                                Objbl = new BusinessLy();
                                                Int32 Recount = Objbl.ExeQueryStrIntBL("Select count(*) from CompetitionTeam where " + Condition, 1);
                                                if (Recount == 0)
                                                    ImportMatchDataInsert("CompetitionTeam", FieldName, FieldValue);
                                                else if (Recount > 0)
                                                    ImportMatchDataUpdate("CompetitionTeam", UpQuery, Condition);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No Records in CompetitionTeam");
                                    }
                                }
                                catch
                                {
                                    MessageBox.Show("Error in CompetitionTeam");
                                }
                            }
                            break;
                        case "G1.xml":
                            {
                                //CompetitionSquad
                                try
                                {
                                    Dset = new DataSet();
                                    Dset.ReadXml(FolderPath + "\\G1.XML");
                                    if (Dset.Tables.Count > 0)
                                    {
                                        if (Dset.Tables[0].Rows.Count > 0)
                                        {
                                            for (int i = 0; i < Dset.Tables[0].Rows.Count; i++)
                                            {
                                                for (int j = 0; j < oldids.Length; j++)
                                                {
                                                    try
                                                    {
                                                        if (Convert.ToInt32(Dset.Tables[0].Rows[i]["PlayerID"]) == Convert.ToInt32(oldids[j]))
                                                            Dset.Tables[0].Rows[i]["PlayerID"] = newids[j];
                                                    }
                                                    catch { }
                                                }
                                            }

                                            foreach (DataRow dr in Dset.Tables[0].Rows)
                                            {
                                                FieldName = "";
                                                FieldValue = "";
                                                UpQuery = "";
                                                Condition = "";

                                                foreach (DataColumn dc in Dset.Tables[0].Columns)
                                                {
                                                    if (UpQuery != "")
                                                        UpQuery = UpQuery + ",";
                                                    UpQuery = UpQuery + dc.ColumnName + "='" + dr[dc].ToString() + "'";

                                                    if (FieldName != "")
                                                        FieldName = FieldName + ",";
                                                    FieldName = FieldName + dc.ColumnName;

                                                    if (FieldValue != "")
                                                        FieldValue = FieldValue + "','";
                                                    FieldValue = FieldValue + dr[dc].ToString();
                                                }
                                                FieldValue = "'" + FieldValue + "'";
                                                Condition = "CompId =" + dr["CompId"].ToString() + " and TeamID =" + dr["TeamID"].ToString() + " and PlayerId=" + dr["PlayerId"].ToString();

                                                Objbl = new BusinessLy();
                                                Int32 Recount = Objbl.ExeQueryStrIntBL("Select count(*) from CompetitionSquad where " + Condition, 1);
                                                if (Recount == 0)
                                                    ImportMatchDataInsert("CompetitionSquad", FieldName, FieldValue);
                                                else if (Recount > 0)
                                                    ImportMatchDataUpdate("CompetitionSquad", UpQuery, Condition);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No Records in CompetitionSquad");
                                    }
                                }
                                catch
                                {
                                    MessageBox.Show("Error in CompetitionSquad");
                                }
                            }
                            break;

                        case "H.xml":
                            {
                                // Matches
                                try
                                {
                                    DataSet Dset = new DataSet();
                                    Dset.ReadXml(FolderPath + "\\H.xml");
                                    if (Dset.Tables.Count > 0)
                                    {
                                        if (Dset.Tables[0].Rows.Count > 0)
                                        {
                                            for (int i = 0; i < Dset.Tables[0].Rows.Count; i++)
                                            {
                                                for (int j = 0; j < oldclubids.Length; j++)
                                                {
                                                    if (Convert.ToInt32(Dset.Tables[0].Rows[i]["TeamA"]) == Convert.ToInt32(oldclubids[j]))
                                                        Dset.Tables[0].Rows[i]["TeamA"] = newclubids[j];
                                                    WriteToLog("clibA id in match table  " + Dset.Tables[0].Rows[i]["TeamA"].ToString());
                                                    if (Convert.ToInt32(Dset.Tables[0].Rows[i]["TeamB"]) == Convert.ToInt32(oldclubids[j]))
                                                        Dset.Tables[0].Rows[i]["TeamB"] = newclubids[j];
                                                    WriteToLog("clibB id in match table  " + Dset.Tables[0].Rows[i]["TeamB"].ToString());
                                                }
                                                for (int k = 0; k < oldVnids.Length; k++)
                                                {
                                                    if (Convert.ToInt32(Dset.Tables[0].Rows[i]["VenueID"]) == Convert.ToInt32(oldVnids[k]))
                                                        Dset.Tables[0].Rows[i]["VenueID"] = newVnids[k];
                                                }
                                                for (int l = 0; l < oldcompids.Length; l++)
                                                {
                                                    if (Convert.ToInt32(Dset.Tables[0].Rows[i]["CompetitionID"]) == Convert.ToInt32(oldcompids[l]))
                                                        Dset.Tables[0].Rows[i]["CompetitionID"] = newcompids[l];
                                                }

                                            }
                                            foreach (DataRow dr in Dset.Tables[0].Rows)
                                            {
                                                FieldName = "";
                                                FieldValue = "";
                                                UpQuery = "";
                                                Condition = "";

                                                foreach (DataColumn dc in Dset.Tables[0].Columns)
                                                {
                                                    if (dc.ColumnName == "Date")
                                                    {
                                                        WriteToLog("Before converting date is: " + dr[dc]);
                                                        string converteddate = dr[dc].ToString();
                                                        dr[dc] = converteddate;

                                                        WriteToLog("After converting date is: " + dr[dc]);
                                                    }

                                                    if (dc.ColumnName.ToUpper() != "MATCHID")
                                                    {
                                                        if (UpQuery != "")
                                                            UpQuery = UpQuery + ",";

                                                        UpQuery = UpQuery + dc.ColumnName + "='" + dr[dc].ToString().Replace("'","''") + "'";
                                                    }

                                                    if (FieldName != "")
                                                        FieldName = FieldName + ",";
                                                    if (dc.ColumnName.ToUpper() != "MATCHID")
                                                    {
                                                        FieldName = FieldName + dc.ColumnName;
                                                    }

                                                    if (FieldValue != "")
                                                        FieldValue = FieldValue + "','";
                                                    if (dc.ColumnName.ToUpper() != "MATCHID")
                                                    {
                                                        FieldValue = FieldValue + dr[dc].ToString();
                                                    }


                                                }
                                                FieldValue = "'" + FieldValue + "'";
                                                Condition = " TeamA in(" + dr["TeamA"].ToString() + "," + dr["TeamB"].ToString() + ") and TeamB in(" + dr["TeamA"].ToString() + "," + dr["TeamB"].ToString() + ") and convert(varchar(50),date,1) ='" + dr["date"].ToString() + "'";

                                                Int32 Recount = Objbl.ExeQueryStrIntBL("Select count(*) from KB_Matches where " + Condition, 1);
                                                WriteToLog("Select count(*) from KB_Matches where " + Condition);
                                                if (Recount == 0)
                                                {
                                                    Matchid = Objbl.ExeQueryStrIntBL("Select isnull(max(MatchID),0)+1 from KB_Matches", 1);

                                                    FieldName = "Matchid," + FieldName;//old                                                        
                                                    FieldValue = Matchid.ToString() + "," + FieldValue;//old
                                                    newmatchid = Matchid;//old
                                                    MessageBox.Show("Insert into  KB_Matches (" + FieldName + ") Values (" + FieldValue + ")");
                                                    ImportMatchDataInsert("KB_Matches", FieldName, FieldValue);
                                                }
                                                else
                                                {
                                                    WriteToLog("Select MatchID from KB_Matches Where " + Condition);
                                                    Matchid = Objbl.ExeQueryStrIntBL("Select MatchID from KB_Matches Where " + Condition, 1);
                                                    ImportMatchDataUpdate("KB_Matches", UpQuery, Condition);
                                                    newmatchid = Matchid;
                                                }
                                            }
                                        }
                                    }
                                    else { MessageBox.Show("No Records in MATCH"); }
                                }

                                catch
                                {
                                    MessageBox.Show("Error On Matches");
                                }
                            }
                            break;

                        case "I.xml":
                            {
                                //MatchHalf
                                try
                                {
                                    DataSet Dset = new DataSet();
                                    Dset.ReadXml(FolderPath + "\\I.xml");
                                    if (Dset.Tables.Count > 0)
                                    {
                                        if (Dset.Tables[0].Rows.Count > 0)
                                        {
                                            for (int i = 0; i < Dset.Tables[0].Rows.Count; i++)
                                            {
                                                if (Matchid != Convert.ToInt32(Dset.Tables[0].Rows[i]["Matchid"]))
                                                {
                                                    Dset.Tables[0].Rows[i]["Matchid"] = Matchid;
                                                }
                                            }
                                            for (int i = 0; i < Dset.Tables[0].Rows.Count; i++)
                                            {
                                                for (int j = 0; j < oldclubids.Length; j++)
                                                {
                                                    if (Convert.ToInt32(Dset.Tables[0].Rows[i]["LeftClubID"]) == Convert.ToInt32(oldclubids[j]))
                                                        Dset.Tables[0].Rows[i]["LeftClubID"] = newclubids[j];
                                                    if (Convert.ToInt32(Dset.Tables[0].Rows[i]["RightClubID"]) == Convert.ToInt32(oldclubids[j]))
                                                        Dset.Tables[0].Rows[i]["RightClubID"] = newclubids[j];
                                                }
                                            }
                                            foreach (DataRow dr in Dset.Tables[0].Rows)
                                            {
                                                FieldName = "";
                                                FieldValue = "";
                                                UpQuery = "";
                                                Condition = "";

                                                foreach (DataColumn dc in Dset.Tables[0].Columns)
                                                {
                                                    if (UpQuery != "")
                                                        UpQuery = UpQuery + ",";
                                                    if (dc.ColumnName == "MatchID")
                                                        UpQuery = UpQuery + dc.ColumnName + "='" + Matchid.ToString() + "'";
                                                    else
                                                        UpQuery = UpQuery + dc.ColumnName + "='" + dr[dc].ToString() + "'";

                                                    if (FieldName != "")
                                                        FieldName = FieldName + ",";
                                                    FieldName = FieldName + dc.ColumnName;

                                                    if (FieldValue != "")
                                                        FieldValue = FieldValue + "','";

                                                    if (dc.ColumnName == "MatchID")
                                                        FieldValue = FieldValue + Matchid.ToString();
                                                    else
                                                        FieldValue = FieldValue + dr[dc].ToString();
                                                }
                                                FieldValue = "'" + FieldValue + "'";
                                                Condition = "Matchid =" + Matchid.ToString() + " and HalfId =" + dr["HalfId"].ToString();

                                                // Objbl = new BusinessLy();
                                                Int32 Recount = Objbl.ExeQueryStrIntBL("Select count(*) from MatchHalf where " + Condition, 1);
                                                if (Recount == 0)
                                                    ImportMatchDataInsert("MatchHalf", FieldName, FieldValue);
                                                else if (Recount > 0)
                                                    ImportMatchDataUpdate("MatchHalf", UpQuery, Condition);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No Records in Innings");
                                    }

                                }
                                catch
                                {
                                    MessageBox.Show("Error ON Innings");
                                }
                            }
                            break;

                        case "I1.xml":
                            {
                                //Lineups
                                try
                                {
                                    Dset = new DataSet();
                                    Dset.ReadXml(FolderPath + "\\I1.XML");
                                    if (Dset.Tables.Count > 0)
                                    {
                                        if (Dset.Tables[0].Rows.Count > 0)
                                        {
                                            for (int i = 0; i < Dset.Tables[0].Rows.Count; i++)
                                            {
                                                if (Matchid != Convert.ToInt32(Dset.Tables[0].Rows[i]["Matchid"]))
                                                {
                                                    Dset.Tables[0].Rows[i]["Matchid"] = Matchid;
                                                }
                                                for (int j = 0; j < oldids.Length; j++)
                                                {
                                                    try
                                                    {
                                                        if (Convert.ToInt32(Dset.Tables[0].Rows[i]["PlayerID"]) == Convert.ToInt32(oldids[j]))
                                                            Dset.Tables[0].Rows[i]["PlayerID"] = newids[j];
                                                    }
                                                    catch { }
                                                }
                                            }
                                            foreach (DataRow dr in Dset.Tables[0].Rows)
                                            {
                                                FieldName = "";
                                                FieldValue = "";
                                                UpQuery = "";
                                                Condition = "";

                                                foreach (DataColumn dc in Dset.Tables[0].Columns)
                                                {
                                                    if (UpQuery != "")
                                                        UpQuery = UpQuery + ",";
                                                    UpQuery = UpQuery + dc.ColumnName + "='" + dr[dc].ToString() + "'";

                                                    if (FieldName != "")
                                                        FieldName = FieldName + ",";
                                                    FieldName = FieldName + dc.ColumnName;

                                                    if (FieldValue != "")
                                                        FieldValue = FieldValue + "','";
                                                    FieldValue = FieldValue + dr[dc].ToString();
                                                }
                                                FieldValue = "'" + FieldValue + "'";
                                                Condition = "Matchid =" + Matchid.ToString() + " and PlayerID =" + dr["PlayerID"].ToString();

                                                Objbl = new BusinessLy();
                                                Int32 Recount = Objbl.ExeQueryStrIntBL("Select count(*) from Lineups where " + Condition, 1);
                                                if (Recount == 0)
                                                    ImportMatchDataInsert("Lineups", FieldName, FieldValue);
                                                else if (Recount > 0)
                                                    ImportMatchDataUpdate("Lineups", UpQuery, Condition);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No Records in Lineups");
                                    }
                                }
                                catch
                                {
                                    MessageBox.Show("Error in Lineups");
                                }
                            }
                            break;
                        case "J.xml":
                            {
                                //Raid
                                try
                                {
                                    Dset = new DataSet();
                                    Dset.ReadXml(FolderPath + "\\J.XML");
                                    if (Dset.Tables.Count > 0)
                                    {
                                        if (Dset.Tables[0].Rows.Count > 0)
                                        {
                                            for (int i = 0; i < Dset.Tables[0].Rows.Count; i++)
                                            {
                                                if (Matchid != Convert.ToInt32(Dset.Tables[0].Rows[i]["Matchid"]))
                                                {
                                                    Dset.Tables[0].Rows[i]["Matchid"] = Matchid;
                                                }
                                                for (int j = 0; j < oldids.Length; j++)
                                                {
                                                    try
                                                    {
                                                        if (Convert.ToInt32(Dset.Tables[0].Rows[i]["RaiderID"]) == Convert.ToInt32(oldids[j]))
                                                            Dset.Tables[0].Rows[i]["RaiderID"] = newids[j];
                                                    }
                                                    catch { }
                                                }
                                            }

                                            ImportMatchDataDelete("Raid", " Where Matchid=" + Matchid + "");

                                            foreach (DataRow dr in Dset.Tables[0].Rows)
                                            {
                                                FieldName = "";
                                                FieldValue = "";
                                                UpQuery = "";
                                                Condition = "";

                                                foreach (DataColumn dc in Dset.Tables[0].Columns)
                                                {
                                                    if (UpQuery != "")
                                                        UpQuery = UpQuery + ",";
                                                    UpQuery = UpQuery + dc.ColumnName + "='" + dr[dc].ToString() + "'";

                                                    if (FieldName != "")
                                                        FieldName = FieldName + ",";
                                                    FieldName = FieldName + (dc.ColumnName == "Escape" ? "[Escape]" : dc.ColumnName);

                                                    if (FieldValue != "")
                                                        FieldValue = FieldValue + "','";
                                                    FieldValue = FieldValue + dr[dc].ToString();
                                                }
                                                FieldValue = "'" + FieldValue + "'";
                                                Condition = "Matchid =" + Matchid.ToString() + " and HalfID =" + dr["HalfID"].ToString() + " and RaidNo=" + dr["RaidNo"].ToString();

                                                Objbl = new BusinessLy();
                                                Int32 Recount = Objbl.ExeQueryStrIntBL("Select count(*) from Raid where " + Condition, 1);
                                                if (Recount == 0)
                                                    ImportMatchDataInsert("Raid", FieldName, FieldValue);
                                                else if (Recount > 0)
                                                    ImportMatchDataUpdate("Raid", UpQuery, Condition);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No Records in Raid");
                                    }
                                }
                                catch
                                {
                                    MessageBox.Show("Error in Raid");
                                }
                            }
                            break;
                        case "J1.xml":
                            {
                                //Events
                                try
                                {
                                    Dset = new DataSet();
                                    Dset.ReadXml(FolderPath + "\\J1.XML");
                                    if (Dset.Tables.Count > 0)
                                    {
                                        if (Dset.Tables[0].Rows.Count > 0)
                                        {
                                            for (int i = 0; i < Dset.Tables[0].Rows.Count; i++)
                                            {
                                                if (Matchid != Convert.ToInt32(Dset.Tables[0].Rows[i]["Matchid"]))
                                                {
                                                    Dset.Tables[0].Rows[i]["Matchid"] = Matchid;
                                                }
                                                for (int j = 0; j < oldids.Length; j++)
                                                {
                                                    try
                                                    {
                                                        if (Convert.ToInt32(Dset.Tables[0].Rows[i]["Initiator"]) == Convert.ToInt32(oldids[j]))
                                                            Dset.Tables[0].Rows[i]["Initiator"] = newids[j];
                                                    }
                                                    catch { }
                                                }
                                            }
                                            ImportMatchDataDelete("Events", " Where Matchid=" + Matchid + "");
                                            foreach (DataRow dr in Dset.Tables[0].Rows)
                                            {
                                                FieldName = "";
                                                FieldValue = "";
                                                UpQuery = "";
                                                Condition = "";

                                                foreach (DataColumn dc in Dset.Tables[0].Columns)
                                                {
                                                    if (UpQuery != "")
                                                        UpQuery = UpQuery + ",";
                                                    UpQuery = UpQuery + dc.ColumnName + "='" + dr[dc].ToString() + "'";

                                                    if (FieldName != "")
                                                        FieldName = FieldName + ",";
                                                    FieldName = FieldName + dc.ColumnName;

                                                    if (FieldValue != "")
                                                        FieldValue = FieldValue + "','";
                                                    FieldValue = FieldValue + dr[dc].ToString();
                                                }
                                                FieldValue = "'" + FieldValue + "'";
                                                Condition = "Matchid =" + Matchid.ToString() + " and HalfID =" + dr["HalfID"].ToString() + " and RaidNo=" + dr["RaidNo"].ToString() + " and EventID=" + dr["EventID"].ToString();

                                                Objbl = new BusinessLy();
                                                Int32 Recount = Objbl.ExeQueryStrIntBL("Select count(*) from Events where " + Condition, 1);
                                                if (Recount == 0)
                                                    ImportMatchDataInsert("Events", FieldName, FieldValue);
                                                else if (Recount > 0)
                                                    ImportMatchDataUpdate("Events", UpQuery, Condition);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No Records in Events");
                                    }
                                }
                                catch
                                {
                                    MessageBox.Show("Error in Events");
                                }
                            }
                            break;

                        case "J2.xml":
                            {
                                //OutPlayer
                                try
                                {
                                    Dset = new DataSet();
                                    Dset.ReadXml(FolderPath + "\\J2.XML");
                                    if (Dset.Tables.Count > 0)
                                    {
                                        if (Dset.Tables[0].Rows.Count > 0)
                                        {
                                            for (int i = 0; i < Dset.Tables[0].Rows.Count; i++)
                                            {
                                                if (Matchid != Convert.ToInt32(Dset.Tables[0].Rows[i]["Matchid"]))
                                                {
                                                    Dset.Tables[0].Rows[i]["Matchid"] = Matchid;
                                                }
                                                for (int j = 0; j < oldids.Length; j++)
                                                {
                                                    try
                                                    {
                                                        if (Convert.ToInt32(Dset.Tables[0].Rows[i]["PlayerID"]) == Convert.ToInt32(oldids[j]))
                                                            Dset.Tables[0].Rows[i]["PlayerID"] = newids[j];
                                                    }
                                                    catch { }
                                                }
                                            }
                                            ImportMatchDataDelete("OutPlayer", " Where Matchid=" + Matchid + "");
                                            foreach (DataRow dr in Dset.Tables[0].Rows)
                                            {
                                                FieldName = "";
                                                FieldValue = "";
                                                UpQuery = "";
                                                Condition = "";

                                                foreach (DataColumn dc in Dset.Tables[0].Columns)
                                                {
                                                    if (UpQuery != "")
                                                        UpQuery = UpQuery + ",";
                                                    UpQuery = UpQuery + dc.ColumnName + "='" + dr[dc].ToString() + "'";

                                                    if (FieldName != "")
                                                        FieldName = FieldName + ",";
                                                    FieldName = FieldName + dc.ColumnName;

                                                    if (FieldValue != "")
                                                        FieldValue = FieldValue + "','";
                                                    FieldValue = FieldValue + dr[dc].ToString();
                                                }
                                                FieldValue = "'" + FieldValue + "'";
                                                Condition = "Matchid =" + Matchid.ToString() + " and HalfID =" + dr["HalfID"].ToString() + " and RaidNo=" + dr["RaidNo"].ToString() + " and EventID=" + dr["EventID"].ToString() + " and PlayerID=" + dr["PlayerID"].ToString();

                                                Objbl = new BusinessLy();
                                                Int32 Recount = Objbl.ExeQueryStrIntBL("Select count(*) from OutPlayer where " + Condition, 1);
                                                if (Recount == 0)
                                                    ImportMatchDataInsert("OutPlayer", FieldName, FieldValue);
                                                else if (Recount > 0)
                                                    ImportMatchDataUpdate("OutPlayer", UpQuery, Condition);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No Records in OutPlayer");
                                    }
                                }
                                catch
                                {
                                    MessageBox.Show("Error in OutPlayer");
                                }
                            }
                            break;
                        case "J3.xml":
                            {
                                //OutPlayerRef
                                try
                                {
                                    Dset = new DataSet();
                                    Dset.ReadXml(FolderPath + "\\J3.XML");
                                    if (Dset.Tables.Count > 0)
                                    {
                                        if (Dset.Tables[0].Rows.Count > 0)
                                        {
                                            for (int i = 0; i < Dset.Tables[0].Rows.Count; i++)
                                            {
                                                if (Matchid != Convert.ToInt32(Dset.Tables[0].Rows[i]["Matchid"]))
                                                {
                                                    Dset.Tables[0].Rows[i]["Matchid"] = Matchid;
                                                }
                                                for (int j = 0; j < oldids.Length; j++)
                                                {
                                                    try
                                                    {
                                                        if (Convert.ToInt32(Dset.Tables[0].Rows[i]["PlayerID"]) == Convert.ToInt32(oldids[j]))
                                                            Dset.Tables[0].Rows[i]["PlayerID"] = newids[j];
                                                    }
                                                    catch { }
                                                }
                                            }
                                            ImportMatchDataDelete("OutPlayerRef", " Where Matchid=" + Matchid + "");
                                            foreach (DataRow dr in Dset.Tables[0].Rows)
                                            {
                                                FieldName = "";
                                                FieldValue = "";
                                                UpQuery = "";
                                                Condition = "";

                                                foreach (DataColumn dc in Dset.Tables[0].Columns)
                                                {
                                                    if (UpQuery != "")
                                                        UpQuery = UpQuery + ",";
                                                    UpQuery = UpQuery + dc.ColumnName + "='" + dr[dc].ToString() + "'";

                                                    if (FieldName != "")
                                                        FieldName = FieldName + ",";
                                                    FieldName = FieldName + dc.ColumnName;

                                                    if (FieldValue != "")
                                                        FieldValue = FieldValue + "','";
                                                    FieldValue = FieldValue + dr[dc].ToString();
                                                }
                                                FieldValue = "'" + FieldValue + "'";
                                                Condition = "Matchid =" + Matchid.ToString() + " and HalfID =" + dr["HalfID"].ToString() + " and RaidNo=" + dr["RaidNo"].ToString() + " and PlayerID=" + dr["PlayerID"].ToString();

                                                Objbl = new BusinessLy();
                                                Int32 Recount = Objbl.ExeQueryStrIntBL("Select count(*) from OutPlayerRef where " + Condition, 1);
                                                if (Recount == 0)
                                                    ImportMatchDataInsert("OutPlayerRef", FieldName, FieldValue);
                                                else if (Recount > 0)
                                                    ImportMatchDataUpdate("OutPlayerRef", UpQuery, Condition);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No Records in OutPlayerRef");
                                    }
                                }
                                catch
                                {
                                    MessageBox.Show("Error in OutPlayerRef");
                                }
                            }
                            break;
                        case "J4.xml":
                            {
                                //SuspendedPlayer
                                try
                                {
                                    Dset = new DataSet();
                                    Dset.ReadXml(FolderPath + "\\J4.XML");
                                    if (Dset.Tables.Count > 0)
                                    {
                                        if (Dset.Tables[0].Rows.Count > 0)
                                        {
                                            for (int i = 0; i < Dset.Tables[0].Rows.Count; i++)
                                            {
                                                if (Matchid != Convert.ToInt32(Dset.Tables[0].Rows[i]["Matchid"]))
                                                {
                                                    Dset.Tables[0].Rows[i]["Matchid"] = Matchid;
                                                }
                                                for (int j = 0; j < oldids.Length; j++)
                                                {
                                                    try
                                                    {
                                                        if (Convert.ToInt32(Dset.Tables[0].Rows[i]["PlayerID"]) == Convert.ToInt32(oldids[j]))
                                                            Dset.Tables[0].Rows[i]["PlayerID"] = newids[j];
                                                    }
                                                    catch { }
                                                }
                                            }
                                            ImportMatchDataDelete("SuspendedPlayer", " Where Matchid=" + Matchid + "");
                                            foreach (DataRow dr in Dset.Tables[0].Rows)
                                            {
                                                FieldName = "";
                                                FieldValue = "";
                                                UpQuery = "";
                                                Condition = "";

                                                foreach (DataColumn dc in Dset.Tables[0].Columns)
                                                {
                                                    if (UpQuery != "")
                                                        UpQuery = UpQuery + ",";
                                                    UpQuery = UpQuery + dc.ColumnName + "='" + dr[dc].ToString() + "'";

                                                    if (FieldName != "")
                                                        FieldName = FieldName + ",";
                                                    FieldName = FieldName + dc.ColumnName;

                                                    if (FieldValue != "")
                                                        FieldValue = FieldValue + "','";
                                                    FieldValue = FieldValue + dr[dc].ToString();
                                                }
                                                FieldValue = "'" + FieldValue + "'";
                                                Condition = "Matchid =" + Matchid.ToString() + " and HalfID =" + dr["HalfID"].ToString() + " and RaidNo=" + dr["RaidNo"].ToString() + " and PlayerID=" + dr["PlayerID"].ToString();

                                                Objbl = new BusinessLy();
                                                Int32 Recount = Objbl.ExeQueryStrIntBL("Select count(*) from SuspendedPlayer where " + Condition, 1);
                                                if (Recount == 0)
                                                    ImportMatchDataInsert("SuspendedPlayer", FieldName, FieldValue);
                                                else if (Recount > 0)
                                                    ImportMatchDataUpdate("SuspendedPlayer", UpQuery, Condition);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No Records in SuspendedPlayer");
                                    }
                                }
                                catch
                                {
                                    MessageBox.Show("Error in SuspendedPlayer");
                                }
                            }
                            break;
                        case "J5.xml":
                            {
                                //Substitute
                                try
                                {
                                    Dset = new DataSet();
                                    Dset.ReadXml(FolderPath + "\\J5.XML");
                                    if (Dset.Tables.Count > 0)
                                    {
                                        if (Dset.Tables[0].Rows.Count > 0)
                                        {
                                            for (int i = 0; i < Dset.Tables[0].Rows.Count; i++)
                                            {
                                                if (Matchid != Convert.ToInt32(Dset.Tables[0].Rows[i]["Matchid"]))
                                                {
                                                    Dset.Tables[0].Rows[i]["Matchid"] = Matchid;
                                                }
                                                for (int j = 0; j < oldids.Length; j++)
                                                {
                                                    try
                                                    {
                                                        if (Convert.ToInt32(Dset.Tables[0].Rows[i]["PlayerID"]) == Convert.ToInt32(oldids[j]))
                                                            Dset.Tables[0].Rows[i]["PlayerID"] = newids[j];
                                                        if (Convert.ToInt32(Dset.Tables[0].Rows[i]["Subplayerid"]) == Convert.ToInt32(oldids[j]))
                                                            Dset.Tables[0].Rows[i]["Subplayerid"] = newids[j];
                                                    }
                                                    catch { }
                                                }
                                            }

                                            ImportMatchDataDelete("Substitute", " Where Matchid=" + Matchid + "");
                                            foreach (DataRow dr in Dset.Tables[0].Rows)
                                            {
                                                FieldName = "";
                                                FieldValue = "";
                                                UpQuery = "";
                                                Condition = "";

                                                foreach (DataColumn dc in Dset.Tables[0].Columns)
                                                {
                                                    if (UpQuery != "")
                                                        UpQuery = UpQuery + ",";
                                                    UpQuery = UpQuery + dc.ColumnName + "='" + dr[dc].ToString() + "'";

                                                    if (FieldName != "")
                                                        FieldName = FieldName + ",";
                                                    FieldName = FieldName + dc.ColumnName;

                                                    if (FieldValue != "")
                                                        FieldValue = FieldValue + "','";
                                                    FieldValue = FieldValue + dr[dc].ToString();
                                                }
                                                FieldValue = "'" + FieldValue + "'";
                                                Condition = "Matchid =" + Matchid.ToString() + " and HalfID =" + dr["HalfID"].ToString() + " and RaidNo=" + dr["RaidNo"].ToString() + " and PlayerID=" + dr["PlayerID"].ToString();

                                                Objbl = new BusinessLy();
                                                Int32 Recount = Objbl.ExeQueryStrIntBL("Select count(*) from Substitute where " + Condition, 1);
                                                if (Recount == 0)
                                                    ImportMatchDataInsert("Substitute", FieldName, FieldValue);
                                                else if (Recount > 0)
                                                    ImportMatchDataUpdate("Substitute", UpQuery, Condition);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No Records in SuspendedPlayer");
                                    }
                                }
                                catch
                                {
                                    MessageBox.Show("Error in SuspendedPlayer");
                                }
                            }
                            break;
                        case "J6.xml":
                            {
                                //Innerplayer
                                try
                                {
                                    Dset = new DataSet();
                                    Dset.ReadXml(FolderPath + "\\J6.XML");
                                    if (Dset.Tables.Count > 0)
                                    {
                                        if (Dset.Tables[0].Rows.Count > 0)
                                        {
                                            for (int i = 0; i < Dset.Tables[0].Rows.Count; i++)
                                            {
                                                if (Matchid != Convert.ToInt32(Dset.Tables[0].Rows[i]["Matchid"]))
                                                {
                                                    Dset.Tables[0].Rows[i]["Matchid"] = Matchid;
                                                }
                                                for (int j = 0; j < oldids.Length; j++)
                                                {
                                                    try
                                                    {
                                                        if (Convert.ToInt32(Dset.Tables[0].Rows[i]["PlayerID"]) == Convert.ToInt32(oldids[j]))
                                                            Dset.Tables[0].Rows[i]["PlayerID"] = newids[j];
                                                    }
                                                    catch { }
                                                }
                                            }

                                            ImportMatchDataDelete("Innerplayer", " Where Matchid=" + Matchid + "");
                                            foreach (DataRow dr in Dset.Tables[0].Rows)
                                            {
                                                FieldName = "";
                                                FieldValue = "";
                                                UpQuery = "";
                                                Condition = "";

                                                foreach (DataColumn dc in Dset.Tables[0].Columns)
                                                {
                                                    if (UpQuery != "")
                                                        UpQuery = UpQuery + ",";
                                                    UpQuery = UpQuery + dc.ColumnName + "='" + dr[dc].ToString() + "'";

                                                    if (FieldName != "")
                                                        FieldName = FieldName + ",";
                                                    FieldName = FieldName + dc.ColumnName;

                                                    if (FieldValue != "")
                                                        FieldValue = FieldValue + "','";
                                                    FieldValue = FieldValue + dr[dc].ToString();
                                                }
                                                FieldValue = "'" + FieldValue + "'";
                                                Condition = "Matchid =" + Matchid.ToString() + " and HalfID =" + dr["HalfID"].ToString() + " and RaidNo=" + dr["RaidNo"].ToString() + " and PlayerID=" + dr["PlayerID"].ToString();

                                                Objbl = new BusinessLy();
                                                Int32 Recount = Objbl.ExeQueryStrIntBL("Select count(*) from Innerplayer where " + Condition, 1);
                                                if (Recount == 0)
                                                    ImportMatchDataInsert("Innerplayer", FieldName, FieldValue);
                                                else if (Recount > 0)
                                                    ImportMatchDataUpdate("Innerplayer", UpQuery, Condition);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No Records in Innerplayer");
                                    }
                                }
                                catch
                                {
                                    MessageBox.Show("Error in Innerplayer");
                                }
                            }
                            break;
                        case "J7.xml":
                            {
                                //RaidSubjects
                                try
                                {
                                    Dset = new DataSet();
                                    Dset.ReadXml(FolderPath + "\\J7.XML");
                                    if (Dset.Tables.Count > 0)
                                    {
                                        if (Dset.Tables[0].Rows.Count > 0)
                                        {
                                            for (int i = 0; i < Dset.Tables[0].Rows.Count; i++)
                                            {
                                                if (Matchid != Convert.ToInt32(Dset.Tables[0].Rows[i]["Matchid"]))
                                                {
                                                    Dset.Tables[0].Rows[i]["Matchid"] = Matchid;
                                                }
                                                for (int j = 0; j < oldids.Length; j++)
                                                {
                                                    try
                                                    {
                                                        if (Convert.ToInt32(Dset.Tables[0].Rows[i]["PlayerID"]) == Convert.ToInt32(oldids[j]))
                                                            Dset.Tables[0].Rows[i]["PlayerID"] = newids[j];
                                                    }
                                                    catch { }
                                                }
                                            }
                                            ImportMatchDataDelete("RaidSubjects", " Where Matchid=" + Matchid + "");
                                            foreach (DataRow dr in Dset.Tables[0].Rows)
                                            {
                                                FieldName = "";
                                                FieldValue = "";
                                                UpQuery = "";
                                                Condition = "";

                                                foreach (DataColumn dc in Dset.Tables[0].Columns)
                                                {
                                                    if (UpQuery != "")
                                                        UpQuery = UpQuery + ",";
                                                    UpQuery = UpQuery + dc.ColumnName + "='" + dr[dc].ToString() + "'";

                                                    if (FieldName != "")
                                                        FieldName = FieldName + ",";
                                                    FieldName = FieldName + dc.ColumnName;

                                                    if (FieldValue != "")
                                                        FieldValue = FieldValue + "','";
                                                    FieldValue = FieldValue + dr[dc].ToString();
                                                }
                                                FieldValue = "'" + FieldValue + "'";
                                                Condition = "Matchid =" + Matchid.ToString() + " and HalfID =" + dr["HalfID"].ToString() + " and RaidNo=" + dr["RaidNo"].ToString() + " and SubId=" + dr["SubId"].ToString();

                                                Objbl = new BusinessLy();
                                                Int32 Recount = Objbl.ExeQueryStrIntBL("Select count(*) from RaidSubjects where " + Condition, 1);
                                                if (Recount == 0)
                                                    ImportMatchDataInsert("RaidSubjects", FieldName, FieldValue);
                                                else if (Recount > 0)
                                                    ImportMatchDataUpdate("RaidSubjects", UpQuery, Condition);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No Records in RaidSubjects");
                                    }
                                }
                                catch
                                {
                                    MessageBox.Show("Error in RaidSubjects");
                                }
                            }
                            break;
                        case "K1.xml":
                            {
                                //INPlayerList
                                try
                                {
                                    Dset = new DataSet();
                                    Dset.ReadXml(FolderPath + "\\K1.XML");
                                    if (Dset.Tables.Count > 0)
                                    {
                                        if (Dset.Tables[0].Rows.Count > 0)
                                        {
                                            for (int i = 0; i < Dset.Tables[0].Rows.Count; i++)
                                            {
                                                if (Matchid != Convert.ToInt32(Dset.Tables[0].Rows[i]["Matchid"]))
                                                {
                                                    Dset.Tables[0].Rows[i]["Matchid"] = Matchid;
                                                }
                                                for (int j = 0; j < oldids.Length; j++)
                                                {
                                                    try
                                                    {
                                                        if (Convert.ToInt32(Dset.Tables[0].Rows[i]["PlayerID"]) == Convert.ToInt32(oldids[j]))
                                                            Dset.Tables[0].Rows[i]["PlayerID"] = newids[j];
                                                    }
                                                    catch { }
                                                }
                                            }
                                            ImportMatchDataDelete("INPlayerList", " Where Matchid=" + Matchid + "");
                                            foreach (DataRow dr in Dset.Tables[0].Rows)
                                            {
                                                FieldName = "";
                                                FieldValue = "";
                                                UpQuery = "";
                                                Condition = "";

                                                foreach (DataColumn dc in Dset.Tables[0].Columns)
                                                {
                                                    if (UpQuery != "")
                                                        UpQuery = UpQuery + ",";
                                                    UpQuery = UpQuery + dc.ColumnName + "='" + dr[dc].ToString() + "'";

                                                    if (FieldName != "")
                                                        FieldName = FieldName + ",";
                                                    FieldName = FieldName + dc.ColumnName;

                                                    if (FieldValue != "")
                                                        FieldValue = FieldValue + "','";
                                                    FieldValue = FieldValue + dr[dc].ToString();
                                                }
                                                FieldValue = "'" + FieldValue + "'";
                                                Condition = " Matchid =" + Matchid.ToString() + " and RaidNo=" + dr["RaidNo"].ToString() + " and PlayerID=" + dr["PlayerID"].ToString();

                                                Objbl = new BusinessLy();
                                                Int32 Recount = Objbl.ExeQueryStrIntBL("Select count(*) from INPlayerList where " + Condition, 1);
                                                if (Recount == 0)
                                                    ImportMatchDataInsert("INPlayerList", FieldName, FieldValue);
                                                else if (Recount > 0)
                                                    ImportMatchDataUpdate("INPlayerList", UpQuery, Condition);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No Records in INPlayerList");
                                    }
                                }
                                catch
                                {
                                    MessageBox.Show("Error in INPlayerList");
                                }
                            }
                            break;
                        case "K2.xml":
                            {
                                //OutPlayerList
                                try
                                {
                                    Dset = new DataSet();
                                    Dset.ReadXml(FolderPath + "\\K2.XML");
                                    if (Dset.Tables.Count > 0)
                                    {
                                        if (Dset.Tables[0].Rows.Count > 0)
                                        {
                                            for (int i = 0; i < Dset.Tables[0].Rows.Count; i++)
                                            {
                                                if (Matchid != Convert.ToInt32(Dset.Tables[0].Rows[i]["Matchid"]))
                                                {
                                                    Dset.Tables[0].Rows[i]["Matchid"] = Matchid;
                                                }
                                                for (int j = 0; j < oldids.Length; j++)
                                                {
                                                    try
                                                    {
                                                        if (Convert.ToInt32(Dset.Tables[0].Rows[i]["PlayerID"]) == Convert.ToInt32(oldids[j]))
                                                            Dset.Tables[0].Rows[i]["PlayerID"] = newids[j];
                                                    }
                                                    catch { }
                                                }
                                            }
                                            ImportMatchDataDelete("OutPlayerList", " Where Matchid=" + Matchid + "");
                                            foreach (DataRow dr in Dset.Tables[0].Rows)
                                            {
                                                FieldName = "";
                                                FieldValue = "";
                                                UpQuery = "";
                                                Condition = "";

                                                foreach (DataColumn dc in Dset.Tables[0].Columns)
                                                {
                                                    if (UpQuery != "")
                                                        UpQuery = UpQuery + ",";
                                                    UpQuery = UpQuery + dc.ColumnName + "='" + dr[dc].ToString() + "'";

                                                    if (FieldName != "")
                                                        FieldName = FieldName + ",";
                                                    FieldName = FieldName + dc.ColumnName;

                                                    if (FieldValue != "")
                                                        FieldValue = FieldValue + "','";
                                                    FieldValue = FieldValue + dr[dc].ToString();
                                                }
                                                FieldValue = "'" + FieldValue + "'";

                                                Condition = " Matchid =" + Matchid.ToString() + " and RaidNo=" + dr["RaidNo"].ToString() + " and PlayerID=" + dr["PlayerID"].ToString();

                                                Objbl = new BusinessLy();
                                                Int32 Recount = Objbl.ExeQueryStrIntBL("Select count(*) from OutPlayerList where " + Condition, 1);
                                                if (Recount == 0)
                                                    ImportMatchDataInsert("OutPlayerList", FieldName, FieldValue);
                                                else if (Recount > 0)
                                                    ImportMatchDataUpdate("OutPlayerList", UpQuery, Condition);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No Records in OutPlayerList");
                                    }
                                }
                                catch
                                {
                                    MessageBox.Show("Error in OutPlayerList");
                                }
                            }
                            break;
                        case "L.xml":
                            {
                                //SwapPlayer
                                try
                                {
                                    Dset = new DataSet();
                                    Dset.ReadXml(FolderPath + "\\L.XML");
                                    if (Dset.Tables.Count > 0)
                                    {
                                        if (Dset.Tables[0].Rows.Count > 0)
                                        {
                                            for (int i = 0; i < Dset.Tables[0].Rows.Count; i++)
                                            {
                                                if (Matchid != Convert.ToInt32(Dset.Tables[0].Rows[i]["Matchid"]))
                                                {
                                                    Dset.Tables[0].Rows[i]["Matchid"] = Matchid;
                                                }
                                                for (int j = 0; j < oldids.Length; j++)
                                                {
                                                    try
                                                    {
                                                        if (Convert.ToInt32(Dset.Tables[0].Rows[i]["CurOutplayerId"]) == Convert.ToInt32(oldids[j]))
                                                            Dset.Tables[0].Rows[i]["CurOutplayerId"] = newids[j];
                                                        if (Convert.ToInt32(Dset.Tables[0].Rows[i]["CurInPlayerID"]) == Convert.ToInt32(oldids[j]))
                                                            Dset.Tables[0].Rows[i]["CurInPlayerID"] = newids[j];
                                                    }
                                                    catch { }
                                                }
                                            }
                                            ImportMatchDataDelete("SwapPlayer", " Where Matchid=" + Matchid + "");
                                            foreach (DataRow dr in Dset.Tables[0].Rows)
                                            {
                                                FieldName = "";
                                                FieldValue = "";
                                                UpQuery = "";
                                                Condition = "";

                                                foreach (DataColumn dc in Dset.Tables[0].Columns)
                                                {
                                                    if (UpQuery != "")
                                                        UpQuery = UpQuery + ",";
                                                    UpQuery = UpQuery + dc.ColumnName + "='" + dr[dc].ToString() + "'";

                                                    if (FieldName != "")
                                                        FieldName = FieldName + ",";
                                                    FieldName = FieldName + dc.ColumnName;

                                                    if (FieldValue != "")
                                                        FieldValue = FieldValue + "','";
                                                    FieldValue = FieldValue + dr[dc].ToString();
                                                }
                                                FieldValue = "'" + FieldValue + "'";

                                                Condition = " Matchid =" + Matchid.ToString() + " and RaidNo=" + dr["RaidNo"].ToString() + " and CurInPlayerID=" + dr["CurInPlayerID"].ToString();

                                                Objbl = new BusinessLy();
                                                Int32 Recount = Objbl.ExeQueryStrIntBL("Select count(*) from SwapPlayer where " + Condition, 1);
                                                if (Recount == 0)
                                                    ImportMatchDataInsert("SwapPlayer", FieldName, FieldValue);
                                                else if (Recount > 0)
                                                    ImportMatchDataUpdate("SwapPlayer", UpQuery, Condition);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No Records in SwapPlayer");
                                    }
                                }
                                catch
                                {
                                    MessageBox.Show("Error in SwapPlayer");
                                }
                            }
                            break;
                        case "M.xml":
                            {
                                //MatchResult
                                try
                                {
                                    Dset = new DataSet();
                                    Dset.ReadXml(FolderPath + "\\M.XML");
                                    if (Dset.Tables.Count > 0)
                                    {
                                        if (Dset.Tables[0].Rows.Count > 0)
                                        {
                                            for (int i = 0; i < Dset.Tables[0].Rows.Count; i++)
                                            {
                                                if (Matchid != Convert.ToInt32(Dset.Tables[0].Rows[i]["Matchid"]))
                                                {
                                                    Dset.Tables[0].Rows[i]["Matchid"] = Matchid;
                                                }
                                            }
                                            foreach (DataRow dr in Dset.Tables[0].Rows)
                                            {
                                                FieldName = "";
                                                FieldValue = "";
                                                UpQuery = "";
                                                Condition = "";

                                                foreach (DataColumn dc in Dset.Tables[0].Columns)
                                                {
                                                    if (UpQuery != "")
                                                        UpQuery = UpQuery + ",";
                                                    UpQuery = UpQuery + dc.ColumnName + "='" + dr[dc].ToString() + "'";

                                                    if (FieldName != "")
                                                        FieldName = FieldName + ",";
                                                    FieldName = FieldName + dc.ColumnName;

                                                    if (FieldValue != "")
                                                        FieldValue = FieldValue + "','";
                                                    FieldValue = FieldValue + dr[dc].ToString();
                                                }
                                                FieldValue = "'" + FieldValue + "'";
                                                Condition = "Matchid =" + Matchid.ToString() + " and Clubid =" + dr["Clubid"].ToString();

                                                Objbl = new BusinessLy();
                                                Int32 Recount = Objbl.ExeQueryStrIntBL("Select count(*) from MatchResult where " + Condition, 1);
                                                if (Recount == 0)
                                                    ImportMatchDataInsert("MatchResult", FieldName, FieldValue);
                                                else if (Recount > 0)
                                                    ImportMatchDataUpdate("MatchResult", UpQuery, Condition);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No Records in Lineups");
                                    }
                                }
                                catch
                                {
                                    MessageBox.Show("Error in Lineups");
                                }
                            }
                            break;
                        case "N.xml":
                            {
                                //Review
                                try
                                {
                                    Dset = new DataSet();
                                    Dset.ReadXml(FolderPath + "\\N.XML");
                                    if (Dset.Tables.Count > 0)
                                    {
                                        if (Dset.Tables[0].Rows.Count > 0)
                                        {
                                            for (int i = 0; i < Dset.Tables[0].Rows.Count; i++)
                                            {
                                                if (Matchid != Convert.ToInt32(Dset.Tables[0].Rows[i]["Matchid"]))
                                                {
                                                    Dset.Tables[0].Rows[i]["Matchid"] = Matchid;
                                                }
                                            }
                                            foreach (DataRow dr in Dset.Tables[0].Rows)
                                            {
                                                FieldName = "";
                                                FieldValue = "";
                                                UpQuery = "";
                                                Condition = "";

                                                foreach (DataColumn dc in Dset.Tables[0].Columns)
                                                {
                                                    if (dc.ColumnName != "AutoID")
                                                    {
                                                        if (UpQuery != "")
                                                            UpQuery = UpQuery + ",";
                                                        UpQuery = UpQuery + dc.ColumnName + "='" + dr[dc].ToString() + "'";

                                                        if (FieldName != "")
                                                            FieldName = FieldName + ",";
                                                        FieldName = FieldName + dc.ColumnName;

                                                        if (FieldValue != "")
                                                            FieldValue = FieldValue + "','";
                                                        FieldValue = FieldValue + dr[dc].ToString();
                                                    }
                                                }
                                                FieldValue = "'" + FieldValue + "'";
                                                Condition = "Matchid =" + Matchid.ToString() + " and Raidno =" + dr["Raidno"].ToString();

                                                Objbl = new BusinessLy();
                                                Int32 Recount = Objbl.ExeQueryStrIntBL("Select count(*) from Review where " + Condition, 1);
                                                if (Recount == 0)
                                                    ImportMatchDataInsert("Review", FieldName, FieldValue);
                                                else if (Recount > 0)
                                                    ImportMatchDataUpdate("Review", UpQuery, Condition);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No Records in Review");
                                    }
                                }
                                catch
                                {
                                    MessageBox.Show("Error in Review");
                                }
                            }
                            break;
                        case "O.xml":
                            {
                                //TimeOut
                                try
                                {
                                    Dset = new DataSet();
                                    Dset.ReadXml(FolderPath + "\\O.XML");
                                    if (Dset.Tables.Count > 0)
                                    {
                                        if (Dset.Tables[0].Rows.Count > 0)
                                        {
                                            for (int i = 0; i < Dset.Tables[0].Rows.Count; i++)
                                            {
                                                if (Matchid != Convert.ToInt32(Dset.Tables[0].Rows[i]["Matchid"]))
                                                {
                                                    Dset.Tables[0].Rows[i]["Matchid"] = Matchid;
                                                }
                                            }
                                            foreach (DataRow dr in Dset.Tables[0].Rows)
                                            {
                                                FieldName = "";
                                                FieldValue = "";
                                                UpQuery = "";
                                                Condition = "";

                                                foreach (DataColumn dc in Dset.Tables[0].Columns)
                                                {
                                                    if (dc.ColumnName != "AutoID")
                                                    {
                                                        if (UpQuery != "")
                                                            UpQuery = UpQuery + ",";
                                                        UpQuery = UpQuery + dc.ColumnName + "='" + dr[dc].ToString() + "'";

                                                        if (FieldName != "")
                                                            FieldName = FieldName + ",";
                                                        FieldName = FieldName + dc.ColumnName;

                                                        if (FieldValue != "")
                                                            FieldValue = FieldValue + "','";
                                                        FieldValue = FieldValue + dr[dc].ToString();
                                                    }
                                                }
                                                FieldValue = "'" + FieldValue + "'";
                                                Condition = "Matchid =" + Matchid.ToString() + " and Raidno =" + dr["Raidno"].ToString();

                                                Objbl = new BusinessLy();
                                                Int32 Recount = Objbl.ExeQueryStrIntBL("Select count(*) from TimeOut where " + Condition, 1);
                                                if (Recount == 0)
                                                    ImportMatchDataInsert("TimeOut", FieldName, FieldValue);
                                                else if (Recount > 0)
                                                    ImportMatchDataUpdate("TimeOut", UpQuery, Condition);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No Records in TimeOut");
                                    }
                                }
                                catch
                                {
                                    MessageBox.Show("Error in TimeOut");
                                }
                            }
                            break;
                        case "O1.xml":
                            {
                                //Othercard
                                try
                                {
                                    Dset = new DataSet();
                                    Dset.ReadXml(FolderPath + "\\O1.XML");
                                    if (Dset.Tables.Count > 0)
                                    {
                                        if (Dset.Tables[0].Rows.Count > 0)
                                        {
                                            for (int i = 0; i < Dset.Tables[0].Rows.Count; i++)
                                            {
                                                if (Matchid != Convert.ToInt32(Dset.Tables[0].Rows[i]["Matchid"]))
                                                {
                                                    Dset.Tables[0].Rows[i]["Matchid"] = Matchid;
                                                }
                                            }
                                            foreach (DataRow dr in Dset.Tables[0].Rows)
                                            {
                                                FieldName = "";
                                                FieldValue = "";
                                                UpQuery = "";
                                                Condition = "";

                                                foreach (DataColumn dc in Dset.Tables[0].Columns)
                                                {
                                                    if (dc.ColumnName != "AutoID")
                                                    {
                                                        if (UpQuery != "")
                                                            UpQuery = UpQuery + ",";
                                                        UpQuery = UpQuery + dc.ColumnName + "='" + dr[dc].ToString() + "'";

                                                         if (FieldName != "")
                                                            FieldName = FieldName + ",";
                                                         if (dc.ColumnName == "Team/Coach")
                                                             FieldName = FieldName + "["+dc.ColumnName+"]";
                                                         else
                                                             FieldName = FieldName + dc.ColumnName;

                                                        if (FieldValue != "")
                                                            FieldValue = FieldValue + "','";
                                                        FieldValue = FieldValue + dr[dc].ToString();
                                                    }
                                                }
                                                FieldValue = "'" + FieldValue + "'";
                                                Condition = "Matchid =" + Matchid.ToString() + " and Raidno =" + dr["Raidno"].ToString();

                                                Objbl = new BusinessLy();
                                                Int32 Recount = Objbl.ExeQueryStrIntBL("Select count(*) from Othercard where " + Condition, 1);
                                                if (Recount == 0)
                                                    ImportMatchDataInsert("Othercard", FieldName, FieldValue);
                                                else if (Recount > 0)
                                                    ImportMatchDataUpdate("Othercard", UpQuery, Condition);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No Records in Othercard");
                                    }
                                }
                                catch
                                {
                                    MessageBox.Show("Error in TimeOut");
                                }
                            }
                            break;
                    }
                }
            }
            MessageBox.Show("Import Successfully");
        }

        void ImportMatchDataDelete(string TableName, string Condition)
        {
            try
            {
                //Objbl = new BusinessLy();
                WriteToLog("Delete From " + TableName+" " + Condition, 1);
                if (Objbl.ExeQueryRetBooDL("Delete From " + TableName + " " + Condition, 1))
                {

                }
            }
            catch
            {

            }
        }

        void ImportMatchDataUpdate(string TableName, string UpdateValue, string Condition)
        {
            try
            {
                //Objbl = new BusinessLy();
                WriteToLog("Update " + TableName + " Set " + UpdateValue + " Where " + Condition, 1);
                if (Objbl.ExeQueryRetBooDL("Update " + TableName + " Set " + UpdateValue + " Where " + Condition, 1))
                {

                }
            }
            catch
            {

            }
        }


        void ImportMatchDataInsert(string TableName, string FieldsName, string FieldsValue)
        {
            try
            {
                //Objbl = new BusinessLy();
                WriteToLog("Insert into " + TableName + "(" + FieldsName + ") Values (" + FieldsValue + ")", 2);
                if (Objbl.ExeQueryRetBooDL("Insert into " + TableName + "(" + FieldsName + ") Values (" + FieldsValue + ")", 1))
                {

                }
            }
            catch
            {
            }
        
        }

        private string createNwXMLID(string oldplyrid, string oldplyrFnm, string oldplyrMnm, string oldplyrLnm, string dobo, int Gender, string SportID, string TeamID, string PickNo, string Role, string Country)
        {
            
            string newplyrID = "0";
            int reccount = Objbl.ExeQueryStrIntBL("Select count(*) from Player_Master where id = '" + oldplyrid + "'", 1);// And Firstname='" + oldplyrFnm + "' And LastName='" + oldplyrLnm + "'
            if (reccount > 0)
            {
                DataTable dtplyrIDcheck;
                dtplyrIDcheck = Objbl.ExeQueryStrRetDTBL("Select * from Player_Master where id = '" + oldplyrid + "'", 1);
                if (dtplyrIDcheck.Rows.Count > 0)
                {
                    if (dtplyrIDcheck.Rows[0]["Firstname"].ToString() == oldplyrFnm && dtplyrIDcheck.Rows[0]["Lastname"].ToString() == oldplyrLnm)
                    {
                        newplyrID = oldplyrid;
                        return newplyrID;
                    }
                    else
                    {
                        DataTable dtplyrNmcheck;
                        dtplyrNmcheck = Objbl.ExeQueryStrRetDTBL("Select * from Player_Master where Firstname = '" + oldplyrFnm + "' and Lastname = '" + oldplyrLnm + "'", 1);
                        if (dtplyrNmcheck.Rows.Count > 0)
                        {
                            newplyrID = dtplyrNmcheck.Rows[0]["ID"].ToString();
                            return newplyrID;
                        }
                        else
                        {
                            newplyrID = "0";
                            string query = "Insert into Player(ID,FirstName,MiddleName,LastName,DOB,Gender,SportID,TeamID,PickNo,Role,Country) values('" + oldplyrid + "','" + oldplyrFnm + "','" + oldplyrMnm + "','" + oldplyrLnm + "','" + dobo + "'," + Gender + "," + SportID + "," + TeamID + "," + (PickNo == "" ? "Null" : PickNo) + ",'" + Role + "','" + Country + "')";
                            WriteToLog(query, 3);
                            if (Objbl.ExeQueryRetBooDL(query, 1))
                                newplyrID = oldplyrid;
                            newplyrID = oldplyrid;
                            return newplyrID;
                        }
                    }
                }
            }
            else
            {
                DataTable dtplyrNmcheck;
                dtplyrNmcheck = Objbl.ExeQueryStrRetDTBL("Select * from player where Firstname = '" + oldplyrFnm + "' and Lastname = '" + oldplyrLnm + "'", 1);
                if (dtplyrNmcheck.Rows.Count > 0)
                {
                    newplyrID = dtplyrNmcheck.Rows[0]["ID"].ToString();
                    return newplyrID;
                }
                else
                {
                    newplyrID = "0";
                    string query = "Insert into Player(ID,FirstName,MiddleName,LastName,DOB,Gender,SportID,TeamID,PickNo,Role,Country) values('" + oldplyrid + "','" + oldplyrFnm + "','" + oldplyrMnm + "','" + oldplyrLnm + "','" + dobo + "'," + Gender + "," + SportID + "," + TeamID + "," + (PickNo == "" ? "Null" : PickNo) + ",'" + Role + "','" + Country + "')";
                    WriteToLog(query, 3);
                    if (Objbl.ExeQueryRetBooDL(query, 1))
                        newplyrID = oldplyrid;
                    newplyrID = oldplyrid;

                    return newplyrID;
                }
            }
            return newplyrID;
        }

        private string createNwClubID(string oldclubid, string oldclubnm, string oldprefix, string Country, string SportID)
        {
            string newclubID = "0";
            int reccount = Objbl.ExeQueryStrIntBL("Select count(*) from Team_Master where TeamID = '" + oldclubid + "'", 1);
            WriteToLog("Select count(*) from Team_Master where TeamID = '" + oldclubid + "';" + reccount);
            if (reccount > 0)
            {
                DataTable dtplyrIDcheck;
                dtplyrIDcheck = Objbl.ExeQueryStrRetDTBL("Select * from Team_Master where TeamID = '" + oldclubid + "'", 1);
                WriteToLog("id exists");
                WriteToLog("Select * from Team_Master where TeamID = '" + oldclubid + "'");
                if (dtplyrIDcheck.Rows.Count > 0)
                {
                    if (dtplyrIDcheck.Rows[0]["TeamName"].ToString() == oldclubnm && dtplyrIDcheck.Rows[0]["Prefix"].ToString() == oldprefix)
                    {
                        WriteToLog(newclubID);
                        newclubID = oldclubid;
                        return newclubID;
                    }
                    else
                    {
                        DataTable dtplyrNmcheck;
                        dtplyrNmcheck = Objbl.ExeQueryStrRetDTBL("Select * from Team_Master where TeamName = '" + oldclubnm + "' and Prefix = '" + oldprefix + "'", 1);
                        WriteToLog("Select * from Team_Master where TeamName = '" + oldclubnm + "' and Prefix = '" + oldprefix + "'; in" + dtplyrNmcheck.Rows.Count);
                        if (dtplyrNmcheck.Rows.Count > 0)
                        {
                            newclubID = dtplyrNmcheck.Rows[0]["ID"].ToString();
                            return newclubID;
                        }
                        else
                        {
                            newclubID = "0";
                            // INSERT QUERY LOGIC
                            WriteToLog("Insert into Team_Master(TeamID,TeamName,Prefix,Country,SportID)Values('" + oldclubnm + "','" + oldprefix + "','" + Country + "'," + SportID + "); ");
                            newclubID = Objbl.ExeQueryStrIntBL("Insert into Team_Master(TeamID,TeamName,Prefix,Country,SportID)Values('" + oldclubnm + "','" + oldprefix + "','" + Country + "'," + SportID + ");", 1).ToString();
                            return newclubID;
                        }
                    }
                }
            }
            else
            {
                DataTable dtplyrNmcheck;
                dtplyrNmcheck = Objbl.ExeQueryStrRetDTBL("Select * from Team_Master where TeamName = '" + oldclubnm + "' and Prefix = '" + oldprefix + "'", 1);
                WriteToLog("id not exists");
                WriteToLog("Select * from Team_Master where TeamName = '" + oldclubnm + "' and Prefix = '" + oldprefix + "';out" + dtplyrNmcheck.Rows.Count);
                if (dtplyrNmcheck.Rows.Count > 0)
                {
                    newclubID = dtplyrNmcheck.Rows[0]["ID"].ToString();
                    WriteToLog(newclubID);
                    return newclubID;
                }
                else
                {
                    newclubID = "0";
                    newclubID = Objbl.ExeQueryStrIntBL("Insert into Team_Master(TeamID,TeamName,Prefix,Country,SportID)Values('" + oldclubnm + "','" + oldprefix + "','" + Country + "'," + SportID + ");", 1).ToString();
                    WriteToLog("Insert into Team_Master(TeamID,TeamName,Prefix,Country,SportID)Values('" + oldclubnm + "','" + oldprefix + "','" + Country + "'," + SportID + "); ");
                    return newclubID;
                }
            }
            return newclubID;
        }

        private string createNwVenueID(string oldvenueid, string oldVnname, string city, string Country, string SportID)
        {
            string newVnID = "0";
            int reccount = Objbl.ExeQueryStrIntBL("Select count(*) from Venue_Master where id = '" + oldvenueid + "'", 1);
            if (reccount > 0)
            {
                DataTable dtplyrIDcheck;
                dtplyrIDcheck = Objbl.ExeQueryStrRetDTBL("Select * from Venue_Master where id = '" + oldvenueid + "'", 1);
                if (dtplyrIDcheck.Rows.Count > 0)
                {
                    if (dtplyrIDcheck.Rows[0]["name"].ToString() == oldVnname)
                    {
                        newVnID = oldvenueid;
                        return newVnID;
                    }
                    else
                    {
                        DataTable dtplyrNmcheck;
                        dtplyrNmcheck = Objbl.ExeQueryStrRetDTBL("Select * from Venue_Master where Name = '" + oldVnname + "'", 1);
                        if (dtplyrNmcheck.Rows.Count > 0)
                        {
                            newVnID = dtplyrNmcheck.Rows[0]["ID"].ToString();
                            return newVnID;
                        }
                        else
                        {
                            newVnID = "0";
                            newVnID = Objbl.ExeQueryStrIntBL("Insert into Venue_Master(ID,[Name],City,Country,SportID)Values(," + oldvenueid + ",'" + oldVnname + "','" + city + "'," + Country + "," + SportID + "); ", 1).ToString();
                            return newVnID;
                        }
                    }
                }
            }
            else
            {
                DataTable dtplyrNmcheck;
                dtplyrNmcheck = Objbl.ExeQueryStrRetDTBL("Select * from Venue_Master where Name = '" + oldVnname + "'", 1);
                if (dtplyrNmcheck.Rows.Count > 0)
                {
                    newVnID = dtplyrNmcheck.Rows[0]["ID"].ToString();
                    return newVnID;
                }
                else
                {
                    newVnID = "0";
                    newVnID = Objbl.ExeQueryStrIntBL("Insert into Venue_Master(ID,[Name],City,Country,SportID)Values(," + oldvenueid + ",'" + oldVnname + "','" + city + "'," + Country + "," + SportID + "); ", 1).ToString();
                    return newVnID;
                }
            }
            return newVnID;
        }

        private string createNwCompId(string oldcompid, int SportID, string oldcompname, string fromdateo, string todateo, int MatchTypeo)
        {
            string newCompID = "0";
            int reccount = Objbl.ExeQueryStrIntBL("Select count(*) from Competition where CompID = '" + oldcompid + "'", 1);
            if (reccount > 0)
            {
                DataTable dtplyrIDcheck;
                dtplyrIDcheck = Objbl.ExeQueryStrRetDTBL("Select * from Competition where CompID = '" + oldcompid + "'", 1);
                if (dtplyrIDcheck.Rows.Count > 0)
                {
                    if (dtplyrIDcheck.Rows[0]["name"].ToString() == oldcompname)
                    {
                        newCompID = oldcompid;
                        return newCompID;
                    }
                    else
                    {
                        DataTable dtplyrNmcheck;
                        dtplyrNmcheck = Objbl.ExeQueryStrRetDTBL("Select * from Competition where Name = '" + oldcompname + "'", 1);
                        if (dtplyrNmcheck.Rows.Count > 0)
                        {
                            newCompID = dtplyrNmcheck.Rows[0]["CompID"].ToString();
                            return newCompID;
                        }
                        else
                        {
                            newCompID = "0"; string query = "Insert into Competition(CompID,SportID,Name,Fromdate,Todate,MatchType) Values(" + oldcompid + "," + SportID + ",'" + oldcompname + "','" + fromdateo + "','" + todateo + "'," + MatchTypeo + ");";
                            newCompID = Objbl.ExeQueryStrIntBL(query, 1).ToString();
                            return newCompID;
                        }
                    }
                }
            }
            else
            {
                DataTable dtplyrNmcheck;
                dtplyrNmcheck = Objbl.ExeQueryStrRetDTBL("Select * from Competition where Name = '" + oldcompname + "'", 1);
                if (dtplyrNmcheck.Rows.Count > 0)
                {
                    newCompID = dtplyrNmcheck.Rows[0]["CompID"].ToString();
                    return newCompID;
                }
                else
                {
                    newCompID = "0";
                    string query = string.Empty;
                    query = "Insert into Competition(CompID,SportID,Name,Fromdate,Todate,MatchType) Values(" + oldcompid + "," + SportID + ",'" + oldcompname + "','" + fromdateo + "','" + todateo + "'," + MatchTypeo + ");";
                    WriteToLog(query);
                    if (Objbl.ExeQueryRetBooDL(query, 1))
                        newCompID = oldcompid;
                    return newCompID;
                }
            }
            return newCompID;
        }
        
        public void WriteToLog(string text)
        {
            string sTemp = Application.StartupPath + "\\KabaddiVenue_Log_" + DateTime.Now.ToString("dd_MM") + ".txt";
            FileStream Fs = new FileStream(sTemp, FileMode.OpenOrCreate | FileMode.Append);
            StreamWriter st = new StreamWriter(Fs);
            string dttemp = DateTime.Now.ToString("[dd:MM:yyyy] [HH:mm:ss:ffff]"); //"[" + DateTime.Now.Day + ":" + DateTime.Now.Month + ":" + DateTime.Now.Year + "] [" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + ":" + DateTime.Now.Millisecond + "]";
            st.WriteLine(dttemp + "\t" + text);
            st.Close();
        }

        public void WriteToLog(string text, int count)
        {
            if (count == 1)
            {
                string sTemp = Application.StartupPath + "\\Log.txt";
                FileStream Fs = new FileStream(sTemp, FileMode.OpenOrCreate | FileMode.Append);
                StreamWriter st = new StreamWriter(Fs);
                string dttemp = DateTime.Now.ToString("[dd:MM:yyyy] [HH:mm:ss:ffff]"); //"[" + DateTime.Now.Day + ":" + DateTime.Now.Month + ":" + DateTime.Now.Year + "] [" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + ":" + DateTime.Now.Millisecond + "]";
                st.WriteLine(dttemp + "\t" + text);
                st.Close();
            }
            else if (count == 2)
            {
                string sTemp = Application.StartupPath + "\\Insert.txt";
                FileStream Fs = new FileStream(sTemp, FileMode.OpenOrCreate | FileMode.Append);
                StreamWriter st = new StreamWriter(Fs);
                string dttemp = DateTime.Now.ToString("[dd:MM:yyyy] [HH:mm:ss:ffff]"); //"[" + DateTime.Now.Day + ":" + DateTime.Now.Month + ":" + DateTime.Now.Year + "] [" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + ":" + DateTime.Now.Millisecond + "]";
                st.WriteLine(dttemp + "\t" + text);
                st.Close();
            }
            else if (count == 3)
            {
                string sTemp = Application.StartupPath + "\\PlayerInsert.txt";
                FileStream Fs = new FileStream(sTemp, FileMode.OpenOrCreate | FileMode.Append);
                StreamWriter st = new StreamWriter(Fs);
                string dttemp = DateTime.Now.ToString("[dd:MM:yyyy] [HH:mm:ss:ffff]"); //"[" + DateTime.Now.Day + ":" + DateTime.Now.Month + ":" + DateTime.Now.Year + "] [" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + ":" + DateTime.Now.Millisecond + "]";
                st.WriteLine(dttemp + "\t" + text);
                st.Close();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                MiD = Convert.ToInt32(cmbmatch.SelectedValue);
                string FolderPath = "";
                browsebox.ShowDialog();
                FolderPath = browsebox.SelectedPath.ToString();

                if (FolderPath != "")
                {
                    DataTable dt = new DataTable();
                    dt = Objbl.ExeQueryStrRetDTBL("Select distinct(Halfid) from MatchHalf where matchid = " + cmbmatch.SelectedValue, 1);
                    string madate = Objbl.ExeQueryStrRetStrBL("select 'Match#'+CAST(Matchid as Nvarchar(10)) from KB_Matches where Matchid=" + cmbmatch.SelectedValue, 1);
                    if (dt.Rows.Count > 0)
                    {
                        FolderPath = FolderPath + "\\" + madate + "\\";
                        if (System.IO.Directory.Exists(FolderPath))
                        {
                            System.IO.Directory.Delete(FolderPath, true);
                        }
                        string path = "";
                        path = FolderPath + "\\";
                        System.IO.Directory.CreateDirectory(FolderPath);
                        System.IO.Directory.CreateDirectory(path);
                        ExportMatchData(MiD, path);
                        MessageBox.Show("Export Successfully");
                    }
                    else
                        MessageBox.Show("No Records Related to the match");
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        private void ExportMatchData(int Matchid, string FolderPath)
        {
            try
            {

                #region Xml Table list
                //A - EventMaster
                //B - Stage
                //C - Player
                //D - Clubs
                //E0 - Tournament
                //E1 - COMPETITION
                //F - Venue
                //G0 - CompetitionTeam
                //G1 - CompetitionSquad
                //H - matches
                //I - MatchHalf
                //I1 - Lineups
                //J - Raid
                //J1 - Events
                //J2 - OutPlayer
                //J3 - OutPlayerRef
                //J4 - SuspendedPlayer 
                //J5 - Substitute
                //J6 - Innerplayer
                //k1 - INPlayerList
                //k2 - OutPlayerList
                //L - SwapPlayer
                #endregion


                ExportXML("select * from EventMaster", FolderPath + "\\A");

                ExportXML("select * from Stage", FolderPath + "\\B");

                ExportXML("select Id,FirstName,MiddleName,LastName,FORMAT(CAST(DOB as DATETIME),'yyyy-MM-dd') DOB,Gender,SportID,TeamID,PickNo,Role,Country from Player_Master Where id in(select PlayerID from Lineups Where Matchid=" + Matchid + ")", FolderPath + "\\C");

                ExportXML("select cl1.* from KB_Matches ma inner join Team_Master cl1 on cl1.TeamID = ma.TeamA where ma.MatchID=" + Matchid + " union select cl2.* from KB_Matches ma inner join Team_Master cl2 on cl2.TeamID = ma.TeamB where ma.MatchID=" + Matchid, FolderPath + "\\D");

                ExportXML("Select comp.CompID,comp.SportID,comp.Name,convert(varchar,comp.FromDate,22)FromDate,convert(varchar,comp.Todate,22)Todate,comp.MatchType from competition comp inner join KB_Matches ma on comp.CompID=ma.competitionid where ma.MatchID=" + Matchid, FolderPath + "\\E1");

                ExportXML("select st.ID,st.Name,Isnull(st.City,'')City,st.Country,st.SportID from KB_Matches ma inner join Venue_Master st on ma.VenueID=st.id where ma.MatchID=" + Matchid, FolderPath + "\\F");

                ExportXML("select comp.* from CompetitionTeam comp inner join KB_Matches ma on comp.CompId=ma.competitionid where ma.MatchID=" + Matchid, FolderPath + "\\G0");

                ExportXML("select comp.* from CompetitionSquad comp inner join KB_Matches ma on comp.CompId=ma.competitionid where ma.MatchID=" + Matchid, FolderPath + "\\G1");


                ExportXML("select MatchID,convert(varchar,date,1)Date,TeamA,TeamB,VenueID,MatchTypeID,StageType,Competitionid,ClubAColor,ClubBColor,refMatchid,QCUpdate,ManoftheMatch1,ManoftheMatch2,MatchNo,MatchGroup,HomeTeamid from KB_Matches where MatchID=" + Matchid, FolderPath + "\\H");

                ExportXML("select Matchid,HalfID,LeftClubID,RightClubID,TossWin,Description,HalfStart,HalfEnd,convert(varchar,StartTime,22)StartTime,convert(varchar,EndTime,22)EndTime from MatchHalf Where Matchid=" + Matchid, FolderPath + "\\I");

                ExportXML("select * from Lineups Where Matchid=" + Matchid, FolderPath + "\\I1");

                ExportXML("Select MatchID,HalfID,RaidNo,RaiderID,BonusLine,BLPX,BLPY,Outcome,SuperRaid,SuperTackle,DoorDie,RaiderOutType,[Escape],Allout,convert(varchar,StartTime,22)Starttime,convert(varchar,Endtime,22)Endtime,Startframe,Endframe,TimerStart,TimerEnd,RaiderCard,RaidNoNew,RaidDIP,DefDIP,TeamRaidNo,PlayerRaidNo,AllPlayerRaidno,raidpoint,defencepoint,Time,RaidByRaidScore,Raidingtime,IsDeclare from Raid where matchid=" + Matchid + " and Outcome IS Not Null", FolderPath + "\\J");
                ExportXML("Select * from Events where matchid=" + Matchid, FolderPath + "\\J1");
                ExportXML("Select * from OutPlayer where matchid=" + Matchid, FolderPath + "\\J2");
                ExportXML("Select * from OutPlayerRef where matchid=" + Matchid, FolderPath + "\\J3");
                ExportXML("Select * from SuspendedPlayer where matchid=" + Matchid, FolderPath + "\\J4");
                ExportXML("Select * from Substitute where matchid=" + Matchid, FolderPath + "\\J5");
                ExportXML("Select * from Innerplayer where matchid=" + Matchid, FolderPath + "\\J6");
                ExportXML("Select * from RaidSubjects where matchid=" + Matchid, FolderPath + "\\J7");
                ExportXML("Select * from INPlayerList where matchid=" + Matchid, FolderPath + "\\K1");
                ExportXML("Select * from OutPlayerList where matchid=" + Matchid, FolderPath + "\\K2");
                ExportXML("Select * from SwapPlayer where matchid=" + Matchid, FolderPath + "\\L");
                ExportXML("Select * from MatchResult where matchid=" + Matchid, FolderPath + "\\M");
                ExportXML("Select * from Review where matchid=" + Matchid, FolderPath + "\\N");
                ExportXML("Select * from Timeout where matchid=" + Matchid, FolderPath + "\\O");
                ExportXML("Select * from Othercard where matchid=" + Matchid, FolderPath + "\\O1");
            }
            catch
            {

            }
        }


        void ExportXML(string Query, string FileName)
        {
            try
            {
                //Objbl = new BusinessLy();
                Dset = new DataSet();
                Dset = Objbl.ExeQueryStrRetDsBL(Query, 1);
                Dset.WriteXml(FileName + ".xml");
            }
            catch
            {

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
