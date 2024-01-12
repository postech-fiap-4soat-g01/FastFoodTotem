using MediatR;

namespace FastFoodTotem.Application.UseCases.Customer.GetCustomers
{
    public sealed record GetCustomersRequest : IRequest<GetCustomersResponse>
    {

    }
}
