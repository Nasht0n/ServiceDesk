using Domain.Models.Requests.Software;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Software.LifeCycles
{
    public interface ISoftwareDevelopmentRequestLifeCycleRepository
    {
        Task<SoftwareDevelopmentRequestLifeCycle> Add(SoftwareDevelopmentRequestLifeCycle lifeCycle);
        Task<SoftwareDevelopmentRequestLifeCycle> Update(SoftwareDevelopmentRequestLifeCycle lifeCycle);
        Task Delete(SoftwareDevelopmentRequestLifeCycle lifeCycle);
        Task<List<SoftwareDevelopmentRequestLifeCycle>> GetLifeCycles();
    }
}
