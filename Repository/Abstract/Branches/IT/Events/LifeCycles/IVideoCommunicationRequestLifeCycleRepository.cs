using Domain.Models.Requests.Events;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Events.LifeCycles
{
    public interface IVideoCommunicationRequestLifeCycleRepository
    {
        Task<VideoCommunicationRequestLifeCycle> Add(VideoCommunicationRequestLifeCycle lifeCycle);
        Task<VideoCommunicationRequestLifeCycle> Update(VideoCommunicationRequestLifeCycle lifeCycle);
        Task Delete(VideoCommunicationRequestLifeCycle lifeCycle);
        Task<List<VideoCommunicationRequestLifeCycle>> GetLifeCycles();
    }
}
