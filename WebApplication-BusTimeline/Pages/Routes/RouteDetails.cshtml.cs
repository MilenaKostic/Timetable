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
//using WebAPI.Models;
//using Azure;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WebApplication_BusTimeline.Pages.Routes
{
	public class RouteDetailsModel : PageModel
	{

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
		
			using (var httpClient = new HttpClient())
			{
				try
				{
					using (HttpResponseMessage response = await httpClient.GetAsync($"http://localhost:5099/api/Route/{routeId}"))
					{
						string apiResponse = await response.Content.ReadAsStringAsync();

						try
						{
							Route = JsonConvert.DeserializeObject<RouteDTO>(apiResponse);

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
			}

			using (var httpClient = new HttpClient())
			{
				try
				{
					using (HttpResponseMessage response = await httpClient.GetAsync("http://localhost:5099/api/Stop"))
					{
						string apiResponse = await response.Content.ReadAsStringAsync();
						var _stops = (JsonConvert.DeserializeObject<List<StopGetBasicDTO>>(apiResponse)).ToList();

						Stops = _stops.ToList();
						StanicaList = Stops.Select(row => new SelectListItem() { Value = row.Id.ToString(), Text = row.Name }).ToList(); 

					}
				}
				catch (Exception e)
				{
					ErrorMessage = "Lista stanica je trenutno nedostupna, pokušajte kasnije";
				}
			}

			using (var httpClient = new HttpClient())
			{
				try
				{
					using (HttpResponseMessage response = await httpClient.GetAsync($"http://localhost:5099/api/RouteStop/{routeId}"))
					{
						string apiResponse = await response.Content.ReadAsStringAsync();
						RouteStops = (JsonConvert.DeserializeObject<List<RouteStopListDTO>>(apiResponse)).ToList();

						LastRBr = RouteStops.Max(x => x.Rbr);
					}
				}
				catch (Exception e)
				{
					ErrorMessage = "Lista stanica je trenutno nedostupna, pokušajte kasnije";
				}
			}
		}

		public async Task OnPostDeleteRouteStopAsync(int routeId, int stanicaId, int RBr)
		{
			using (var httpClient = new HttpClient())
			{
				try
				{
					using (HttpResponseMessage response = await httpClient.GetAsync($"http://localhost:5099/api/RouteStop/{routeId}"))
					{
						string apiResponse = await response.Content.ReadAsStringAsync();
						RouteStops = (JsonConvert.DeserializeObject<List<RouteStopListDTO>>(apiResponse)).ToList();

					}
					
					foreach(var s in RouteStops)
					{
						if(s.Id == stanicaId && s.Rbr == RBr)
						{
							using (HttpResponseMessage response2 = await httpClient.DeleteAsync($"http://localhost:5099/api/RouteStop?id={s.Id}"))
							{
                                string apiResponse = await response2.Content.ReadAsStringAsync();
                               
                            }
                            
                        }
					}

                }
				catch (Exception e)
				{
					ErrorMessage = "Lista stanica je trenutno nedostupna, pokušajte kasnije";
                }


			}
            using (var httpClient = new HttpClient())
            {
                try
                {
                    using (HttpResponseMessage response = await httpClient.GetAsync($"http://localhost:5099/api/Route/{routeId}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        try
                        {
                            Route = JsonConvert.DeserializeObject<RouteDTO>(apiResponse);

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
            }

            using (var httpClient = new HttpClient())
            {
                try
                {
                    using (HttpResponseMessage response = await httpClient.GetAsync("http://localhost:5099/api/Stop"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var _stops = (JsonConvert.DeserializeObject<List<StopGetBasicDTO>>(apiResponse)).ToList();

                        Stops = _stops.ToList();

                    }
                }
                catch (Exception e)
                {
                    ErrorMessage = "Lista stanica je trenutno nedostupna, pokušajte kasnije";
                }
            }

            using (var httpClient = new HttpClient())
            {
                try
                {
                    using (HttpResponseMessage response = await httpClient.GetAsync($"http://localhost:5099/api/RouteStop/{routeId}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        RouteStops = (JsonConvert.DeserializeObject<List<RouteStopListDTO>>(apiResponse)).ToList();

                        LastRBr = RouteStops.Max(x => x.Rbr);
                    }
                }
                catch (Exception e)
                {
                    ErrorMessage = "Lista stanica je trenutno nedostupna, pokušajte kasnije";
                }
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

            using (var httpClient = new HttpClient())
            {
                try
                {
                    using (HttpResponseMessage response = await httpClient.GetAsync($"http://localhost:5099/api/Route/{RouteId}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        try
                        {
                            Route = JsonConvert.DeserializeObject<RouteDTO>(apiResponse);

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
            }

            using (var httpClient = new HttpClient())
            {
                try
                {
                    using (HttpResponseMessage response = await httpClient.GetAsync("http://localhost:5099/api/Stop"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var _stops = (JsonConvert.DeserializeObject<List<StopGetBasicDTO>>(apiResponse)).ToList();

                        Stops = _stops.ToList();
						StanicaList = Stops.Select(row => new SelectListItem() { Value = row.Id.ToString(), Text=row.Name }).ToList();

                    }
                }
                catch (Exception e)
                {
                    ErrorMessage = "Lista stanica je trenutno nedostupna, pokušajte kasnije";
                }
            }

            using (var httpClient = new HttpClient())
            {
                try
                {
                    using (HttpResponseMessage response = await httpClient.GetAsync($"http://localhost:5099/api/Route/{RouteId}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        RouteStops = (JsonConvert.DeserializeObject<List<RouteStopListDTO>>(apiResponse)).ToList();

                        LastRBr = RouteStops.Max(x => x.Rbr);
                    }
                }
                catch (Exception e)
                {
                    ErrorMessage = "Lista stanica je trenutno nedostupna, pokušajte kasnije";
                }
            }
			return Page();
        }

	}
}