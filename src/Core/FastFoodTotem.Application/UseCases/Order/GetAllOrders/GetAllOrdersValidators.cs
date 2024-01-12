using FluentValidation;

namespace FastFoodTotem.Application.UseCases.Order.GetAllOrders;

public class GetAllOrdersValidators : AbstractValidator<GetAllOrdersRequest>
{
    public GetAllOrdersValidators()
    {
    }
}
