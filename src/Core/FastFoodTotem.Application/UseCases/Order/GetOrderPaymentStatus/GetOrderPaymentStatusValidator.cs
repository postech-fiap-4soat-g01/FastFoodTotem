using FluentValidation;

namespace FastFoodTotem.Application.UseCases.Order.GetOrderPaymentStatus;

public class GetOrderPaymentStatusValidator : AbstractValidator<GetOrderPaymentStatusRequest>
{
    public GetOrderPaymentStatusValidator() { }
}
