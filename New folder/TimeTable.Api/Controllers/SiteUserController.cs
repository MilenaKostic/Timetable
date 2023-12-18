using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using System.Security.Cryptography;
using System.Text;
using TimeTable.Api.Entities.Models;
using TimeTable.Api.Interfaces;

namespace TimeTable.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SiteUserController : ControllerBase
	{
		IRepositoryManager _repository;

		public SiteUserController(IRepositoryManager repository)
		{
			_repository = repository;
		}

		[HttpPost]
		public async Task<IActionResult> CreateUser([FromBody] UserForRegistrationDTO user)
		{
			var UserEntity = new SiteUser()
			{
				FirstName = user.FirstName,
				LastName = user.LastName,
				Email = user.Email,
				Username = user.UserName,
				Password = ComputeSHA256Hash(user.Password)
			};

			static string ComputeSHA256Hash(string input)
			{
				using (SHA256 sha256 = SHA256.Create())
				{
					byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
					return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
				}
			}

			_repository.SiteUser.CreateUser(UserEntity);

			await _repository.SaveAsync();

			var userbasic = new UserGetBasicDTO()
			{
				Id = UserEntity.Id,
				Name = UserEntity.FirstName,
				Email = UserEntity.Email
			};

			return CreatedAtRoute("UserById", new { Id = userbasic.Id }, userbasic);
		}

		[HttpGet("{Name}", Name = "SiteUserByName")]
		public async Task<IActionResult> GetUserByName(string Name)
		{
			var u = await _repository.SiteUser.GetByName(Name);

			if (u == null)
			{
				return NotFound();
			}

			return Ok(new UserDTO()
			{
				Id = u.Id,
				Name = u.FirstName,
				Lastname = u.LastName,
				Email = u.Email,
				Username = u.Username,
				Password = u.Password
			});
		}
	}
}
