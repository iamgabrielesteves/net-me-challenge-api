namespace MeChallenge.Infrastructure.Domain
{
    using Database;
    using MeChallenge.Domain.SeedWorks;
    using System.Threading;
    using System.Threading.Tasks;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly MeChallengeContext _ordersContext;

        public UnitOfWork(MeChallengeContext ordersContext)
        {
            _ordersContext = ordersContext;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            return await _ordersContext.SaveChangesAsync(cancellationToken);
        }
    }
}