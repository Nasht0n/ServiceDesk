using Domain.Models.Requests.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Communication.LifeCycles
{
    public interface IPhoneLineRepairRequestLifeCycleRepository
    {
        Task<PhoneLineRepairRequestLifeCycle> Add(PhoneLineRepairRequestLifeCycle lifeCycle);
        Task<PhoneLineRepairRequestLifeCycle> Update(PhoneLineRepairRequestLifeCycle lifeCycle);
        Task Delete(PhoneLineRepairRequestLifeCycle lifeCycle);
        Task<List<PhoneLineRepairRequestLifeCycle>> GetLifeCycles();
    }
}
