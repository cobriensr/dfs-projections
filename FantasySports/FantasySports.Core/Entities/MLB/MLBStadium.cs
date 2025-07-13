namespace FantasySports.Core.Entities.MLB
{
    public class MLBStadium : MLBBaseEntity
    {
        public int Id { get; set; }
        public int StadiumId { get; set; }
        public virtual MLBStadium? Stadium { get; set; }
        public bool? Active { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int? Country { get; set; }
        public int? Capacity { get; set; }
        public string? Surface { get; set; }
        public string? Leftfield { get; set; }
        public string? Midleftfield { get; set; }
        public string? Leftcenterfield { get; set; }
        public string? Midleftcenterfield { get; set; }
        public string? Centerfield { get; set; }
        public string? Midrightcenterfield { get; set; }
        public string? Rightcenterfield { get; set; }
        public string? Midrightfield { get; set; }
        public string? Rightfield { get; set; }
        public string? Geolat { get; set; }
        public string? Geolong { get; set; }
        public int? Altitude { get; set; }
        public string? Homeplatedirection { get; set; }
        public string? Type { get; set; }
    }
}
