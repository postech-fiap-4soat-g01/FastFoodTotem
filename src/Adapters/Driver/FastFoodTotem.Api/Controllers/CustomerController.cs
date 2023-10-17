using FastFoodTotem.Api.Controllers.Base;
using FastFoodTotem.Application.Dtos.Requests.Customer;
using FastFoodTotem.Application.Dtos.Requests.Product;
using FastFoodTotem.Application.Dtos.Responses.Customer;
using FastFoodTotem.Domain.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace FastFoodTotem.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{ver:apiVersion}/customer")]
    [Produces("application/json")]
    public class CustomerController : BaseController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// Create a new customer.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST
        ///     {
        ///         "customerName": "Fulano de Tal",
        ///         "customerEmail": "fulano@tal.com",
        ///         "customerIdentification": "12345678909"
        ///     }
        ///
        /// </remarks>
        /// <returns>Id of customer created</returns>
        /// <response code="201">Request was processed sucessfully</response>
        /// <response code="400">Body in the request was wrong.</response>
        /// <response code="500">Internal server error</response>
        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status201Created, type: typeof(CustomerCreateResponseDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(CustomerCreateRequestDto customerCreateRequestDto, CancellationToken cancellationToken)
        {
            try
            {
                var customer = await _customerService.AddCustomer(customerCreateRequestDto, cancellationToken);

                return Ok(customer);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding customer");
            }
        }

        /// <summary>
        /// Retrieve a customer by cpf.
        /// </summary>
        /// <returns>Customer</returns>
        /// <response code="200">Request was processed sucessfully</response>
        /// <response code="400">Body in the request was wrong.</response>
        /// <response code="500">Internal server error</response>
        [HttpGet("{cpf}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(CustomerGetByCPFResponseDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCustomerByCpf(string cpf, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _customerService.GetCustomerByCPF(cpf, cancellationToken));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something wrong occurred while trying to retrieve customer.");
            }
        }

        /// <summary>
        /// Retrieve a list of all customers.
        /// </summary>
        /// <returns>List of customers</returns>
        /// <response code="200">Request was processed sucessfully</response>
        /// <response code="400">Body in the request was wrong.</response>
        /// <response code="500">Internal server error</response>
        [HttpGet()]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(IEnumerable<CustomerGetResponseDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCustomers(CancellationToken cancellationToken)
        {
            var customers = await _customerService.GetCustomers(cancellationToken);

            if (customers is null || !customers.Any())
            {
                return NoContent();
            }

            return Ok(customers);
        }
    }
}
