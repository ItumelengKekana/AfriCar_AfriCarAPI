using AfriCar_Utility;
using AfriCar_Web.Models.Dto;
using AfriCar_Web.Models;
using AfriCar_Web.Services.IServices;

namespace AfriCar_Web.Services
{
	public class AuthService : BaseService, IAuthService
	{

		private readonly IHttpClientFactory _clientFactory;
		private string carUrl;

		public AuthService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
		{
			_clientFactory = clientFactory;
			carUrl = configuration.GetValue<string>("ServiceUrls:CarAPI");
		}

		public Task<T> LoginAsync<T>(LoginRequestDTO obj)
		{
			return SendAsync<T>(new APIRequest()
			{
				ApiType = SD.ApiType.POST,
				Data = obj,
				Url = carUrl + "/api/v1/UsersAuth/login"
			});
		}

		public Task<T> RegisterAsync<T>(RegistrationRequestDTO obj)
		{
			return SendAsync<T>(new APIRequest()
			{
				ApiType = SD.ApiType.POST,
				Data = obj,
				Url = carUrl + "/api/v1/UsersAuth/register"
			});
		}
	}
}
