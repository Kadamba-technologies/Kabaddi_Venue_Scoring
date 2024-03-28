using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vizrt.VizCommunication;

namespace OtherSports_DataPushing.Kabaddi
{
    public partial class FrmManualScore : Form
    {
        SendToSMM SendCollection;
        TcpClient tcpClient;
        string TCPIP = "", SPName = "", AppLoc = "", Viz_Scene = "";
        string[] strsplit = { "", "" };
        int TCPPort = 6189, TCPClientPort = 6100, FlagId = 0, RowCount = 0, LangID = 1;
        Boolean IpConnectL1 = false, IpConnectL2 = false, FirstLoopL1 = true, FirstLoopL2 = true;

        public FrmManualScore()
        {
            InitializeComponent();
            TCPIP = ConfigurationSettings.AppSettings["TcpHostIPPrimary"].ToString();
            TCPPort = Convert.ToInt32(ConfigurationSettings.AppSettings["TcpHostPort"].ToString());
            TCPClientPort = Convert.ToInt32(ConfigurationSettings.AppSettings["TCPClientPort"].ToString());
            ConnectionInitialize();
        }
        public FrmManualScore(string teamAname, string teamBname, string teamAscore, string teamBscore)
        {
            InitializeComponent();
            txtteamAname_man.Text = teamAname;
            txtteamBname_man.Text = teamBname;
            txtteamAscore.Text = teamAscore;
            txtteamBscore.Text = teamBscore;
            if (!IsValidIp(TCPIP))
            {
                MessageBox.Show("Given IP Address1 not connected..."); IpConnectL1 = false; return;
            }
            ConnectionInitialize();
        }
        public bool IsValidIp(string addr)
        {
            IPAddress ip;
            bool valid = !string.IsNullOrEmpty(addr) && IPAddress.TryParse(addr, out ip);
            return valid;
        }

        void ConnectionInitialize()
        {
            //if (CommonCls.EnableSendvizData == 0) { return; }
            SendCollection = new SendToSMM();
            try
            {
                SendCollection.AddUdpHost(TCPIP, TCPPort);
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            tcpClient = new TcpClient();
            using (tcpClient = new TcpClient())
            {
                IAsyncResult ar = tcpClient.BeginConnect(TCPIP, TCPClientPort, null, null);
                System.Threading.WaitHandle wh = ar.AsyncWaitHandle;
                try
                {
                    if (!ar.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(2), false))
                    {
                        tcpClient.Close();
                        throw new TimeoutException();
                    }

                    tcpClient.EndConnect(ar); tcpClient = new TcpClient();
                    wh.Close(); tcpClient.Connect(TCPIP, TCPClientPort);
                }
                finally
                {
                    wh.Close();
                }
            }
        }

        private string excuteVizCommand(string Command)
        {
            string result = string.Empty;
            try
            {
                if (!FirstLoopL1) { return ""; }
                if (!IpConnectL1 && IsValidIp(TCPIP))
                    ConnectionInitialize();
                if (tcpClient != null && tcpClient.Connected)
                {
                    byte[] recvBuffer = new byte[1024];
                    tcpClient.Client.Send(Encoding.UTF8.GetBytes("1 " + Command + "\0"));
                    tcpClient.Client.Receive(recvBuffer);
                    result = Encoding.UTF8.GetString(recvBuffer).Substring(2);
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.ToString() == "An established connection was aborted by the software in your host machine" || ex.Message.ToString() == "The operation has timed out." || ex.Message.ToString() == "An existing connection was forcibly closed by the remote host" || ex.Message.ToString() == "A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond " + TCPIP + ":" + TCPPort)
                {
                    IpConnectL1 = false;
                    FirstLoopL1 = false;
                    MessageBox.Show("Given IP Address not connected...");
                }
                return "";
            }
            return result;
        }

        private void btnupdate_man_Click(object sender, EventArgs e)
        {
            SendCollection.Send("kabaddi_scorebugmanual", "");
            SendCollection.Send("kabaddi_scorebugmanual", txtteamAname_man.Text + ";" + txtteamBname_man.Text + ";" + (string.IsNullOrEmpty(txtteamAscore.Text) ? "0" : txtteamAscore.Text) + ";" + (string.IsNullOrEmpty(txtteamBscore.Text) ? "0" : txtteamBscore.Text) + ";" + cbhalf_man.Text);
            excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*Pop_up_centre CONTINUE");
            excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*Pop_up_left CONTINUE");
            excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*Pop_up_right CONTINUE");
            excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*bottom_right_raid CONTINUE");
            excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*bottom_left_raid CONTINUE");
        }

        private void chkhideDIP_CheckedChanged(object sender, EventArgs e)
        {
            if (chkhideDIP.Checked)
            {
                SendCollection.Send("kabaddi_scorebug_DIPctrl_test", "");
                SendCollection.Send("kabaddi_scorebug_DIPctrl_test", "1");
            }
            else
            {
                SendCollection.Send("kabaddi_scorebug_DIPctrl_test", "");
                SendCollection.Send("kabaddi_scorebug_DIPctrl_test", "0");
            }
        }

        private void btnswapteam_man_Click(object sender, EventArgs e)
        {
            string Aname = string.Empty, Bname = string.Empty, Ascore = string.Empty, Bscore = string.Empty;
            Aname = txtteamBname_man.Text;
            Bname = txtteamAname_man.Text;
            Ascore = txtteamBscore.Text;
            Bscore = txtteamAscore.Text;
            txtteamAname_man.Text = Aname;
            txtteamBname_man.Text = Bname;
            txtteamAscore.Text = Ascore;
            txtteamBscore.Text = Bscore;
        }

        private void FrmManualScore_Load(object sender, EventArgs e)
        {

        }

    }
}
