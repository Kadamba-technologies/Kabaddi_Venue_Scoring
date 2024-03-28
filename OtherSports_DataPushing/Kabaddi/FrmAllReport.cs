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
using OtherSports_DataPushing.Kabaddi;

namespace OtherSports_DataPushing
{
    public partial class FrmAllReport : Form
    {
        BusinessLy objMB = new BusinessLy();
        int ID = 0;
        DataTable DT;
        DataTable DT1;
        Boolean pageload = false;

        public FrmAllReport()
        {
            InitializeComponent();
        }

        private void FrmAllReport_Load(object sender, EventArgs e)
        {
            try
            {
                BindData();
                pageload = true;
            }
            catch
            { }
        }

        void BindData()
        {
            try
            {
                cbComeptition.DataSource = objMB.ExeQueryStrRetDTBL("Select CompID ID,Name from competition", 1);
                cbComeptition.DisplayMember = "Name";
                cbComeptition.ValueMember = "ID";
                cbComeptition.SelectedIndex = -1;
            }
            catch
            { }
        }

        private void cbComeptition_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!pageload) { return; }
                DT1 = new DataTable();
                DT1 = objMB.ExeQueryStrRetDTBL("select Distinct TeamId ID, dbo.fn_GetTeamName(TeamId)Name from(select TeamA TeamId from KB_Matches where CompetitionID=" + cbComeptition.SelectedValue + " Union select TeamB TeamId from KB_Matches where CompetitionID=" + cbComeptition.SelectedValue + ")A order by Name", 1);
                if (DT1.Rows.Count > 0)
                {
                    cbTeams.DataSource =DT1;
                    cbTeams.DisplayMember = "Name";
                    cbTeams.ValueMember = "ID";
                    cbTeams.SelectedIndex = -1;
                }
            }
            catch
            { }
        }

        private void cbTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!pageload) { return; }
                DT = new DataTable();
                DT = objMB.ExeQueryStrRetDTBL("Select distinct P.id,(firstname+' '+lastname) as name  from Player_Master P Inner Join Lineups L ON P.Id=L.PlayerId Inner Join KB_Matches M ON L.MatchID=M.MatchID and (L.ClubID=M.TeamA Or L.ClubID=M.TeamB) where M.CompetitionID=" + cbComeptition.SelectedValue + " and L.ClubID=" + cbTeams.SelectedValue + " order by name asc", 1);
                if (DT.Rows.Count > 0)
                {
                    chklbPlayer.DataSource = DT;
                    chklbPlayer.DisplayMember = "name";
                    chklbPlayer.ValueMember = "ID";
                    chklbPlayer.SelectedIndex = -1;

                    DT = new DataTable();
                    DT = objMB.ExeQueryStrRetDTBL("select MatchID ID,dbo.fn_GetMatchNameDate_KB(MatchID) +'-'+Cast(MatchID as varchar) Name from KB_Matches where CompetitionID=" + cbComeptition.SelectedValue + " And (TeamA=" + cbTeams.SelectedValue + " OR TeamB=" + cbTeams.SelectedValue + ")", 1);
                    if (DT.Rows.Count > 0)
                    {
                        chklbMatches.DataSource = DT;
                        chklbMatches.DisplayMember = "name";
                        chklbMatches.ValueMember = "ID";
                        chklbMatches.SelectedIndex = -1;
                    }
                }
                else
                {
                    chklbPlayer.DataSource = null;
                      DT = new DataTable();
                      DT = objMB.ExeQueryStrRetDTBL("select MatchID ID,dbo.fn_GetMatchNameDate_KB(MatchID) +'-'+Cast(MatchID as varchar) Name from KB_Matches where CompetitionID=" + cbComeptition.SelectedValue + " And (TeamA=" + cbTeams.SelectedValue + " OR TeamB=" + cbTeams.SelectedValue + ")", 1);
                    if (DT.Rows.Count > 0)
                    {
                        chklbMatches.DataSource = DT;
                        chklbMatches.DisplayMember = "name";
                        chklbMatches.ValueMember = "ID";
                    }
                    else
                    {
                        chklbMatches.DataSource = null;
                    }
                }
            }
            catch
            { }
        }

        private void chkAllPlayer_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllPlayer.Checked == true)
            {
                for (int index = 0; index < chklbPlayer.Items.Count; ++index)
                {
                    chklbPlayer.SetItemChecked(index, true);
                }
            }
            else
            {
                for (int index = 0; index < chklbPlayer.Items.Count; ++index)
                {
                    chklbPlayer.SetItemChecked(index, false);
                }
            }
        }

        private void chkAllMatches_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllMatches.Checked == true)
            {
                for (int index = 0; index < chklbMatches.Items.Count; ++index)
                {
                    chklbMatches.SetItemChecked(index, true);
                }
            }
            else
            {
                for (int index = 0; index < chklbMatches.Items.Count; ++index)
                {
                    chklbMatches.SetItemChecked(index, false);
                }
            }
        }

        private void TxtPlayerFilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                objMB = new BusinessLy();
                DT = new DataTable();
                if (TxtPlayerFilter.Text != "")
                    DT = objMB.ExeQueryStrRetDTBL("Select distinct P.id,(firstname+' '+lastname) as name  from player P Inner Join Lineup L ON P.Id=L.PlayerId Inner Join KB_Matches M ON L.MatchID=M.MatchID and (L.ClubID=M.TeamA Or L.ClubID=M.TeamB) where CompetitionID=" + cbComeptition.SelectedValue + " and L.ClubID=" + cbTeams.SelectedValue + " and (firstname+' '+lastname) like '%" + TxtPlayerFilter.Text + "%' order by name asc ", 1);
                else
                    DT = objMB.ExeQueryStrRetDTBL("Select distinct P.id,(firstname+' '+lastname) as name  from player P Inner Join Lineup L ON P.Id=L.PlayerId Inner Join KB_Matches M ON L.MatchID=M.MatchID and (L.ClubID=M.TeamA Or L.ClubID=M.TeamB) where CompetitionID=" + cbComeptition.SelectedValue + " and L.ClubID=" + cbTeams.SelectedValue + " order by name asc", 1);

                if (DT.Rows.Count > 0)
                {
                    chklbPlayer.DataSource = DT;
                    chklbPlayer.DisplayMember = "name";
                    chklbPlayer.ValueMember = "ID";
                    chklbPlayer.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Player Not Found", "Kabaddi Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {

            }
        }

        int FindPlayerId(string Name)
        {
            try
            {
                int Playerid = objMB.ExeQueryStrIntBL("Select ID from Player Where  (firstname+' '+lastname)='" + Name + "' Or (firstname+' '+lastname) like '%" + Name + "%'", 1);
                return Playerid;
            }
            catch
            {
                return 0;
            }
        }

        int FindMatchId(string Name)
        {
            try
            {
                int MatchId = objMB.ExeQueryStrIntBL("select MatchID from KB_Matches where dbo.fn_GetMatchNameDate_KB(MatchID)='" + Name + "' Or dbo.fn_GetMatchNameDate_KB(MatchID) like '%" + Name + "%'", 1);
                return MatchId;
            }
            catch
            {
                return 0;
            }
        }

        int FindEventId(string Name)
        {
            try
            {
                int EventId = objMB.ExeQueryStrIntBL("Select ID from Event Where Description='" + Name + "' Or Description like '%" + Name + "%'", 1);
                return EventId;
            }
            catch
            {
                return 0;
            }
        }

        bool bonus = false;
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            Condition = ""; PlayerList = ""; MatchList = ""; EventList = ""; HalfList = ""; OutComeList = "";
            bonus = false;
            if (!rbBonus.Checked && !rbRadierEvents.Checked && !rbdefenderEvents.Checked)
                MessageBox.Show("Select Filter by.");
            if(chklbPlayer.Items.Count<=0)
            {
                MessageBox.Show("Select Player", "Kabaddi Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (chklbMatches.Items.Count <= 0)
            {
                MessageBox.Show("Select Match", "Kabaddi Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Condition = " Where ";
            
            //if (rbdefenderEvents.Checked == true)
            //{
            //    Condition = Condition + " EventGroup in (";
            //    foreach (int x in chklbEvent.CheckedIndices)
            //    {
            //        chklbEvent.SelectedIndex = x;
            //        EventList = EventList + ",'" + chklbEvent.SelectedValue.ToString() + "'";
            //    }
            //    EventList = EventList.Trim(',');
            //    Condition = Condition + EventList + " ) And";
            //}
            //else 
                if (rbRadierEvents.Checked == true)
            {
                foreach (int x in chklbEvent.CheckedIndices)
                {
                    chklbEvent.SelectedIndex = x;
                    if (chklbEvent.SelectedValue.ToString() == "100")
                        bonus = true;
                    else
                        EventList = EventList + "," + chklbEvent.SelectedValue.ToString();
                }

                //if (bonus && EventList != string.Empty)
                //    Condition = Condition + "( R.Bonusline=1 or";
                //else
                //    Condition = Condition + " R.Bonusline=1 AND ";
                if (EventList != string.Empty)
                {
                    Condition = Condition + " OP.OutType in (";
                    EventList = EventList.Trim(',');
                    //if (bonus)
                    //    Condition = Condition + EventList + ")) And";
                    //else
                        Condition = Condition + EventList + ") And";
                }

                foreach (int x in chklbPlayer.CheckedIndices)
                {
                    chklbPlayer.SelectedIndex = x;
                    PlayerList = PlayerList + "," + chklbPlayer.SelectedValue.ToString();
                }
                if (PlayerList != string.Empty)
                {
                    Condition = Condition + " R.RaiderID in (";
                    PlayerList = PlayerList.Trim(',');
                    Condition = Condition + PlayerList + ") And";
                }
            }
            else if (rbdefenderEvents.Checked == true)
            {
                foreach (int x in chklbEvent.CheckedIndices)
                {
                    chklbEvent.SelectedIndex = x;
                    EventList = EventList + "," + chklbEvent.SelectedValue.ToString();
                }
                if (EventList != string.Empty)
                {
                    Condition = Condition + " OP.OutType in (";
                    EventList = EventList.Trim(',');
                    Condition = Condition + EventList + ") And";
                }

                foreach (int x in chklbPlayer.CheckedIndices)
                {
                    chklbPlayer.SelectedIndex = x;
                    PlayerList = PlayerList + "," + chklbPlayer.SelectedValue.ToString();
                }
                if (PlayerList != string.Empty)
                {
                    Condition = Condition + " OP.PlayerID in (";
                    PlayerList = PlayerList.Trim(',');
                    Condition = Condition + PlayerList + ") And";
                }
            }
            else if (rbBonus.Checked == true)
            {
                Condition = Condition + " R.Bonusline=1 And";

                foreach (int x in chklbPlayer.CheckedIndices)
                {
                    chklbPlayer.SelectedIndex = x;
                    PlayerList = PlayerList + "," + chklbPlayer.SelectedValue.ToString();
                }
                if (PlayerList != string.Empty)
                {
                    Condition = Condition + " R.RaiderId in (";
                    PlayerList = PlayerList.Trim(',');
                    Condition = Condition + PlayerList + ") And";
                }
            }
            Condition = Condition + " R.MatchId in(";
            foreach (int x in chklbMatches.CheckedIndices)
            {
                chklbMatches.SelectedIndex = x;
                MatchList = MatchList + "," + chklbMatches.SelectedValue.ToString();
            }
            MatchList = MatchList.Trim(',');
            Condition = Condition +MatchList+") And R.HalfID in(";

            if(ChkQ1.Checked)
            {
                HalfList = HalfList + ",1";
            }
            if (ChkQ2.Checked)
            {
                HalfList =HalfList+ ",2";
            }
            if (ChkQAll.Checked || HalfList.Trim()=="")
            {
                HalfList = "1,2";
                ChkQAll.Checked = true;
            }
            HalfList = HalfList.Trim(',');
            Condition = Condition + HalfList + ") And R.OutCome in(";

            if (chkSuccess.Checked)
            {
                OutComeList = OutComeList + ",12,13,14";
            }
            if (chkUnSuccess.Checked)
            {
                OutComeList = OutComeList + ",15";
            }
            if (chkEmpty.Checked)
            {
                OutComeList = OutComeList + ",16";
            }
            if (chkOutcomeAll.Checked || OutComeList.Trim() == "")
            {
                OutComeList = "12,13,14,15,16";
                chkOutcomeAll.Checked = true;
            }
            OutComeList = OutComeList.Trim(',');
            Condition = Condition + OutComeList + ") ";

            PitchMark(Condition);
        }
        string Condition = "", PlayerList = "", MatchList = "", EventList = "", HalfList = "", OutComeList="";

        Label lbl = new Label();
        void PitchMark(string Condition)
        {
            int PX = 0, PY = 0, GX = 0, GY = 0;
            pnlPitchMap.Refresh();
            DT = new DataTable();
            if (rbdefenderEvents.Checked)
                DT = objMB.ExeQueryStrRetDTBL("SELECT MAX(E.PX)PX,MAX(E.PY)PY FROM Raid R LEFT JOIN Events E ON R.MatchID=E.MatchID AND R.RaidNo=E.RaidNo LEFT JOIN OutPlayer OP ON R.MatchID=OP.MatchID AND R.RaidNo=OP.RaidNo AND E.EventId=OP.EventID " + Condition + " AND E.PX IS NOT NULL Group By R.Raidno", 1);
            else if (rbBonus.Checked || (EventList == "" && bonus))
                DT = objMB.ExeQueryStrRetDTBL("SELECT MAX(R.BLPX)PX,MAX(R.BLPY)PY FROM Raid R LEFT JOIN Events E ON R.MatchID=E.MatchID AND R.RaidNo=E.RaidNo LEFT JOIN OutPlayer OP ON R.MatchID=OP.MatchID AND R.RaidNo=OP.RaidNo AND E.EventId=OP.EventID " + Condition + " And Bonusline=1 AND R.BLPX IS NOT NULL Group By R.Raidno", 1);
            else if (rbRadierEvents.Checked)
                DT = objMB.ExeQueryStrRetDTBL("SELECT MAX(E.PX)PX,MAX(E.PY)PY FROM Raid R LEFT JOIN Events E ON R.MatchID=E.MatchID AND R.RaidNo=E.RaidNo LEFT JOIN OutPlayer OP ON R.MatchID=OP.MatchID AND R.RaidNo=OP.RaidNo AND E.EventId=OP.EventID " + Condition + " AND E.PX IS NOT NULL Group By R.Raidno " + (bonus ? " Union All SELECT R.BLPX PX,R.BLPY PY FROM Raid R LEFT JOIN Events E ON R.MatchID=E.MatchID AND R.RaidNo=E.RaidNo LEFT JOIN OutPlayer OP ON R.MatchID=OP.MatchID AND R.RaidNo=OP.RaidNo AND E.EventId=OP.EventID " + Condition.Replace("OP.OutType in (" + EventList + ") And", "") + " And Bonusline=1 AND R.BLPX IS NOT NULL" : "") + "", 1);


            if (DT.Rows.Count > 0)
            {
                for (int i = 0; i < DT.Rows.Count; i++)
                {
                    #region Hockey Pitch
                    {
                        PX = Convert.ToInt32(DT.Rows[i]["PX"]);
                        PY = Convert.ToInt32(DT.Rows[i]["PY"]);
                        Brush brshGreen = new SolidBrush(Color.White);
                        //if (Convert.ToInt32(DT.Rows[i]["EventTypeID"]) == 12)
                        //    brshGreen = new SolidBrush(Color.Lime);
                        //else if (Convert.ToInt32(DT.Rows[i]["EventTypeID"]) == 29)
                        //    brshGreen = new SolidBrush(Color.Yellow);
                        //else if (Convert.ToInt32(DT.Rows[i]["EventTypeID"]) == 30)
                        //    brshGreen = new SolidBrush(Color.Fuchsia);
                        //else if (Convert.ToInt32(DT.Rows[i]["EventTypeID"]) == 38)
                        //    brshGreen = new SolidBrush(Color.Aqua);
                        Graphics g = pnlPitchMap.CreateGraphics();
                        FontFamily fam = new FontFamily("Verdana");
                        Font font = new System.Drawing.Font(fam, 8, FontStyle.Bold);

                        g.DrawString("X", font, brshGreen, new Point(PX - 4, PY - 4));
                    }
                    #endregion
                }
            }

            DT = new DataTable();
            if (rbdefenderEvents.Checked)
                DT = objMB.ExeQueryStrRetDTBL("Select  Region,count(*)Cnt from(SELECT dbo.Fn_GetPitchmapRegion(MAX(E.PX),MAX(E.PY),1)Region FROM Raid R LEFT JOIN Events E ON R.MatchID=E.MatchID AND R.RaidNo=E.RaidNo LEFT JOIN OutPlayer OP ON R.MatchID=OP.MatchID AND R.RaidNo=OP.RaidNo AND E.EventId=OP.EventID " + Condition + " AND E.PX IS NOT NULL Group By R.Raidno)A where Region is NOT NULL GROUP BY Region ", 1);
            else if (rbBonus.Checked || (EventList == "" && bonus))
                DT = objMB.ExeQueryStrRetDTBL("Select  Region,count(*)Cnt from(SELECT dbo.Fn_GetPitchmapRegion(R.BLPX,R.BLPY,1)Region FROM Raid R LEFT JOIN Events E ON R.MatchID=E.MatchID AND R.RaidNo=E.RaidNo LEFT JOIN OutPlayer OP ON R.MatchID=OP.MatchID AND R.RaidNo=OP.RaidNo AND E.EventId=OP.EventID " + Condition + " AND R.BLPX IS NOT NULL )A where Region is NOT NULL GROUP BY Region ", 1);
            else if (rbRadierEvents.Checked)
                DT = objMB.ExeQueryStrRetDTBL("Select  Region,count(*)Cnt from(SELECT dbo.Fn_GetPitchmapRegion(MAX(E.PX),MAX(E.PY),1)Region FROM Raid R LEFT JOIN Events E ON R.MatchID=E.MatchID AND R.RaidNo=E.RaidNo LEFT JOIN OutPlayer OP ON R.MatchID=OP.MatchID AND R.RaidNo=OP.RaidNo AND E.EventId=OP.EventID " + Condition + " AND E.PX IS NOT NULL Group By R.Raidno  " + (bonus ? " Union All SELECT dbo.Fn_GetPitchmapRegion(R.BLPX,R.BLPY,1) FROM Raid R LEFT JOIN Events E ON R.MatchID=E.MatchID AND R.RaidNo=E.RaidNo LEFT JOIN OutPlayer OP ON R.MatchID=OP.MatchID AND R.RaidNo=OP.RaidNo AND E.EventId=OP.EventID " + Condition.Replace("OP.OutType in (" + EventList + ") And", "") + " AND R.BLPX IS NOT NULL " : "") + ")A where Region is NOT NULL GROUP BY Region ", 1);
            //  DT = objMB.ExeQueryStrRetDTBL("SELECT MAX(E.PX)PX,MAX(E.PY)PY FROM Raid R LEFT JOIN Events E ON R.MatchID=E.MatchID AND R.RaidNo=E.RaidNo LEFT JOIN OutPlayer OP ON R.MatchID=OP.MatchID AND R.RaidNo=OP.RaidNo AND E.EventId=OP.EventID " + Condition + " AND E.PX IS NOT NULL Group By R.Raidno " + (bonus ? " Union All SELECT R.BLPX PX,R.BLPY PY FROM Raid R LEFT JOIN Events E ON R.MatchID=E.MatchID AND R.RaidNo=E.RaidNo LEFT JOIN OutPlayer OP ON R.MatchID=OP.MatchID AND R.RaidNo=OP.RaidNo AND E.EventId=OP.EventID " + Condition + "  AND E.PX IS NOT NULL" : "") + "", 1);

            foreach (Control control1 in panel2.Controls)
            {
                if (control1 is Label)
                    if (((Label)control1).Name.Contains("lblRegion"))
                        ((Label)control1).Text = "0";
            }
            foreach (DataRow dr in DT.Rows)
            {

                foreach (Control control in panel2.Controls)
                {
                    if (control is Label)
                    {
                        if (((Label)control).Name == "lblRegion" + dr["Region"].ToString())
                            ((Label)control).Text = dr["Cnt"].ToString();
                    }
                }

            }
        }

        private void chklbMatches_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            for (int index = 0; index < chklbEvent.Items.Count; ++index)
            {
                chklbEvent.SetItemChecked(index, false);
            }
        }

        private void rbEvents_CheckedChanged(object sender, EventArgs e)
        {
            lblFilterName.Text = "Events";
            chklbEvent.Visible = true;
            lblFilterName.Visible = true;
            btnClear.Visible = true;
            chkAllEvents.Visible = true;
            chkAllEvents.Checked = false;
            try
            {
                if (!pageload) { return; }

                DT = new DataTable();
                if(rbRadierEvents.Checked)
                    DT = objMB.ExeQueryStrRetDTBL("select ID,EventName Name From EventMaster  where EventGroup in('Touch') Union All select 100,'BounusLine' Name ", 1);
                else if (rbdefenderEvents.Checked)
                    DT = objMB.ExeQueryStrRetDTBL("select ID,EventName Name From EventMaster  where EventGroup in('Tackle')", 1);
                if (DT.Rows.Count > 0)
                {
                    chklbEvent.DataSource = DT;
                    chklbEvent.DisplayMember = "name";
                    chklbEvent.ValueMember = "ID";
                    chklbEvent.SelectedIndex = -1;
                }
            }
            catch
            { }
        }

        private void PlayerReport_Click(object sender, EventArgs e)
        {

        }

        private void rbEventGroup_CheckedChanged(object sender, EventArgs e)
        {
            lblFilterName.Text = "Event Group";
            chklbEvent.Visible = true;
            lblFilterName.Visible = true;
            btnClear.Visible = true;
            try
            {
                if (!pageload) { return; }

                DT = new DataTable();
                DT = objMB.ExeQueryStrRetDTBL("select Distinct [EventGroup] Name  From EventMaster where [EventGroup] is not null", 1);
                if (DT.Rows.Count > 0)
                {
                    chklbEvent.DataSource = DT;
                    chklbEvent.DisplayMember = "Name";
                    chklbEvent.ValueMember = "Name";
                    chklbEvent.SelectedIndex = -1;
                }
            }
            catch
            { }
        }
        
        private void btnReset_Click(object sender, EventArgs e)
        {
            cbComeptition.SelectedIndex = -1;
            cbTeams.SelectedIndex = -1;
            for (int index = 0; index < chklbPlayer.Items.Count; ++index)
            {
                chklbPlayer.SetItemChecked(index, false);
            }
            for (int index = 0; index < chklbMatches.Items.Count; ++index)
            {
                chklbMatches.SetItemChecked(index, false);
            }
            for (int index = 0; index < chklbEvent.Items.Count; ++index)
            {
                chklbEvent.SetItemChecked(index, false);
            }
        }

        private void ChkQ1_CheckedChanged(object sender, EventArgs e)
        {
            //if(ChkQAll.Checked)
            //{
            //    ChkQAll.Checked = false;
            //}
        }

        private void ChkQ2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void ChkQ3_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void ChkQ4_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void ChkQAll_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkQAll.Checked)
            {
                ChkQ1.Checked = true;
                ChkQ2.Checked = true;
            }
            else
            {
                ChkQ1.Checked = false;
                ChkQ2.Checked = false;
            }
        }

        private void chklbPlayer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rbBonus_CheckedChanged(object sender, EventArgs e)
        {
            chklbEvent.Visible = false;
            lblFilterName.Visible = false;
            btnClear.Visible = false;
            chkAllEvents.Visible = false;
        }

        private void chkAllEvents_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllEvents.Checked == true)
            {
                for (int index = 0; index < chklbEvent.Items.Count; ++index)
                {
                    chklbEvent.SetItemChecked(index, true);
                }
            }
            else
            {
                for (int index = 0; index < chklbEvent.Items.Count; ++index)
                {
                    chklbEvent.SetItemChecked(index, false);
                }
            }
        }

        private void chkOutcomeAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOutcomeAll.Checked)
            {
                chkSuccess.Checked = true;
                chkUnSuccess.Checked = true;
                chkEmpty.Checked = true;
            }
            else
            {
                chkSuccess.Checked = false;
                chkUnSuccess.Checked = false; 
                chkEmpty.Checked = false; 
            }
        }

        private void btnPitch_Click(object sender, EventArgs e)
        {
            frmPitchmapRegion frm = new frmPitchmapRegion();
            frm.Show();
        }
    }
}
