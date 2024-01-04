using AfriCar_AfriCarAPI.Models;

namespace AfriCar_AfriCarAPI.Repository.IRepository
{
	public interface ICarNumberRepository : IRepository<CarNumberModel>
	{
		Task<CarNumberModel> UpdateAsync(CarNumberModel entity);
	}
}
