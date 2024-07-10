using Webshop.Web.Dtos;
using Webshop.Web.Models;
using Webshop.Web.Service.IService;
using Webshop.Web.Utility;

namespace Webshop.Web.Service
{
    public class CartService : ICartService
    {
        private readonly IBaseService _baseService;

        public CartService(IBaseService baseService)
        {
            _baseService = baseService;
        }




        public async Task<ResponseDto?> ApplyCouponAsync(CartDto carDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = carDto,
                Url = SD.CouponAPIBase + "/api/cart/ApplyCoupon"
            });

        }

        public async Task<ResponseDto?> GetCartByUserIdAsync(string userId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Data = userId,
                Url = SD.CouponAPIBase + "/api/cart/GetCart/" +userId
            }); 
        }

        public async Task<ResponseDto?> RemovFromCartASync(int cartDetailsId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDetailsId,
                Url = SD.CouponAPIBase + "/api/cart/RemoveCart"
            });
        }

        public async Task<ResponseDto?> UpsertCartAsync(CartDto carDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = carDto,
                Url = SD.CouponAPIBase + "/api/cart/CartUpsert"
            });
        }
    }
}
