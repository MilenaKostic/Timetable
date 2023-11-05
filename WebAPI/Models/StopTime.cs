namespace WebAPI.Models
{
    public class StopTime
    {
        public int Id { get; set; }
        public int tripId { get; set; }
        public int stopId { get; set; }
        public int stopSequence {  get; set; }
    }
}
