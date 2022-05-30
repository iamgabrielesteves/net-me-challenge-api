namespace MeChallenge.Application.Product.GetList
{
    using System;

    public class ListOfProducstsDto
    {
        public Guid Produto { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public decimal PrecoUnitario { get; set; }
    }
}