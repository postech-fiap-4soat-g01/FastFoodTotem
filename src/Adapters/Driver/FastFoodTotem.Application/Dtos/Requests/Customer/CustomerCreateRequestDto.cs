using FastFoodTotem.Application.DtoValidators;

namespace FastFoodTotem.Application.Dtos.Requests.Customer
{
    public struct CustomerCreateRequestDto
    {
        /// <summary>
        /// Customer name.
        /// </summary>
        /// <example>Fulano de Tal</example>
        public string CustomerName { get; set; }

        /// <summary>
        /// Customer email
        /// </summary>
        /// <example>fulano@tal.com</example>
        public string CustomerEmail { get; set; }

        /// <summary>
        /// Customer identification
        /// </summary>
        /// <example>12345678909</example>
        [Identificationvalidation(ErrorMessage = "Identification must be valid!")]
        public string CustomerIdentification { get; set; }
    }
}
