using Domain.Models.Requests.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Communications.LifeCycles
{
    public interface IHoldingPhoneLineRequestLifeCycleLogic
    {
        Task<HoldingPhoneLineRequestLifeCycle> Add(HoldingPhoneLineRequestLifeCycle lifeCycle);
        Task<List<HoldingPhoneLineRequestLifeCycle>> GetLifeCycles(HoldingPhoneLineRequest request);
    }
}
