using System;
namespace CBS.Entity.Domain
{
    public class BookingRoomDetails
    {
        public Guid BookingRoomDetailsId { get; set; }
        public Guid BookingId { get; set; }
        public Guid RoomTypeId { get; set; }
        public int RoomQuantity { get; set; }
        public DateTime Date { get; set; }
        public decimal RoomPrice { get; set; }
    }
}
