using CBS.DTO.Request;
using CBS.Entity.Domain;
using CSE.Entity.Domain;
using CSE.Extension.Api;
using CSE.Generic.Controllers;
using CSE.Interfaces.IApi;
using CSE.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CBS.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : GenericController<Booking, Guid>
    {
        private readonly IBookingService _bookingService;
        private readonly IBookingRoomDetailsService _bookingRoomDetailsService;
        private readonly IBookingServiceDetailsService _bookingServiceDetailsService;
        private readonly ICustomerService _customerService;

        //public BookingController(IBookingService service, IApiResponse<object> apiResponse)
        //    : base(service, apiResponse)
        //{
        //    _bookingService = service;
        //}

        public BookingController(
        IBookingService bookingService,
        IBookingRoomDetailsService bookingRoomDetailsService,
        IBookingServiceDetailsService bookingServiceDetailsService,
        ICustomerService customerService,
        IApiResponse<object> apiResponse)
            : base(bookingService, apiResponse)
            {
                _bookingService = bookingService;
                _bookingRoomDetailsService = bookingRoomDetailsService;
                _bookingServiceDetailsService = bookingServiceDetailsService;
                _customerService = customerService;
        }



        [HttpGet("dates/{bookingId}")]
        public ActionResult<IEnumerable<DateTime>> GetBookingDates(Guid bookingId)
        {
            var dates = _bookingService.GetBookingDates(bookingId);
            return Ok(dates);
        }

        [HttpPost("book")]
        public async Task<IActionResult> BookRoom(BookingRequest request)
        {
            try
            {
                // Verifica che il CustomerId esista
                var customer = await _customerService.GetByIdAsync(request.CustomerId);
                if (customer == null)
                {
                    _apiResponse.StatusCode = 400;
                    _apiResponse.Message = $"Customer with ID {request.CustomerId} does not exist.";
                    return _apiResponse.ToActionResult();
                }

                // Verifica che tutti gli ServiceId esistano
                //foreach (var serviceBooking in request.ServiceBookings)
                //{
                //    var service = await _bookingService.GetByIdAsync(serviceBooking.ServiceId);
                //    if (service == null)
                //    {
                //        _apiResponse.StatusCode = 400;
                //        _apiResponse.Message = $"Service with ID {serviceBooking.ServiceId} does not exist.";
                //        return _apiResponse.ToActionResult();
                //    }
                //}

                var booking = new Booking
                {
                    CustomerId = request.CustomerId,
                    CouponId = request.CouponId,
                    CheckinDate = request.CheckinDate,
                    CheckoutDate = request.CheckoutDate,
                    NumberOfAdults = request.NumberofAdults,
                    NumberOfChildren = request.NumberofChildren,
                    CreateDate = DateTime.UtcNow,
                    IsCanceled = false
                };

                var createdBooking = await _bookingService.CreateAsync(booking);

                foreach (var roomBooking in request.RoomBookings)
                {
                    var roomDetails = new BookingRoomDetails
                    {
                        BookingId = createdBooking.BookingId,
                        RoomTypeId = roomBooking.RoomTypeId,
                        RoomQuantity = roomBooking.RoomQuantity,
                        Date = request.CheckinDate,
                        RoomPrice = 0 // Calcola il prezzo in base alle tariffe e alle promozioni
                    };

                    await _bookingRoomDetailsService.CreateAsync(roomDetails);
                }

                foreach (var serviceBooking in request.ServiceBookings)
                {
                    var serviceDetails = new BookingServiceDetails
                    {
                        BookingId = createdBooking.BookingId,
                        ServiceId = serviceBooking.ServiceId,
                        ServiceQuantity = serviceBooking.ServiceQuantity,
                        ServicePrice = 0 // Calcola il prezzo in base alle tariffe
                    };

                    await _bookingServiceDetailsService.CreateAsync(serviceDetails);
                }

                _apiResponse.Data = createdBooking;
                return _apiResponse.ToActionResult();
            }
            catch (Exception ex)
            {
                _apiResponse.Message = ex.Message;
                _apiResponse.StatusCode = 400;
                return _apiResponse.ToActionResult();
            }
        }
    }
}