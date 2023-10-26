using FastFoodTotem.Application.Dtos.Requests.Order;
using FluentValidation;

namespace FastFoodTotem.Application.Dtos.Validators.Order;

public class OrderCreateRequestDtoValidator : AbstractValidator<OrderCreateRequestDto>
{
    public OrderCreateRequestDtoValidator()
    {
        RuleFor(dto => dto.OrderedItems)
            .NotEmpty()
            .WithMessage("O pedido precisa ter pelo menos um produto para ser criado.")
            .ForEach(item => item.SetValidator(new OrderItemAddRequestDtoValidator()));

        RuleFor(dto => dto.CustomerId)
            .GreaterThan(0)
            .WithMessage("O id do cliente deve ser preenchido.");
    }
}

public class OrderItemAddRequestDtoValidator : AbstractValidator<OrderItemAddRequestDto>
{
    public OrderItemAddRequestDtoValidator()
    {
        RuleFor(dto => dto.ProductId)
            .NotEmpty()
            .WithMessage("O id do pedido precisa estar preenchido.");

        RuleFor(dto => dto.Amount)
            .GreaterThan(0)
            .WithMessage("A quantidade do produto precisa ser maior que zero.");
    }
}

