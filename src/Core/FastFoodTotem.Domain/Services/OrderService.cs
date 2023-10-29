using FastFoodTotem.Domain.Contracts.Repositories;
using FastFoodTotem.Domain.Contracts.Services;
using FastFoodTotem.Domain.Entities;
using FastFoodTotem.Domain.Enums;
using FastFoodTotem.Domain.Exceptions;
using FastFoodTotem.Domain.Validations;
using System.Threading;

namespace FastFoodTotem.Domain.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IValidationNotifications _validationNotifications;

        public OrderService(IOrderRepository orderRepository,
            IValidationNotifications validationNotifications)
        {
            _orderRepository = orderRepository;
            _validationNotifications = validationNotifications;
        }

        public async Task<OrderEntity> CreateAsync(OrderEntity orderEntity, CancellationToken cancellationToken)
        {
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
    }
}
