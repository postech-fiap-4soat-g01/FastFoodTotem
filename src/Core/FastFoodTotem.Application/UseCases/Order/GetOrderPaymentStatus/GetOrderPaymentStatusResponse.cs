using FastFoodTotem.Application.UseCases.Order.GetOrderById;
using FastFoodTotem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodTotem.Application.UseCases.Order.GetOrderPaymentStatus;

public sealed record GetOrderPaymentStatusResponse
{
    public int Id { get; set; }
    public PaymentStatus Status { get; set; }
}
