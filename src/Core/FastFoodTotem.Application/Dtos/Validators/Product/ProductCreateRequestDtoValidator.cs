using FastFoodTotem.Application.Dtos.Requests.Customer;
using FastFoodTotem.Application.Dtos.Requests.Product;
using FluentValidation;

namespace FastFoodTotem.Application.Dtos.Validators.Product;

public class ProductCreateRequestDtoValidator : AbstractValidator<ProductCreateRequestDto>
{
    public ProductCreateRequestDtoValidator()
    {
        RuleFor(dto => dto.Name)
            .Length(3, 255)
            .WithMessage("O nome deve ter no minimo 3 e no máximo 255 caracteres.")
            .NotEmpty()
            .WithMessage("O nome deve estar preenchido.");

        RuleFor(dto => dto.CategoryId)
            .NotEmpty()
            .WithMessage("O id da categoria deve estar preenchido.");
    }
}

