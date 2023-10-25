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
        
    }
}
