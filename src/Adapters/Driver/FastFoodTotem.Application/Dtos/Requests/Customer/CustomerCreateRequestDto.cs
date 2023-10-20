using FastFoodTotem.Application.DtoValidators;
using System.ComponentModel.DataAnnotations;

namespace FastFoodTotem.Application.Dtos.Requests.Customer
{
    public struct CustomerCreateRequestDto
    {
        /// <summary>
        /// Customer name.
        /// </summary>
        /// <example>Fulano de Tal</example>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Customer email
        /// </summary>
        /// <example>fulano@tal.com</example>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Customer identification
        /// </summary>
        /// <example>12345678909</example>
        [Required]
        [Identificationvalidation(ErrorMessage = "Identification must be valid!")]
        public string Identification { get; set; }
    }
}
