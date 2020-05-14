using BusinessLogic.Abstract.Branches.IT.Events.LifeCycles;
using Domain.Models.Requests.Events;
using Repository.Abstract.Branches.IT.Events.LifeCycles;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Events.LifeCycles
{
    public class TechnicalSupportEventRequestLifeCycleLogic : ITechnicalSupportEventRequestLifeCycleLogic
    {
        private readonly ITechnicalSupportEventRequestLifeCycleRepository repository;

        public TechnicalSupportEventRequestLifeCycleLogic(ITechnicalSupportEventRequestLifeCycleRepository repository)
        {
            this.repository = repository;
        }

        public async Task<TechnicalSupportEventRequestLifeCycle> Add(TechnicalSupportEventRequestLifeCycle lifeCycle)
        {
            return await repository.Add(lifeCycle);
        }

        public async Task<List<TechnicalSupportEventRequestLifeCycle>> GetLifeCycles(TechnicalSupportEventRequest request)
        {
            var lifeCycles = await repository.GetLifeCycles();
            return lifeCycles.Where(lc => lc.RequestId == request.Id).ToList();
        }
    }
}
