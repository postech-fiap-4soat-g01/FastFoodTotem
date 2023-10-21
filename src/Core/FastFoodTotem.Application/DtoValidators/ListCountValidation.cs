using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace FastFoodTotem.Application.DtoValidators
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class ListCountValidation : ValidationAttribute
    {
        private readonly int _minCount;
        private readonly int _maxCount;

        public ListCountValidation(int minCount = 1, int maxCount = int.MaxValue)
        {
            _minCount = minCount;
            _maxCount = maxCount;
        }

        public override bool IsValid(object? value)
        {
            if (value is not IList list) return false;

            return list.Count >= _minCount && list.Count <= _maxCount;
        }
    }
}
