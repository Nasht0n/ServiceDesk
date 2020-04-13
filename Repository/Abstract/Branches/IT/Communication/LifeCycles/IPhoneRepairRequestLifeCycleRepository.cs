using Domain.Models.Requests.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Communication.LifeCycles
{
    public interface IPhoneRepairRequestLifeCycleRepository
    {
        Task<PhoneRepairRequestLifeCycle> Add(PhoneRepairRequestLifeCycle lifeCycle);
        Task<PhoneRepairRequestLifeCycle> Update(PhoneRepairRequestLifeCycle lifeCycle);
        Task Delete(PhoneRepairRequestLifeCycle lifeCycle);
        Task<List<PhoneRepairRequestLifeCycle>> GetLifeCycles();
    }
}
