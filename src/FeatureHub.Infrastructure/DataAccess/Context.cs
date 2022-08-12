using FeatureHub.Domain.Hub;
using FeatureHub.Infrastructure.DataAccess.Map.Hub;
using Microsoft.EntityFrameworkCore;

namespace FeatureHub.Infrastructure.DataAccess
{
    public class Context : DbContext
    {
        public DbSet<Features> Features { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("CONN"), npgsqlOptionsAction: options =>
            {
                options.EnableRetryOnFailure(2, TimeSpan.FromSeconds(5), new List<string>());
                options.MigrationsHistoryTable("_MigrationHistory", "Hub");
            });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FeaturesMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
