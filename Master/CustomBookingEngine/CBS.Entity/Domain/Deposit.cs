using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBS.Entity.Domain
{
    /// <summary>
    /// Acconto/Caparra
    /// </summary>
    public class Deposit
    {
        public Guid DepositId { get; set; } = Guid.NewGuid();
        public Guid BookingId { get; set; }
        public Booking Booking { get; set; }
        public decimal Amount { get; set; }
        public DateTime DepositDate { get; set; }
        public bool IsRefundable { get; set; } // Indica se l'acconto è rimborsabile
    }

}
