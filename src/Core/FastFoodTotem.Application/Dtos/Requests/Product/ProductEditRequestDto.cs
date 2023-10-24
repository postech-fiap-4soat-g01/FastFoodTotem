namespace FastFoodTotem.Application.Dtos.Requests.Product
{
    public class ProductEditRequestDto : ApiBaseRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }
}
