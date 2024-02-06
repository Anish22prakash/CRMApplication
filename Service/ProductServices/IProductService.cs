using CustomerRelationshipManagementBackend.Model;
using CustomerRelationshipManagementBackend.ModelDto;

namespace CustomerRelationshipManagementBackend.Service.ProductServices
{
    public interface IProductService
    {
        public Task<AddProductDto> RegisterProductAsync(AddProductDto productDto);
        public Task<UpdateProductDto> UpdateProductAsync(UpdateProductDto productDto);
        public Task<string> DeleteProductAsync(int productId);
        public Task<IList<object>> GetAllProducts(int userId, int page, int pageSize, string search);
        public Task<ReturnProductDto> GetProductsAsyncById(int productId);
    }
}
