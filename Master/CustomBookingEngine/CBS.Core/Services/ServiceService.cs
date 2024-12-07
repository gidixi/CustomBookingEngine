using CBS.Entity.Domain;
using CSE.Interfaces.IRepository;
using CSE.Interfaces.IUnitOfWork;
using CSE.Service.Generics;


public class ServiceService : GenericService<Service, int>, IServiceService
{
    private readonly IRepository<Service, int> _serviceRepository;

    public ServiceService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _serviceRepository = unitOfWork.Repository<Service, int>();
    }

    public IEnumerable<Service> SearchServices(string keyword)
    {
        return _serviceRepository.Get().Where(s => !s.IsDeleted && s.ServiceName.Contains(keyword)).ToList();
    }
}