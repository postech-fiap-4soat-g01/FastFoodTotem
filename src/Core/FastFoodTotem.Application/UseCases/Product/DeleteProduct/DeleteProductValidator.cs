using FluentValidation;

namespace FastFoodTotem.Application.UseCases.Product.DeleteProduct;

public class DeleteProductValidator : AbstractValidator<DeleteProductRequest>
{
    public DeleteProductValidator()
    {

    }
}
