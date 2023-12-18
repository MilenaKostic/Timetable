using Microsoft.EntityFrameworkCore;
using TimeTable.Api.Entities.Models;
using TimeTable.Api.Interfaces;

namespace TimeTable.Api.Repositories
{
	public class SiteUserRepository : RepositoryBase<SiteUser>, ISiteUserRepository
	{
		public SiteUserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
		{
		}

		public void CreateUser(SiteUser user)
		{
			Create(user);
		}

		public async Task<SiteUser> GetByName(string Name)
		{
			return await FindByCondition(x => x.Username == Name, false).FirstOrDefaultAsync();
		}
		public async Task<IEnumerable<SiteUser>> GetAll()
		{
			return await FindAll(false).ToListAsync();
		}
	}
}
