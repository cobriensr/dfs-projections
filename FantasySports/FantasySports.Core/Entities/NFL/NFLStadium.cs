namespace FantasySports.Core.Entities.NFL
{
    public class NFLStadium : NFLBaseEntity
    {
        public int Id { get; set; }
        public int StadiumId { get; set; }
        public virtual NFLStadium? Stadium { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int? Country { get; set; }
        public int? Capacity { get; set; }
        public string? Playingsurface { get; set; }
        public string? Geolat { get; set; }
        public string? Geolong { get; set; }
        public string? Type { get; set; }
    }
}
