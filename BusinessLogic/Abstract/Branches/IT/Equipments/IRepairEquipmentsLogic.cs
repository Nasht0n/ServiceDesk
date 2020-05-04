using Domain.Models.Requests.Equipment;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Equipments
{
    public interface IRepairEquipmentsLogic
    {
        Task<RepairEquipments> Add(RepairEquipments repair);
    }
}
