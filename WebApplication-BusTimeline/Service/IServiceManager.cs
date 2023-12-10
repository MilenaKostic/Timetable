using Shared.DTO;

namespace WebApplication_BusTimeline.Service
{
	public interface IServiceManager
	{
		Task<IEnumerable<StopGetBasicDTO>> GetAllBasicStop();
		Task<IEnumerable<StopDTO>> GetStopById(int id);
		Task<IEnumerable<RouteGetBasicDTO>> GetAllBasicRoute();
		Task<RouteDTO> GetRouteById(int id);
		Task<RouteDTO> GetRouteByName(string name);
		Task<IEnumerable<RouteStopListDTO>> GetRouteStopByRouteId(int routeId);
		Task DeleteRouteStopById(int id);
	}
}
