using TimeTable.Api.Entities.Models;

namespace TimeTable.Api.Interfaces
{
	public interface IRouteStopRepository
	{
		void CreateRouteStop(RouteStop routeStop);
		Task<IEnumerable<RouteStop>> GetAll();
		Task<IEnumerable<RouteStop>> GetByRouteId(int Id, Boolean trackChanges);
		Task<RouteStop> GetById(int Id, Boolean trackChanges);
		void DeleteRouteStop(RouteStop routeStop);
		Task<IEnumerable<RouteStop>> GetGreatRbrRoute(int routeId, int rbr);
	}
}
