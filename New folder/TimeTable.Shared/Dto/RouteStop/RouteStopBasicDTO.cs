using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTable.Shared.DTO
{
	public class RouteStopBasicDTO
	{
		public int Id { get; set; }
		public RouteGetBasicDTO Route { get; set; }
		public int Rbr { get; set; }
		public StopGetBasicDTO Stop { get; set; }

	}
}
