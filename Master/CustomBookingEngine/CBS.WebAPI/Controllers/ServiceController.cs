using CBS.Entity.Domain;
using CSE.Generic.Controllers;
using CSE.Interfaces.IApi;
using Microsoft.AspNetCore.Mvc;
using CSE.Extension.Api;

namespace CBS.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : GenericController<Service, int>
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService service, IApiResponse<object> apiResponse)
            : base(service, apiResponse)
        {
            _serviceService = service;
        }

        [HttpGet("search/{keyword}")]
        public async Task<IActionResult> SearchServices(string keyword)
        {
            var services = _serviceService.SearchServices(keyword);
            _apiResponse.Data = services;
            return _apiResponse.ToActionResult();
        }
    }
}