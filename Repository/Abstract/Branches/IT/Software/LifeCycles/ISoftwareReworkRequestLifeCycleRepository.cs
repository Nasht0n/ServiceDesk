using Domain.Models.Requests.Software;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Software.LifeCycles
{
    public interface ISoftwareReworkRequestLifeCycleRepository
    {
        Task<SoftwareReworkRequestLifeCycle> Add(SoftwareReworkRequestLifeCycle lifeCycle);
        Task<SoftwareReworkRequestLifeCycle> Update(SoftwareReworkRequestLifeCycle lifeCycle);
        Task Delete(SoftwareReworkRequestLifeCycle lifeCycle);
        Task<List<SoftwareReworkRequestLifeCycle>> GetLifeCycles();
    }
}
