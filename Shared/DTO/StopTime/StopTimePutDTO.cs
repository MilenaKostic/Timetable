using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTO
{
    public class StopTimePutDTO
    {
        public int StopId { get; set; }
        public int StopSequence { get; set; }
        public int TripId { get; set; }
    }
}
