using AutoMapper;
using Webshop.Services.CouponAPI.Dtos;
using Webshop.Services.CouponAPI.Models;

namespace Webshop.Services.CouponAPI.Profiles
{
    public class CouponProfile : Profile
    {
        public CouponProfile() 
        {
            // Src -> Target

            CreateMap<Coupon, CouponReadDto>();
            CreateMap<CouponCreateDto, Coupon>();
            CreateMap<CouponUpdateDto, Coupon>();
        
        }

    }
}
