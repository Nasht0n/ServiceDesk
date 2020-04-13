using Domain.Models.Requests.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Communication.LifeCycles
{
    public interface IHoldingPhoneLineRequestLifeCycleRepository
    {
        Task<HoldingPhoneLineRequestLifeCycle> Add(HoldingPhoneLineRequestLifeCycle lifeCycle);
        Task<HoldingPhoneLineRequestLifeCycle> Update(HoldingPhoneLineRequestLifeCycle lifeCycle);
        Task Delete(HoldingPhoneLineRequestLifeCycle lifeCycle);
        Task<List<HoldingPhoneLineRequestLifeCycle>> GetLifeCycles();
    }
}
