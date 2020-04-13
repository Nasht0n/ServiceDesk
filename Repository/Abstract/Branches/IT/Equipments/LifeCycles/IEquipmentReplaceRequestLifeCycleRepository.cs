using Domain.Models.Requests.Equipment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Equipments.LifeCycles
{
    public interface IEquipmentReplaceRequestLifeCycleRepository
    {
        Task<EquipmentReplaceRequestLifeCycle> Add(EquipmentReplaceRequestLifeCycle lifeCycle);
        Task<EquipmentReplaceRequestLifeCycle> Update(EquipmentReplaceRequestLifeCycle lifeCycle);
        Task Delete(EquipmentReplaceRequestLifeCycle lifeCycle);
        Task<List<EquipmentReplaceRequestLifeCycle>> GetLifeCycles();
    }
}
