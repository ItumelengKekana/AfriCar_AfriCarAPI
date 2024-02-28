using AfriCar_Web.Models;

namespace AfriCar_Web.Services.IServices
{
	public interface IBaseService
	{
		APIResponse responseModel { get; set; }

		Task<T> SendAsync<T>(APIRequest apiRequest);
	}
}
