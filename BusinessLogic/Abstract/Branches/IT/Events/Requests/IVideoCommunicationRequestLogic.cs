﻿using Domain.Models.Requests.Events;
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
    }
}
