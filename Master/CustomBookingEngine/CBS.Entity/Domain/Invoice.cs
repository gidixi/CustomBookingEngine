using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBS.Entity.Domain
{
    public class Invoice
    {
        public Guid InvoiceId { get; set; } = Guid.NewGuid();
        public Guid BookingId { get; set; }
        public Booking Booking { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Taxes { get; set; }
        public decimal Discounts { get; set; }
        public decimal FinalAmount { get; set; } // Totale dopo tasse e sconti
        public bool IsPaid { get; set; }
    }

}
