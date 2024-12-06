using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBS.DTO.Request
{
    public class BookingRequest
    {
        public int CustomerId { get; set; }
        public int? CouponId { get; set; }
        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }
        public int NumberofAdults { get; set; }
        public int NumberofChildren { get; set; }
        public List<RoomBookingRequest> RoomBookings { get; set; }
        public List<ServiceBookingRequest> ServiceBookings { get; set; }
    }
}
