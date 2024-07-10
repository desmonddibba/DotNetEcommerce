using Webshop.Web.Dtos;
using Webshop.Web.Models;


namespace Webshop.Web.Service.IService
{
    public interface IProductService
    {
        //Task<ResponseDto?> GetProduct(string couponCode);
        Task<ResponseDto?> GetAllProductsAsync();
        Task<ResponseDto?> GetProductByIdAsync(int id);
        Task<ResponseDto?> CreateProductAsync(ProductDto productDto);
        Task<ResponseDto?> UpdateProductAsync(ProductDto productDto);
        Task<ResponseDto?> DeleteProductAsync(int id);
    }

}
