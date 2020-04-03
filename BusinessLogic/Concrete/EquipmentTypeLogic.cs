using BusinessLogic.Abstract;
using Domain.Models;
using Repository.Abstract;
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
    }
}
