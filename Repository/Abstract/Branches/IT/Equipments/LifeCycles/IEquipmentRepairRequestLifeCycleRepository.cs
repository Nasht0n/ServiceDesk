using Domain.Models.Requests.Equipment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Equipments.LifeCycles
{
    public interface IEquipmentRepairRequestLifeCycleRepository
    {
        Task<EquipmentRepairRequestLifeCycle> Add(EquipmentRepairRequestLifeCycle lifeCycle);
        Task<EquipmentRepairRequestLifeCycle> Update(EquipmentRepairRequestLifeCycle lifeCycle);
        Task Delete(EquipmentRepairRequestLifeCycle lifeCycle);
        Task<List<EquipmentRepairRequestLifeCycle>> GetLifeCycles();
    }
}
