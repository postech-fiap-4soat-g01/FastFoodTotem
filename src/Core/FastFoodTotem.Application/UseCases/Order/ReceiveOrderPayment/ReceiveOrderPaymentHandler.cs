using AutoMapper;
using FastFoodTotem.Domain.Contracts.Repositories;
using FastFoodTotem.Domain.Entities;
using FastFoodTotem.Domain.Exceptions;
using FastFoodTotem.Domain.Validations;
using MediatR;

namespace FastFoodTotem.Application.UseCases.Order.ReceiveOrderPayment;
public class ReceiveOrderPaymentHandler : IRequestHandler<ReceiveOrderPaymentRequest, ReceiveOrderPaymentResponse>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IValidationNotifications _validationNotifications;
    private readonly IMapper _mapper;

    public ReceiveOrderPaymentHandler(
        IMapper mapper,
        IOrderRepository orderRepository,
        IValidationNotifications validationNotifications
        )
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        _validationNotifications = validationNotifications ?? throw new ArgumentNullException(nameof(validationNotifications));
    }

    public async Task<ReceiveOrderPaymentResponse> Handle(ReceiveOrderPaymentRequest request, CancellationToken cancellationToken)
    {
        var orderEntity = _mapper.Map<OrderEntity>(request);

        var existentOrder = await _orderRepository.GetOrderAsync(orderEntity.Id, cancellationToken)
                ?? throw new ObjectNotFoundException("Pedido com id inválido.");

        if (!existentOrder.ValidStatus(orderEntity.Status))
        {
            _validationNotifications.AddError("Status", "Novo status do pedido inválido");
        }
        else
        {
            existentOrder.Status = orderEntity.Status;

            await _orderRepository.EditOrderAsync(existentOrder, cancellationToken);
        }

        return _mapper.Map<ReceiveOrderPaymentResponse>(existentOrder);
    }
}
