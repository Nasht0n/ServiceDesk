using BusinessLogic.Abstract.Branches.IT.Communications.LifeCycles;
using Domain.Models.Requests.Communication;
using Repository.Abstract.Branches.IT.Communication.LifeCycles;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Communications.LifeCycles
{
    public class PhoneNumberAllocationRequestLifeCycleLogic : IPhoneNumberAllocationRequestLifeCycleLogic
    {
        private readonly IPhoneNumberAllocationRequestLifeCycleRepository repository;

        public PhoneNumberAllocationRequestLifeCycleLogic(IPhoneNumberAllocationRequestLifeCycleRepository repository)
        {
            this.repository = repository;
        }

        public async Task<PhoneNumberAllocationRequestLifeCycle> Add(PhoneNumberAllocationRequestLifeCycle lifeCycle)
        {
            return await repository.Add(lifeCycle);
        }

        public async Task<List<PhoneNumberAllocationRequestLifeCycle>> GetLifeCycles(PhoneNumberAllocationRequest request)
        {
            var lifeCycles = await repository.GetLifeCycles();
            return lifeCycles.Where(lc => lc.RequestId == request.Id).ToList();
        }
    }
}
