using Domain.Models.Requests.Equipment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Equipments.Requests
{
    public interface IEquipmentRepairRequestRepository
    {
        Task<EquipmentRepairRequest> Add(EquipmentRepairRequest request);
        Task<EquipmentRepairRequest> Update(EquipmentRepairRequest request);
        Task Delete(EquipmentRepairRequest request);
        Task<List<EquipmentRepairRequest>> GetRequests();
    }
}
