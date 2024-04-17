using AfriCar_Utility;
using AfriCar_Web.Models;
using AfriCar_Web.Models.Dto;
using AfriCar_Web.Services.IServices;

namespace AfriCar_Web.Services
{
	public class CarNumberService : BaseService, ICarNumberService
	{
		private readonly IHttpClientFactory _clientFactory;
		private string carUrl;

		public CarNumberService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
		{
			_clientFactory = clientFactory;
			carUrl = configuration.GetValue<string>("ServiceUrls:CarAPI");
		}

		public Task<T> CreateAsync<T>(CarNumberCreateDTO dto, string token)
		{
			return SendAsync<T>(new APIRequest()
			{
				ApiType = SD.ApiType.POST,
				Data = dto,
				Url = carUrl + "/api/carNumberAPI",
				Token = token
			});
		}

		public Task<T> DeleteAsync<T>(int id, string token)
		{
			return SendAsync<T>(new APIRequest()
			{
				ApiType = SD.ApiType.DELETE,
				Url = carUrl + "/api/carNumberAPI/" + id,
				Token = token
			});
		}

		public Task<T> GetAllAsync<T>(string token)
		{
			return SendAsync<T>(new APIRequest()
			{
				ApiType = SD.ApiType.GET,
				Url = carUrl + "/api/carNumberAPI",
				Token = token
			});
		}

		public Task<T> GetAsync<T>(int id, string token)
		{
			return SendAsync<T>(new APIRequest()
			{
				ApiType = SD.ApiType.GET,
				Url = carUrl + "/api/carNumberAPI/" + id,
				Token = token
			});
		}

		public Task<T> UpdateAsync<T>(CarNumberUpdateDTO dto, string token)
		{
			return SendAsync<T>(new APIRequest()
			{
				ApiType = SD.ApiType.PUT,
				Data = dto,
				Url = carUrl + "/api/carNumberAPI/" + dto.CarNo,
				Token = token
			});
		}
	}
}
