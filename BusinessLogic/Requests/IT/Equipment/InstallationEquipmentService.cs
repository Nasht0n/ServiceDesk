using DataAccess.Concrete;
using Domain.Models.Requests.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Requests
{
    public class InstallationEquipmentService
    {
        private ServiceDesk serviceDesk = new ServiceDesk();

        public void AddRequest(InstallationEquipments equipment)
        {
            serviceDesk.InstallationEquipmentsRepository.Insert(equipment);
            serviceDesk.Save();
        }

        public void DeleteEntry(EquipmentInstallationRequest request)
        {
            var list = serviceDesk.InstallationEquipmentsRepository.Get(filter: e => e.RequestId == request.Id).ToList();
            foreach(var item in list)
            {
                serviceDesk.InstallationEquipmentsRepository.Delete(item);
            }
            serviceDesk.Save();
        }
    }
}
