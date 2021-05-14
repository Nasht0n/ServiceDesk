using BusinessLogic.Abstract.Branches.IT.Events.Requests;
using Domain.Models.Requests.Events;
using Repository.Abstract.Branches.IT.Events.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Events.Requests
{
    public class VideoCommunicationRequestLogic : IVideoCommunicationRequestLogic
    {
        private readonly IVideoCommunicationRequestRepository repository;

        public VideoCommunicationRequestLogic(IVideoCommunicationRequestRepository repository)
        {
            this.repository = repository;
        }

        public async Task Delete(VideoCommunicationRequest request)
        {
            await repository.Delete(request);
        }

        public async Task<VideoCommunicationRequest> GetRequest(int id)
        {
            var requests = await repository.GetRequests();
            return requests.SingleOrDefault(r => r.Id == id);
        }

        public async Task<VideoCommunicationRequest> GetRequest(DateTime start, DateTime end, string location)
        {
            var requests = await repository.GetRequests();
            return requests.SingleOrDefault(r => r.Location == location && r.StartDateTime >= start && r.EndDateTime <= end);
        }

        public async Task<List<VideoCommunicationRequest>> GetRequests()
        {
            return await repository.GetRequests();
        }

        public async Task<VideoCommunicationRequest> Save(VideoCommunicationRequest request)
        {
            VideoCommunicationRequest result;
            if (request.Id == 0) result = await repository.Add(request);
            else result = await repository.Update(request);
            return result;
        }
    }
}
