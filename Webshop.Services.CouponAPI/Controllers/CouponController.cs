using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Webshop.Services.CouponAPI.Dtos;
using Webshop.Services.CouponAPI.Interface;
using Webshop.Services.CouponAPI.Models;

namespace Webshop.Services.CouponAPI.Controllers
{
    [Route("api/coupon")]
	[ApiController]
	[Authorize]
	public class ProductController : ControllerBase
	{
		private readonly ICouponRepository _couponRepo;
		private readonly IMapper _mapper;
		private ResponseDto _response;

		public ProductController(ICouponRepository couponRepo, IMapper mapper)
		{
			_couponRepo = couponRepo;
			_mapper = mapper;
			_response = new ResponseDto();
		}

		[HttpGet]
		public async Task<ResponseDto> GetAll()
		{
			try
			{
				var coupons = await _couponRepo.GetAllAsync();

				if (coupons == null || coupons.Count == 0)
				{
					_response.IsSuccess = false;
					_response.Message = "No coupons found.";
					return _response;
				}

				_response.Result = _mapper.Map<List<CouponReadDto>>(coupons);
				_response.IsSuccess = true;
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}
			return _response;
		}

		[HttpGet("{id:int}")]
		public async Task<ResponseDto> GetById(int id)
		{
			try
			{
				var coupon = await _couponRepo.GetByIdAsync(id);
				if (coupon == null)
				{
					_response.IsSuccess = false;
					_response.Message = $"Coupon with id {id} not found.";
					return _response;
				}
				_response.Result = _mapper.Map<CouponReadDto>(coupon);
				_response.IsSuccess = true;
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}
			return _response;
		}

		[HttpGet("GetByCode/{code}")]
		public async Task<ResponseDto> GetByCode(string code)
		{
			try
			{
				var coupon = await _couponRepo.GetByCodeAsync(code);
				if (coupon == null)
				{
					_response.IsSuccess = false;
					_response.Message = $"Coupon with code {code} not found.";
					return _response;
				}
				_response.Result = _mapper.Map<CouponReadDto>(coupon);
				_response.IsSuccess = true;
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}
			return _response;
		}


		[HttpPost]
		[Authorize(Roles = "ADMIN")]
		public async Task<ResponseDto> CreateCoupon([FromBody] CouponCreateDto couponDto)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					_response.IsSuccess = false;
					_response.Message = "Invalid model state.";
					return _response;
				}

				var coupon = _mapper.Map<Coupon>(couponDto);
				await _couponRepo.CreateAsync(coupon);
				_response.Result = _mapper.Map<CouponReadDto>(coupon);
				_response.IsSuccess = true;
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}
			return _response;
		}


		[HttpDelete("{id:int}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ResponseDto> DeleteCoupon(int id)
		{
			try
			{
				var coupon = await _couponRepo.DeleteAsync(id);
				if (coupon == null)
				{
					_response.IsSuccess = false;
					_response.Message = $"Coupon with id {id} not found.";
					return _response;
				}
				_response.IsSuccess = true;
				_response.Message = "Coupon deleted successfully.";
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}
			return _response;
		}

		[HttpPut("{id:int}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ResponseDto> UpdateCoupon(int id, [FromBody] CouponUpdateDto updateDto)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					_response.IsSuccess = false;
					_response.Message = "Invalid model state.";
					return _response;
				}

				var coupon = _mapper.Map<Coupon>(updateDto);
				coupon.CouponId = id;

				var updatedCoupon = await _couponRepo.UpdateAsync(coupon);

				if (updatedCoupon == null)
				{
					_response.IsSuccess = false;
					_response.Message = $"Coupon with id {id} not found.";
					return _response;
				}

				_response.Result = _mapper.Map<CouponReadDto>(updatedCoupon);
				_response.IsSuccess = true;
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}
			return _response;
		}
	}
}
