using System;
namespace CBS.Entity.Domain
{
    public class ServiceImages
    {
        public int ServiceImageId { get; set; }
        public byte[] ImageData { get; set; }
        public int ServiceId { get; set; }
    }
}
