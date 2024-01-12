using FastFoodTotem.Domain.Validations;
using FluentValidation;
using MediatR;

namespace FastFoodTotem.Application.MediatorPipes.Behavior;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
                                              where TRequest : IRequest<TResponse>
{
    private readonly IValidator<TRequest> _validator;
    private readonly IValidationNotifications _validationNotifications;

    public ValidationBehavior(IValidator<TRequest> validator, IValidationNotifications validationNotifications)
    {
        _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        _validationNotifications = validationNotifications ?? throw new ArgumentNullException(nameof(validationNotifications));
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse>
                                                next, CancellationToken cancellationToken)
    {
        if (_validator is null)
            return await next();

        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors;

            foreach (var error in errors)
            {
                _validationNotifications.AddError(error.PropertyName, error.ErrorMessage);
            }

            throw new FastFoodTotem.Domain.Exceptions.ValidationException(_validationNotifications);
        }


        return await next();
    }
}
