using AfriCar_AfriCarAPI.Data;
using AfriCar_AfriCarAPI.Models;
using AfriCar_AfriCarAPI.Repository.IRepository;

namespace AfriCar_AfriCarAPI.Repository
{
	public class CarRepository : Repository<CarModel>, ICarRepository
	{
		private readonly ApplicationDbContext _db;

		public CarRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public async Task<CarModel> UpdateAsync(CarModel entity)
		{
			entity.UpdatedDate = DateTime.Now;
			_db.Cars.Update(entity);
			await _db.SaveChangesAsync();
			return entity;
		}
	}
}
