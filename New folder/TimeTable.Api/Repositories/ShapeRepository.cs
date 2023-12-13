using Microsoft.EntityFrameworkCore;
using TimeTable.Api.Entities.Models;
using TimeTable.Api.Interfaces;

namespace TimeTable.Api.Repositories
{
	public class ShapeRepository : RepositoryBase<Shape>, IShapeRepository
	{
		public ShapeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
		{
		}

		public async Task<IEnumerable<Shape>> GetAll()
		{
			return await FindAll(false).ToListAsync();
		}

		public void CreateShape(Shape shape)
		{
			Create(shape);
		}

		public void DeleteShape(Shape shape)
		{
			Delete(shape);
		}

		public async Task<Shape> GetById(int id, bool trackChanges)
		{
			return await FindByCondition(x => x.Id == id, trackChanges).FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<Shape>> GetByRoute(int routeId)
		{
			return await FindByCondition(x => x.RouteId == routeId, false).ToListAsync();
		}


		public async Task<int?> GetLastRbrByRoute(int routeId)
		{
			var rbr = await FindByCondition(x => x.RouteId == routeId, false).OrderByDescending(x => x.RBr).FirstOrDefaultAsync();

			if(rbr == null)
			{
				return new int?();
			}
			return rbr.RBr; 
		}
	}
}
