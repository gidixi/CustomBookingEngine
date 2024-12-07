using CBS.Core.Interfaces;
using CBS.Entity.Domain;
using CSE.Interfaces.IRepository;
using CSE.Interfaces.IUnitOfWork;
using CSE.Service.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBS.Core.Services
{
    public class RoomService : GenericService<Room, int>, IRoomService
    {
        private readonly IRepository<Room, int> _serviceRepository;

        public RoomService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _serviceRepository = unitOfWork.Repository<Room, int>();
        }

        //public async Task<IEnumerable<Room>> GetAvailableRooms(int hotelId)
        //{
            
        //}
    }
}
