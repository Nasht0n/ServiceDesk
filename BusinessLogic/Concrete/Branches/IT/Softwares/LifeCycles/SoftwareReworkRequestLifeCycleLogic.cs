using BusinessLogic.Abstract.Branches.IT.Softwares.LifeCycles;
using Domain.Models.Requests.Software;
using Repository.Abstract.Branches.IT.Software.LifeCycles;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Softwares.LifeCycles
{
    public class SoftwareReworkRequestLifeCycleLogic : ISoftwareReworkRequestLifeCycleLogic
    {
        private readonly ISoftwareReworkRequestLifeCycleRepository repository;

        public SoftwareReworkRequestLifeCycleLogic(ISoftwareReworkRequestLifeCycleRepository repository)
        {
            this.repository = repository;
        }

        public async Task<SoftwareReworkRequestLifeCycle> Add(SoftwareReworkRequestLifeCycle lifeCycle)
        {
            return await repository.Add(lifeCycle);
        }

        public async Task<List<SoftwareReworkRequestLifeCycle>> GetLifeCycles(SoftwareReworkRequest request)
        {
            var lifeCycles = await repository.GetLifeCycles();
            return lifeCycles.Where(lc => lc.RequestId == request.Id).ToList();
        }
    }
}
