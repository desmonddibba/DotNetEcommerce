using AutoMapper;
using Webshop.Services.CouponAPI.Data;
using Webshop.Services.CouponAPI.Models;
using Webshop.Services.CouponAPI.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using Webshop.Services.CouponAPI.Interface;

namespace Webshop.Services.CouponAPI.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly AppDbContext _db;
        private IMapper _mapper;

        public CouponRepository(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<CouponDto> GetCouponByCode(string couponCode)
        {
            var coupon = await _db.Coupons.FirstOrDefaultAsync(c => c.CouponCode == couponCode);
            return _mapper.Map<CouponDto>(coupon);
        }

        public async Task<CouponDto> CreateUpdateCoupon(CouponDto couponDto)
        {
            var coupon = _mapper.Map<Coupon>(couponDto);
            if (coupon.CouponId > 0)
            {
                _db.Coupons.Update(coupon);
            }
            else
            {
                _db.Coupons.Add(coupon);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<CouponDto>(coupon);
        }

        public async Task<bool> DeleteCoupon(int couponId)
        {
            try
            {
                var coupon = await _db.Coupons.FirstOrDefaultAsync(c => c.CouponId == couponId);
                if (coupon == null)
                {
                    return false;
                }
                _db.Coupons.Remove(coupon);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
