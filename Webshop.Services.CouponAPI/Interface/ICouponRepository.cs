using Webshop.Services.CouponAPI.Dtos;
using Webshop.Services.CouponAPI.Models;

namespace Webshop.Services.CouponAPI.Interface
{
    public interface ICouponRepository
    {
        Task<List<Coupon>> GetAllAsync();
        Task<Coupon?> GetByIdAsync(int id);
        Task<Coupon?> GetByCodeAsync(string code);
        Task<Coupon> CreateAsync(Coupon coupon);
        Task<Coupon?> DeleteAsync(int id);
        Task<Coupon?> UpdateAsync(Coupon coupon);
    }
}
