using Domain.Models.Requests.Equipment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Equipments.LifeCycles
{
    public interface IEquipmentReplaceRequestLifeCycleLogic
    {
        Task<EquipmentReplaceRequestLifeCycle> Add(EquipmentReplaceRequestLifeCycle lifeCycle);
        Task<List<EquipmentReplaceRequestLifeCycle>> GetLifeCycles(EquipmentReplaceRequest request);
    }
}
