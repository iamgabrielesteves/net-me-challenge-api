namespace MeChallenge.Application.Orders.CreateNewOrder
{
    using FluentValidation;

    public class OrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public OrderCommandValidator()
        {
            RuleForEach(x => x.Items).SetValidator(new OrderItemsDtoValidator());
        }
    }
}