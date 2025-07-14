namespace FantasySports.Core.Entities.CollegeFootball
{
    public class CFBPeriod : CFBBaseEntity
    {
        public int Id { get; set; }
        public int PeriodId { get; set; }
        public int GameId { get; set; }
        public virtual CFBGame? Game { get; set; }
        public int? Number { get; set; }
        public string? Name { get; set; }
        public string? Awayscore { get; set; }
        public string? Homescore { get; set; }
    }
}
