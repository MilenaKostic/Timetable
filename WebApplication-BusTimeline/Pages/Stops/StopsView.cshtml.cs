using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
                try
                {
                    SelectedStop = await _service.GetStopById(StanicaId.Value);
                }
                catch (Exception e)
                {
                    ErrorMessage = e.Message;
                }
            }

        }

        
    }
}
