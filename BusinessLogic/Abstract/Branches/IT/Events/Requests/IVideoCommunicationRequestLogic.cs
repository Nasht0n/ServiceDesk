using Domain.Models;
using Domain.Models.Requests.Events;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Events.Requests
{
    public interface IVideoCommunicationRequestLogic
    {
        Task<VideoCommunicationRequest> Save(VideoCommunicationRequest request);
        Task Delete(VideoCommunicationRequest request);
        Task<VideoCommunicationRequest> GetRequest(int id);
        Task<List<VideoCommunicationRequest>> GetRequests();
        Task<List<VideoCommunicationRequest>> GetRequests(DateTime start, DateTime end);
        Task<VideoCommunicationRequest> GetRequest(DateTime start, DateTime end, string location, int campusId);
    }
}
