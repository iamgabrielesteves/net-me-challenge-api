namespace MeChallenge.Application.Orders.CreateNewOrder
{
    using FluentValidation;

    public class OrderCommandValidator : AbstractValidator<CreateOrderDto>
    {
        public OrderCommandValidator()
        {
            RuleForEach(x => x.Itens).SetValidator(new OrderItemsDtoValidator());
        }
    }
}