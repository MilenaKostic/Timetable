using Microsoft.AspNetCore.Identity;

namespace TimeTable.Api.Entities.Models;

public class User : IdentityUser
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string? RefreshToken { get; set; }
	public DateTime RefreshTokenExpiryTime { get; set; }
}