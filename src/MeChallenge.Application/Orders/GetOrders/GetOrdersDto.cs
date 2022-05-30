namespace MeChallenge.Application.Orders.GetOrders
{
    using System;
    using System.Collections.Generic;

    public class GetOrdersDto
    {
        public GetOrdersDto()
        {
            Itens = new List<GetOrdersItensDto>();
        }

        public Guid? Pedido { get; set; }

        public string Status { get; set; }

        public List<GetOrdersItensDto> Itens { get; set; }
    }
}