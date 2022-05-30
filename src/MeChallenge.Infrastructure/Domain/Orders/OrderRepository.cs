namespace MeChallenge.Infrastructure.Domain.Orders
{
    using Database;
    using MeChallenge.Domain.AggregatesModels.Order;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading.Tasks;

    public class OrderRepository : IOrderRepository
    {
        private readonly MeChallengeContext _context;

        public OrderRepository(MeChallengeContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Order> GetByIdAsync(OrderId id)
        {
            return await _context.Orders
                .Include("OrderProducts")
                .SingleOrDefaultAsync(x => x.OrderId == id);
        }

        public async Task AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
        }

        public async Task UpdateAsync(Order order)
        {
            _context.Update(order);
        }
    }
}