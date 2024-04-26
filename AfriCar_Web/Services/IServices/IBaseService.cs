using AfriCar_Web.Models;

/* This is the base service used to send all API requests */

namespace AfriCar_Web.Services.IServices
{
	public interface IBaseService
	{
		APIResponse responseModel { get; set; }

		Task<T> SendAsync<T>(APIRequest apiRequest);
	}
}
