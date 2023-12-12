using System.ComponentModel.DataAnnotations.Schema;

namespace TimeTable.Api.Entities.Models
{
	public class Shape
	{
		public int Id { get; set; }

		[ForeignKey(nameof(Route))]
		public int RouteId { get; set; }
		public int RBr {  get; set; }
		public double Lat { get; set; }
		public double Lon { get; set; }

	}
}
