using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBS.Entity.Domain
{
    /// <summary>
    /// Sospesi
    /// </summary>
    public class Suspended
    {
        public Guid SuspendedId { get; set; } = Guid.NewGuid();
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; } // Data di scadenza per il pagamento
        public string Description { get; set; }
    }

}
