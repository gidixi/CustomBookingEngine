using CBS.Entity.Domain;
using CSE.Generic.Controllers;
using CSE.Interfaces.IApi;
using CSE.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CBS.WebAPI.Controllers
{
    public class NotificationController : GenericController<Notification, Guid>
    {
        public NotificationController(IGenericService<Notification, Guid> service, IApiResponse<object> apiResponse) : base(service, apiResponse)
        {
        }
    }
}
