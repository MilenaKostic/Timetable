using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
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
	}
}
