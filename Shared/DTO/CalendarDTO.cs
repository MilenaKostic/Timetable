﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTO
{
    public class CalendarDTO
    {
        public bool monday { get; set; }
        public bool tuesday { get; set; }
        public bool wednesday { get; set; }
        public bool thursday { get; set; }
        public bool friday { get; set; }
        public bool saturday { get; set; }
        public bool sunday { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

    }
}
