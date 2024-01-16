using FluentValidation;

namespace FastFoodTotem.Application.UseCases.Order.GetPendingOrders;

public class GetPendingOrdersValidator : AbstractValidator<GetPendingOrdersRequest>
{
    public GetPendingOrdersValidator()
    {

    }
}
