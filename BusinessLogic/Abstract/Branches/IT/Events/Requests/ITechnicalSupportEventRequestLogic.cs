using Domain.Models.Requests.Events;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Events.Requests
{
    public interface ITechnicalSupportEventRequestLogic
    {
        Task<TechnicalSupportEventRequest> Save(TechnicalSupportEventRequest request);
        Task Delete(TechnicalSupportEventRequest request);
        Task<TechnicalSupportEventRequest> GetRequest(int id);
    }
}
