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
    public partial class frmPitchmapRegion : Form
    {
        MasterDL objDL = new MasterDL();
        public frmPitchmapRegion()
        {
            InitializeComponent();
        }

        private void pnlPitchMap_MouseClick(object sender, MouseEventArgs e)
        {
            txtRegion.Text = "X : " + e.X + " , Y : " + e.Y;
            textBox1.Text = objDL.ExeQueryStrRetStrDL("Select dbo.Fn_GetPitchmapRegion_details( " + e.X + "," + e.Y + ",1)", 1);          
        }

        private void frmPitchmapRegion_Load(object sender, EventArgs e)
        {

        }
    }
}
