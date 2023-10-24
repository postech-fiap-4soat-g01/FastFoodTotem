using AutoMapper;
using FastFoodTotem.Application.ApplicationServicesInterfaces;
using FastFoodTotem.Application.Dtos.Requests.Customer;
using FastFoodTotem.Application.Dtos.Responses;
using FastFoodTotem.Application.Dtos.Responses.Customer;
using FastFoodTotem.Domain.Contracts.Services;
using FastFoodTotem.Domain.Entities;
using FastFoodTotem.Domain.Validations;
using FluentValidation;

namespace FastFoodTotem.Application.ApplicationServices;

public class CustomerApplicationService : BaseApplicationService, ICustomerApplicationService
{
    private readonly IMapper _mapper;
    private readonly ICustomerService _customerService;
    private readonly IValidator<CustomerCreateRequestDto> _customerCreateRequestDtoValidation;

    public CustomerApplicationService(
        ICustomerService customerService,
        IMapper mapper,
        IValidationNotifications validationNotifications,
        IValidator<CustomerCreateRequestDto> customerCreateRequestDtoValidation)
        : base(validationNotifications)
    {
        _customerService = customerService;
        _mapper = mapper;
        _customerCreateRequestDtoValidation = customerCreateRequestDtoValidation;
    }

    public async Task<ApiBaseResponse<CustomerCreateResponseDto>> AddCustomerAsync(CustomerCreateRequestDto customerCreateRequestDto, CancellationToken cancellationToken)
    {
        var response = new ApiBaseResponse<CustomerCreateResponseDto>();

        if (!await IsDtoValid(_customerCreateRequestDtoValidation, customerCreateRequestDto))
            return response;

        await _customerService.AddCustomerAsync(_mapper.Map<CustomerEntity>(customerCreateRequestDto), cancellationToken);
        return response;
    }

    public async Task<ApiBaseResponse<CustomerGetByCPFResponseDto>> GetCustomerByCPFAsync(string cpf, CancellationToken cancellationToken)
    {
        var response = new ApiBaseResponse<CustomerGetByCPFResponseDto>();

        if (string.IsNullOrWhiteSpace(cpf))
        {
            _validationNotifications.AddError("Cpf", "O cpf deve estar preenchido");
            return response;
        }

        var customer = await _customerService.GetCustomerByCPFAsync(cpf, cancellationToken);

        response.Data = new CustomerGetByCPFResponseDto()
        {
            Id = customer.Id,
            Name = customer.Name,
            Email = customer.Email
        };

        return response;
    }

    public async Task<ApiBaseResponse<CustomerGetResponseDto>> GetCustomersAsync(CancellationToken cancellationToken)
    {
        var customers = await _customerService.GetCustomersAsync(cancellationToken);

        var customerGetResponseDto = new ApiBaseResponse<CustomerGetResponseDto>()
        {
            Data = new CustomerGetResponseDto()
            {
                Customers = _mapper.Map<List<CustomerGetResponseData>>(customers)
            }
        };

        return customerGetResponseDto;
    }
}
