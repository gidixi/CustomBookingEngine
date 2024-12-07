using System;
namespace CBS.Entity.Domain
{
    public class Promotion
    {
        public int PromotionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal DiscountRates { get; set; }
        public bool IsDeleted { get; set; }
        public string PromotionName { get; set; }

        public Guid StructureId { get; set; }
        public Structure Structure { get; set; }

    }
}
