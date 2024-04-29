using Microsoft.AspNetCore.Identity;

namespace AfriCar_AfriCarAPI.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string Name { get; set; }

	}
}
