using AutoMapper;
using Webshop.Services.CouponAPI.Models;
using Webshop.Services.CouponAPI.Models.Dtos;

namespace Webshop.Services.CouponAPI.Profiles
{
    public class CouponProfile : Profile
    {
        public CouponProfile() 
        {
            // Src -> Target

            CreateMap<Coupon, CouponDto>().ReverseMap();
        
        }

    }
}
