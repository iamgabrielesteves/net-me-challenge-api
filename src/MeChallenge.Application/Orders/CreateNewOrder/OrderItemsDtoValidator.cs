namespace MeChallenge.Application.Orders.CreateNewOrder
{
    using FluentValidation;

    public class OrderItemsDtoValidator : AbstractValidator<CreateOrderItemsDto>
    {
        public OrderItemsDtoValidator()
        {
            RuleFor(x => x.Produto).NotEmpty().NotNull()
                .WithMessage("Identificador de produto é obrigatorio");
            RuleFor(x => x.Qtd).NotEmpty().NotNull()
                .WithMessage("Quantidade de produto é obrigatorio");
        }
    }
}