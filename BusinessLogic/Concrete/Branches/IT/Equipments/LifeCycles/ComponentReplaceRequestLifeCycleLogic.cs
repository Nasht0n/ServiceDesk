using BusinessLogic.Abstract.Branches.IT.Equipments.LifeCycles;
using Domain.Models.Requests.Equipment;
using Repository.Abstract.Branches.IT.Equipments.LifeCycles;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Equipments.LifeCycles
{
    public class ComponentReplaceRequestLifeCycleLogic : IComponentReplaceRequestLifeCycleLogic
    {
        private readonly IComponentReplaceRequestLifeCycleRepository lifeCycleRepository;

        public ComponentReplaceRequestLifeCycleLogic(IComponentReplaceRequestLifeCycleRepository lifeCycleRepository)
        {
            this.lifeCycleRepository = lifeCycleRepository;
        }

        public async Task<List<ComponentReplaceRequestLifeCycle>> GetLifeCycles(int requestId)
        {
            var lifeCycles = await lifeCycleRepository.GetLifeCycles();
            return lifeCycles.Where(l => l.RequestId == requestId).ToList();
        }

        public async Task<ComponentReplaceRequestLifeCycle> Add(ComponentReplaceRequestLifeCycle lifeCycle)
        {
            ComponentReplaceRequestLifeCycle result;
            if (lifeCycle.Id == 0) result = await lifeCycleRepository.Add(lifeCycle);
            else result = await lifeCycleRepository.Update(lifeCycle);
            return result;
        }
    }
}
