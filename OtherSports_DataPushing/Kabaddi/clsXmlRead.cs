using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace clsXmlRead
    {
            [XmlRoot(ElementName = "tackle-points")]
            public class Tacklepoints
            {
                [XmlElement(ElementName = "tackle-bonus-points")]
                public string Tacklebonuspoints { get; set; }
                [XmlAttribute(AttributeName = "total-tackle-points")]
                public string Totaltacklepoints { get; set; }
                [XmlElement(ElementName = "capture-points")]
                public Capturepoints Capturepoints { get; set; }
            }

            [XmlRoot(ElementName = "raid-points")]
            public class Raidpoints
            {
                [XmlElement(ElementName = "raid-bonus-points")]
                public string Raidbonuspoints { get; set; }
                [XmlAttribute(AttributeName = "total-raid-points")]
                public string Totalraidpoints { get; set; }
                [XmlElement(ElementName = "touch-points")]
                public Touchpoints Touchpoints { get; set; }
            }

            [XmlRoot(ElementName = "points")]
            public class Points
            {
                [XmlElement(ElementName = "tackle-points")]
                public Tacklepoints Tacklepoints { get; set; }
                [XmlElement(ElementName = "raid-points")]
                public Raidpoints Raidpoints { get; set; }
                [XmlElement(ElementName = "all-out-points")]
                public string Alloutpoints { get; set; }
                [XmlElement(ElementName = "extra-points")]
                public string Extrapoints { get; set; }
                [XmlAttribute(AttributeName = "total-points")]
                public string Totalpoints { get; set; }
            }

            [XmlRoot(ElementName = "points-last-n-minutes")]
            public class Pointslastnminutes
            {
                [XmlElement(ElementName = "five")]
                public string Five { get; set; }
                [XmlElement(ElementName = "ten")]
                public string Ten { get; set; }
            }

            [XmlRoot(ElementName = "raids")]
            public class Raids
            {
                [XmlElement(ElementName = "successful-raids")]
                public string Successfulraids { get; set; }
                [XmlElement(ElementName = "unsuccessful-raids")]
                public string Unsuccessfulraids { get; set; }
                [XmlElement(ElementName = "empty-raids")]
                public string Emptyraids { get; set; }
                [XmlAttribute(AttributeName = "total-raids")]
                public string Totalraids { get; set; }
                [XmlAttribute(AttributeName = "super-raids")]
                public string Superraids { get; set; }
            }

            [XmlRoot(ElementName = "tackles")]
            public class Tackles
            {
                [XmlElement(ElementName = "successful-tackles")]
                public string Successfultackles { get; set; }
                [XmlElement(ElementName = "unsuccessful-tackles")]
                public string Unsuccessfultackles { get; set; }
                [XmlAttribute(AttributeName = "total-tackles")]
                public string Totaltackles { get; set; }
                [XmlAttribute(AttributeName = "super-tackles")]
                public string Supertackles { get; set; }
            }

            [XmlRoot(ElementName = "do-or-die")]
            public class Doordie
            {
                [XmlElement(ElementName = "successfull-raids")]
                public string Successfullraids { get; set; }
                [XmlElement(ElementName = "failed-raids")]
                public string Failedraids { get; set; }
                [XmlElement(ElementName = "super-raids")]
                public string Superraids { get; set; }
                [XmlElement(ElementName = "raid-points")]
                public string Raidpoints { get; set; }
                [XmlElement(ElementName = "touch-points")]
                public string Touchpoints { get; set; }
                [XmlElement(ElementName = "bonus-points")]
                public string Bonuspoints { get; set; }
                [XmlAttribute(AttributeName = "total-raids")]
                public string Totalraids { get; set; }
            }

            [XmlRoot(ElementName = "skill-points")]
            public class Skillpoints
            {
                [XmlAttribute(AttributeName = "skill-id")]
                public string Skillid { get; set; }
                [XmlText]
                public string Text { get; set; }
            }

            [XmlRoot(ElementName = "touch-points")]
            public class Touchpoints
            {
                [XmlElement(ElementName = "skill-points")]
                public Skillpoints Skillpoints { get; set; }
                [XmlAttribute(AttributeName = "total-touch-points")]
                public string Totaltouchpoints { get; set; }
            }

            [XmlRoot(ElementName = "capture-points")]
            public class Capturepoints
            {
                [XmlElement(ElementName = "skill-points")]
                public Skillpoints Skillpoints { get; set; }
                [XmlAttribute(AttributeName = "total-capture-points")]
                public string Totalcapturepoints { get; set; }
            }

            [XmlRoot(ElementName = "location")]
            public class Location
            {
                [XmlElement(ElementName = "strong")]
                public string Strong { get; set; }
                [XmlElement(ElementName = "weak")]
                public string Weak { get; set; }
                [XmlAttribute(AttributeName = "location-id")]
                public string Locationid { get; set; }
            }

            [XmlRoot(ElementName = "raid-map-locations")]
            public class Raidmaplocations
            {
                [XmlElement(ElementName = "location")]
                public List<Location> Location { get; set; }
            }

            [XmlRoot(ElementName = "player")]
            public class Player
            {
                [XmlElement(ElementName = "points")]
                public Points Points { get; set; }
                [XmlElement(ElementName = "raids")]
                public Raids Raids { get; set; }
                [XmlElement(ElementName = "tackles")]
                public Tackles Tackles { get; set; }
                [XmlElement(ElementName = "time-off-court")]
                public string Timeoffcourt { get; set; }
                [XmlElement(ElementName = "do-or-die")]
                public Doordie Doordie { get; set; }
                [XmlElement(ElementName = "avg-raid-time")]
                public string Avgraidtime { get; set; }
                [XmlElement(ElementName = "raid-map-locations")]
                public Raidmaplocations Raidmaplocations { get; set; }
                [XmlAttribute(AttributeName = "player-id")]
                public string Playerid { get; set; }
                [XmlAttribute(AttributeName = "player-name")]
                public string Playername { get; set; }
                [XmlAttribute(AttributeName = "player-revival-order")]
                public string Playerrevivalorder { get; set; }
                [XmlAttribute(AttributeName = "player-on-court")]
                public string Playeroncourt { get; set; }
                [XmlAttribute(AttributeName = "player-raiding-now")]
                public string Playerraidingnow { get; set; }
            }

            [XmlRoot(ElementName = "players")]
            public class Players
            {
                [XmlElement(ElementName = "player")]
                public List<Player> Player { get; set; }
            }

            [XmlRoot(ElementName = "team")]
            public class Team
            {
                [XmlElement(ElementName = "points")]
                public Points Points { get; set; }
                [XmlElement(ElementName = "points-last-n-minutes")]
                public Pointslastnminutes Pointslastnminutes { get; set; }
                [XmlElement(ElementName = "raids")]
                public Raids Raids { get; set; }
                [XmlElement(ElementName = "tackles")]
                public Tackles Tackles { get; set; }
                [XmlElement(ElementName = "do-or-die")]
                public Doordie Doordie { get; set; }
                [XmlElement(ElementName = "players")]
                public Players Players { get; set; }
                [XmlAttribute(AttributeName = "team-name")]
                public string Teamname { get; set; }
                [XmlAttribute(AttributeName = "team-id")]
                public string Teamid { get; set; }
                [XmlAttribute(AttributeName = "total-points")]
                public string Totalpoints { get; set; }
            }

            [XmlRoot(ElementName = "team-players-statistics")]
            public class Teamplayersstatistics
            {
                [XmlElement(ElementName = "team")]
                public List<Team> Team { get; set; }
            }

            [XmlRoot(ElementName = "raid")]
            public class Raid
            {
                [XmlElement(ElementName = "team")]
                public List<Team> Team { get; set; }
                [XmlAttribute(AttributeName = "raid-number")]
                public string Raidnumber { get; set; }
                [XmlAttribute(AttributeName = "raiding-team-id")]
                public string Raidingteamid { get; set; }
                [XmlAttribute(AttributeName = "raiding-player-id")]
                public string Raidingplayerid { get; set; }
                [XmlAttribute(AttributeName = "raid-outcome-id")]
                public string Raidoutcomeid { get; set; }
                [XmlAttribute(AttributeName = "raid-half")]
                public string Raidhalf { get; set; }
            }
            [XmlRoot(ElementName = "match_info")]
            public class Match_info
            {
                [XmlAttribute(AttributeName = "matchid")]
                public string Matchid { get; set; }
                [XmlAttribute(AttributeName = "stage")]
                public string Stage { get; set; }
                [XmlAttribute(AttributeName = "group")]
                public string Group { get; set; }
                [XmlAttribute(AttributeName = "teama-id")]
                public string Teamaid { get; set; }
                [XmlAttribute(AttributeName = "teama")]
                public string Teama { get; set; }
                [XmlAttribute(AttributeName = "teamb-id")]
                public string Teambid { get; set; }
                [XmlAttribute(AttributeName = "teamb")]
                public string Teamb { get; set; }
                [XmlAttribute(AttributeName = "local-date")]
                public string Localdate { get; set; }
                [XmlAttribute(AttributeName = "venue")]
                public string Venue { get; set; }
                [XmlAttribute(AttributeName = "tosswin")]
                public string Tosswin { get; set; }
                [XmlAttribute(AttributeName = "opted")]
                public string Opted { get; set; }
                [XmlAttribute(AttributeName = "status")]
                public string Status { get; set; }
                [XmlAttribute(AttributeName = "player_of_the_match")]
                public string Player_of_the_match { get; set; }
                [XmlAttribute(AttributeName = "player_of_the_match2")]
                public string Player_of_the_match2 { get; set; }
                [XmlAttribute(AttributeName = "match-clock")]
                public string Matchclock { get; set; }
            }
            [XmlRoot(ElementName = "result")]
            public class Result
            {
                [XmlAttribute(AttributeName = "result-type")]
                public string Resulttype { get; set; }
                [XmlAttribute(AttributeName = "winning-team-id")]
                public string Winningteamid { get; set; }
                [XmlText]
                public string Text { get; set; }
            }
            [XmlRoot(ElementName = "play-by-play")]
            public class Playbyplay
            {
                [XmlElement(ElementName = "raid")]
                public List<Raid> Raid { get; set; }
            }

            [XmlRoot(ElementName = "match-details")]
            public class Matchdetails
            {
                [XmlElement(ElementName = "match_info")]
                public Match_info Match_info { get; set; }
                [XmlElement(ElementName = "result")]
                public Result Result { get; set; }
               // public Result Result { get; set; }
            }

            [XmlRoot(ElementName = "in-match")]
            public class Inmatch
            {
                [XmlElement(ElementName = "team-players-statistics")]
                public Teamplayersstatistics Teamplayersstatistics { get; set; }
                [XmlElement(ElementName = "play-by-play")]
                public Playbyplay Playbyplay { get; set; }
                [XmlElement(ElementName = "match-details")]
                public Matchdetails Matchdetails { get; set; }
            }

        }

        //[XmlRoot(ElementName = "tackle-points")]
        //public class Tacklepoints
        //{
        //    [XmlElement(ElementName = "tackle-bonus-points")]
        //    public string Tacklebonuspoints { get; set; }
        //    [XmlAttribute(AttributeName = "total-tackle-points")]
        //    public string Totaltacklepoints { get; set; }
        //    [XmlElement(ElementName = "capture-points")]
        //    public Capturepoints Capturepoints { get; set; }
        //}

        //[XmlRoot(ElementName = "raid-points")]
        //public class Raidpoints
        //{
        //    [XmlElement(ElementName = "raid-bonus-points")]
        //    public string Raidbonuspoints { get; set; }
        //    [XmlAttribute(AttributeName = "total-raid-points")]
        //    public string Totalraidpoints { get; set; }
        //    [XmlElement(ElementName = "touch-points")]
        //    public Touchpoints Touchpoints { get; set; }
        //}

        //[XmlRoot(ElementName = "points")]
        //public class Points
        //{
        //    [XmlElement(ElementName = "tackle-points")]
        //    public Tacklepoints Tacklepoints { get; set; }
        //    [XmlElement(ElementName = "raid-points")]
        //    public Raidpoints Raidpoints { get; set; }
        //    [XmlElement(ElementName = "all-out-points")]
        //    public string Alloutpoints { get; set; }
        //    [XmlElement(ElementName = "extra-points")]
        //    public string Extrapoints { get; set; }
        //    [XmlAttribute(AttributeName = "total-points")]
        //    public string Totalpoints { get; set; }
        //}

        //[XmlRoot(ElementName = "points-last-n-minutes")]
        //public class Pointslastnminutes
        //{
        //    [XmlElement(ElementName = "five")]
        //    public string Five { get; set; }
        //    [XmlElement(ElementName = "ten")]
        //    public string Ten { get; set; }
        //}

        //[XmlRoot(ElementName = "raids")]
        //public class Raids
        //{
        //    [XmlElement(ElementName = "successful-raids")]
        //    public string Successfulraids { get; set; }
        //    [XmlElement(ElementName = "unsuccessful-raids")]
        //    public string Unsuccessfulraids { get; set; }
        //    [XmlElement(ElementName = "empty-raids")]
        //    public string Emptyraids { get; set; }
        //    [XmlAttribute(AttributeName = "total-raids")]
        //    public string Totalraids { get; set; }
        //    [XmlAttribute(AttributeName = "super-raids")]
        //    public string Superraids { get; set; }
        //}

        //[XmlRoot(ElementName = "tackles")]
        //public class Tackles
        //{
        //    [XmlElement(ElementName = "successful-tackles")]
        //    public string Successfultackles { get; set; }
        //    [XmlElement(ElementName = "unsuccessful-tackles")]
        //    public string Unsuccessfultackles { get; set; }
        //    [XmlAttribute(AttributeName = "total-tackles")]
        //    public string Totaltackles { get; set; }
        //    [XmlAttribute(AttributeName = "super-tackles")]
        //    public string Supertackles { get; set; }
        //}

        //[XmlRoot(ElementName = "do-or-die")]
        //public class Doordie
        //{
        //    [XmlElement(ElementName = "successfull-raids")]
        //    public string Successfullraids { get; set; }
        //    [XmlElement(ElementName = "failed-raids")]
        //    public string Failedraids { get; set; }
        //    [XmlElement(ElementName = "super-raids")]
        //    public string Superraids { get; set; }
        //    [XmlElement(ElementName = "raid-points")]
        //    public string Raidpoints { get; set; }
        //    [XmlElement(ElementName = "touch-points")]
        //    public string Touchpoints { get; set; }
        //    [XmlElement(ElementName = "bonus-points")]
        //    public string Bonuspoints { get; set; }
        //    [XmlAttribute(AttributeName = "total-raids")]
        //    public string Totalraids { get; set; }
        //}

        //[XmlRoot(ElementName = "skill-points")]
        //public class Skillpoints
        //{
        //    [XmlAttribute(AttributeName = "skill-id")]
        //    public string Skillid { get; set; }
        //    [XmlText]
        //    public string Text { get; set; }
        //}

        //[XmlRoot(ElementName = "touch-points")]
        //public class Touchpoints
        //{
        //    [XmlElement(ElementName = "skill-points")]
        //    public List<Skillpoints> Skillpoints { get; set; }
        //    [XmlAttribute(AttributeName = "total-touch-points")]
        //    public string Totaltouchpoints { get; set; }
        //}

        //[XmlRoot(ElementName = "capture-points")]
        //public class Capturepoints
        //{
        //    [XmlElement(ElementName = "skill-points")]
        //    public List<Skillpoints> Skillpoints { get; set; }
        //    [XmlAttribute(AttributeName = "total-capture-points")]
        //    public string Totalcapturepoints { get; set; }
        //}

        //[XmlRoot(ElementName = "location")]
        //public class Location
        //{
        //    [XmlElement(ElementName = "strong")]
        //    public string Strong { get; set; }
        //    [XmlElement(ElementName = "weak")]
        //    public string Weak { get; set; }
        //    [XmlAttribute(AttributeName = "location-id")]
        //    public string Locationid { get; set; }
        //}

        //[XmlRoot(ElementName = "raid-map-locations")]
        //public class Raidmaplocations
        //{
        //    [XmlElement(ElementName = "location")]
        //    public List<Location> Location { get; set; }
        //}

        //[XmlRoot(ElementName = "player")]
        //public class Player
        //{
        //    [XmlElement(ElementName = "points")]
        //    public Points Points { get; set; }
        //    [XmlElement(ElementName = "raids")]
        //    public Raids Raids { get; set; }
        //    [XmlElement(ElementName = "tackles")]
        //    public Tackles Tackles { get; set; }
        //    [XmlElement(ElementName = "time-off-court")]
        //    public string Timeoffcourt { get; set; }
        //    [XmlElement(ElementName = "do-or-die")]
        //    public Doordie Doordie { get; set; }
        //    [XmlElement(ElementName = "avg-raid-time")]
        //    public string Avgraidtime { get; set; }
        //    [XmlElement(ElementName = "raid-map-locations")]
        //    public Raidmaplocations Raidmaplocations { get; set; }
        //    [XmlAttribute(AttributeName = "player-id")]
        //    public string Playerid { get; set; }
        //    [XmlAttribute(AttributeName = "player-name")]
        //    public string Playername { get; set; }
        //    [XmlAttribute(AttributeName = "player-on-court")]
        //    public string Playeroncourt { get; set; }
        //    [XmlAttribute(AttributeName = "player-revival-order")]
        //    public string Playerrevivalorder { get; set; }
        //}

        //[XmlRoot(ElementName = "players")]
        //public class Players
        //{
        //    [XmlElement(ElementName = "player")]
        //    public List<Player> Player { get; set; }
        //}

        //[XmlRoot(ElementName = "team")]
        //public class Team
        //{
        //    [XmlElement(ElementName = "points")]
        //    public Points Points { get; set; }
        //    [XmlElement(ElementName = "points-last-n-minutes")]
        //    public Pointslastnminutes Pointslastnminutes { get; set; }
        //    [XmlElement(ElementName = "raids")]
        //    public Raids Raids { get; set; }
        //    [XmlElement(ElementName = "tackles")]
        //    public Tackles Tackles { get; set; }
        //    [XmlElement(ElementName = "do-or-die")]
        //    public Doordie Doordie { get; set; }
        //    [XmlElement(ElementName = "players")]
        //    public Players Players { get; set; }
        //    [XmlAttribute(AttributeName = "team-name")]
        //    public string Teamname { get; set; }
        //    [XmlAttribute(AttributeName = "team-id")]
        //    public string Teamid { get; set; }
        //    [XmlAttribute(AttributeName = "total-points")]
        //    public string Totalpoints { get; set; }
        //}

        //[XmlRoot(ElementName = "team-players-statistics")]
        //public class Teamplayersstatistics
        //{
        //    [XmlElement(ElementName = "team")]
        //    public List<Team> Team { get; set; }
        //}

        //[XmlRoot(ElementName = "raid")]
        //public class Raid
        //{
        //    [XmlElement(ElementName = "team")]
        //    public List<Team> Team { get; set; }
        //    [XmlAttribute(AttributeName = "raid-number")]
        //    public string Raidnumber { get; set; }
        //    [XmlAttribute(AttributeName = "raiding-team-id")]
        //    public string Raidingteamid { get; set; }
        //    [XmlAttribute(AttributeName = "raiding-player-id")]
        //    public string Raidingplayerid { get; set; }
        //    [XmlAttribute(AttributeName = "raid-outcome-id")]
        //    public string Raidoutcomeid { get; set; }
        //    [XmlAttribute(AttributeName = "raid-half")]
        //    public string Raidhalf { get; set; }
        //}

        //[XmlRoot(ElementName = "play-by-play")]
        //public class Playbyplay
        //{
        //    [XmlElement(ElementName = "raid")]
        //    public List<Raid> Raid { get; set; }
        //}

        //[XmlRoot(ElementName = "result")]
        //public class Result
        //{
        //    [XmlAttribute(AttributeName = "result-type")]
        //    public string Resulttype { get; set; }
        //    [XmlAttribute(AttributeName = "winning-team-id")]
        //    public string Winningteamid { get; set; }
        //    [XmlText]
        //    public string Text { get; set; }
        //}

        //[XmlRoot(ElementName = "match-details")]
        //public class Matchdetails
        //{
        //    [XmlElement(ElementName = "result")]
        //    public Result Result { get; set; }
        //}

        //[XmlRoot(ElementName = "in-match")]
        //public class Inmatch
        //{
        //    [XmlElement(ElementName = "team-players-statistics")]
        //    public Teamplayersstatistics Teamplayersstatistics { get; set; }
        //    [XmlElement(ElementName = "play-by-play")]
        //    public Playbyplay Playbyplay { get; set; }
        //    [XmlElement(ElementName = "match-details")]
        //    public Matchdetails Matchdetails { get; set; }
        //}

 