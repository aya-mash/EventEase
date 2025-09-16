﻿namespace EventEaseAdmin.Models
{

    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Organization { get; set; } = string.Empty;
    }

}
