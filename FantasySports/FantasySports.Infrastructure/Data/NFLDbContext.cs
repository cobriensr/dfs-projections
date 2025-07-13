using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using FantasySports.Core.Entities.NFL;
using System.Linq.Expressions;

namespace FantasySports.Infrastructure.Data
{
    public class NFLDbContext : DbContext
    {
        public NFLDbContext(DbContextOptions<NFLDbContext> options) : base(options) { }

        public DbSet<NFLTeam> Teams { get; set; }
        public DbSet<NFLPlayer> Players { get; set; }
        public DbSet<NFLStadium> Stadiums { get; set; }
        public DbSet<NFLStanding> Standings { get; set; }
        public DbSet<NFLPlayerGame> PlayerGames { get; set; }
        public DbSet<NFLPlayerGameProjection> PlayerGameProjections { get; set; }
        public DbSet<NFLPlayerSeason> PlayerSeasons { get; set; }
        public DbSet<NFLPlayerSeasonProjection> PlayerSeasonProjections { get; set; }
        public DbSet<NFLFantasyDefenseGame> FantasyDefenseGames { get; set; }
        public DbSet<NFLFantasyDefenseGameProjection> FantasyDefenseGameProjections { get; set; }
        public DbSet<NFLFantasyDefenseSeason> FantasyDefenseSeasons { get; set; }
        public DbSet<NFLFantasyDefenseSeasonProjection> FantasyDefenseSeasonProjections { get; set; }
        public DbSet<NFLTeamSeason> TeamSeasons { get; set; }
        public DbSet<NFLTeamGame> TeamGames { get; set; }
        public DbSet<NFLScore> Scores { get; set; }
        public DbSet<NFLQuarter> Quarters { get; set; }

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
            var entries = ChangeTracker.Entries<NFLBaseEntity>();

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
            // Apply to all entities that inherit from NFLBaseEntity
            foreach (var entityType in modelBuilder.Model.GetEntityTypes()
                .Where(e => typeof(NFLBaseEntity).IsAssignableFrom(e.ClrType)))
            {
                // Add index on IsDeleted for performance
                modelBuilder.Entity(entityType.ClrType)
                    .HasIndex("IsDeleted")
                    .HasDatabaseName($"IX_{entityType.GetTableName()}_IsDeleted");
            }

            // Global query filter to exclude deleted records by default
            foreach (var entityType in modelBuilder.Model.GetEntityTypes()
                .Where(e => typeof(NFLBaseEntity).IsAssignableFrom(e.ClrType)))
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