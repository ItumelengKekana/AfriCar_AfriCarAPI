using AfriCar_Web.Models.Dto;

namespace AfriCar_Web.Services.IServices
{
	public interface ICarNumberService
	{
		Task<T> GetAllAsync<T>(string token);
		Task<T> GetAsync<T>(int id, string token);
		Task<T> CreateAsync<T>(CarNumberCreateDTO dto, string token);
		Task<T> UpdateAsync<T>(CarNumberUpdateDTO dto, string token);
		Task<T> DeleteAsync<T>(int id, string token);
	}
}
