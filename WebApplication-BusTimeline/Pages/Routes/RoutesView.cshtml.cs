//using Azure;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Shared.DTO;
using WebApplication_BusTimeline.Service;

namespace WebApplication_BusTimeline.Pages.Routes
{
	public class MapModel : PageModel
	{
		public IServiceManager _service;
		[BindProperty(SupportsGet = true)]
		public string routeName { get; set; }
		public List<RouteStopListDTO> RouteStops { get; set; }
		public string? ErrorMessage { get; set; }
		public int RouteId { get; set; }
		public List<StopDTO> Stops { get; set; }
		public List<ShapeDTO> Shapes { get; set; }

		public List<RouteGetBasicDTO> Routes { get; set; }
		public RouteWithStopsDTO RouteWithStop { get; set; }

		public MapModel(IServiceManager service)
		{
			_service = service;
		}

		public async Task OnGetAsync(string routeId)
		{
			int RouteId = 0;
			try
			{

				Routes = (await _service.GetAllBasicRoute()).ToList();

			}
			catch
			{
				ErrorMessage = "Nije moguce dobaviti listu ruta.";
			}

			if (routeId != null)
			{
				if(int.TryParse(routeId, out RouteId))
				{
					RouteWithStop = await _service.GetRouteWithStops(RouteId);
				}
				RouteId = int.Parse(routeId);
				Shapes = (await _service.GetShapeByRoute(RouteId)).ToList();
			}
			else
			{
				ErrorMessage = "Izaberite rutu"; 
			}
		}
	
	}

}
	


