using Domain.Models.Requests.Equipment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Equipments.LifeCycles
{
    public interface IEquipmentRefillRequestLifeCycleRepository
    {
        Task<EquipmentRefillRequestLifeCycle> Add(EquipmentRefillRequestLifeCycle lifeCycle);
        Task<EquipmentRefillRequestLifeCycle> Update(EquipmentRefillRequestLifeCycle lifeCycle);
        Task Delete(EquipmentRefillRequestLifeCycle lifeCycle);
        Task<List<EquipmentRefillRequestLifeCycle>> GetLifeCycles();
    }
}
