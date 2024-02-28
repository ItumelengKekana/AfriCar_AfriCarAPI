using AfriCar_Web.Models.Dto;

namespace AfriCar_Web.Services.IServices
{
	public interface ICarService
	{
		Task<T> GetAllAsync<T>();
		Task<T> GetAsync<T>(int id);
		Task<T> CreateAsync<T>(CarCreateDTO dto);
		Task<T> UpdateAsync<T>(CarUpdateDTO dto);
		Task<T> DeleteAsync<T>(int id);
	}
}
