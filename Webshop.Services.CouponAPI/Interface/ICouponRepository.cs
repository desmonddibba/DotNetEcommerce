using Webshop.Services.CouponAPI.Models.Dtos;

namespace Webshop.Services.CouponAPI.Interface
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCouponByCode(string couponCode);
        Task<CouponDto> CreateUpdateCoupon(CouponDto couponDto);
        Task<bool> DeleteCoupon(int couponId);
    }
}
