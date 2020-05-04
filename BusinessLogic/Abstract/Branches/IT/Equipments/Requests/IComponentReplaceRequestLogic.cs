using Domain.Models.Requests.Equipment;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Equipments.Requests
{
    public interface IComponentReplaceRequestLogic
    {
        Task<ComponentReplaceRequest> Save(ComponentReplaceRequest request);
        Task Delete(ComponentReplaceRequest request);
        Task<ComponentReplaceRequest> GetRequest(int id);
    }
}
