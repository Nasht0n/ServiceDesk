using Domain.Models;
using Domain.Models.ManyToMany;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IServicesExecutorGroupsLogic
    {
        Task<List<ServicesExecutorGroup>> GetServicesExecutorGroups(Service service);
    }
}
