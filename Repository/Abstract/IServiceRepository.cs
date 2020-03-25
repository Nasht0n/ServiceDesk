using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IServiceRepository
    {
        Task<Service> AddService(Service service);
        Task<Service> UpdateService(Service service);
        Task DeleteService(Service service);
        Task<List<Service>> GetServices();
    }
}
