namespace CBS.Entity.Domain
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }
        public decimal ServiceAmount { get; set; }
        public decimal RoomAmount { get; set; }
        public bool IsCanceled { get; set; }
        public int? CouponId { get; set; }
    }
}
