using Domain.Models.Requests.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Communications.LifeCycles
{
    public interface IPhoneLineRepairRequestLifeCycleLogic
    {
        Task<PhoneLineRepairRequestLifeCycle> Add(PhoneLineRepairRequestLifeCycle lifeCycle);
        Task<List<PhoneLineRepairRequestLifeCycle>> GetLifeCycles(PhoneLineRepairRequest request);
    }
}
