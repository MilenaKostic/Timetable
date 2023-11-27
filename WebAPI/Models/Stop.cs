namespace WebAPI.Models
{
    public class Stop
    {
        public int Id { get; set; }
        public string? StopName { get; set; }
        public double StopLat {get; set;}
        public double StopLon {get; set;}
        public ICollection<RouteStop> RouteStops { get; set; }

    }
}
