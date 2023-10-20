using FastFoodTotem.Application.Dtos.Requests.Customer;
using FastFoodTotem.Application.Dtos.Responses.Customer;

namespace FastFoodTotem.Domain.Contracts.Services
{
    public interface ICustomerService
    {
        Task AddCustomerAsync(CustomerCreateRequestDto customer, CancellationToken cancellationToken);
        Task<CustomerGetByCPFResponseDto> GetCustomerByCPFAsync(string cpf, CancellationToken cancellationToken);
        Task<IEnumerable<CustomerGetResponseDto>> GetCustomersAsync(CancellationToken cancellationToken);
    }
}
