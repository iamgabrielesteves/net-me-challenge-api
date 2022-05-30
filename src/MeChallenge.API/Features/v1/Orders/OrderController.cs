namespace MeChallenge.API.Features.v1.Orders
{
    using Application.Orders.CreateNewOrder;
    using Application.Orders.GetOrders;
    using Configuration.ProblemDetails.Helpers;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Net;
    using System.Threading.Tasks;

    [ApiController]
    [ApiVersion("1")]
    [Route("api/pedidos")]
    [Produces("application/json")]
    [ServiceFilter(typeof(ProblemDetailsFilter))]
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        ///     Get order.
        /// </summary>
        /// <param name="orderId">Customer ID.</param>
        /// <returns>List of customer orders.</returns>
        [Route("{orderId:guid}")]
        [HttpGet]
        [ProducesResponseType(typeof(GetOrdersDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCustomerOrders(Guid orderId)
        {
            GetOrdersDto order = await _mediator.Send(new GetOrdersQuery(orderId));
            return Ok(order);
        }

        /// <summary>
        ///     Create a order.
        /// </summary>
        /// <param name="createOrderDto"></param>
        /// <returns>List of customer orders.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(CreateOrderDto), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> GetCustomerOrders(CreateOrderDto createOrderDto)
        {
            CreateOrderDto order = await _mediator.Send(new CreateOrderCommand(createOrderDto.Itens));
            return Created(string.Empty, order);
        }
    }
}