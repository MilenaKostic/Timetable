using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTable.Api.Interfaces;
using Shared.DTO;
using TimeTable.Api.Entities.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
			var r = await _repository.Route.GetById(Id, false);

			if (r == null)
			{
				return NotFound();
			}

			var routeStop = r.RouteStops.Select(row => new RouteStopListDTO()
			{
				Id = row.Id,
				Rbr = row.Rbr,
				Stop = new StopDTO()
				{
					Id = row.Stop.Id,
					Name = row.Stop.StopName,
					Lat = row.Stop.StopLat,
					Lon = row.Stop.StopLon
				}
			}).ToList();

			return Ok(routeStop); 
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

			var stopsOnRoute = await _repository.RouteStop.GetByRouteId(rEntity.RouteId, true);

			var routeStopsGreater = await _repository.RouteStop.GetGreatRbrRoute(rEntity.RouteId, rEntity.Rbr);

			foreach (var r in routeStopsGreater)
			{
				r.Rbr = r.Rbr -1;
			}


			_repository.RouteStop.DeleteRouteStop(rEntity);
			await _repository.SaveAsync();

			return NoContent();
		}

		[HttpPost]
		public async Task<IActionResult> CreateRouteStop([FromBody] RouteStopPostDTO routeStop)
		{
			switch (routeStop.PositionId)
			{
				case 1:
					{
						var stopsOnRoute = await _repository.RouteStop.GetByRouteId(routeStop.RouteId, true);

						var routeStopsGreater = await _repository.RouteStop.GetGreatRbrRoute(routeStop.RouteId, 1);

						foreach(var r in routeStopsGreater)
						{
							r.Rbr = r.Rbr + 1; 
						}

						await _repository.SaveAsync();

						var RouteStopEntity = new RouteStop()
						{
							RouteId = routeStop.RouteId,
							Rbr = 1,
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

				case 2:
					{
						var stopsOnRoute = await _repository.RouteStop.GetByRouteId(routeStop.RouteId, true);

						var routeStopsGreater = await _repository.RouteStop.GetGreatRbrRoute(routeStop.RouteId, routeStop.SelectRbr.Value);

						var _selRbr = routeStop.SelectRbr ?? 0;

						foreach (var r in routeStopsGreater)
						{
							r.Rbr = r.Rbr + 1;
						}

						await _repository.SaveAsync();

						var RouteStopEntity = new RouteStop()
						{
							RouteId = routeStop.RouteId,
							Rbr = _selRbr ,
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


				case 3:
					{
						var stopsOnRoute = await _repository.RouteStop.GetByRouteId(routeStop.RouteId, true);

						var routeStopsGreater = await _repository.RouteStop.GetGreatRbrRoute(routeStop.RouteId, routeStop.SelectRbr.Value+1);

						var _selRbr = routeStop.SelectRbr ?? 0;

						foreach (var r in routeStopsGreater)
						{
							r.Rbr = r.Rbr + 1;
						}

						await _repository.SaveAsync();

						var RouteStopEntity = new RouteStop()
						{
							RouteId = routeStop.RouteId,
							Rbr = _selRbr + 1,
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

				case 4:
					{
						var stopsOnRoute = await _repository.RouteStop.GetByRouteId(routeStop.RouteId, false);

						List<RouteStop> stopsOnRouteList = stopsOnRoute.ToList();
						var broj = stopsOnRouteList.Count;

						var _selRbr = routeStop.SelectRbr ?? 0;

						var RouteStopEntity = new RouteStop()
						{
							RouteId = routeStop.RouteId,
							Rbr = broj +1,
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
			return BadRequest();

			
		}


	}
}
