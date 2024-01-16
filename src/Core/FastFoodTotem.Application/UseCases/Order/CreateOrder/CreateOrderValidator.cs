using FluentValidation;

namespace FastFoodTotem.Application.UseCases.Order.CreateOrder;

public class CreateOrderValidator : AbstractValidator<CreateOrderRequest>
{
    public CreateOrderValidator()
    {
        RuleFor(dto => dto.OrderedItems)
            .NotEmpty()
            .WithMessage("O pedido precisa ter pelo menos um produto para ser criado.")
            .ForEach(item => item.SetValidator(new OrderItensValidator()));
    }
}

public class OrderItensValidator : AbstractValidator<OrderItens>
{
    public OrderItensValidator()
    {
        RuleFor(dto => dto.ProductId)
            .NotEmpty()
            .WithMessage("O id do produto precisa estar preenchido.");

        RuleFor(dto => dto.Amount)
            .GreaterThan(0)
            .WithMessage("A quantidade do produto precisa ser maior que zero.");

    }
}