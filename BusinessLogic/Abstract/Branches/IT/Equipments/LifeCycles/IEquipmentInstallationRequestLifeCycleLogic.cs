using Domain.Models.Requests.Equipment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Equipments.LifeCycles
{
    public interface IEquipmentInstallationRequestLifeCycleLogic
    {
        Task<EquipmentInstallationRequestLifeCycle> Add(EquipmentInstallationRequestLifeCycle lifeCycle);
        Task<List<EquipmentInstallationRequestLifeCycle>> GetLifeCycles(EquipmentInstallationRequest request);
    }
}
