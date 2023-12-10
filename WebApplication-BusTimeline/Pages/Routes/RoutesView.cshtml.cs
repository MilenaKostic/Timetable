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

		public List<RouteGetBasicDTO> Routes { get; set; }

		public MapModel(IServiceManager service)
		{
			_service = service;
		}

		public async Task OnGetAsync(string routeName)
		{
			if (routeName != null)
			{
				try
				{
					var _route = (await _service.GetRouteByName(routeName));
					RouteId = _route.Id;
				}
				catch (Exception e)
				{
					ErrorMessage = e.Message;
				}

				try
				{
					Routes = (await _service.GetAllBasicRoute()).ToList();
				}
				catch (Exception ex)
				{
					ErrorMessage = ex.Message;
				}


				try
				{
					RouteStops = (await _service.GetRouteStopByRouteId(RouteId)).ToList();
				}
				catch (Exception e)
				{
					ErrorMessage = e.Message;
				}


				//try
				//{
				//	Stops = (await _service.GetStopDTO()).ToList();
				//}
				//catch (Exception e)
				//{
				//	ErrorMessage = e.Message;
				//}





			}
			else
			{
				try
				{
					Routes = (await _service.GetAllBasicRoute()).ToList();
				}
				catch (Exception ex)
				{
					ErrorMessage = ex.Message;
				}

				ErrorMessage = "Izaberite željenu rutu";
			}
		}
	
	}

}
	


