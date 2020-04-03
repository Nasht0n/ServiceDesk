using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IEquipmentTypeRepository
    {
        Task<EquipmentType> Add(EquipmentType equipmentType);
        Task<EquipmentType> Update(EquipmentType equipmentType);
        Task Delete(EquipmentType equipmentType);
        Task<List<EquipmentType>> GetEquipmentTypes();
    }
}
