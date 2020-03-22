using DataAccess.Concrete;
using Domain.Models.Requests.Equipment;
using System.Linq;

namespace BusinessLogic.Requests.IT.Equipment
{
    public class RepairEquipmentService
    {
        private ServiceDesk serviceDesk = new ServiceDesk();

        public void AddRequest(RepairEquipments equipment)
        {
            serviceDesk.RepairEquipmentsRepository.Insert(equipment);
            serviceDesk.Save();
        }

        public void DeleteEntry(EquipmentRepairRequest request)
        {
            var list = serviceDesk.RepairEquipmentsRepository.Get(filter: e => e.RequestId == request.Id).ToList();
            foreach (var item in list)
            {
                serviceDesk.RepairEquipmentsRepository.Delete(item);
            }
            serviceDesk.Save();
        }
    }
}
