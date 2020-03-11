using DataAccess.Concrete;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class EquipmentTypeService
    {
        private ServiceDesk serviceDesk = new ServiceDesk();

        public List<EquipmentType> GetEquipmentTypes()
        {
            return serviceDesk.EquipmentTypeRepository.Get().ToList();
        }

        public EquipmentType GetEquipmentTypeById(int id)
        {
            return serviceDesk.EquipmentTypeRepository.Get(filter: e => e.Id == id).FirstOrDefault();
        }

        public void AddEquipmentType(EquipmentType equipmentType)
        {
            serviceDesk.EquipmentTypeRepository.Insert(equipmentType);
            serviceDesk.Save();
        }

        public void UpdateEquipmentType(EquipmentType equipmentType)
        {
            serviceDesk.EquipmentTypeRepository.Update(equipmentType);
            serviceDesk.Save();
        }

        public void DeleteEquipmentType(EquipmentType equipmentType)
        {
            serviceDesk.EquipmentTypeRepository.Delete(equipmentType);
            serviceDesk.Save();
        }
    }
}
