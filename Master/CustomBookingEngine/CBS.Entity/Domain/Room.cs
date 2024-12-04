using System;
namespace CBS.Entity.Domain
{
    public class Room
    {
        public int RoomNumber { get; set; }
        public int RoomTypeId { get; set; }
        public bool IsOccupied { get; set; }
    }
}
