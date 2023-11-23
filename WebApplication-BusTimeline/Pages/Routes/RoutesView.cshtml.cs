using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Shared.DTO;

namespace WebApplication_BusTimeline.Pages.Routes
{
	public class MapModel : PageModel
	{
		[BindProperty(SupportsGet = true)]
		public string routeName { get; set; }
		public List<StopDTO> LstStops { get; set; }

		public async Task OnGetAsync(string routeName)
		{
			if(routeName != null)
			{
				using(var httpClient = new HttpClient())
				{
					try
					{
						using (HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:7151/Stop/ByRouteBelong:{routeName}"))
						{
							string apiResponse = await response.Content.ReadAsStringAsync();						
							try
							{
								var _stops = JsonConvert.DeserializeObject<List<StopDTO>>(apiResponse);
								LstStops = _stops.ToList();
							}
							catch (JsonSerializationException)
							{
								var singleStop = JsonConvert.DeserializeObject<StopDTO>(apiResponse);
								LstStops = new List<StopDTO> { singleStop };
							}
						}

                    }
					catch(Exception ex)
					{
						//Osmisli
					}
				}
			}

		}

	}
	

}

