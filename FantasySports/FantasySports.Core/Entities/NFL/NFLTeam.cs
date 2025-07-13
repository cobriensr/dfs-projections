namespace FantasySports.Core.Entities.NFL
{
    public class NFLTeam : NFLBaseEntity
    {
        public int Id { get; set; }
        public string? Key { get; set; }
        public string? City { get; set; }
        public string? Name { get; set; }
        public string? Conference { get; set; }
        public string? Division { get; set; }
        public string? Fullname { get; set; }
        public int StadiumId { get; set; }
        public virtual NFLStadium? Stadium { get; set; }
        public string? Byeweek { get; set; }
        public decimal? Averagedraftposition { get; set; }
        public decimal? Averagedraftpositionppr { get; set; }
        public string? Primarycolor { get; set; }
        public string? Secondarycolor { get; set; }
        public string? Tertiarycolor { get; set; }
        public string? Quaternarycolor { get; set; }
        public string? Wikipedialogourl { get; set; }
        public string? Wikipediawordmarkurl { get; set; }
        public string? Draftkingsname { get; set; }
        public int DraftKingsPlayerId { get; set; }
        public string? Fanduelname { get; set; }
        public string? Fanduelplayerid { get; set; }
        // Collections
        public virtual ICollection<NFLPlayer> Players { get; set; } = new List<NFLPlayer>();
    }
}
