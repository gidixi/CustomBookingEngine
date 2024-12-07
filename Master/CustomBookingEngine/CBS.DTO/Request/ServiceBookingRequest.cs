using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBS.DTO.Request
{
    public class ServiceBookingRequest
    {
        public int ServiceId { get; set; }
        public int ServiceQuantity { get; set; }
    }
}
