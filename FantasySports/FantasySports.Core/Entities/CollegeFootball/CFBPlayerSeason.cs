namespace FantasySports.Core.Entities.CollegeFootball
{
    public class CFBPlayerSeason : CFBBaseEntity
    {
        public int Id { get; set; }
        public int ExternalStatId { get; set; }
        public int TeamId { get; set; }
        public virtual CFBTeam? TeamEntity { get; set; }
        public int PlayerId { get; set; }
        public virtual CFBPlayer? Player { get; set; }
        public int? Seasontype { get; set; }
        public int? Season { get; set; }
        public string? Name { get; set; }
        public string? Team { get; set; }
        public string? Position { get; set; }
        public string? Positioncategory { get; set; }
        public int? Games { get; set; }
        public string? Fantasypoints { get; set; }
        public string? Passingattempts { get; set; }
        public string? Passingcompletions { get; set; }
        public string? Passingyards { get; set; }
        public string? Passingcompletionpercentage { get; set; }
        public string? Passingyardsperattempt { get; set; }
        public string? Passingyardspercompletion { get; set; }
        public string? Passingtouchdowns { get; set; }
        public string? Passinginterceptions { get; set; }
        public string? Passingrating { get; set; }
        public string? Rushingattempts { get; set; }
        public string? Rushingyards { get; set; }
        public string? Rushingyardsperattempt { get; set; }
        public string? Rushingtouchdowns { get; set; }
        public string? Rushinglong { get; set; }
        public string? Receptions { get; set; }
        public string? Receivingyards { get; set; }
        public string? Receivingyardsperreception { get; set; }
        public string? Receivingtouchdowns { get; set; }
        public string? Receivinglong { get; set; }
        public int? Fieldgoalsattempted { get; set; }
        public int? Fieldgoalsmade { get; set; }
        public int? Fieldgoalpercentage { get; set; }
        public int? Fieldgoalslongestmade { get; set; }
        public string? Extrapointsattempted { get; set; }
        public string? Extrapointsmade { get; set; }
    }
}
