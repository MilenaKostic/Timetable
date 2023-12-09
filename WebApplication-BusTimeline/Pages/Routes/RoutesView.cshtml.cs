//using Azure;
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

		public List<RouteGetBasicDTO> Routes { get; set; }

        public async Task OnGetAsync(string routeName)
		{
			if(routeName != null)
			{
				using (var httpClient = new HttpClient())
				{
					try
					{
						using (HttpResponseMessage response = await httpClient.GetAsync($"http://localhost:5099/api/Route/RouteByName?name={routeName}"))
						{
							string apiResponse = await response.Content.ReadAsStringAsync();
							try
							{
								var _route = JsonConvert.DeserializeObject<RouteDTO>(apiResponse);
								RouteId = _route.Id;
							}
							catch (JsonSerializationException)
							{
								ErrorMessage = "�eljena ruta je trenutno nedostupna, poku�ajte kasnije";
							}
						}

					}
					catch (Exception ex)
					{
						ErrorMessage = "�eljena ruta je trenutno nedostupna, poku�ajte kasnije";
					}
					try
					{
						using (HttpResponseMessage response = await httpClient.GetAsync($"http://localhost:5099/api/Route"))
						{
							string apiResponse = await response.Content.ReadAsStringAsync();
							try
							{
								var _routes = JsonConvert.DeserializeObject<List<RouteGetBasicDTO>>(apiResponse);
								Routes = _routes.ToList(); 
							}
							catch (JsonSerializationException)
							{
								ErrorMessage = "Lista ruta je trenutno nedostupna, poku�ajte kasnije";
							}
						}

					}
					catch (Exception ex)
					{
						ErrorMessage = "Lista ruta je trenutno nedostupna, poku�ajte kasnije";
					}


					try
					{
						using (HttpResponseMessage response = await httpClient.GetAsync($"http://localhost:5099/api/RouteStop/{RouteId}"))
						{
							string apiResponse = await response.Content.ReadAsStringAsync();
							try
							{
								var _routeStops = (JsonConvert.DeserializeObject<List<RouteStopListDTO>>(apiResponse)).ToList();
								RouteStops = _routeStops;
							}
							catch (JsonSerializationException)
							{
								ErrorMessage = "�eljena ruta je trenutno nedostupna, poku�ajte kasnije";
							}
						}

					}
					catch (Exception ex)
					{
						ErrorMessage = "�eljena ruta je trenutno nedostupna, poku�ajte kasnije";
					}

					try
					{
						using (HttpResponseMessage response = await httpClient.GetAsync("http://localhost:5099/api/Stop"))
						{
							string apiResponse = await response.Content.ReadAsStringAsync();
							try
							{
								var _stops = JsonConvert.DeserializeObject<List<StopDTO>>(apiResponse);
								Stops = _stops.ToList();

							}


							catch (Exception ex)
							{
								ErrorMessage = "�eljena ruta je trenutno nedostupna, poku�ajte kasnije";
							}
						}
					}
                    catch (Exception ex)
                    {
                        ErrorMessage = "�eljena ruta je trenutno nedostupna, poku�ajte kasnije";
                    }
                }
			}
			else
			{
				using (var httpClient = new HttpClient())
				{
					try
					{
						using (HttpResponseMessage response = await httpClient.GetAsync($"http://localhost:5099/api/Route"))
						{
							string apiResponse = await response.Content.ReadAsStringAsync();
							try
							{
								var _route = JsonConvert.DeserializeObject<List<RouteGetBasicDTO>>(apiResponse);
								Routes = _route.ToList();
							}
							catch (JsonSerializationException)
							{
								ErrorMessage = "�eljena ruta je trenutno nedostupna, poku�ajte kasnije";
							}
						}

					}
					catch (Exception ex)
					{
						ErrorMessage = "�eljena ruta je trenutno nedostupna, poku�ajte kasnije";
					}
					ErrorMessage = "Izaberite �eljenu rutu";
				}
            }

		}

	}
	

}

