using Webshop.Web.Dtos;
using Webshop.Web.Models;

namespace Webshop.Web.Service.IService
{
    public interface ICouponService
    {
        Task<ResponseDto?> GetCoupon(string couponCode);
        Task<ResponseDto?> GetAllCouponsAsync();
        Task<ResponseDto?> GetCouponByIdAsync(int id);
        Task<ResponseDto?> CreateCouponAsync(CouponDto couponDto);
        Task<ResponseDto?> UpdateCouponAsync(CouponDto couponDto);
        Task<ResponseDto?> DeleteCouponAsync(int id);
    }

}
