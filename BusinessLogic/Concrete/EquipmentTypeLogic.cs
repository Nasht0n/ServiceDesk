using BusinessLogic.Abstract;
using Domain.Models;
using Repository.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class EquipmentTypeLogic : IEquipmentTypeLogic
    {
        private readonly IEquipmentTypeRepository equipmentTypeRepository;

        public EquipmentTypeLogic(IEquipmentTypeRepository equipmentTypeRepository)
        {
            this.equipmentTypeRepository = equipmentTypeRepository;
        }

        public async Task<EquipmentType> GetEquipmentTypeById(int id)
        {
            var types = await equipmentTypeRepository.GetEquipmentTypes();
            return types.FirstOrDefault(t => t.Id == id);
        }

        public async Task<List<EquipmentType>> GetEquipmentTypes()
        {
            var types = await equipmentTypeRepository.GetEquipmentTypes();
            return types.OrderBy(t => t.Id).ToList();
        }

        public async Task<List<EquipmentType>> GetEquipmentTypesByDescendings()
        {
            var types = await equipmentTypeRepository.GetEquipmentTypes();
            return types.OrderByDescending(t => t.Id).ToList();
        }
    }
}
