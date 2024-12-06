using CBS.Entity.Domain;
using CSE.Generic.Controllers;
using CSE.Service.Dapper;
using Microsoft.AspNetCore.Mvc;

namespace CBS.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v2/customer")]
    public class CustomerDapperController : GenericDapperController<Customer>
    {
        public CustomerDapperController(IDapperService dapperService) : base(dapperService, "Customer")
        {
        }
    }
}
