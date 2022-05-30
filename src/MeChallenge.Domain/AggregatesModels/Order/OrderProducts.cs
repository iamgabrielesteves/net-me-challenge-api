namespace MeChallenge.Domain.AggregatesModels.Order
{
    using Product;
    using SeedWorks;

    public class OrderProducts : Entity
    {
        public OrderProducts()
        {
        }

        public OrderProducts(ProductId productId, decimal productUnitValue, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;

            CalculateValue(productUnitValue);
        }

        public ProductId ProductId { get; set; }
        public OrderId OrderId { get; set; }

        public decimal Value { get; private set; }
        public int Quantity { get; }

        internal static OrderProducts CreateForProduct(ProductId productId, decimal productUnitValue, int quantity)
        {
            return new OrderProducts(productId, productUnitValue, quantity);
        }

        private void CalculateValue(decimal productPrice)
        {
            Value = Quantity * productPrice;
        }
    }
}