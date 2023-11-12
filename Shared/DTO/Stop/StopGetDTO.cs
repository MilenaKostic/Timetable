using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTO
{
    public class StopGetDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
    }
}
