namespace MeChallenge.Application.Orders.CreateNewOrder
{
    using System.Collections.Generic;

    public class CreateOrderCommand : CommandBase<CreateOrderDto>
    {
        public CreateOrderCommand(List<CreateOrderItemsDto> items)
        {
            Items = items;
        }

        public List<CreateOrderItemsDto> Items { get; }
    }
}