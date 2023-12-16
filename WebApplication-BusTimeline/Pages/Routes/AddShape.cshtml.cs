using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.DTO;
using System.Xml.Serialization;
using WebApplication_BusTimeline.Service;

namespace WebApplication_BusTimeline.Pages.Routes;

	public class AddShapeModel : PageModel
{
    public IServiceManager _service;
    public string ErrorMessage { get; set; }
    public List<ShapeDTO> Shapes { get; set; }
		public RouteWithStopsDTO RouteWithStops { get; set; }

		public AddShapeModel(IServiceManager service)
    {
        _service = service;
    }

    public int RouteId { get; set; }
    public async Task OnGetAsync(int id, double lat, double lon)
    {
        RouteId = id;
        try
        {
				

				if (lat !=  0 && lon != 0)
            {
                var createShape = new ShapePostDTO()
                {
                    RouteId = RouteId,
                    Lat = lat,
                    Lon = lon
                };

                await _service.CreateShape(createShape);
					
				}
				Shapes = (await _service.GetShapeByRoute(RouteId)).ToList();
			}
        catch (Exception ex)
        {
            ErrorMessage = ex.Message; 
        }
    }

    public async Task OnPostDeleteShape(int shapeId, int routeId)
    {
        RouteId = routeId; 
        try
        {
            await _service.DeleteShapeById(shapeId);
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }

			try
			{
				Shapes = (await _service.GetShapeByRoute(routeId)).ToList();
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
			}


		}
}
