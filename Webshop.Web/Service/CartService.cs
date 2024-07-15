﻿using Webshop.Web.Models.Dtos;
using Webshop.Web.Models.Dtos.Cart;
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
                Url = SD.CartAPIBase + "/api/cart/ApplyCoupon"
            });

        }

        public async Task<ResponseDto?> EmailCart(CartDto carDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = carDto,
                Url = SD.CartAPIBase + "/api/cart/EmailCart"
            });
        }

        public async Task<ResponseDto?> GetCartByUserIdAsync(string userId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Data = userId,
                Url = SD.CartAPIBase + "/api/cart/GetCart/" + userId
            });
        }

        public async Task<ResponseDto?> RemoveFromCartASync(int cartDetailsId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDetailsId,
                Url = SD.CartAPIBase + "/api/cart/RemoveCart"
            });
        }

        public async Task<ResponseDto?> UpsertCartAsync(CartDto carDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = carDto,
                Url = SD.CartAPIBase + "/api/cart/CartUpsert"
            });
        }
    }
}
