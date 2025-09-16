namespace EventEaseAdmin.Models
{
    public class Venue
    {
        public long VenueId { get; set; }
        public string VenueName { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; } = true;
    }

}
