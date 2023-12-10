using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.Identity.Client;
using Newtonsoft.Json;
using Shared.DTO;
using WebApplication_BusTimeline.Service;

namespace WebApplication_BusTimeline.Pages.Stops
{
    public class StopsViewModel : PageModel
    {
        public IServiceManager _service;
        public Int32? StanicaId { get; set; }
        public List<StopGetBasicDTO> LstStops { get; set; }
        public StopDTO SelectedStop { get; set; }
        public string? ErrorMessage;

        public StopsViewModel(IServiceManager service)
        {
            _service = service;
        }


        public async Task OnGetAsync(string stanicaId)
        {
            try
            {
                LstStops = (await _service.GetAllBasicStop()).ToList();
            }
            catch(Exception e)
            {
                ErrorMessage = e.Message;
            }
            

            StanicaId = null;
            int _stanicaId = -1;

            if(Int32.TryParse(stanicaId, out _stanicaId))
            {
                StanicaId = _stanicaId;
            }

            if(StanicaId != null)
            {
                //using(var httpClient = new HttpClient())
                //{
                //    try
                //    {
                //        using (HttpResponseMessage response = await httpClient.GetAsync($"http://localhost:5099/api/Stop/{StanicaId}"))
                //        {
                //            string apiResponse = await response.Content.ReadAsStringAsync();
                //            SelectedStop = JsonConvert.DeserializeObject<StopDTO>(apiResponse);
                //        }
                //    }
                //    catch(Exception e)
                //    {
                //        ErrorMessage = "Željena stanica je trenutno nedostupna, pokušajte kasnije";
                //    }
                //}

                try
                {
                    
                    //SelectedStop = await _service.GetStopById(StanicaId);
                }
                catch (Exception e)
                {
                    ErrorMessage = e.Message;
                }
            }

        }

        
    }
}
