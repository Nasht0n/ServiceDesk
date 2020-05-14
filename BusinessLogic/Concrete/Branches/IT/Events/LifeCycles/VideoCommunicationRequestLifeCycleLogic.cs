using BusinessLogic.Abstract.Branches.IT.Events.LifeCycles;
using Domain.Models.Requests.Events;
using Repository.Abstract.Branches.IT.Events.LifeCycles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Events.LifeCycles
{
    public class VideoCommunicationRequestLifeCycleLogic : IVideoCommunicationRequestLifeCycleLogic
    {
        private readonly IVideoCommunicationRequestLifeCycleRepository repository;

        public VideoCommunicationRequestLifeCycleLogic(IVideoCommunicationRequestLifeCycleRepository repository)
        {
            this.repository = repository;
        }

        public async Task<VideoCommunicationRequestLifeCycle> Add(VideoCommunicationRequestLifeCycle lifeCycle)
        {
            return await repository.Add(lifeCycle);
        }

        public async Task<List<VideoCommunicationRequestLifeCycle>> GetLifeCycles(VideoCommunicationRequest request)
        {
            var lifeCycles = await repository.GetLifeCycles();
            return lifeCycles.Where(lc => lc.RequestId == request.Id).ToList();
        }
    }
}
