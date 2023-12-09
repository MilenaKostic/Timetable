﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTable.Api.Interfaces;
using TimeTable.Api.Repositories;
using TimeTable.Shared.DTO;
using TimeTable.Shared.DTO.Route;

namespace TimeTable.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RouteController : ControllerBase
	{
		IRepositoryManager _repository;

		public RouteController(IRepositoryManager repository)
		{
			_repository = repository;
		}

	

		[HttpGet(Name = "RoutesAll")]
		public async Task<IActionResult> GetRoute()
		{
			var r = await _repository.Route.GetAll();
			return Ok(r);
		}

		[Authorize(Roles = "User")]

		[HttpGet("{Id:int}", Name = "RouteById")]
		public async Task<IActionResult> GetById(int Id)
		{
			var r = await _repository.Route.GetById(Id, false);

			if (r == null)
			{
				return NotFound();
			}

			return Ok(new RouteDTO()
			{
				Id = r.Id,
				Name = r.RouteName,
				Color = r.RouteColor
			});

		}

		[HttpGet("RouteByName")]
		public async Task<IActionResult> GetRouteByName(String name)
		{
			var r = await _repository.Route.GetByName(name);

			if (r == null)
			{
				return NotFound();
			}

			return Ok(new RouteDTO()
			{
				Id = r.Id,
				Name = r.RouteName,
				Color = r.RouteColor
			});
		}

		[HttpPut()]
		public async Task<IActionResult> RouteUpdate([FromBody] RoutePutDTO route, [FromQuery] int id)
		{
			var rEntity = await _repository.Route.GetById(id, true);

			if (rEntity == null)
			{
				return NotFound();
			}

			rEntity.RouteName = route.Name;
			rEntity.RouteColor = route.Color;

			await _repository.SaveAsync();

			return NoContent();


		}

		[HttpDelete()]
		public async Task<IActionResult> Delete([FromQuery] int id)
		{
			var rEntity = await _repository.Route.GetById(id, true);

			if (rEntity == null)
			{
				return NotFound();
			}

			_repository.Route.DeleteRoute(rEntity);

			await _repository.SaveAsync();

			return NoContent();
		}




	}
}
