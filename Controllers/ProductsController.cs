using CustomerRelationshipManagementBackend.Model;
using CustomerRelationshipManagementBackend.ModelDto;
using CustomerRelationshipManagementBackend.Service.ProductServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomerRelationshipManagementBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost, Route("AddProduct")]
        [Consumes("multipart/form-data")]
        [RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = int.MaxValue)]
        public async Task<IActionResult> AddProduct([FromForm] AddProductDto productDto)
        {
            if (!string.IsNullOrWhiteSpace(productDto.ProductName) || !string.IsNullOrWhiteSpace(productDto.ProductUniqueCode))
            {

                var data = await _productService.RegisterProductAsync(productDto);
                if (data != null)
                {
                    return Ok(new { success = true, statusCode = 200, data = data });
                }
                else
                {
                    return Ok(new { success = false, statusCode = 400, error = "Failed to add product" });
                }
            }
            else
            {
                return BadRequest(new { success = false, statusCode = 400, error = "product name/unique code is not valid" });
            }
        }

        [HttpGet, Route("GetAllUserByFilter")]
        public async Task<IActionResult> GetAllUserByFilter(int userId =0 ,int page = 1, int pageSize = 10, string? search = "")
        {
            try
            {
                var data = await _productService.GetAllProducts(userId,page, pageSize, search);
                if (data.Count > 0)
                {
                    return Ok(new { success = true, statusCode = 200, data = data });
                }
                else
                {
                    return Ok(new { success = false, statusCode = 400, error = "product not found" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, statusCode = 400, error = "Invalid input", details = ex.Message });
            }
        }

        [HttpGet, Route("GetProductAsync")]
        public async Task<IActionResult> GetProductAsync(int productId)
        {
            try
            {
                var data = await _productService.GetProductsAsyncById(productId);
                if (data != null)
                {
                    return Ok(new { success = true, statusCode = 200, data = data });
                }
                else
                {
                    return Ok(new { success = false, statusCode = 400, error = "product not found" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, statusCode = 400, error = "Invalid input", details = ex.Message });
            }
        }

        [HttpPut, Route("UpdateProduct")]
        [Consumes("multipart/form-data")]
        [RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = int.MaxValue)]
        public async Task<IActionResult> UpdateProduct([FromForm] UpdateProductDto productDto)
        {
            if (productDto.ProductId.HasValue && productDto.ProductId > 0)
            {
                var data = await _productService.UpdateProductAsync(productDto);
                if (data != null)
                {
                    return Ok(new { success = true, statusCode = 200, data = data });
                }
                else
                {
                    return Ok(new { success = false, statusCode = 400, error = "Failed to update product" });
                }
            }
            else
            {
                return BadRequest(new { success = false, statusCode = 400, error = "Invalid product ID" });
            }
        }

        [HttpDelete, Route("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            if (productId > 0)
            {
                var result = await _productService.DeleteProductAsync(productId);
                if (result != null)
                {
                    return Ok(new { success = true, statusCode = 200, message = result });
                }
                else
                {
                    return Ok(new { success = false, statusCode = 400, error = "Failed to delete product" });
                }
            }
            else
            {
                return BadRequest(new { success = false, statusCode = 400, error = "Invalid product ID" });
            }
        }


    }
}
