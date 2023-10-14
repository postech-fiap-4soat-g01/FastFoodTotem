using System.ComponentModel.DataAnnotations;

namespace FastFoodTotem.Application.DtoValidators
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class GuidNotEmpty : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is not Guid guid) return false;

            return !guid.Equals(Guid.Empty);
        }
    }
}
