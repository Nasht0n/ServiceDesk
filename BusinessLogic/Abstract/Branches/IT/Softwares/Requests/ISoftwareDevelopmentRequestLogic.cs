using Domain.Models.Requests.Software;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Softwares.Requests
{
    public interface ISoftwareDevelopmentRequestLogic
    {
        Task<SoftwareDevelopmentRequest> Save(SoftwareDevelopmentRequest request);
        Task Delete(SoftwareDevelopmentRequest request);
        Task<SoftwareDevelopmentRequest> GetRequestById(int id);
    }
}
