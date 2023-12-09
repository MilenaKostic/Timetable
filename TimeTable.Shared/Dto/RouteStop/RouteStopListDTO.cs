using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTable.Shared.DTO
{
	public class RouteStopListDTO
	{
		public int Id { get; set; }
		public int Rbr { get; set; }
		public StopDTO Stop { get; set; }
	}
}
