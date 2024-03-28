// Old //
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Vizrt.VizCommunication;
using OtherSports_DataPushing.Layer;
using System.Configuration;
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.Threading;
using System.Drawing.Imaging;

namespace OtherSports_DataPushing
{

    public partial class SendtoViz : UserControl
    {
        TcpClient tcpClient;
        SendToSMM SendCollection;
        public string TisOver = "";
        MasterDL obj = new MasterDL();
        string TCPIP = "";
        bool IpConnectL1 = true;
        int TCPPort = 0, TCPClientPort = 0, UdpHostPort = 0, RaidStartval = 0;
        public SendtoViz()
        {
            InitializeComponent();
            LoadVizInitialize();
            timer1.Start();
        }

        void LoadVizInitialize()
        {
            try
            {
                TCPIP = CommonCls.TCPIP;
                TCPPort = CommonCls.TCPPort;
                TCPClientPort = CommonCls.TCPClientPort;
                UdpHostPort = CommonCls.UdpHostPort;
                SendCollection = new SendToSMM();
                if (CommonCls.EnableSendvizData == 0) { return; }
                if (!IsValidIp(TCPIP))
                {
                    MessageBox.Show("Given IP Address1 not connected..."); IpConnectL1 = false; return;
                }
                try
                {
                    SendCollection.AddUdpHost(TCPIP, UdpHostPort);
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                checkTCPConnect();
            }
            catch (Exception ae)
            {

                if (ae.Message.Trim() == "The operation has timed out.")
                {
                    //{ CommonCls.VizConStatus = 1; }
                    //if (CommonCls.EnableJsonpush != 1)
                        MessageBox.Show("VizEngine not connected.");
                    // throw ae;
                }
                else
                {
                   //if (ae.Message.Trim() == "A socket operation was attempted to an unreachable host " + TCPIP + ":" + TCPClientPort)
                   // { CommonCls.VizConStatus = 1; }
                    MessageBox.Show(ae.Message);
                }
            }
        }

        private void checkTCPConnect()
        {
            if (!IpConnectL1) { return; }
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

                   // tcpClient.EndConnect(ar);
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
            try
            {
                string result = string.Empty;
                if (tcpClient != null && tcpClient.Connected)
                {
                    byte[] recvBuffer = new byte[1024];
                    tcpClient.Client.Send(Encoding.UTF8.GetBytes("1 " + Command + "\0"));
                    tcpClient.Client.Receive(recvBuffer);
                    result = Encoding.UTF8.GetString(recvBuffer).Substring(2);
                }
                return result;
            }
            catch
            {
                return "";
            }
        }

        public bool IsValidIp(string addr)
        {
            IPAddress ip;
            bool valid = !string.IsNullOrEmpty(addr) && IPAddress.TryParse(addr, out ip);
            return valid;
        }
        Boolean IpConnect = false;
        void ConnectionInitialize()
        {
            if (CommonCls.EnableSendvizData == 0) { return; }
            if (!IpConnectL1) { return; }
            TCPIP = CommonCls.TCPIP;
            TCPPort = CommonCls.TCPPort;
            TCPClientPort = CommonCls.TCPClientPort;
            UdpHostPort = CommonCls.UdpHostPort;

            SendCollection = new SendToSMM();

            SendCollection.AddUdpHost(TCPIP, UdpHostPort);
            tcpClient = new TcpClient();
            try
            {
                var result = tcpClient.BeginConnect(TCPIP, TCPClientPort, null, null);
                result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(3));
                if (!tcpClient.Connected)
                {
                    throw new Exception("The specified network name is no longer available.");
                }
                tcpClient = new TcpClient();
                try
                {
                    tcpClient.Connect(TCPIP, TCPClientPort);
                }
                catch { }
            }
            catch (SocketException e)
            {
                tcpClient = null;
                throw e;
            }
        }
        private string excuteVizCommand1(string Command)
        {
            try
            {
                if (!IpConnect && IsValidIp(TCPIP))
                    ConnectionInitialize();
                string result = string.Empty;
                if (tcpClient != null && tcpClient.Connected)
                {
                    byte[] recvBuffer = new byte[1024];
                    tcpClient.Client.Send(Encoding.UTF8.GetBytes("1 " + Command + "\0"));
                    tcpClient.Client.Receive(recvBuffer);
                    result = Encoding.UTF8.GetString(recvBuffer).Substring(2);
                }
                return result;
            }
            catch (Exception ex)
            {
                if (ex.Message.ToString().Trim() == "The specified network name is no longer available." || ex.Message.ToString() == "An established connection was aborted by the software in your host machine" || (tcpClient == null && ex.Message.ToString().Trim() == "A socket operation was attempted to an unreachable host 192.168.1.97:6100") || ex.Message.ToString() == "A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond 192.168.1.97:6100")
                {
                    IpConnect = false;
                    //MessageBox.Show("Given IP Address not connected...");
                    throw ex;
                }

                return "";
            }
        }

