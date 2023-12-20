using AfriCar_AfriCarAPI.Models;

namespace AfriCar_AfriCarAPI.Repository.IRepository
{
	public interface ICarRepository : IRepository<CarModel>
	{
		Task<CarModel> UpdateAsync(CarModel entity);
	}
}
