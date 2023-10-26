using FastFoodTotem.Application.Dtos.Requests.Order;
using FluentValidation;

namespace FastFoodTotem.Application.Dtos.Validators.Order;

public class OrderUpdateRequestDtoValidator : AbstractValidator<OrderUpdateRequestDto>
{
    public OrderUpdateRequestDtoValidator()
    {
        RuleFor(dto => dto.Id)
            .GreaterThan(0)
            .WithMessage("O id pedido precisa ser maior que zero.");

        RuleFor(dto => dto.Status)
            .IsInEnum()
            .WithMessage("O status do pedido é inválido.");
    }
}

