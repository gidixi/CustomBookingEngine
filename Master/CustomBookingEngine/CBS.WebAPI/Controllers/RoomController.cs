using CBS.Core.Interfaces;
using CBS.Entity.Domain;
using CSE.Generic.Controllers;
using CSE.Interfaces.IApi;
using Microsoft.AspNetCore.Mvc;

namespace CBS.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : GenericController<Room, int>
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService service, IApiResponse<object> apiResponse)
                    : base(service, apiResponse)
        {
            _roomService = service;
        }

    }
}
