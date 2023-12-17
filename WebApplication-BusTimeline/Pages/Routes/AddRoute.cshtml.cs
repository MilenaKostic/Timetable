using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Shared.DTO;
using System.Net.Http;
using System.Text;
using WebApplication_BusTimeline.Service;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WebApplication_BusTimeline.Pages.Routes;

[Authorize]
	public class AddRouteModel : PageModel
    {
	public IServiceManager _service;
        public List<RouteGetBasicDTO> Routes { get; set; }
	public string? ErrorMessage { get; set; }

	public List<RouteGetBasicDTO> routes { get; set; }

        [BindProperty]
        public RoutePostDTO routePostDTO { get; set; }

	public AddRouteModel(IServiceManager service)
	{
		_service = service;
	}
	public async Task OnGetAsync()
        {
		try 
		{
			Routes = (await _service.GetAllBasicRoute()).ToList();
		}
		catch (Exception ex)
		{
			ErrorMessage = ex.Message;
		}
			
	}

	
	public async Task OnPostAsync(RoutePostDTO routePostDTO)
	{
		try
		{
			routes = (await _service.GetAllBasicRoute()).ToList();

			foreach(var r in routes)
			{
				if(r.Name == routePostDTO.Name)
				{
					ErrorMessage = "Već postoji ruta sa ovim imenom, pokušajte ponovo!";
					Routes = (await _service.GetAllBasicRoute()).ToList();
					return;
				}
			}

			RoutePostDTO newRoute = new RoutePostDTO
			{
				Name = routePostDTO.Name,
				Color = routePostDTO.Color
			};

			try
			{
				var result = (await _service.CreateRoute(newRoute));
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
			}

			try
			{
				Routes = (await _service.GetAllBasicRoute()).ToList();
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
			}			

		}
		catch(Exception ex)
		{
			ErrorMessage = ex.Message; 
		}
			
	}

}
