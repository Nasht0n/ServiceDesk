using Domain.Models.Requests.Equipment;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Equipments
{
    public interface IRefillEquipmentsLogic
    {
        Task<RefillEquipments> Add(RefillEquipments equipments);
        Task DeleteEntry(EquipmentRefillRequest request);
    }
}