        public void sendEndover()
        {
            try
            {
                if (tcpClient == null)
                {
                    if (!IpConnect && IsValidIp(TCPIP))
                        ConnectionInitialize();
                }
                GC.Collect();
                excuteVizCommand1("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*ScoreTicker_Bowler START");
            }
            catch
            {

            }
        }
        public void WriteToLog(string text)
        {
            try
            {
                string sTemp = Application.StartupPath + "\\Send_to_Viz_log.txt";
                FileStream Fs = new FileStream(sTemp, FileMode.OpenOrCreate | FileMode.Append);
                StreamWriter st = new StreamWriter(Fs);
                string dttemp = DateTime.Now.ToString("[dd:MM:yyyy] [HH:mm:ss:ffff]");
                st.WriteLine(dttemp + "\t" + text);
                st.Close();
            }
            catch { }
        }
        public void sendScorecard()
        {
            try
            {
               if (tcpClient == null)
                {
                    if (!IpConnect && IsValidIp(TCPIP))
                        ConnectionInitialize();
                }
                if (TCPIP != CommonCls.TCPIP)
                {
                    SendCollection.RemoveUdpHost(TCPIP);
                    IpConnect = false;
                    if (!IpConnect && IsValidIp(CommonCls.TCPIP))
                        LoadVizInitialize();
                }
                GC.Collect();
                if (mycommon.SportID == 8)
                {
                    #region Kabaddi
                    WriteToLog("KABADDI - " + dgv2.Rows[0].Cells["TeamAScore"].Value.ToString() + " - " + dgv2.Rows[0].Cells["TeamBScore"].Value.ToString() + " - Befroe connection check");

                    WriteToLog("KABADDI - " + dgv2.Rows[0].Cells["TeamAScore"].Value.ToString() + " - " + dgv2.Rows[0].Cells["TeamBScore"].Value.ToString() + " - After connection check");

                    string Score = string.Empty;
                    if (dgv1.Rows[0].Cells["HalfID"].Value.ToString() == "" ||
                        dgv2.Rows[0].Cells["TeamAName"].Value.ToString() == "" || dgv2.Rows[0].Cells["TeamBName"].Value.ToString() == ""
                        || dgv1.Rows[0].Cells["TeamAPrefix"].Value.ToString() == "" || dgv1.Rows[0].Cells["TeamBPrefix"].Value.ToString() == ""
                        || dgv2.Rows[0].Cells["TeamAScore"].Value.ToString() == "" || dgv2.Rows[0].Cells["TeamBScore"].Value.ToString() == ""
                        || dgv1.Rows[0].Cells["Timer"].Value.ToString() == "")
                    { return; }


                    RaidStartval = Convert.ToInt32(dgv1.Rows[0].Cells["RaidStart"].Value);

                    Score =
                         dgv1.Rows[0].Cells["TeamARaider"].Value.ToString().ToUpper() + ";" + dgv1.Rows[0].Cells["TeamBRaider"].Value.ToString().ToUpper()
                        + ";" + dgv1.Rows[0].Cells["TeamAFreeText"].Value.ToString().ToUpper() + ";" + dgv1.Rows[0].Cells["TeamBFreeText"].Value.ToString().ToUpper()
                        + ";" + dgv1.Rows[0].Cells["HalfID"].Value.ToString() + ";" + dgv1.Rows[0].Cells["Timer"].Value.ToString().ToUpper()
                        + ";" + dgv1.Rows[0].Cells["TeamAPrefix"].Value.ToString() + ";" + dgv1.Rows[0].Cells["TeamBPrefix"].Value.ToString()
                        + ";" + dgv2.Rows[0].Cells["TeamAName"].Value.ToString().ToUpper() + ";" + dgv2.Rows[0].Cells["TeamBName"].Value.ToString().ToUpper()
                         + ";" + dgv2.Rows[0].Cells["TeamAScore"].Value.ToString() + ";" + dgv2.Rows[0].Cells["TeamBScore"].Value.ToString()
                         + ";" + dgv2.Rows[0].Cells["TeamADIP"].Value.ToString() + ";" + dgv2.Rows[0].Cells["TeamBDIP"].Value.ToString()
                       + ";" + dgv2.Rows[0].Cells["TeamASpecial"].Value.ToString() + ";" + dgv2.Rows[0].Cells["TeamBSpecial"].Value.ToString()
                         + ";" + dgv1.Rows[0].Cells["RaidStart"].Value.ToString();

                    WriteToLog("KABADDI - " + dgv2.Rows[0].Cells["TeamAScore"].Value.ToString() + " - " + dgv2.Rows[0].Cells["TeamBScore"].Value.ToString() + " - Befroe data send");
                    SendCollection.Send("kabaddi_scorebug", "");
                    SendCollection.Send("kabaddi_scorebug", Score);

                    WriteToLog( "KABADDI - "+dgv2.Rows[0].Cells["TeamAScore"].Value.ToString() + " - " + dgv2.Rows[0].Cells["TeamBScore"].Value.ToString() + " - After data send");

                    WriteToLog("KABADDI - " + dgv2.Rows[0].Cells["TeamAScore"].Value.ToString() + " - " + dgv2.Rows[0].Cells["TeamBScore"].Value.ToString() + " - data send Ended");
                    #endregion
                }
                else if (mycommon.SportID == 15 || mycommon.SportID == 4)
                {
                    #region Badminton
                    WriteToLog( "BADMINTON SET - " +dgvBadminton.Rows[0].Cells["SetID"].Value.ToString() + " - " +dgvBadminton.Rows[0].Cells["BadTeamACurSetScore"].Value.ToString() + " - " + dgvBadminton.Rows[0].Cells["BadTeamBCurSetScore"].Value.ToString() + " - Befroe connection check");

                    WriteToLog( "SET - " +dgvBadminton.Rows[0].Cells["SetID"].Value.ToString() + " - " +dgvBadminton.Rows[0].Cells["BadTeamACurSetScore"].Value.ToString() + " - " + dgvBadminton.Rows[0].Cells["BadTeamBCurSetScore"].Value.ToString() + " - After connection check");

                    //string vvv = dgvBadminton.Rows[0].Cells["AsetWin"].Value.ToString();
                    //string vvv1 = dgvBadminton.Rows[0].Cells["BsetWin"].Value.ToString();

                    string Score = string.Empty;
                    if (dgvBadminton.Rows[0].Cells["SetID"].Value.ToString() == "" ||
                        dgvBadminton.Rows[0].Cells["BadTeamAName"].Value.ToString() == "" || dgvBadminton.Rows[0].Cells["BadTeamBName"].Value.ToString() == ""
                        || dgvBadminton.Rows[0].Cells["BadTeamBPrefix"].Value.ToString() == "" || dgvBadminton.Rows[0].Cells["BadTeamAPrefix"].Value.ToString() == ""
                        || dgvBadminton.Rows[0].Cells["BadTeamBCurSetScore"].Value.ToString() == "" || dgvBadminton.Rows[0].Cells["BadTeamACurSetScore"].Value.ToString() == "")
                    { return; }


                    Score =
                         dgvBadminton.Rows[0].Cells["SetID"].Value.ToString().ToUpper() + ";" + dgvBadminton.Rows[0].Cells["BadTeamAName"].Value.ToString().ToUpper()
                        + ";" + dgvBadminton.Rows[0].Cells["BadTeamBName"].Value.ToString().ToUpper() + ";" + dgvBadminton.Rows[0].Cells["BadTeamAPrefix"].Value.ToString().ToUpper()
                        + ";" + dgvBadminton.Rows[0].Cells["BadTeamBPrefix"].Value.ToString().ToUpper() + ";" + dgvBadminton.Rows[0].Cells["BadTeamASet1Score"].Value.ToString().ToUpper()
                        + ";" + dgvBadminton.Rows[0].Cells["BadTeamBSet1Score"].Value.ToString() + ";" + dgvBadminton.Rows[0].Cells["BadTeamASet2Score"].Value.ToString()
                        + ";" + dgvBadminton.Rows[0].Cells["BadTeamBSet2Score"].Value.ToString().ToUpper() + ";" + dgvBadminton.Rows[0].Cells["BadTeamASet3Score"].Value.ToString().ToUpper()
                         + ";" + dgvBadminton.Rows[0].Cells["BadTeamBSet3Score"].Value.ToString() + ";" + dgvBadminton.Rows[0].Cells["BadTeamAServe"].Value.ToString()
                         + ";" + dgvBadminton.Rows[0].Cells["BadTeamBServe"].Value.ToString()

                         + ";" + dgvBadminton.Rows[0].Cells["BadTeamAPlayerfname1"].Value.ToString().ToUpper()
                       + ";" + dgvBadminton.Rows[0].Cells["BadTeamAPlayerlname1"].Value.ToString().ToUpper()
                       + ";" + dgvBadminton.Rows[0].Cells["BadTeamBPlayerfname1"].Value.ToString().ToUpper()
                       + ";" + dgvBadminton.Rows[0].Cells["BadTeamBPlayerlname1"].Value.ToString().ToUpper()

                       + ";" + dgvBadminton.Rows[0].Cells["BadTeamAPlayer2"].Value.ToString().ToUpper()
                         + ";" + dgvBadminton.Rows[0].Cells["BadTeamBPlayer2"].Value.ToString().ToUpper() + ";" + dgvBadminton.Rows[0].Cells["ASetWin"].Value.ToString()
                         + ";" + dgvBadminton.Rows[0].Cells["BSetWin"].Value.ToString() + ";" + dgvBadminton.Rows[0].Cells["SingleorDouble"].Value.ToString()
                    + ";" + dgvBadminton.Rows[0].Cells["BadTeamASet4Score"].Value.ToString() + ";" + dgvBadminton.Rows[0].Cells["BadTeamBSet4Score"].Value.ToString()
                    + ";" + dgvBadminton.Rows[0].Cells["BadTeamASet5Score"].Value.ToString() + ";" + dgvBadminton.Rows[0].Cells["BadTeamBSet5Score"].Value.ToString()
                    + ";" + dgvBadminton.Rows[0].Cells["GameStart"].Value.ToString() + ";" + dgvBadminton.Rows[0].Cells["GameEnd"].Value.ToString()
                     + ";" + dgvBadminton.Rows[0].Cells["MatchStart"].Value.ToString() + ";" + dgvBadminton.Rows[0].Cells["MatchEnd"].Value.ToString();
                   

                    WriteToLog( "SET - " +dgvBadminton.Rows[0].Cells["SetID"].Value.ToString() + " - " +dgvBadminton.Rows[0].Cells["BadTeamACurSetScore"].Value.ToString() + " - " + dgvBadminton.Rows[0].Cells["BadTeamBCurSetScore"].Value.ToString() + " - Befroe data send");
                    if (mycommon.SportID == 15)
                    {
                        SendCollection.Send("badminton_scorebug", "");
                        SendCollection.Send("badminton_scorebug", Score);

                        if (dgvBadminton.Rows[0].Cells["MatchStart"].Value.ToString() == "1")
                        {
                            excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_1 CONTINUE");
                            excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_2 CONTINUE");
                            excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_3 CONTINUE");
                            excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_4 CONTINUE");
                            excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_5 CONTINUE");
                            excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*ON_GOING START");
                        }
                        if (dgvBadminton.Rows[0].Cells["GameEnd"].Value.ToString() == "1")
                        {
                            if (dgvBadminton.Rows[0].Cells["SetID"].Value.ToString().ToUpper() == "1")
                                excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_1 START");
                            if (dgvBadminton.Rows[0].Cells["SetID"].Value.ToString().ToUpper() == "2")
                                excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_2 START");

                            if (dgvBadminton.Rows[0].Cells["SetID"].Value.ToString().ToUpper() == "3")
                                excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_3 START");

                           // Thread.Sleep(500);
                            excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*ON_GOING CONTINUE");
                        }
                        if (dgvBadminton.Rows[0].Cells["MatchEnd"].Value.ToString() == "1")
                        {
                            excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*ON_GOING CONTINUE");
                        }

                        if (mycommon.pagerefresh)
                        {
                            excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_1 CONTINUE");
                            excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_2 CONTINUE");
                            excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_3 CONTINUE");
                            excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_4 CONTINUE");
                            excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_5 CONTINUE");
                            if (Convert.ToInt32(dgvBadminton.Rows[0].Cells["SetID"].Value.ToString()) == 1)
                            {
                                if (mycommon.GameEnd == 1)
                                {
                                    excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_1 START");
                                    excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*ON_GOING CONTINUE");
                                }
                                else
                                {
                                    excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_1 CONTINUE");
                                    excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*ON_GOING START");
                                }
                            }

                            else if (Convert.ToInt32(dgvBadminton.Rows[0].Cells["SetID"].Value.ToString()) == 2)
                            {
                                if (mycommon.GameEnd == 1)
                                {
                                    excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_1 START");
                                    excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_2 START");
                                    excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*ON_GOING CONTINUE");
                                }
                                else
                                {
                                    excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_1 START");
                                    excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_2 CONTINUE");
                                    excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*ON_GOING START");
                                }
                            }
                            else if (Convert.ToInt32(dgvBadminton.Rows[0].Cells["SetID"].Value.ToString()) == 3)
                            {
                                if (mycommon.GameEnd == 1 || mycommon.MatchEnd == 1)
                                {
                                    excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_1 START");
                                    excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_2 START");
                                    excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_3 START");
                                    excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*ON_GOING CONTINUE");
                                }
                                else
                                {
                                    excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_1 START");
                                    excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_2 START");
                                    excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_3 CONTINUE");
                                    excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*ON_GOING START");
                                }
                            }
                            mycommon.pagerefresh = false;
                        }
                        else
                        {
                            if (dgvBadminton.Rows[0].Cells["GameStart"].Value.ToString() == "1")
                            {
                                if (Convert.ToInt32(dgvBadminton.Rows[0].Cells["SetID"].Value.ToString()) == 1)
                                {
                                    excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_1 CONTINUE");
                                }
                                else if (Convert.ToInt32(dgvBadminton.Rows[0].Cells["SetID"].Value.ToString()) == 2)
                                {
                                    excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_2 CONTINUE");
                                }
                                else if (Convert.ToInt32(dgvBadminton.Rows[0].Cells["SetID"].Value.ToString()) == 3)
                                {
                                    excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_3 CONTINUE");
                                }

                                Thread.Sleep(500);
                                excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*ON_GOING START");
                            }
                        }
                        mycommon.GameEnd = 0;
                        mycommon.GameStart = 0;
                        mycommon.MatchStart = 0;
                        mycommon.MatchEnd = 0;

                       
                    }
                    else if (mycommon.SportID == 4)
                    {
                        SendCollection.Send("volleyball_scorebug", "");
                        SendCollection.Send("volleyball_scorebug", Score);


                        if (dgvBadminton.Rows[0].Cells["MatchStart"].Value.ToString() == "1")
                        {
                            excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_1 CONTINUE");
                            excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_2 CONTINUE");
                            excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_3 CONTINUE");
                            excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_4 CONTINUE");
                            excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_5 CONTINUE");
                            excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*ON_GOING START");
                        }
                        if (dgvBadminton.Rows[0].Cells["GameEnd"].Value.ToString() == "1")
                        {
                            
                            excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*ON_GOING CONTINUE");
                            //Thread.Sleep(100);
                            //if (dgvBadminton.Rows[0].Cells["SetID"].Value.ToString().ToUpper() == "1")
                            //    excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_1 START");
                            //if (dgvBadminton.Rows[0].Cells["SetID"].Value.ToString().ToUpper() == "2")
                            //    excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_2 START");

                            //if (dgvBadminton.Rows[0].Cells["SetID"].Value.ToString().ToUpper() == "3")
                            //    excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_3 START");

                            //if (dgvBadminton.Rows[0].Cells["SetID"].Value.ToString().ToUpper() == "4")
                            //    excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_4 START");

                            //if (dgvBadminton.Rows[0].Cells["SetID"].Value.ToString().ToUpper() == "5")
                            //    excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_5 START");


                            if (mycommon.MatchEnd == 1)
                            {
                                excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*ON_GOING CONTINUE");
                                Thread.Sleep(100);
                                if (dgvBadminton.Rows[0].Cells["SetID"].Value.ToString().ToUpper() == "1")
                                {
                                    excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_1 START");
                                }
                                if (dgvBadminton.Rows[0].Cells["SetID"].Value.ToString().ToUpper() == "2")
                                {
                                    excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_1 START");
                                    excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_2 START");
                                }

                                if (dgvBadminton.Rows[0].Cells["SetID"].Value.ToString().ToUpper() == "3")
                                {
                                    excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_1 START");
                                    excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_2 START");
                                    excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_3 START");
                                }

                                if (dgvBadminton.Rows[0].Cells["SetID"].Value.ToString().ToUpper() == "4")
                                {
                                    excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_1 START");
                                    excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_2 START");
                                    excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_3 START");
                                    excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_4 START");
                                }

                                if (dgvBadminton.Rows[0].Cells["SetID"].Value.ToString().ToUpper() == "5")
                                {
                                    excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_1 START");
                                    excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_2 START");
                                    excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_3 START");
                                    excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_4 START");
                                    excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_5 START");
                                }
                            }
                            else
                            {
                                if (mycommon.GameEnd == 1)
                                    excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_1 START");
                                else
                                    excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_1 CONTINUE");
                            }


                        }

                        else if (mycommon.pagerefresh)
                        {
                            if (Convert.ToInt32(dgvBadminton.Rows[0].Cells["SetID"].Value.ToString()) == 1)
                            {
                                excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_1 CONTINUE");
                                excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_2 CONTINUE");
                                excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_3 CONTINUE");
                                excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_4 CONTINUE");
                                excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_5 CONTINUE");
                                excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*ON_GOING START");
                            }
                            else
                            {
                                excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*ON_GOING START");

                                excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_2 CONTINUE");
                                excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_3 CONTINUE");
                                excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_4 CONTINUE");
                                excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_5 CONTINUE");
                                excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_1 START");
                            }
                            mycommon.pagerefresh = false;
                        }
                        mycommon.GameEnd = 0;
                        if (mycommon.MatchEnd == 1)
                        {
                            excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*ON_GOING CONTINUE");
                            Thread.Sleep(100);
                            if (dgvBadminton.Rows[0].Cells["SetID"].Value.ToString().ToUpper() == "1")
                            {
                                excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_1 START");
                            }
                            if (dgvBadminton.Rows[0].Cells["SetID"].Value.ToString().ToUpper() == "2")
                            {
                                excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_1 START");
                                excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_2 START");
                            }

                            if (dgvBadminton.Rows[0].Cells["SetID"].Value.ToString().ToUpper() == "3")
                            {
                                excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_1 START");
                                excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_2 START");
                                excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_3 START");
                            }

                            if (dgvBadminton.Rows[0].Cells["SetID"].Value.ToString().ToUpper() == "4")
                            {
                                excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_1 START");
                                excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_2 START");
                                excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_3 START");
                                excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_4 START");
                            }

                            if (dgvBadminton.Rows[0].Cells["SetID"].Value.ToString().ToUpper() == "5")
                            {
                                excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_1 START");
                                excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_2 START");
                                excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_3 START");
                                excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_4 START");
                                excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*SET_5 START");
                            }
                        }

                        if (dgvBadminton.Rows[0].Cells["GameStart"].Value.ToString() == "1")
                        {
                            excuteVizCommand("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*ON_GOING START");
                        }

                        mycommon.GameEnd = 0;
                        mycommon.GameStart = 0;
                        mycommon.MatchStart = 0;
                        mycommon.MatchEnd = 0;
                    }


                    WriteToLog( "SET - " +dgvBadminton.Rows[0].Cells["SetID"].Value.ToString() + " - " +dgvBadminton.Rows[0].Cells["BadTeamACurSetScore"].Value.ToString() + " - " + dgvBadminton.Rows[0].Cells["BadTeamBCurSetScore"].Value.ToString() + " - After data send");

                    WriteToLog( "SET - " +dgvBadminton.Rows[0].Cells["SetID"].Value.ToString() + " - " +dgvBadminton.Rows[0].Cells["BadTeamACurSetScore"].Value.ToString() + " - " + dgvBadminton.Rows[0].Cells["BadTeamBCurSetScore"].Value.ToString() + " - data send Ended");
                    #endregion
                }

                else if (mycommon.SportID == 3)
                {
                    #region Basketball
                    string Score = string.Empty;
                    DataTable dt = (DataTable)dgvBasketball.DataSource;
                    dgvBasketball.DataSource = dt;

                    Score =
                         Convert.ToString(dt.Rows[0]["QuarterID"]) + ";" + Convert.ToString(dt.Rows[0]["TeamAName1"]).ToUpper()
                        + ";" + Convert.ToString(dt.Rows[0]["TeamBName1"]).ToUpper() + ";" + Convert.ToString(dt.Rows[0]["TeamAscore1"])
                        + ";" + Convert.ToString(dt.Rows[0]["TeamBscore1"]) + ";" + Convert.ToString(dt.Rows[0]["Timer2"])
                        + ";" + Convert.ToString(dt.Rows[0]["ShotTimer"]);
                     if (mycommon.SportID == 3)
                    {
                        SendCollection.Send("basketball_scorebug", "");
                        SendCollection.Send("basketball_scorebug", Score);

                    }
                     #endregion
                }
                else if (mycommon.SportID == 2)
                {
                    #region wrestling
                    string Score = string.Empty;
                    DataTable dt = (DataTable)dgvBasketball.DataSource;
                    dgvBasketball.DataSource = dt;

                    Score =
                         Convert.ToString(dt.Rows[0]["QuarterID"]) + ";" + Convert.ToString(dt.Rows[0]["TeamAName1"]).ToUpper()
                        + ";" + Convert.ToString(dt.Rows[0]["TeamBName1"]).ToUpper() + ";" + Convert.ToString(dt.Rows[0]["TeamAscore1"])
                        + ";" + Convert.ToString(dt.Rows[0]["TeamBscore1"]) + ";" + Convert.ToString(dt.Rows[0]["Timer2"]) + ";" + Convert.ToString(dt.Rows[0]["TeamAPrefix"]) + ";" + Convert.ToString(dt.Rows[0]["TeamBPrefix"]);

                 if (mycommon.SportID == 2)
                    {
                        SendCollection.Send("wrestling_scorebug", "");
                        SendCollection.Send("wrestling_scorebug", Score);

                    }

                    #endregion
                }

                else if (mycommon.SportID == 7)
                {
                    #region KhoKho
                    string Score = string.Empty;

                    DataTable dt = (DataTable)dgvBasketball.DataSource;
                    dgvBasketball.DataSource = dt;

                    Score =
                         Convert.ToString(dt.Rows[0]["QuarterID"]) + ";" + Convert.ToString(dt.Rows[0]["TeamAName1"]).ToUpper()
                        + ";" + Convert.ToString(dt.Rows[0]["TeamBName1"]).ToUpper() + ";" + Convert.ToString(dt.Rows[0]["TeamAscore1"])
                        + ";" + Convert.ToString(dt.Rows[0]["TeamBscore1"]) + ";" + Convert.ToString(dt.Rows[0]["Timer2"])
                        + ";" + Convert.ToString(dt.Rows[0]["Runner"]) + ";" + Convert.ToString(dt.Rows[0]["Chaser"]);
                  if (mycommon.SportID == 7)
                    {
                        SendCollection.Send("khokho_scorebug", "");
                        SendCollection.Send("khokho_scorebug", Score);

                    }
                  if (mycommon.MatchStart == 1)
                  {

                      excuteVizCommand1("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*bottom_right_raid CONTINUE");
                      excuteVizCommand1("RENDERER*FRONT_LAYER*STAGE*DIRECTOR*bottom_left_raid CONTINUE");
                  }
                  mycommon.GameStart = 0;
                  mycommon.GameEnd = 0;
                  mycommon.MatchStart = 0;
                  mycommon.MatchEnd = 0;
                      #endregion
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.ToString().Trim() == "The specified network name is no longer available." || ex.Message.ToString().Trim() == "A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond 192.168.1.97:6100" || ex.Message.ToString().Trim() == "The network path was not found." || (tcpClient == null && ex.Message.ToString().Trim() == "A socket operation was attempted to an unreachable host 192.168.1.97:6100"))
                    throw ex;
                else
                    MessageBox.Show(ex.Message);
            }
        }


