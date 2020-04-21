using Domain.Models.Requests.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Communications.LifeCycles
{
    public interface IPhoneRepairRequestLifeCycleLogic
    {
        Task<PhoneRepairRequestLifeCycle> Add(PhoneRepairRequestLifeCycle lifeCycle);
        Task<List<PhoneRepairRequestLifeCycle>> GetLifeCycles(PhoneRepairRequest request);
    }
}
