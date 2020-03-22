using DataAccess.Concrete;
using Domain.Models.Requests.Equipment;
using System.Linq;

namespace BusinessLogic.Requests.IT.Equipment
{
    public class ReplaceEquipmentService
    {
        private ServiceDesk serviceDesk = new ServiceDesk();

        public void AddRequest(ReplaceEquipments equipment)
        {
            serviceDesk.ReplaceEquipmentsRepository.Insert(equipment);
            serviceDesk.Save();
        }

        public void DeleteEntry(EquipmentReplaceRequest request)
        {
            var list = serviceDesk.ReplaceEquipmentsRepository.Get(filter: e => e.RequestId == request.Id).ToList();
            foreach (var item in list)
            {
                serviceDesk.ReplaceEquipmentsRepository.Delete(item);
            }
            serviceDesk.Save();
        }
    }
}
