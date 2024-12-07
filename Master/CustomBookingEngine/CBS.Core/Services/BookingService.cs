using CBS.Entity.Domain;
using CSE.Interfaces.IUnitOfWork;
using CSE.Service.Generics;
using CSE.Interfaces.IRepository;

public class BookingService : GenericService<Booking, Guid>, IBookingService
{
    private readonly IRepository<Booking, Guid> _bookingRepository;

    public BookingService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _bookingRepository = unitOfWork.Repository<Booking, Guid>();
    }

    public async Task<IEnumerable<DateTime>> GetBookingDates(Guid bookingId)
    {
        var booking = await _bookingRepository.FindByIdAsync(bookingId).ConfigureAwait(true);
        if (booking == null) return new List<DateTime>();

        var dates = new List<DateTime>();
        for (var date = booking.CheckinDate; date <= booking.CheckoutDate; date = date.AddDays(1))
        {
            dates.Add(date);
        }
        return dates;
    }
}