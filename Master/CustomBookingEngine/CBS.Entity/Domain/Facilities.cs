using System;
namespace CBS.Entity.Domain
{
    //Servizi in camera
    public class Facilities
    {
        public int FacilityId { get; set; }
        public string FacilityName { get; set; }
        public byte[] FacilityImage { get; set; }

        public Guid StructureId { get; set; }
        public Structure Structure { get; set; }

    }
}
