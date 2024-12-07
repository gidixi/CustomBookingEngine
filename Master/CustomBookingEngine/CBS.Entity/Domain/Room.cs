using CBS.Entity.Enum;
using System;
namespace CBS.Entity.Domain
{
    public class Room
    {
        public int RoomNumber { get; set; }
        public Guid RoomTypeId { get; set; }
        //public bool IsOccupied { get; set; }
        public RoomState RoomState { get; set; }

    }
}
