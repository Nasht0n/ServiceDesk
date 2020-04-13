using Domain.Models.Requests.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Communication.LifeCycles
{
    public interface IPhoneNumberAllocationRequestLifeCycleRepository
    {
        Task<PhoneNumberAllocationRequestLifeCycle> Add(PhoneNumberAllocationRequestLifeCycle lifeCycle);
        Task<PhoneNumberAllocationRequestLifeCycle> Update(PhoneNumberAllocationRequestLifeCycle lifeCycle);
        Task Delete(PhoneNumberAllocationRequestLifeCycle lifeCycle);
        Task<List<PhoneNumberAllocationRequestLifeCycle>> GetLifeCycles();
    }
}
