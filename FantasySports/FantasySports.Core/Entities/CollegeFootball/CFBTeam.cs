namespace FantasySports.Core.Entities.CollegeFootball
{
    public class CFBTeam : CFBBaseEntity
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public virtual CFBTeam? TeamEntity { get; set; }
        public string? Key { get; set; }
        public bool? Active { get; set; }
        public string? School { get; set; }
        public string? Name { get; set; }
        public int StadiumId { get; set; }
        public virtual CFBStadium? Stadium { get; set; }
        public string? Aprank { get; set; }
        public int? Wins { get; set; }
        public int? Losses { get; set; }
        public string? Conferencewins { get; set; }
        public string? Conferencelosses { get; set; }
        public string? Teamlogourl { get; set; }
        public string? Conferenceid { get; set; }
        public string? Conference { get; set; }
        public string? Shortdisplayname { get; set; }
        public int? Rankweek { get; set; }
        public int? Rankseason { get; set; }
        public int? Rankseasontype
        { get; set; }
        // Collections
        public virtual ICollection<CFBPlayer> Players { get; set; } = new List<CFBPlayer>();
        public virtual ICollection<CFBGame> HomeGames { get; set; } = new List<CFBGame>();
        public virtual ICollection<CFBGame> AwayGames { get; set; } = new List<CFBGame>();
    }
}
