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

namespace OtherSports_DataPushing.BadMinton
{
    public partial class FrmQC : Form
    {
        BusinessLy objMB = new BusinessLy();
        DataTable DT;
        public FrmQC()
        {
            InitializeComponent();
        }
        private void FrmQC_Load(object sender, EventArgs e)
        {
            bindgrid();
        }

        void bindgrid()
        {
            try
            {
                DataTable dt = new DataTable();
                DataTable dtt = new DataTable();
                dt = objMB.ExeQueryStrRetDTBL("select GameID,PointID,dbo.[fn_GetTeamName](WinnerID) WinnerID,dbo.[fn_GetTeamName](ServerID) ServerID,TeamAPoint,TeamBPoint from BM_Events where MatchID="+mycommon.MatchId+" order by GameID Desc,PointID Desc", 2);
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                    }
                    gvpointtable.DataSource = dt;
                    foreach (DataGridViewRow row in gvpointtable.Rows)
                    {
                        string Matchid = row.Cells["Matchid"].Value.ToString().Trim();
                        dtt = objMB.ExeQueryStrRetDTBL("select distinct bowlerid,bowlername from fullbowlercard where matchid=" + Matchid + "", 2);
                        DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)(row.Cells["Bowlername"]);
                        cell.DataSource = dtt;
                        cell.DisplayMember = "bowlername";
                        cell.ValueMember = "bowlerid";
                    }
                }
                catch
                {
                }
            }
            catch
            {
            }
        }
    }
}
