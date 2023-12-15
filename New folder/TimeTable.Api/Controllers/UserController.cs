using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTable.Api.Entities.Models;
using TimeTable.Api.Interfaces;
using Shared.DTO;

namespace TimeTable.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		IRepositoryManager _repository;

		public UserController(IRepositoryManager repository)
		{
			_repository = repository;
		}


		[HttpGet(Name = "AllUsers")]
		public async Task<IActionResult> GetUser()
		{
			var u = await _repository.User.GetAll();
			return Ok(u);
		}


		[HttpGet("{Id:int}", Name = "UserById")]
		public async Task<IActionResult> GetUserById(int Id)
		{
			var u = await _repository.User.GetById(Id, false);
			if (u == null)
			{
				return NotFound();
			}

			return Ok(new UserDTO()
			{
				Name = u.FirstName,
				Lastname = u.LastName,
				Email = u.Email,
				Username = u.UserName,
				Password = u.PasswordHash
			});

		}


		[HttpGet("{Name}", Name = "UserByName")]
		public async Task<IActionResult> GetUserByName(string Name)
		{
			var u = await _repository.User.GetByName(Name);

			if (u == null)
			{
				return NotFound();
			}

			return Ok(new UserDTO()
			{
				Name = u.FirstName,
				Lastname = u.LastName,
				Email = u.Email,
				Username = u.UserName,
				Password = u.PasswordHash
			});
		}


		[HttpPut]
		public async Task<IActionResult> UserUpdate([FromBody] UserPutDTO user, [FromQuery] int Id)
		{
			var rEntity = await _repository.User.GetById(Id, true);

			if (rEntity == null)
			{
				return NotFound();
			}

			rEntity.UserName = user.Username;
			rEntity.FirstName = user.Name;
			rEntity.LastName = user.Lastname;
			rEntity.PasswordHash = user.Password;
			rEntity.Email = user.Email;

			await _repository.SaveAsync();

			return NoContent();


		}


		[HttpDelete()]
		public async Task<IActionResult> Delete([FromQuery] int Id)
		{
			var rEntity = await _repository.User.GetById(Id, true);

			if (rEntity == null)
			{
				return NotFound();
			}

			_repository.User.DeleteUser(rEntity);

			await _repository.SaveAsync();

			return NoContent();
		}



	}
}
