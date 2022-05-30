namespace MeChallenge.Application.Orders.CreateNewOrder
{
    using Domain.AggregatesModels.Order;
    using Domain.AggregatesModels.Product;
    using Domain.SeedWorks;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand, CreateOrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrderCommandHandler(IUnitOfWork unitOfWork, IOrderRepository orderRepository,
            IProductRepository productRepository)
        {
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }


        public async Task<CreateOrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            List<ProductId> producstsIds = request.Items.Select(x => new ProductId(x.Produto)).ToList();
            List<Product> products = await _productRepository.GetByIdsAsync(producstsIds);

            List<OrderProducts> orderProducts = (from x in request.Items
                let product = products.Find(y => y.ProductId.Value == x.Produto)
                select new OrderProducts(product.ProductId, product.UnitValue, x.Qtd)).ToList();

            Order order = new(orderProducts);

            await _orderRepository.AddAsync(order);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new CreateOrderDto
            {
                Pedido = order.OrderId.Value,
                Itens = order.OrderProducts.Select(x => new CreateOrderItemsDto
                {
                    Produto = x.ProductId.Value, Qtd = x.Quantity, PrecoUnitario = x.Value / x.Quantity
                }).ToList()
            };
        }
    }
}