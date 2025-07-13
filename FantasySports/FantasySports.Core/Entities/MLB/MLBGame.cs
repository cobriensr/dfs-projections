namespace FantasySports.Core.Entities.MLB
{
    public class MLBGame : MLBBaseEntity
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int? Season { get; set; }
        public int? SeasonType { get; set; }
        public string? Status { get; set; }
        public DateTime? Day { get; set; }
        public DateTime? Datetime { get; set; }
        public string? Awayteam { get; set; }
        public string? Hometeam { get; set; }
        public int? AwayTeamId { get; set; }
        public virtual MLBTeam? AwayTeamEntity { get; set; }
        public int? HomeTeamId { get; set; }
        public virtual MLBTeam? HomeTeamEntity { get; set; }
        public int StadiumId { get; set; }
        public virtual MLBStadium? Stadium { get; set; }
        public string? Awayteamruns { get; set; }
        public string? Hometeamruns { get; set; }
        public string? Awayteamprobablepitcherid { get; set; }
        public string? Hometeamprobablepitcherid { get; set; }
        public string? Awayteamstartingpitcherid { get; set; }
        public string? Hometeamstartingpitcherid { get; set; }
        public int? Pointspread { get; set; }
        public decimal? Overunder { get; set; }
        public string? Awayteammoneyline { get; set; }
        public string? Hometeammoneyline { get; set; }
        public string? Forecasttemplow { get; set; }
        public string? Forecasttemphigh { get; set; }
        public string? Forecastdescription { get; set; }
        public string? Forecastwindchill { get; set; }
        public string? Forecastwindspeed { get; set; }
        public string? Forecastwinddirection { get; set; }
        public string? Awayteamstartingpitcher { get; set; }
        public string? Hometeamstartingpitcher { get; set; }
        public string? Homerotationnumber { get; set; }
        public string? Awayrotationnumber { get; set; }
        public string? Neutralvenue { get; set; }
        public decimal? Overpayout { get; set; }
        public decimal? Underpayout { get; set; }
        public string? Hometeamopener { get; set; }
        public string? Awayteamopener { get; set; }
        // Collections
        public virtual ICollection<MLBPlayerGame> PlayerStats { get; set; } = new List<MLBPlayerGame>();
    }
}
