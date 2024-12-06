using CBS.Entity.Domain;
using CSE.Generic.Controllers;
using CSE.Interfaces.IApi;
using CSE.Extension.Api;
using Microsoft.AspNetCore.Mvc;

namespace CBS.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomTypeController : GenericController<RoomType, int>
    {
        private readonly IRoomTypeService _roomTypeService;

        public RoomTypeController(IRoomTypeService service, IApiResponse<object> apiResponse)
            : base(service, apiResponse)
        {
            _roomTypeService = service;
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchRoomTypes(int adult, int children, DateTime checkInDate, DateTime checkOutDate)
        {
            var roomTypes = _roomTypeService.SearchRoomTypes(adult, children, checkInDate, checkOutDate);
            _apiResponse.Data = roomTypes;
            return _apiResponse.ToActionResult();           
        }
    }
}