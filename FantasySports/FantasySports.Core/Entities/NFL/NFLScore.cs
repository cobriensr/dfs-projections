namespace FantasySports.Core.Entities.NFL
{
    public class NFLScore : NFLBaseEntity
    {
        public int Id { get; set; }
        public string? Gamekey { get; set; }
        public int? Seasontype { get; set; }
        public int? Season { get; set; }
        public int? Week { get; set; }
        public DateTime? Date { get; set; }
        public string? Awayteam { get; set; }
        public string? Hometeam { get; set; }
        public string? Awayscore { get; set; }
        public string? Homescore { get; set; }
        public int? Pointspread { get; set; }
        public decimal? Overunder { get; set; }
        public string? Awayscorequarter1 { get; set; }
        public string? Awayscorequarter2 { get; set; }
        public string? Awayscorequarter3 { get; set; }
        public string? Awayscorequarter4 { get; set; }
        public string? Awayscoreovertime { get; set; }
        public string? Homescorequarter1 { get; set; }
        public string? Homescorequarter2 { get; set; }
        public string? Homescorequarter3 { get; set; }
        public string? Homescorequarter4 { get; set; }
        public string? Homescoreovertime { get; set; }
        public int StadiumId { get; set; }
        public virtual NFLStadium? Stadium { get; set; }
        public string? Forecasttemplow { get; set; }
        public string? Forecasttemphigh { get; set; }
        public string? Forecastdescription { get; set; }
        public string? Forecastwindchill { get; set; }
        public string? Forecastwindspeed { get; set; }
        public string? Awayteammoneyline { get; set; }
        public string? Hometeammoneyline { get; set; }
        public int ScoreId { get; set; }
        public string? Neutralvenue { get; set; }
        public decimal? Overpayout { get; set; }
        public decimal? Underpayout { get; set; }
    }
}
