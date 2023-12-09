using TimeTable.Api.Entities.Models;

namespace TimeTable.Api.Interfaces
{
	public interface IUserRepository
	{
		void CreateUser(User user);
		Task<IEnumerable<User>> GetAll();
		Task<User> GetById(int Id, Boolean trackChanges);
		Task<User> GetByName(string Name);
		void DeleteUser(User user);
	}
}
