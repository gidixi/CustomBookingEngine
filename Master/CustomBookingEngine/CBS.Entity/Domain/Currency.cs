using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBS.Entity.Domain
{
    public class Currency
    {
        public Guid CurrencyId { get; set; } = Guid.NewGuid();
        public string Code { get; set; } // Es. "USD", "EUR"
        public string Name { get; set; } // Es. "United States Dollar"
        public decimal ExchangeRate { get; set; } // Tasso di cambio rispetto alla valuta base
        public bool IsBaseCurrency { get; set; } // Indica se è la valuta base
    }
}
