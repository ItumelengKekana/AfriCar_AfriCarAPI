using AfriCar_Web.Models.Dto;

namespace AfriCar_Web.Services.IServices
{
	public interface ICarNumberService
	{
		Task<T> GetAllAsync<T>();
		Task<T> GetAsync<T>(int id);
		Task<T> CreateAsync<T>(CarNumberCreateDTO dto);
		Task<T> UpdateAsync<T>(CarNumberUpdateDTO dto);
		Task<T> DeleteAsync<T>(int id);
	}
}
