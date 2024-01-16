using AutoMapper;
using FastFoodTotem.Domain.Contracts.Repositories;
using FastFoodTotem.Domain.Entities;
using FastFoodTotem.Domain.Validations;
using MediatR;

namespace FastFoodTotem.Application.UseCases.Customer.CreateCustomer;

public class CreateCustomerHandler : IRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    private readonly IValidationNotifications _validationNotifications;

    public CreateCustomerHandler(ICustomerRepository customerRepository, IMapper mapper, IValidationNotifications validationNotifications)
    {
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _validationNotifications = validationNotifications ?? throw new ArgumentNullException(nameof(validationNotifications));
    }

    public async Task<CreateCustomerResponse> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        var customer = _mapper.Map<CustomerEntity>(request);

        var existingCustomer = await _customerRepository.GetCustomerByCPFAsync(customer.Identification, cancellationToken);

        if (existingCustomer != null)
            _validationNotifications.AddError("Identification", "Já existe um usuário cadastrado com esse CPF.");
        else
        {
            customer.Identification = customer.Identification.Replace(".", string.Empty).Replace("-", string.Empty);
            await _customerRepository.AddCustomerAsync(customer, cancellationToken);
        }

        return new CreateCustomerResponse();
    }
}
