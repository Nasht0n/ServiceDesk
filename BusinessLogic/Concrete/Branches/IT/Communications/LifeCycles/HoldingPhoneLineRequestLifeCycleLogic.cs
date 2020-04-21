using BusinessLogic.Abstract.Branches.IT.Communications.LifeCycles;
using Domain.Models.Requests.Communication;
using Repository.Abstract.Branches.IT.Communication.LifeCycles;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Communications.LifeCycles
{
    public class HoldingPhoneLineRequestLifeCycleLogic : IHoldingPhoneLineRequestLifeCycleLogic
    {
        private readonly IHoldingPhoneLineRequestLifeCycleRepository repository;

        public HoldingPhoneLineRequestLifeCycleLogic(IHoldingPhoneLineRequestLifeCycleRepository repository)
        {
            this.repository = repository;
        }

        public async Task<HoldingPhoneLineRequestLifeCycle> Add(HoldingPhoneLineRequestLifeCycle lifeCycle)
        {
            return await repository.Add(lifeCycle);
        }

        public async Task<List<HoldingPhoneLineRequestLifeCycle>> GetLifeCycles(HoldingPhoneLineRequest request)
        {
            var lifeCycles = await repository.GetLifeCycles();
            return lifeCycles.Where(lc => lc.RequestId == request.Id).ToList();
        }
    }
}
