namespace WebAPI.Models
{
    public class Route
    {
        public int Id { get; set; }
        public string? RouteName { get; set; }
        public string? RouteColor { get; set; }
		public ICollection<RouteStop> RouteStops { get; set; }

	}
}
