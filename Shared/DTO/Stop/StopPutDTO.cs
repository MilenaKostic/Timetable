using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTO
{
    public class StopPutDTO
    {
        public string? Name { get; set; }
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
    }
}
