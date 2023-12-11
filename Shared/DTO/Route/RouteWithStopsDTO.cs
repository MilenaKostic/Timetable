using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTO
{
	public class RouteWithStopsDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Color { get; set; }
		public List<RouteStopListDTO> Stops { get; set;  }
	}
}
