using FastFoodTotem.Api.Controllers.Base;
using FastFoodTotem.Application.Dtos.Requests.Order;
using FastFoodTotem.Domain.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace FastFoodTotem.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{ver:apiVersion}/order")]
    [Produces("application/json")]
    public class OrderController : BaseController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Create a new order.
        /// </summary>
        /// <param name="orderCreateRequestDto"></param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST
        ///     {
        ///        "clientId": "8322d708-507a-41d2-901d-620fe97948f6",
        ///        "items": [
        ///             {
        ///                 "id": "f2f73569-6760-4c25-a8f4-96effc5419f5"
        ///             }
        ///        ]
        ///     }
        ///
        /// </remarks>
        /// <returns>Id of the new order created</returns>
        /// <response code="200">Request was processed sucessfully</response>
        /// <response code="400">Body in the request was wrong.</response>
        /// <response code="500">Internal server error</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateOrder([FromBody] OrderCreateRequestDto orderCreateRequestDto, CancellationToken cancellationToken)
        => Ok(await _orderService.CreateAsync(orderCreateRequestDto, cancellationToken));
    }
}
