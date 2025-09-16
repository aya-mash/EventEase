namespace EventEaseAdmin.Models
{

    public class Event
    {
        public long EventId { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime? StartAt { get; set; }
        public DateTime? EndAt { get; set; }
        public string Description { get; set; }
        public long? VenueId { get; set; }
        public Guid? CustomerId { get; set; }
    }

}
