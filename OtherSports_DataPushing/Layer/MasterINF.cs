using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtherSports_DataPushing.Layer
{
    interface VizSendKabaddiDataINF
    {
        string HalfID { get; set; }
        string TeamAName { get; set; }
        string TeamBName { get; set; }
        string TeamAPrefix { get; set; }
        string TeamBPrefix { get; set; }
        string TeamAScore { get; set; }
        string TeamBScore { get; set; }
        string Timer { get; set; }
        string TeamARaider { get; set; }
        string TeamBRaider { get; set; }
        string TeamAFreeText { get; set; }
        string TeamBFreeText { get; set; }
        string TeamADIP { get; set; }
        string TeamBDIP { get; set; }
        string TeamASpecial { get; set; }
        string TeamBSpecial { get; set; }
        string RaidStart { get; set; }
    }

    interface VizSendBadmintonDataINF
    {
        string SetID { get; set; }
        string TeamAName { get; set; }
        string TeamBName { get; set; }
        string TeamAPrefix { get; set; }
        string TeamBPrefix { get; set; }
        string TeamASet1Score { get; set; }
        string TeamBSet1Score { get; set; }
        string TeamASet2Score { get; set; }
        string TeamBSet2Score { get; set; }
        string TeamASet3Score { get; set; }
        string TeamBSet3Score { get; set; }
        string TeamASet4Score { get; set; }
        string TeamBSet4Score { get; set; }
        string TeamASet5Score { get; set; }
        string TeamBSet5Score { get; set; }
        string Timer { get; set; }
        string TeamAServe { get; set; }
        string TeamBServe { get; set; }
        string TeamAPlayerfname1 { get; set; }
        string TeamBPlayerfname1 { get; set; }
        string TeamAPlayerlname1 { get; set; }
        string TeamBPlayerlname1 { get; set; }

        string TeamAPlayer2 { get; set; }
        string TeamBPlayer2 { get; set; }
        string SingleorDouble { get; set; }

        string TeamACurSetScore { get; set; }
        string TeamBCurSetScore { get; set; }
        string GameStart { get; set; }
        string GameEnd { get; set; }

        string MatchStart { get; set; }
        string MatchEnd { get; set; }
    }

    interface VizSendBasketballDataINF
    {
        string QuarterID { get; set; }
        string TeamAName { get; set; }
        string TeamBName { get; set; }
        string TeamAPrefix { get; set; }
        string TeamBPrefix { get; set; }
        string Timer { get; set; }
        string Shottime { get; set; }
        string TeamAScore { get; set; }
        string TeamBScore { get; set; }
        string QuarterStart { get; set; }
        string GameEnd { get; set; }

        string MatchStart { get; set; }
        string MatchEnd { get; set; }
        string Runner { get; set; }
        string Chaser { get; set; }
    }

}
