using FastFoodTotem.Api.Controllers.Base;
using FastFoodTotem.Application.ApplicationServicesInterfaces;
using FastFoodTotem.Application.Dtos.Requests.Product;
using FastFoodTotem.Domain.Contracts.Services;
using FastFoodTotem.Domain.Enums;
using FastFoodTotem.Domain.Validations;
using Microsoft.AspNetCore.Mvc;

namespace FastFoodTotem.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{ver:apiVersion}/product")]
    [Produces("application/json")]
    public class ProductController : BaseController
    {
        private readonly IProductApplicationService _productApplicationService;

        public ProductController(IProductApplicationService productApplicationService, IValidationNotifications validationNotifications)
            : base(validationNotifications)
        {
            _productApplicationService = productApplicationService;
        }

        /// <summary>
        /// Create a new product.
        /// </summary>
        /// <param name="productCreateRequestDto"></param>
        /// <param name="cancellationToken"></param>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCreateRequestDto productCreateRequestDto, CancellationToken cancellationToken)
        {
            var productCreateResponseDto = await _productApplicationService.CreateAsync(productCreateRequestDto, cancellationToken);
            return await Return(productCreateResponseDto);
        }

        /// <summary>
        /// Edit a product.
        /// </summary>
        /// <param name="productEditRequestDto"></param>
        /// <param name="cancellationToken"></param>
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] ProductEditRequestDto productEditRequestDto, CancellationToken cancellationToken)
        {
            var productEditResponseDto = await _productApplicationService.EditAsync(productEditRequestDto, cancellationToken);
            return await Return(productEditResponseDto);
        }

        /// <summary>
        /// Delete a product.
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="cancellationToken"></param>
        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete([FromRoute] int productId, CancellationToken cancellationToken)
        {
            var productDeleteResponseDto = await _productApplicationService.DeleteAsync(productId, cancellationToken);
            return await Return(productDeleteResponseDto);
        }

        /// <summary>
        /// Retrieve a list of products by category.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="cancellationToken"></param>
        [HttpGet("category/{type}")]
        public async Task<IActionResult> GetByCategory([FromRoute] CategoryType type, CancellationToken cancellationToken)
        {
            var productGetByCategoryResponseDto = await _productApplicationService.GetByCategoryAsync(type, cancellationToken);
            return await Return(productGetByCategoryResponseDto);
        }
    }
}
