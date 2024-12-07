using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBS.Entity.Domain
{

    /// <summary>
    /// Tassa di Soggiorno
    /// </summary>
    public class TouristTax
    {
        public Guid TouristTaxId { get; set; } = Guid.NewGuid();
        public Guid StructureId { get; set; }
        public Guid BookingId { get; set; }
        public Structure Structure { get; set; }
        public Booking Booking { get; set; }
        public decimal Amount { get; set; }
        public DateTime TaxDate { get; set; }
    }

}
