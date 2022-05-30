namespace MeChallenge.Application.Orders.GetOrders
{
    using Domain.AggregatesModels.Order;
    using Domain.AggregatesModels.Product;
    using Domain.SeedWorks;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetOrdersQueryHandler : IQueryHandler<GetOrdersQuery, GetOrdersDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public GetOrdersQueryHandler(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<GetOrdersDto> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            Order order = await _orderRepository.GetByIdAsync(new OrderId(request.OrderId));

            if (order == null)
            {
                return new GetOrdersDto
                {
                    Pedido = TypedIdValueBase.EmptyValue, Status = OrderStatus.CODIGO_PEDIDO_INVALIDO.ToString()
                };
            }

            GetOrdersDto getOrdersDto = new GetOrdersDto {Pedido = order.OrderId.Value};

            List<Product> productsOfOrders = await _productRepository.GetByIdsAsync(order
                .OrderProducts.Select(x => x.ProductId).ToList());

            foreach (Product product in productsOfOrders)
            {
                OrderProducts? orderProduct = order.OrderProducts.Find(x => x.ProductId == product.ProductId);

                GetOrdersItensDto orderItem = new GetOrdersItensDto
                {
                    Description = product.Description,
                    Quantity = orderProduct.Quantity,
                    UnitValue = product.UnitValue
                };

                getOrdersDto.Itens.Add(orderItem);
            }

            return getOrdersDto;
        }
    }
}