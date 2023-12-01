﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Shared.DTO;
using Shared.DTO.Route;
using System.Net.Http;
using System.Text;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WebApplication_BusTimeline.Pages.Routes
{
    public class AddRouteModel : PageModel
    {
        public List<RouteGetBasicDTO> Routes { get; set; }
		public string? ErrorMessage { get; set; }

        [BindProperty]
        public RoutePostDTO routePostDTO { get; set; }
		public async Task OnGetAsync()
        {
			using (var httpClient = new HttpClient())
			{
				try
				{
					using (HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:7151/Route/AllRoutes"))
					{
						string apiResponse = await response.Content.ReadAsStringAsync();
						try
						{
							var _routes = JsonConvert.DeserializeObject<List<RouteGetBasicDTO>>(apiResponse);
							Routes = _routes.ToList();

						}
						catch (JsonSerializationException)
						{
							ErrorMessage = "Lista ruta je trenutno nedostupna, pokušajte kasnije";
						}
					}

				}
				catch (Exception ex)
				{
					ErrorMessage = "Lista ruta je trenutno nedostupna, pokušajte kasnije";
				}

			}
				
		}


		public async Task OnPostAsync(RoutePostDTO routePostDTO)
		{
			using (var httpClient = new HttpClient())
			{
				try
				{
					using (HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:7151/Route/ByName:{routePostDTO.Name}"))
					{
						if (response.IsSuccessStatusCode)
						{
							string apiResponse = await response.Content.ReadAsStringAsync();
							var _user = (JsonConvert.DeserializeObject<UserRegisterDTO>(apiResponse));
							ErrorMessage = "Već postoji ruta sa ovim imenom, pokušajte ponovo!";

							try
							{
								using (HttpResponseMessage response2 = await httpClient.GetAsync($"https://localhost:7151/Route/AllRoutes"))
								{
									string apiResponse2 = await response2.Content.ReadAsStringAsync();
									try
									{
										var _routes = JsonConvert.DeserializeObject<List<RouteGetBasicDTO>>(apiResponse2);
										Routes = _routes.ToList();

									}
									catch (JsonSerializationException)
									{
										ErrorMessage = "Lista ruta je trenutno nedostupna, pokušajte kasnije";

									}


								}


							}
							catch (Exception ex)
							{
								ErrorMessage = "Lista ruta je trenutno nedostupna, pokušajte kasnije";

							}
						}
						else
						{

							RoutePostDTO newRoute = new RoutePostDTO
							{
								Name = routePostDTO.Name,
								Color = routePostDTO.Color
							};

							var _httpClient = new HttpClient();
							var result = await _httpClient.PostAsync("https://localhost:7151/Route", new StringContent(JsonSerializer.Serialize(newRoute), Encoding.UTF8, "application/json"));


							try
							{
								using (HttpResponseMessage response3 = await httpClient.GetAsync($"https://localhost:7151/Route/AllRoutes"))
								{
									string apiResponse = await response3.Content.ReadAsStringAsync();
									try
									{
										var _routes = JsonConvert.DeserializeObject<List<RouteGetBasicDTO>>(apiResponse);
										Routes = _routes.ToList();

									}
									catch (JsonSerializationException)
									{
										ErrorMessage = "Lista ruta je trenutno nedostupna, pokušajte kasnije";

									}


								}


							}
							catch (Exception ex)
							{
								ErrorMessage = "Lista ruta je trenutno nedostupna, pokušajte kasnije";

							}
						}


					}
				}

				catch (JsonSerializationException)
				{
					ErrorMessage = "Lista ruta je trenutno nedostupna, pokušajte kasnije";

				}



			}
		}

	}
}