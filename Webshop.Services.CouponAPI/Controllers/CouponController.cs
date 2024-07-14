using Microsoft.AspNetCore.Mvc;
using Webshop.Services.CouponAPI.Interface;
using Webshop.Services.CouponAPI.Models.Dtos;
using Webshop.Services.CouponAPI.Repository;

namespace Webshop.Services.CouponAPI.Controllers
{
    [Route("api/coupon")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly ICouponRepository _couponRepository;
        protected ResponseDto _response;

        public CouponController(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
            _response = new ResponseDto();
        }

        [HttpGet("GetByCode/{code}")]
        public async Task<object> GetByCode(string code)
        {
            try
            {
                var coupon = await _couponRepository.GetCouponByCode(code);
                _response.Result = coupon;
                _response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        public async Task<object> CreateCoupon([FromBody] CouponDto couponDto)
        {
            try
            {
                var coupon = await _couponRepository.CreateUpdateCoupon(couponDto);
                _response.Result = coupon;
                _response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpPut]
        public async Task<object> UpdateCoupon([FromBody] CouponDto couponDto)
        {
            try
            {
                var coupon = await _couponRepository.CreateUpdateCoupon(couponDto);
                _response.Result = coupon;
                _response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id}")]
        public async Task<object> DeleteCoupon(int id)
        {
            try
            {
                var isDeleted = await _couponRepository.DeleteCoupon(id);
                _response.Result = isDeleted;
                _response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }
    }
}
