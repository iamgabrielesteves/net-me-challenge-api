namespace MeChallenge.Domain.AggregatesModels.Order
{
    using SeedWorks;
    using System;

    public class OrderId : TypedIdValueBase
    {
        public OrderId(Guid value) : base(value)
        {
        }
    }
}