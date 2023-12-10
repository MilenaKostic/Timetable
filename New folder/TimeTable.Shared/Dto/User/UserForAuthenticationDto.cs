using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TimeTable.Shared.DTO.User;
public record UserForAuthenticationDto
{
	[Required(ErrorMessage = "User name is required")]
	public string? UserName { get; init; }
	[Required(ErrorMessage = "Password name is required")]
	public string? Password { get; init; }
}