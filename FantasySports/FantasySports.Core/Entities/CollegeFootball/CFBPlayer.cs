namespace FantasySports.Core.Entities.CollegeFootball
{
    public class CFBPlayer : CFBBaseEntity
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public virtual CFBPlayer? Player { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public int TeamId { get; set; }
        public virtual CFBTeam? TeamEntity { get; set; }
        public string? Team { get; set; }
        public int? Jersey { get; set; }
        public string? Position { get; set; }
        public string? Positioncategory { get; set; }
        public string? Class { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }
        public string? Injurystatus { get; set; }
        // Collections
        public virtual ICollection<CFBPlayerGame> GameStats { get; set; } = new List<CFBPlayerGame>();
        public virtual ICollection<CFBPlayerSeason> SeasonStats { get; set; } = new List<CFBPlayerSeason>();
    }
}
