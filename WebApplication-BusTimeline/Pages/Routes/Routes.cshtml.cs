using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication_BusTimeline.Pages.Routes
{
    public class MapModel : PageModel
    {
        private readonly ILogger<MapModel> _logger;

        public MapModel(ILogger<MapModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
        }
    }
}
