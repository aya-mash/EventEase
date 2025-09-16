using System.ComponentModel.DataAnnotations;

namespace EventEaseAdmin.Models
{

    public class Booking
    {
        public Guid BookingId { get; set; }
        [Required]
        public long EventId { get; set; }
        [Required]
        public long VenueId { get; set; }
        [Required]
        public DateTime BookingDate { get; set; } = DateTime.UtcNow;
        [Required]
        public DateTime StartAt { get; set; }
        [Required]
        public DateTime EndAt { get; set; }
        [Required, StringLength(50)]
        public string Status { get; set; } = string.Empty;
    }

}
