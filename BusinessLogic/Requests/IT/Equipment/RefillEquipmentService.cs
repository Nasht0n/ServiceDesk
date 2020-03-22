using DataAccess.Concrete;
using Domain.Models.Requests.Equipment;
using System.Linq;

namespace BusinessLogic.Requests.IT.Equipment
{
    public class RefillEquipmentService
    {
        private ServiceDesk serviceDesk = new ServiceDesk();

        public void AddRequest(RefillEquipments equipment)
        {
            serviceDesk.RefillEquipmentsRepository.Insert(equipment);
            serviceDesk.Save();
        }

        public void DeleteEntry(EquipmentRefillRequest request)
        {
            var list = serviceDesk.RefillEquipmentsRepository.Get(filter: e => e.RequestId == request.Id).ToList();
            foreach (var item in list)
            {
                serviceDesk.RefillEquipmentsRepository.Delete(item);
            }
            serviceDesk.Save();
        }
    }
}
