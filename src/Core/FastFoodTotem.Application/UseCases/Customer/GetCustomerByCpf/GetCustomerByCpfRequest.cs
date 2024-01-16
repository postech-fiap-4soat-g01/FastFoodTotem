using MediatR;

namespace FastFoodTotem.Application.UseCases.Customer.GetCustomerByCpf;

public sealed record GetCustomerByCpfRequest(string cpf) :
 IRequest<GetCustomerByCpfResponse>;
