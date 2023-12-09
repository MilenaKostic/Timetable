using System.ComponentModel.DataAnnotations.Schema;

namespace TimeTable.Api.Entities.Models
{
	public class RouteStop
	{
		public int Id { get; set; }
		[ForeignKey(nameof(Route))]
		public int RouteId { get; set; }
		public Route Route { get; set; }
		public int Rbr {  get; set; }
		[ForeignKey(nameof(Stop))]
		public int StopId { get; set; }
		public Stop Stop { get; set; }
		public int? TimeInterval { get; set; }
		public int? MetarDistance { get; set; }
	}
}
