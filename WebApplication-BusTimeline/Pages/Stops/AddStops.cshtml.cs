﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Shared.DTO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using WebApplication_BusTimeline.Service;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WebApplication_BusTimeline.Pages.Stops
{
	[Authorize]
	public class AddStopsModel : PageModel
    {
		public IServiceManager _service;
		public string? ErrorMessage {  get; set; }

		public double lat {  get; set; }
		public double lon { get; set; }

		List<StopGetBasicDTO> stops = new List<StopGetBasicDTO>();

		public AddStopsModel(IServiceManager service)
		{
			_service = service;
		}
      
        public async Task OnGetAsync()
		{
         
		}

		public async Task OnPostAsync(double lat, double lon, string stopName)
		{			
			try
			{
				stops = (await _service.GetAllBasicStop()).ToList();					

				foreach (var s in stops)
				{
					if (s.Name == stopName)
					{
						ErrorMessage = "Već postoji stanica sa ovim imenom";
						return;
					}
				}
							
				if (lat == 0 || lon == 0)
				{
					ErrorMessage = "Izaberite mesto za dodavanje stanica";
				}
				else
				{
					StopPostDTO newStop = new StopPostDTO()
					{
						Name = stopName,
						Lat = lat,
						Lon = lon
					};

					var _resultNewStop = await _service.CreateStop(newStop);

					ErrorMessage = "Uspešno dodata stanica";

				}
					
			}
			catch (Exception e)
			{
				ErrorMessage = e.Message;
			}	

		}

	}
}
