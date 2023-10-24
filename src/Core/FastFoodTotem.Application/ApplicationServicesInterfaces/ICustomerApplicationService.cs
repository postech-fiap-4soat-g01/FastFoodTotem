using FastFoodTotem.Application.Dtos.Requests.Customer;
using FastFoodTotem.Application.Dtos.Responses;
using FastFoodTotem.Application.Dtos.Responses.Customer;

namespace FastFoodTotem.Application.ApplicationServicesInterfaces;

public interface ICustomerApplicationService
{
    Task<ApiBaseResponse<CustomerCreateResponseDto>> AddCustomerAsync(CustomerCreateRequestDto customerCreateRequestDto, CancellationToken cancellationToken);
    Task<ApiBaseResponse<CustomerGetByCPFResponseDto>> GetCustomerByCPFAsync(string cpf, CancellationToken cancellationToken);
    Task<ApiBaseResponse<CustomerGetResponseDto>> GetCustomersAsync(CancellationToken cancellationToken);
}

