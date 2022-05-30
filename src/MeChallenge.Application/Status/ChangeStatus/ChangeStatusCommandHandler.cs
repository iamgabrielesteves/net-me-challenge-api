namespace MeChallenge.Application.Status.ChangeStatus
{
    using Domain.AggregatesModels.Order;
    using Domain.SeedWorks;
    using System.Threading;
    using System.Threading.Tasks;

    public class ChangeStatusCommandHandler : ICommandHandler<ChangeStatusCommand, StatusResponseDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ChangeStatusCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<StatusResponseDto> Handle(ChangeStatusCommand request, CancellationToken cancellationToken)
        {
            Order order = await _orderRepository.GetByIdAsync(new OrderId(request.OrderId.Value));

            if (order == null)
            {
                return new StatusResponseDto
                {
                    Pedido = TypedIdValueBase.EmptyValue, Status = OrderStatus.CODIGO_PEDIDO_INVALIDO.ToString()
                };
            }

            order.CheckStatusOrder(request.ValueApproved, request.ItemsApproved);

            await _orderRepository.UpdateAsync(order);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new StatusResponseDto {Pedido = order.OrderId.Value, Status = order.OrderStatus.ToString()};
        }
    }
}