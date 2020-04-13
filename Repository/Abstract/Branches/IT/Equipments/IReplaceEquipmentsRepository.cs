using Domain.Models.Requests.Equipment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Equipments
{
    public interface IReplaceEquipmentsRepository
    {
        Task<ReplaceEquipments> Add(ReplaceEquipments equipments);
        Task<ReplaceEquipments> Update(ReplaceEquipments equipments);
        Task Delete(ReplaceEquipments equipments);
        Task<List<ReplaceEquipments>> GetReplaces();
    }
}
