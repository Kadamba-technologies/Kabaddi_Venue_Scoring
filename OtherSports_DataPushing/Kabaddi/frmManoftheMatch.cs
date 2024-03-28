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

namespace OtherSports_DataPushing.Kabaddi
{
    public partial class frmManoftheMatch : Form
    {
        MasterDL obj = new MasterDL();
        DataTable dt;
        int indexField = 0;
        public frmManoftheMatch()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (lsPlayer.SelectedItems.Count <= 2)
            {
                try
                {
                    obj = new MasterDL();
                    int plIndex = 0;
                    string player1 = string.Empty;
                    string player2 = string.Empty;
                    foreach (DataRowView drView in lsPlayer.SelectedItems)
                    {
                        if (plIndex == 1)
                            player2 = Convert.ToString(drView["playerid"]);
                        else
                        {
                            player1 = Convert.ToString(drView["playerid"]);
                            plIndex++;
                        }
                    }
                    if (obj.ExeQueryRetBooDL("Update KB_Matches Set ManOftheMatch1='" + player1 + "',ManOftheMatch2='" + player2 + "' Where MatchId=" + CommonCls.MatchId, 1))
                    {
                        try
                        {
                            int cnt = obj.ExeQueryStrDL("Select ISNULL(Count(*),0)+1 From tblCorrectedTable where Matchid=" + CommonCls.MatchId + " And tablename='KB_Matches'", 1);
                            obj.ExeQueryRetBooDL("Insert into tblCorrectedTable (Matchid,[count],tablename,SaveTime,IsInsert,Isupdate,Isdelete)values(" + CommonCls.MatchId + "," + cnt + ",'KB_Matches','" + System.DateTime.Now + "',0,1,0)", 1);
                        }
                        catch { }
                        MessageBox.Show("Man of the Match Update sucessfully", "Kabaddi21", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                    }
                }
                catch
                {

                }
            }
            else
            {
                MessageBox.Show("Selected Player is more than two");
            }
        }

        void loadInplayerList(string Filter)
        {
            try
            {
                dt = new DataTable();
                dt = obj.ExeQueryStrRetDTDL("Select L.playerid,CAST(L.JercyNo AS VARCHAR(5))+' - '+CAST(CASE when P.firstname is Null or P.firstname='' Then P.Lastname else P.firstname END AS VARCHAR(20))+'('+dbo.fn_getTeamnameprefix(L.clubid)+')' AS firstname,L.JercyNo   from lineups L INNER JOIN Player_Master P ON L.Playerid=P.id WHERE L.matchid=" + CommonCls.MatchId + " " + Filter + "", 1);
                lsPlayer.DataSource = dt;
                lsPlayer.DisplayMember = "firstname";
                lsPlayer.ValueMember = "playerid";
            }
            catch { }
        }
        private void frmManoftheMatch_Load(object sender, EventArgs e)
        {
            loadInplayerList("");

            rbTeamA.Text = CommonCls.Club1Prefix;
            rbTeamB.Text = CommonCls.Club2Prefix;
        }

        private void lsPlayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsPlayer.SelectedItems.Count <= 2)
            {

            }
            else
            {
                int n_false = lsPlayer.SelectedIndex;
                lsPlayer.SetSelected(n_false, false);
                indexField = 0;
            }
        }

        private void rbTeamPlayerFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTeamA.Checked)
            {
                loadInplayerList(" And L.ClubID=" + CommonCls.ClubId1);
            }
            else if (rbTeamB.Checked)
            {
                loadInplayerList(" And L.ClubID=" + CommonCls.ClubId2);
            }
            else
            {
                loadInplayerList("");
            }
        }
    }
}
