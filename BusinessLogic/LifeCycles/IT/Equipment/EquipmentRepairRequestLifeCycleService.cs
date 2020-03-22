using DataAccess.Concrete;
using Domain.Models.Requests.Equipment;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.LifeCycles.IT.Equipment
{
    public class EquipmentRepairRequestLifeCycleService
    {
        private ServiceDesk serviceDesk = new ServiceDesk();

        public void AddLifeCycle(EquipmentRepairRequestLifeCycle lifeCycle)
        {
            serviceDesk.EquipmentRepairRequestLifeCycleRepository.Insert(lifeCycle);
            serviceDesk.Save();
        }

        public List<EquipmentRepairRequestLifeCycle> GetLifeCycles(int id)
        {
            return serviceDesk.EquipmentRepairRequestLifeCycleRepository
                .Get(filter: r => r.RequestId == id, includeProperties: "Request, Employee, Employee.Subdivision")
                .ToList();
        }
    }
}
