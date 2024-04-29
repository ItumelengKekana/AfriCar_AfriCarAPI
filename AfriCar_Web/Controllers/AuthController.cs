using AfriCar_Utility;
using AfriCar_Web.Models.Dto;
using AfriCar_Web.Services.IServices;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using AfriCar_Web.Models;
using System.IdentityModel.Tokens.Jwt;

/* This controller contains the following action methods:
 * Login (GET) - returns the view to the login page
 * Login (POST) - allows a user to login
 * Register (GET) - returns the view to the register page
 * Register (POST) - allows a user to register
 * Logout - allows a user to log out/sign out
 * AccessDenied - returns the view to the access denied page when authorization is denied 
*/

namespace AfriCar_Web.Controllers
{
	public class AuthController : Controller
	{
		private readonly IAuthService _authService;
		public AuthController(IAuthService authService)
		{
			_authService = authService;
		}

		//GET
		[HttpGet]
		public IActionResult Login()
		{
			LoginRequestDTO obj = new();

			return View(obj);
		}

		//POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginRequestDTO obj)
		{
			APIResponse response = await _authService.LoginAsync<APIResponse>(obj);

			if (response != null && response.isSuccess)
			{
				LoginResponseDTO model = JsonConvert.DeserializeObject<LoginResponseDTO>(Convert.ToString(response.Result));

				var handler = new JwtSecurityTokenHandler();
				var jwt = handler.ReadJwtToken(model.Token);

				var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

				identity.AddClaim(new Claim(ClaimTypes.Name, jwt.Claims.FirstOrDefault(u => u.Type == "unique_name").Value));
				identity.AddClaim(new Claim(ClaimTypes.Role, jwt.Claims.FirstOrDefault(u => u.Type == "role").Value));
				var principal = new ClaimsPrincipal(identity);
				await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);


				HttpContext.Session.SetString(SD.SessionToken, model.Token);
				return RedirectToAction("Index", "Home");
			}
			else
			{
				ModelState.AddModelError("ErrorMessages", response.ErrorMessages.FirstOrDefault());
				return View(obj);
			}

		}

		//GET
		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		//POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegistrationRequestDTO obj)
		{
			APIResponse result = await _authService.RegisterAsync<APIResponse>(obj);
			if (result != null && result.isSuccess)
			{
				return RedirectToAction("Login");
			}

			return View();
		}

		//GET
		[HttpGet]
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync();
			HttpContext.Session.SetString(SD.SessionToken, "");
			return RedirectToAction("Index", "Home");
		}

		//GET
		[HttpGet]
		public IActionResult AccessDenied()
		{
			return View();
		}

	}
}
