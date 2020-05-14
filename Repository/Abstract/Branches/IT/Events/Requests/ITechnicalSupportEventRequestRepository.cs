using Domain.Models.Requests.Events;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Events.Requests
{
    public interface ITechnicalSupportEventRequestRepository
    {
        Task<TechnicalSupportEventRequest> Add(TechnicalSupportEventRequest request);
        Task<TechnicalSupportEventRequest> Update(TechnicalSupportEventRequest request);
        Task Delete(TechnicalSupportEventRequest request);
        Task<List<TechnicalSupportEventRequest>> GetRequests();
    }
}
