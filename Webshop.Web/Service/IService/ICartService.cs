using Webshop.Web.Models.Dtos;
using Webshop.Web.Models.Dtos.Cart;

namespace Webshop.Web.Service.IService
{
    public interface ICartService
    {

        Task<ResponseDto?> GetCartByUserIdAsync(string userId);
        Task<ResponseDto?> UpsertCartAsync(CartDto carDto);
        Task<ResponseDto?> RemoveFromCartASync(int cartDetailsId);
        Task<ResponseDto?> ApplyCouponAsync(CartDto carDto);
        Task<ResponseDto?> EmailCart(CartDto carDto);

    }
}