        public void sendWrestlingTimer(string TimerEvent)
        {
            try
            {
                // WriteToLog(dgv2.Rows[0].Cells["TeamAScore"].Value.ToString() + " - " + dgv2.Rows[0].Cells["TeamBScore"].Value.ToString() + " - Befroe connection check");
                if (tcpClient == null)
                {
                    if (!IpConnect && IsValidIp(TCPIP))
                        ConnectionInitialize();
                }
                if (TCPIP != CommonCls.TCPIP)
                {
                    SendCollection.RemoveUdpHost(TCPIP);
                    IpConnect = false;
                    if (!IpConnect && IsValidIp(CommonCls.TCPIP))
                        LoadVizInitialize();
                }
                excuteVizCommand1(TimerEvent);
                // WriteToLog(dgv2.Rows[0].Cells["TeamAScore"].Value.ToString() + " - " + dgv2.Rows[0].Cells["TeamBScore"].Value.ToString() + " - After connection check");
                GC.Collect();

            }
            catch (Exception ex)
            {
                if (ex.Message.ToString().Trim() == "The specified network name is no longer available." || ex.Message.ToString().Trim() == "A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond 192.168.1.97:6100" || ex.Message.ToString().Trim() == "The network path was not found." || (tcpClient == null && ex.Message.ToString().Trim() == "A socket operation was attempted to an unreachable host 192.168.1.97:6100"))
                    throw ex;
                else
                    MessageBox.Show(ex.Message);
            }
        }


