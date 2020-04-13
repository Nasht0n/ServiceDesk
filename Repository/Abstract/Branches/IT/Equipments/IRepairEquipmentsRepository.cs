using Domain.Models.Requests.Equipment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Equipments
{
    public interface IRepairEquipmentsRepository
    {
        Task<RepairEquipments> Add(RepairEquipments repair);
        Task<RepairEquipments> Update(RepairEquipments repair);
        Task Delete(RepairEquipments repair);
        Task<List<RepairEquipments>> GetRepairs();
    }
}
