namespace FantasySports.Core.Entities.NFL
{
    public class NFLQuarter : NFLBaseEntity
    {
        public int Id { get; set; }
        public int QuarterId { get; set; }
        public int ScoreId { get; set; }
        public int? Number { get; set; }
        public string? Name { get; set; }
        public string? Awayteamscore { get; set; }
        public string? Hometeamscore { get; set; }
    }
}
