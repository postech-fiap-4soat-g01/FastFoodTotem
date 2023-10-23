namespace FastFoodTotem.Application.Dtos.Requests.Customer
{
    public class CustomerCreateRequestDto : ApiBaseRequest
    {
        /// <summary>
        /// Customer name.
        /// </summary>
        /// <example>Fulano de Tal</example>
        public string Name { get; set; }

        /// <summary>
        /// Customer email
        /// </summary>
        /// <example>fulano@tal.com</example>
        public string Email { get; set; }

        /// <summary>
        /// Customer identification
        /// </summary>
        /// <example>12345678909</example>
        public string Identification { get; set; }
    }
}
