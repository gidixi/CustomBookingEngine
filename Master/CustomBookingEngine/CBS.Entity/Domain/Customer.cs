using System;

namespace CBS.Entity.Domain
{
    public class Customer
    {
        public Guid CustomerId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }

        // Relazioni
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Quote> Quotes { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Suspended> Suspendeds { get; set; }
    }
}
