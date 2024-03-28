using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace KabaddiPusher
{
    public class KabaddiXmlGenerate_Web
    {
        public void GenerateXML(DataSet Ds, string XmlFilename)
        {
            // MasterDAL masterDal = new MasterDAL("dbConnection");
            //var matchDetails = masterDal.GetDataSet("EXEC SP_MatchXML 1");
            DataTable teamStats = Ds.Tables[0];
            DataTable teamA_Players = Ds.Tables[1];
            DataTable teamB_Players = Ds.Tables[2];
            DataTable raids = Ds.Tables[3];
            //DataTable raids = matchDetails.Tables[3];
            DataTable result = Ds.Tables[4];
            DataTable MatchInfo = Ds.Tables[5];
            DataTable OtherEvents = Ds.Tables[6];

            XmlTextWriter writer = new XmlTextWriter(XmlFilename, System.Text.Encoding.Default);
            writer.WriteStartDocument(true);
            writer.Formatting = System.Xml.Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("in-match");

            writer.WriteStartElement("team-players-statistics");
            CreateTeamStats(writer, teamStats, teamA_Players, teamB_Players);
            writer.WriteEndElement();

            writer.WriteStartElement("play-by-play");
            CreatePlayByPlayStats(writer, raids);
            writer.WriteEndElement();

            writer.WriteStartElement("other-events");

            foreach (DataRow dr in OtherEvents.Rows)
            {
                writer.WriteStartElement("event");
                if (dr["event-name"].ToString().Contains("Card"))
                {
                    writer.WriteAttributeString("event-half", dr["event-half"].ToString()); // "1");
                    writer.WriteAttributeString("clock", dr["clock"].ToString()); // "10");
                    writer.WriteAttributeString("event-name", dr["event-name"].ToString()); // "Green Card");
                    writer.WriteAttributeString("player-id", dr["player-id"].ToString()); // "22");
                }
                else if (dr["event-name"].ToString() == "substitution")
                {
                    writer.WriteAttributeString("event-half", dr["event-half"].ToString()); // "1");
                    writer.WriteAttributeString("clock", dr["clock"].ToString()); // "10");
                    writer.WriteAttributeString("event-name", dr["event-name"].ToString()); // "substitution");
                    writer.WriteAttributeString("in-player-id", dr["in-player-id"].ToString()); // "22");
                    writer.WriteAttributeString("out-player-id", dr["out-player-id"].ToString()); // "22");
                }
                else if (dr["event-name"].ToString() == "Timeout")
                {
                    writer.WriteAttributeString("event-half", dr["event-half"].ToString()); // "1");
                    writer.WriteAttributeString("clock", dr["clock"].ToString()); // "10");
                    writer.WriteAttributeString("event-name", dr["event-name"].ToString()); // "Timeout");
                    if (dr["team-id"].ToString() != "0")
                        writer.WriteAttributeString("team-id", dr["team-id"].ToString()); // "22");
                   
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteStartElement("match-details");

            writer.WriteStartElement("match_info");
            if (MatchInfo.Rows.Count > 0)
            {
                writer.WriteAttributeString("matchid", MatchInfo.Rows[0]["matchid"].ToString()); // "28");
                writer.WriteAttributeString("stage", MatchInfo.Rows[0]["Stage"].ToString()); //"1");
                writer.WriteAttributeString("group", MatchInfo.Rows[0]["Group"].ToString()); //"");
                writer.WriteAttributeString("teama-id", MatchInfo.Rows[0]["teamaid"].ToString()); //"");
                writer.WriteAttributeString("teama", MatchInfo.Rows[0]["TeamA"].ToString()); //"Patna Pirates");
                writer.WriteAttributeString("teamb-id", MatchInfo.Rows[0]["teambid"].ToString()); //"");
                writer.WriteAttributeString("teamb", MatchInfo.Rows[0]["TeamB"].ToString()); //"Jaipur Pink Panthers");
                writer.WriteAttributeString("local-date", MatchInfo.Rows[0]["local_date"].ToString()); //"Jul 10 2016 12:00AM");
                writer.WriteAttributeString("venue", MatchInfo.Rows[0]["Venue"].ToString()); //"Patliputra Indoor Stadium");
                writer.WriteAttributeString("tosswin", MatchInfo.Rows[0]["TossWin"].ToString()); //"8");
                writer.WriteAttributeString("opted", MatchInfo.Rows[0]["Opted"].ToString()); //"Defence");
                writer.WriteAttributeString("status", MatchInfo.Rows[0]["Status"].ToString()); //"Completed");
                writer.WriteAttributeString("player_of_the_match", MatchInfo.Rows[0]["player_of_the_match"].ToString()); //"");
                writer.WriteAttributeString("player_of_the_match2", MatchInfo.Rows[0]["player_of_the_match2"].ToString()); //"");
                // writer.WriteAttributeString("match_no", MatchInfo.Rows[0]["match_no"].ToString()); //"Match #1");
            }

            writer.WriteEndElement();
            writer.WriteStartElement("result");
            if (result.Rows.Count > 0)
            {
                writer.WriteAttributeString("result-type", result.Rows[0]["result-type"].ToString()); // "w");
                writer.WriteAttributeString("winning-team-id", result.Rows[0]["winning-team-id"].ToString()); //"25");
                writer.WriteString(result.Rows[0]["Result"].ToString()); //"Haryana beat Indian Railways (25-24)");
            }

            writer.WriteEndElement();
            writer.WriteEndElement();


            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
            //createNode("1", "Product 1", "1000", writer);
        }

        private void CreateTeamStats(XmlTextWriter writer, DataTable teamStats, DataTable teamA_Players, DataTable teamB_Players)
        {
            for (int teamVal = 0; teamVal < 2; teamVal++)
            {
                writer.WriteStartElement("team");
                writer.WriteAttributeString("team-name", teamStats.Rows[teamVal]["team-name"].ToString()); // "Indian Railways");
                writer.WriteAttributeString("team-id", teamStats.Rows[teamVal]["team-id"].ToString()); //"24");

                #region Points
                writer.WriteStartElement("points");
                writer.WriteAttributeString("total-points", teamStats.Rows[teamVal]["total-points"].ToString()); // "24");

                writer.WriteStartElement("tackle-points");
                writer.WriteAttributeString("total-tackle-points", teamStats.Rows[teamVal]["total-tackle-points"].ToString()); // "5");
                writer.WriteStartElement("capture-points");
                writer.WriteString(teamStats.Rows[teamVal]["capture-points"].ToString()); //"4");
                writer.WriteEndElement();
                writer.WriteStartElement("tackle-bonus-points");
                writer.WriteString(teamStats.Rows[teamVal]["tackle-bonus-points"].ToString()); //"1");
                writer.WriteEndElement();
                writer.WriteEndElement();

                writer.WriteStartElement("raid-points");
                writer.WriteAttributeString("total-raid-points", teamStats.Rows[teamVal]["total-raid-points"].ToString()); //"15");
                writer.WriteStartElement("touch-points");
                writer.WriteString(teamStats.Rows[teamVal]["touch-points"].ToString()); //"11");
                writer.WriteEndElement();
                writer.WriteStartElement("raid-bonus-points");
                writer.WriteString(teamStats.Rows[teamVal]["raid-bonus-points"].ToString()); //"4");
                writer.WriteEndElement();
                writer.WriteEndElement();

                writer.WriteStartElement("all-out-points");
                writer.WriteString(teamStats.Rows[teamVal]["all-out-points"].ToString()); //"2");
                writer.WriteEndElement();

                writer.WriteStartElement("extra-points");
                writer.WriteString(teamStats.Rows[teamVal]["extra-points"].ToString()); //"2");
                writer.WriteEndElement();


                writer.WriteEndElement();
                #endregion

                #region Points last Minute
                writer.WriteStartElement("points-last-n-minutes");

                writer.WriteStartElement("five");
                writer.WriteString(teamStats.Rows[teamVal]["five"].ToString()); //"0");
                writer.WriteEndElement();

                writer.WriteStartElement("ten");
                writer.WriteString(teamStats.Rows[teamVal]["ten"].ToString()); //"4");
                writer.WriteEndElement();

                writer.WriteEndElement();
                #endregion

                #region Raids
                writer.WriteStartElement("raids");
                writer.WriteAttributeString("total-raids", teamStats.Rows[teamVal]["total-raids"].ToString()); //"16");
                writer.WriteAttributeString("super-raids", teamStats.Rows[teamVal]["super-raids"].ToString()); //"1");

                writer.WriteStartElement("successful-raids");
                writer.WriteString(teamStats.Rows[teamVal]["successful-raids"].ToString()); //"9");
                writer.WriteEndElement();

                writer.WriteStartElement("unsuccessful-raids");
                writer.WriteString(teamStats.Rows[teamVal]["unsuccessful-raids"].ToString()); //"4");
                writer.WriteEndElement();

                writer.WriteStartElement("empty-raids");
                writer.WriteString(teamStats.Rows[teamVal]["empty-raids"].ToString()); //"3");
                writer.WriteEndElement();

                writer.WriteEndElement();
                #endregion

                #region Tackles
                writer.WriteStartElement("tackles");
                writer.WriteAttributeString("total-tackles", teamStats.Rows[teamVal]["total-tackles"].ToString()); // "19");
                writer.WriteAttributeString("super-tackles", teamStats.Rows[teamVal]["super-tackles"].ToString()); // "1");

                writer.WriteStartElement("successful-tackles");
                writer.WriteString(teamStats.Rows[teamVal]["successful-tackles"].ToString()); //"4");
                writer.WriteEndElement();

                writer.WriteStartElement("unsuccessful-tackles");
                writer.WriteString(teamStats.Rows[teamVal]["unsuccessful-tackles"].ToString()); //"15");
                writer.WriteEndElement();

                writer.WriteEndElement();
                #endregion

                #region Do or die
                writer.WriteStartElement("do-or-die");
                writer.WriteAttributeString("total-raids", teamStats.Rows[teamVal]["do-total-raids"].ToString()); // "0");

                writer.WriteStartElement("successfull-raids");
                writer.WriteString(teamStats.Rows[teamVal]["do-successfull-raids"].ToString()); //"0");
                writer.WriteEndElement();

                writer.WriteStartElement("failed-raids");
                writer.WriteString(teamStats.Rows[teamVal]["do-failed-raids"].ToString()); //"0");
                writer.WriteEndElement();

                writer.WriteStartElement("super-raids");
                writer.WriteString(teamStats.Rows[teamVal]["do-super-raids"].ToString()); //"0");
                writer.WriteEndElement();

                writer.WriteStartElement("raid-points");
                writer.WriteString(teamStats.Rows[teamVal]["do-raid-points"].ToString()); //"0");
                writer.WriteEndElement();

                writer.WriteStartElement("touch-points");
                writer.WriteString(teamStats.Rows[teamVal]["do-touch-points"].ToString()); //"0");
                writer.WriteEndElement();

                writer.WriteStartElement("bonus-points");
                writer.WriteString(teamStats.Rows[teamVal]["do-bonus-points"].ToString()); //"0");
                writer.WriteEndElement();

                writer.WriteEndElement();
                #endregion

                #region Players

                var players = new DataTable();
                if (teamVal == 0)
                    players = teamA_Players;
                else
                    players = teamB_Players;
                writer.WriteStartElement("players");

                for (int i = 0; i < players.Rows.Count; i++)
                {
                    writer.WriteStartElement("player");
                    writer.WriteAttributeString("player-id", players.Rows[i]["player-id"].ToString()); //"42");
                    writer.WriteAttributeString("player-name", players.Rows[i]["player-name"].ToString()); //"Dharmaraj Cheralathan");
                    writer.WriteAttributeString("jercyno", players.Rows[i]["JercyNo"].ToString()); //"1");
                    writer.WriteAttributeString("role", players.Rows[i]["Role"].ToString()); //"Defender");
                    //writer.WriteAttributeString("skill", players.Rows[i]["skill"].ToString()); //"Defender");
                    writer.WriteAttributeString("isStarted", players.Rows[i]["isStarted"].ToString()); //"0");
                    if (Convert.ToBoolean(players.Rows[i]["player-raiding-now"]))
                        writer.WriteAttributeString("player-raiding-now", "true"); //"Dharmaraj Cheralathan");
                    if (Convert.ToBoolean(players.Rows[i]["player-on-court"]))
                        writer.WriteAttributeString("player-on-court", "true"); //"Dharmaraj Cheralathan");
                    if (!Convert.ToBoolean(players.Rows[i]["player-on-court"]) && Convert.ToString(players.Rows[i]["player-revival-order"]) != "0")
                        writer.WriteAttributeString("player-revival-order", Convert.ToString(players.Rows[i]["player-revival-order"])); //"1");

                    #region Points
                    writer.WriteStartElement("points");
                    writer.WriteAttributeString("total-points", players.Rows[i]["total-points"].ToString()); // "3");

                    writer.WriteStartElement("raid-points");
                    writer.WriteAttributeString("total-raid-points", players.Rows[i]["total-raid-points"].ToString()); //"0");
                    writer.WriteStartElement("touch-points");
                    writer.WriteAttributeString("total-touch-points", players.Rows[i]["total-touch-points"].ToString()); //"0");
                    #region Touch-Skill
                    writer.WriteStartElement("skill-points");
                    writer.WriteAttributeString("skill-id", players.Rows[i]["r-skill-id"].ToString()); // "1");
                    //Skill Points
                    writer.WriteString("0");
                    writer.WriteEndElement();
                    #endregion
                    writer.WriteEndElement();
                    writer.WriteStartElement("raid-bonus-points");
                    writer.WriteString(players.Rows[i]["raid-bonus-points"].ToString()); //"0");
                    writer.WriteEndElement();
                    writer.WriteEndElement();

                    writer.WriteStartElement("tackle-points");
                    writer.WriteAttributeString("total-tackle-points", players.Rows[i]["total-tackle-points"].ToString()); // "3");
                    writer.WriteStartElement("capture-points");
                    writer.WriteAttributeString("total-capture-points", players.Rows[i]["total-capture-points"].ToString()); //"2");
                    #region Tackle-Skill
                    writer.WriteStartElement("skill-points");
                    writer.WriteAttributeString("skill-id", players.Rows[i]["t-skill-id"].ToString()); //"11");
                    //Skill Points
                    writer.WriteString("0");
                    writer.WriteEndElement();
                    #endregion
                    writer.WriteEndElement();
                    writer.WriteStartElement("tackle-bonus-points");
                    writer.WriteString(players.Rows[i]["tackle-bonus-points"].ToString()); //"1");
                    writer.WriteEndElement();
                    writer.WriteEndElement();

                    writer.WriteEndElement();
                    #endregion

                    #region Raids
                    writer.WriteStartElement("raids");
                    writer.WriteAttributeString("total-raids", players.Rows[i]["total-raids"].ToString()); // "0");
                    writer.WriteAttributeString("super-raids", players.Rows[i]["super-raids"].ToString()); // "0");

                    writer.WriteStartElement("successful-raids");
                    writer.WriteString(players.Rows[i]["successful-raids"].ToString()); //"0");
                    writer.WriteEndElement();

                    writer.WriteStartElement("unsuccessful-raids");
                    writer.WriteString(players.Rows[i]["unsuccessful-raids"].ToString()); //"0");
                    writer.WriteEndElement();

                    writer.WriteStartElement("empty-raids");
                    writer.WriteString(players.Rows[i]["empty-raids"].ToString()); //"0");
                    writer.WriteEndElement();

                    writer.WriteEndElement();
                    #endregion

                    #region Tackles
                    writer.WriteStartElement("tackles");
                    writer.WriteAttributeString("total-tackles", players.Rows[i]["total-tackles"].ToString()); //"3");
                    writer.WriteAttributeString("super-tackles", players.Rows[i]["super-tackles"].ToString()); //"1");

                    writer.WriteStartElement("successful-tackles");
                    writer.WriteString(players.Rows[i]["successful-tackles"].ToString()); //"2");
                    writer.WriteEndElement();

                    writer.WriteStartElement("unsuccessful-tackles");
                    writer.WriteString(players.Rows[i]["unsuccessful-tackles"].ToString()); //"1");
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    #endregion

                    writer.WriteStartElement("time-off-court");
                    writer.WriteString(players.Rows[i]["time-off-court"].ToString()); //"31");
                    writer.WriteEndElement();

                    #region Do or die
                    writer.WriteStartElement("do-or-die");
                    //do-total-raids
                    writer.WriteAttributeString("total-raids", players.Rows[i]["do-total-raids"].ToString()); // "0");

                    writer.WriteStartElement("successfull-raids");
                    writer.WriteString(players.Rows[i]["do-successfull-raids"].ToString()); //"0");
                    writer.WriteEndElement();

                    writer.WriteStartElement("failed-raids");
                    writer.WriteString(players.Rows[i]["do-failed-raids"].ToString()); //"0");
                    writer.WriteEndElement();

                    writer.WriteStartElement("super-raids");
                    writer.WriteString(players.Rows[i]["do-super-raids"].ToString()); //"0");
                    writer.WriteEndElement();

                    writer.WriteStartElement("raid-points");
                    writer.WriteString(players.Rows[i]["do-raid-points"].ToString()); //"0");
                    writer.WriteEndElement();

                    writer.WriteStartElement("touch-points");
                    writer.WriteString(players.Rows[i]["do-touch-points"].ToString()); //"0");
                    writer.WriteEndElement();

                    writer.WriteStartElement("bonus-points");
                    writer.WriteString(players.Rows[i]["do-bonus-points"].ToString()); //"0");
                    writer.WriteEndElement();

                    writer.WriteEndElement();
                    #endregion

                    writer.WriteStartElement("avg-raid-time");
                    writer.WriteString(players.Rows[i]["avg-raid-time"].ToString()); //"0");
                    writer.WriteEndElement();

                    #region Raid Map Location
                    writer.WriteStartElement("raid-map-locations");

                    for (int x = 1; x <= 11; x++)
                    {
                        writer.WriteStartElement("location");
                        writer.WriteAttributeString("location-id", x.ToString());
                        writer.WriteStartElement("strong");
                        writer.WriteString(players.Rows[i]["strong"].ToString()); //"0");
                        writer.WriteEndElement();
                        writer.WriteStartElement("weak");
                        writer.WriteString(players.Rows[i]["weak"].ToString()); //"0");
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                    #endregion


                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                #endregion

                writer.WriteEndElement();
            }
        }

        private void CreatePlayByPlayStats(XmlTextWriter writer, DataTable raids)
        {
            for (int i = 0; i < raids.Rows.Count; i++)
            {
                writer.WriteStartElement("raid");
                writer.WriteAttributeString("raid-number", raids.Rows[i]["raid-number"].ToString()); // i.ToString());
                writer.WriteAttributeString("raiding-team-id", raids.Rows[i]["raiding-team-id"].ToString()); //"24");
                writer.WriteAttributeString("raiding-player-id", raids.Rows[i]["raiding-player-id"].ToString()); //"264");
                writer.WriteAttributeString("raid-outcome-id", raids.Rows[i]["raid-outcome-id"].ToString()); //"2");
                writer.WriteAttributeString("raid-half", raids.Rows[i]["raid-half"].ToString()); //"1");
                writer.WriteAttributeString("clock", raids.Rows[i]["clock"].ToString()); //"1");

                for (int x = 0; x < 2; x++)
                {
                    if (x == 0)
                    {
                        writer.WriteStartElement("team");
                        writer.WriteAttributeString("team-id", raids.Rows[i]["a-team-id"].ToString()); //"24");
                        writer.WriteAttributeString("total-points", raids.Rows[i]["a-total-points"].ToString()); //"0");

                        writer.WriteStartElement("points");
                        writer.WriteAttributeString("total-points", raids.Rows[i]["a-total-points"].ToString()); //"0");

                        writer.WriteStartElement("raid-points");
                        writer.WriteAttributeString("total-raid-points", raids.Rows[i]["a-total-raid-points"].ToString()); //"0");
                        writer.WriteStartElement("touch-points");
                        writer.WriteString(raids.Rows[i]["a-touch-points"].ToString()); //"0");
                        writer.WriteEndElement();
                        writer.WriteStartElement("raid-bonus-points");
                        writer.WriteString(raids.Rows[i]["a-raid-bonus-points"].ToString()); //"0");
                        writer.WriteEndElement();
                        writer.WriteEndElement();

                        writer.WriteStartElement("tackle-points");
                        writer.WriteAttributeString("total-tackle-points", raids.Rows[i]["a-total-tackle-points"].ToString()); // "0");
                        writer.WriteEndElement();

                        writer.WriteStartElement("all-out-points");
                        writer.WriteString(raids.Rows[i]["a-all-out-points"].ToString()); //"0");
                        writer.WriteEndElement();

                        writer.WriteStartElement("extra-points");
                        writer.WriteString(raids.Rows[i]["a-extra-points"].ToString()); //"0");
                        writer.WriteEndElement();

                        writer.WriteEndElement();
                        writer.WriteEndElement();
                    }
                    else
                    {
                        writer.WriteStartElement("team");
                        writer.WriteAttributeString("team-id", raids.Rows[i]["b-team-id"].ToString()); //"24");
                        writer.WriteAttributeString("total-points", raids.Rows[i]["b-total-points"].ToString()); //"0");

                        writer.WriteStartElement("points");
                        writer.WriteAttributeString("total-points", raids.Rows[i]["b-total-points"].ToString()); //"0");

                        writer.WriteStartElement("raid-points");
                        writer.WriteAttributeString("total-raid-points", raids.Rows[i]["b-total-raid-points"].ToString()); //"0");
                        writer.WriteEndElement();
                        writer.WriteStartElement("tackle-points");
                        writer.WriteAttributeString("total-tackle-points", raids.Rows[i]["b-total-tackle-points"].ToString()); //"0");
                        writer.WriteStartElement("capture-points");
                        writer.WriteString(raids.Rows[i]["b-capture-points"].ToString()); //"0");
                        writer.WriteEndElement();
                        writer.WriteStartElement("tackle-bonus-points");
                        writer.WriteString(raids.Rows[i]["b-tackle-bonus-points"].ToString()); //"0");
                        writer.WriteEndElement();
                        writer.WriteEndElement();

                        writer.WriteStartElement("all-out-points");
                        writer.WriteString(raids.Rows[i]["b-all-out-points"].ToString()); //"0");
                        writer.WriteEndElement();

                        writer.WriteStartElement("extra-points");
                        writer.WriteString(raids.Rows[i]["b-extra-points"].ToString()); //"0");
                        writer.WriteEndElement();

                        writer.WriteEndElement();
                        writer.WriteEndElement();
                    }
                }
                writer.WriteEndElement();
            }
        }


        public void GeneratePrematchXML(DataSet Ds, string XmlFilename)
        {
            //   MasterDAL masterDal = new MasterDAL("dbConnection");
            // var preMatchDetails = masterDal.GetDataSet("EXEC SP_PreMatchXML");
            DataTable teamDetails = Ds.Tables[0];
            DataTable playerDetails = Ds.Tables[1];
            DataTable playerStatDetails = Ds.Tables[2];

            XmlTextWriter writer = new XmlTextWriter(XmlFilename, System.Text.Encoding.Default);
            writer.WriteStartDocument(true);
            writer.Formatting = System.Xml.Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("pre-match");
            writer.WriteStartElement("team-players-statistics");
            foreach (DataRow team in teamDetails.Rows)
            {
                writer.WriteStartElement("team");
                writer.WriteAttributeString("team-id", Convert.ToString(team["team-id"]));
                writer.WriteAttributeString("team-name", Convert.ToString(team["team-name"]));

                writer.WriteStartElement("Matches");
                writer.WriteString(Convert.ToString(team["Matches"]));
                writer.WriteEndElement();

                writer.WriteStartElement("won");
                writer.WriteString(Convert.ToString(team["won"]));
                writer.WriteEndElement();

                writer.WriteStartElement("lost");
                writer.WriteString(Convert.ToString(team["lost"]));
                writer.WriteEndElement();

                writer.WriteStartElement("tied");
                writer.WriteString(Convert.ToString(team["tied"]));
                writer.WriteEndElement();

                #region Points
                writer.WriteStartElement("points");
                writer.WriteAttributeString("total-points", Convert.ToString(team["total-points"]));

                writer.WriteStartElement("raid-points");
                writer.WriteAttributeString("total-raid-points", Convert.ToString(team["total-raid-points"]));
                writer.WriteStartElement("touch-points");
                writer.WriteString(Convert.ToString(team["touch-points"]));
                writer.WriteEndElement();
                writer.WriteStartElement("raid-bonus-points");
                writer.WriteString(Convert.ToString(team["raid-bonus-points"]));
                writer.WriteEndElement();
                writer.WriteEndElement();

                writer.WriteStartElement("tackle-points");
                writer.WriteAttributeString("total-tackle-points", Convert.ToString(team["total-tackle-points"]));
                writer.WriteStartElement("capture-points");
                writer.WriteString(Convert.ToString(team["capture-points"]));
                writer.WriteEndElement();
                writer.WriteStartElement("tackle-bonus-points");
                writer.WriteString(Convert.ToString(team["tackle-bonus-points"]));
                writer.WriteEndElement();
                writer.WriteEndElement();

                writer.WriteStartElement("all-out-points");
                writer.WriteString(Convert.ToString(team["all-out-points"]));
                writer.WriteEndElement();

                writer.WriteStartElement("extra-points");
                writer.WriteString(Convert.ToString(team["extra-points"]));
                writer.WriteEndElement();

                writer.WriteEndElement();
                #endregion

                #region Raids

                writer.WriteStartElement("raids");
                writer.WriteAttributeString("total-raids", Convert.ToString(team["total-raids"]));
                writer.WriteAttributeString("super-raids", Convert.ToString(team["super-raids"]));

                writer.WriteStartElement("successful-raids");
                writer.WriteString(Convert.ToString(team["successful-raids"]));
                writer.WriteEndElement();

                writer.WriteStartElement("unsuccessful-raids");
                writer.WriteString(Convert.ToString(team["unsuccessful-raids"]));
                writer.WriteEndElement();

                writer.WriteStartElement("empty-raids");
                writer.WriteString(Convert.ToString(team["empty-raids"]));
                writer.WriteEndElement();

                writer.WriteEndElement();
                #endregion

                #region Tackles

                writer.WriteStartElement("tackles");
                writer.WriteAttributeString("total-tackles", Convert.ToString(team["total-tackles"]));
                writer.WriteAttributeString("super-tackles", Convert.ToString(team["super-tackles"]));

                writer.WriteStartElement("successful-tackles");
                writer.WriteString(Convert.ToString(team["successful-tackles"]));
                writer.WriteEndElement();

                writer.WriteStartElement("unsuccessful-tackles");
                writer.WriteString(Convert.ToString(team["unsuccessful-tackles"]));
                writer.WriteEndElement();

                writer.WriteEndElement();
                #endregion

                #region Do or die
                writer.WriteStartElement("do-or-die");
                writer.WriteAttributeString("total-raids", Convert.ToString(team["do-total-raids"]));

                writer.WriteStartElement("successfull-raids");
                writer.WriteString(Convert.ToString(team["do-successful-raids"]));
                writer.WriteEndElement();

                writer.WriteStartElement("failed-raids");
                writer.WriteString(Convert.ToString(team["do-failed-raids"]));
                writer.WriteEndElement();

                writer.WriteStartElement("super-raids");
                //Do super raids
                writer.WriteString(Convert.ToString(team["do-super-raids"]));
                writer.WriteEndElement();

                writer.WriteStartElement("raid-points");
                writer.WriteString(Convert.ToString(team["do-raid-points"]));
                writer.WriteEndElement();

                writer.WriteStartElement("touch-points");
                writer.WriteString(Convert.ToString(team["do-touch-points"]));
                writer.WriteEndElement();

                writer.WriteStartElement("bonus-points");
                writer.WriteString(Convert.ToString(team["do-bonus-points"]));
                writer.WriteEndElement();

                writer.WriteEndElement();
                #endregion

                #region Players
                var players = playerDetails.Select("[Team-Id] = '" + Convert.ToString(team["team-id"]) + "'").CopyToDataTable();

                writer.WriteStartElement("players");

                foreach (DataRow player in players.Rows)
                {
                    writer.WriteStartElement("player");
                    writer.WriteAttributeString("player-id", Convert.ToString(player["player-id"]));
                    writer.WriteAttributeString("player-name", Convert.ToString(player["player-name"]));

                    writer.WriteStartElement("full-name");
                    writer.WriteString(Convert.ToString(player["full-name"]));
                    writer.WriteEndElement();

                    writer.WriteStartElement("short-name");
                    writer.WriteString(Convert.ToString(player["short-name"]));
                    writer.WriteEndElement();

                    writer.WriteStartElement("jersey-no");
                    writer.WriteString(Convert.ToString(player["jersey-no"]));
                    writer.WriteEndElement();

                    writer.WriteStartElement("date-of-birth");
                    writer.WriteString(Convert.ToString(player["date-of-birth"]));
                    writer.WriteEndElement();

                    writer.WriteStartElement("high_five");
                    writer.WriteString(Convert.ToString(player["high_five"]));
                    writer.WriteEndElement();

                    writer.WriteStartElement("super_ten");
                    writer.WriteString(Convert.ToString(player["super_ten"]));
                    writer.WriteEndElement();

                    writer.WriteStartElement("Matches");
                    writer.WriteString(Convert.ToString(player["Matches"]));
                    writer.WriteEndElement();

                    writer.WriteStartElement("Matches_raided");
                    writer.WriteString(Convert.ToString(player["Matches_raided"]));
                    writer.WriteEndElement();

                    #region Role
                    writer.WriteStartElement("roles");
                    for (int roleNo = 1; roleNo <= 3; roleNo++)
                    {
                        writer.WriteStartElement("role");
                        writer.WriteAttributeString("role-id", Convert.ToString(roleNo));
                        //Role is primary
                        if (Convert.ToInt32(player["role-id"]) == roleNo)
                            writer.WriteAttributeString("role-isprimary", "1");
                        else
                            writer.WriteAttributeString("role-isprimary", "0");
                        writer.WriteStartElement("rating");
                        writer.WriteString(Convert.ToString(player["rating"]));
                        writer.WriteEndElement();
                        writer.WriteStartElement("skill-id");
                        writer.WriteString(Convert.ToString(player["skill-id"]));
                        writer.WriteEndElement();
                        writer.WriteStartElement("career-best-points");
                        writer.WriteString(Convert.ToString(player["career-best-points"]));
                        writer.WriteEndElement();

                        writer.WriteEndElement();
                    }
                    if (Convert.ToInt32(player["role-id"])==3)
                    {
                        writer.WriteStartElement("role");
                        writer.WriteAttributeString("role-id", Convert.ToString(3));
                        //Role is primary
                        if (Convert.ToInt32(player["role-id"]) == 3)
                            writer.WriteAttributeString("role-isprimary", "1");
                        else
                            writer.WriteAttributeString("role-isprimary", "0");
                        writer.WriteStartElement("rating");
                        writer.WriteString(Convert.ToString(player["rating"]));
                        writer.WriteEndElement();
                        writer.WriteStartElement("skill-id");
                        writer.WriteString(Convert.ToString(player["skill-id"]));
                        writer.WriteEndElement();
                        writer.WriteStartElement("career-best-points");
                        writer.WriteString(Convert.ToString(player["career-best-points"]));
                        writer.WriteEndElement();

                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                    #endregion

                    #region Impacts
                    writer.WriteStartElement("impacts");

                    writer.WriteStartElement("against_six_or_more_antis");
                    writer.WriteString("0");
                    writer.WriteEndElement();
                    writer.WriteStartElement("against_five_antis");
                    writer.WriteString("0");
                    writer.WriteEndElement();
                    writer.WriteStartElement("against_four_antis");
                    writer.WriteString("0");
                    writer.WriteEndElement();
                    writer.WriteStartElement("against_three_or_less_antis");
                    writer.WriteString("0");
                    writer.WriteEndElement();

                    writer.WriteEndElement();
                    #endregion

                    #region Points
                    writer.WriteStartElement("points");
                    writer.WriteAttributeString("total-points", Convert.ToString(player["total-points"]));

                    writer.WriteStartElement("raid-points");
                    writer.WriteAttributeString("total-raid-points", Convert.ToString(player["total-raid-points"]));

                    writer.WriteStartElement("touch-points");
                    writer.WriteAttributeString("total-touch-points", Convert.ToString(player["total-touch-points"]));
                    for (int skillVal = 1; skillVal <= 9; skillVal++)
                    {
                        writer.WriteStartElement("skill-points");
                        writer.WriteAttributeString("skill-id", Convert.ToString(player["r-skill-id"]));
                        writer.WriteString("0");
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();

                    writer.WriteStartElement("raid-bonus-points");
                    writer.WriteString(Convert.ToString(player["raid-bonus-points"]));

                    writer.WriteEndElement();

                    writer.WriteEndElement();


                    writer.WriteStartElement("tackle-points");
                    writer.WriteAttributeString("total-tackle-points", Convert.ToString(player["total-tackle-points"]));

                    writer.WriteStartElement("capture-points");
                    writer.WriteAttributeString("total-capture-points", Convert.ToString(player["total-capture-points"]));
                    for (int skillVal = 11; skillVal <= 21; skillVal++)
                    {
                        writer.WriteStartElement("skill-points");
                        writer.WriteAttributeString("skill-id", Convert.ToString(player["t-skill-id"]));
                        writer.WriteString("0");
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                    writer.WriteStartElement("tackle-bonus-points");
                    writer.WriteString(Convert.ToString(player["tackle-bonus-points"]));
                    writer.WriteEndElement();

                    writer.WriteEndElement();

                    writer.WriteEndElement();
                    #endregion

                    #region Raids
                    writer.WriteStartElement("raids");
                    writer.WriteAttributeString("total-raids", Convert.ToString(player["total-raids"]));
                    writer.WriteAttributeString("super-raids", Convert.ToString(player["super-raids"]));

                    writer.WriteStartElement("successful-raids");
                    writer.WriteString(Convert.ToString(player["successful-raids"]));
                    writer.WriteEndElement();
                    writer.WriteStartElement("unsuccessful-raids");
                    writer.WriteString(Convert.ToString(player["unsuccessful-raids"]));
                    writer.WriteEndElement();
                    writer.WriteStartElement("empty-raids");
                    writer.WriteString(Convert.ToString(player["empty-raids"]));
                    writer.WriteEndElement();

                    writer.WriteEndElement();
                    #endregion

                    #region Tackles
                    writer.WriteStartElement("tackles");
                    writer.WriteAttributeString("total-tackles", Convert.ToString(player["total-tackles"]));
                    writer.WriteAttributeString("super-tackles", Convert.ToString(player["super-tackles"]));

                    writer.WriteStartElement("successful-tackles");
                    writer.WriteString(Convert.ToString(player["successful-tackles"]));
                    writer.WriteEndElement();
                    writer.WriteStartElement("unsuccessful-tackles");
                    writer.WriteString(Convert.ToString(player["unsuccessful-tackles"]));
                    writer.WriteEndElement();

                    writer.WriteEndElement();
                    #endregion

                    #region Do or die
                    writer.WriteStartElement("do-or-die");
                    writer.WriteAttributeString("total-raids", Convert.ToString(player["do-total-raids"]));

                    writer.WriteStartElement("successfull-raids");
                    writer.WriteString(Convert.ToString(player["do-successful-raids"]));
                    writer.WriteEndElement();
                    writer.WriteStartElement("failed-raids");
                    writer.WriteString(Convert.ToString(player["do-failed-raids"]));
                    writer.WriteEndElement();
                    writer.WriteStartElement("super-raids");
                    //do super raids
                    writer.WriteString(Convert.ToString(team["do-super-raids"]));
                    writer.WriteString("");
                    writer.WriteEndElement();
                    writer.WriteStartElement("raid-points");
                    writer.WriteString(Convert.ToString(player["do-raid-points"]));
                    writer.WriteEndElement();
                    writer.WriteStartElement("touch-points");
                    writer.WriteString(Convert.ToString(player["do-touch-points"]));
                    writer.WriteEndElement();
                    writer.WriteStartElement("bonus-points");
                    writer.WriteString(Convert.ToString(player["do-bonus-points"]));
                    writer.WriteEndElement();

                    writer.WriteEndElement();
                    #endregion

                    #region Assists
                    writer.WriteStartElement("assists");
                    writer.WriteString(Convert.ToString(player["assists"]));
                    writer.WriteEndElement();
                    #endregion

                    #region Ride map locations
                    writer.WriteStartElement("raid-map-locations");
                    for (int locationNo = 1; locationNo <= 11; locationNo++)
                    {
                        writer.WriteStartElement("location");
                        writer.WriteAttributeString("location-id", Convert.ToString(player["location-id"]));
                        writer.WriteStartElement("strong");
                        writer.WriteString(Convert.ToString(player["strong"]));
                        writer.WriteEndElement();
                        writer.WriteStartElement("weak");
                        writer.WriteString(Convert.ToString(player["weak"]));
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                    #endregion

                    var playerStats = playerStatDetails.Select("[player-id] = '" + Convert.ToString(player["player-id"]) + "'").CopyToDataTable();
                    if (playerStats.Rows.Count > 0)
                    {
                        foreach (DataRow playerStat in playerStats.Rows)
                        {
                            writer.WriteStartElement("performance-against-team");
                            writer.WriteAttributeString("team-id", Convert.ToString(playerStat["Opp-Team-Id"]));

                            writer.WriteStartElement("matches");
                            writer.WriteString(Convert.ToString(player["Matches"]));
                            writer.WriteEndElement();

                            writer.WriteStartElement("points");
                            writer.WriteAttributeString("total-points", Convert.ToString(playerStat["total-points"]));

                            writer.WriteStartElement("raid-points");
                            writer.WriteAttributeString("total-raid-points", Convert.ToString(playerStat["total-raid-points"]));
                            writer.WriteStartElement("touch-points");
                            writer.WriteAttributeString("total-touch-points", Convert.ToString(playerStat["total-touch-points"]));
                            writer.WriteEndElement();
                            writer.WriteStartElement("raid-bonus-points");
                            writer.WriteString(Convert.ToString(player["raid-bonus-points"]));
                            writer.WriteEndElement();
                            writer.WriteEndElement();
                            writer.WriteStartElement("tackle-points");
                            writer.WriteAttributeString("total-tackle-points", Convert.ToString(playerStat["total-tackle-points"]));
                            writer.WriteStartElement("capture-points");
                            writer.WriteAttributeString("total-capture-points", Convert.ToString(playerStat["total-capture-points"]));
                            writer.WriteEndElement();
                            writer.WriteStartElement("tackle-bonus-points");
                            writer.WriteString(Convert.ToString(player["tackle-bonus-points"]));
                            writer.WriteEndElement();
                            writer.WriteEndElement();

                            writer.WriteEndElement();

                            writer.WriteStartElement("raids");
                            writer.WriteAttributeString("total-raids", Convert.ToString(playerStat["total-raids"]));
                            writer.WriteAttributeString("super-raids", Convert.ToString(playerStat["super-raids"]));

                            writer.WriteStartElement("successful-raids");
                            writer.WriteString(Convert.ToString(player["successful-raids"]));
                            writer.WriteEndElement();
                            writer.WriteStartElement("unsuccessful-raids");
                            writer.WriteString(Convert.ToString(player["unsuccessful-raids"]));
                            writer.WriteEndElement();
                            writer.WriteStartElement("empty-raids");
                            writer.WriteString(Convert.ToString(player["empty-raids"]));
                            writer.WriteEndElement();

                            writer.WriteEndElement();

                            writer.WriteStartElement("tackles");
                            writer.WriteAttributeString("total-tackles", Convert.ToString(playerStat["total-tackles"]));
                            writer.WriteAttributeString("super-tackles", Convert.ToString(playerStat["super-tackles"]));

                            writer.WriteStartElement("successful-tackles");
                            writer.WriteString(Convert.ToString(player["successful-tackles"]));
                            writer.WriteEndElement();
                            writer.WriteStartElement("unsuccessful-tackles");
                            writer.WriteString(Convert.ToString(player["unsuccessful-tackles"]));
                            writer.WriteEndElement();

                            writer.WriteEndElement();

                            writer.WriteEndElement();
                        }
                    }
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                #endregion

                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }
    }
}
