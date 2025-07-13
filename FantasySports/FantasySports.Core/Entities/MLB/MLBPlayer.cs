namespace FantasySports.Core.Entities.MLB
{
    public class MLBPlayer : MLBBaseEntity
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public virtual MLBPlayer? Player { get; set; }
        public string? Status { get; set; }
        public int TeamId { get; set; }
        public virtual MLBTeam? TeamEntity { get; set; }
        public string? Team { get; set; }
        public int? Jersey { get; set; }
        public string? Positioncategory { get; set; }
        public string? Position { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Bathand { get; set; }
        public string? Throwhand { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }
        public string? Birthdate { get; set; }
        public string? Birthcity { get; set; }
        public string? Birthstate { get; set; }
        public string? Birthcountry { get; set; }
        public string? Photourl { get; set; }
        public string? Injurystatus { get; set; }
        public int FanDuelPlayerId { get; set; }
        public int DraftKingsPlayerId { get; set; }
        public string? Fanduelname { get; set; }
        public string? Draftkingsname { get; set; }
        // Collections
        public virtual ICollection<MLBPlayerGame> GameStats { get; set; } = new List<MLBPlayerGame>();
        public virtual ICollection<MLBPlayerSeason> SeasonStats { get; set; } = new List<MLBPlayerSeason>();
    }
}
