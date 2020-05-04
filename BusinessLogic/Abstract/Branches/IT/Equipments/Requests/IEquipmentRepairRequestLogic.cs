using Domain.Models.Requests.Equipment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Equipments.Requests
{
    public interface IEquipmentRepairRequestLogic
    {
        Task<EquipmentRepairRequest> Save(EquipmentRepairRequest request);
        Task Delete(EquipmentRepairRequest request);
        Task<EquipmentRepairRequest> GetRequest(int id);
        Task<List<EquipmentRepairRequest>> GetRequests(bool descendings = false);
    }
}
