namespace MeChallenge.Domain.AggregatesModels.Order
{
    using System.Threading.Tasks;

    public interface IOrderRepository
    {
        Task<Order> GetByIdAsync(OrderId id);
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
    }
}