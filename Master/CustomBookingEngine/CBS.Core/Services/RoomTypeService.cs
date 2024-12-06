using CBS.Entity.Domain;
using CSE.Interfaces.IUnitOfWork;
using CSE.Service.Generics;
using CSE.Interfaces.IRepository;

public class RoomTypeService : GenericService<RoomType, int>, IRoomTypeService
{
    private readonly IRepository<RoomType, int> _roomTypeRepository;

    public RoomTypeService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _roomTypeRepository = unitOfWork.Repository<RoomType, int>();
    }

    public IEnumerable<RoomType> SearchRoomTypes(int adult, int children, DateTime checkInDate, DateTime checkOutDate)
    {
        return _roomTypeRepository.Get()
            .Where(r => !r.IsDeleted && r.MaxAdult >= adult && r.MaxChildren >= children && r.MaxPeople >= (adult + children))
            .ToList();
    }
}