using Domain.Models.Requests.Events;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Events.LifeCycles
{
    public interface ITechnicalSupportEventRequestLifeCycleRepository
    {
        Task<TechnicalSupportEventRequestLifeCycle> Add(TechnicalSupportEventRequestLifeCycle lifeCycle);
        Task<TechnicalSupportEventRequestLifeCycle> Update(TechnicalSupportEventRequestLifeCycle lifeCycle);
        Task Delete(TechnicalSupportEventRequestLifeCycle lifeCycle);
        Task<List<TechnicalSupportEventRequestLifeCycle>> GetLifeCycles();
    }
}
