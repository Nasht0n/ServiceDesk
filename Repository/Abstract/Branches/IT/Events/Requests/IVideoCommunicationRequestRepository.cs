using Domain.Models.Requests.Events;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Events.Requests
{
    public interface IVideoCommunicationRequestRepository
    {
        Task<VideoCommunicationRequest> Add(VideoCommunicationRequest request);
        Task<VideoCommunicationRequest> Update(VideoCommunicationRequest request);
        Task Delete(VideoCommunicationRequest request);
        Task<List<VideoCommunicationRequest>> GetRequests();
    }
}
