using Domain.Models.Requests.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Equipments.Requests
{
    public interface IEquipmentRepairRequestLogic
    {
        Task<EquipmentRepairRequest> Save(EquipmentRepairRequest request);
        Task Delete(EquipmentRepairRequest request);
        Task<EquipmentRepairRequest> GetRequestById(int id);
        Task<List<EquipmentRepairRequest>> GetRequests();
        Task<List<EquipmentRepairRequest>> GetRequestsByDescending();
    }
}
