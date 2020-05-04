using Domain.Models.Requests.Communication;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Communications.Requests
{
    public interface IVideoCommunicationRequestLogic
    {
        Task<VideoCommunicationRequest> Save(VideoCommunicationRequest request);
        Task Delete(VideoCommunicationRequest request);
        Task<VideoCommunicationRequest> GetRequest(int id);
    }
}
