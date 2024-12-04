using System;
namespace CBS.Entity.Domain
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public decimal Price { get; set; }
        public bool IsDeleted { get; set; }
        public string Description { get; set; }
    }
}
