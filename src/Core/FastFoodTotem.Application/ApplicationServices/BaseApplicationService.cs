using Azure;
using FastFoodTotem.Application.Dtos.Requests;
using FastFoodTotem.Domain.Validations;
using FluentValidation;

namespace FastFoodTotem.Application.ApplicationServices;

public abstract class BaseApplicationService
{
    protected readonly IValidationNotifications _validationNotifications;

    public BaseApplicationService(IValidationNotifications validationNotifications)
    {
        _validationNotifications = validationNotifications;
    }

    protected async Task<bool> IsDtoValid<T>(IValidator<T> validator, T apiBaseRequest)
    {
        var validationResult = await validator.ValidateAsync(apiBaseRequest);

        if (!validationResult.IsValid)
        {
            foreach (var error in validationResult.Errors)
                _validationNotifications.AddError(error.PropertyName, error.ErrorMessage);
        }

        return validationResult.IsValid;
    }
}

