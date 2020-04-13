using Domain.Models.Requests.Software;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Software.Requests
{
    public interface ISoftwareDevelopmentRequestRepository
    {
        Task<SoftwareDevelopmentRequest> Add(SoftwareDevelopmentRequest request);
        Task<SoftwareDevelopmentRequest> Update(SoftwareDevelopmentRequest request);
        Task Delete(SoftwareDevelopmentRequest request);
        Task<List<SoftwareDevelopmentRequest>> GetRequests();
    }
}
