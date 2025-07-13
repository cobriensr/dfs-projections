namespace FantasySports.Core.Entities.CollegeFootball
{
    public class CFBGame : CFBBaseEntity
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public virtual CFBGame? Game { get; set; }
        public int? Season { get; set; }
        public int? Seasontype { get; set; }
        public int? Week { get; set; }
        public string? Status { get; set; }
        public DateTime? Day { get; set; }
        public DateTime? Datetime { get; set; }
        public string? Awayteam { get; set; }
        public string? Hometeam { get; set; }
        public int AwayTeamId { get; set; }
        public virtual CFBTeam? AwayTeam { get; set; }
        public int HomeTeamId { get; set; }
        public virtual CFBTeam? HomeTeam { get; set; }
        public string? Awayteamname { get; set; }
        public string? Hometeamname { get; set; }
        public string? Awayteamscore { get; set; }
        public string? Hometeamscore { get; set; }
        public int? Pointspread { get; set; }
        public decimal? Overunder { get; set; }
        public string? Awayteammoneyline { get; set; }
        public string? Hometeammoneyline { get; set; }
        public int StadiumId { get; set; }
        public virtual CFBStadium? StadiumEntity { get; set; }
        public string? Stadium { get; set; }
        public string? Title { get; set; }
        public string? Homerotationnumber { get; set; }
        public string? Awayrotationnumber { get; set; }
        public string? Neutralvenue { get; set; }
        public string? Awaypointspreadpayout { get; set; }
        public string? Homepointspreadpayout { get; set; }
        public decimal? Overpayout { get; set; }
        public decimal? Underpayout { get; set; }
        // Collections
        public virtual ICollection<CFBPlayerGame> PlayerStats { get; set; } = new List<CFBPlayerGame>();
    }
}
