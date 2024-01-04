using AfriCar_AfriCarAPI.Data;
using AfriCar_AfriCarAPI.Models;
using AfriCar_AfriCarAPI.Repository.IRepository;

namespace AfriCar_AfriCarAPI.Repository
{
	public class CarNumberRepository : Repository<CarNumberModel>, ICarNumberRepository
	{
		private readonly ApplicationDbContext _db;

		public CarNumberRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public async Task<CarNumberModel> UpdateAsync(CarNumberModel entity)
		{
			entity.UpdatedDate = DateTime.Now;
			_db.CarNumbers.Update(entity);
			await _db.SaveChangesAsync();
			return entity;
		}
	}
}
