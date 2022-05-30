namespace MeChallenge.Application.Orders.GetOrders
{
    using System;

    public class GetOrdersQuery : IQuery<GetOrdersDto>
    {
        public GetOrdersQuery(Guid orderId)
        {
            OrderId = orderId;
        }

        public Guid OrderId { get; }
    }
}