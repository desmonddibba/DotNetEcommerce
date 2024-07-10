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


       //[Authorize]
        public async Task<IActionResult> CartIndex()
        {
            return View();
        }


        private async Task<CartDto> LoadCartDtoBasedOnLoggedInUser()
        {
            var userId = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Sub)?.FirstOrDefault()?.Value;
            ResponseDto res = await _cartService.GetCartByUserIdAsync(userId);

            if(res!= null && res.IsSuccess)
            {
                CartDto cartDto = JsonConvert.DeserializeObject<CartDto>(Convert.ToString(res.Result));
            };

            return new CartDto();
        }
    }
}
