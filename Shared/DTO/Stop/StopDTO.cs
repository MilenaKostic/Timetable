using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTO
{
    public class StopDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string RouteBelong { get; set;}
    }
}