        public void sendScorecardTimer(string TimerEvent)
        {
          //  return;
            try
            {
               // WriteToLog(dgv2.Rows[0].Cells["TeamAScore"].Value.ToString() + " - " + dgv2.Rows[0].Cells["TeamBScore"].Value.ToString() + " - Befroe connection check");
                if (tcpClient == null)
                {
                    if (!IpConnect && IsValidIp(TCPIP))
                        ConnectionInitialize();
                }   
                if (TCPIP != CommonCls.TCPIP)
                {
                    SendCollection.RemoveUdpHost(TCPIP);
                    IpConnect = false;
                    if (!IpConnect && IsValidIp(CommonCls.TCPIP))
                        LoadVizInitialize();
                }
                excuteVizCommand1("CLOCK0 " + TimerEvent + "");
               // WriteToLog(dgv2.Rows[0].Cells["TeamAScore"].Value.ToString() + " - " + dgv2.Rows[0].Cells["TeamBScore"].Value.ToString() + " - After connection check");
                GC.Collect();

            }
            catch (Exception ex)
            {
                if (ex.Message.ToString().Trim() == "The specified network name is no longer available." || ex.Message.ToString().Trim() == "A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond 192.168.1.97:6100" || ex.Message.ToString().Trim() == "The network path was not found." || (tcpClient == null && ex.Message.ToString().Trim() == "A socket operation was attempted to an unreachable host 192.168.1.97:6100"))
                    throw ex;
                else
                    MessageBox.Show(ex.Message);
            }
        }

