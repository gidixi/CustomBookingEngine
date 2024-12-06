using CBS.Entity.Domain;
using CSE.Interfaces.IUnitOfWork;
using CSE.Service.Generics;


public class CustomerService : GenericService<Customer, Guid>, ICustomerService
{
    public CustomerService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}