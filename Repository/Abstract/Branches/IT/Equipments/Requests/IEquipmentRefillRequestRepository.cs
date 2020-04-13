using Domain.Models.Requests.Equipment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Equipments.Requests
{
    public interface IEquipmentRefillRequestRepository
    {
        Task<EquipmentRefillRequest> Add(EquipmentRefillRequest request);
        Task<EquipmentRefillRequest> Update(EquipmentRefillRequest request);
        Task Delete(EquipmentRefillRequest request);
        Task<List<EquipmentRefillRequest>> GetRequests();
    }
}
