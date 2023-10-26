using FastFoodTotem.Api.Controllers.Base;
using FastFoodTotem.Application.ApplicationServicesInterfaces;
using FastFoodTotem.Application.Dtos.Requests.Order;
using FastFoodTotem.Domain.Contracts.Services;
using FastFoodTotem.Domain.Validations;
using Microsoft.AspNetCore.Mvc;

namespace FastFoodTotem.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{ver:apiVersion}/order")]
    [Produces("application/json")]
    public class OrderController : BaseController
    {
        private readonly IOrderApplicationService _orderApplicationService;

        public OrderController(IOrderApplicationService orderApplicationService, IValidationNotifications validationNotifications)
            : base(validationNotifications)
        {
            _orderApplicationService = orderApplicationService;
        }

        /// <summary>
        /// Create a new order.
        /// </summary>
        /// <param name="orderCreateRequestDto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Id of the new order created</returns>
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderCreateRequestDto orderCreateRequestDto, CancellationToken cancellationToken)
        {
            return await Return(await _orderApplicationService.CreateAsync(orderCreateRequestDto, cancellationToken));
        }

        /// <summary>
        /// Update order status.
        /// </summary>
        /// <param name="orderUpdateRequestDto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Id and new status of the updated order</returns>
        [HttpPatch]
        public async Task<IActionResult> UpdateOrder([FromBody] OrderUpdateRequestDto orderUpdateRequestDto, CancellationToken cancellationToken)
        {
            return await Return(await _orderApplicationService.UpdateAsync(orderUpdateRequestDto, cancellationToken));
        }

        /// <summary>
        /// Get order by id.
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>The order requested</returns>
        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderById([FromRoute] int orderId, CancellationToken cancellationToken)
        {
            return await Return(await _orderApplicationService.GetByIdAsync(orderId, cancellationToken));
        }
    }
}
