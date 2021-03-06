using Domain.Models;
using Domain.Models.Requests.Equipment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Equipments.Requests
{
    public interface IEquipmentRefillRequestLogic
    {
        Task<EquipmentRefillRequest> Save(EquipmentRefillRequest request);
        Task Delete(EquipmentRefillRequest request);
        Task<EquipmentRefillRequest> GetRequest(int id);
        Task<List<EquipmentRefillRequest>> GetRequests(bool descendings = false);
        Task<List<EquipmentRefillRequest>> GetRequests(Subdivision subdivision, bool descendings = false);
    }
}
