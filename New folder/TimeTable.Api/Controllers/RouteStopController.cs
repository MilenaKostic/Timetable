using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTable.Api.Interfaces;
using Shared.DTO;
using TimeTable.Api.Entities.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace TimeTable.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RouteStopController : ControllerBase
	{
		IRepositoryManager _repository;

		public RouteStopController(IRepositoryManager repository)
		{
			_repository = repository;
		}


		[HttpGet(Name = "RouteStopsAll")]
		public async Task<IActionResult> GetRouteStops()
		{
			var routestops = await _repository.RouteStop.GetAll();

			var routeStopDTO = routestops.Select(row => new RouteStopGetDTO()
			{
				Id = row.Id,
				Rbr = row.Rbr

			});
			return Ok(routeStopDTO);
		}


		//[Authorize(Roles = "User")]

		[HttpGet("ByRouteId")]
		public async Task<IActionResult> GetByRouteId(int Id)
		{
			var r = await _repository.RouteStop.GetByRouteId(Id, false);

			if (r == null)
			{
				return NotFound();
			}

			return Ok(new RouteStopListDTO()
			{
				Id = r.Id,
				Rbr = r.Rbr,
				Stop = new StopDTO()
				{
					Id = r.Stop.Id,
					Name = r.Stop.StopName,
					Lat = r.Stop.StopLat,
					Lon = r.Stop.StopLon
				}
			});


		}


		[HttpGet("{Id:int}", Name = "RouteStopById")]
		public async Task<IActionResult> GetById(int Id)
		{
			var r = await _repository.RouteStop.GetById(Id, false);

			if (r == null)
			{
				return NotFound();
			}

			return Ok(new RouteStopListDTO()
			{
				Id = r.Id,
				Rbr = r.Rbr,
				Stop = new StopDTO()
				{
					Id = r.Stop.Id,
					Name = r.Stop.StopName,
					Lat = r.Stop.StopLat,
					Lon = r.Stop.StopLon
				}
			});
			return Ok();

		}


		[HttpDelete()]
		public async Task<IActionResult> Delete([FromQuery] int id)
		{
			var rEntity = await _repository.RouteStop.GetById(id, true);

			if (rEntity == null)
			{
				return NotFound();
			}

			_repository.RouteStop.DeleteRouteStop(rEntity);

			await _repository.SaveAsync();

			return NoContent();
		}

		[HttpPost]
		public async Task<IActionResult> CreateRouteSTop([FromBody] RouteStopPostDTO routeStop)
		{
			var RouteStopEntity = new RouteStop()
			{
				RouteId = routeStop.RouteId,
				StopId = routeStop.StopId,
				TimeInterval = routeStop.TimeInterval,
				MetarDistance = routeStop.MetarDistance,				

			};

			_repository.RouteStop.CreateRouteStop(RouteStopEntity);

			await _repository.SaveAsync();

			var routestopbasic = new RouteStopBasicDTO()
			{
				Id = RouteStopEntity.Id,
				Rbr = RouteStopEntity.Rbr

			};

			return CreatedAtRoute("RouteStopById", new { Id = routestopbasic.Id }, routestopbasic);
		}


	}
}
