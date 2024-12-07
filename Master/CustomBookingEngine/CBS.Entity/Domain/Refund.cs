using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBS.Entity.Domain
{
    public class Refund
    {
        public Guid RefundId { get; set; } = Guid.NewGuid();
        public Guid PaymentId { get; set; }
        public Payment Payment { get; set; }
        public decimal RefundAmount { get; set; }
        public DateTime RefundDate { get; set; }
        public string Reason { get; set; }
    }

}
