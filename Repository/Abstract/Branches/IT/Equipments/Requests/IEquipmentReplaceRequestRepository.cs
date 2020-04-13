using Domain.Models.Requests.Equipment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Equipments.Requests
{
    public interface IEquipmentReplaceRequestRepository
    {
        Task<EquipmentReplaceRequest> Add(EquipmentReplaceRequest request);
        Task<EquipmentReplaceRequest> Update(EquipmentReplaceRequest request);
        Task Delete(EquipmentReplaceRequest request);
        Task<List<EquipmentReplaceRequest>> GetRequests();
    }
}
