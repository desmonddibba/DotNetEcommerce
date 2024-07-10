using Webshop.Web.Dtos;
using Webshop.Web.Models;

namespace Webshop.Web.Service.IService
{
    public interface ICartService
    {
 
        Task<ResponseDto?> GetCartByUserIdAsync(string userId);
        Task<ResponseDto?> UpsertCartAsync(CartDto carDto);
        Task<ResponseDto?> RemoveFromCartASync(int cartDetailsId);
        Task<ResponseDto?> ApplyCouponAsync(CartDto carDto);

    }
}
