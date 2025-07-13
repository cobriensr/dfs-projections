namespace FantasySports.Core.Entities.NFL
{
    public class NFLPlayer : NFLBaseEntity
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public virtual NFLPlayer? Player { get; set; }
        public string? Team { get; set; }
        public int? Number { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Position { get; set; }
        public string? Status { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }
        public string? Birthdate { get; set; }
        public string? College { get; set; }
        public int? Experience { get; set; }
        public string? Fantasyposition { get; set; }
        public string? Positioncategory { get; set; }
        public string? Photourl { get; set; }
        public string? Byeweek { get; set; }
        public decimal? Averagedraftposition { get; set; }
        public string? Collegedraftteam { get; set; }
        public string? Collegedraftyear { get; set; }
        public string? Collegedraftround { get; set; }
        public string? Collegedraftpick { get; set; }
        public bool? Isundraftedfreeagent { get; set; }
        public int FanDuelPlayerId { get; set; }
        public int DraftKingsPlayerId { get; set; }
        public string? Injurystatus { get; set; }
        public string? Fanduelname { get; set; }
        public string? Draftkingsname { get; set; }
        public string? Teamid { get; set; }
        // Collections
        public virtual ICollection<NFLPlayerGame> GameStats { get; set; } = new List<NFLPlayerGame>();
        public virtual ICollection<NFLPlayerSeason> SeasonStats { get; set; } = new List<NFLPlayerSeason>();
    }
}
