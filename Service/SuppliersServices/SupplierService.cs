using AutoMapper;
using CustomerRelationshipManagementBackend.Data;
using CustomerRelationshipManagementBackend.Model;
using CustomerRelationshipManagementBackend.ModelDto;
using CustomerRelationshipManagementBackend.Service.UserServices;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CustomerRelationshipManagementBackend.Service.SuppliersServices
{
    public class SupplierService : ISupplierService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<SupplierService> _logger;
        private readonly IUserService _userService;


        public SupplierService(ApplicationDbContext context, IMapper mapper, ILogger<SupplierService> logger, IUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _userService = userService;
        }

        public async Task<Suppliers?> AddSuppliersAsync(AddSupplierDto supplierDto)
        {
            try
            {
                if (supplierDto != null) {
                    var newSupplier = _mapper.Map<AddSupplierDto, Suppliers>(supplierDto);
                    newSupplier.IsEnabled = true;
                    newSupplier.CreatedDateTime = DateTime.Now;
                    newSupplier.UpdatedDateTime = DateTime.Now;
                    newSupplier.User = await _userService.GetUserAsync(supplierDto.UserID);

                  await _context.Suppliers.AddAsync(newSupplier);
                   await  _context.SaveChangesAsync();
                    _logger.LogInformation("supllier added successfull");
                    return newSupplier;
                }
                _logger.LogInformation("not able to add supllier");
                return null;
            }catch(Exception ex) {
                _logger.LogError(default(EventId), ex, "AddSuppliersAsync");
                throw;
            }
        }

        public async Task<string> DeleteSuppliers(int supplierId, int userId)
        {
            try
            {
                var existingSupplier = await _context.Suppliers.FindAsync(supplierId);

                if (existingSupplier != null && existingSupplier.UserID == userId)
                {
                    _context.Suppliers.Remove(existingSupplier);
                    await _context.SaveChangesAsync();

                    _logger.LogInformation("Supplier deleted successfully");

                    return "Supplier deleted successfully";
                }
                else
                {
                    _logger.LogInformation("Supplier not found or user does not have permission to delete");
                    return "Supplier not found or user does not have permission to delete";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(default(EventId), ex, "DeleteSuppliers");
                throw;
            }
        }


        

        public async Task<string> DisabledSuppliers(int supplierId, int userId)
        {
            try
            {
                var existingSupplier = await _context.Suppliers.FindAsync(supplierId);

                if (existingSupplier != null && existingSupplier.UserID == userId)
                {
                    // Soft delete: Set IsEnabled to false
                    existingSupplier.IsEnabled = false;
                    existingSupplier.UpdatedDateTime = DateTime.Now;

                    await _context.SaveChangesAsync();

                    _logger.LogInformation("Supplier disabled successfully");

                    return "Supplier disabled successfully";
                }
                else
                {
                    _logger.LogInformation("Supplier not found or user does not have permission to delete");
                    return "Supplier not found or user does not have permission to delete";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(default(EventId), ex, "DisabledSuppliers");
                throw;
            }
        }


        public async Task<IList<Suppliers>> GetAllSuppliersAsync(int page, int pageSize, string? search, int userId)
        {
            try
            {
                if (page < 1)
                {
                    throw new ArgumentException("Page number must be greater than or equal to 1.");
                }

                if (pageSize < 1)
                {
                    throw new ArgumentException("Page size must be greater than or equal to 1.");
                }

                var query = _context.Suppliers.Where(s => s.UserID == userId).AsQueryable();

                if (!string.IsNullOrWhiteSpace(search))
                {
                    query = query.Where(u => u.SupplierName.Contains(search) 
                                        || u.SupplierMobile.Contains(search));
                }

                var users = await query
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                this._logger.LogInformation($"Supplier data retrieved for page {page} with page size  and search criteria", page, pageSize, search);

                return users;
            }
            catch (Exception ex)
            {
                this._logger.LogError(default(EventId), ex, "GetAllSuppliersAsync", page, pageSize, search);
                throw;
            }
        }

        public async Task<Suppliers> GetSuppliersAsync(int supplierId, int userId)
        {
            try
            {
             var existingSupplier = await   _context.Suppliers.FirstOrDefaultAsync(s => s.SuppliesId == supplierId && s.UserID == userId);
                if (existingSupplier == null)
                {
                    _logger.LogInformation("not able to find supllier");
                    return null;
                }
                _logger.LogInformation("supllier retrived successfully");
                return existingSupplier;
            }catch (Exception ex)
            {
                this._logger.LogError(default(EventId), ex, "GetSuppliersAsync");
                throw;
            }
        }

        public async Task<Suppliers?> UpdateSuppliers(UpdateSupplierDto updatesupplierDto)
        {
            try
            {
                if (updatesupplierDto != null)
                {
                    // 1. Get the existing supplier from the database
                    var existingSupplier = await _context.Suppliers.FindAsync(updatesupplierDto.SuppliesId);

                    if (existingSupplier != null)
                    {
                        // 2. Update only non-null properties from UpdateSupplierDto to existing supplier using AutoMapper
                        _mapper.Map(updatesupplierDto, existingSupplier);

                        // 3. Set the updated DateTime
                        existingSupplier.UpdatedDateTime = DateTime.Now;

                        // 4. Save changes to the database
                        await _context.SaveChangesAsync();

                        // 5. Log success information
                        _logger.LogInformation("Supplier updated successfully");

                        // 6. Return the updated supplier
                        return existingSupplier;
                    }
                    else
                    {
                        // 7. Log a message if the supplier with the specified SuppliesId is not found
                        _logger.LogInformation("Supplier not found for update");
                        return null;
                    }
                }

                // 8. Log a message if supplierDto is null
                _logger.LogInformation("Not able to update supplier as supplierDto is null");

                // 9. Return null if supplierDto is null
                return null;
            }
            catch (Exception ex)
            {
                // 10. Log an error if an exception occurs
                _logger.LogError(default(EventId), ex, "UpdateSuppliers");

                // 11. Re-throw the exception
                throw;
            }
        }

    }
}
