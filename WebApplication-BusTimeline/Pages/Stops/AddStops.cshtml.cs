using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shared.DTO;
using WebAPI.Data;
using WebAPI.Models;

namespace WebApplication_BusTimeline.Pages.Stops
{
    public class AddStopsModel : PageModel
    {
		private readonly DataContext context;

        public double lat = -300;
        public double Long = -300;

		public string? ErrorMessage {  get; set; }

        public AddStopsModel(DataContext context)
        {
			this.context = context;
		}

        public async Task OnGetAsync(double? lat)
		{
            if(lat != -300 )
            {
				Console.WriteLine($"Vrednosti su {lat}");
				//??? Problem 
				
				

				
			}
            

         
		}
	}
}
