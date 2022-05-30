namespace MeChallenge.Application.Orders.GetOrders
{
    using Newtonsoft.Json;

    public class GetOrdersItensDto
    {
        [JsonProperty("qtd")] public int Quantity { get; set; }

        [JsonProperty("descricao")] public string Description { get; set; }

        [JsonProperty("precoUnitario")] public decimal UnitValue { get; set; }
    }
}