using Microsoft.EntityFrameworkCore;
using TimeTable.Api.Interfaces;

namespace TimeTable.Api.Repositories
{
	public class RouteRepository : RepositoryBase<Entities.Models.Route>, IRouteRepository
	{
		public RouteRepository(RepositoryContext repositoryContext) : base(repositoryContext)
		{
		}

		public void CreateRoute(Entities.Models.Route route)
		{
			Create(route);
		}
		public async Task<IEnumerable<Entities.Models.Route>> GetAll()
		{
			return await FindAll(false).ToListAsync();
		}

		public async Task<Entities.Models.Route> GetById(int id, Boolean trackChanges)
		{
			return await FindByCondition(x => x.Id == id, trackChanges).FirstOrDefaultAsync();
		}

		public async Task<Entities.Models.Route> GetByName(string name)
		{
			return await FindByCondition(x => x.RouteName == name, false).FirstOrDefaultAsync();
		}


		public void DeleteRoute(Entities.Models.Route route)
		{
			Delete(route);
		}

	
	}
}
