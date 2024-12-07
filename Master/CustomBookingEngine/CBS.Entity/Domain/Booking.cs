using CBS.Entity.Enum;

namespace CBS.Entity.Domain
{
    public class Booking
    {
        public Guid BookingId { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }
        public decimal ServiceAmount { get; set; }
        public decimal RoomAmount { get; set; }
        public bool IsCanceled { get; set; }
        public int? CouponId { get; set; }


        // Relazione con Structure
        public Guid StructureId { get; set; }
        public Structure Structure { get; set; }
        public BookingState BookingState { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Deposit> Deposits { get; set; }
        public ICollection<TouristTax> TouristTaxes { get; set; }

    }
}
