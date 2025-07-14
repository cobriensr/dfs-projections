using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using FantasySports.Core.Entities.CollegeFootball;
using System.Linq.Expressions;

namespace FantasySports.Infrastructure.Data
{
    public class CFBDbContext : DbContext
    {
        public CFBDbContext(DbContextOptions<CFBDbContext> options) : base(options) { }

        public DbSet<CFBTeam> Teams { get; set; }
        public DbSet<CFBPlayer> Players { get; set; }
        public DbSet<CFBStadium> Stadiums { get; set; }
        public DbSet<CFBGame> Games { get; set; }
        public DbSet<CFBPlayerGame> PlayerGames { get; set; }
        public DbSet<CFBPlayerGameProjection> PlayerGameProjections { get; set; }
        public DbSet<CFBPlayerSeason> PlayerSeasons { get; set; }
        public DbSet<CFBTeamGame> TeamGames { get; set; }
        public DbSet<CFBTeamSeason> TeamSeasons { get; set; }
        public DbSet<CFBPeriod> Periods { get; set; }

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
            var entries = ChangeTracker.Entries<CFBBaseEntity>();

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
            // Use schema for CFB
            modelBuilder.HasDefaultSchema("cfb");

            // Configure CFB Game relationships
            modelBuilder.Entity<CFBGame>(entity =>
            {
                entity.HasOne(g => g.HomeTeam)
                    .WithMany(t => t.HomeGames)
                    .HasForeignKey(g => g.HomeTeamId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(g => g.AwayTeam)
                    .WithMany(t => t.AwayGames)
                    .HasForeignKey(g => g.AwayTeamId)
                    .OnDelete(DeleteBehavior.Restrict);

                // If you have stadium navigation
                entity.HasOne(g => g.StadiumEntity)
                    .WithMany()
                    .HasForeignKey(g => g.StadiumId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // If you have player relationships
            modelBuilder.Entity<CFBPlayer>(entity =>
            {
                entity.HasOne(p => p.TeamEntity)
                    .WithMany(t => t.Players)
                    .HasForeignKey(p => p.TeamId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Your existing base entity configuration
            foreach (var entityType in modelBuilder.Model.GetEntityTypes()
                .Where(e => typeof(CFBBaseEntity).IsAssignableFrom(e.ClrType)))
            {
                // Add index on IsDeleted for performance
                modelBuilder.Entity(entityType.ClrType)
                    .HasIndex("IsDeleted")
                    .HasDatabaseName($"IX_{entityType.GetTableName()}_IsDeleted");
            }

            // Global query filter to exclude deleted records by default
            foreach (var entityType in modelBuilder.Model.GetEntityTypes()
                .Where(e => typeof(CFBBaseEntity).IsAssignableFrom(e.ClrType)))
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