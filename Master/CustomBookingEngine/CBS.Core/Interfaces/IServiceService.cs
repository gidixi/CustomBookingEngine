using CBS.Entity.Domain;
using CSE.Interfaces.IServices;

public interface IServiceService : IGenericService<Service, int>
{
    IEnumerable<Service> SearchServices(string keyword);
}