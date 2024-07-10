using Microsoft.AspNetCore.Mvc;
using Webshop.Services.AuthAPI.Models.Dtos;
using Webshop.Services.AuthAPI.Service.IService;

namespace Webshop.Services.AuthAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ResponseDto _response = new ResponseDto();

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto model)
        {
            var errorMsg = await _authService.Register(model);
            if (!string.IsNullOrEmpty(errorMsg))
            {
                _response.IsSuccess = false;
                _response.Message = errorMsg;
                return BadRequest(_response);
            }
            return Ok(_response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            var loginResponse = await _authService.Login(model);
            if (loginResponse.User == null)
            {
                _response.IsSuccess = false;
                _response.Message = "Username or password is incorrect";
                return BadRequest(_response);
            }

            _response.Result = loginResponse;
            return Ok(_response);
        }

        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDto model)
        {
            var assignRoleSuccess = await _authService.AssignRole(model.Email, model.Role);
            if (!assignRoleSuccess)
            {
                _response.IsSuccess = false;
                _response.Message = "Error encountered when assigning role";
                return BadRequest(_response);
            }
            return Ok(_response);
        }
    }
}
