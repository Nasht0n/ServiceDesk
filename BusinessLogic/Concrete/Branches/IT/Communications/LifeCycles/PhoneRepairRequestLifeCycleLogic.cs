using BusinessLogic.Abstract.Branches.IT.Communications.LifeCycles;
using Domain.Models.Requests.Communication;
using Repository.Abstract.Branches.IT.Communication.LifeCycles;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Communications.LifeCycles
{
    public class PhoneRepairRequestLifeCycleLogic : IPhoneRepairRequestLifeCycleLogic
    {
        private readonly IPhoneRepairRequestLifeCycleRepository repository;

        public PhoneRepairRequestLifeCycleLogic(IPhoneRepairRequestLifeCycleRepository repository)
        {
            this.repository = repository;
        }

        public async Task<PhoneRepairRequestLifeCycle> Add(PhoneRepairRequestLifeCycle lifeCycle)
        {
            return await repository.Add(lifeCycle);
        }

        public async Task<List<PhoneRepairRequestLifeCycle>> GetLifeCycles(PhoneRepairRequest request)
        {
            var lifeCycles = await repository.GetLifeCycles();
            return lifeCycles.Where(r => r.RequestId == request.Id).ToList();
        }
    }
}
