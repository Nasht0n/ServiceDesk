using Domain.Models.Requests.Software;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Softwares.LifeCycles
{
    public interface IInformationStatusRequestLifeCycleLogic
    {
        Task<InformationStatusRequestLifeCycle> Add(InformationStatusRequestLifeCycle lifeCycle);
        Task<List<InformationStatusRequestLifeCycle>> GetLifeCycles(InformationStatusRequest request);
    }
}
