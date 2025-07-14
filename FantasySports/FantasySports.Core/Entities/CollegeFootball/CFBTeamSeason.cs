namespace FantasySports.Core.Entities.CollegeFootball
{
    public class CFBTeamSeason : CFBBaseEntity
    {
        public int Id { get; set; }
        public int ExternalStatId { get; set; }
        public int TeamId { get; set; }
        public virtual CFBTeam? TeamEntity { get; set; }
        public int? Seasontype { get; set; }
        public int? Season { get; set; }
        public string? Name { get; set; }
        public string? Team { get; set; }
        public int? Wins { get; set; }
        public int? Losses { get; set; }
        public int? Pointsfor { get; set; }
        public int? Pointsagainst { get; set; }
        public string? Conferencewins { get; set; }
        public string? Conferencelosses { get; set; }
        public string? Conferencepointsfor { get; set; }
        public string? Conferencepointsagainst { get; set; }
        public string? Homewins { get; set; }
        public string? Homelosses { get; set; }
        public string? Roadwins { get; set; }
        public string? Roadlosses { get; set; }
        public string? Streak { get; set; }
        public int? Score { get; set; }
        public string? Opponentscore { get; set; }
        public string? Firstdowns { get; set; }
        public string? Thirddownconversions { get; set; }
        public string? Thirddownattempts { get; set; }
        public string? Fourthdownconversions { get; set; }
        public string? Fourthdownattempts { get; set; }
        public string? Penalties { get; set; }
        public string? Penaltyyards { get; set; }
        public DateTime? Timeofpossessionminutes { get; set; }
        public DateTime? Timeofpossessionseconds { get; set; }
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
