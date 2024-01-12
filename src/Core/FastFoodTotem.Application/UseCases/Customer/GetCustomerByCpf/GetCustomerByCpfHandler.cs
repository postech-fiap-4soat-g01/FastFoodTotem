using AutoMapper;
using FastFoodTotem.Domain.Contracts.Repositories;
using FastFoodTotem.Domain.Exceptions;
using MediatR;

namespace FastFoodTotem.Application.UseCases.Customer.GetCustomerByCpf;

public class GetCustomerByCpfHandler : IRequestHandler<GetCustomerByCpfRequest, GetCustomerByCpfResponse>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public GetCustomerByCpfHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<GetCustomerByCpfResponse> Handle(GetCustomerByCpfRequest request, CancellationToken cancellationToken)
    {
        var cpf = request.cpf.Replace(".", string.Empty).Replace("-", string.Empty);

        var customerByCpf = await _customerRepository.GetCustomerByCPFAsync(cpf, cancellationToken)
            ?? throw new ObjectNotFoundException("Usuário não encontrado para esse CPF");

        return _mapper.Map<GetCustomerByCpfResponse>(customerByCpf);
    }
}