        public void sendChaserorRunner(string TeamAFlag,string TeamBFlag)
        {
            try
            {
                // WriteToLog(dgv2.Rows[0].Cells["TeamAScore"].Value.ToString() + " - " + dgv2.Rows[0].Cells["TeamBScore"].Value.ToString() + " - Befroe connection check");
                if (tcpClient == null)
                {
                    if (!IpConnect && IsValidIp(TCPIP))
                        ConnectionInitialize();
                }
                if (TCPIP != CommonCls.TCPIP)
                {
                    SendCollection.RemoveUdpHost(TCPIP);
                    IpConnect = false;
                    if (!IpConnect && IsValidIp(CommonCls.TCPIP))
                        LoadVizInitialize();
                }

                SendCollection.Send("khokho_runnerchaser", "");
                SendCollection.Send("khokho_runnerchaser", TeamAFlag + ";" + TeamBFlag);

                GC.Collect();

            }
            catch (Exception ex)
            {
                if (ex.Message.ToString().Trim() == "The specified network name is no longer available." || ex.Message.ToString().Trim() == "A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond 192.168.1.97:6100" || ex.Message.ToString().Trim() == "The network path was not found." || (tcpClient == null && ex.Message.ToString().Trim() == "A socket operation was attempted to an unreachable host 192.168.1.97:6100"))
                    throw ex;
                else
                    MessageBox.Show(ex.Message);
            }
        }

