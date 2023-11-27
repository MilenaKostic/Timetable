namespace WebAPI.Models
{
    public class StopTime
    {
        public int Id { get; set; }
        public int StopId { get; set; }
        public int StopSequence {  get; set; }
        public int TripId { get; set; }
    }
}
