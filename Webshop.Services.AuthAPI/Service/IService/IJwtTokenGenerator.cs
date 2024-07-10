using Webshop.Services.AuthAPI.Models;

namespace Webshop.Services.AuthAPI.Service.IService
{
	public interface IJwtTokenGenerator
	{
		string GenerateToken(AppUser appUser, IEnumerable<string> roles);
	}
}
