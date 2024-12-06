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
    public class FacilitiesService : GenericService<Facilities, int>, IFacilitiesService
    {
        private readonly IRepository<Facilities, int> _facilitiesRepository;
        public FacilitiesService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _facilitiesRepository = unitOfWork.Repository<Facilities, int>();
        }
    }
}
