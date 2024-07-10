﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Webshop.Web.Dtos;
using Webshop.Web.Models;
using Webshop.Web.Service.IService;
using Webshop.Web.Utility;

namespace Webshop.Web.Controllers
{
	public class AuthController : Controller
	{
		private readonly IAuthService _authservice;
        private readonly ITokenProvider _tokenprovider;

		public AuthController(IAuthService authService, ITokenProvider tokenProvider)
        {
			_authservice = authService;
            _tokenprovider = tokenProvider;
        }

		[HttpGet]
		public IActionResult Login()
		{
			LoginRequestDto loginRequestDto = new();
			return View(loginRequestDto);
		}
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDto loginReq)
        {
            ResponseDto response = await _authservice.LoginAsync(loginReq);

            if (response != null && response.IsSuccess)
            {
                LoginResponseDto loginResponse = JsonConvert.DeserializeObject<LoginResponseDto>(Convert.ToString(response.Result));

                // Set Jwt Token
                await SignInUser(loginResponse);
                _tokenprovider.SetToken(loginResponse.Token);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("CustomError", response.Message);
                return View(loginReq);
            }
        }






        [HttpGet]
		public IActionResult Register()
		{
			var roleList = new List<SelectListItem>()
			{
				new SelectListItem{Text=SD.RoleAdmin, Value=SD.RoleAdmin},
                new SelectListItem{Text=SD.RoleCustomer, Value=SD.RoleCustomer}
            };
			ViewBag.RoleList = roleList;
			return View();
		}

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationRequestDto regRequest)
        {
			ResponseDto response = await _authservice.RegisterAsync(regRequest);
			ResponseDto assignRole;
		
			if(response != null && response.IsSuccess)
			{
				if(string.IsNullOrEmpty(regRequest.Role))
				{
					regRequest.Role = SD.RoleCustomer;
                }
                assignRole = await _authservice.AssignRoleAsync(regRequest);

				if(assignRole != null && assignRole.IsSuccess)
				{
					TempData["success"] = "Registration Successful";
					return RedirectToAction(nameof(Login));
				}
            }
            else
            {
                TempData["error"] = response.Message;
            }

            var roleList = new List<SelectListItem>()
            {
                new SelectListItem{Text=SD.RoleAdmin, Value=SD.RoleAdmin},
                new SelectListItem{Text=SD.RoleCustomer, Value=SD.RoleCustomer}
            };
            ViewBag.RoleList = roleList;
            return View(regRequest);
       }







        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            _tokenprovider.ClearToken();
            return RedirectToAction("Index", "Home");
        }


        private async Task SignInUser(LoginResponseDto loginResponse)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(loginResponse.Token);

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Email, 
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Sub).Value));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Name,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Name).Value));


            identity.AddClaim(new Claim(ClaimTypes.Name,
                     jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));

            identity.AddClaim(new Claim(ClaimTypes.Role,
                    jwt.Claims.FirstOrDefault(u => u.Type == "role").Value));

            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }
    }
}