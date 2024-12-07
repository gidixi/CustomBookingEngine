using System;
namespace CBS.Entity.Domain
{
    public class BookingServiceDetails
    {
        public int BookingServiceDetailsId { get; set; }
        public Guid BookingId { get; set; }
        public int ServiceId { get; set; }
        public int ServiceQuantity { get; set; }
        public decimal ServicePrice { get; set; }
    }
}
