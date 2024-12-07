using CBS.Core.Interfaces;
using CBS.Entity.Domain;
using CSE.Generic.Controllers;
using CSE.Interfaces.IApi;
using Microsoft.AspNetCore.Mvc;

namespace CBS.WebAPI.Controllers
{
    public class FacilitiesController : GenericController<Facilities, int>
    {
        private readonly IFacilitiesService _facilitiesService;

        public FacilitiesController(IFacilitiesService service, IApiResponse<object> apiResponse)
                    : base(service, apiResponse)
        {
            _facilitiesService = service;
        }

    }
}
