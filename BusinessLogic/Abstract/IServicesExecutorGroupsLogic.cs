using Domain.Models.ManyToMany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IServicesExecutorGroupsLogic
    {
        Task<List<ServicesExecutorGroup>> GetServicesExecutorGroups(int serviceId);
    }
}
