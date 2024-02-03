using CustomerRelationshipManagementBackend.Model;

namespace CustomerRelationshipManagementBackend.Service.ProductServices
{
    public interface IProductService
    {
        public Task<Products> RegisterProductAsync();
        public Task<Products> UpdateProductAsync();
        public Task<string> DeleteProductAsync();
        public Task<IList<Products>> GetAllProducts();
        public Task<Products> GetProductsAsyncBy();
    }
}
