using MediatR;

namespace FastFoodTotem.Application.UseCases.Customer.CreateCustomer;

public sealed record CreateCustomerRequest(
    string Name, string Email, string Identification) :
     IRequest<CreateCustomerResponse>;
