using Microsoft.EntityFrameworkCore;
using Webshop.Services.CouponAPI.Data;
using Webshop.Services.CouponAPI.Dtos;
using Webshop.Services.CouponAPI.Interface;
using Webshop.Services.CouponAPI.Models;

namespace Webshop.Services.CouponAPI.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly AppDbContext _context;
        public CouponRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Coupon> CreateAsync(Coupon coupon)
        {
            await _context.Coupons.AddAsync(coupon);
            await _context.SaveChangesAsync();
            return coupon;
        }

        public async Task<Coupon?> DeleteAsync(int CouponId)
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync(x => x.CouponId == CouponId);

            if (coupon == null)
            {
                return null;
            }

            _context.Coupons.Remove(coupon);
            await _context.SaveChangesAsync();
            return coupon;

        }

        public async Task<List<Coupon>> GetAllAsync()
        {
            return await _context.Coupons.ToListAsync();
        }

        public async Task<Coupon?> GetByCodeAsync(string code)
        {
            return await _context.Coupons.FirstOrDefaultAsync(x => x.CouponCode.ToLower() == code.ToLower());
        }

        public async Task<Coupon?> GetByIdAsync(int CouponId)
        {
            return await _context.Coupons.FirstOrDefaultAsync(x => x.CouponId == CouponId);
        }

        public async Task<Coupon?> UpdateAsync(Coupon coupon)
        {
            var existingCoupon = await _context.Coupons.FirstOrDefaultAsync(x => x.CouponId == coupon.CouponId);
            if (existingCoupon == null)
            {
                return null;
            }

            existingCoupon.CouponCode = coupon.CouponCode;
            existingCoupon.DiscountAmount = coupon.DiscountAmount;
            existingCoupon.MinAmount = coupon.MinAmount;


            await _context.SaveChangesAsync();
            return coupon;


        }
    }
}
