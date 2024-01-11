using FastFoodTotem.Api.Controllers.Base;
using FastFoodTotem.Application.ApplicationServicesInterfaces;
using FastFoodTotem.Application.Dtos.Requests.Customer;
using FastFoodTotem.Application.Dtos.Responses.Customer;
using FastFoodTotem.Application.Dtos.Responses;
using FastFoodTotem.Domain.Validations;
using Microsoft.AspNetCore.Mvc;

namespace FastFoodTotem.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{ver:apiVersion}/customer")]
    [Produces("application/json")]
    public class PaymentController : BaseController
    {
        //private readonly ICheckoutApplicationService _checkoutApplicationService;

        public PaymentController(/*ICheckoutApplicationService checkoutApplicationService,*/ 
            IValidationNotifications validationNotifications)
            : base(validationNotifications)
        {
            //_checkoutApplicationService = checkoutApplicationService;
        }

        /// <summary>
        /// Generates chckout of product list.
        /// </summary>
        /// <returns>Id of customer created</returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiBaseResponse<CustomerCreateResponseDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiBaseResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiBaseResponse))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ApiBaseResponse<CustomerCreateResponseDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiBaseResponse))]
        [HttpPost]
        public async Task<IActionResult> Create(CustomerCreateRequestDto customerCreateRequestDto, CancellationToken cancellationToken)
        {
            return Ok();
            //var customerCreateResponseDto = await _customerApplicationService.AddCustomerAsync(customerCreateRequestDto, cancellationToken);
            //return await Return(customerCreateResponseDto);
        }
    }
}
