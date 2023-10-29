using FastFoodTotem.Api.Controllers.Base;
using FastFoodTotem.Application.ApplicationServicesInterfaces;
using FastFoodTotem.Application.Dtos.Requests.Customer;
using FastFoodTotem.Application.Dtos.Responses.Order;
using FastFoodTotem.Application.Dtos.Responses;
using FastFoodTotem.Domain.Validations;
using Microsoft.AspNetCore.Mvc;
using FastFoodTotem.Application.Dtos.Responses.Customer;

namespace FastFoodTotem.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{ver:apiVersion}/customer")]
    [Produces("application/json")]
    public class CustomerController : BaseController
    {
        private readonly ICustomerApplicationService _customerApplicationService;

        public CustomerController(ICustomerApplicationService customerApplicationService, IValidationNotifications validationNotifications)
            : base(validationNotifications)
        {
            _customerApplicationService = customerApplicationService;
        }

        /// <summary>
        /// Create a new customer.
        /// </summary>
        /// <returns>Id of customer created</returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiBaseResponse<CustomerCreateResponseDto>))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(ApiBaseResponse<CustomerCreateResponseDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiBaseResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiBaseResponse))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ApiBaseResponse<CustomerCreateResponseDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiBaseResponse))]
        [HttpPost]
        public async Task<IActionResult> Create(CustomerCreateRequestDto customerCreateRequestDto, CancellationToken cancellationToken)
        {
            var customerCreateResponseDto = await _customerApplicationService.AddCustomerAsync(customerCreateRequestDto, cancellationToken);
            return await Return(customerCreateResponseDto);
        }

        /// <summary>
        /// Retrieve a customer by cpf.
        /// </summary>
        /// <returns>Customer</returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiBaseResponse<CustomerGetByCPFResponseDto>))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(ApiBaseResponse<CustomerGetByCPFResponseDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiBaseResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiBaseResponse))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ApiBaseResponse<CustomerGetByCPFResponseDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiBaseResponse))]
        [HttpGet("{cpf}")]
        public async Task<IActionResult> GetCustomerByCpf(string cpf, CancellationToken cancellationToken)
        {
            var customerGetByCPFResponseDto = await _customerApplicationService.GetCustomerByCPFAsync(cpf, cancellationToken);
            return await Return(customerGetByCPFResponseDto);
        }

        /// <summary>
        /// Retrieve a list of all customers.
        /// </summary>
        /// <returns>List of customers</returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiBaseResponse<CustomerGetResponseDto>))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(ApiBaseResponse<CustomerGetResponseDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiBaseResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiBaseResponse))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ApiBaseResponse<CustomerGetResponseDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiBaseResponse))]
        [HttpGet()]
        public async Task<IActionResult> GetCustomers(CancellationToken cancellationToken)
        {
            var customers = await _customerApplicationService.GetCustomersAsync(cancellationToken);
            return await Return(customers);
        }
    }
}
