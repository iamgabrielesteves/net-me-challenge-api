namespace MeChallenge.Domain.AggregatesModels.Order
{
    using SeedWorks;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Order : Entity, IAggregateRoot
    {
        public Order()
        {
            OrderProducts = new List<OrderProducts>();
        }

        public Order(IEnumerable<OrderProducts> orderProductsList) : this()
        {
            OrderId = new OrderId(Guid.NewGuid());
            OrderDate = DateTime.UtcNow;

            foreach (OrderProducts orderProduct in orderProductsList)
            {
                AggregatesModels.Order.OrderProducts.CreateForProduct(orderProduct.ProductId,
                    orderProduct.Value,
                    orderProduct.Quantity);

                OrderProducts.Add(orderProduct);
            }

            CheckStatusOrder(ValueApproved, ItemsApproved);
        }

        public OrderId OrderId { get; }
        public DateTime OrderDate { get; }
        public List<OrderProducts> OrderProducts { get; }
        public decimal ValueApproved { get; private set; }
        public int ItemsApproved { get; private set; }
        public OrderStatus OrderStatus { get; private set; }

        public void CheckStatusOrder(decimal valueApproved, int itemsApproved)
        {
            ValueApproved = valueApproved;
            ItemsApproved = itemsApproved;

            int totalOrderItems = OrderProducts.Sum(x => x.Quantity);

            if (itemsApproved == totalOrderItems && valueApproved == GetAmountOrder())
            {
                OrderStatus = OrderStatus.APROVADO;
            }
            else if (itemsApproved > totalOrderItems)
            {
                OrderStatus = OrderStatus.APROVADO_QTD_A_MAIOR;
            }
            else if (itemsApproved < totalOrderItems)
            {
                OrderStatus = OrderStatus.APROVADO_QTD_A_MENOR;
            }
            else if (valueApproved < GetAmountOrder())
            {
                OrderStatus = OrderStatus.APROVADO_VALOR_A_MENOR;
            }
            else if (valueApproved > GetAmountOrder())
            {
                OrderStatus = OrderStatus.APROVADO_VALOR_A_MAIOR;
            }
        }

        private decimal GetAmountOrder()
        {
            return OrderProducts.Sum(x => x.Value);
        }
    }
}