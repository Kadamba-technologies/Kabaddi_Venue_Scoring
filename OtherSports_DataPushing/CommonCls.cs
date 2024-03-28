using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace OtherSports_DataPushing
{
    //public static class CommonCls
    public static class CommonCls
    {
        public static int CompId = Convert.ToInt32(ConfigurationSettings.AppSettings["CompID"].ToString());
        public static int MatchId;                      // Match Id Maintain
        public static int HalfID;                     // Innings Id Maintain
        public static int SessionID;
        public static int RaidClubId;
        public static int DefenceClubId;
        public static int RaidNo;
        public static int RaiderID;
        public static int EventID; 
        public static int ClubId1;                      // Club 1 Id Maintain
        public static int ClubId2;                      // Club 2 Id Maintain      
        public static string Club1Name;                 // Club 1 Name Maintain
        public static string Club2Name;                 // Club 2 Name Maintain
        public static string Club1Prefix;
        public static string Club2Prefix;
        public static DateTime MatchDate;
        public static bool XmlPush = true;

        public static Boolean GivePathCls;

        public static string localConn = string.Empty;
        public static string serverConn = string.Empty;
        public static int DBType= 0;
        public static string MachineName = string.Empty;
        public static string IPAddress = string.Empty;
        //public static int MatchidRv=0;
        //public static int InningsRv = 0;
        //public static int BallidRv = 0;
        public static string WebServerURL = string.Empty;
        public static string VideoFilter = string.Empty;
        public static DateTime LastTime = System.DateTime.Now;
        public static int MatchTypeID = 0;

        public static string VideoPath;
        public static Int32 SinkValue = 0;
        public static string TeamAColor = "";
        public static string TeamBColor = "";
        public static int EventTypeId = 0;
        public static DateTime StartTime = System.DateTime.Now;
        public static DateTime EndTime = System.DateTime.Now;
        public static Int32 PX = 0;
        public static Int32 PY = 0;
        public static Int32 BLPX = 0;
        public static Int32 BLPY = 0;
        public static DataTable DTListEvents=new DataTable();
        public static DataTable DTListOutPlayer = new DataTable();
        public static Int32 RaiderOutType = 0;
        public static Int32 RaiderOutCome = 0;
        public static Int32 RaiderEscape = 0;
        public static Int32 RaiderCard = 0;

        public static string StartTimer = "";
        public static string EndTimer = "";
        public static string Videopath = "";

        public static int UserLoginID;                  // User Login Id Maintain
        public static string UserLoginName;             // User Login Name Maintain
        public static string UserLoginType;             // User Login Type Maintain   
        public static Int32 AppType = 0;
        public static int TeamID1;
        public static int TeamID2;


        public static int TeamADIPXML;
        public static int TeamBDIPXML;

        public static string SpecialCase="";

        public static string RaidSpecialCase = "";
        public static string DefSpecialCase = "";

        public static string TCPIP = ConfigurationSettings.AppSettings["TcpHostIPPrimary"].ToString();
        public static Int32 TCPPort = Convert.ToInt32(ConfigurationSettings.AppSettings["TcpHostPort"].ToString());
        public static Int32 TCPClientPort = Convert.ToInt32(ConfigurationSettings.AppSettings["TCPClientPort"].ToString());
        public static Int32 UdpHostPort = Convert.ToInt32(ConfigurationSettings.AppSettings["UdpHostPort"].ToString());
        public static Int32 EnableSendvizData = Convert.ToInt32(ConfigurationSettings.AppSettings["EnableSendvizData"].ToString());
        public static string xmlpath = ConfigurationSettings.AppSettings["xmlpath"].ToString();
        public static string xmlpath1 = ConfigurationSettings.AppSettings["xmlpath1"].ToString();
        
    }   
}
