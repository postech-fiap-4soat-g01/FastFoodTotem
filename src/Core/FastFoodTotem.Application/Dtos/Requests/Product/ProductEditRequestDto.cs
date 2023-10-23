namespace FastFoodTotem.Application.Dtos.Requests.Product
{
    public class ProductEditRequestDto : ApiBaseRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
    }
}
