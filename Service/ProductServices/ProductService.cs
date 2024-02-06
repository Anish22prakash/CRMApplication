using AutoMapper;
using CustomerRelationshipManagementBackend.Data;
using CustomerRelationshipManagementBackend.Model;
using CustomerRelationshipManagementBackend.ModelDto;
using CustomerRelationshipManagementBackend.Service.SuppliersServices;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CustomerRelationshipManagementBackend.Service.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<SupplierService> _logger;
        private readonly ISupplierService _supplierService;
        private readonly IWebHostEnvironment _environment;


        public ProductService(ApplicationDbContext context, IMapper mapper, ILogger<SupplierService> logger, 
            ISupplierService supplierService, IWebHostEnvironment environment)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _supplierService = supplierService;
            _environment = environment;
        }

     

        public async Task<IList<object>> GetAllProducts(int userId ,int page , int pageSize , string search)
        {
            try
            {
                var query = _context.Products
                                .Include(p => p.Supplier)
                                .Where(p => p.Supplier.UserID == userId)
                           .Select(p => new
                           {
                               p.ProductId,
                               p.ProductName,
                               p.ProductUniqueCode,
                               p.ProductPicUrl,
                               p.Quantity,
                               p.ProductPrice
                           });


                if (!string.IsNullOrWhiteSpace(search))
                {
                    query = query.Where(p =>
                        p.ProductName.Contains(search) ||
                        p.ProductUniqueCode.Contains(search));
                }

                query = query.Skip((page - 1) * pageSize)
                             .Take(pageSize);

                var products = await query.ToListAsync();
                _logger.LogInformation("All product retrived successfully");
                return products.Cast<object>().ToList();
            }
            catch (Exception ex)
            {
                this._logger.LogError(default(EventId), ex, "GetAllProducts");
                throw;
            }
            
        }

        public async Task<ReturnProductDto> GetProductsAsyncById(int productId)
        {
            try
            {
              var existingProduct = await _context.Products
                .Include(p => p.Supplier) 
                .FirstOrDefaultAsync(p => p.ProductId == productId);

                if (existingProduct == null)
                {
                    _logger.LogInformation("product not found");
                    return null;
                }
                var productWithSupplierNameDTO = new ReturnProductDto
                {
                    ProductId = existingProduct.ProductId,
                    ProductName = existingProduct.ProductName,
                    ProductDescription = existingProduct.ProductDescription,
                    ProductUniqueCode = existingProduct.ProductUniqueCode,
                    ProductPicUrl = existingProduct.ProductPicUrl,
                    Quantity = existingProduct.Quantity,
                    ProductPrice = existingProduct.ProductPrice,
                    SupplierName = existingProduct.Supplier?.SupplierName,
                    SupplierMobile = existingProduct.Supplier?.SupplierMobile

                };
                _logger.LogInformation("product data retrived");
                return productWithSupplierNameDTO;
            }catch (Exception ex)
            {
                this._logger.LogError(default(EventId), ex, "GetAllProducts");
                throw;
            }
        }

        public async Task<AddProductDto> RegisterProductAsync(AddProductDto productDto)
        {
            try
            {
                var newProduct = _mapper.Map<AddProductDto, Products>(productDto);
                newProduct.CreatedDateTime = DateTime.Now;
                newProduct.UpdatedDateTime = DateTime.Now;
                newProduct.IsEnabled = true;
                newProduct.Supplier = await _context.Suppliers.FirstOrDefaultAsync(u => u.SuppliesId == productDto.SuppliesId);

                if(productDto.ProductImage != null)
                {
                    string ProductImgfolder = "Product";

                    ProductImgfolder += Guid.NewGuid().ToString().Substring(0, 5);

                    string serverFilePath = Path.Combine(_environment.ContentRootPath, "CRMImages", ProductImgfolder);
                    if (!Directory.Exists(Path.GetDirectoryName(serverFilePath)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(serverFilePath));
                    }
                    using (var stream = new FileStream(serverFilePath, FileMode.Create))
                    {
                        productDto.ProductImage.CopyTo(stream);
                    }
                    newProduct.ProductPicUrl = $"/CRMImages/{ProductImgfolder}";
                }

                productDto = _mapper.Map<Products, AddProductDto>(newProduct);
               await _context.Products.AddAsync(newProduct);
                await _context.SaveChangesAsync();
                _logger.LogInformation("product is succssfully added");
                return productDto;

            }catch (Exception ex)
            {
                this._logger.LogError(default(EventId), ex, "RegisterProductAsync");
                throw;
            }
        }

        public async Task<UpdateProductDto> UpdateProductAsync(UpdateProductDto productDto)
        {
            try
            {
                var existingProduct = await _context.Products
                    .FirstOrDefaultAsync(p => p.ProductId == productDto.ProductId);

                if (existingProduct == null)
                {
                    _logger.LogInformation("Product not found");
                    return null;
                }

                // Update only the specified fields
                existingProduct.ProductName = productDto.ProductName ?? existingProduct.ProductName;
                existingProduct.ProductDescription = productDto.ProductDescription ?? existingProduct.ProductDescription;
                existingProduct.Quantity = productDto.Quantity ?? existingProduct.Quantity;
                existingProduct.ProductPrice = productDto.ProductPrice ?? existingProduct.ProductPrice;

                if (productDto.ProductImage != null)
                {
                    // Update image logic here
                    string ProductImgfolder = "Product";

                    ProductImgfolder += Guid.NewGuid().ToString().Substring(0, 5);

                    string serverFilePath = Path.Combine(_environment.ContentRootPath, "CRMImages", ProductImgfolder);
                    if (!Directory.Exists(Path.GetDirectoryName(serverFilePath)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(serverFilePath));
                    }

                    // Remove the old image file if it exists
                    if (!string.IsNullOrEmpty(existingProduct.ProductPicUrl))
                    {
                        string oldImagePath = Path.Combine(_environment.ContentRootPath, existingProduct.ProductPicUrl.TrimStart('/'));
                        if (File.Exists(oldImagePath))
                        {
                            File.Delete(oldImagePath);
                        }
                    }

                    // Save the new image
                    using (var stream = new FileStream(serverFilePath, FileMode.Create))
                    {
                        productDto.ProductImage.CopyTo(stream);
                    }

                    existingProduct.ProductPicUrl = $"/CRMImages/{ProductImgfolder}";
                }

                existingProduct.UpdatedDateTime = DateTime.Now;
                _context.Update(existingProduct);
                await _context.SaveChangesAsync();

                var updatedProductDto = _mapper.Map<Products, UpdateProductDto>(existingProduct);
                return updatedProductDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(default(EventId), ex, "UpdateProductAsync");
                throw;
            }
        }
        public async Task<string> DeleteProductAsync(int productId)
        {
            try
            {
                var existingProduct = await _context.Products
                    .FirstOrDefaultAsync(p => p.ProductId == productId);

                if (existingProduct == null)
                {
                    _logger.LogInformation("Product not found");
                    return null;
                }

                // Remove the product
                _context.Products.Remove(existingProduct);

                // Save changes
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Product deleted successfully: {productId}");
                return "Product deleted successfully";
            }
            catch (Exception ex)
            {
                _logger.LogError(default(EventId), ex, "DeleteProductAsync");
                throw;
            }
        }
    }
}
