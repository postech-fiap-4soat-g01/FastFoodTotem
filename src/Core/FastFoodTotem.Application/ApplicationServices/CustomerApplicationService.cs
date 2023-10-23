using AutoMapper;
using FastFoodTotem.Application.ApplicationServicesInterfaces;
using FastFoodTotem.Application.Dtos.Requests.Customer;
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
    private readonly IValidationNotifications _validationNotifications;
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
        _validationNotifications = validationNotifications;
        _customerCreateRequestDtoValidation = customerCreateRequestDtoValidation;
    }

    public async Task<CustomerCreateResponseDto> AddCustomerAsync(CustomerCreateRequestDto customerCreateRequestDto, CancellationToken cancellationToken)
    {
        var response = new CustomerCreateResponseDto();

        if (!await IsDtoValid(_customerCreateRequestDtoValidation, customerCreateRequestDto))
            return response;

        await _customerService.AddCustomerAsync(_mapper.Map<CustomerEntity>(customerCreateRequestDto), cancellationToken);
        return response;
    }

    public async Task<CustomerGetByCPFResponseDto> GetCustomerByCPFAsync(string cpf, CancellationToken cancellationToken)
    {
        var response = new CustomerGetByCPFResponseDto();

        if (string.IsNullOrWhiteSpace(cpf))
        {
            _validationNotifications.AddError("Cpf", "O cpf deve estar preenchido");
            return response;
        }

        var customer = await _customerService.GetCustomerByCPFAsync(cpf, cancellationToken);

        response.Id = customer.Id;
        response.Name = customer.Name;
        response.Email = customer.Email;

        return response;
    }

    public async Task<CustomerGetResponseDto> GetCustomersAsync(CancellationToken cancellationToken)
    {
        var customers = await _customerService.GetCustomersAsync(cancellationToken);

        var customerGetResponseDto = new CustomerGetResponseDto()
        {
            Customers = _mapper.Map<List<CustomerGetResponseData>>(customers)
        };

        return customerGetResponseDto;
    }
}
