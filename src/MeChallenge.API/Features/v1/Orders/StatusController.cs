namespace MeChallenge.API.Features.v1.Orders
{
    using Application.Status.ChangeStatus;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Net;
    using System.Threading.Tasks;

    [ApiController]
    [ApiVersion("1")]
    [Route("api/status")]
    [Produces("application/json")]
    public class StatusController : Controller
    {
        private readonly IMediator _mediator;

        public StatusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        ///     Change a status order.
        /// </summary>
        /// <param name="statusDto"></param>
        /// <returns>List of customer orders.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(StatusResponseDto), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> GetCustomerOrders(StatusDto statusDto)
        {
            StatusResponseDto order = await _mediator.Send(new ChangeStatusCommand(statusDto.Pedido,
                statusDto.ItensAprovados, statusDto.ValorAprovado));
            return Created(string.Empty, order);
        }
    }
}