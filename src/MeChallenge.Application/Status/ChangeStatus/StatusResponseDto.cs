namespace MeChallenge.Application.Status.ChangeStatus
{
    using System;

    public class StatusResponseDto
    {
        public Guid? Pedido { get; set; }
        public string Status { get; set; }
    }
}