namespace MeChallenge.API.Features.v1.Orders
{
    using Application.Product.GetList;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;

    [ApiController]
    [ApiVersion("1")]
    [Route("api/produtos")]
    [Produces("application/json")]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        ///     Get product list.
        /// </summary>
        /// <returns>List of customer orders.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<ListOfProducstsDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCustomerOrders()
        {
            List<ListOfProducstsDto> productsList = await _mediator.Send(new GetProductsListQuery());
            return Ok(productsList);
        }
    }
}