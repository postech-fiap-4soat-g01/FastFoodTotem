using FastFoodTotem.Api.Controllers.Base;
using FastFoodTotem.Application.ApplicationServicesInterfaces;
using FastFoodTotem.Application.Dtos.Requests.Product;
using FastFoodTotem.Application.Dtos.Responses.Order;
using FastFoodTotem.Application.Dtos.Responses;
using FastFoodTotem.Domain.Enums;
using FastFoodTotem.Domain.Validations;
using Microsoft.AspNetCore.Mvc;
using FastFoodTotem.Application.Dtos.Responses.Product;

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiBaseResponse<ProductCreateResponseDto>))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(ApiBaseResponse<ProductCreateResponseDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiBaseResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiBaseResponse))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ApiBaseResponse<ProductCreateResponseDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiBaseResponse))]
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiBaseResponse<ProductEditResponseDto>))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(ApiBaseResponse<ProductEditResponseDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiBaseResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiBaseResponse))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ApiBaseResponse<ProductEditResponseDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiBaseResponse))]
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiBaseResponse<ProductDeleteResponseDto>))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(ApiBaseResponse<ProductDeleteResponseDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiBaseResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiBaseResponse))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ApiBaseResponse<ProductDeleteResponseDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiBaseResponse))]
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiBaseResponse<ProductGetByCategoryResponseDto>))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(ApiBaseResponse<ProductGetByCategoryResponseDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiBaseResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiBaseResponse))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ApiBaseResponse<ProductGetByCategoryResponseDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiBaseResponse))]
        [HttpGet("category/{type}")]
        public async Task<IActionResult> GetByCategory([FromRoute] CategoryType type, CancellationToken cancellationToken)
        {
            var productGetByCategoryResponseDto = await _productApplicationService.GetByCategoryAsync(type, cancellationToken);
            return await Return(productGetByCategoryResponseDto);
        }
    }
}
