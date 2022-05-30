namespace MeChallenge.Domain.AggregatesModels.Product
{
    using SeedWorks;
    using System;

    public class Product : Entity, IAggregateRoot
    {
        public Product()
        {
            ProductId = new ProductId(Guid.NewGuid());
        }

        public Product(string name, string description, decimal unitValue) : this()
        {
            Name = name;
            Description = description;
            UnitValue = unitValue;
        }

        public ProductId ProductId { get; }
        public string Name { get; }
        public string Description { get; }
        public decimal UnitValue { get; }
    }
}