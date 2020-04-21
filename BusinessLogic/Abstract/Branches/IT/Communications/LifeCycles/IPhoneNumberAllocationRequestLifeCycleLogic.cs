using Domain.Models.Requests.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Communications.LifeCycles
{
    public interface IPhoneNumberAllocationRequestLifeCycleLogic
    {
        Task<PhoneNumberAllocationRequestLifeCycle> Add(PhoneNumberAllocationRequestLifeCycle lifeCycle);
        Task<List<PhoneNumberAllocationRequestLifeCycle>> GetLifeCycles(PhoneNumberAllocationRequest request);
    }
}
