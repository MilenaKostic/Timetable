using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using TimeTable.Api.Entities.Models;
using TimeTable.Api.Interfaces;

namespace TimeTable.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ShapeController : ControllerBase
	{
		IRepositoryManager _repository;

		public ShapeController(IRepositoryManager repository)
		{
			_repository = repository;
		}

		[HttpGet(Name = "AllShapes")]
		public async Task<IActionResult> GetShape()
		{
			var shapes = await _repository.Shape.GetAll();

			var shapesDTO = shapes.Select(row => new ShapeDTO()
			{
				Id = row.Id,
				RouteId = row.RouteId,
				RBr = row.RBr,
				Lat = row.Lat,
				Lon = row.Lon
				
			});


			return Ok(shapesDTO);
		}


		[HttpGet("{Id:int}", Name = "ShapeById")]
		public async Task<IActionResult> GetShapeById(int Id)
		{
			var s = await _repository.Shape.GetById(Id, false);
			if (s == null)
			{
				return NotFound();
			}

			

			return Ok( new ShapeDTO()
			{
				Id = s.Id,
				RouteId = s.RouteId,
				RBr = s.RBr,
				Lat = s.Lat,
				Lon = s.Lon

			});

		}

		[HttpDelete]
		public async Task<IActionResult> DeleteShape([FromQuery] int Id)
		{
			var rEntity = await _repository.Shape.GetById(Id, true);

			if (rEntity == null)
			{
				return NotFound();
			}

			var shapesGreaterThenRbr = await _repository.Shape.GetGreatRbrRoute(rEntity.RouteId, rEntity.RBr);

			_repository.Shape.DeleteShape(rEntity);

			foreach(var shape in shapesGreaterThenRbr)
			{
				shape.RBr = shape.RBr - 1; 
			}

			await _repository.SaveAsync();

			return NoContent();
		}


		[HttpPost]
		public async Task<IActionResult> CreateShape([FromBody] ShapePostDTO shape)
		{
			int? lastRbr = await _repository.Shape.GetLastRbrByRoute(shape.RouteId);

			var ShapeEntity = new Shape()
			{
				RouteId = shape.RouteId,
				RBr = (lastRbr ?? 0)+1,	
				Lat = shape.Lat,
				Lon	= shape.Lon
				
			};

			_repository.Shape.CreateShape(ShapeEntity);

			await _repository.SaveAsync();

			var shapebasic = new ShapeBasicDTO()
			{
				Id = ShapeEntity.Id,
				RouteId = ShapeEntity.RouteId
			};

			return CreatedAtRoute("ShapeById", new { Id = shapebasic.Id }, shapebasic);
		}

		[HttpGet("GetShapeByRoute")]
		public async Task<IActionResult> GetShapeByRoute(int routeId)
		{
			var shapes = await _repository.Shape.GetByRoute(routeId);

			var shapesDTO = shapes.Select(x => new ShapeDTO()
			{
				Id = x.Id,
				RouteId = x.RouteId,
				RBr = x.RBr,
				Lat = x.Lat,
				Lon = x.Lon
			
			}).ToList();

			return Ok(shapesDTO);
		}

	}
}
