using CBS.Entity.Domain;
using CSE.Interfaces.IServices;

public interface IBookingService : IGenericService<Booking, int>
{
    Task<IEnumerable<DateTime>> GetBookingDates(int bookingId);
}