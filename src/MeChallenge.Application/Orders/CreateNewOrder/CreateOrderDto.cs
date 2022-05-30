namespace MeChallenge.Application.Orders.CreateNewOrder
{
    using System;
    using System.Collections.Generic;

    public class CreateOrderDto
    {
        public CreateOrderDto()
        {
            Itens = new List<CreateOrderItemsDto>();
        }

        public Guid? Pedido { get; set; }
        public List<CreateOrderItemsDto> Itens { get; set; }
    }
}