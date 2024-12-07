using CBS.Entity.Domain;
using CSE.Interfaces.IServices;

public interface IBookingService : IGenericService<Booking, Guid>
{
    Task<IEnumerable<DateTime>> GetBookingDates(Guid bookingId);
}