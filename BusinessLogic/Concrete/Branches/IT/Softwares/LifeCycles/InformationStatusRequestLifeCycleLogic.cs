using BusinessLogic.Abstract.Branches.IT.Softwares.LifeCycles;
using Domain.Models.Requests.Software;
using Repository.Abstract.Branches.IT.Software.LifeCycles;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Softwares.LifeCycles
{
    public class InformationStatusRequestLifeCycleLogic : IInformationStatusRequestLifeCycleLogic
    {
        private readonly IInformationStatusRequestLifeCycleRepository repository;

        public InformationStatusRequestLifeCycleLogic(IInformationStatusRequestLifeCycleRepository repository)
        {
            this.repository = repository;
        }

        public async Task<InformationStatusRequestLifeCycle> Add(InformationStatusRequestLifeCycle lifeCycle)
        {
            return await repository.Add(lifeCycle);
        }

        public async Task<List<InformationStatusRequestLifeCycle>> GetLifeCycles(InformationStatusRequest request)
        {
            var lifeCycles = await repository.GetLifeCycles();
            return lifeCycles.Where(lc => lc.RequestId == request.Id).ToList();
        }
    }
}
