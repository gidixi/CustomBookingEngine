using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBS.Entity.Domain
{
    public class Tax
    {
        public Guid TaxId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public decimal Percentage { get; set; } // Percentuale della tassa
        public bool IsIncludedInPrice { get; set; } // Indica se è già inclusa nel prezzo
    }

}
