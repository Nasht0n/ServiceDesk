using Domain.Models.Requests.Events;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Events.LifeCycles
{
    public interface ITechnicalSupportEventRequestLifeCycleLogic
    {
        Task<TechnicalSupportEventRequestLifeCycle> Add(TechnicalSupportEventRequestLifeCycle lifeCycle);
        Task<List<TechnicalSupportEventRequestLifeCycle>> GetLifeCycles(TechnicalSupportEventRequest request);
    }
}
