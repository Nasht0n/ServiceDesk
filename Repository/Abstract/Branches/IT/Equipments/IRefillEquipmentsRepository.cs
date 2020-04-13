using Domain.Models.Requests.Equipment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Equipments
{
    public interface IRefillEquipmentsRepository
    {
        Task<RefillEquipments> Add(RefillEquipments refill);
        Task<RefillEquipments> Update(RefillEquipments refill);
        Task Delete(RefillEquipments refill);
        Task<List<RefillEquipments>> GetRefills();
    }
}
