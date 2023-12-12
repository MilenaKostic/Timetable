using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shared.DTO
{
	public class ShapeDTO
	{
		public int Id { get; set; }
		public int RouteId { get; set; }
		public int RBr { get; set; }
		public double Lat { get; set; }
		public double Lon { get; set; }

	}
}
