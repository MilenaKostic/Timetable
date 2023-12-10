using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO; 
using TimeTable.Api.Service;

namespace TimeTable.Api.Controllers;


public class AuthenticationController : ControllerBase
{
	private readonly IAuthenticationService _service;

	public AuthenticationController(IAuthenticationService service) => _service = service;

	[HttpPost("Create")]
	public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDTO userForRegistration)
	{
		var result = await _service.RegisterUser(userForRegistration);
		if (!result.Succeeded)
		{
			foreach (var error in result.Errors)
			{
				ModelState.TryAddModelError(error.Code, error.Description);
			}
			return BadRequest(ModelState);
		}

		return StatusCode(201);
	}

	[HttpPost("login")]
	public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDTO user)
	{
		if (!await _service.ValidateUser(user))
			return Unauthorized();

		var tokenDto = await _service.CreateToken(populateExp: true);

		return Ok(new TokenBasicDto(tokenDto.AccessToken));
	}
}
