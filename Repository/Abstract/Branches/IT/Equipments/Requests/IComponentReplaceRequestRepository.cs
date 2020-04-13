using Domain.Models.Requests.Equipment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Equipments.Requests
{
    public interface IComponentReplaceRequestRepository
    {
        Task<ComponentReplaceRequest> Add(ComponentReplaceRequest request);
        Task<ComponentReplaceRequest> Update(ComponentReplaceRequest request);
        Task Delete(ComponentReplaceRequest request);
        Task<List<ComponentReplaceRequest>> GetRequests();
    }
}
