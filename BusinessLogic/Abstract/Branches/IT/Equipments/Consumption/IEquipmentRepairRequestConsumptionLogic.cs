using Domain.Models.Requests.Equipment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Equipments.Consumption
{
    public interface IEquipmentRepairRequestConsumptionLogic
    {
        Task<EquipmentRepairRequestConsumption> Save(EquipmentRepairRequestConsumption consumption);
        Task Delete(EquipmentRepairRequestConsumption consumption);
        Task<EquipmentRepairRequestConsumption> GetConsumption(int id);
        Task<List<EquipmentRepairRequestConsumption>> GetConsumptions(EquipmentRepairRequest request);
    }
}
