using Newtonsoft.Json;
using Webshop.Services.CartAPI.Models.Dtos;
using Webshop.Services.CartAPI.Service.IService;

namespace Webshop.Services.CartAPI.Service
{
    public class CouponService : ICouponService
    {
        private readonly IHttpClientFactory _http;
        public CouponService(IHttpClientFactory http)
        {
            _http = http;
        }


        public async Task<CouponDto> GetCoupon(string couponCode)
        {
            var client = _http.CreateClient("Coupon");
            var httpResponse = await client.GetAsync($"/api/coupon/GetByCode/{couponCode}");
            var apiContent = await httpResponse.Content.ReadAsStringAsync();

            var res = JsonConvert.DeserializeObject<ResponseDto>(apiContent);

            if (res!= null && res.IsSuccess)
            {
                return JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(res.Result));
            }
            return new CouponDto();
        }
    }
}
