using CBS.Entity.Domain;
using CSE.Interfaces.IServices;

public interface IRoomTypeService : IGenericService<RoomType, int>
{
    IEnumerable<RoomType> SearchRoomTypes(int adult, int children, DateTime checkInDate, DateTime checkOutDate);
}