using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using Shared.DTO;

namespace WebApplication_BusTimeline.Pages.Stops
{
    public class StopsViewModel : PageModel
    {
        public Int32? StanicaId { get; set; }
        public List<StopGetBasicDTO> LstStops { get; set; }
        public StopDTO SelectedStop { get; set; }

        public async Task OnGetAsync(string stanicaId)
        {
            using(var httpClient = new HttpClient())
            {
                try
                {
                    using(HttpResponseMessage response = await httpClient.GetAsync("https://localhost:7151/Stop/AllStops"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var _stops = (JsonConvert.DeserializeObject<List<StopGetBasicDTO>>(apiResponse)).ToList();

                        LstStops = _stops.ToList();

                    }
                }
                catch(Exception e)
                {
                    //Osmisli 
                }
            }

            StanicaId = null;
            int _stanicaId = -1;

            if(Int32.TryParse(stanicaId, out _stanicaId))
            {
                StanicaId = _stanicaId;
            }

            if(StanicaId != null)
            {
                using(var httpClient = new HttpClient())
                {
                    try
                    {
                        using (HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:7151/Stop/ById:{StanicaId}"))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            SelectedStop = JsonConvert.DeserializeObject<StopDTO>(apiResponse);
                        }
                    }
                    catch(Exception e)
                    {
                        //Osmisli
                    }
                }
            }

        }

        
    }
}
