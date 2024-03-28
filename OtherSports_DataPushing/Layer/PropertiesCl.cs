using OtherSports_DataPushing.Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtherSports_DataPushing
{
    public class VizKabaddiSendData : VizSendKabaddiDataINF
    {
        #region KABADDI

        #region variable

        string _HalfID { get; set; }
        string _TeamAName { get; set; }
        string _TeamBName { get; set; }
        string _TeamAPrefix { get; set; }
        string _TeamBPrefix { get; set; }
        string _TeamAScore { get; set; }
        string _TeamBScore { get; set; }
        string _Timer { get; set; }
        string _TeamARaider { get; set; }
        string _TeamBRaider { get; set; }
        string _TeamAFreeText { get; set; }
        string _TeamBFreeText { get; set; }
        string _TeamADIP { get; set; }
        string _TeamBDIP { get; set; }
        string _TeamASpecial { get; set; }
        string _TeamBSpecial { get; set; }
        string _RaidStart { get; set; }

        #endregion

        #region VizSendDataINF Members

        public string HalfID
        {
            get { return _HalfID; }
            set { _HalfID = value; }
        }
        public string TeamAName
        {
            get { return _TeamAName; }
            set { _TeamAName = value; }
        }
        public string TeamBName
        {
            get { return _TeamBName; }
            set { _TeamBName = value; }
        }
        public string TeamAPrefix
        {
            get { return _TeamAPrefix; }
            set { _TeamAPrefix = value; }
        }
        public string TeamBPrefix
        {
            get { return _TeamBPrefix; }
            set { _TeamBPrefix = value; }
        }
        public string TeamAScore
        {
            get { return _TeamAScore; }
            set { _TeamAScore = value; }
        }
        public string TeamBScore
        {
            get { return _TeamBScore; }
            set { _TeamBScore = value; }
        }
        public string Timer
        {
            get { return _Timer; }
            set { _Timer = value; }
        }
        public string TeamARaider
        {
            get { return _TeamARaider; }
            set { _TeamARaider = value; }
        }
        public string TeamBRaider
        {
            get { return _TeamBRaider; }
            set { _TeamBRaider = value; }
        }
        public string TeamAFreeText
        {
            get { return _TeamAFreeText; }
            set { _TeamAFreeText = value; }
        }
        public string TeamBFreeText
        {
            get { return _TeamBFreeText; }
            set { _TeamBFreeText = value; }
        }
        public string TeamADIP
        {
            get { return _TeamADIP; }
            set { _TeamADIP = value; }
        }
        public string TeamBDIP
        {
            get { return _TeamBDIP; }
            set { _TeamBDIP = value; }
        }
        public string TeamASpecial
        {
            get { return _TeamASpecial; }
            set { _TeamASpecial = value; }
        }
        public string TeamBSpecial
        {
            get { return _TeamBSpecial; }
            set { _TeamBSpecial = value; }
        }
        public string RaidStart
        {
            get { return _RaidStart; }
            set { _RaidStart = value; }
        }
      
        #endregion

        #endregion
    }

    public class VizBadmintonSendData : VizSendBadmintonDataINF
    {
        #region KABADDI

        #region variable

        string _SetID { get; set; }
        string _TeamAName { get; set; }
        string _TeamBName { get; set; }
        string _TeamAPrefix { get; set; }
        string _TeamBPrefix { get; set; }
        string _TeamASet1Score { get; set; }
        string _TeamBSet1Score { get; set; }
        string _TeamASet2Score { get; set; }
        string _TeamBSet2Score { get; set; }
        string _TeamASet3Score { get; set; }
        string _TeamBSet3Score { get; set; }
        string _TeamASet4Score { get; set; }
        string _TeamBSet4Score { get; set; }
        string _TeamASet5Score { get; set; }
        string _TeamBSet5Score { get; set; }
        string _Timer { get; set; }
        string _TeamAServe { get; set; }
        string _TeamBServe { get; set; }

        string _TeamAPlayerfname1 { get; set; }
        string _TeamBPlayerfname1 { get; set; }
        string _TeamAPlayerlname1 { get; set; }
        string _TeamBPlayerlname1 { get; set; }

        string _TeamAPlayer2 { get; set; }
        string _TeamBPlayer2 { get; set; }

        string _TeamACurSetScore { get; set; }
        string _TeamBCurSetScore { get; set; }

        string _SingleorDouble { get; set; }
        string _GameStart { get; set; }
        string _GameEnd { get; set; }
        string _MatchStart { get; set; }
        string _MatchEnd { get; set; }

        #endregion

        #region VizSendDataINF Members

        public string SetID
        {
            get { return _SetID; }
            set { _SetID = value; }
        }
        public string TeamAName
        {
            get { return _TeamAName; }
            set { _TeamAName = value; }
        }
        public string TeamBName
        {
            get { return _TeamBName; }
            set { _TeamBName = value; }
        }
        public string TeamAPrefix
        {
            get { return _TeamAPrefix; }
            set { _TeamAPrefix = value; }
        }
        public string TeamBPrefix
        {
            get { return _TeamBPrefix; }
            set { _TeamBPrefix = value; }
        }
        public string TeamASet1Score
        {
            get { return _TeamASet1Score; }
            set { _TeamASet1Score = value; }
        }
        public string TeamBSet1Score
        {
            get { return _TeamBSet1Score; }
            set { _TeamBSet1Score = value; }
        }
        public string TeamASet2Score
        {
            get { return _TeamASet2Score; }
            set { _TeamASet2Score = value; }
        }
        public string TeamBSet2Score
        {
            get { return _TeamBSet2Score; }
            set { _TeamBSet2Score = value; }
        }
        public string TeamASet3Score
        {
            get { return _TeamASet3Score; }
            set { _TeamASet3Score = value; }
        }
        public string TeamBSet3Score
        {
            get { return _TeamBSet3Score; }
            set { _TeamBSet3Score = value; }
        }

        public string TeamASet4Score
        {
            get { return _TeamASet4Score; }
            set { _TeamASet4Score = value; }
        }
        public string TeamBSet4Score
        {
            get { return _TeamBSet4Score; }
            set { _TeamBSet4Score = value; }
        }

        public string TeamASet5Score
        {
            get { return _TeamASet5Score; }
            set { _TeamASet5Score = value; }
        }
        public string TeamBSet5Score
        {
            get { return _TeamBSet5Score; }
            set { _TeamBSet5Score = value; }
        }

        public string TeamACurSetScore
        {
            get { return _TeamACurSetScore; }
            set { _TeamACurSetScore = value; }
        }
        public string TeamBCurSetScore
        {
            get { return _TeamBCurSetScore; }
            set { _TeamBCurSetScore = value; }
        }

        public string SingleorDouble
        {
            get { return _SingleorDouble; }
            set { _SingleorDouble = value; }
        }
        public string Timer
        {
            get { return _Timer; }
            set { _Timer = value; }
        }
        public string TeamAServe
        {
            get { return _TeamAServe; }
            set { _TeamAServe = value; }
        }
        public string TeamBServe
        {
            get { return _TeamBServe; }
            set { _TeamBServe = value; }
        }
        public string TeamAPlayerfname1
        {
            get { return _TeamAPlayerfname1; }
            set { _TeamAPlayerfname1 = value; }
        }
        public string TeamBPlayerfname1
        {
            get { return _TeamBPlayerfname1; }
            set { _TeamBPlayerfname1 = value; }
        }
        public string TeamAPlayerlname1
        {
            get { return _TeamAPlayerlname1; }
            set { _TeamAPlayerlname1 = value; }
        }
        public string TeamBPlayerlname1
        {
            get { return _TeamBPlayerlname1; }
            set { _TeamBPlayerlname1 = value; }
        }

        public string TeamAPlayer2
        {
            get { return _TeamAPlayer2; }
            set { _TeamAPlayer2 = value; }
        }
        public string TeamBPlayer2
        {
            get { return _TeamBPlayer2; }
            set { _TeamBPlayer2 = value; }
        }

        public string GameStart
        {
            get { return _GameStart; }
            set { _GameStart = value; }
        }
        public string GameEnd
        {
            get { return _GameEnd; }
            set { _GameEnd = value; }
        }
        public string MatchStart
        {
            get { return _MatchStart; }
            set { _MatchStart = value; }
        }
        public string MatchEnd
        {
            get { return _MatchEnd; }
            set { _MatchEnd = value; }
        }
        #endregion

        #endregion
    }
    public class VizBasketballSendData : VizSendBasketballDataINF
    {
        #region BasketBall

        #region variable

        string _QuarterID { get; set; }
        string _TeamAName { get; set; }
        string _TeamBName { get; set; }
        string _TeamAPrefix { get; set; }
        string _TeamBPrefix { get; set; }
        //string _TeamASet1Score { get; set; }
        //string _TeamBSet1Score { get; set; }
        //string _TeamASet2Score { get; set; }
        //string _TeamBSet2Score { get; set; }
        //string _TeamASet3Score { get; set; }
        //string _TeamBSet3Score { get; set; }
        //string _TeamASet4Score { get; set; }
        //string _TeamBSet4Score { get; set; }
        //string _TeamASet5Score { get; set; }
        //string _TeamBSet5Score { get; set; }
        string _Timer { get; set; }
        string _TeamAScore { get; set; }
        string _TeamBScore { get; set; }
        string _Shottime { get; set; }

        //string _TeamAPlayerfname1 { get; set; }
        //string _TeamBPlayerfname1 { get; set; }
        //string _TeamAPlayerlname1 { get; set; }
        //string _TeamBPlayerlname1 { get; set; }

        //string _TeamAPlayer2 { get; set; }
        //string _TeamBPlayer2 { get; set; }

        //string _TeamACurSetScore { get; set; }
        //string _TeamBCurSetScore { get; set; }

        //string _SingleorDouble { get; set; }
        string _QuarterStart { get; set; }
        string _QuarterEnd { get; set; }
        string _MatchStart { get; set; }
        string _MatchEnd { get; set; }

        string _Runner { get; set; }
        string _Chaser { get; set; }

        #endregion

        #region VizSendDataINF Members

        public string QuarterID
        {
            get { return _QuarterID; }
            set { _QuarterID = value; }
        }
        public string TeamAName
        {
            get { return _TeamAName; }
            set { _TeamAName = value; }
        }
        public string TeamBName
        {
            get { return _TeamBName; }
            set { _TeamBName = value; }
        }
        public string TeamAPrefix
        {
            get { return _TeamAPrefix; }
            set { _TeamAPrefix = value; }
        }
        public string TeamBPrefix
        {
            get { return _TeamBPrefix; }
            set { _TeamBPrefix = value; }
        }
        //public string TeamASet1Score
        //{
        //    get { return _TeamASet1Score; }
        //    set { _TeamASet1Score = value; }
        //}
        //public string TeamBSet1Score
        //{
        //    get { return _TeamBSet1Score; }
        //    set { _TeamBSet1Score = value; }
        //}
        //public string TeamASet2Score
        //{
        //    get { return _TeamASet2Score; }
        //    set { _TeamASet2Score = value; }
        //}
        //public string TeamBSet2Score
        //{
        //    get { return _TeamBSet2Score; }
        //    set { _TeamBSet2Score = value; }
        //}
        //public string TeamASet3Score
        //{
        //    get { return _TeamASet3Score; }
        //    set { _TeamASet3Score = value; }
        //}
        //public string TeamBSet3Score
        //{
        //    get { return _TeamBSet3Score; }
        //    set { _TeamBSet3Score = value; }
        //}

        //public string TeamASet4Score
        //{
        //    get { return _TeamASet4Score; }
        //    set { _TeamASet4Score = value; }
        //}
        //public string TeamBSet4Score
        //{
        //    get { return _TeamBSet4Score; }
        //    set { _TeamBSet4Score = value; }
        //}

        //public string TeamASet5Score
        //{
        //    get { return _TeamASet5Score; }
        //    set { _TeamASet5Score = value; }
        //}
        //public string TeamBSet5Score
        //{
        //    get { return _TeamBSet5Score; }
        //    set { _TeamBSet5Score = value; }
        //}

        //public string TeamACurSetScore
        //{
        //    get { return _TeamACurSetScore; }
        //    set { _TeamACurSetScore = value; }
        //}
        //public string TeamBCurSetScore
        //{
        //    get { return _TeamBCurSetScore; }
        //    set { _TeamBCurSetScore = value; }
        //}

        //public string SingleorDouble
        //{
        //    get { return _SingleorDouble; }
        //    set { _SingleorDouble = value; }
        //}
        public string Timer
        {
            get { return _Timer; }
            set { _Timer = value; }
        }
        public string TeamAScore
        {
            get { return _TeamAScore; }
            set { _TeamAScore = value; }
        }
        public string TeamBScore
        {
            get { return _TeamBScore; }
            set { _TeamBScore = value; }
        }
        //public string TeamAPlayerfname1
        //{
        //    get { return _TeamAPlayerfname1; }
        //    set { _TeamAPlayerfname1 = value; }
        //}
        //public string TeamBPlayerfname1
        //{
        //    get { return _TeamBPlayerfname1; }
        //    set { _TeamBPlayerfname1 = value; }
        //}
        //public string TeamAPlayerlname1
        //{
        //    get { return _TeamAPlayerlname1; }
        //    set { _TeamAPlayerlname1 = value; }
        //}
        //public string TeamBPlayerlname1
        //{
        //    get { return _TeamBPlayerlname1; }
        //    set { _TeamBPlayerlname1 = value; }
        //}

        //public string TeamAPlayer2
        //{
        //    get { return _TeamAPlayer2; }
        //    set { _TeamAPlayer2 = value; }
        //}
        //public string TeamBPlayer2
        //{
        //    get { return _TeamBPlayer2; }
        //    set { _TeamBPlayer2 = value; }
        //}

        public string QuarterStart
        {
            get { return _QuarterStart; }
            set { _QuarterStart = value; }
        }
        public string GameEnd
        {
            get { return _QuarterEnd; }
            set { _QuarterEnd = value; }
        }
        public string MatchStart
        {
            get { return _MatchStart; }
            set { _MatchStart = value; }
        }
        public string MatchEnd
        {
            get { return _MatchEnd; }
            set { _MatchEnd = value; }
        }
        public string Shottime
        {
            get { return _Shottime; }
            set { _Shottime = value; }
        }
        public string Runner
        {
            get { return _Runner; }
            set { _Runner = value; }
        }
        public string Chaser
        {
            get { return _Chaser; }
            set { _Chaser = value; }
        }
        #endregion

        #endregion
    }
}
