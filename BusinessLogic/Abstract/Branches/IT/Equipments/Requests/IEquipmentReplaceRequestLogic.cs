using Domain.Models.Requests.Equipment;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Equipments.Requests
{
    public interface IEquipmentReplaceRequestLogic
    {
        Task<EquipmentReplaceRequest> Save(EquipmentReplaceRequest request);
        Task Delete(EquipmentReplaceRequest request);
        Task<EquipmentReplaceRequest> GetRequest(int id);

    }
}
