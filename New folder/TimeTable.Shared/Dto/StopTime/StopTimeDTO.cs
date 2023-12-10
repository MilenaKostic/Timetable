using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTable.Shared.DTO
{
    public class StopTimeDTO
    {
        public int Id { get; set; }
        public int StopId { get; set; }
        public int StopSequence { get; set; }
        public int TripId { get; set; }
    }
}
