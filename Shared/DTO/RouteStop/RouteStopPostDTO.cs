using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTO
{
	public class RouteStopPostDTO
	{
		public int RouteId { get; set; }
		public int PositionId {  get; set; } //1-prvi 2-pre selektovane 3-posle selektovane 4-zadnji
		public int StopId { get; set; }
		public int? TimeInterval { get; set; }
		public int? MetarDistance { get; set; }
	}
}
