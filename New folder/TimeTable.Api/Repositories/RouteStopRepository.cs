﻿using Microsoft.EntityFrameworkCore;
using TimeTable.Api.Entities.Models;
using TimeTable.Api.Interfaces;

namespace TimeTable.Api.Repositories
{
	public class RouteStopRepository : RepositoryBase<RouteStop>, IRouteStopRepository
	{
		public RouteStopRepository(RepositoryContext repositoryContext) : base(repositoryContext)
		{
		}
		public void CreateRouteStop(RouteStop routestop)
		{
			Create(routestop);
		}
		public async Task<IEnumerable<RouteStop>> GetAll()
		{
			return await FindAll(false).ToListAsync();
		}
		public async Task<IEnumerable<RouteStop>> GetByRouteId(int Id, Boolean trackChanges)
		{

			var stopsOnRoute = await FindByCondition(x => x.RouteId == Id, false).ToListAsync();
			var orderedStopsOnRoute = stopsOnRoute.OrderBy(x => x.Rbr);

			return orderedStopsOnRoute.ToList();
						 //FindByCondition(x => x.Route.Id == Id).ToList();
		}
		public async Task<RouteStop> GetById(int Id, Boolean trackChanges)
		{
			return await FindByCondition(x => x.Id == Id, trackChanges).FirstOrDefaultAsync();
		}
		public void DeleteRouteStop(RouteStop routestop)
		{
			Delete(routestop);
		}

		public async Task<IEnumerable<RouteStop>> GetGreatRbrRoute(int routeId, int rbr)
		{
			return await FindByCondition(x => x.RouteId == routeId && x.Rbr >= rbr, true).ToListAsync();
		}
	}
}
