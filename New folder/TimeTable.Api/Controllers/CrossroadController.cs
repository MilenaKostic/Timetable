using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;

namespace TimeTable.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CrossroadController : ControllerBase
	{
		[HttpGet]
		public IActionResult GetAll()
		{
			var crossroadDto = new List<CrossroadDTO>()
			{
				new CrossroadDTO{ Id = 1, Name ="Raskrsnica 1", Lat=44.972927, Lon=19.599169 },
				new CrossroadDTO{ Id = 2, Name= "Raskrsnica 2", Lat=44.970503, Lon=19.637003 },
				new CrossroadDTO{ Id = 2, Name= "Raskrsnica 3", Lat=44.968638, Lon=19.608513 },
				new CrossroadDTO{ Id = 2, Name= "Raskrsnica 4", Lat=44.967031, Lon=19.609958 },
				new CrossroadDTO{ Id = 2, Name= "Raskrsnica 5", Lat=44.967617, Lon=19.605412 },
				new CrossroadDTO{ Id = 2, Name= "Raskrsnica 6", Lat=44.972322, Lon=19.609499 },
			};

			return Ok(crossroadDto);




		}
	}
}






