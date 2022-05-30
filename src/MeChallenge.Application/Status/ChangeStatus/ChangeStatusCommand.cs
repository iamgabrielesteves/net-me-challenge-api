namespace MeChallenge.Application.Status.ChangeStatus
{
    using System;

    public class ChangeStatusCommand : CommandBase<StatusResponseDto>
    {
        public ChangeStatusCommand(Guid? orderId, int itemsApproved, decimal valueApproved)
        {
            OrderId = orderId;
            ItemsApproved = itemsApproved;
            ValueApproved = valueApproved;
        }

        public Guid? OrderId { get; set; }

        public int ItemsApproved { get; set; }

        public decimal ValueApproved { get; set; }
    }
}