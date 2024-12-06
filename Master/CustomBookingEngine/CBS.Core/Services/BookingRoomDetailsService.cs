using CBS.Entity.Domain;
using CSE.Interfaces.IUnitOfWork;
using CSE.Service.Generics;

public class BookingRoomDetailsService : GenericService<BookingRoomDetails, int>, IBookingRoomDetailsService
{
    public BookingRoomDetailsService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}