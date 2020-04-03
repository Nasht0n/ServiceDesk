using BusinessLogic.Abstract;
using Domain.Models;
using Repository.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class EquipmentLogic : IEquipmentLogic
    {
        private readonly IEquipmentRepository equipmentRepository;

        public EquipmentLogic(IEquipmentRepository equipmentRepository)
        {
            this.equipmentRepository = equipmentRepository;
        }

        public async Task<Equipment> GetEquipmentById(int id)
        {
            var equipments = await equipmentRepository.GetEquipments();
            return equipments.FirstOrDefault(e => e.Id == id);
        }

        public async Task<Equipment> GetEquipmentByInventory(string inventory)
        {
            var equipments = await equipmentRepository.GetEquipments();
            return equipments.FirstOrDefault(e => e.InventoryNumber == inventory);
        }

        public async Task<List<Equipment>> GetEquipments(EquipmentType equipmentType)
        {
            var equipments = await equipmentRepository.GetEquipments();
            return equipments.Where(e => e.EquipmentTypeId == equipmentType.Id).ToList();
        }
    }
}
