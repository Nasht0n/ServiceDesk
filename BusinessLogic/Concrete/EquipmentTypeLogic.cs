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

        public async Task<EquipmentType> GetEquipmentType(int id)
        {
            var types = await equipmentTypeRepository.GetEquipmentTypes();
            return types.FirstOrDefault(t => t.Id == id);
        }

        public async Task<List<EquipmentType>> GetEquipmentTypes(bool descendings = false)
        {
            var types = await equipmentTypeRepository.GetEquipmentTypes();
            if(descendings) return types.OrderByDescending(t => t.Name).ToList();
            else return types.OrderBy(t => t.Name).ToList();
        }
    }
}
