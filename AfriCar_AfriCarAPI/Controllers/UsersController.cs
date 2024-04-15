using AfriCar_AfriCarAPI.Models;
using AfriCar_AfriCarAPI.Models.Dto;
using AfriCar_AfriCarAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AfriCar_AfriCarAPI.Controllers
{
	[Route("api/UsersAuth")]
	[ApiController]
	//[ApiVersionNeutral]
	public class UsersController : Controller
	{
		private readonly IUserRepository _userRepository;
		protected APIResponse _apiResponse;
		public UsersController(IUserRepository userRepository)
		{
			_userRepository = userRepository;
			this._apiResponse = new();
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
		{
			var loginResponse = await _userRepository.Login(model);
			if (loginResponse.User == null || string.IsNullOrEmpty(loginResponse.Token))
			{
				_apiResponse.StatusCode = HttpStatusCode.BadRequest;
				_apiResponse.isSuccess = false;
				_apiResponse.ErrorMessages.Add("Username or password is incorrect");
				return BadRequest(_apiResponse);
			}

			_apiResponse.StatusCode = HttpStatusCode.OK;
			_apiResponse.isSuccess = true;
			_apiResponse.Result = loginResponse;

			return Ok(_apiResponse);
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO model)
		{
			bool isUserNameUnique = _userRepository.IsUniqueUser(model.UserName);

			if (!isUserNameUnique)
			{
				_apiResponse.StatusCode = HttpStatusCode.BadRequest;
				_apiResponse.isSuccess = false;
				_apiResponse.ErrorMessages.Add("Username already exists");
				return BadRequest(_apiResponse);
			}

			var user = await _userRepository.Register(model);
			if (user == null)
			{
				_apiResponse.StatusCode = HttpStatusCode.BadRequest;
				_apiResponse.isSuccess = false;
				_apiResponse.ErrorMessages.Add("Error while registering. Please try again.");
				return BadRequest(_apiResponse);
			}

			_apiResponse.StatusCode = HttpStatusCode.OK;
			_apiResponse.isSuccess = true;

			return Ok(_apiResponse);

		}

	}

}
