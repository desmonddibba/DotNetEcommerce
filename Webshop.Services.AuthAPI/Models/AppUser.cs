using Microsoft.AspNetCore.Identity;

namespace Webshop.Services.AuthAPI.Models
{
	public class AppUser : IdentityUser
	{
		public string Name { get; set; } = string.Empty;
    }
}
