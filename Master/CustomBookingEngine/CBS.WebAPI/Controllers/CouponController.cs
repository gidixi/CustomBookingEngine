using CBS.Entity.Domain;
using CSE.Generic.Controllers;
using CSE.Interfaces.IApi;
using CSE.Extension.Api;
using Microsoft.AspNetCore.Mvc;

namespace CBS.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CouponController : GenericController<Coupon, int>
    {
        private readonly ICouponService _couponService;

        public CouponController(ICouponService service, IApiResponse<object> apiResponse)
            : base(service, apiResponse)
        {
            _couponService = service;
        }

        [HttpGet("search/{couponCode}")]
        public async Task<IActionResult> SearchCoupon(string couponCode)
        {
            var coupon = _couponService.SearchCoupon(couponCode);
            if (coupon == null)
            {
                _apiResponse.StatusCode = 404;
                _apiResponse.Message = "Not Found";
                return _apiResponse.ToActionResult();
            }
            _apiResponse.StatusCode = 200;
            _apiResponse.Message = "Success";
            _apiResponse.Data = coupon;

            return _apiResponse.ToActionResult();    
        }
    }
}