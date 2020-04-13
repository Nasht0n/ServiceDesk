using Domain.Models.Requests.Software;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Software.Requests
{
    public interface ISoftwareReworkRequestRepository
    {
        Task<SoftwareReworkRequest> Add(SoftwareReworkRequest request);
        Task<SoftwareReworkRequest> Update(SoftwareReworkRequest request);
        Task Delete(SoftwareReworkRequest request);
        Task<List<SoftwareReworkRequest>> GetRequests();
    }
}
