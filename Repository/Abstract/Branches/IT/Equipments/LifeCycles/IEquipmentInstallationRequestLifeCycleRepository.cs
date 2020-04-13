using Domain.Models.Requests.Equipment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Equipments.LifeCycles
{
    public interface IEquipmentInstallationRequestLifeCycleRepository
    {
        Task<EquipmentInstallationRequestLifeCycle> Add(EquipmentInstallationRequestLifeCycle lifeCycle);
        Task<EquipmentInstallationRequestLifeCycle> Update(EquipmentInstallationRequestLifeCycle lifeCycle);
        Task Delete(EquipmentInstallationRequestLifeCycle lifeCycle);
        Task<List<EquipmentInstallationRequestLifeCycle>> GetLifeCycles();
    }
}
