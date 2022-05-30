namespace MeChallenge.Application.Status.ChangeStatus
{
    using System;

    public class StatusDto
    {
        public Guid? Pedido { get; set; }

        public int ItensAprovados { get; set; }

        public decimal ValorAprovado { get; set; }
    }
}