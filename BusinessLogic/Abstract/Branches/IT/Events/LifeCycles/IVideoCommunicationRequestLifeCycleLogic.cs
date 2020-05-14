using Domain.Models.Requests.Events;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Events.LifeCycles
{
    public interface IVideoCommunicationRequestLifeCycleLogic
    {
        Task<VideoCommunicationRequestLifeCycle> Add(VideoCommunicationRequestLifeCycle lifeCycle);
        Task<List<VideoCommunicationRequestLifeCycle>> GetLifeCycles(VideoCommunicationRequest request);
    }
}
