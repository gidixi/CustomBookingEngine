using System;
namespace CBS.Entity.Domain
{
    public class FacilitiesApply
    {
        public int FacilitiesApplyId { get; set; }
        public int FacilityId { get; set; }
        public Guid RoomTypeId { get; set; }
    }
}
