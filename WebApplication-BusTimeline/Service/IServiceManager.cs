using Shared.DTO;

namespace WebApplication_BusTimeline.Service
{
	public interface IServiceManager
	{
		Task<IEnumerable<StopGetBasicDTO>> GetAllBasicStop();
		Task<StopDTO> GetStopById(int id);
		Task<StopGetBasicDTO> CreateStop (StopPostDTO stop);

		Task<IEnumerable<RouteGetBasicDTO>> GetAllBasicRoute();
		Task<RouteDTO> GetRouteById(int id);
		Task<RouteDTO> GetRouteByName(string name);
		Task<RouteGetBasicDTO> CreateRoute(RoutePostDTO route);
		Task DeleteRoute(int id);

		Task<IEnumerable<RouteStopListDTO>> GetRouteStopByRouteId(int routeId);
		Task DeleteRouteStopById(int id);
		Task <RouteStopGetDTO> CreateRouteStop(RouteStopPostDTO route);
		Task<RouteWithStopsDTO> GetRouteWithStops(int routeId);
	}
}
