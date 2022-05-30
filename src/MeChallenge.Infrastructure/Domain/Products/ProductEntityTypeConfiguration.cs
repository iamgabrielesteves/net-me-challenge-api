namespace MeChallenge.Infrastructure.Domain.Products
{
    using Database;
    using MeChallenge.Domain.AggregatesModels.Product;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", SchemaNames.MeChallange);
            builder.HasKey(b => b.ProductId);
            builder.Property(b => b.Name);
            builder.Property(b => b.Description);
            builder.Property(b => b.UnitValue);

            builder.HasData(
                new Product("T-shirt", "Lorem Ipsum", 50),
                new Product("Jacket", "Lorem Ipsum", 400),
                new Product("Glasses", "Lorem Ipsum", 250),
                new Product("Shorts", "Lorem Ipsum", 95),
                new Product("Cap", "Lorem Ipsum", 35)
            );
        }
    }
}