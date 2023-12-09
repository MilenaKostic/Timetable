using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTable.Api.Entities.Models;
using TimeTable.Api.Interfaces;
using TimeTable.Shared.DTO;

namespace TimeTable.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StopController : ControllerBase
	{
		IRepositoryManager _repository;

		public StopController(IRepositoryManager repository)
		{
			_repository = repository;
		}

		[HttpGet(Name = "AllStops")]
		public async Task<IActionResult> GetStop()
		{
			var s = await _repository.Stop.GetAll();
			return Ok(s);
		}

		[HttpGet("{Id:int}", Name = "StopById")]
		public async Task<IActionResult> GetStopById(int Id)
		{
			var s = await _repository.Stop.GetById(Id, false);
			if (s == null)
			{
				return NotFound();
			}

			return Ok(new StopDTO()
			{
				Id = s.Id,
				Name = s.StopName,
				Lat = s.StopLat,
				Lon = s.StopLon
			});

		}

		[HttpGet("{Name}", Name = "StopByName")]
		public async Task<IActionResult> GetStopByName(string Name)
		{
			var s = await _repository.Stop.GetByName(Name);

			if (s == null)
			{
				return NotFound();
			}

			return Ok(new StopDTO()
			{
				Id = s.Id,
				Name = s.StopName,
				Lat = s.StopLat,
				Lon = s.StopLon
			});
		}

		[HttpPut]
		public async Task<IActionResult> StopUpdate([FromBody] StopPutDTO stop, [FromQuery] int Id)
		{
			var rEntity = await _repository.Stop.GetById(Id, true);

			if (rEntity == null)
			{
				return NotFound();
			}

			rEntity.StopName = stop.Name;
			rEntity.StopLat = stop.Lat;
			rEntity.StopLon = stop.Lon;

			await _repository.SaveAsync();

			return NoContent();


		}

		[HttpDelete()]
		public async Task<IActionResult> Delete([FromQuery] int Id)
		{
			var rEntity = await _repository.Stop.GetById(Id, true);

			if (rEntity == null)
			{
				return NotFound();
			}

			_repository.Stop.DeleteStop(rEntity);

			await _repository.SaveAsync();

			return NoContent();
		}

	}
}
