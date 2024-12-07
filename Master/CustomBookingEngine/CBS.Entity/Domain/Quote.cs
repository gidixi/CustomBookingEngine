using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBS.Entity.Domain
{
    public class Quote
    {
        public Guid QuoteId { get; set; } = Guid.NewGuid();
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal EstimatedAmount { get; set; }
        public string Description { get; set; }
    }

}
