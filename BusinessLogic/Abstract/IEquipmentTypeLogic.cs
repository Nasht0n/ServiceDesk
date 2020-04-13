using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IEquipmentTypeLogic
    {
        Task<List<EquipmentType>> GetEquipmentTypes();
        Task<List<EquipmentType>> GetEquipmentTypesByDescendings();
        Task<EquipmentType> GetEquipmentTypeById(int id);
    }
}
