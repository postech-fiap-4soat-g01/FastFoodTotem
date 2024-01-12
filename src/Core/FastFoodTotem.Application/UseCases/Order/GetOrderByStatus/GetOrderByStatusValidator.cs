using FluentValidation;

namespace FastFoodTotem.Application.UseCases.Order.GetOrderByStatus
{
    public class GetOrderByStatusValidator : AbstractValidator<GetOrderByStatusRequest>
    {
        public GetOrderByStatusValidator()
        {
            RuleFor(dto => dto.Status)
                .IsInEnum()
                .WithMessage("O status do pedido é inválido.");
        }
    }
}
