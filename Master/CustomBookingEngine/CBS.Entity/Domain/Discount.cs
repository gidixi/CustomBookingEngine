using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBS.Entity.Domain
{
    public class Discount
    {
        public Guid DiscountId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public decimal Percentage { get; set; } // Percentuale di sconto
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsGlobal { get; set; } // Applicabile a tutte le prenotazioni o specifiche
    }

}
