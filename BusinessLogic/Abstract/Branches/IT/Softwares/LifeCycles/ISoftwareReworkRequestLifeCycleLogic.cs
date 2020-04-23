using Domain.Models.Requests.Software;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Softwares.LifeCycles
{
    public interface ISoftwareReworkRequestLifeCycleLogic
    {
        Task<SoftwareReworkRequestLifeCycle> Add(SoftwareReworkRequestLifeCycle lifeCycle);
        Task<List<SoftwareReworkRequestLifeCycle>> GetLifeCycles(SoftwareReworkRequest request);
    }
}
