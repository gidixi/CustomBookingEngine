using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBS.Entity.Domain
{
    public class PaymentMethod
    {
        public Guid PaymentMethodId { get; set; } = Guid.NewGuid();
        public string Name { get; set; } // Es. "Credit Card", "PayPal", "Bank Transfer"
        public string Description { get; set; } // Opzionale: descrizione del metodo di pagamento
        public bool IsActive { get; set; } // Indica se il metodo di pagamento è attivo
    }

}
