namespace MeChallenge.Infrastructure.Domain.Orders
{
    using Database;
    using MeChallenge.Domain.AggregatesModels.Order;
    using MeChallenge.Domain.AggregatesModels.Product;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class OrdersEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .ToTable("Orders", SchemaNames.MeChallange)
                .HasKey(x => x.OrderId);

            builder.Property(x => x.OrderDate);
            builder.Property(x => x.ItemsApproved);
            builder.Property(x => x.ValueApproved);
            builder.Ignore(x => x.OrderStatus);

            builder.OwnsMany(o => o.OrderProducts, navigationBuilder =>
            {
                navigationBuilder.ToTable("OrderProducts", SchemaNames.MeChallange);
                navigationBuilder.HasKey(nameof(OrderId), nameof(ProductId));
                navigationBuilder.WithOwner().HasForeignKey(nameof(OrderId));

                navigationBuilder.Property(orderProducts => orderProducts.Value);
                navigationBuilder.Property(orderProducts => orderProducts.Quantity);
            });
        }
    }
}