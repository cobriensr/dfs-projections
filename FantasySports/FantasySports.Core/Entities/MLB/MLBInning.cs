namespace FantasySports.Core.Entities.MLB
{
    public class MLBInning : MLBBaseEntity
    {
        public int Id { get; set; }
        public int InningId { get; set; }
        public int GameId { get; set; }
        public virtual MLBGame? Game { get; set; }
        public string? Inningnumber { get; set; }
        public string? Awayteamruns { get; set; }
        public string? Hometeamruns { get; set; }
    }
}
