using System;
namespace CBS.Entity.Domain
{
    public class RoomType
    {
        public int RoomTypeId { get; set; }
        public string Name { get; set; }
        public decimal DefaultPrice { get; set; }
        public int Quantity { get; set; }
        public bool IsDeleted { get; set; }
        public string Description { get; set; }
        public int MaxAdult { get; set; }
        public int MaxChildren { get; set; }
        public int MaxPeople { get; set; }
    }
}
