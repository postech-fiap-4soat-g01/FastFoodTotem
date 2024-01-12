using FluentValidation;

namespace FastFoodTotem.Application.UseCases.Order.GetOrderById;

public class GetOrderByIdValidator : AbstractValidator<GetOrderByIdRequest>
{
    public GetOrderByIdValidator() { }
}
