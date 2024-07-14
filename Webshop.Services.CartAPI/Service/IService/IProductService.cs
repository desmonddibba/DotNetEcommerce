using Webshop.Services.CartAPI.Models.Dtos;

namespace Webshop.Services.CartAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
