using Domain.Models.Requests.Equipment;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Equipments.Requests
{
    public interface IEquipmentInstallationRequestLogic
    {
        Task<EquipmentInstallationRequest> Save(EquipmentInstallationRequest request);
        Task Delete(EquipmentInstallationRequest request);
        Task<EquipmentInstallationRequest> GetRequest(int id);
    }
}
