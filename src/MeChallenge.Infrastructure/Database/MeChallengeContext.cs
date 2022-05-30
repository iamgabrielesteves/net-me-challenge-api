namespace MeChallenge.Infrastructure.Database
{
    using MeChallenge.Domain.AggregatesModels.Order;
    using MeChallenge.Domain.AggregatesModels.Product;
    using Microsoft.EntityFrameworkCore;

    public class MeChallengeContext : DbContext
    {
        public MeChallengeContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeChallengeContext).Assembly);
        }
    }
}