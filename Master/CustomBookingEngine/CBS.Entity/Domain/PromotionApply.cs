using System;
namespace CBS.Entity.Domain
{
    public class PromotionApply
    {
        public int PromotionApplyId { get; set; }
        public int PromotionId { get; set; }
        public Guid RoomTypeId { get; set; }
    }
}
