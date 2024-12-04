using System;
namespace CBS.Entity.Domain
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }
    }
}
