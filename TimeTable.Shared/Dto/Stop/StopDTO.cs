﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTable.Shared.DTO
{
    public class StopDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
    }
}
