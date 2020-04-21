using BusinessLogic.Abstract.Branches.IT.Communications.Requests;
using Domain.Models.Requests.Communication;
using Repository.Abstract.Branches.IT.Communication.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Communications.Requests
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

        public async Task<VideoCommunicationRequest> GetRequestById(int id)
        {
            var requests = await repository.GetRequests();
            return requests.SingleOrDefault(r => r.Id == id);
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
