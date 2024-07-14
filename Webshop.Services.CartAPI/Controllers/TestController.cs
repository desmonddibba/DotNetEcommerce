using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Webshop.Services.CartAPI.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {

        [HttpGet("token")]
        public async Task<IActionResult> GetToken()
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            return Ok(new { Token = token });
        }

    }
}
