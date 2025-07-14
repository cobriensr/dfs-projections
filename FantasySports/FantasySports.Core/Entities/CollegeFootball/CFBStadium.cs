namespace FantasySports.Core.Entities.CollegeFootball
{
    public class CFBStadium : CFBBaseEntity
    {
        public int Id { get; set; }
        public int StadiumId { get; set; }
        public virtual CFBStadium? StadiumEntity { get; set; }
        public bool? Active { get; set; }
        public string? Name { get; set; }
        public bool? Dome { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Geolat { get; set; }
        public string? Geolong { get; set; }
    }
}
