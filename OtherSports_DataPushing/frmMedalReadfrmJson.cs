using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtherSports_DataPushing
{
    public partial class frmMedalReadfrmJson : Form
    {
        public frmMedalReadfrmJson()
        {
            InitializeComponent();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            //string contents;
            //using (var wc = new System.Net.WebClient())
            //    contents = wc.DownloadString("http://beta-kheloindia.sportz.io/registration/api/Medal/Get_KI_Medal_Feed");


            //var deser = new JavaScriptSerializer().Deserialize<RootObject_KheloIndia>(contents);

            //foreach (KheloIndia KI in deser.KheloIndia)
            //{

            //}

            //List<RootObject_KheloIndia> UserList = new JavaScriptSerializer().Deserialize<List<RootObject_KheloIndia>>(contents);

        }
    }
}
