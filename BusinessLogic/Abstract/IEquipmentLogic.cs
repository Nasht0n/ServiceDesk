using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IEquipmentLogic
    {
        Task<Equipment> GetEquipmentById(int id);
        Task<Equipment> GetEquipmentByInventory(string inventory);
        Task<List<Equipment>> GetEquipments(EquipmentType equipmentType);
    }
}
