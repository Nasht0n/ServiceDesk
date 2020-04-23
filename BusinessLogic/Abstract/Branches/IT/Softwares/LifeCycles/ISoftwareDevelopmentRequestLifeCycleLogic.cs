using Domain.Models.Requests.Software;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Softwares.LifeCycles
{
    public interface ISoftwareDevelopmentRequestLifeCycleLogic
    {
        Task<SoftwareDevelopmentRequestLifeCycle> Add(SoftwareDevelopmentRequestLifeCycle lifeCycle);
        Task<List<SoftwareDevelopmentRequestLifeCycle>> GetLifeCycles(SoftwareDevelopmentRequest request);
    }
}
