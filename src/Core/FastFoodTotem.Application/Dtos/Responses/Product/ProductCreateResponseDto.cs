﻿namespace FastFoodTotem.Application.Dtos.Responses.Product
{
    public class ProductCreateResponseDto : ApiBaseResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }
}
