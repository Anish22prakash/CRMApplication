using CustomerRelationshipManagementBackend.ModelDto;
using CustomerRelationshipManagementBackend.Service.SuppliersServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerRelationshipManagementBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpPost, Route("AddSupplier")]
        public async Task<IActionResult> AddSupplier(AddSupplierDto supplierDto)
        {
            if (!string.IsNullOrWhiteSpace(supplierDto.SupplierName) || !string.IsNullOrWhiteSpace(supplierDto.SupplierMobile))
            {

                var data = await _supplierService.AddSuppliersAsync(supplierDto);
                if (data != null)
                {
                    return Ok(new { success = true, statusCode = 200, data = data });
                }
                else
                {
                    return Ok(new { success = false, statusCode = 400, error = "Failed to add supplier" });
                }
            }
            else
            {
                return BadRequest(new { success = false, statusCode = 400, error = "Email/mobile is not valid" });
            }
        }

        [HttpGet, Route("GetAllSupplier")]
        public async Task<IActionResult> GetAllSupplier(int page = 1, int pageSize = 10, string? search = "" , int userId = 0)
        {
            if (userId > 0)
            {

                var data = await _supplierService.GetAllSuppliersAsync(page , pageSize , search , userId);
                if (data != null)
                {
                    return Ok(new { success = true, statusCode = 200, data = data });
                }
                else
                {
                    return Ok(new { success = false, statusCode = 400, error = "Failed to retrived supplier" });
                }
            }
            else
            {
                return BadRequest(new { success = false, statusCode = 400, error = "userid not valid" });
            }
        }

        [HttpGet, Route("GetSupplierById")]
        public async Task<IActionResult> GetSupplierById(int supplierId, int userId)
        {
            if (userId > 0 && supplierId > 0)
            {

                var data = await _supplierService.GetSuppliersAsync(supplierId , userId);
                if (data != null)
                {
                    return Ok(new { success = true, statusCode = 200, data = data });
                }
                else
                {
                    return Ok(new { success = false, statusCode = 400, error = "Failed to retrived supplier" });
                }
            }
            else
            {
                return BadRequest(new { success = false, statusCode = 400, error = "userid or supplier not valid" });
            }
        }

        [HttpPut, Route("UpdateSupplier")]
        public async Task<IActionResult> UpdateSupplier(UpdateSupplierDto supplierDto)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(supplierDto.SupplierName) || !string.IsNullOrWhiteSpace(supplierDto.SupplierMobile))
                {
                    var updatedSupplier = await _supplierService.UpdateSuppliers(supplierDto);

                    if (updatedSupplier != null)
                    {
                        return Ok(new { success = true, statusCode = 200, data = updatedSupplier });
                    }
                    else
                    {
                        return Ok(new { success = false, statusCode = 400, error = "Failed to update supplier. Supplier not found." });
                    }
                }
                else
                {
                    return BadRequest(new { success = false, statusCode = 400, error = "Supplier name or mobile is not valid" });
                }
            }
            catch (Exception ex)
            {
              
                return StatusCode(500, new { success = false, statusCode = 500, error = "Internal Server Error" });
            }
        }

        [HttpDelete, Route("DeleteSupplier/{supplierId}/{userId}")]
        public async Task<IActionResult> DeleteSupplier(int supplierId, int userId)
        {
            try
            {
                var deletionMessage = await _supplierService.DeleteSuppliers(supplierId, userId);

                return Ok(new { success = true, statusCode = 200, message = deletionMessage });
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, new { success = false, statusCode = 500, error = "Internal Server Error" });
            }
        }

        [HttpDelete, Route("DisableSupplier/{supplierId}/{userId}")]
        public async Task<IActionResult> DisableSupplier(int supplierId, int userId)
        {
            try
            {
                var deletionMessage = await _supplierService.DisabledSuppliers(supplierId, userId);

                return Ok(new { success = true, statusCode = 200, message = deletionMessage });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { success = false, statusCode = 500, error = "Internal Server Error" });
            }
        }

    }
}
