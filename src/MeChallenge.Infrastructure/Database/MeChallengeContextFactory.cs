namespace MeChallenge.Infrastructure.Database
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
    using SeedWork;

    public class MeChallengeContextFactory : IDesignTimeDbContextFactory<MeChallengeContext>
    {
        public MeChallengeContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<MeChallengeContext> optionsBuilder =
                new();
            optionsBuilder.UseNpgsql(
                "User ID=postgres;Password=Postgres2019!;Host=localhost;Port=15432;Database=postgres");
            optionsBuilder.ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();

            return new MeChallengeContext(optionsBuilder.Options);
        }
    }
}