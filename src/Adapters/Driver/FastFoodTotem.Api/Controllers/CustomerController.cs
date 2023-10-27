using FastFoodTotem.Api.Controllers.Base;
using FastFoodTotem.Application.ApplicationServicesInterfaces;
using FastFoodTotem.Application.Dtos.Requests.Customer;
using FastFoodTotem.Domain.Validations;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet()]
        public async Task<IActionResult> GetCustomers(CancellationToken cancellationToken)
        {
            var customers = await _customerApplicationService.GetCustomersAsync(cancellationToken);
            return await Return(customers);
        }
    }
}
