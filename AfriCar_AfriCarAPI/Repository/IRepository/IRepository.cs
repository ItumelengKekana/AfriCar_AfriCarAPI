using System.Linq.Expressions;

/* This respository includes async action methods that perform the follwowing:
	GetAllAsync - fetches all the cars from the db and can filter the results based on the parameters
	GetAsync - fetches a specific car based on the ID and can also filter the results
	CreateAsync - creates a new car
	RemoveAsync - removes a car based on its ID
	SaveAsync - saves changes to the db
 */

namespace AfriCar_AfriCarAPI.Repository.IRepository
{
	public interface IRepository<T> where T : class
	{
		Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null, int pageSize = 0, int pageNumber = 1);
		Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true, string? includeProperties = null);
		Task CreateAsync(T entity);
		Task RemoveAsync(T entity);
		Task SaveAsync();
	}
}
