using OtherSports_DataPushing.Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Runtime.InteropServices;
using System.Security.Principal;


namespace OtherSports_DataPushing
{
    public partial class FrmDBBackup : Form
    {
        BusinessLy objMB = new BusinessLy();
        public FrmDBBackup()
        {
            InitializeComponent();
        }
        private void btnPath1_Click(object sender, EventArgs e)
        {

            saveFileDialog1.Filter = "Text files (*.bak)|*.bak|All files (*.*)|*.*";
            saveFileDialog1.FileName = strBuild.InitialCatalog + "_" + DateTime.Now.ToString("dd-MMM-yy") + "_" + DateTime.Now.ToString("h-mm tt") + ".bak";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtPath1.Text = saveFileDialog1.FileName;
            }
        }

        private void btnPath2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text files (*.bak)|*.bak|All files (*.*)|*.*";
            saveFileDialog1.FileName = strBuild.InitialCatalog + "_" + DateTime.Now.ToString("dd-MMM-yy") + "_" + DateTime.Now.ToString("h-mm tt") + ".bak";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtPath2.Text = saveFileDialog1.FileName;
            }
        }
        SqlConnectionStringBuilder strBuild = new SqlConnectionStringBuilder();

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            if (txtPath1.Text == "" && txtPath2.Text == "")
            {
                MessageBox.Show("Select Path1 & Path2", "Kabaddi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string InputPath = txtPath1.Text+@"\" + strBuild.InitialCatalog + "_" + DateTime.Now.ToString("dd-MMM-yy") + "_" + DateTime.Now.ToString("h-mm tt") + ".bak";
            if (objMB.ExeQueryRetBooDL("Backup database " + strBuild.InitialCatalog + " to disk='" + txtPath1.Text + "'", 1))
            {
                label3.Visible = true;
                label3.ForeColor = Color.LimeGreen;
                label3.Text = "Database BackUp has been created successful";
            }
            else
            {
                label3.Visible = true;
                label3.Text = "Database BackUp has been created Fail";
                return;
            }
            //if (txtPath1.Text != string.Empty)
            //{
            //    // if (Directory.Exists(InputPath))
            //    {
            //        System.IO.File.Copy(InputPath, txtPath1.Text, true);
            //    }
            //}
            if (txtPath2.Text != string.Empty)
            {
                // if (Directory.Exists(InputPath))
                {
                    System.IO.File.Copy(InputPath, txtPath2.Text, true);
                }
            }
        }

        private void FrmDBBackup_Load(object sender, EventArgs e)
        {
            //strBuild.ConnectionString = ConfigurationManager.AppSettings["ConnectString"];
            strBuild.ConnectionString = ConfigurationManager.AppSettings["ConnectString"];
           
        }
    }
}
