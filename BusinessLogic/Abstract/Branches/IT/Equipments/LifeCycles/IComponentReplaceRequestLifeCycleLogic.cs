using Domain.Models.Requests.Equipment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Equipments.LifeCycles
{
    public interface IComponentReplaceRequestLifeCycleLogic
    {
        Task<ComponentReplaceRequestLifeCycle> Add(ComponentReplaceRequestLifeCycle lifeCycle);
        Task<List<ComponentReplaceRequestLifeCycle>> GetLifeCycles(ComponentReplaceRequest request);
    }
}
