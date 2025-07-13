namespace FantasySports.Core.Entities.MLB
{
    public class MLBTeamSeason : MLBBaseEntity
    {
        public int Id { get; set; }
        public int ExternalStatId { get; set; }
        public int TeamId { get; set; }
        public virtual MLBTeam? TeamEntity { get; set; }
        public int? Seasontype { get; set; }
        public int? Season { get; set; }
        public string? Name { get; set; }
        public string? Team { get; set; }
        public int? Games { get; set; }
        public string? Fantasypoints { get; set; }
        public string? Atbats { get; set; }
        public int? Runs { get; set; }
        public int? Hits { get; set; }
        public string? Singles { get; set; }
        public string? Doubles { get; set; }
        public string? Triples { get; set; }
        public string? Homeruns { get; set; }
        public int? Runsbattedin { get; set; }
        public string? Battingaverage { get; set; }
        public string? Outs { get; set; }
        public string? Strikeouts { get; set; }
        public string? Walks { get; set; }
        public string? Hitbypitch { get; set; }
        public string? Sacrifices { get; set; }
        public string? Sacrificeflies { get; set; }
        public string? Groundintodoubleplay { get; set; }
        public string? Stolenbases { get; set; }
        public string? Caughtstealing { get; set; }
        public string? Onbasepercentage { get; set; }
        public decimal? Sluggingpercentage { get; set; }
        public string? Onbaseplusslugging { get; set; }
        public int? Wins { get; set; }
        public int? Losses { get; set; }
        public int? Saves { get; set; }
        public string? Inningspitcheddecimal { get; set; }
        public int? Totaloutspitched { get; set; }
        public string? Inningspitchedfull { get; set; }
        public string? Inningspitchedouts { get; set; }
        public string? Earnedrunaverage { get; set; }
        public string? Pitchinghits { get; set; }
        public string? Pitchingruns { get; set; }
        public string? Pitchingearnedruns { get; set; }
        public string? Pitchingwalks { get; set; }
        public string? Pitchingstrikeouts { get; set; }
        public string? Pitchinghomeruns { get; set; }
        public string? Pitchesthrown { get; set; }
        public string? Pitchesthrownstrikes { get; set; }
        public string? Walkshitsperinningspitched { get; set; }
        public string? Pitchingbattingaverageagainst { get; set; }
        public string? Fantasypointsfanduel { get; set; }
        public string? Fantasypointsdraftkings { get; set; }
        public decimal? Weightedonbasepercentage { get; set; }
        public string? Pitchingcompletegames { get; set; }
        public string? Pitchingshutouts { get; set; }
        public string? Pitchingonbasepercentage { get; set; }
        public string? Pitchingsluggingpercentage { get; set; }
        public string? Pitchingonbaseplusslugging { get; set; }
        public string? Pitchingstrikeoutspernineinnings { get; set; }
        public string? Pitchingwalkspernineinnings { get; set; }
        public string? Pitchingweightedonbasepercentage { get; set; }
        public string? Fantasypointsbatting { get; set; }
        public string? Fantasypointspitching { get; set; }
    }
}
