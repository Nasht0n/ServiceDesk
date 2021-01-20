using Domain.Models.Requests.Software;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Softwares.Requests
{
    public interface IInformationStatusRequestLogic
    {
        Task<InformationStatusRequest> Save(InformationStatusRequest request);
        Task Delete(InformationStatusRequest request);
        Task<InformationStatusRequest> GetRequest(int id);
    }
}
