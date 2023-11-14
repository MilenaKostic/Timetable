using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTO.User
{
    public class UserPostDTO
    {
        public string name { get; set; }
        public string lastname { get; set; }
        public string? address { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
