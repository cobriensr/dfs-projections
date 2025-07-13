using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using FantasySports.Core.Entities.MLB;
using System.Linq.Expressions;

namespace FantasySports.Infrastructure.Data
{
    public class MLBDbContext : DbContext
    {
        public MLBDbContext(DbContextOptions<MLBDbContext> options) : base(options) { }

        public DbSet<MLBTeam> Teams { get; set; }
        public DbSet<MLBPlayer> Players { get; set; }
        public DbSet<MLBStadium> Stadiums { get; set; }
        public DbSet<MLBGame> Games { get; set; }
        public DbSet<MLBPlayerGame> PlayerGames { get; set; }
        public DbSet<MLBPlayerGameProjection> PlayerGameProjections { get; set; }
        public DbSet<MLBPlayerSeason> PlayerSeasons { get; set; }
        public DbSet<MLBPlayerSeasonProjection> PlayerSeasonProjections { get; set; }
        public DbSet<MLBInning> Innings { get; set; }
        public DbSet<MLBTeamGame> TeamGames { get; set; }
        public DbSet<MLBTeamSeason> TeamSeasons { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimestamps();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            UpdateTimestamps();
            return base.SaveChanges();
        }

        private void UpdateTimestamps()
        {
            var entries = ChangeTracker.Entries<MLBBaseEntity>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply to all entities that inherit from MLBBaseEntity
            foreach (var entityType in modelBuilder.Model.GetEntityTypes()
                .Where(e => typeof(MLBBaseEntity).IsAssignableFrom(e.ClrType)))
            {
                // Add index on IsDeleted for performance
                modelBuilder.Entity(entityType.ClrType)
                    .HasIndex("IsDeleted")
                    .HasDatabaseName($"IX_{entityType.GetTableName()}_IsDeleted");
            }

            // Global query filter to exclude deleted records by default
            foreach (var entityType in modelBuilder.Model.GetEntityTypes()
                .Where(e => typeof(MLBBaseEntity).IsAssignableFrom(e.ClrType)))
            {
                var parameter = Expression.Parameter(entityType.ClrType, "e");
                var property = Expression.Property(parameter, "IsDeleted");
                var filter = Expression.Lambda(
                    Expression.Equal(property, Expression.Constant(false)),
                    parameter);

                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(filter);
            }
        }
    }
}