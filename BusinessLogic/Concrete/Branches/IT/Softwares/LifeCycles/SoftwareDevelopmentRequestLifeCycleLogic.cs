using BusinessLogic.Abstract.Branches.IT.Softwares.LifeCycles;
using Domain.Models.Requests.Software;
using Repository.Abstract.Branches.IT.Software.LifeCycles;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Softwares.LifeCycles
{
    public class SoftwareDevelopmentRequestLifeCycleLogic : ISoftwareDevelopmentRequestLifeCycleLogic
    {
        private readonly ISoftwareDevelopmentRequestLifeCycleRepository repository;

        public SoftwareDevelopmentRequestLifeCycleLogic(ISoftwareDevelopmentRequestLifeCycleRepository repository)
        {
            this.repository = repository;
        }

        public async Task<SoftwareDevelopmentRequestLifeCycle> Add(SoftwareDevelopmentRequestLifeCycle lifeCycle)
        {
            return await repository.Add(lifeCycle);
        }

        public async Task<List<SoftwareDevelopmentRequestLifeCycle>> GetLifeCycles(SoftwareDevelopmentRequest request)
        {
            var lifeCycles = await repository.GetLifeCycles();
            return lifeCycles.Where(lc => lc.RequestId == request.Id).ToList();
        }
    }
}
