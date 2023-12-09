using Microsoft.AspNetCore.Identity;
using TimeTable.Shared.Dto;
using TimeTable.Shared.DTO;
using TimeTable.Shared.DTO.User;

namespace TimeTable.Api.Service;
public interface IAuthenticationService
{
	Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration);
	Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
	Task<TokenDto> CreateToken(bool populateExp);
	Task<TokenDto> RefreshToken(TokenDto tokenDto);
}