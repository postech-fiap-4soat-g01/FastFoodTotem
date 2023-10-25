using FastFoodTotem.Application.Dtos.Requests.Order;
using FluentValidation;

namespace FastFoodTotem.Application.Dtos.Validators.Order;

public class OrderCreateRequestDtoValidator : AbstractValidator<OrderCreateRequestDto>
{
    public OrderCreateRequestDtoValidator()
    {
        RuleFor(dto => dto.Status)
            .NotEmpty()
            .WithMessage("O status inicial do pedido deve estar preenchido.")
            .IsInEnum()
            .WithMessage("O status especificado não é válido.");

        RuleFor(dto => dto.Items)
            .NotEmpty()
            .WithMessage("O pedido precisa ter pelo menos um produto para ser criado.")
            .ForEach(item => item.SetValidator(new OrderItemAddRequestDtoValidator())); ;
    }
}

public class OrderItemAddRequestDtoValidator : AbstractValidator<OrderItemAddRequestDto>
{
    public OrderItemAddRequestDtoValidator()
    {
        RuleFor(dto => dto.OrderItemId)
            .NotEmpty()
            .WithMessage("O id do pedido precisa estar preenchido.");
    }
}

