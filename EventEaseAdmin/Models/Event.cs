using System.ComponentModel.DataAnnotations;

namespace EventEaseAdmin.Models
{

    public class Event
    {
        public long EventId { get; set; }
        [Required, StringLength(100)]
        public string EventName { get; set; }
        [Required]
        public DateTime EventDate { get; set; }
        public DateTime? StartAt { get; set; }
        public DateTime? EndAt { get; set; }
        [StringLength(500)]
        public string? Description { get; set; }
        public long? VenueId { get; set; }
        public Guid? CustomerId { get; set; }
    }

}
