using Microsoft.EntityFrameworkCore;
using TimeTable.Api.Entities.Models;
using TimeTable.Api.Interfaces;

namespace TimeTable.Api.Repositories
{
	public class UserRepository : RepositoryBase<User>, IUserRepository
	{
		public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
		{
		}

		public void CreateUser(User user)
		{
			Create(user);
		}

		public void DeleteUser(User user)
		{
			Delete(user);
		}

		public async Task<IEnumerable<User>> GetAll()
		{
			return await FindAll(false).ToListAsync();
		}

		public async Task<User> GetById(int Id, bool trackChanges)
		{
			return await FindByCondition(x => x.Id == Id.ToString(), trackChanges).FirstOrDefaultAsync();
		}

		public async Task<User> GetByName(string Name)
		{
			return await FindByCondition(x => x.UserName == Name, false).FirstOrDefaultAsync();
		}
	}
}
