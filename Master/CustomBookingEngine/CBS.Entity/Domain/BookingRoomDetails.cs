using System;
namespace CBS.Entity.Domain
{
    public class BookingRoomDetails
    {
        public int BookingRoomDetailsId { get; set; }
        public int BookingId { get; set; }
        public int RoomTypeId { get; set; }
        public int RoomQuantity { get; set; }
        public DateTime Date { get; set; }
        public decimal RoomPrice { get; set; }
    }
}
