namespace FantasySports.Core.Entities.NFL
{
    public class NFLPlayerGame : NFLBaseEntity
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public virtual NFLPlayer? Player { get; set; }
        public int? Seasontype { get; set; }
        public int? Season { get; set; }
        public string? Gamedate { get; set; }
        public int? Week { get; set; }
        public string? Team { get; set; }
        public string? Opponent { get; set; }
        public string? Homeoraway { get; set; }
        public int? Number { get; set; }
        public string? Name { get; set; }
        public string? Position { get; set; }
        public string? Positioncategory { get; set; }
        public bool? Played { get; set; }
        public bool? Started { get; set; }
        public string? Passingattempts { get; set; }
        public string? Passingcompletions { get; set; }
        public string? Passingyards { get; set; }
        public string? Passingcompletionpercentage { get; set; }
        public string? Passingyardsperattempt { get; set; }
        public string? Passingyardspercompletion { get; set; }
        public string? Passingtouchdowns { get; set; }
        public string? Passinginterceptions { get; set; }
        public string? Passingrating { get; set; }
        public string? Passinglong { get; set; }
        public string? Passingsacks { get; set; }
        public string? Passingsackyards { get; set; }

        public string? Rushingattempts { get; set; }
        public string? Rushingyards { get; set; }
        public string? Rushingyardsperattempt { get; set; }
        public string? Rushingtouchdowns { get; set; }
        public string? Rushinglong { get; set; }

        public string? Receivingtargets { get; set; }

        public string? Receptions { get; set; }
        public string? Receivingyards { get; set; }
        public string? Receivingyardsperreception { get; set; }
        public string? Receivingtouchdowns { get; set; }
        public string? Receivinglong { get; set; }

        public string? Fumbles { get; set; }
        public string? Fumbleslost { get; set; }
        public string? Puntreturns { get; set; }
        public string? Puntreturnyards { get; set; }
        public string? Puntreturntouchdowns { get; set; }
        public string? Kickreturns { get; set; }
        public string? Kickreturnyards { get; set; }
        public string? Kickreturntouchdowns { get; set; }
        public string? Solotackles { get; set; }
        public string? Assistedtackles { get; set; }
        public int? Tacklesforloss { get; set; }
        public int? Sacks { get; set; }
        public string? Sackyards { get; set; }
        public string? Quarterbackhits { get; set; }
        public string? Passesdefended { get; set; }
        public string? Fumblesforced { get; set; }
        public string? Fumblesrecovered { get; set; }
        public string? Fumblereturntouchdowns { get; set; }
        public int? Interceptions { get; set; }
        public string? Interceptionreturntouchdowns { get; set; }
        public int? Fieldgoalsattempted { get; set; }
        public int? Fieldgoalsmade { get; set; }
        public string? Extrapointsmade { get; set; }
        public string? Twopointconversionpasses { get; set; }
        public string? Twopointconversionruns { get; set; }
        public string? Twopointconversionreceptions { get; set; }
        public string? Fantasypoints { get; set; }
        public string? Fantasyposition { get; set; }
        public int PlayerGameId { get; set; }
        public string? Extrapointsattempted { get; set; }
        public string? Fantasypointsfanduel { get; set; }
        public int? Fieldgoalsmade0to19 { get; set; }
        public int? Fieldgoalsmade20to29 { get; set; }
        public int? Fieldgoalsmade30to39 { get; set; }
        public int? Fieldgoalsmade40to49 { get; set; }
        public int? Fieldgoalsmade50plus { get; set; }
        public string? Fantasypointsdraftkings { get; set; }
        public string? Injurystatus { get; set; }
        public int TeamId { get; set; }
        public virtual NFLTeam? TeamEntity { get; set; }
        public int OpponentId { get; set; }
        public int? Scoreid { get; set; }
        // Collections
        public virtual ICollection<NFLPlayerGame> PlayerStats { get; set; } = new List<NFLPlayerGame>();
    }
}
