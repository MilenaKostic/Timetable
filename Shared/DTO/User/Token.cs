using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTO
{
	public record TokenDto(string AccessToken, string RefreshToken);
	public record TokenBasicDto(string Token);
}
