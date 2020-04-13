using Domain.Models.Requests.Equipment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Equipments.Requests
{
    public interface IEquipmentInstallationRequestRepository
    {
        Task<EquipmentInstallationRequest> Add(EquipmentInstallationRequest request);
        Task<EquipmentInstallationRequest> Update(EquipmentInstallationRequest request);
        Task Delete(EquipmentInstallationRequest request);
        Task<List<EquipmentInstallationRequest>> GetRequests();
    }
}
