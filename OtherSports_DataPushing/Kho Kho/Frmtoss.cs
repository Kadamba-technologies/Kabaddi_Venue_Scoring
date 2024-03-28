using OtherSports_DataPushing.Layer;
using OtherSports_DataPushing.Volley_Ball;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtherSports_DataPushing.Kho_Kho
{
    public partial class Frmtoss : Form
    {
        BusinessLy objMB = new BusinessLy();
        DataTable DT;
        public Frmtoss()
        {
            InitializeComponent();
        }

        private void Frmtoss_Load(object sender, EventArgs e)
        {
            try
            {
                DT = objMB.ExeQueryStrRetDTBL("select Distinct ClubID ID,[dbo].[fn_GetTeamName](ClubID) Name from KK_Lineup where MatchID=" + mycommon.MatchId, 1);
                cbtoss.DataSource = DT;
                cbtoss.DisplayMember = "Name";
                cbtoss.ValueMember = "ID";
                cbtoss.SelectedIndex = -1;
            }
            catch { }
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            if (cbtoss.Text != null)
            {
                mycommon.tossteamid = Convert.ToInt32(cbtoss.SelectedValue);
                FrmKhoKho Objfrm = new FrmKhoKho();
                Objfrm.Show();
                this.Dispose(true);
            }
        }
    }
}
