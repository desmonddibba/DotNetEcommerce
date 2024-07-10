﻿using Webshop.Web.Dtos;
using Webshop.Web.Models;

namespace Webshop.Web.Service.IService
{
	public interface IAuthService
	{
		Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto);
		Task<ResponseDto?> RegisterAsync(RegistrationRequestDto registrationRequestDto);
		Task<ResponseDto?> AssignRoleAsync(RegistrationRequestDto registrationRequestDto);
	} 
}