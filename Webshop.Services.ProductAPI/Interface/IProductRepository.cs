using Webshop.Services.ProductAPI.Models;

namespace Webshop.Services.ProductAPI.Interface
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        //Task<Product?> GetByCodeAsync(string code);
        Task<Product> CreateAsync(Product product);
        Task<Product?> DeleteAsync(int id);
        Task<Product?> UpdateAsync(Product product);
    }
}
