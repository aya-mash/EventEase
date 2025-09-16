namespace EventEaseAdmin.Models
{

    public class Booking
    {
        public Guid BookingId { get; set; }
        public long EventId { get; set; }
        public long VenueId { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.UtcNow;
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public string Status { get; set; } = string.Empty;
    }

}
