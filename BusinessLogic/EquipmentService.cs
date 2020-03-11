using DataAccess.Concrete;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class EquipmentService
    {
        private ServiceDesk serviceDesk = new ServiceDesk();

        public List<Equipment> GetEquipments()
        {
            return serviceDesk.EquipmentRepository.Get(includeProperties: "EquipmentType").ToList();
        }

        public Equipment GetEquipmentById(int id)
        {
            return serviceDesk.EquipmentRepository.Get(filter: e => e.Id == id, includeProperties: "EquipmentType").FirstOrDefault();
        }

        public void AddEquipment(Equipment equipment)
        {
            serviceDesk.EquipmentRepository.Insert(equipment);
            serviceDesk.Save();
        }

        public void UpdateEquipment(Equipment equipment)
        {
            serviceDesk.EquipmentRepository.Update(equipment);
            serviceDesk.Save();
        }

        public void DeleteEquipment(Equipment equipment)
        {
            serviceDesk.EquipmentRepository.Delete(equipment);
            serviceDesk.Save();
        }
    }
}
