namespace MeChallenge.Application.Status.ChangeStatus
{
    using FluentValidation;

    public class ChangeStatusCommandValidator : AbstractValidator<ChangeStatusCommand>
    {
        public ChangeStatusCommandValidator()
        {
            RuleFor(x => x.OrderId).NotEmpty().NotNull();
            RuleFor(x => x.ItemsApproved).NotEmpty().NotNull();
            RuleFor(x => x.ValueApproved).NotEmpty().NotNull();
        }
    }
}