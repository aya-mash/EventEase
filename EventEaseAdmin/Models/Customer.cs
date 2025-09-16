namespace EventEaseAdmin.Models
{

    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Organization { get; set; }
    }

}
