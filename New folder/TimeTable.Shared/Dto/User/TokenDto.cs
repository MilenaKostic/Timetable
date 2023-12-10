using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Shared.Dto;


public record TokenDto(string AccessToken, string RefreshToken);
public record TokenBasicDto(string Token);