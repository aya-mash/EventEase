using System.ComponentModel.DataAnnotations;

namespace EventEaseAdmin.Models
{
    public class Venue
    {
        public long VenueId { get; set; }
        [Required, StringLength(100)]
        public string VenueName { get; set; }
        [Required, StringLength(200)]
        public string Location { get; set; }
        [Range(1, 100000)]
        public int Capacity { get; set; }
        [StringLength(500)]
        public string? ImageUrl { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
