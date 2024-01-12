using FluentValidation;

namespace FastFoodTotem.Application.UseCases.Product.CreateProduct;

public class CreateProductValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductValidator()
    {
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

        RuleFor(dto => dto.Description)
            .Length(3, 255)
            .WithMessage("A descrição do produto deve ter no minimo 3 e no máximo 255 caracteres.")
            .NotEmpty()
            .WithMessage("O descrição do produto deve estar preenchido.");

        RuleFor(dto => dto.ProductImageUrl)
            .NotEmpty()
            .WithMessage("A imagem do produto deve estar preenchida.");
    }
}
