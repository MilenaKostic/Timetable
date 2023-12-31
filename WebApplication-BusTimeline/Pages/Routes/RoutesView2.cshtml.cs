using FluentAssertions.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Shared.DTO;
using WebApplication_BusTimeline.Service;
//using WebAPI.Models;

namespace WebApplication_BusTimeline.Pages.Routes;

[Authorize]
public class RoutesView2Model : PageModel
{
	
	public IServiceManager _service;
    public List<RouteGetBasicDTO> Routes { get; set; }

    public string? ErrorMessage { get; set; }

    public RoutesView2Model(IServiceManager service)
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

    public async Task OnPostDeleteRouteAsync(int routeId)
	{
		try
		{
			await _service.DeleteRoute(routeId);
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
}

