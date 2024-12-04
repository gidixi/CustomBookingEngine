using System;
namespace CBS.Entity.Domain
{
    public class RoomTypeImages
    {
        public int RoomTypeImageId { get; set; }
        public byte[] ImageData { get; set; }
        public int RoomTypeId { get; set; }
    }
}
