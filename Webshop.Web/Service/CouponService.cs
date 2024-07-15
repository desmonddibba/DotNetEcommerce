using Webshop.Web.Models.Dtos;
using Webshop.Web.Models.Dtos.Coupon;
using Webshop.Web.Service.IService;
using Webshop.Web.Utility;


namespace Webshop.Web.Service
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;
        private readonly ILogger<CouponService> _logger;

        public CouponService(IBaseService baseService, ILogger<CouponService> logger)
        {
            _baseService = baseService;
            _logger = logger;
        }

        public async Task<ResponseDto?> CreateCouponAsync(CouponDto couponDto)
        {
            var response = await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = couponDto,
                Url = SD.CouponAPIBase + "/api/coupon/"
            });

            if (response == null || !response.IsSuccess)
            {
                _logger.LogError("Failed to create coupon: {Message}", response?.Message);
            }
            else
            {
                _logger.LogInformation("Coupon created successfully with code: {Code}", couponDto.CouponCode);
            }

            return response;
        }

        public async Task<ResponseDto?> DeleteCouponAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.CouponAPIBase + "/api/coupon/" + id
            });
        }

        public async Task<ResponseDto?> GetAllCouponsAsync()
        {
            _logger.LogInformation("Fetching all coupons");

            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponAPIBase + "/api/coupon"
            });


        }


        public async Task<ResponseDto?> GetCoupon(string couponCode)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponAPIBase + "/api/coupon/GetByCode/" + couponCode
            });
        }

        public async Task<ResponseDto?> GetCouponByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponAPIBase + "/api/coupon/" + id
            });
        }

        public async Task<ResponseDto?> UpdateCouponAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = couponDto,
                Url = SD.CouponAPIBase + "/api/coupon/"
            });
        }
    }
}
