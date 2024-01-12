using FluentValidation;

namespace FastFoodTotem.Application.UseCases.Order.UpdateOrder;

public class UpdateOrderValidator : AbstractValidator<UpdateOrderRequest>
{
    public UpdateOrderValidator()
    {
        RuleFor(dto => dto.Id)
            .GreaterThan(0)
            .WithMessage("O id pedido precisa ser maior que zero.");

        RuleFor(dto => dto.Status)
            .IsInEnum()
            .WithMessage("O status do pedido é inválido.");
    }
}
