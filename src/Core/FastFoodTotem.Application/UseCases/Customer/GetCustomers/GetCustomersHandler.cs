using AutoMapper;
using FastFoodTotem.Domain.Contracts.Repositories;
using MediatR;

namespace FastFoodTotem.Application.UseCases.Customer.GetCustomers
{
    public class GetCustomersHandler : IRequestHandler<GetCustomersRequest, GetCustomersResponse>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomersHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GetCustomersResponse> Handle(GetCustomersRequest request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetCustomersAsync(cancellationToken);

            var customersDto = _mapper.Map<IEnumerable<Customers>>(customers);

            return new GetCustomersResponse() { Customers = customersDto };
        }
    }
}
