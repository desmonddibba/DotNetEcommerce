namespace Webshop.Web.Models.Dtos.Authorization
{
    public class LoginResponseDto
    {
        public UserDto User { get; set; }
        public string Token { get; set; }
    }
}
