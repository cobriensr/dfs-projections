namespace FantasySports.Core.Entities.NFL
{
    public class NFLStanding : NFLBaseEntity
    {
        public int Id { get; set; }
        public int? Seasontype { get; set; }
        public int? Season { get; set; }
        public string? Conference { get; set; }
        public string? Division { get; set; }
        public string? Team { get; set; }
        public string? Name { get; set; }
        public int? Wins { get; set; }
        public int? Losses { get; set; }
        public string? Ties { get; set; }
        public decimal? Percentage { get; set; }
        public int? Pointsfor { get; set; }
        public int? Pointsagainst { get; set; }
        public string? Netpoints { get; set; }
        public int? Touchdowns { get; set; }
        public string? Divisionwins { get; set; }
        public string? Divisionlosses { get; set; }
        public string? Conferencewins { get; set; }
        public string? Conferencelosses { get; set; }
        public int TeamId { get; set; }
        public virtual NFLTeam? TeamEntity { get; set; }
        public string? Divisionties { get; set; }
        public string? Conferenceties { get; set; }
        public string? Divisionrank { get; set; }
        public string? Conferencerank { get; set; }
    }
}
