using System;
namespace CBS.Entity.Domain
{
    public class RoomTypeImages
    {
        public Guid RoomTypeImageId { get; set; }
        public byte[] ImageData { get; set; }
        public Guid RoomTypeId { get; set; }
    }
}
