using FastFoodTotem.Api.Controllers.Base;
using FastFoodTotem.Application.Dtos.Requests.Product;
using Microsoft.AspNetCore.Mvc;

namespace FastFoodTotem.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{ver:apiVersion}/product")]
    [Produces("application/json")]
    public class ProductController : BaseController
    {
        // <summary>
        /// Create a new product.
        /// </summary>
        /// <param name="productCreateRequestDto"></param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST
        ///     {
        ///        
        ///     }
        ///
        /// </remarks>
        /// <returns>Id of the new product created</returns>
        /// <response code="200">Request was processed sucessfully</response>
        /// <response code="400">Body in the request was wrong.</response>
        /// <response code="500">Internal server error</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateOrder([FromBody] ProductCreateRequestDto productCreateRequestDto, CancellationToken cancellationToken)
        => await Task.FromResult(Ok());
    }
}
