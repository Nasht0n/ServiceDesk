using DataAccess.Concrete;
using Domain.Models.Requests.Equipment;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.LifeCycles.IT.Equipment
{
    public class EquipmentReplaceRequestLifeCycleService
    {
        private ServiceDesk serviceDesk = new ServiceDesk();

        public void AddLifeCycle(EquipmentReplaceRequestLifeCycle lifeCycle)
        {
            serviceDesk.EquipmentReplaceRequestLifeCycleRepository.Insert(lifeCycle);
            serviceDesk.Save();
        }

        public List<EquipmentReplaceRequestLifeCycle> GetLifeCycles(int id)
        {
            return serviceDesk.EquipmentReplaceRequestLifeCycleRepository
                .Get(filter: r => r.RequestId == id,includeProperties: "Request, Employee, Employee.Subdivision")
                .ToList();
        }
    }
}
