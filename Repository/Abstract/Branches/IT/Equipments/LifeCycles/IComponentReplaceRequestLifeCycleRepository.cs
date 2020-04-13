using Domain.Models.Requests.Equipment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Equipments.LifeCycles
{
    public interface IComponentReplaceRequestLifeCycleRepository
    {
        Task<ComponentReplaceRequestLifeCycle> Add(ComponentReplaceRequestLifeCycle lifeCycle);
        Task<ComponentReplaceRequestLifeCycle> Update(ComponentReplaceRequestLifeCycle lifeCycle);
        Task Delete(ComponentReplaceRequestLifeCycle lifeCycle);
        Task<List<ComponentReplaceRequestLifeCycle>> GetLifeCycles();
    }
}
