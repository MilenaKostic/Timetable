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
		public RouteDTO Route { get; set; }
		public List<StopGetBasicDTO> Stops { get; set; }
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
				int routeID = Int32.Parse(routeId);
				Route = await _service.GetRouteById(routeID);			
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
			catch(Exception e)
			{
				ErrorMessage = e.Message;
			}

			try
			{
				int RouteId = Int32.Parse(routeId);
				RouteStops = (await _service.GetRouteStopByRouteId(RouteId)).ToList();
				LastRBr = RouteStops.Max(x => x.Rbr);
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
				RouteStops = (await _service.GetRouteStopByRouteId(routeId)).ToList();
			}
			catch (Exception e)
			{
				ErrorMessage = e.Message;
			}

			
			foreach(var s in RouteStops)
			{
				if(s.Id == stanicaId && s.Rbr == RBr)
				{
					//??  
                }
			}


			try
			{
				
				Route = await _service.GetRouteById(routeId);
			}
			catch (Exception e)
			{
				ErrorMessage = e.Message;
			}

		

			try {
				Stops = (await _service.GetAllBasicStop()).ToList();

			}
			catch(Exception e)
			{
				ErrorMessage = e.Message; 
			}

			try
			{
				RouteStops = (await _service.GetRouteStopByRouteId(routeId)).ToList();
				LastRBr = RouteStops.Max(x => x.Rbr);
			}
			catch (Exception e)
			{
				ErrorMessage = e.Message;
			}

        }

		public async Task<IActionResult> OnPost()
		{
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

				var _httpClient = new HttpClient();
				var result = await _httpClient.PostAsync("https://localhost:7151/RouteStop", new StringContent(JsonSerializer.Serialize(newRouteStop), Encoding.UTF8, "application/json"));

			}
			catch(Exception e)
			{
				ErrorMessage = e.Message.ToString();
			}

			try
			{
				int RouteID = Int32.Parse(RouteId);
				Route = await _service.GetRouteById(RouteID);
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
			catch(Exception e)
			{
				ErrorMessage = e.Message; 
			}

			try
			{
				int routeId = Int32.Parse(RouteId);
				Route = await _service.GetRouteById(routeId);
			}
			catch (Exception e)
			{
				ErrorMessage = e.Message;
			}
			return Page();
        }

	}
}