using AfriCar_Web.Models.Dto;

namespace AfriCar_Web.Services.IServices
{
	public interface ICarService
	{
		Task<T> GetAllAsync<T>(string token);
		Task<T> GetAsync<T>(int id, string token);
		Task<T> CreateAsync<T>(CarCreateDTO dto, string token);
		Task<T> UpdateAsync<T>(CarUpdateDTO dto, string token);
		Task<T> DeleteAsync<T>(int id, string token);
	}
}
