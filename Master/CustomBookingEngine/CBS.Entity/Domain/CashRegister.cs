using CBS.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBS.Entity.Domain
{
    public class CashRegister
    {
        public Guid CashRegisterId { get; set; } = Guid.NewGuid();
        public Guid StructureId { get; set; }
        public Structure Structure { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; } // Es. "Pagamento tassa di soggiorno"
        public CashRegisterType TransactionType { get; set; } // Entrata o Uscita
    }

}