        public void sendScorecardRaidStart(string TeamARaider, string TeamBRaider,string TeamADIP,string TeamBDIP)
        {
            try
            {
             //   WriteToLog(dgv2.Rows[0].Cells["TeamAScore"].Value.ToString() + " - " + dgv2.Rows[0].Cells["TeamBScore"].Value.ToString() + " - Befroe connection check");
                if (tcpClient == null)
                {
                    if (!IpConnect && IsValidIp(TCPIP))
                        ConnectionInitialize();
                }
                if (TCPIP != CommonCls.TCPIP)
                {
                    SendCollection.RemoveUdpHost(TCPIP);
                    IpConnect = false;
                    if (!IpConnect && IsValidIp(CommonCls.TCPIP))
                        LoadVizInitialize();
                }
                excuteVizCommand1("RENDERER*STAGE*DIRECTOR*Pop_up_right " + TeamARaider + "");
                excuteVizCommand1("RENDERER*STAGE*DIRECTOR*Pop_up_left " + TeamBRaider + "");
                WriteToLog(dgv2.Rows[0].Cells["TeamAScore"].Value.ToString() + " - " + dgv2.Rows[0].Cells["TeamBScore"].Value.ToString() + " - After connection check");
                GC.Collect();

            }
            catch (Exception ex)
            {
                if (ex.Message.ToString().Trim() == "The specified network name is no longer available." || ex.Message.ToString().Trim() == "A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond 192.168.1.97:6100" || ex.Message.ToString().Trim() == "The network path was not found." || (tcpClient == null && ex.Message.ToString().Trim() == "A socket operation was attempted to an unreachable host 192.168.1.97:6100"))
                    throw ex;
                else
                    MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            sendScorecard();
        }

        private void GridControl_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CommonCls.EnableSendvizData == 0) { return; }
            if (tcpClient == null)
            {
                if (!IpConnect && IsValidIp(TCPIP))
                    ConnectionInitialize();
            }
            if (TCPIP != CommonCls.TCPIP)
            {
                SendCollection.RemoveUdpHost(TCPIP);
                IpConnect = false;
                if (!IpConnect && IsValidIp(CommonCls.TCPIP))
                    LoadVizInitialize();
            }
          //  WriteToLog(dgv2.Rows[0].Cells["TeamAScore"].Value.ToString() + " - " + dgv2.Rows[0].Cells["TeamBScore"].Value.ToString() + " - Before timer dummy send");
            GC.Collect();
            SendCollection.Send("dummy", "dummy");
          //  WriteToLog(dgv2.Rows[0].Cells["TeamAScore"].Value.ToString() + " - " + dgv2.Rows[0].Cells["TeamBScore"].Value.ToString() + " - After timer dummy send");
        }
    }
}
