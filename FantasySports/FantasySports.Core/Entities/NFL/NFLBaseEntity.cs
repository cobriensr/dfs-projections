namespace FantasySports.Core.Entities.NFL
{
    public abstract class NFLBaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; } = false;

        // Usage tracking
        public DateTime? LastAccessedAt { get; set; }
        public int AccessCount { get; set; } = 0;
    }
}