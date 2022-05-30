namespace MeChallenge.Domain.AggregatesModels.Product
{
    using SeedWorks;
    using System;

    public class ProductId : TypedIdValueBase
    {
        public ProductId(Guid value) : base(value)
        {
        }
    }
}