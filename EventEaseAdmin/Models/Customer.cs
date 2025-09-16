using System.ComponentModel.DataAnnotations;

namespace EventEaseAdmin.Models
{

    public class Customer
    {
        public Guid CustomerId { get; set; }
        [Required, StringLength(100)]
        public string FullName { get; set; }
        [Required, StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(20)]
        public string? Phone { get; set; }
        [StringLength(100)]
        public string? Organization { get; set; }
    }
}
