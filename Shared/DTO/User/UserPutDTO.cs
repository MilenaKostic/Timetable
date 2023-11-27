using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTO
{
    public class UserPutDTO
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string? Address { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
