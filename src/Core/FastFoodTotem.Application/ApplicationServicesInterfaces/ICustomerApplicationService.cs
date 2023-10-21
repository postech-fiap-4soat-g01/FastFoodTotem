using FastFoodTotem.Application.Dtos.Requests.Customer;
using FastFoodTotem.Application.Dtos.Responses.Customer;

namespace FastFoodTotem.Application.ApplicationServicesInterfaces;

public interface ICustomerApplicationService
{
    Task<CustomerCreateResponseDto> AddCustomerAsync(CustomerCreateRequestDto customerCreateRequestDto, CancellationToken cancellationToken);
    Task<CustomerGetByCPFResponseDto> GetCustomerByCPFAsync(string cpf, CancellationToken cancellationToken);
    Task<CustomerGetResponseDto> GetCustomersAsync(CancellationToken cancellationToken);
}

