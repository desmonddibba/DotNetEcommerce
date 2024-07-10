using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using Webshop.Web.Dtos;
using Webshop.Web.Models;
using Webshop.Web.Service.IService;

namespace Webshop.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;   
        }

        [Authorize]
        public async Task<IActionResult> CartIndex()
        {
            return View(await LoadCartDtoBasedOnLoggedInUser());
        }

        public async Task<IActionResult> Remove(int cartDetailsId)
        {
            var userId = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Sub)?.FirstOrDefault()?.Value;
            ResponseDto? res = await _cartService.RemoveFromCartASync(cartDetailsId);

            if (res != null && res.IsSuccess)
            {
                TempData["Success"] = "Cart updated successfully";
                return RedirectToAction(nameof(CartIndex));
            };
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ApplyCoupon(CartDto cartDto)
        {
            ResponseDto? res = await _cartService.ApplyCouponAsync(cartDto);

            if (res != null && res.IsSuccess)
            {
                TempData["Success"] = "Coupon added successfully";
                return RedirectToAction(nameof(CartIndex));
            };
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RemoveCoupon(CartDto cartDto)
        {
            cartDto.CartHeader.CouponCode = "";
            ResponseDto? res = await _cartService.ApplyCouponAsync(cartDto);

            if (res != null && res.IsSuccess)
            {
                TempData["Success"] = "Coupon added successfully";
                return RedirectToAction(nameof(CartIndex));
            };
            return View();
        }




        private async Task<CartDto> LoadCartDtoBasedOnLoggedInUser()
        {
            var userId = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Sub)?.FirstOrDefault()?.Value;
            ResponseDto res = await _cartService.GetCartByUserIdAsync(userId);

            if(res != null && res.IsSuccess)
            {
                CartDto cartDto = JsonConvert.DeserializeObject<CartDto>(Convert.ToString(res.Result));
                return cartDto;
            };

            return new CartDto();
        }
    }
}
