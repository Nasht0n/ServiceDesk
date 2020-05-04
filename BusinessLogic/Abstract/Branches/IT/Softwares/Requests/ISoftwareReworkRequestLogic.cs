using Domain.Models.Requests.Software;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Softwares.Requests
{
    public interface ISoftwareReworkRequestLogic
    {
        Task<SoftwareReworkRequest> Save(SoftwareReworkRequest request);
        Task Delete(SoftwareReworkRequest request);
        Task<SoftwareReworkRequest> GetRequest(int id);
    }
}
