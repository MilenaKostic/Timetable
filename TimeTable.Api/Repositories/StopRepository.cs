using Microsoft.EntityFrameworkCore;
using TimeTable.Api.Entities.Models;
using TimeTable.Api.Interfaces;

namespace TimeTable.Api.Repositories
{
	public class StopRepository : RepositoryBase<Stop>, IStopRepository
	{
		public StopRepository(RepositoryContext repositoryContext) : base(repositoryContext)
		{
		}

		public void CreateStop(Stop stop)
		{
			Create(stop);
		}

		public void DeleteStop(Stop stop)
		{
			Delete(stop);
		}

		public async Task<IEnumerable<Stop>> GetAll()
		{
			return await FindAll(false).ToListAsync();
		}

		public async Task<Stop> GetById(int id, bool trackChanges)
		{
			return await FindByCondition(x => x.Id == id, trackChanges).FirstOrDefaultAsync();
		}

		public async Task<Stop> GetByName(string name)
		{
			return await FindByCondition(x => x.StopName == name,  false).FirstOrDefaultAsync();
		}
	}
	
}
