using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtherSports_DataPushing
{
    public partial class FrmHome : Form
    {
        string Appname = "";
        public FrmHome()
        {
            InitializeComponent();
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                string[] s = assembly.FullName.Split(',');
               //this.Text = s[0] + " - " + s[1].Replace('=', ' ');

                this.Text = s[0] +"-"+ "Junior Kabaddi V-1";

        }

        private void pbSport_Click(object sender, EventArgs e)
        {
            Appname = Convert.ToString(((PictureBox)sender).Name);
            string[] AA = Appname.Split('_');
            mycommon.ApplicationName = AA[0].Replace("pb", "");
            mycommon.SportID = Convert.ToInt32(AA[1]);
            FrmMDIparent frm = new FrmMDIparent();
            frm.Show();
            this.Hide();
        }

        private void FrmHome_Load(object sender, EventArgs e)
        {

        }

        private void FrmHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            Environment.Exit(-1);
        }

        private void pbMedal_0_Click(object sender, EventArgs e)
        {
            frmMedalEntry frm = new frmMedalEntry();
            frm.Show();
            this.Hide();
        }
    }
}
