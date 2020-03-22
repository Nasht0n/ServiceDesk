using DataAccess.Concrete;
using Domain.Models.Requests.Equipment;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.LifeCycles.IT.Equipment
{
    public class ComponentReplaceRequestLifeCycleService
    {
        private ServiceDesk serviceDesk = new ServiceDesk();

        public void AddLifeCycle(ComponentReplaceRequestLifeCycle lifeCycle)
        {
            serviceDesk.ComponentReplaceRequestLifeCycleRepository.Insert(lifeCycle);
            serviceDesk.Save();
        }

        public List<ComponentReplaceRequestLifeCycle> GetLifeCycles(int id)
        {
            return serviceDesk.ComponentReplaceRequestLifeCycleRepository
                .Get(filter: r => r.RequestId == id, includeProperties: "Request, Employee, Employee.Subdivision")
                .ToList();
        }
    }
}
