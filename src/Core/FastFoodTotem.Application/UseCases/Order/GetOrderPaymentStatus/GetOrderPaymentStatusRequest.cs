using FastFoodTotem.Application.UseCases.Order.GetOrderById;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodTotem.Application.UseCases.Order.GetOrderPaymentStatus;

public sealed record GetOrderPaymentStatusRequest(int OrderId) : IRequest<GetOrderPaymentStatusResponse>;