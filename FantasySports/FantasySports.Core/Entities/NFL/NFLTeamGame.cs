namespace FantasySports.Core.Entities.NFL
{
    public class NFLTeamGame : NFLBaseEntity
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int? Seasontype { get; set; }
        public int? Season { get; set; }
        public int? Week { get; set; }
        public string? Team { get; set; }
        public string? Opponent { get; set; }
        public string? Homeoraway { get; set; }
        public int? Score { get; set; }
        public string? Opponentscore { get; set; }
        public int? Totalscore { get; set; }
        public string? Stadium { get; set; }
        public int? Scorequarter1 { get; set; }
        public int? Scorequarter2 { get; set; }
        public int? Scorequarter3 { get; set; }
        public int? Scorequarter4 { get; set; }
        public int? Scoreovertime { get; set; }
        public DateTime? Timeofpossessionminutes { get; set; }
        public DateTime? Timeofpossessionseconds { get; set; }
        public DateTime? Timeofpossession { get; set; }
        public string? Firstdowns { get; set; }
        public string? Firstdownsbyrushing { get; set; }

        public string? Firstdownsbypassing { get; set; }

        public string? Firstdownsbypenalty { get; set; }
        public string? Offensiveplays { get; set; }
        public string? Offensiveyards { get; set; }
        public string? Offensiveyardsperplay { get; set; }
        public int? Touchdowns { get; set; }
        public string? Rushingattempts { get; set; }
        public string? Rushingyards { get; set; }
        public string? Rushingyardsperattempt { get; set; }
        public string? Rushingtouchdowns { get; set; }

        public string? Passingattempts { get; set; }
        public string? Passingcompletions { get; set; }
        public string? Passingyards { get; set; }
        public string? Passingtouchdowns { get; set; }
        public string? Passinginterceptions { get; set; }
        public string? Passingyardsperattempt { get; set; }
        public string? Passingyardspercompletion { get; set; }

        public string? Completionpercentage { get; set; }
        public string? Passerrating { get; set; }
        public string? Thirddownattempts { get; set; }
        public string? Thirddownconversions { get; set; }
        public string? Thirddownpercentage { get; set; }
        public string? Fourthdownattempts { get; set; }
        public string? Fourthdownconversions { get; set; }
        public string? Fourthdownpercentage { get; set; }
        public string? Redzoneattempts { get; set; }
        public string? Redzoneconversions { get; set; }
        public string? Goaltogoattempts { get; set; }
        public string? Goaltogoconversions { get; set; }
        public string? Penalties { get; set; }
        public string? Penaltyyards { get; set; }
        public string? Fumbles { get; set; }
        public string? Fumbleslost { get; set; }
        public DateTime? Timessacked { get; set; }
        public DateTime? Timessackedyards { get; set; }
        public string? Quarterbackhits { get; set; }
        public int? Tacklesforloss { get; set; }
        public string? Punts { get; set; }
        public string? Puntyards { get; set; }
        public string? Puntaverage { get; set; }
        public string? Giveaways { get; set; }
        public string? Takeaways { get; set; }
        public string? Turnoverdifferential { get; set; }
        public string? Opponentscorequarter1 { get; set; }
        public string? Opponentscorequarter2 { get; set; }
        public string? Opponentscorequarter3 { get; set; }
        public string? Opponentscorequarter4 { get; set; }
        public string? Opponentscoreovertime { get; set; }
        public string? Opponenttimeofpossessionminutes { get; set; }
        public string? Opponenttimeofpossessionseconds { get; set; }
        public string? Opponenttimeofpossession { get; set; }
        public string? Opponentfirstdowns { get; set; }
        public string? Opponentfirstdownsbyrushing { get; set; }

        public string? Opponentfirstdownsbypassing { get; set; }

        public string? Opponentfirstdownsbypenalty { get; set; }
        public string? Opponentoffensiveplays { get; set; }
        public string? Opponentoffensiveyards { get; set; }
        public string? Opponentoffensiveyardsperplay { get; set; }
        public string? Opponenttouchdowns { get; set; }
        public string? Opponentrushingattempts { get; set; }
        public string? Opponentrushingyards { get; set; }
        public string? Opponentrushingyardsperattempt { get; set; }
        public string? Opponentrushingtouchdowns { get; set; }

        public string? Opponentpassingattempts { get; set; }
        public string? Opponentpassingcompletions { get; set; }
        public string? Opponentpassingyards { get; set; }
        public string? Opponentpassingtouchdowns { get; set; }
        public string? Opponentpassinginterceptions { get; set; }
        public string? Opponentpassingyardsperattempt { get; set; }
        public string? Opponentpassingyardspercompletion { get; set; }

        public string? Opponentcompletionpercentage { get; set; }
        public string? Opponentpasserrating { get; set; }
        public string? Opponentthirddownattempts { get; set; }
        public string? Opponentthirddownconversions { get; set; }
        public string? Opponentthirddownpercentage { get; set; }
        public string? Opponentfourthdownattempts { get; set; }
        public string? Opponentfourthdownconversions { get; set; }
        public string? Opponentfourthdownpercentage { get; set; }
        public string? Opponentredzoneattempts { get; set; }
        public string? Opponentredzoneconversions { get; set; }
        public string? Opponentgoaltogoattempts { get; set; }
        public string? Opponentgoaltogoconversions { get; set; }
        public string? Opponentpenalties { get; set; }
        public string? Opponentpenaltyyards { get; set; }
        public string? Opponentfumbles { get; set; }
        public string? Opponentfumbleslost { get; set; }
        public string? Opponenttimessacked { get; set; }
        public string? Opponenttimessackedyards { get; set; }
        public string? Opponentquarterbackhits { get; set; }
        public string? Opponenttacklesforloss { get; set; }
        public string? Opponentpunts { get; set; }
        public string? Opponentpuntyards { get; set; }
        public string? Opponentpuntaverage { get; set; }
        public string? Opponentgiveaways { get; set; }
        public string? Opponenttakeaways { get; set; }
        public string? Opponentturnoverdifferential { get; set; }
        public string? Redzonepercentage { get; set; }
        public string? Goaltogopercentage { get; set; }
        public string? Opponentredzonepercentage { get; set; }
        public string? Opponentgoaltogopercentage { get; set; }
        public string? Extrapointkickingattempts { get; set; }
        public string? Extrapointkickingconversions { get; set; }

        public string? Extrapointshadblocked { get; set; }
        public string? Extrapointpassingattempts { get; set; }
        public string? Extrapointpassingconversions { get; set; }

        public string? Extrapointrushingattempts { get; set; }
        public string? Extrapointrushingconversions { get; set; }

        public int? Fieldgoalattempts { get; set; }
        public int? Fieldgoalsmade { get; set; }
        public string? Opponentextrapointkickingattempts { get; set; }
        public string? Opponentextrapointkickingconversions { get; set; }

        public string? Opponentextrapointshadblocked { get; set; }
        public string? Opponentextrapointpassingattempts { get; set; }
        public string? Opponentextrapointpassingconversions { get; set; }

        public string? Opponentextrapointrushingattempts { get; set; }
        public string? Opponentextrapointrushingconversions { get; set; }

        public string? Opponentfieldgoalattempts { get; set; }
        public string? Opponentfieldgoalsmade { get; set; }
        public string? Solotackles { get; set; }
        public string? Assistedtackles { get; set; }
        public int? Sacks { get; set; }
        public string? Sackyards { get; set; }
        public string? Passesdefended { get; set; }
        public string? Fumblesforced { get; set; }
        public string? Fumblesrecovered { get; set; }
        public string? Opponentsolotackles { get; set; }
        public string? Opponentassistedtackles { get; set; }
        public string? Opponentsacks { get; set; }
        public string? Opponentsackyards { get; set; }
        public string? Opponentpassesdefended { get; set; }
        public string? Opponentfumblesforced { get; set; }
        public string? Opponentfumblesrecovered { get; set; }
        public string? Dayofweek { get; set; }
        public int TeamId { get; set; }
        public virtual NFLTeam? TeamEntity { get; set; }
        public int OpponentId { get; set; }
        public int? Scoreid { get; set; }
        // Collections
        public virtual ICollection<NFLPlayerGame> PlayerStats { get; set; } = new List<NFLPlayerGame>();
    }
}
