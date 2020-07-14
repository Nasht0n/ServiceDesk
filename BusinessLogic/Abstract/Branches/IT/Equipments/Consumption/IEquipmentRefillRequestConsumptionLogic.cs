using Domain.Models.Requests.Equipment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Equipments.Consumption
{
    public interface IEquipmentRefillRequestConsumptionLogic
    {
        Task<EquipmentRefillRequestConsumption> Save(EquipmentRefillRequestConsumption consumption);
        Task Delete(EquipmentRefillRequestConsumption consumption);
        Task<EquipmentRefillRequestConsumption> GetConsumption(int id);
        Task<List<EquipmentRefillRequestConsumption>> GetConsumptions(EquipmentRefillRequest request);
    }
}
