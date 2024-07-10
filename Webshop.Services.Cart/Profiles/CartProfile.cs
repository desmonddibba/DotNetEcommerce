using AutoMapper;
using Webshop.Services.CartAPI.Models;
using Webshop.Services.CartAPI.Models.Dtos;

namespace Webshop.Services.CouponAPI.Profiles
{
    public class CartProfile : Profile
    {
        public CartProfile() 
        {
            // Src -> Target

            CreateMap<CartHeader, CartHeaderDto>().ReverseMap();
            CreateMap<CartDetails, CartDetailsDto>().ReverseMap();

        }

    }
}
