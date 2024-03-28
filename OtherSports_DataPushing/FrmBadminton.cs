using OtherSports_DataPushing.Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtherSports_DataPushing
{
    public partial class FrmBadminton : Form
    {
        BusinessLy objMB = new BusinessLy();
        DataTable DT;
        public FrmBadminton()
        {
            InitializeComponent();
        }

        private void FrmBadminton_Load(object sender, EventArgs e)
        {
            binddata();
        }
        void binddata()
        {
            try
            {
                DT = new DataTable();
                DT = objMB.ExeQueryStrRetDTBL("", 1);
            }
            catch
            {

            }
        }
    }
}
