using CBS.Entity.Domain;
using CSE.Entity.Domain;
using CSE.Generic.Controllers;
using CSE.Interfaces.IApi;
using CSE.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CBS.WebAPI.Controllers
{
    public class BookingController : GenericController<Booking, int>
    {
        public BookingController(IGenericService<Booking, int> service, IApiResponse<object> apiResponse)
            : base(service, apiResponse)
        {
        }
    }
}
