using DataAccess.Concrete;
using Domain.Models.Requests.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.LifeCycles
{
    public class EquipmentInstallationRequestLifeCycleService
    {
        private ServiceDesk serviceDesk = new ServiceDesk();

        public void AddLifeCycle(EquipmentInstallationRequestLifeCycle lifeCycle)
        {
            serviceDesk.EquipmentInstallationRequestLifeCycleRepository.Insert(lifeCycle);
            serviceDesk.Save();
        }

        public List<EquipmentInstallationRequestLifeCycle> GetLifeCycles(int id)
        {
            return serviceDesk.EquipmentInstallationRequestLifeCycleRepository.Get(
                filter: r=>r.RequestId == id,
                includeProperties: "Request, Employee, Employee.Subdivision"
                ).ToList();
        }
    }
}
