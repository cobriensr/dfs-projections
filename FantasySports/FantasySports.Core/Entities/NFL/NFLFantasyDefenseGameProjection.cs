namespace FantasySports.Core.Entities.NFL
{
    public class NFLFantasyDefenseGameProjection : NFLBaseEntity
    {
        public int Id { get; set; }
        public int? Seasontype { get; set; }
        public int? Season { get; set; }
        public int? Week { get; set; }
        public DateTime? Date { get; set; }
        public string? Team { get; set; }
        public string? Opponent { get; set; }
        public int? Pointsallowed { get; set; }
        public int? Touchdownsscored { get; set; }
        public int? Sacks { get; set; }
        public string? Sackyards { get; set; }
        public string? Fumblesforced { get; set; }
        public string? Fumblesrecovered { get; set; }
        public string? Fumblereturntouchdowns { get; set; }
        public int? Interceptions { get; set; }
        public string? Interceptionreturntouchdowns { get; set; }
        public string? Blockedkicks { get; set; }
        public string? Safeties { get; set; }
        public string? Puntreturntouchdowns { get; set; }
        public string? Kickreturntouchdowns { get; set; }
        public string? Blockedkickreturntouchdowns { get; set; }
        public int? Fieldgoalreturntouchdowns { get; set; }
        public string? Quarterbackhits { get; set; }
        public int? Tacklesforloss { get; set; }
        public string? Defensivetouchdowns { get; set; }
        public string? Specialteamstouchdowns { get; set; }
        public string? Fantasypoints { get; set; }
        public int? Pointsallowedbydefensespecialteams { get; set; }

        public string? Twopointconversionreturns { get; set; }
        public string? Fantasypointsfanduel { get; set; }
        public string? Fantasypointsdraftkings { get; set; }
        public int PlayerId { get; set; }
        public virtual NFLPlayer? Player { get; set; }
        public string? Homeoraway { get; set; }
        public int TeamId { get; set; }
        public virtual NFLTeam? TeamEntity { get; set; }
        public int OpponentId { get; set; }
        public int? Scoreid { get; set; }
    }
}
