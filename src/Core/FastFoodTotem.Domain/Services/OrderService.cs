using FastFoodTotem.Domain.Contracts.Repositories;
using FastFoodTotem.Domain.Contracts.Services;
using FastFoodTotem.Domain.Entities;
using FastFoodTotem.Domain.Enums;
using FastFoodTotem.Domain.Exceptions;
using FastFoodTotem.Domain.Validations;

namespace FastFoodTotem.Domain.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IValidationNotifications _validationNotifications;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;

        public OrderService(IOrderRepository orderRepository,
            IValidationNotifications validationNotifications,
            ICustomerRepository customerRepository,
            IProductRepository productRepository
            )
        {
            _orderRepository = orderRepository;
            _validationNotifications = validationNotifications;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }

        public async Task<OrderEntity> CreateAsync(OrderEntity orderEntity, CancellationToken cancellationToken)
        {
            if (orderEntity.CustomerId == 0 || !orderEntity.CustomerId.HasValue)
                orderEntity.CustomerId = null;
            else
            {
                var customer = await _customerRepository.GetCustomerByIdAsync(orderEntity.CustomerId.Value, cancellationToken);

                if (customer == null)
                    throw new ObjectNotFoundException($"Usuário com id {orderEntity.CustomerId} não foi encontrado.");
            }

            var productIds = orderEntity.OrderedItems.Select(x => x.ProductId);
            var productsNotFound = string.Empty;
            foreach (var productId in productIds)
            {
                var product = await _productRepository.GetProduct(productId, cancellationToken);
                if (product == null)
                    productsNotFound += $"{productId} - ";
            }

            if (!string.IsNullOrWhiteSpace(productsNotFound))
                throw new ObjectNotFoundException($"Os produtos {productsNotFound} não foram encontrados na base de dados.");

            await _orderRepository.AddOrderAsync(orderEntity, cancellationToken);
            return orderEntity;
        }

        public async Task UpdateAsync(OrderEntity orderEntity, CancellationToken cancellationToken)
        {
            var existentOrder = await _orderRepository.GetOrderAsync(orderEntity.Id, cancellationToken)
                ?? throw new ObjectNotFoundException("Pedido com id inválido.");

            if (!existentOrder.ValidStatus(orderEntity.Status))
            {
                _validationNotifications.AddError("Status", "Novo status do pedido inválido");
                return;
            }

            existentOrder.Status = orderEntity.Status;

            await _orderRepository.EditOrderAsync(existentOrder, cancellationToken);
        }

        public async Task<OrderEntity> GetByIdAsync(int orderId, CancellationToken cancellationToken)
        {
            var existentOrder = await _orderRepository.GetOrderAsync(orderId, cancellationToken);

            if (existentOrder == null)
                throw new ObjectNotFoundException();

            return existentOrder;
        }

        public async Task<IEnumerable<OrderEntity>> GetAllAsync(CancellationToken cancellationToken)
            => await _orderRepository.GetAllAsync(cancellationToken);

        public async Task<IEnumerable<OrderEntity>> GetOrderByStatus(OrderStatus status, CancellationToken cancellationToken)
            => await _orderRepository.GetOrderByStatus(status, cancellationToken);

        public async Task<IEnumerable<OrderEntity>> GetPendingOrders(CancellationToken cancellationToken)
            => await _orderRepository.GetPendingOrders(cancellationToken);
    }
}
