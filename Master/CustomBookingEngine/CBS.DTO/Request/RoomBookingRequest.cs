using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBS.DTO.Request
{
    public class RoomBookingRequest
    {
        public int RoomTypeId { get; set; }
        public int RoomQuantity { get; set; }
    }
}
