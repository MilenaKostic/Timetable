using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Shared.DTO;
using Shared.DTO.Route;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Net.WebSockets;
using JsonSerializer = System.Text.Json.JsonSerializer;
using WebAPI.Models;
using Azure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace WebApplication_BusTimeline.Pages.Routes
{
	public class RouteDetailsModel : PageModel
	{

		public RouteDTO Route { get; set; }

		public List<StopGetBasicDTO> Stops { get; set; }

		public List<RouteStopListDTO> RouteStops { get; set; }

		public Int32 LastRBr { get; set; }

		public string? ErrorMessage { get; set; }
		public async Task OnGetAsync(string routeId, string stanicaId, string lastRbr)
		{
			if (stanicaId != null)
			{
				try
				{
					RouteStopPostDTO newRouteStop = new RouteStopPostDTO()
					{
						RouteId = Convert.ToInt32(routeId),
						Rbr = Convert.ToInt32(lastRbr) + 1,
						StopId = Convert.ToInt32(stanicaId)
					};


					var _httpClient = new HttpClient();
					var result = await _httpClient.PostAsync("https://localhost:7151/RouteStop", new StringContent(JsonSerializer.Serialize(newRouteStop), Encoding.UTF8, "application/json"));


				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message);
				}


			}


			using (var httpClient = new HttpClient())
			{
				try
				{
					using (HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:7151/Route/ById:{routeId}"))
					{
						string apiResponse = await response.Content.ReadAsStringAsync();

						try
						{
							Route = JsonConvert.DeserializeObject<RouteDTO>(apiResponse);

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
			}

			using (var httpClient = new HttpClient())
			{
				try
				{
					using (HttpResponseMessage response = await httpClient.GetAsync("https://localhost:7151/Stop/AllStops"))
					{
						string apiResponse = await response.Content.ReadAsStringAsync();
						var _stops = (JsonConvert.DeserializeObject<List<StopGetBasicDTO>>(apiResponse)).ToList();

						Stops = _stops.ToList();

					}
				}
				catch (Exception e)
				{
					ErrorMessage = "Lista stanica je trenutno nedostupna, poku�ajte kasnije";
				}
			}

			using (var httpClient = new HttpClient())
			{
				try
				{
					using (HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:7151/RouteStop/ById:{routeId}"))
					{
						string apiResponse = await response.Content.ReadAsStringAsync();
						RouteStops = (JsonConvert.DeserializeObject<List<RouteStopListDTO>>(apiResponse)).ToList();

						LastRBr = RouteStops.Max(x => x.Rbr);
					}
				}
				catch (Exception e)
				{
					ErrorMessage = "Lista stanica je trenutno nedostupna, poku�ajte kasnije";
				}
			}
		}


		public async Task OnPostDeleteRouteStopAsync(int routeId, int stanicaId, int RBr)
		{
			using (var httpClient = new HttpClient())
			{
				try
				{
					using (HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:7151/RouteStop/ById:{routeId}"))
					{
						string apiResponse = await response.Content.ReadAsStringAsync();
						RouteStops = (JsonConvert.DeserializeObject<List<RouteStopListDTO>>(apiResponse)).ToList();

					}
					
					foreach(var s in RouteStops)
					{
						if(s.Id == stanicaId && s.Rbr == RBr)
						{
							using (HttpResponseMessage response2 = await httpClient.DeleteAsync($"https://localhost:7151/RouteStop/{s.Id}"))
							{
                                string apiResponse = await response2.Content.ReadAsStringAsync();

                                //return RedirectToPage($"Routes/RouteDetails?routeId={routeId}");
                            }
                            
                        }
					}
                    //return RedirectToPage($"Routes/RouteDetails?routeId={routeId}");

                }
				catch (Exception e)
				{
					ErrorMessage = "Lista stanica je trenutno nedostupna, poku�ajte kasnije";
                    //return RedirectToPage($"Routes/RouteDetails?routeId={routeId}");
                }


			}
		}

	}
}