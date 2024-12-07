using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBS.Entity.Domain
{
    public class Payment
    {
        public Guid PaymentId { get; set; } = Guid.NewGuid();
        public Guid BookingId { get; set; }
        public Booking Booking { get; set; }
        public decimal Amount { get; set; }
        public Guid CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public DateTime PaymentDate { get; set; }
        public Guid PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string TransactionId { get; set; } // ID transazione del gateway di pagamento
    }


}
