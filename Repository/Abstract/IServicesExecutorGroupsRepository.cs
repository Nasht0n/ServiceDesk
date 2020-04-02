using Domain.Models.ManyToMany;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IServicesExecutorGroupsRepository
    {
        Task<ServicesExecutorGroup> Add(ServicesExecutorGroup servicesExecutorGroup);
        Task Delete(ServicesExecutorGroup servicesExecutorGroup);
        Task<List<ServicesExecutorGroup>> GetServicesExecutorGroups();
    }
}
