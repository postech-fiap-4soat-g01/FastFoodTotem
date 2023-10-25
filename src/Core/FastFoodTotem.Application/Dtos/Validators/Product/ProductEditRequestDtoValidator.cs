using FastFoodTotem.Application.Dtos.Requests.Product;
using FluentValidation;

namespace FastFoodTotem.Application.Dtos.Validators.Product;

public class ProductEditRequestDtoValidator : AbstractValidator<ProductEditRequestDto>
{
    public ProductEditRequestDtoValidator()
    {
        RuleFor(dto => dto.Id)
            .NotEmpty()
            .WithMessage("O id deve estar preenchido");

        RuleFor(dto => dto.Name)
            .Length(3, 255)
            .WithMessage("O nome deve ter no minimo 3 e no máximo 255 caracteres.")
            .NotEmpty()
            .WithMessage("O nome deve estar preenchido.");

        RuleFor(dto => dto.Type)
            .NotEmpty()
            .WithMessage("O tipo do produto deve estar preenchido.")
            .IsInEnum()
            .WithMessage("O tipo do produto especificado não é válido.");

        RuleFor(dto => dto.Price)
            .NotEmpty()
            .WithMessage("O preço do produto deve estar especificado.");
    }
}

