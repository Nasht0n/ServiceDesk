using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IEquipmentLogic
    {
        Task<Equipment> GetEquipment(int id);
        Task<Equipment> GetEquipment(string inventory);
        Task<List<Equipment>> GetEquipments(EquipmentType equipmentType, bool descendings = false);
    }
}
