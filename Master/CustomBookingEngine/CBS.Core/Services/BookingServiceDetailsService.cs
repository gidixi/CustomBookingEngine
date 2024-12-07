using CBS.Entity.Domain;
using CSE.Interfaces.IUnitOfWork;
using CSE.Service.Generics;


public class BookingServiceDetailsService : GenericService<BookingServiceDetails, int>, IBookingServiceDetailsService
{
    public BookingServiceDetailsService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}