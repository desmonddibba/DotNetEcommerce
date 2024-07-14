using Webshop.Services.CartAPI.Models.Dtos;

namespace Webshop.Services.CartAPI.Service.IService
{
    public interface ICouponService
    {
        Task<CouponDto> GetCoupon(string couponCode);
    }
}
