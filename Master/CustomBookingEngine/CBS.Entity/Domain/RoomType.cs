using System;
namespace CBS.Entity.Domain
{
    public class RoomType
    {
        public Guid RoomTypeId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public decimal DefaultPrice { get; set; }
        public int Quantity { get; set; }
        public bool IsDeleted { get; set; }
        public string Description { get; set; }
        public int MaxAdult { get; set; }
        public int MaxChildren { get; set; }
        public int MaxPeople { get; set; }

        public Guid StructureId { get; set; }
        public Structure Structure { get; set; }

        // Relazioni
        public ICollection<Rate> Rates { get; set; }

    }
}
