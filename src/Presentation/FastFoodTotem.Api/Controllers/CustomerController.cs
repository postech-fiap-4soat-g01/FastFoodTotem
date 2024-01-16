using FastFoodTotem.Api.Controllers.Base;
using FastFoodTotem.Application.Shared.BaseResponse;
using FastFoodTotem.Application.UseCases.Customer.CreateCustomer;
using FastFoodTotem.Application.UseCases.Customer.GetCustomerByCpf;
using FastFoodTotem.Application.UseCases.Customer.GetCustomers;
using FastFoodTotem.Domain.Validations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FastFoodTotem.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{ver:apiVersion}/customer")]
    [Produces("application/json")]
    public class CustomerController : BaseController
    {
        private readonly IMediator _mediator;

        public CustomerController(IValidationNotifications validationNotifications, IMediator mediator)
            : base(validationNotifications)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Create a new customer.
        /// </summary>
        /// <returns>Id of customer created</returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiBaseResponse<CreateCustomerResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiBaseResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiBaseResponse))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ApiBaseResponse<CreateCustomerResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiBaseResponse))]
        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerRequest customerCreateRequestDto, CancellationToken cancellationToken)
        {
            var data = await _mediator.Send(customerCreateRequestDto, cancellationToken);
            return await Return(new ApiBaseResponse<CreateCustomerResponse>() { Data = data });
        }

        /// <summary>
        /// Retrieve a customer by cpf.
        /// </summary>
        /// <returns>Customer</returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiBaseResponse<GetCustomerByCpfResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiBaseResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiBaseResponse))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ApiBaseResponse<GetCustomerByCpfResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiBaseResponse))]
        [HttpGet("{cpf}")]
        public async Task<IActionResult> GetCustomerByCpf(string cpf, CancellationToken cancellationToken)
        {
            var data = await _mediator.Send(new GetCustomerByCpfRequest(cpf), cancellationToken);
            return await Return(new ApiBaseResponse<GetCustomerByCpfResponse>() { Data = data });
        }

        /// <summary>
        /// Retrieve a list of all customers.
        /// </summary>
        /// <returns>List of customers</returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiBaseResponse<GetCustomersResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiBaseResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiBaseResponse))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ApiBaseResponse<GetCustomersResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiBaseResponse))]
        [HttpGet]
        public async Task<IActionResult> GetCustomers(CancellationToken cancellationToken)
        {
            var data = await _mediator.Send(new GetCustomersRequest(), cancellationToken);
            return await Return(new ApiBaseResponse<GetCustomersResponse>() { Data = data });
        }
    }
}
