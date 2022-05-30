namespace MeChallenge.Application.Orders.CreateNewOrder
{
    using System;

    public class CreateOrderItemsDto
    {
        public Guid Produto { get; set; }

        public int Qtd { get; set; }

        public decimal PrecoUnitario { get; set; }
    }
}