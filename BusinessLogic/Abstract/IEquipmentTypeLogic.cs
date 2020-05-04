using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IEquipmentTypeLogic
    {
        Task<List<EquipmentType>> GetEquipmentTypes(bool descendings = false);
        Task<EquipmentType> GetEquipmentType(int id);
    }
}
