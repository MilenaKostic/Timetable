using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Shared.DTO;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Net.WebSockets;
using JsonSerializer = System.Text.Json.JsonSerializer;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using WebApplication_BusTimeline.Service;

namespace WebApplication_BusTimeline.Pages.Routes
{
	public class RouteDetailsModel : PageModel
	{
		public IServiceManager _service;
		public RouteWithStopsDTO RouteWithStops { get; set; }

		public List<StopGetBasicDTO> Stops = new List<StopGetBasicDTO>(); 
		public List<RouteStopListDTO> RouteStops { get; set; }
		public Int32 LastRBr { get; set; }
		public string? ErrorMessage { get; set; }
		public List<SelectListItem> StanicaList { get; set; }

		[BindProperty, DataType(DataType.Text)]
		public string SelStanicaId { get; set; }

		[BindProperty, DataType(DataType.Text)]
		public string SelPozicijaId { get; set; }

		[BindProperty, DataType(DataType.Text)]
		public string TimeInterval { get; set; }

		[BindProperty, DataType(DataType.Text)]
		public string MetarDistance { get; set; }

		[BindProperty, DataType(DataType.Text)]
		public string RouteId { get; set; }

		[BindProperty, DataType(DataType.Text)]
		public string SelectRbr { get; set; }

		public List<ShapeDTO> Shapes { get; set; }

		public RouteDetailsModel(IServiceManager service)
		{
			_service = service;
		}

		public async Task OnGetAsync(string routeId, string StanicaRbr)
		{
			if(StanicaRbr  == null)
			{
				SelectRbr = "1";
			}
			else
			{
				SelectRbr = StanicaRbr;
			}

			try
			{
				int _routeId = int.Parse(routeId);
				Shapes = (await _service.GetShapeByRoute(_routeId)).ToList();
			}
			catch(Exception ex)
			{
				ErrorMessage = ex.Message; 
			}

			try 
			{
				int routeID = Int32.Parse(routeId);
				RouteWithStops = await _service.GetRouteWithStops(routeID);

				LastRBr = RouteWithStops.Stops.Max(x => x.Rbr); 
			}
			catch(Exception e)
			{
				ErrorMessage = e.Message;
			}

			
			try
			{
				Stops = (await _service.GetAllBasicStop()).ToList();
				StanicaList = Stops.Select(row => new SelectListItem() { Value = row.Id.ToString(), Text = row.Name }).ToList();

			}
			catch (Exception e)
			{
				ErrorMessage = e.Message;
			}

		}

		public async Task OnPostDeleteRouteStopAsync(int routeId, int stanicaId, int RBr)
		{

			try
			{
				RouteWithStops = (await _service.GetRouteWithStops(routeId));
			}
			catch (Exception e)
			{
				ErrorMessage = e.Message;
			}


			foreach (var s in RouteWithStops.Stops)
			{
				if (s.Id == stanicaId && s.Rbr == RBr)
				{
					try
					{
						await _service.DeleteRouteStopById(s.Id);
					}
					catch (Exception e)
					{
						ErrorMessage = e.Message;
					}

				}
			}

			try
			{
				RouteWithStops = await _service.GetRouteWithStops(routeId);
				LastRBr = RouteWithStops.Stops.Max(x => x.Rbr);
			}
			catch (Exception e)
			{
				ErrorMessage = e.Message;
			}


			try
			{
				Stops = (await _service.GetAllBasicStop()).ToList();
				StanicaList = Stops.Select(row => new SelectListItem() { Value = row.Id.ToString(), Text = row.Name }).ToList();

			}
			catch (Exception e)
			{
				ErrorMessage = e.Message;
			}






		}

		public async Task<IActionResult> OnPost()
		{
			int _routeId = 0;
			try
			{
				RouteStopPostDTO newRouteStop = new RouteStopPostDTO()
				{
					RouteId = Convert.ToInt32(RouteId),
					PositionId = Convert.ToInt32(SelPozicijaId),
					StopId = Convert.ToInt32(SelStanicaId),
					TimeInterval = Convert.ToInt32(TimeInterval),
					MetarDistance = Convert.ToInt32(MetarDistance),
					SelectRbr = String.IsNullOrEmpty(SelectRbr) ? (new int?()) : Convert.ToInt32(SelectRbr)
				};

				await _service.CreateRouteStop(newRouteStop);

				//try
				//{
				//	await _service.CreateRouteStop(newRouteStop);
				//	if (RouteStops.Count == 0)
				//	{
				//		LastRBr = 1;
				//	}
				//	else
				//	{
				//		LastRBr = RouteStops.Max(x => x.Rbr);
				//	}

				//}
				//catch (Exception e)
				//{
				//	ErrorMessage = e.Message;
				//}

			}
			catch (Exception e)
			{
				ErrorMessage = e.Message.ToString();
			}

			

			try
			{
				if (RouteId != null)
				{
					if (int.TryParse(RouteId, out _routeId))
					{
						RouteWithStops = await _service.GetRouteWithStops(_routeId);
					}
				}
				else
				{
					ErrorMessage = "Izaberite rutu";
				}

			}
			catch (Exception e)
			{
				ErrorMessage = e.Message;
			}


			try
			{
				Stops = (await _service.GetAllBasicStop()).ToList();
				StanicaList = Stops.Select(row => new SelectListItem() { Value = row.Id.ToString(), Text = row.Name }).ToList();

			}
			catch (Exception e)
			{
				ErrorMessage = e.Message;
			}

			return Page();
		}

	}
}