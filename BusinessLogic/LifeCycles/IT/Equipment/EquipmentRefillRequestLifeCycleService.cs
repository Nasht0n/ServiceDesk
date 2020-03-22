using DataAccess.Concrete;
using Domain.Models.Requests.Equipment;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.LifeCycles.IT.Equipment
{
    public class EquipmentRefillRequestLifeCycleService
    {
        private ServiceDesk serviceDesk = new ServiceDesk();

        public void AddLifeCycle(EquipmentRefillRequestLifeCycle lifeCycle)
        {
            serviceDesk.EquipmentRefillRequestLifeCycleRepository.Insert(lifeCycle);
            serviceDesk.Save();
        }

        public List<EquipmentRefillRequestLifeCycle> GetLifeCycles(int id)
        {
            return serviceDesk.EquipmentRefillRequestLifeCycleRepository
                .Get(filter: r => r.RequestId == id, includeProperties: "Request, Employee, Employee.Subdivision")
                .ToList();
        }
    }
}
