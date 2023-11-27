using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Shared.DTO;
using Shared.DTO.Route;

namespace WebApplication_BusTimeline.Pages.Routes
{
	public class MapModel : PageModel
	{
		[BindProperty(SupportsGet = true)]
		public string routeName { get; set; }
		public List<RouteStopListDTO> RouteStops { get; set; }
		public string? ErrorMessage { get; set; }
		public int RouteId { get; set; }
		public List<StopDTO> Stops { get; set; }

        public async Task OnGetAsync(string routeName)
		{
			if(routeName != null)
			{
				using (var httpClient = new HttpClient())
				{
					try
					{
						using (HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:7151/Route/ByName:{routeName}"))
						{
							string apiResponse = await response.Content.ReadAsStringAsync();
							try
							{
								var _route = JsonConvert.DeserializeObject<RouteDTO>(apiResponse);
								RouteId = _route.Id;
							}
							catch (JsonSerializationException)
							{
								ErrorMessage = "Željena ruta je trenutno nedostupna, pokušajte kasnije";
							}
						}

					}
					catch (Exception ex)
					{
						ErrorMessage = "Željena ruta je trenutno nedostupna, pokušajte kasnije";
					}
					try
					{
						using (HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:7151/RouteStop/ById:{RouteId}"))
						{
							string apiResponse = await response.Content.ReadAsStringAsync();
							try
							{
								var _routeStops = (JsonConvert.DeserializeObject<List<RouteStopListDTO>>(apiResponse)).ToList();
								RouteStops = _routeStops;
							}
							catch (JsonSerializationException)
							{
								ErrorMessage = "Željena ruta je trenutno nedostupna, pokušajte kasnije";
							}
						}

					}
					catch (Exception ex)
					{
						ErrorMessage = "Željena ruta je trenutno nedostupna, pokušajte kasnije";
					}

					try
					{
						using (HttpResponseMessage response = await httpClient.GetAsync("https://localhost:7151/Stop/AllStops"))
						{
							string apiResponse = await response.Content.ReadAsStringAsync();
							try
							{
								var _stops = JsonConvert.DeserializeObject<List<StopDTO>>(apiResponse);
								Stops = _stops.ToList();

							}


							catch (Exception ex)
							{
								ErrorMessage = "Željena ruta je trenutno nedostupna, pokušajte kasnije";
							}
						}
					}
                    catch (Exception ex)
                    {
                        ErrorMessage = "Željena ruta je trenutno nedostupna, pokušajte kasnije";
                    }
                }
			}
			else
			{
                ErrorMessage = "Izaberite željenu rutu";
            }

		}

	}
	

}

