using CBS.Entity.Domain;
using CSE.Entity.Domain;
using CSE.Generic.Controllers;
using CSE.Interfaces.IApi;
using CSE.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CBS.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingRoomDetailsController : GenericController<BookingRoomDetails, int>
    {
        public BookingRoomDetailsController(IBookingRoomDetailsService service, IApiResponse<object> apiResponse)
            : base(service, apiResponse)
        {
        }
    }
}