namespace FantasySports.Core.Entities.CollegeFootball
{
    public abstract class CFBBaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; } = false;

        // Usage tracking
        public DateTime? LastAccessedAt { get; set; }
        public int AccessCount { get; set; } = 0;
    }
}