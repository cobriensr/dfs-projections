namespace FantasySports.Core.Entities.MLB
{
    public class MLBTeam : MLBBaseEntity
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public virtual MLBTeam? TeamEntity { get; set; }
        public string? Key { get; set; }
        public bool? Active { get; set; }
        public string? City { get; set; }
        public string? Name { get; set; }
        public int StadiumId { get; set; }
        public virtual MLBStadium? Stadium { get; set; }
        public string? League { get; set; }
        public string? Division { get; set; }
        public string? Primarycolor { get; set; }
        public string? Secondarycolor { get; set; }
        public string? Tertiarycolor { get; set; }
        public string? Quaternarycolor { get; set; }
        public string? Wikipedialogourl { get; set; }
        public string? Wikipediawordmarkurl { get; set; }
        // Collections
        public virtual ICollection<MLBPlayer> Players { get; set; } = new List<MLBPlayer>();
        public virtual ICollection<MLBGame> HomeGames { get; set; } = new List<MLBGame>();
        public virtual ICollection<MLBGame> AwayGames { get; set; } = new List<MLBGame>();
    }
}
