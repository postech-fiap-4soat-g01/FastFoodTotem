using FastFoodTotem.Application.UseCases.Order.GetOrderById;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodTotem.Application.UseCases.Order.GetOrderPaymentStatus;

public class GetOrderPaymentStatusValidator : AbstractValidator<GetOrderPaymentStatusRequest>
{
    public GetOrderPaymentStatusValidator() { }
}
