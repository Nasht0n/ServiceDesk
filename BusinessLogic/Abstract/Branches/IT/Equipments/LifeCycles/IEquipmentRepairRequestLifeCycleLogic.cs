using Domain.Models.Requests.Equipment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Equipments.LifeCycles
{
    public interface IEquipmentRepairRequestLifeCycleLogic
    {
        Task<EquipmentRepairRequestLifeCycle> Add(EquipmentRepairRequestLifeCycle lifeCycle);
        Task<List<EquipmentRepairRequestLifeCycle>> GetLifeCycles(EquipmentRepairRequest request);
    }
}
