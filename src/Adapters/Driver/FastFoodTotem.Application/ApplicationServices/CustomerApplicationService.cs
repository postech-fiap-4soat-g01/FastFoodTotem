using AutoMapper;
using FastFoodTotem.Application.ApplicationServicesInterfaces;
using FastFoodTotem.Application.Dtos.Requests.Customer;
using FastFoodTotem.Application.Dtos.Responses.Customer;
using FastFoodTotem.Domain.Contracts.Services;
using FastFoodTotem.Domain.Entities;

namespace FastFoodTotem.Application.ApplicationServices;

public class CustomerApplicationService : ICustomerApplicationService
{
    private readonly IMapper _mapper;
    private readonly ICustomerService _customerService;

    public CustomerApplicationService(ICustomerService customerService, IMapper mapper)
    {
        _customerService = customerService;
        _mapper = mapper;
    }

    public async Task<CustomerCreateResponseDto> AddCustomerAsync(CustomerCreateRequestDto customerCreateRequestDto, CancellationToken cancellationToken)
    {
        await _customerService.AddCustomerAsync(_mapper.Map<CustomerEntity>(customerCreateRequestDto), cancellationToken);
        return new CustomerCreateResponseDto();
    }

    public async Task<CustomerGetByCPFResponseDto> GetCustomerByCPFAsync(string cpf, CancellationToken cancellationToken)
    {
        var customer = await _customerService.GetCustomerByCPFAsync(cpf, cancellationToken);
        return new CustomerGetByCPFResponseDto(customer.Id, customer.Name, customer.Email);
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
