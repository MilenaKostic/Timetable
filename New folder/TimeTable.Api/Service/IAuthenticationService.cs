using Microsoft.AspNetCore.Identity;
using Shared.DTO;

namespace TimeTable.Api.Service;
public interface IAuthenticationService
{
	Task<IdentityResult> RegisterUser(UserForRegistrationDTO userForRegistration);
	public Task<bool> ValidateUser(UserForAuthenticationDTO userForAuth);
	Task<TokenDto> CreateToken(bool populateExp);
	Task<TokenDto> RefreshToken(TokenDto tokenDto);
}