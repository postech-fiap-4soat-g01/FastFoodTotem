using MediatR;

namespace FastFoodTotem.Application.UseCases.Order.GetOrderPaymentStatus;

public sealed record GetOrderPaymentStatusRequest(int OrderId) : IRequest<GetOrderPaymentStatusResponse>;