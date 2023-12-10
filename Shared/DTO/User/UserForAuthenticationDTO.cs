using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

public class UserForAuthenticationDTO
{
	[Required(ErrorMessage = "User name is required")]
	public string? UserName { get; init; }
	[Required(ErrorMessage = "Password name is required")]
	public string? Password { get; init; }
}